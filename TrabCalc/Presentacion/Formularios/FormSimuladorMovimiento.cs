using NAudio.Wave;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Windows.Forms;
using TrabCalc.Negocios.Movimiento;
using TrabCalc.Servicios;
using TrabCalc.Servicios.Exportacion;
using TrabCalc.Servicios.Historial;
using TrabCalc.Servicios.UI;

namespace TrabCalc
{

    public partial class FormSimuladorMovimiento : Form
    {
        private bool isAnimating = false;

        // Variables para simulación de integrales
        private double masa = 250;
        private double kResistencia = 0.4;
        private double velocidadInicial = 0.0;
        private double aceleracion = 4.0;
        private double aceleracionMin = 2.0;
        private double tiempoTotal = 0.0;
        private double velocidadMaxima = 1.0;
        private double tiempoActual = 0.0;
        private bool simulacionActiva = false;
        private System.Windows.Forms.Timer timerSimulacion;
        private bool esAceleracionConstante;

        // Resultados calculados
        private double distanciaRecorrida = 0.0;
        private double velocidadFinal = 0.0;
        private double trabajoRealizado = 0.0;

        //pa la animación
        private double pistaOffset = 0;
        private double fondoOffset = 0;
        private double aceleracionVisualActual = 0;
        private Image fondoImage, pistaImage, carroImage;
        private bool imagesLoaded = false;
        const double metrosPorPixel = 0.3;
        const double factorMovimientoPista = 7.5;
        const double factorMovimientoFondo = 0.10;


        //Graficas
        private List<double> listaTiempos = new List<double>();
        private List<double> listaVelocidades = new List<double>();
        private List<double> listaAceleraciones = new List<double>();
        private List<double> listaTrabajos = new List<double>();
        private double cursorTiempoVelocidad = -1;
        private double cursorTiempoAceleracion = -1;
        private double cursorTiempoTrabajo = -1;
        private readonly ToolTip ayuda = new ToolTip();
        private int indiceMovimientoConfirmado = -1;
        private bool restaurandoMovimiento;

        bool isPaused = false;

        double velocidadActual = 1.0;
        private bool parametrosVariableConfigurados = false;

        public double Masa { get => masa; set => masa = value; }
        public double KResistencia { get => kResistencia; set => kResistencia = value; }
        public double VelocidadInicial { get => velocidadInicial; set => velocidadInicial = value; }
        public double Aceleracion { get => aceleracion; set => aceleracion = value; }
        public double TiempoTotal { get => tiempoTotal; set => tiempoTotal = value; }
        public double VelocidadMaxima { get => velocidadMaxima; set => velocidadMaxima = value; }
        public double TiempoActual { get => tiempoActual; set => tiempoActual = value; }
        public double AceleracionMin { get => aceleracionMin; set => aceleracionMin = value; }

        public FormSimuladorMovimiento()
        {
            InitializeComponent();
            AppManager.RegisterForm(this);
            this.TransparencyKey = Color.DarkBlue;
            KeyPreview = true;
            KeyDown += FormSimuladorMovimiento_KeyDown;
            SetStyle(ControlStyles.AllPaintingInWmPaint |
             ControlStyles.UserPaint |
             ControlStyles.DoubleBuffer, true);

            ConfigurarEventosPanel();
            ConfigurarTooltips();
            LoadImages();
            InicializarSimulacion();
            ConfigurarLayoutResponsivo();
            timer1.Start();
            PlaySound("snd/Form.wav");
        }

        private double MsAKmh(double velocidadMs)
        {
            return ConversorUnidades.MsAKmh(velocidadMs);
        }

        private double KmhAMs(double velocidadKmh)
        {
            return ConversorUnidades.KmhAMs(velocidadKmh);
        }
        private void LoadImages()
        {
            try
            {
                fondoImage = LoadImageSafely("img/fondo.png");
                pistaImage = LoadImageSafely("img/pista.png");
                carroImage = LoadImageSafely("img/carro.png");
                imagesLoaded = true;
            }
            catch (Exception ex)
            {
                DialogoApp.MostrarError(this, $"Error cargando recursos: {ex.Message}");
                imagesLoaded = false;
            }
        }

        private Image LoadImageSafely(string path)
        {
            try
            {
                string rutaFinal = RutasApp.Resolver(path);
                if (System.IO.File.Exists(rutaFinal))
                {
                    return Image.FromFile(rutaFinal);
                }
                else
                {
                    return CreateDefaultImage(path);
                }
            }
            catch (Exception ex)
            {
                DialogoApp.MostrarError(this, $"Error cargando {path}: {ex.Message}");
                return CreateDefaultImage(path);
            }
        }

        private Image CreateDefaultImage(string imageName)
        {
            Bitmap defaultImg = new Bitmap(100, 50);
            using (Graphics g = Graphics.FromImage(defaultImg))
            {
                g.Clear(Color.LightGray);
                g.DrawString(imageName, new Font("Arial", 8), Brushes.Black, 5, 5);
                g.DrawRectangle(Pens.Black, 0, 0, 99, 49);
            }
            return defaultImg;
        }

        public void RefrescarTodo()
        {
            ActualizarResultados();
            DibujarAnimacion();
        }


        private void InicializarSimulacion()
        {
            cursorTiempoVelocidad = -1;
            cursorTiempoAceleracion = -1;
            cursorTiempoTrabajo = -1;
            panelVelocidad.Invalidate();
            panelAceleracion.Invalidate();
            panelTrabajo.Invalidate();

            listaTiempos.Clear();
            listaVelocidades.Clear();
            listaAceleraciones.Clear();
            listaTrabajos.Clear();

            timerSimulacion = new System.Windows.Forms.Timer();
            timerSimulacion.Interval = 50;
            timerSimulacion.Tick += TimerSimulacion_Tick;

            // Configurar valores por defecto
            VelocidadInicial = 0.0;
            Aceleracion = 2.0;
            TiempoTotal = 10.0;
            VelocidadMaxima = 90.0;
            esAceleracionConstante = true;
            btnPausa.Enabled = false;
            btnMostrarProcedimiento.Enabled = false;
            lblSimulacionCompletada.Visible = false;

            ActualizarResultados();
        }

        private void ConfigurarLayoutResponsivo()
        {
            TemaApp.AplicarFormularioPrincipal(this, pb2, new Size(820, 620));
            pb2.Resize += (s, e) => ReacomodarLayoutMovimiento();
            guna2CustomGradientPanel1.Resize += (s, e) => ReacomodarPanelGraficas();
            ReacomodarLayoutMovimiento();
        }

