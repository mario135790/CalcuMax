using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using TrabCalc.Negocios.Recipientes;
using TrabCalc.Servicios;
using TrabCalc.Servicios.Exportacion;
using TrabCalc.Servicios.Historial;
using TrabCalc.Servicios.UI;

namespace TrabCalc
{
    public partial class FormSimuladorRecipientes : Form
    {
        public enum ModoVista
        {
            Frontal,
            Lateral,
            Isometrica
        }

        private readonly Timer timerSimulacion = new Timer();
        private readonly Stopwatch relojSimulacion = new Stopwatch();
        private readonly ToolTip ayuda = new ToolTip();
        private bool isAnimating;
        private bool simulacionActiva;
        private bool figDibujada;
        private bool isPaused;
        private bool isDragging;
        private int operacionActual;
        private double tiempo;
        private double tiempoTranscurrido;
        private double caudalPorSegundo;
        private double caudalPorMinuto;
        private double velocidadActual = 1.0;
        private ParametrosRecipiente parametrosRecipienteProcedimiento;
        private float zoomFactor = 1.0f;
        private Point panOffset = new Point(0, 0);
        private Point lastMousePos;
        private Figura3D figura;
        private ModoVista modoVistaActual = ModoVista.Frontal;

        public FormSimuladorRecipientes()
        {
            InitializeComponent();
            AppManager.RegisterForm(this);
            this.TransparencyKey = Color.DarkBlue;
            this.Opacity = 0;
            KeyPreview = true;
            KeyDown += FormSimuladorRecipientes_KeyDown;

            ConfigurarControlesInteractivos();
            ConfigurarTooltips();
            ConfigurarEventosPanel();
            ConfigurarLayoutResponsivo();
            ConfigurarValidacionEnVivo();

            timerSimulacion.Interval = 33;
            timerSimulacion.Tick += TimerSimulacion_Tick;

            timer1.Start();
            PlaySound("snd/Form.wav");
        }

        private void ConfigurarControlesInteractivos()
        {
            trackBarVelocidad.Minimum = 1;
            trackBarVelocidad.Maximum = 1000;
            trackBarVelocidad.Value = 10;
            labelVelocidad.Text = $"Velocidad: {FormatoUnidades.VelocidadSimulacion(1.0)}";

            cmbModoVista.Items.Clear();
            cmbModoVista.Items.AddRange(new string[] { "3D", "2D" });
            cmbModoVista.SelectedIndex = 0;
            trackBarZoom.Minimum = 5;
            trackBarZoom.Maximum = 30;
            trackBarZoom.Value = 10;
            labelZoom.Text = "Zoom: 100%";

            btnPausa.Enabled = false;
            btnPausa.Text = "Pausar";
            button1.Text = "Simular";
            btnMostrarProcedimiento.Visible = false;
            btnMostrarProcedimiento.Enabled = false;
            lblSimulacionCompletada.Visible = false;
        }

        private void ConfigurarLayoutResponsivo()
        {
            TemaApp.AplicarFormularioPrincipal(this, pb2, new Size(860, 650));
            pb2.Resize += (s, e) => ReacomodarLayoutRecipientes();
            guna2CustomGradientPanel1.Resize += (s, e) => ReacomodarPanelRecipiente();
            ReacomodarLayoutRecipientes();
        }

        private void ReacomodarLayoutRecipientes()
        {
            if (pb2.ClientSize.Width <= 0 || pb2.ClientSize.Height <= 0)
            {
                return;
            }

            int margen = 18;
            int panelIzquierdo = 345;
            int separacion = 16;
            int xVista = panelIzquierdo + separacion;
            int anchoVista = Math.Max(360, pb2.ClientSize.Width - xVista - margen);
            int altoVista = Math.Max(360, pb2.ClientSize.Height - margen * 2);

            guna2CustomGradientPanel1.Location = new Point(xVista, margen);
            guna2CustomGradientPanel1.Size = new Size(anchoVista, altoVista);

            btnSalir.Location = new Point(24, pb2.ClientSize.Height - btnSalir.Height - 14);
            btnSalir.Size = new Size(96, btnSalir.Height);
            btnExportarResultados.Location = new Point(128, btnSalir.Top);
            btnExportarResultados.Size = new Size(112, btnExportarResultados.Height);
            btnCopiarResultados.Location = new Point(248, btnSalir.Top);
            btnCopiarResultados.Size = new Size(86, btnCopiarResultados.Height);
            btnMostrarProcedimiento.Location = new Point(24, Math.Max(576, btnSalir.Top - btnMostrarProcedimiento.Height - 8));
            btnMostrarProcedimiento.Size = new Size(panelIzquierdo - 42, btnMostrarProcedimiento.Height);

            ReacomodarPanelRecipiente();
        }

