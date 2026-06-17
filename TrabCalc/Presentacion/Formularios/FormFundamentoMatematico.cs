using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;
using TrabCalc.Servicios.UI;

namespace TrabCalc
{
    public partial class FormFundamentoMatematico : Form
    {
        private enum SeccionFundamento
        {
            Derivadas,
            Integrales
        }

        private SeccionFundamento seccionActual = SeccionFundamento.Derivadas;
        private bool reconstruyendoContenido;

        public FormFundamentoMatematico()
        {
            InitializeComponent();
            TransparencyKey = Color.DarkBlue;
            KeyPreview = true;
            TemaApp.AplicarFormularioDialogo(this, pnlContenedor);
            panelContenido.Resize += panelContenido_Resize;
            MostrarSeccion(SeccionFundamento.Derivadas);
        }

        private void btnDerivadas_Click(object sender, EventArgs e)
        {
            MostrarSeccion(SeccionFundamento.Derivadas);
        }

        private void btnIntegrales_Click(object sender, EventArgs e)
        {
            MostrarSeccion(SeccionFundamento.Integrales);
        }

        private void panelContenido_Resize(object sender, EventArgs e)
        {
            if (!reconstruyendoContenido)
            {
                MostrarSeccion(seccionActual);
            }
        }

        private void MostrarSeccion(SeccionFundamento seccion)
        {
            seccionActual = seccion;
            ActualizarBotones();

            reconstruyendoContenido = true;
            panelContenido.SuspendLayout();
            LimpiarPanel();

            int y = 20;
            if (seccion == SeccionFundamento.Derivadas)
            {
                ConstruirDerivadas(ref y);
            }
            else
            {
                ConstruirIntegrales(ref y);
            }

            panelContenido.AutoScrollMinSize = new Size(0, y + 20);
            panelContenido.ResumeLayout();
            reconstruyendoContenido = false;
        }

        private void ConstruirDerivadas(ref int y)
        {
            AgregarEncabezado(
                ref y,
                "Derivadas: recipientes, caudal y nivel del agua",
                "Este simulador existe para responder preguntas de ritmo: cuanto tarda en llenarse o vaciarse un recipiente, y que tan rapido cambia el nivel del liquido mientras eso ocurre.",
                Color.FromArgb(219, 248, 239),
                Color.FromArgb(0, 96, 62));

            AgregarBloque(
                ref y,
                "Ejemplo real",
                "Imagina una fabrica que debe llenar tinacos, tanques o cisternas antes de pasar al siguiente paso de manufactura. Si el llenado tarda demasiado, la linea se vuelve lenta; si el drenado no se controla, puede haber esperas, desperdicio o riesgo de desbordamiento. CalcuMax convierte dimensiones y caudal en tiempo, volumen y velocidad de nivel para planear mejor el proceso.");

            AgregarBloque(
                ref y,
                "Que datos usa",
                "El usuario elige la figura del recipiente, sus dimensiones, el porcentaje inicial de llenado, la operacion (llenar o drenar) y el caudal en m^3/min. Con eso el programa sabe cuanto volumen tiene el recipiente, cuanto volumen falta cambiar y con que rapidez entra o sale el liquido.");

            AgregarSubtitulo(ref y, "1. Volumen total segun la figura");
            AgregarTexto(ref y, "Cada figura usa una formula distinta. La cisterna y el cilindro tienen area transversal constante; la esfera no, porque su ancho cambia con la altura.");
            AgregarFormula(ref y, @"V_{cilindro}=\pi r^2H");
            AgregarFormula(ref y, @"V_{esfera}=\frac{4}{3}\pi R^3");
            AgregarFormula(ref y, @"V_{cisterna}=LWH");

            AgregarSubtitulo(ref y, "2. Volumen que realmente debe cambiar");
            AgregarTexto(ref y, "No siempre se llena desde cero ni se drena desde lleno. Por eso se calcula el volumen inicial y el volumen final, y solo se trabaja con la diferencia.");
            AgregarFormula(ref y, @"\Delta V=|V_f-V_i|");

            AgregarSubtitulo(ref y, "3. Conversion de caudal y tiempo total");
            AgregarTexto(ref y, "El caudal se captura por minuto, pero la simulacion avanza por segundos. Primero se convierte a m^3/s y luego se divide el volumen cambiado entre ese caudal.");
            AgregarFormula(ref y, @"Q_s=\frac{Q_{min}}{60}");
            AgregarFormula(ref y, @"t=\frac{\Delta V}{Q_s}");

            AgregarSubtitulo(ref y, "4. Derivada del volumen y velocidad del nivel");
            AgregarTexto(ref y, "La derivada dV/dt dice que tan rapido cambia el volumen. Para llenado es positiva; para drenado es negativa. Para convertir ese cambio de volumen en cambio de altura se usa la regla de la cadena.");
            AgregarFormula(ref y, @"\frac{dV}{dt}=\pm Q_s");
            AgregarFormula(ref y, @"\frac{dh}{dt}=\frac{dV/dt}{dV/dh}");

            AgregarTexto(ref y, "La parte dV/dh es el area transversal en la altura actual. Si el area es grande, el mismo caudal sube poco el nivel; si el area es pequena, el nivel sube o baja mas rapido.");
            AgregarFormula(ref y, @"\frac{dV}{dh}=\pi r^2\quad(cilindro)");
            AgregarFormula(ref y, @"\frac{dV}{dh}=LW\quad(cisterna)");
            AgregarFormula(ref y, @"\frac{dV}{dh}=\pi(2Rh-h^2)\quad(esfera)");

            AgregarBloque(
                ref y,
                "Que representan los resultados",
                "Tiempo total indica cuanto tarda la operacion. Volumen cambiado indica cuanto liquido se movio. dV/dt es el caudal con signo. dh/dt indica que tan rapido sube o baja el nivel del agua. La animacion no inventa el resultado: solo muestra en pequenos pasos el mismo cambio de volumen calculado.");
        }