        private void ReacomodarLayoutMovimiento()
        {
            if (pb2.ClientSize.Width <= 0 || pb2.ClientSize.Height <= 0)
            {
                return;
            }

            int margen = 18;
            int panelIzquierdo = 345;
            int separacion = 16;
            int xGraficas = panelIzquierdo + separacion;
            int anchoGraficas = Math.Max(380, pb2.ClientSize.Width - xGraficas - margen);
            int altoGraficas = Math.Max(360, pb2.ClientSize.Height - margen * 2);

            guna2CustomGradientPanel1.Location = new Point(xGraficas, margen);
            guna2CustomGradientPanel1.Size = new Size(anchoGraficas, altoGraficas);

            int topBotones = pb2.ClientSize.Height - btnSalir.Height - 14;
            btnSalir.Location = new Point(24, topBotones);
            btnSalir.Size = new Size(96, btnSalir.Height);
            btnExportarResultados.Location = new Point(128, topBotones);
            btnExportarResultados.Size = new Size(112, btnExportarResultados.Height);
            btnCopiarResultados.Location = new Point(248, topBotones);
            btnCopiarResultados.Size = new Size(86, btnCopiarResultados.Height);
            btnMostrarProcedimiento.Location = new Point(24, Math.Max(510, topBotones - btnMostrarProcedimiento.Height - 10));
            btnMostrarProcedimiento.Size = new Size(panelIzquierdo - 42, btnMostrarProcedimiento.Height);

            ReacomodarPanelGraficas();
        }

        private void ReacomodarPanelGraficas()
        {
            int margen = 16;
            int separacion = 8;
            int anchoContenido = Math.Max(120, guna2CustomGradientPanel1.ClientSize.Width - margen * 2);
            int altoContenido = Math.Max(120, guna2CustomGradientPanel1.ClientSize.Height - margen * 2);
            int altoEscena = Math.Max(210, (int)(altoContenido * 0.56));
            int yGraficas = margen + altoEscena + separacion;
            int altoGraficas = Math.Max(120, altoContenido - altoEscena - separacion);
            int anchoGrafica = Math.Max(90, (anchoContenido - separacion * 2) / 3);

            panel1.Location = new Point(margen, margen);
            panel1.Size = new Size(anchoContenido, altoEscena);
            panelVelocidad.Location = new Point(margen, yGraficas);
            panelVelocidad.Size = new Size(anchoGrafica, altoGraficas);
            panelAceleracion.Location = new Point(margen + anchoGrafica + separacion, yGraficas);
            panelAceleracion.Size = new Size(anchoGrafica, altoGraficas);
            panelTrabajo.Location = new Point(margen + (anchoGrafica + separacion) * 2, yGraficas);
            panelTrabajo.Size = new Size(Math.Max(90, anchoContenido - (anchoGrafica + separacion) * 2), altoGraficas);

            DibujarAnimacion();
            DibujarGraficas();
        }

        private void TimerSimulacion_Tick(object sender, EventArgs e)
        {
            if (simulacionActiva && !isPaused)
            {
                double deltaT = 0.05;
                double nuevoTiempoActual = TiempoActual + deltaT * velocidadActual;

                bool tiempoExcedido = false;
                if (nuevoTiempoActual >= TiempoTotal)
                {
                    tiempoExcedido = true;
                    double deltaTExacto = (TiempoTotal - TiempoActual) / velocidadActual;
                    nuevoTiempoActual = TiempoTotal;
                    deltaT = deltaTExacto;
                }

                TiempoActual = nuevoTiempoActual;

                CalcularMovimiento();

                double desplazamientoPixeles = velocidadFinal / metrosPorPixel * deltaT * velocidadActual;
                double intensidadAceleracion = Math.Min(1.0, Math.Abs(aceleracionVisualActual) / 6.0);
                double desplazamientoCamino = desplazamientoPixeles * (factorMovimientoPista + intensidadAceleracion * 1.5);

                pistaOffset += desplazamientoCamino;
                fondoOffset += desplazamientoCamino * factorMovimientoFondo;

                ActualizarResultados();
                DibujarAnimacion();

                if (esAceleracionConstante)
                {
                    listaTiempos.Add(TiempoActual);
                    listaVelocidades.Add(MsAKmh(velocidadFinal));
                    listaAceleraciones.Add(ObtenerAceleracionActualConstante());
                    listaTrabajos.Add(trabajoRealizado);
                }

                if (tiempoExcedido)
                {
                    simulacionActiva = false;
                    timerSimulacion.Stop();
                    btnPausa.Text = "Pausar";
                    btnMostrarProcedimiento.Enabled = true;
                    btnCopiarResultados.Visible = true;
                    btnCopiarResultados.Enabled = true;
                    btnExportarResultados.Visible = true;
                    btnExportarResultados.Enabled = true;
                    btnPausa.Enabled = false;
                    cmbMovimiento.Enabled = true;
                    lblSimulacionCompletada.Visible = true;
                    RegistrarHistorial();
                }
            }
        }

        private void CalcularMovimiento()
        {
            string tipoMovimiento = cmbMovimiento.SelectedItem?.ToString() ?? "Aceleración Constante";

            switch (tipoMovimiento)
            {
                case "Aceleración Constante":
                    CalcularAceleracionConstante();
                    break;
                case "Aceleración Variable":
                    CalcularAceleracionVariable();
                    break;
            }
        }

        private void CalcularAceleracionConstante()
        {
            AplicarResultadoMovimiento(CalculadoraMovimiento.CalcularAceleracionConstante(CrearParametrosMovimiento()));
        }

        private double ObtenerAceleracionActualConstante()
        {
            return CalculadoraMovimiento.ObtenerAceleracionActualConstante(CrearParametrosMovimiento(), velocidadFinal);
        }

        private void CalcularAceleracionVariable()
        {
            ResultadoMovimiento resultado = CalculadoraMovimiento.CalcularAceleracionVariable(CrearParametrosMovimiento());
            AplicarResultadoMovimiento(resultado);
            CargarMuestrasMovimiento(resultado);
        }