        private void ReacomodarPanelRecipiente()
        {
            int margen = 16;
            panel1.Location = new Point(margen, margen);
            panel1.Size = new Size(
                Math.Max(120, guna2CustomGradientPanel1.ClientSize.Width - margen * 2),
                Math.Max(120, guna2CustomGradientPanel1.ClientSize.Height - margen * 2));
            figura?.dibujarFigura();
        }

        private void ConfigurarValidacionEnVivo()
        {
            txtRazon.TextChanged += (s, e) =>
            {
                ActualizarEstadoCaudal();
                OcultarResultadosCompletados();
            };
            cmbQueHace.SelectedIndexChanged += (s, e) =>
            {
                ActualizarEstadoCaudal();
                OcultarResultadosCompletados();
            };
            ActualizarEstadoCaudal();
        }

        private bool CaudalActualEsValido()
        {
            return EntradaNumerica.TryLeerDouble(txtRazon.Text, out double razon) && razon > 0;
        }

        private void ActualizarEstadoCaudal()
        {
            if (string.IsNullOrWhiteSpace(txtRazon.Text))
            {
                txtRazon.BorderColor = TemaApp.BordePrincipal;
            }
            else
            {
                txtRazon.BorderColor = CaudalActualEsValido() ? TemaApp.VerdeAccion : TemaApp.RojoAccion;
            }

            if (!simulacionActiva)
            {
                button1.Enabled = figDibujada && cmbQueHace.SelectedIndex >= 0 && CaudalActualEsValido();
            }
        }

        private void ConfigurarTooltips()
        {
            ayuda.SetToolTip(cmbQueHace, "Elige si el recipiente se llena o se drena.");
            ayuda.SetToolTip(txtRazon, "Caudal en m³/min. Se convierte internamente a m³/s.");
            ayuda.SetToolTip(trackBarVelocidad, "Velocidad visual de la simulación.");
            ayuda.SetToolTip(trackBarZoom, "Zoom de la vista del recipiente.");
            ayuda.SetToolTip(cmbModoVista, "Cambia entre vista 3D y 2D.");
            ayuda.SetToolTip(btnMostrarProcedimiento, "Abre el procedimiento paso a paso.");
            ayuda.SetToolTip(btnCopiarResultados, "Copia el resumen de resultados al portapapeles.");
            ayuda.SetToolTip(btnExportarResultados, "Exporta el resumen o una tabla CSV.");
            ayuda.SetToolTip(btnHistorial, "Abre el historial de simulaciones.");
        }

        private void ConfigurarEventosPanel()
        {
            ActivarDobleBuffer(panel1);
            panel1.Paint += Panel1_Paint;
            panel1.MouseDown += Panel1_MouseDown;
            panel1.MouseMove += Panel1_MouseMove;
            panel1.MouseUp += Panel1_MouseUp;
            panel1.MouseWheel += Panel1_MouseWheel;
        }

        private void FormSimuladorRecipientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                button1.PerformClick();
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.Space && btnPausa.Enabled && !ControlConEntradaActivo())
            {
                btnPausa.PerformClick();
                e.Handled = true;
                return;
            }

            if (e.Control && e.KeyCode == Keys.R)
            {
                btnResetView_Click(sender, EventArgs.Empty);
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
            return ActiveControl is TextBoxBase || ActiveControl is Guna2TextBox || ActiveControl is ComboBox;
        }