        private void ConstruirIntegrales(ref int y)
        {
            AgregarEncabezado(
                ref y,
                "Integrales: movimiento, distancia y trabajo",
                "Este simulador existe para responder preguntas de acumulacion: cuanta distancia se recorre y cuanta energia se gasta cuando la velocidad y la aceleracion cambian con el tiempo.",
                Color.FromArgb(224, 238, 255),
                Color.FromArgb(20, 70, 140));

            AgregarBloque(
                ref y,
                "Ejemplo real",
                "Imagina un carrito industrial, un vehiculo de reparto interno o una plataforma automatizada. Interesa saber que velocidad alcanza, que distancia recorre en cierto tiempo y cuanto trabajo debe realizar el motor. CalcuMax usa integrales porque esos resultados se acumulan durante todo el recorrido.");

            AgregarBloque(
                ref y,
                "Que datos usa",
                "El usuario define velocidad inicial, aceleracion, tiempo, velocidad maxima, masa y resistencia del aire. En aceleracion variable tambien se define un minimo y un maximo para que la aceleracion cambie durante la simulacion.");

            AgregarSubtitulo(ref y, "1. Velocidad final");
            AgregarTexto(ref y, "En aceleracion constante, la velocidad cambia de forma directa. Si existe una velocidad maxima, el simulador no permite que el vehiculo la supere.");
            AgregarFormula(ref y, @"v(t)=v_0+at");
            AgregarFormula(ref y, @"v_f=\min(v_0+at,\;v_{max})");

            AgregarSubtitulo(ref y, "2. Distancia como area bajo la velocidad");
            AgregarTexto(ref y, "La distancia no se calcula mirando solo la velocidad final. Se obtiene acumulando todas las velocidades que hubo durante el tiempo. Esa acumulacion es una integral.");
            AgregarFormula(ref y, @"d=\int_0^t v(\tau)\,d\tau");
            AgregarFormula(ref y, @"d=v_0t+\frac{1}{2}at^2\quad(aceleracion\ constante)");

            AgregarSubtitulo(ref y, "3. Aceleracion variable y aproximacion numerica");
            AgregarTexto(ref y, "Cuando la aceleracion cambia, el programa avanza por pequenos intervalos. En cada paso calcula aceleracion, velocidad, distancia y trabajo. Este metodo aproxima el area bajo la curva con trapecios.");
            AgregarFormula(ref y, @"a(t)=\frac{a_{max}+a_{min}}{2}+\frac{a_{max}-a_{min}}{2}\sin(t)");
            AgregarFormula(ref y, @"v_{n+1}=v_n+\frac{a(t_n)+a(t_{n+1})}{2}\Delta t");
            AgregarFormula(ref y, @"d_{n+1}=d_n+\frac{v_n+v_{n+1}}{2}\Delta t");

            AgregarSubtitulo(ref y, "4. Trabajo del motor");
            AgregarTexto(ref y, "El trabajo mide energia. El motor debe acelerar la masa y tambien vencer la resistencia del aire. Por eso la fuerza incluye una parte ma y otra proporcional a v^2.");
            AgregarFormula(ref y, @"F_{motor}=ma_{ef}+kv^2");
            AgregarFormula(ref y, @"P(t)=F_{motor}v(t)");
            AgregarFormula(ref y, @"W=\int_0^t P(\tau)\,d\tau");
            AgregarFormula(ref y, @"W\approx\sum\frac{P_i+P_{i+1}}{2}\Delta t");

            AgregarBloque(
                ref y,
                "Que representan los resultados",
                "Velocidad final muestra el estado al terminar. Distancia es todo lo recorrido, no solo un instante. Trabajo es la energia acumulada que tuvo que entregar el motor. Las graficas ayudan a ver de donde sale cada resultado: velocidad para distancia, aceleracion para cambio de velocidad y trabajo como energia acumulada.");
        }