        private ParametrosMovimiento CrearParametrosMovimiento()
        {
            return new ParametrosMovimiento
            {
                Masa = Masa,
                KResistencia = KResistencia,
                VelocidadInicial = VelocidadInicial,
                AceleracionMaxima = Aceleracion,
                AceleracionMinima = AceleracionMin,
                TiempoActual = TiempoActual,
                VelocidadMaximaKmh = VelocidadMaxima
            };
        }

        private void AplicarResultadoMovimiento(ResultadoMovimiento resultado)
        {
            velocidadFinal = resultado.VelocidadFinal;
            distanciaRecorrida = resultado.DistanciaRecorrida;
            trabajoRealizado = resultado.TrabajoRealizadoKj;
            aceleracionVisualActual = resultado.AceleracionActual;
        }

        private void CargarMuestrasMovimiento(ResultadoMovimiento resultado)
        {
            listaTiempos.Clear();
            listaAceleraciones.Clear();
            listaVelocidades.Clear();
            listaTrabajos.Clear();

            foreach (MuestraMovimiento muestra in resultado.Muestras)
            {
                listaTiempos.Add(muestra.Tiempo);
                listaAceleraciones.Add(muestra.Aceleracion);
                listaVelocidades.Add(muestra.VelocidadKmh);
                listaTrabajos.Add(muestra.TrabajoKj);
            }
        }

        private void ActualizarResultados()
        {
            lblDistancia.Text = FormatoUnidades.Distancia(distanciaRecorrida);
            lblVelFinal.Text = FormatoUnidades.VelocidadKmh(MsAKmh(velocidadFinal));
            lblTrabajoR.Text = FormatoUnidades.TrabajoKj(trabajoRealizado);
        }

        private void DibujarAnimacion()
        {
            if (panel1.InvokeRequired)
            {
                panel1.Invoke(new Action(DibujarAnimacion));
                return;
            }
            panel1.Invalidate();
        }

        private void DrawScene(Graphics g)
        {
            if (!imagesLoaded) return;

            g.Clear(Color.White);

            if (fondoImage != null)
            {
                int fondoWidth = fondoImage.Width;
                int offsetInt = (int)Math.Round(fondoOffset % fondoWidth);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(fondoImage, -offsetInt, 0, fondoWidth, panel1.Height);
                g.DrawImage(fondoImage, -offsetInt + fondoWidth, 0, fondoWidth, panel1.Height);
                g.DrawImage(fondoImage, -offsetInt - fondoWidth, 0, fondoWidth, panel1.Height);
            }

            if (pistaImage != null)
            {
                int pistaY = panel1.Height - pistaImage.Height;
                int pistaWidth = pistaImage.Width;
                int offsetInt = (int)Math.Round(pistaOffset % pistaWidth);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(pistaImage, -offsetInt, pistaY + 110, pistaWidth, pistaImage.Height);
                g.DrawImage(pistaImage, -offsetInt + pistaWidth, pistaY + 110, pistaWidth, pistaImage.Height);
                g.DrawImage(pistaImage, -offsetInt - pistaWidth, pistaY + 110, pistaWidth, pistaImage.Height);
            }

            if (carroImage != null)
            {
                int posicionX = panel1.Width / 4;
                int posicionY = panel1.Height - 35 - carroImage.Height;
                g.DrawImage(carroImage, posicionX, posicionY, carroImage.Width, carroImage.Height);
            }

            string info = $"Tiempo: {FormatoUnidades.TiempoSegundos(TiempoActual)}\n";
            info += $"Velocidad: {FormatoUnidades.VelocidadKmh(MsAKmh(velocidadFinal))}\n";
            info += $"Distancia: {FormatoUnidades.Distancia(distanciaRecorrida)}";

            using (Font font = new Font("Arial", 14, FontStyle.Bold))
            using (System.Drawing.Drawing2D.GraphicsPath tarjeta = CrearRectanguloRedondeado(new RectangleF(10, 10, 260, 92), 8))
            using (Brush fondoInfo = new SolidBrush(Color.FromArgb(220, 245, 250, 255)))
            using (Pen bordeInfo = new Pen(Color.FromArgb(110, Color.MidnightBlue), 1))
            using (Brush textoInfo = new SolidBrush(Color.MidnightBlue))
            {
                g.FillPath(fondoInfo, tarjeta);
                g.DrawPath(bordeInfo, tarjeta);
                g.DrawString(info, font, textoInfo, 20, 20);
            }
            DibujarGraficas();
        }


        private void DibujarGraficas()
        {
            panelVelocidad.Invalidate();
            panelAceleracion.Invalidate();
            panelTrabajo.Invalidate();

        }