        private void ActivarDobleBuffer(Control control)
        {
            PropertyInfo propiedad = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            propiedad?.SetValue(control, true, null);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            figura?.Dibujar(e.Graphics);
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastMousePos = e.Location;
                panel1.Cursor = Cursors.SizeAll;
            }
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging) return;

            panOffset.X += e.X - lastMousePos.X;
            panOffset.Y += e.Y - lastMousePos.Y;
            lastMousePos = e.Location;
            figura?.dibujarFigura();
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
                panel1.Cursor = Cursors.Default;
            }
        }

        private void Panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                zoomFactor = Math.Min(zoomFactor + 0.1f, 3.0f);
                if (trackBarZoom.Value < trackBarZoom.Maximum)
                    trackBarZoom.Value++;
            }
            else
            {
                zoomFactor = Math.Max(zoomFactor - 0.1f, 0.5f);
                if (trackBarZoom.Value > trackBarZoom.Minimum)
                    trackBarZoom.Value--;
            }

            labelZoom.Text = $"Zoom: {(int)(zoomFactor * 100)}%";
            figura?.dibujarFigura();
        }

        private void trackBarVelocidad_Scroll(object sender, ScrollEventArgs e)
        {
            velocidadActual = trackBarVelocidad.Value / 10.0;
            labelVelocidad.Text = $"Velocidad: {FormatoUnidades.VelocidadSimulacion(velocidadActual)}";
        }

        private void trackBarZoom_Scroll(object sender, ScrollEventArgs e)
        {
            zoomFactor = trackBarZoom.Value / 10.0f;
            labelZoom.Text = $"Zoom: {(int)(zoomFactor * 100)}%";
            figura?.dibujarFigura();
        }

        private void cmbModoVista_SelectedIndexChanged(object sender, EventArgs e)
        {
            modoVistaActual = (ModoVista)cmbModoVista.SelectedIndex;
            PlaySound("snd/Check.mp3");
            figura?.dibujarFigura();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Guna2TextBox textBox = (Guna2TextBox)sender;

            e.Handled = true;
            if ((e.KeyChar == 'v' || e.KeyChar == 'V') && (Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                return;
            }

            if (e.KeyChar == '.' && !textBox.Text.Contains(".") && textBox.Text.Any(char.IsDigit))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '\b' || char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void btnPausa_Click(object sender, EventArgs e)
        {
            if (!simulacionActiva) return;

            isPaused = !isPaused;
            btnPausa.Text = isPaused ? "Reanudar" : "Pausar";
            figura.AnimacionLiquidoActiva = !isPaused;
            relojSimulacion.Restart();
        }

        private void btnResetView_Click(object sender, EventArgs e)
        {
            zoomFactor = 1.0f;
            panOffset = new Point(0, 0);
            trackBarZoom.Value = 10;
            labelZoom.Text = "Zoom: 100%";
            trackBarVelocidad.Value = 10;
            velocidadActual = 1.0;
            labelVelocidad.Text = $"Velocidad: {FormatoUnidades.VelocidadSimulacion(1.0)}";
            figura?.dibujarFigura();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (simulacionActiva)
            {
                DetenerSimulacion(false);
                return;
            }

            if (!figDibujada || figura == null)
            {
                PlaySound("snd/Error.mp3");
                DialogoApp.MostrarAdvertencia(
                    this,
                    "Primero seleccione un recipiente." + Environment.NewLine + Environment.NewLine +
                    "El simulador necesita conocer la forma y sus dimensiones para calcular volumen, area transversal y altura del agua.",
                    "Dato requerido");
                return;
            }

            if (cmbQueHace.SelectedIndex == -1)
            {
                PlaySound("snd/Error.mp3");
                DialogoApp.MostrarAdvertencia(
                    this,
                    "Seleccione si el recipiente se llena o se vacia." + Environment.NewLine + Environment.NewLine +
                    "Esta opcion decide el signo del cambio: llenar aumenta el volumen y drenar lo disminuye.",
                    "Dato requerido");
                return;
            }

            if (!EntradaNumerica.TryLeerDouble(txtRazon.Text, out double razon) || razon <= 0)
            {
                PlaySound("snd/Error.mp3");
                DialogoApp.MostrarAdvertencia(
                    this,
                    "El caudal debe ser mayor que cero." + Environment.NewLine + Environment.NewLine +
                    "El caudal indica cuantos metros cubicos cambian por minuto. Con 0 o menos no hay cambio real de volumen.",
                    "Valor a revisar");
                return;
            }

            operacionActual = cmbQueHace.SelectedIndex;
            caudalPorMinuto = razon;
            caudalPorSegundo = CalculadoraRecipientes.CalcularCaudalPorSegundo(caudalPorMinuto);
            CalcularTiempo();

            if (tiempo <= 0)
            {
                PlaySound("snd/Error.mp3");
                DialogoApp.MostrarAdvertencia(
                    this,
                    "No hay volumen disponible para simular con la operacion seleccionada." + Environment.NewLine + Environment.NewLine +
                    "Por ejemplo, no se puede llenar un recipiente que ya esta al 100%, ni drenar uno que esta vacio.",
                    "Operacion sin recorrido");
                return;
            }

            if (!MostrarAdvertenciasInteligentesRecipiente(razon))
            {
                return;
            }

            PlaySound("snd/Boton.wav");
            IniciarSimulacion();
        }

        private bool MostrarAdvertenciasInteligentesRecipiente(double caudalMinuto)
        {
            string aviso = "";

            if (tiempo > 0 && tiempo < 1)
            {
                aviso += "La simulación durará menos de 1 segundo. Baja el caudal o la velocidad visual para verla mejor.";
            }

            double volumenCambiado = operacionActual == CalculadoraRecipientes.OperacionDrenado ? figura.VolumenActual : figura.VolumenRestante;
            if (caudalMinuto > 0 && volumenCambiado / caudalMinuto < 0.1)
            {
                if (aviso.Length > 0) aviso += Environment.NewLine;
                aviso += "El caudal es muy alto para el volumen disponible; la animación será muy breve.";
            }

            if (aviso.Length > 0)
            {
                return DialogoAdvertenciaSimulacion.Mostrar(this, aviso);
            }

            return true;
        }

        private void IniciarSimulacion()
        {
            tiempoTranscurrido = 0;
            simulacionActiva = true;
            isPaused = false;
            parametrosRecipienteProcedimiento = CrearParametrosRecipiente();
            figura.AnimacionLiquidoActiva = true;
            figura.Drenando = operacionActual == CalculadoraRecipientes.OperacionDrenado;

            button1.Text = "Detener";
            btnPausa.Enabled = true;
            btnPausa.Text = "Pausar";
            btnMostrarProcedimiento.Visible = false;
            btnMostrarProcedimiento.Enabled = false;
            btnExportarResultados.Visible = false;
            btnExportarResultados.Enabled = false;
            btnCopiarResultados.Visible = false;
            btnCopiarResultados.Enabled = false;
            lblSimulacionCompletada.Visible = false;
            ConfigurarEntradasSimulacion(false);
            lblTiempoTotal.Text = FormatoUnidades.TiempoDuracion(tiempo);
            label12.Text = FormatoUnidades.TiempoDuracion(tiempo);

            relojSimulacion.Restart();
            timerSimulacion.Start();
        }

        private void TimerSimulacion_Tick(object sender, EventArgs e)
        {
            double intervaloReal = relojSimulacion.IsRunning
                ? relojSimulacion.Elapsed.TotalSeconds
                : timerSimulacion.Interval / 1000.0;
            relojSimulacion.Restart();

            if (!simulacionActiva || isPaused || figura == null)
            {
                return;
            }

            intervaloReal = Math.Max(0.001, Math.Min(1.0, intervaloReal));
            double tiempoRestante = tiempo - tiempoTranscurrido;
            ResultadoPasoRecipiente paso = CalculadoraRecipientes.CalcularPaso(
                figura.VolumenActual,
                figura.VolumenTotal,
                caudalPorSegundo,
                tiempoRestante,
                intervaloReal,
                velocidadActual,
                operacionActual);

            if (paso.DeltaTiempo <= 0)
            {
                DetenerSimulacion(true);
                return;
            }

            figura.VolumenActual = paso.VolumenActual;
            figura.VolumenRestante = paso.VolumenRestante;
            tiempoTranscurrido += paso.DeltaTiempo;
            figura.AvanzarAnimacionLiquido(paso.DeltaTiempo);

            ActualizarDatos();
            label12.Text = FormatoUnidades.TiempoDuracion(Math.Max(0, tiempo - tiempoTranscurrido));
            figura.dibujarFigura();

            if (tiempoTranscurrido >= tiempo || paso.Completado)
            {
                DetenerSimulacion(true);
            }
        }

        private void DetenerSimulacion(bool completar)
        {
            timerSimulacion.Stop();
            relojSimulacion.Stop();

            if (completar && figura != null)
            {
                figura.VolumenActual = CalculadoraRecipientes.ObtenerVolumenFinal(figura.VolumenTotal, operacionActual);
                figura.VolumenRestante = figura.VolumenTotal - figura.VolumenActual;
                figura.AnimacionLiquidoActiva = false;
                ActualizarDatos();
                label12.Text = "00:00:00";
                figura.dibujarFigura();
            }

            simulacionActiva = false;
            isPaused = false;
            if (figura != null)
            {
                figura.AnimacionLiquidoActiva = false;
            }
            button1.Text = "Simular";
            btnPausa.Enabled = false;
            btnPausa.Text = "Pausar";
            btnMostrarProcedimiento.Visible = completar && figura != null;
            btnMostrarProcedimiento.Enabled = completar && figura != null;
            btnExportarResultados.Visible = completar && figura != null;
            btnExportarResultados.Enabled = completar && figura != null;
            btnCopiarResultados.Visible = completar && figura != null;
            btnCopiarResultados.Enabled = completar && figura != null;
            lblSimulacionCompletada.Visible = completar && figura != null;
            ConfigurarEntradasSimulacion(true);

            if (completar && figura != null)
            {
                RegistrarHistorial();
            }

            ActualizarEstadoCaudal();
        }

        private void RegistrarHistorial()
        {
            string tipo = $"{parametrosRecipienteProcedimiento.NombreFigura} - {parametrosRecipienteProcedimiento.NombreOperacion}";
            string resultadoCorto = $"Tiempo: {FormatoUnidades.TiempoSegundos(parametrosRecipienteProcedimiento.TiempoTotal)} | Volumen final: {FormatoUnidades.Volumen(parametrosRecipienteProcedimiento.VolumenFinal, 4)}";
            HistorialSimulaciones.Agregar("Derivadas", tipo, resultadoCorto, ConstruirResumenResultados(), ConstruirParametrosHistorial());
        }

        private Dictionary<string, string> ConstruirParametrosHistorial()
        {
            Dictionary<string, string> parametros = new Dictionary<string, string>
            {
                { "origen", "recipiente" },
                { "operacion", operacionActual.ToString(CultureInfo.InvariantCulture) },
                { "caudalPorMinuto", GuardarNumero(caudalPorMinuto) },
                { "volumenInicial", GuardarNumero(parametrosRecipienteProcedimiento?.VolumenInicial ?? figura?.VolumenActual ?? 0) }
            };

            if (figura is Cilindro cilindro)
            {
                parametros["figuraTipo"] = "cilindro";
                parametros["radio"] = GuardarNumero(cilindro.Radio);
                parametros["altura"] = GuardarNumero(cilindro.Altura);
            }
            else if (figura is Esfera esfera)
            {
                parametros["figuraTipo"] = "esfera";
                parametros["radio"] = GuardarNumero(esfera.Radio);
            }
            else if (figura is Cisterna cisterna)
            {
                parametros["figuraTipo"] = "cisterna";
                parametros["largo"] = GuardarNumero(cisterna.Largo);
                parametros["ancho"] = GuardarNumero(cisterna.Ancho);
                parametros["altura"] = GuardarNumero(cisterna.Altura);
            }

            return parametros;
        }

        public bool ReabrirDesdeHistorial(RegistroSimulacion registro)
        {
            if (registro == null || !registro.TieneParametros)
            {
                return false;
            }

            if (!TryCrearFiguraDesdeHistorial(registro, out Figura3D figuraRecuperada)
                || !TryLeerEnteroParametro(registro, "operacion", out int operacionGuardada)
                || !TryLeerParametro(registro, "caudalPorMinuto", out double caudalGuardado)
                || !TryLeerParametro(registro, "volumenInicial", out double volumenInicialGuardado))
            {
                return false;
            }

            ForceStop();
            figura = figuraRecuperada;
            figura.VolumenActual = volumenInicialGuardado;
            figura.AnimacionLiquidoActiva = false;
            figura.Drenando = operacionGuardada == CalculadoraRecipientes.OperacionDrenado;
            figDibujada = true;
            operacionActual = operacionGuardada;
            caudalPorMinuto = caudalGuardado;
            caudalPorSegundo = CalculadoraRecipientes.CalcularCaudalPorSegundo(caudalPorMinuto);
            txtRazon.Text = FormatoUnidades.Numero(caudalPorMinuto, 6);

            if (cmbQueHace.Items.Count > operacionGuardada && operacionGuardada >= 0)
            {
                cmbQueHace.SelectedIndex = operacionGuardada;
            }

            CalcularTiempo();
            parametrosRecipienteProcedimiento = CrearParametrosRecipiente();
            tiempoTranscurrido = 0;
            isPaused = false;
            simulacionActiva = false;
            relojSimulacion.Reset();
            label12.Text = "00:00:00";
            button1.Text = "Simular";
            btnPausa.Enabled = false;
            btnPausa.Text = "Pausar";
            btnMostrarProcedimiento.Visible = false;
            btnMostrarProcedimiento.Enabled = false;
            btnExportarResultados.Visible = false;
            btnExportarResultados.Enabled = false;
            btnCopiarResultados.Visible = false;
            btnCopiarResultados.Enabled = false;
            lblSimulacionCompletada.Visible = false;
            ConfigurarEntradasSimulacion(true);
            ActualizarDatos();
            ActualizarEstadoCaudal();
            figura.dibujarFigura();
            DialogoApp.MostrarInformacion(this, "Simulacion reabierta. Puedes ajustar el caudal o volver a simular.", "Historial");
            return true;
        }

        private bool TryCrearFiguraDesdeHistorial(RegistroSimulacion registro, out Figura3D figuraRecuperada)
        {
            figuraRecuperada = null;
            if (!TryObtenerParametro(registro, "figuraTipo", out string figuraTipo))
            {
                return false;
            }

            if (string.Equals(figuraTipo, "cilindro", StringComparison.OrdinalIgnoreCase))
            {
                if (!TryLeerParametro(registro, "radio", out double radio)
                    || !TryLeerParametro(registro, "altura", out double altura))
                {
                    return false;
                }

                figuraRecuperada = new Cilindro(radio, altura, panel1);
                return true;
            }

            if (string.Equals(figuraTipo, "esfera", StringComparison.OrdinalIgnoreCase))
            {
                if (!TryLeerParametro(registro, "radio", out double radio))
                {
                    return false;
                }

                figuraRecuperada = new Esfera(radio, panel1);
                return true;
            }

            if (string.Equals(figuraTipo, "cisterna", StringComparison.OrdinalIgnoreCase))
            {
                if (!TryLeerParametro(registro, "largo", out double largo)
                    || !TryLeerParametro(registro, "ancho", out double ancho)
                    || !TryLeerParametro(registro, "altura", out double altura))
                {
                    return false;
                }

                figuraRecuperada = new Cisterna(largo, ancho, altura, panel1);
                return true;
            }

            return false;
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

        private bool TryLeerEnteroParametro(RegistroSimulacion registro, string clave, out int valor)
        {
            valor = 0;
            return TryObtenerParametro(registro, clave, out string texto)
                && int.TryParse(texto, NumberStyles.Integer, CultureInfo.InvariantCulture, out valor);
        }

        private string GuardarNumero(double valor)
        {
            return valor.ToString("R", CultureInfo.InvariantCulture);
        }

        private void ConfigurarEntradasSimulacion(bool habilitar)
        {
            cmbQueHace.Enabled = habilitar;
            txtRazon.Enabled = habilitar;
            guna2GradientButton3.Enabled = habilitar;
        }

        public float GetZoomFactor()
        {
            return zoomFactor;
        }

        public Point GetPanOffset()
        {
            return panOffset;
        }

        public ModoVista GetModoVista()
        {
            return modoVistaActual;
        }

        private void cmbForma_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PlaySound("snd/Check.mp3");
                using (FormSeleccionRecipiente f2 = new FormSeleccionRecipiente(panel1))
                {
                    if (f2.ShowDialog(this) == DialogResult.OK && f2.Figura != null)
                    {
                        figura = f2.Figura;
                        ActualizarDatos();
                        figura.dibujarFigura();
                        figDibujada = true;
                        ActualizarEstadoCaudal();
                        btnMostrarProcedimiento.Visible = false;
                        btnMostrarProcedimiento.Enabled = false;
                        btnExportarResultados.Visible = false;
                        btnExportarResultados.Enabled = false;
                        btnCopiarResultados.Visible = false;
                        btnCopiarResultados.Enabled = false;
                        lblSimulacionCompletada.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                DialogoApp.MostrarError(this, "Error al abrir FormSeleccionRecipiente: " + ex.Message);
            }
        }

        private void FormSeleccionRecipiente_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void ActualizarDatos()
        {
            if (figura == null) return;

            lblOcupado.Text = FormatoUnidades.Volumen(figura.VolumenActual);
            lblRestante.Text = FormatoUnidades.Volumen(figura.VolumenRestante);
            lblAlturaLiquido.Text = figura.AlturaTotal > 0
                ? FormatoUnidades.Distancia(figura.AlturaLiquido)
                : "--";

            lblVelocidadNivel.Text = ObtenerTextoVelocidadNivel();
        }

        private string ObtenerTextoVelocidadNivel()
        {
            if (figura == null || caudalPorSegundo <= 0 || cmbQueHace.SelectedIndex < 0)
            {
                return "--";
            }

            double area = figura.AreaTransversalActual;
            if (area <= 0.0000001)
            {
                return "indefinida";
            }

            double signo = cmbQueHace.SelectedIndex == CalculadoraRecipientes.OperacionDrenado ? -1.0 : 1.0;
            return FormatoUnidades.VelocidadMs(signo * caudalPorSegundo / area, 5);
        }

        private void CalcularTiempo()
        {
            tiempo = CalculadoraRecipientes.CalcularTiempo(figura.VolumenActual, figura.VolumenRestante, caudalPorSegundo, operacionActual);
        }

        private ParametrosRecipiente CrearParametrosRecipiente()
        {
            return new ParametrosRecipiente
            {
                NombreFigura = ObtenerNombreFigura(),
                Operacion = operacionActual,
                CaudalPorMinuto = caudalPorMinuto,
                VolumenTotal = figura.VolumenTotal,
                VolumenInicial = figura.VolumenActual,
                VolumenFinal = CalculadoraRecipientes.ObtenerVolumenFinal(figura.VolumenTotal, operacionActual),
                TiempoTotal = tiempo
            };
        }

        private void FormSimuladorRecipientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            ForceStop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppManager.ShutdownApplication();
        }

        private void FormSimuladorRecipientes_Load(object sender, EventArgs e)
        {
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;

            PlaySound("snd/Salir.wav");
            ForceStop();
            IniciarFadeOut();
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

        private void lblOcupado_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
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
            OcultarResultadosCompletados();
        }

        private void OcultarResultadosCompletados()
        {
            if (simulacionActiva)
            {
                return;
            }

            btnMostrarProcedimiento.Visible = false;
            btnMostrarProcedimiento.Enabled = false;
            btnExportarResultados.Visible = false;
            btnExportarResultados.Enabled = false;
            btnCopiarResultados.Visible = false;
            btnCopiarResultados.Enabled = false;
            lblSimulacionCompletada.Visible = false;
        }

        private void btnMostrarProcedimiento_Click(object sender, EventArgs e)
        {
            if (figura == null || parametrosRecipienteProcedimiento == null || !btnMostrarProcedimiento.Enabled)
            {
                return;
            }

            using (FormProcedimientoDerivadas procedimiento = new FormProcedimientoDerivadas(
                figura,
                parametrosRecipienteProcedimiento))
            {
                procedimiento.ShowDialog(this);
            }
        }

        private void btnCopiarResultados_Click(object sender, EventArgs e)
        {
            if (figura == null)
            {
                return;
            }

            Clipboard.SetText(ConstruirResumenResultados());
            DialogoApp.MostrarInformacion(this, "Resultados copiados al portapapeles.", "Copiar resultados");
        }

        private void btnExportarResultados_Click(object sender, EventArgs e)
        {
            if (figura == null)
            {
                return;
            }

            bool exportado = ExportadorResultados.ExportarTextoOCsv(
                this,
                $"recipiente_{DateTime.Now:yyyyMMdd_HHmmss}",
                ConstruirResumenResultados(),
                ConstruirCsvRecipiente());

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

        private string ConstruirResumenResultados()
        {
            if (parametrosRecipienteProcedimiento == null && figura != null)
            {
                parametrosRecipienteProcedimiento = CrearParametrosRecipiente();
            }

            return
                "Simulador de llenado/drenado" + Environment.NewLine +
                $"Figura: {parametrosRecipienteProcedimiento.NombreFigura}" + Environment.NewLine +
                $"Operación: {parametrosRecipienteProcedimiento.NombreOperacion}" + Environment.NewLine +
                $"Volumen total: {FormatoUnidades.Volumen(parametrosRecipienteProcedimiento.VolumenTotal, 4)}" + Environment.NewLine +
                $"Volumen inicial: {FormatoUnidades.Volumen(parametrosRecipienteProcedimiento.VolumenInicial, 4)}" + Environment.NewLine +
                $"Volumen final: {FormatoUnidades.Volumen(parametrosRecipienteProcedimiento.VolumenFinal, 4)}" + Environment.NewLine +
                $"Volumen cambiado: {FormatoUnidades.Volumen(parametrosRecipienteProcedimiento.VolumenCambiado, 4)}" + Environment.NewLine +
                $"Caudal: {FormatoUnidades.CaudalMinuto(parametrosRecipienteProcedimiento.CaudalPorMinuto)}" + Environment.NewLine +
                (figura != null ? $"Altura actual: {FormatoUnidades.Distancia(figura.AlturaLiquido, 4)}" + Environment.NewLine : "") +
                (figura != null ? $"Velocidad del nivel (dh/dt): {ObtenerTextoVelocidadNivel()}" + Environment.NewLine : "") +
                $"Tiempo: {FormatoUnidades.TiempoSegundos(parametrosRecipienteProcedimiento.TiempoTotal)} ({FormatoUnidades.TiempoMinutos(parametrosRecipienteProcedimiento.TiempoTotal / 60.0)})";
        }

        private string ConstruirCsvRecipiente()
        {
            if (parametrosRecipienteProcedimiento == null && figura != null)
            {
                parametrosRecipienteProcedimiento = CrearParametrosRecipiente();
            }

            StringBuilder csv = new StringBuilder();
            csv.AppendLine("tiempo_s,volumen_m3,volumen_restante_m3,altura_m,area_m2,dh_dt_ms");

            if (parametrosRecipienteProcedimiento == null || figura == null)
            {
                return csv.ToString();
            }

            double volumenOriginal = figura.VolumenActual;
            double restanteOriginal = figura.VolumenRestante;
            int muestras = Math.Max(2, Math.Min(121, (int)Math.Ceiling(parametrosRecipienteProcedimiento.TiempoTotal) + 1));
            double signo = parametrosRecipienteProcedimiento.Operacion == CalculadoraRecipientes.OperacionDrenado ? -1.0 : 1.0;

            try
            {
                for (int i = 0; i < muestras; i++)
                {
                    double proporcion = muestras == 1 ? 0 : (double)i / (muestras - 1);
                    double tiempoMuestra = parametrosRecipienteProcedimiento.TiempoTotal * proporcion;
                    double volumenMuestra = parametrosRecipienteProcedimiento.VolumenInicial + signo * parametrosRecipienteProcedimiento.CaudalPorSegundo * tiempoMuestra;
                    volumenMuestra = Math.Max(0, Math.Min(parametrosRecipienteProcedimiento.VolumenTotal, volumenMuestra));

                    figura.VolumenActual = volumenMuestra;
                    figura.VolumenRestante = Math.Max(0, parametrosRecipienteProcedimiento.VolumenTotal - volumenMuestra);

                    double area = figura.AreaTransversalActual;
                    double velocidadNivel = area > 0.0000001
                        ? signo * parametrosRecipienteProcedimiento.CaudalPorSegundo / area
                        : 0;

                    csv.AppendLine(string.Join(",",
                        FormatoUnidades.Numero(tiempoMuestra, 4),
                        FormatoUnidades.Numero(figura.VolumenActual, 6),
                        FormatoUnidades.Numero(figura.VolumenRestante, 6),
                        FormatoUnidades.Numero(figura.AlturaLiquido, 6),
                        FormatoUnidades.Numero(area, 6),
                        FormatoUnidades.Numero(velocidadNivel, 8)));
                }
            }
            finally
            {
                figura.VolumenActual = volumenOriginal;
                figura.VolumenRestante = restanteOriginal;
            }

            return csv.ToString();
        }

        private string ObtenerNombreFigura()
        {
            if (figura is Cilindro) return "Cilindro";
            if (figura is Esfera) return "Esfera";
            if (figura is Cisterna) return "Cisterna rectangular";
            return "Recipiente";
        }

        public void PlaySound(string filePath)
        {
            ReproductorSonido.Reproducir(filePath);
        }

        public void ForceStop()
        {
            timerSimulacion.Stop();
            relojSimulacion.Stop();
            timer1?.Stop();
            timer2?.Stop();
            simulacionActiva = false;
            isPaused = false;
            if (figura != null)
            {
                figura.AnimacionLiquidoActiva = false;
            }
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
    }
}