        private void AgregarEncabezado(ref int y, string titulo, string texto, Color fondo, Color acento)
        {
            int ancho = AnchoContenido();
            Panel card = CrearPanel(18, y, ancho, 118, fondo);
            card.Controls.Add(CrearLabel(titulo, 16, FontStyle.Bold, acento, 18, 14, ancho - 36));
            Label descripcion = CrearLabel(texto, 10, FontStyle.Regular, TemaApp.TextoOscuro, 18, 54, ancho - 36);
            card.Controls.Add(descripcion);
            card.Height = Math.Max(104, descripcion.Bottom + 16);
            panelContenido.Controls.Add(card);
            y += card.Height + 14;
        }

        private void AgregarBloque(ref int y, string titulo, string texto)
        {
            int ancho = AnchoContenido();
            Panel card = CrearPanel(18, y, ancho, 110, Color.White);
            card.Controls.Add(CrearLabel(titulo, 12, FontStyle.Bold, TemaApp.BordePrincipal, 18, 14, ancho - 36));
            Label cuerpo = CrearLabel(texto, 10, FontStyle.Regular, TemaApp.TextoOscuro, 18, 44, ancho - 36);
            card.Controls.Add(cuerpo);
            card.Height = cuerpo.Bottom + 16;
            panelContenido.Controls.Add(card);
            y += card.Height + 12;
        }

        private void AgregarSubtitulo(ref int y, string texto)
        {
            Label label = CrearLabel(texto, 12, FontStyle.Bold, Color.FromArgb(0, 90, 40), 24, y + 8, AnchoContenido() - 12);
            panelContenido.Controls.Add(label);
            y += label.Height + 12;
        }

        private void AgregarTexto(ref int y, string texto)
        {
            Label label = CrearLabel(texto, 10, FontStyle.Regular, TemaApp.TextoOscuro, 30, y, AnchoContenido() - 24);
            panelContenido.Controls.Add(label);
            y += label.Height + 10;
        }

        private void AgregarFormula(ref int y, string latex)
        {
            Control formula = ProcedimientoVisual.CrearFormula(latex, Math.Max(520, AnchoContenido() - 24), 16);
            formula.Location = new Point(30, y);
            panelContenido.Controls.Add(formula);
            y += formula.Height + 12;
        }

        private Panel CrearPanel(int x, int y, int ancho, int alto, Color fondo)
        {
            return new Panel
            {
                Location = new Point(x, y),
                Size = new Size(ancho, alto),
                BackColor = fondo,
                BorderStyle = BorderStyle.FixedSingle
            };
        }

        private Label CrearLabel(string texto, int tamano, FontStyle estilo, Color color, int x, int y, int ancho)
        {
            Font fuente = new Font("Segoe UI", tamano, estilo);
            int alto = MedirAlto(texto, fuente, ancho) + 4;
            return new Label
            {
                Text = texto,
                Font = fuente,
                ForeColor = color,
                BackColor = Color.Transparent,
                Location = new Point(x, y),
                Size = new Size(ancho, alto)
            };
        }

        private int MedirAlto(string texto, Font fuente, int ancho)
        {
            return TextRenderer.MeasureText(
                texto,
                fuente,
                new Size(ancho, 0),
                TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl).Height;
        }

        private int AnchoContenido()
        {
            return Math.Max(620, panelContenido.ClientSize.Width - 40);
        }

        private void ActualizarBotones()
        {
            ConfigurarBotonSeccion(btnDerivadas, seccionActual == SeccionFundamento.Derivadas);
            ConfigurarBotonSeccion(btnIntegrales, seccionActual == SeccionFundamento.Integrales);
        }

        private void ConfigurarBotonSeccion(Guna2GradientButton boton, bool activo)
        {
            boton.FillColor = activo ? Color.White : Color.FromArgb(225, 234, 248);
            boton.FillColor2 = activo ? TemaApp.VerdeAccion : TemaApp.AzulAccion;
            boton.ForeColor = activo ? Color.White : TemaApp.TextoOscuro;
            boton.BorderColor = activo ? TemaApp.VerdeAccion : TemaApp.AzulAccion;
        }

        private void LimpiarPanel()
        {
            foreach (Control control in panelContenido.Controls)
            {
                control.Dispose();
            }

            panelContenido.Controls.Clear();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormFundamentoMatematico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                e.Handled = true;
            }
        }
    }
}