        private void DibujarGraficaIndividual(Graphics g, Panel panel, List<double> tiempos, List<double> valores, Color color, string etiqueta, string unidad, double cursorTiempo)
        {
            if (panel == null) return;

            int w = panel.Width;
            int h = panel.Height;
            int margenIzquierdo = 30;
            int margenInferior = 22;
            int margenSuperior = 12;
            int margenDerecho = 8;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            using (Brush fondo = new System.Drawing.Drawing2D.LinearGradientBrush(
                new Rectangle(0, 0, Math.Max(1, w), Math.Max(1, h)),
                Color.White,
                Color.FromArgb(242, 248, 255),
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
            using (Pen borde = new Pen(Color.FromArgb(150, 70, 90, 140), 1))
            {
                g.FillRectangle(fondo, 0, 0, w, h);
                g.DrawRectangle(borde, 0, 0, w - 1, h - 1);
            }

            if (tiempos.Count < 2 || valores.Count < 2)
            {
                using (Font font = new Font("Arial", 8, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.FromArgb(80, Color.MidnightBlue)))
                {
                    g.DrawString(etiqueta, font, brush, margenIzquierdo, h - 16);
                }
                return;
            }

            double tMax = tiempos.Max();
            double vMax = valores.Max();
            double vMin = Math.Min(0, valores.Min());
            if (tMax <= 0) tMax = 1;

            double rango = vMax - vMin;
            if (Math.Abs(rango) < 0.000001)
            {
                rango = 1;
            }

            vMax += rango * 0.08;
            if (vMin < 0)
            {
                vMin -= rango * 0.08;
            }

            double escX = (w - margenIzquierdo - margenDerecho) / tMax;
            double escY = (h - margenSuperior - margenInferior) / (vMax - vMin);

            Func<double, float> convertirX = t => (float)(margenIzquierdo + t * escX);
            Func<double, float> convertirY = v => (float)(h - margenInferior - (v - vMin) * escY);

            using (Pen gridPen = new Pen(Color.FromArgb(215, 220, 230), 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot })
            using (Pen ejePen = new Pen(Color.FromArgb(110, 55, 70, 110), 1.2f))
            using (Font fontEjes = new Font("Arial", 6.8f))
            using (Brush brushEjes = new SolidBrush(Color.FromArgb(95, 20, 30, 55)))
            {
                for (int i = 0; i <= 4; i++)
                {
                    double valor = vMin + (vMax - vMin) * i / 4.0;
                    float y = convertirY(valor);
                    g.DrawLine(gridPen, margenIzquierdo, y, w - margenDerecho, y);
                    g.DrawString(FormatoUnidades.Numero(valor, 1), fontEjes, brushEjes, 2, y - 6);
                }

                for (int i = 1; i <= 3; i++)
                {
                    float x = convertirX(tMax * i / 4.0);
                    g.DrawLine(gridPen, x, margenSuperior, x, h - margenInferior);
                }

                g.DrawLine(ejePen, margenIzquierdo, h - margenInferior, w - margenDerecho, h - margenInferior);
                g.DrawLine(ejePen, margenIzquierdo, margenSuperior, margenIzquierdo, h - margenInferior);
                g.DrawString($"{FormatoUnidades.Numero(tMax, 1)} s", fontEjes, brushEjes, w - 42, h - 13);
            }

            int limite = Math.Min(tiempos.Count, valores.Count);
            PointF[] puntos = new PointF[limite];
            for (int i = 0; i < limite; i++)
            {
                puntos[i] = new PointF(convertirX(tiempos[i]), convertirY(valores[i]));
            }

            if (puntos.Length > 1)
            {
                using (System.Drawing.Drawing2D.GraphicsPath area = new System.Drawing.Drawing2D.GraphicsPath())
                using (Brush relleno = new SolidBrush(Color.FromArgb(28, color)))
                using (Pen penCurva = new Pen(color, 2.4f))
                using (Brush puntoBrush = new SolidBrush(color))
                {
                    penCurva.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    penCurva.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    penCurva.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;

                    area.AddLines(puntos);
                    area.AddLine(puntos[puntos.Length - 1].X, puntos[puntos.Length - 1].Y, puntos[puntos.Length - 1].X, h - margenInferior);
                    area.AddLine(puntos[puntos.Length - 1].X, h - margenInferior, puntos[0].X, h - margenInferior);
                    area.CloseFigure();
                    g.FillPath(relleno, area);

                    g.DrawLines(penCurva, puntos);
                    RectangleF puntoFinal = new RectangleF(puntos[puntos.Length - 1].X - 3, puntos[puntos.Length - 1].Y - 3, 6, 6);
                    g.FillEllipse(puntoBrush, puntoFinal);
                    DibujarEtiquetaValorFinal(g, panel, puntos[puntos.Length - 1], valores[limite - 1], unidad, color);
                }
            }

            using (Font font = new Font("Arial", 7.5f, FontStyle.Bold))
            using (Brush brush = new SolidBrush(Color.FromArgb(210, 18, 29, 72)))
            {
                g.DrawString(etiqueta, font, brush, margenIzquierdo + 2, h - 16);
                g.DrawString($"{FormatoUnidades.Numero(valores.Max(), 1)} {unidad}", font, brush, margenIzquierdo + 2, 4);
            }

            if (cursorTiempo >= 0 && cursorTiempo <= tMax)
            {
                float xCursor = convertirX(cursorTiempo);
                using (Pen cursorPen = new Pen(Color.FromArgb(130, Color.MidnightBlue), 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
                {
                    g.DrawLine(cursorPen, xCursor, margenSuperior, xCursor, h - margenInferior);
                }

                DibujarTooltipGrafica(g, panel, tiempos, valores, etiqueta, unidad, cursorTiempo, xCursor);
            }
        }

        private void DibujarEtiquetaValorFinal(Graphics g, Panel panel, PointF punto, double valor, string unidad, Color color)
        {
            string texto = $"{FormatoUnidades.Numero(valor, 1)} {unidad}";

            using (Font font = new Font("Arial", 7.5F, FontStyle.Bold))
            {
                SizeF tamano = g.MeasureString(texto, font);
                float ancho = tamano.Width + 12;
                float alto = tamano.Height + 8;
                float x = punto.X + 8;
                float y = punto.Y - alto / 2;

                if (x + ancho > panel.Width - 4)
                {
                    x = punto.X - ancho - 8;
                }

                y = Math.Max(4, Math.Min(panel.Height - alto - 4, y));

                RectangleF rect = new RectangleF(Math.Max(4, x), y, ancho, alto);
                using (System.Drawing.Drawing2D.GraphicsPath path = CrearRectanguloRedondeado(rect, 5))
                using (Brush fondo = new SolidBrush(Color.FromArgb(235, 255, 255, 255)))
                using (Pen borde = new Pen(Color.FromArgb(170, color), 1))
                using (Brush textoBrush = new SolidBrush(Color.FromArgb(25, 25, 35)))
                {
                    g.FillPath(fondo, path);
                    g.DrawPath(borde, path);
                    g.DrawString(texto, font, textoBrush, rect.X + 6, rect.Y + 4);
                }
            }
        }

        private void DibujarTooltipGrafica(Graphics g, Panel panel, List<double> tiempos, List<double> valores, string etiqueta, string unidad, double cursorTiempo, float xCursor)
        {
            int indice = tiempos.FindIndex(t => t >= cursorTiempo);
            if (indice < 0) indice = tiempos.Count - 1;
            if (indice >= valores.Count) return;

            string texto = $"{etiqueta}\nTiempo: {tiempos[indice]:0.00} s\nValor: {valores[indice]:0.00} {unidad}";
            using (Font font = new Font("Arial", 7.5F))
            {
                SizeF tamano = g.MeasureString(texto, font);
                float ancho = tamano.Width + 12;
                float alto = tamano.Height + 10;
                float x = xCursor + 8;
                float y = 28;

                if (x + ancho > panel.Width - 4)
                {
                    x = xCursor - ancho - 8;
                }

                if (x < 4) x = 4;

                RectangleF rect = new RectangleF(x, y, ancho, alto);
                using (System.Drawing.Drawing2D.GraphicsPath path = CrearRectanguloRedondeado(rect, 6))
                using (Brush sombra = new SolidBrush(Color.FromArgb(45, Color.Black)))
                using (Brush fondo = new SolidBrush(Color.FromArgb(245, 255, 255, 248)))
                using (Pen borde = new Pen(Color.FromArgb(140, 55, 70, 110), 1))
                using (Brush textoBrush = new SolidBrush(Color.FromArgb(25, 25, 35)))
                {
                    using (System.Drawing.Drawing2D.GraphicsPath sombraPath = CrearRectanguloRedondeado(new RectangleF(rect.X + 2, rect.Y + 2, rect.Width, rect.Height), 6))
                    {
                        g.FillPath(sombra, sombraPath);
                    }

                    g.FillPath(fondo, path);
                    g.DrawPath(borde, path);
                    g.DrawString(texto, font, textoBrush, rect.X + 6, rect.Y + 5);
                }
            }
        }

        private System.Drawing.Drawing2D.GraphicsPath CrearRectanguloRedondeado(RectangleF rect, float radio)
        {
            float diametro = radio * 2;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(rect.X, rect.Y, diametro, diametro, 180, 90);
            path.AddArc(rect.Right - diametro, rect.Y, diametro, diametro, 270, 90);
            path.AddArc(rect.Right - diametro, rect.Bottom - diametro, diametro, diametro, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diametro, diametro, diametro, 90, 90);
            path.CloseFigure();
            return path;
        }


        private void ConfigurarEventosPanel()
        {
            panel1.Paint += Panel1_Paint;

            panelVelocidad.MouseMove += PanelVelocidad_MouseMove;
            panelAceleracion.MouseMove += PanelAceleracion_MouseMove;
            panelTrabajo.MouseMove += PanelTrabajo_MouseMove;

            panelVelocidad.Paint += panelVelocidad_Paint;
            panelAceleracion.Paint += panelAceleracion_Paint;
            panelTrabajo.Paint += panelTrabajo_Paint;
            panelVelocidad.MouseLeave += (s, e) => OcultarTooltipGrafica(panelVelocidad, ref cursorTiempoVelocidad);
            panelAceleracion.MouseLeave += (s, e) => OcultarTooltipGrafica(panelAceleracion, ref cursorTiempoAceleracion);
            panelTrabajo.MouseLeave += (s, e) => OcultarTooltipGrafica(panelTrabajo, ref cursorTiempoTrabajo);

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, panelVelocidad, new object[] { true });

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, panelAceleracion, new object[] { true });

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, panelTrabajo, new object[] { true });

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, panel1, new object[] { true });

        }

        private void ConfigurarTooltips()
        {
            ayuda.SetToolTip(cmbMovimiento, "Elige el tipo de movimiento y abre sus parámetros.");
            ayuda.SetToolTip(trackBarVelocidad, "Velocidad visual de reproducción de la simulación.");
            ayuda.SetToolTip(btnMostrarProcedimiento, "Abre el procedimiento paso a paso.");
            ayuda.SetToolTip(btnCopiarResultados, "Copia el resumen de resultados al portapapeles.");
            ayuda.SetToolTip(btnExportarResultados, "Exporta el resumen o los datos de las grÃ¡ficas.");
            ayuda.SetToolTip(btnHistorial, "Abre el historial de simulaciones.");
        }

        private void FormSimuladorMovimiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && !simulacionActiva)
            {
                button1.PerformClick();
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.Space && simulacionActiva && !ControlConEntradaActivo())
            {
                btnPausa.PerformClick();
                e.Handled = true;
                return;
            }

            if (e.Control && e.KeyCode == Keys.R)
            {
                ReiniciarVelocidad();
                e.Handled = true;
                return;
            }

            if (e.Control && e.KeyCode == Keys.P && btnMostrarProcedimiento.Enabled)
            {
                btnMostrarProcedimiento.PerformClick();
                e.Handled = true;
                return;
            }

            if (e.Control && e.KeyCode == Keys.H)
            {
                MostrarHistorial();
                e.Handled = true;
                return;
            }

            if (e.Control && e.Shift && e.KeyCode == Keys.C && btnCopiarResultados.Enabled)
            {
                btnCopiarResultados.PerformClick();
                e.Handled = true;
            }
        }

        private bool ControlConEntradaActivo()
        {
            return ActiveControl is TextBoxBase || ActiveControl is ComboBox || ActiveControl is NumericUpDown;
        }

        private void ReiniciarVelocidad()
        {
            trackBarVelocidad.Value = 10;
            velocidadActual = 1.0;
            labelVelocidad.Text = $"Velocidad: {FormatoUnidades.VelocidadSimulacion(1.0)}";
        }

        private void panelVelocidad_Paint(object sender, PaintEventArgs e)
        {
            DibujarGraficaIndividual(e.Graphics, panelVelocidad, listaTiempos, listaVelocidades, Color.Red, "Velocidad", "km/h", cursorTiempoVelocidad);
        }

        private void panelAceleracion_Paint(object sender, PaintEventArgs e)
        {
            DibujarGraficaIndividual(e.Graphics, panelAceleracion, listaTiempos, listaAceleraciones, Color.Blue, "Aceleración", "m/s²", cursorTiempoAceleracion);
        }
        private void panelTrabajo_Paint(object sender, PaintEventArgs e)
        {
            DibujarGraficaIndividual(e.Graphics, panelTrabajo, listaTiempos, listaTrabajos, Color.Green, "Trabajo", "kJ", cursorTiempoTrabajo);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            if (!imagesLoaded) return;
            DrawScene(e.Graphics);
        }

        private void PanelVelocidad_MouseMove(object sender, MouseEventArgs e)
        {
            ActualizarTooltipGrafica(panelVelocidad, listaTiempos, listaVelocidades, "Velocidad", "km/h", e, ref cursorTiempoVelocidad);
        }

        private void PanelAceleracion_MouseMove(object sender, MouseEventArgs e)
        {
            ActualizarTooltipGrafica(panelAceleracion, listaTiempos, listaAceleraciones, "Aceleración", "m/s²", e, ref cursorTiempoAceleracion);
        }

        private void PanelTrabajo_MouseMove(object sender, MouseEventArgs e)
        {
            ActualizarTooltipGrafica(panelTrabajo, listaTiempos, listaTrabajos, "Trabajo", "kJ", e, ref cursorTiempoTrabajo);
        }

        private void ActualizarTooltipGrafica(Panel panel, List<double> tiempos, List<double> valores, string etiqueta, string unidad, MouseEventArgs e, ref double cursorTiempo)
        {
            if (tiempos.Count < 2 || valores.Count < 2)
            {
                cursorTiempo = -1;
                panel.Invalidate();
                return;
            }

            int margen = 20;
            double tMax = tiempos.Max();
            if (tMax <= 0) tMax = 1;

            double escX = (panel.Width - margen - 5) / tMax;
            if (escX <= 0)
            {
                cursorTiempo = -1;
                panel.Invalidate();
                return;
            }

            double tiempoMouse = (e.X - margen) / escX;
            if (tiempoMouse < 0 || tiempoMouse > tMax)
            {
                cursorTiempo = -1;
                panel.Invalidate();
                return;
            }

            int indice = tiempos.FindIndex(t => t >= tiempoMouse);
            if (indice < 0) indice = tiempos.Count - 1;
            if (indice >= valores.Count)
            {
                cursorTiempo = -1;
                panel.Invalidate();
                return;
            }

            cursorTiempo = tiempos[indice];
            panel.Invalidate();
        }

        private void OcultarTooltipGrafica(Panel panel, ref double cursorTiempo)
        {
            cursorTiempo = -1;
            panel.Invalidate();
        }

        private void trackBarVelocidad_Scroll(object sender, EventArgs e)
        {
            velocidadActual = trackBarVelocidad.Value / 10.0;
            labelVelocidad.Text = $"Velocidad: {FormatoUnidades.VelocidadSimulacion(velocidadActual)}";
        }

        private void btnPausa_Click(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                isPaused = true;
                btnPausa.Text = "Seguir";
            }
            else
            {
                isPaused = false;
                btnPausa.Text = "Pausar";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbMovimiento.Text == "")
            {
                DialogoApp.MostrarError(this, "Seleccione un tipo de movimiento.");
                return;
            }
            IniciarSimulacion();
            btnPausa.Enabled = true;
            btnMostrarProcedimiento.Enabled = false;
            btnCopiarResultados.Visible = false;
            btnCopiarResultados.Enabled = false;
            btnExportarResultados.Visible = false;
            btnExportarResultados.Enabled = false;
            lblSimulacionCompletada.Visible = false;
        }

        private void IniciarSimulacion()
        {
            listaTiempos.Clear();
            listaVelocidades.Clear();
            listaAceleraciones.Clear();
            listaTrabajos.Clear();
            LimpiarGraficas();

            TiempoActual = 0;
            pistaOffset = 0;
            fondoOffset = 0;
            aceleracionVisualActual = 0;
            simulacionActiva = true;
            isPaused = false;
            btnPausa.Text = "Pausar";
            cmbMovimiento.Enabled = false;
            lblSimulacionCompletada.Visible = false;

            distanciaRecorrida = 0;
            velocidadFinal = VelocidadInicial;
            trabajoRealizado = 0;

            ActualizarResultados();
            timerSimulacion.Start();
        }

        public void AplicarParametros(double velInicial, double acel, double tTotal, double velMax, double masaKg, double kResistencia)
        {
            AplicarParametros(new ParametrosAceleracionConstante
            {
                VelocidadInicialKmh = velInicial,
                Aceleracion = acel,
                TiempoTotal = tTotal,
                VelocidadMaximaKmh = velMax,
                Masa = masaKg,
                KResistencia = kResistencia
            });
        }

        public void AplicarParametros(ParametrosAceleracionConstante parametros)
        {
            VelocidadInicial = KmhAMs(parametros.VelocidadInicialKmh);
            Aceleracion = parametros.Aceleracion;
            TiempoTotal = parametros.TiempoTotal;
            VelocidadMaxima = parametros.VelocidadMaximaKmh;
            Masa = parametros.Masa;
            KResistencia = parametros.KResistencia;
            esAceleracionConstante = true;
            lblSimulacionCompletada.Visible = false;
        }

        public void AplicarParametrosVar(double velInicial, double acel, double tTotal, double velMax, double masaKg, double kResistencia, double acelMin)
        {
            AplicarParametrosVar(new ParametrosAceleracionVariable
            {
                VelocidadInicialKmh = velInicial,
                AceleracionMaxima = acel,
                AceleracionMinima = acelMin,
                TiempoTotal = tTotal,
                VelocidadMaximaKmh = velMax,
                Masa = masaKg,
                KResistencia = kResistencia
            });
        }

        public void AplicarParametrosVar(ParametrosAceleracionVariable parametros)
        {
            VelocidadInicial = KmhAMs(parametros.VelocidadInicialKmh);
            Aceleracion = parametros.AceleracionMaxima;
            TiempoTotal = parametros.TiempoTotal;
            VelocidadMaxima = parametros.VelocidadMaximaKmh;
            Masa = parametros.Masa;
            KResistencia = parametros.KResistencia;
            AceleracionMin = parametros.AceleracionMinima;
            esAceleracionConstante = false;
            parametrosVariableConfigurados = true;
            lblSimulacionCompletada.Visible = false;
        }

        private void LimpiarGraficas()
        {
            cursorTiempoVelocidad = -1;
            cursorTiempoAceleracion = -1;
            cursorTiempoTrabajo = -1;

            panelVelocidad.Invalidate();
            panelAceleracion.Invalidate();
            panelTrabajo.Invalidate();
        }


        public ParametrosAceleracionConstante ObtenerParametros()
        {
            return new ParametrosAceleracionConstante
            {
                VelocidadInicialKmh = MsAKmh(velocidadInicial),
                Aceleracion = aceleracion,
                TiempoTotal = tiempoTotal,
                VelocidadMaximaKmh = velocidadMaxima,
                Masa = masa,
                KResistencia = kResistencia
            };
        }

        public ParametrosAceleracionVariable ObtenerParametrosVar()
        {
            return new ParametrosAceleracionVariable
            {
                VelocidadInicialKmh = MsAKmh(velocidadInicial),
                AceleracionMaxima = aceleracion,
                AceleracionMinima = aceleracionMin,
                TiempoTotal = tiempoTotal,
                VelocidadMaximaKmh = velocidadMaxima,
                Masa = masa,
                KResistencia = kResistencia
            };
        }

        public ParametrosAceleracionVariable ObtenerParametrosVarFormulario()
        {
            if (parametrosVariableConfigurados)
            {
                return ObtenerParametrosVar();
            }

            return new ParametrosAceleracionVariable
            {
                VelocidadInicialKmh = 0.0,
                AceleracionMaxima = 4.0,
                AceleracionMinima = 2.0,
                TiempoTotal = 10.0,
                VelocidadMaximaKmh = 150.0,
                Masa = 250.0,
                KResistencia = 0.4
            };
        }

        public void cmbMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (restaurandoMovimiento || cmbMovimiento.SelectedIndex < 0)
            {
                return;
            }

            PlaySound("snd/Check.mp3");
            string tipoMovimiento = cmbMovimiento.SelectedItem?.ToString() ?? "";

            using (Form configuracion = tipoMovimiento == "Aceleración Variable"
                ? (Form)new FormAcVariable(this)
                : new FormParametrosAceleracionConstante(this))
            {
                if (configuracion.ShowDialog(this) == DialogResult.OK)
                {
                    indiceMovimientoConfirmado = cmbMovimiento.SelectedIndex;
                    return;
                }
            }

            RestaurarMovimientoConfirmado();
        }

        private void RestaurarMovimientoConfirmado()
        {
            restaurandoMovimiento = true;
            cmbMovimiento.SelectedIndex = indiceMovimientoConfirmado;
            restaurandoMovimiento = false;
        }

        private void FormSimuladorMovimiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            ForceStop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppManager.ShutdownApplication();
        }

        private void FormSimuladorMovimiento_Load(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();

            isAnimating = true;
            this.Opacity = 0;
            timer1.Start();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;

            PlaySound("snd/Salir.wav");

            if (simulacionActiva)
            {
                ForceStop();
                Task.Delay(500).ContinueWith(_ =>
                {
                    this.Invoke(new Action(() => IniciarFadeOut()));
                });
            }
            else
            {
                IniciarFadeOut();
            }
        }

        private void IniciarFadeOut()
        {
            timer1.Stop();
            timer2.Stop();
            isAnimating = true;
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0)
            {
                this.Opacity += 0.05;
            }
            else
            {
                timer1.Stop();
                isAnimating = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.05;
            }
            else
            {
                timer2.Stop();
                isAnimating = false;
                AppManager.CambiarFormulario(this, new FormMenuSimuladores());
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            PlaySound("snd/Cursor.wav");
        }

        private void cmbForma_Click(object sender, EventArgs e)
        {
            PlaySound("snd/Select.mp3");
        }

        private void cmbRazon_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlaySound("snd/Check.mp3");
        }

        public void PlaySound(string filePath)
        {
            ReproductorSonido.Reproducir(filePath);
        }

        private void FormSimuladorMovimiento_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisposeImages();
        }

        private void DisposeImages()
        {
            try
            {
                fondoImage?.Dispose();
                pistaImage?.Dispose();
                carroImage?.Dispose();
                fondoImage = null;
                pistaImage = null;
                carroImage = null;
                imagesLoaded = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al descargar imagenes: {ex.Message}");
            }
        }

        public void ForceStop()
        {
            try
            {
                timer1?.Stop();
                timer2?.Stop();
                timerSimulacion?.Stop();

                simulacionActiva = false;
                cmbMovimiento.Enabled = true;
                lblSimulacionCompletada.Visible = false;
            }
            catch
            {
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            ProcedimientoHelper.MostrarProcedimiento(
            this,
            esAceleracionConstante,
            velocidadInicial,
            aceleracion,
            masa,
            tiempoTotal,
            velocidadFinal,
            distanciaRecorrida,
            trabajoRealizado,
            aceleracionMin,
            KmhAMs(velocidadMaxima),
            kResistencia
        );
        }

        private void btnCopiarResultados_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(ConstruirResumenResultados());
            DialogoApp.MostrarInformacion(this, "Resultados copiados al portapapeles.", "Copiar resultados");
        }

        private void btnExportarResultados_Click(object sender, EventArgs e)
        {
            bool exportado = ExportadorResultados.ExportarTextoOCsv(
                this,
                $"movimiento_{DateTime.Now:yyyyMMdd_HHmmss}",
                ConstruirResumenResultados(),
                ConstruirCsvMovimiento());

            if (exportado)
            {
                DialogoApp.MostrarInformacion(this, "Resultados exportados correctamente.", "Exportar resultados");
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            MostrarHistorial();
        }

        private void MostrarHistorial()
        {
            if (!HistorialSimulaciones.TieneRegistros())
            {
                DialogoApp.MostrarInformacion(this, "Aún no hay simulaciones registradas.", "Historial");
                return;
            }

            using (FormHistorialSimulaciones historial = new FormHistorialSimulaciones(this))
            {
                historial.ShowDialog(this);
            }
        }

        private void RegistrarHistorial()
        {
            string tipo = esAceleracionConstante ? "Aceleración constante" : "Aceleración variable";
            string resultadoCorto = $"Distancia: {FormatoUnidades.Distancia(distanciaRecorrida)} | Velocidad final: {FormatoUnidades.VelocidadKmh(MsAKmh(velocidadFinal))} | Trabajo: {FormatoUnidades.TrabajoKj(trabajoRealizado)}";
            HistorialSimulaciones.Agregar("Integrales", tipo, resultadoCorto, ConstruirResumenResultados(), ConstruirParametrosHistorial());
        }

        private Dictionary<string, string> ConstruirParametrosHistorial()
        {
            return new Dictionary<string, string>
            {
                { "origen", "movimiento" },
                { "tipoMovimiento", esAceleracionConstante ? "constante" : "variable" },
                { "velocidadInicialKmh", GuardarNumero(MsAKmh(VelocidadInicial)) },
                { "aceleracionMaxima", GuardarNumero(Aceleracion) },
                { "aceleracionMinima", GuardarNumero(AceleracionMin) },
                { "tiempoTotal", GuardarNumero(TiempoTotal) },
                { "velocidadMaximaKmh", GuardarNumero(VelocidadMaxima) },
                { "masa", GuardarNumero(Masa) },
                { "kResistencia", GuardarNumero(KResistencia) }
            };
        }

        public bool ReabrirDesdeHistorial(RegistroSimulacion registro)
        {
            if (registro == null || !registro.TieneParametros)
            {
                return false;
            }

            if (!TryObtenerParametro(registro, "tipoMovimiento", out string tipoMovimiento)
                || !TryLeerParametro(registro, "velocidadInicialKmh", out double velocidadInicialKmh)
                || !TryLeerParametro(registro, "aceleracionMaxima", out double aceleracionMaxima)
                || !TryLeerParametro(registro, "tiempoTotal", out double tiempoTotalGuardado)
                || !TryLeerParametro(registro, "velocidadMaximaKmh", out double velocidadMaximaKmh)
                || !TryLeerParametro(registro, "masa", out double masaGuardada)
                || !TryLeerParametro(registro, "kResistencia", out double kGuardada))
            {
                return false;
            }

            ForceStop();

            if (string.Equals(tipoMovimiento, "variable", StringComparison.OrdinalIgnoreCase))
            {
                if (!TryLeerParametro(registro, "aceleracionMinima", out double aceleracionMinima))
                {
                    return false;
                }

                AplicarParametrosVar(new ParametrosAceleracionVariable
                {
                    VelocidadInicialKmh = velocidadInicialKmh,
                    AceleracionMaxima = aceleracionMaxima,
                    AceleracionMinima = aceleracionMinima,
                    TiempoTotal = tiempoTotalGuardado,
                    VelocidadMaximaKmh = velocidadMaximaKmh,
                    Masa = masaGuardada,
                    KResistencia = kGuardada
                });
                SeleccionarMovimientoDesdeHistorial(1);
            }
            else
            {
                AplicarParametros(new ParametrosAceleracionConstante
                {
                    VelocidadInicialKmh = velocidadInicialKmh,
                    Aceleracion = aceleracionMaxima,
                    TiempoTotal = tiempoTotalGuardado,
                    VelocidadMaximaKmh = velocidadMaximaKmh,
                    Masa = masaGuardada,
                    KResistencia = kGuardada
                });
                SeleccionarMovimientoDesdeHistorial(0);
            }

            PrepararReaperturaDesdeHistorial();
            DialogoApp.MostrarInformacion(this, "Simulacion reabierta. Puedes ajustar parametros o volver a simular.", "Historial");
            return true;
        }

        private void SeleccionarMovimientoDesdeHistorial(int indice)
        {
            if (cmbMovimiento.Items.Count <= indice)
            {
                return;
            }

            restaurandoMovimiento = true;
            cmbMovimiento.SelectedIndex = indice;
            indiceMovimientoConfirmado = indice;
            restaurandoMovimiento = false;
        }

        private void PrepararReaperturaDesdeHistorial()
        {
            TiempoActual = 0;
            pistaOffset = 0;
            fondoOffset = 0;
            aceleracionVisualActual = 0;
            distanciaRecorrida = 0;
            velocidadFinal = VelocidadInicial;
            trabajoRealizado = 0;
            simulacionActiva = false;
            isPaused = false;
            btnPausa.Enabled = false;
            btnPausa.Text = "Pausar";
            btnMostrarProcedimiento.Enabled = false;
            btnCopiarResultados.Visible = false;
            btnCopiarResultados.Enabled = false;
            btnExportarResultados.Visible = false;
            btnExportarResultados.Enabled = false;
            lblSimulacionCompletada.Visible = false;
            cmbMovimiento.Enabled = true;
            listaTiempos.Clear();
            listaVelocidades.Clear();
            listaAceleraciones.Clear();
            listaTrabajos.Clear();
            LimpiarGraficas();
            ActualizarResultados();
            DibujarAnimacion();
        }

        private bool TryObtenerParametro(RegistroSimulacion registro, string clave, out string valor)
        {
            valor = null;
            return registro.Parametros != null && registro.Parametros.TryGetValue(clave, out valor);
        }

        private bool TryLeerParametro(RegistroSimulacion registro, string clave, out double valor)
        {
            valor = 0;
            return TryObtenerParametro(registro, clave, out string texto)
                && double.TryParse(texto, NumberStyles.Float, CultureInfo.InvariantCulture, out valor);
        }

        private string GuardarNumero(double valor)
        {
            return valor.ToString("R", CultureInfo.InvariantCulture);
        }

        private string ConstruirResumenResultados()
        {
            string tipo = esAceleracionConstante ? "Aceleración constante" : "Aceleración variable";
            return
                "Simulador de movimiento" + Environment.NewLine +
                $"Tipo: {tipo}" + Environment.NewLine +
                $"Tiempo total: {FormatoUnidades.TiempoSegundos(TiempoTotal)}" + Environment.NewLine +
                $"Velocidad inicial: {FormatoUnidades.VelocidadKmh(MsAKmh(VelocidadInicial))}" + Environment.NewLine +
                $"Velocidad final: {FormatoUnidades.VelocidadKmh(MsAKmh(velocidadFinal))}" + Environment.NewLine +
                $"Velocidad máxima: {FormatoUnidades.VelocidadKmh(VelocidadMaxima)}" + Environment.NewLine +
                $"Aceleración máxima: {FormatoUnidades.Aceleracion(Aceleracion)}" + Environment.NewLine +
                (esAceleracionConstante ? "" : $"Aceleración mínima: {FormatoUnidades.Aceleracion(AceleracionMin)}" + Environment.NewLine) +
                $"Masa: {FormatoUnidades.MasaKg(Masa)}" + Environment.NewLine +
                $"Resistencia del aire: {FormatoUnidades.Numero(KResistencia, 4)}" + Environment.NewLine +
                $"Distancia recorrida: {FormatoUnidades.Distancia(distanciaRecorrida)}" + Environment.NewLine +
                $"Trabajo realizado: {FormatoUnidades.TrabajoKj(trabajoRealizado)}";
        }

        private string ConstruirCsvMovimiento()
        {
            StringBuilder csv = new StringBuilder();
            csv.AppendLine("tiempo_s,velocidad_kmh,aceleracion_ms2,trabajo_kj");

            int filas = new[] { listaTiempos.Count, listaVelocidades.Count, listaAceleraciones.Count, listaTrabajos.Count }.Min();
            for (int i = 0; i < filas; i++)
            {
                csv.AppendLine(string.Join(",",
                    FormatoUnidades.Numero(listaTiempos[i], 4),
                    FormatoUnidades.Numero(listaVelocidades[i], 4),
                    FormatoUnidades.Numero(listaAceleraciones[i], 4),
                    FormatoUnidades.Numero(listaTrabajos[i], 4)));
            }

            return csv.ToString();
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE)
            {
                AppManager.ShutdownApplication();
                return;
            }

            base.WndProc(ref m);
        }

        public static void EmergencyShutdown()
        {
            AppManager.ShutdownApplication();
        }
    }
}
