using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TrabCalc.Negocios.Recipientes;
using TrabCalc.Servicios;
using TrabCalc.Servicios.Exportacion;

namespace TrabCalc
{
    public partial class FormProcedimientoDerivadas : Form
    {
        private readonly Figura3D figura;
        private readonly ParametrosRecipiente parametros;
        private readonly Panel panelContenido = new Panel();
        private readonly DocumentoProcedimiento documento = new DocumentoProcedimiento();
        private readonly Timer timerEntrada = new Timer();
        private readonly Timer timerSalida = new Timer();
        private bool isAnimating;

        public FormProcedimientoDerivadas(Figura3D figura, ParametrosRecipiente parametros)
        {
            this.figura = figura;
            this.parametros = parametros;

            InicializarFormulario();
            MostrarProcedimiento();
        }

        private void InicializarFormulario()
        {
            BackColor = Color.DarkBlue;
            ClientSize = new Size(884, 681);
            FormBorderStyle = FormBorderStyle.None;
            Opacity = 0;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Procedimiento - Tiempo de llenado y drenado";
            TransparencyKey = Color.DarkBlue;

            Guna2CustomGradientPanel fondo = new Guna2CustomGradientPanel
            {
                BorderColor = Color.MidnightBlue,
                BorderRadius = 40,
                BorderThickness = 3,
                Dock = DockStyle.Fill,
                FillColor2 = Color.CornflowerBlue,
                FillColor3 = Color.DarkCyan,
                FillColor4 = Color.DarkSlateGray
            };

            panelContenido.AutoScroll = true;
            panelContenido.BackColor = Color.White;
            panelContenido.BorderStyle = BorderStyle.FixedSingle;
            panelContenido.Location = new Point(21, 25);
            panelContenido.Size = new Size(851, 587);

            Guna2GradientButton btnSalir = new Guna2GradientButton
            {
                AutoRoundedCorners = true,
                BackColor = Color.Transparent,
                BorderColor = Color.Firebrick,
                BorderRadius = 23,
                BorderThickness = 3,
                FillColor = Color.LightGray,
                FillColor2 = Color.LightCoral,
                Font = new Font("Arial", 18F),
                ForeColor = Color.Black,
                Location = new Point(10, 617),
                Size = new Size(150, 49),
                Text = "Volver"
            };
            btnSalir.Click += btnSalir_Click;

            Guna2GradientButton btnCopiar = new Guna2GradientButton
            {
                AutoRoundedCorners = true,
                BackColor = Color.Transparent,
                BorderColor = Color.RoyalBlue,
                BorderRadius = 23,
                BorderThickness = 3,
                FillColor = Color.LightGray,
                FillColor2 = Color.DodgerBlue,
                Font = new Font("Arial", 18F),
                ForeColor = Color.Black,
                Location = new Point(170, 617),
                Size = new Size(150, 49),
                Text = "Copiar"
            };
            btnCopiar.Click += btnCopiar_Click;

            Guna2GradientButton btnPdf = new Guna2GradientButton
            {
                AutoRoundedCorners = true,
                BackColor = Color.Transparent,
                BorderColor = Color.SeaGreen,
                BorderRadius = 23,
                BorderThickness = 3,
                FillColor = Color.LightGray,
                FillColor2 = Color.MediumSeaGreen,
                Font = new Font("Arial", 18F),
                ForeColor = Color.Black,
                Location = new Point(330, 617),
                Size = new Size(150, 49),
                Text = "PDF"
            };
            btnPdf.Click += btnPdf_Click;

            fondo.Controls.Add(btnSalir);
            fondo.Controls.Add(btnCopiar);
            fondo.Controls.Add(btnPdf);
            fondo.Controls.Add(panelContenido);
            Controls.Add(fondo);

            timerEntrada.Interval = 20;
            timerEntrada.Tick += timerEntrada_Tick;
            timerSalida.Interval = 20;
            timerSalida.Tick += timerSalida_Tick;

            Load += FormProcedimientoDerivadas_Load;
        }

        private void MostrarProcedimiento()
        {
            panelContenido.Controls.Clear();
            documento.Limpiar();
            int y = 20;
            double caudalSegundo = parametros.CaudalPorSegundo;

            AgregarTitulo($"PROCEDIMIENTO: {parametros.NombreOperacion.ToUpper()}", ref y);

            AgregarSubtitulo("1. Datos del recipiente", ref y);
            AgregarTexto("Primero calculamos el volumen total del recipiente, porque ese valor define el rango posible de llenado o drenado.", ref y);
            AgregarTexto($"Figura: {parametros.NombreFigura}", ref y);
            AgregarFormula(ObtenerFormulaGeneralVolumen(), ref y);
            AgregarFormula(ObtenerFormulaSustituidaVolumen(), ref y);
            AgregarFormula($@"V={F(figura.VolumenTotal, 4)}\;m^3", ref y);
            y += 12;

            AgregarSubtitulo("2. Volumen que cambia", ref y);
            AgregarTexto("Para saber cuanto tiempo tarda, solo necesitamos el volumen que realmente cambia entre el estado inicial y el final.", ref y);
            AgregarTexto($"Volumen inicial: {FormatoUnidades.Volumen(parametros.VolumenInicial, 4)}", ref y);
            AgregarTexto($"Volumen final: {FormatoUnidades.Volumen(parametros.VolumenFinal, 4)}", ref y);
            AgregarFormula(@"\Delta V=|V_f-V_i|", ref y);
            AgregarFormula($@"\Delta V=|{F(parametros.VolumenFinal, 4)}-{F(parametros.VolumenInicial, 4)}|", ref y);
            AgregarFormula($@"\Delta V={F(parametros.VolumenCambiado, 4)}\;m^3", ref y);
            y += 12;

            AgregarSubtitulo("3. Conversión del caudal", ref y);
            AgregarTexto("El caudal se captura en metros cúbicos por minuto, pero la simulación avanza en segundos; por eso dividimos entre 60.", ref y);
            AgregarTexto($"Caudal ingresado: {FormatoUnidades.CaudalMinuto(parametros.CaudalPorMinuto)}", ref y);
            AgregarFormula(@"Q_s=\frac{Q_{min}}{60}", ref y);
            AgregarFormula($@"Q_s=\frac{{{F(parametros.CaudalPorMinuto, 4)}}}{{60}}", ref y);
            AgregarFormula($@"Q_s={F(caudalSegundo, 6)}\;m^3/s", ref y);
            y += 12;

            AgregarSubtitulo("4. Tiempo requerido", ref y);
            AgregarTexto("Como el caudal es constante, el volumen cambia de forma lineal; por eso el tiempo sale de dividir el volumen cambiado entre el caudal por segundo.", ref y);
            AgregarFormula(@"t=\frac{\Delta V}{Q_s}", ref y);
            AgregarFormula($@"t=\frac{{{F(parametros.VolumenCambiado, 4)}}}{{{F(caudalSegundo, 6)}}}", ref y);
            AgregarFormula($@"t={F(parametros.TiempoTotal)}\;s", ref y);
            AgregarFormula($@"t=\frac{{{F(parametros.TiempoTotal)}}}{{60}}={F(parametros.TiempoTotal / 60.0)}\;min", ref y);
            y += 12;

            AgregarSubtitulo("5. Derivada del volumen y del nivel", ref y);
            AgregarTexto("La derivada central del simulador es el caudal: mide que tan rapido cambia el volumen con respecto al tiempo.", ref y);
            AgregarFormula(parametros.Operacion == CalculadoraRecipientes.OperacionDrenado
                ? @"\frac{dV}{dt}=-Q_s"
                : @"\frac{dV}{dt}=Q_s", ref y);
            AgregarFormula($@"\frac{{dV}}{{dt}}={(parametros.Operacion == CalculadoraRecipientes.OperacionDrenado ? "-" : "")}{F(caudalSegundo, 6)}\;m^3/s", ref y);
            AgregarTexto("Para convertir ese cambio de volumen en velocidad vertical del agua usamos la regla de la cadena.", ref y);
            AgregarFormula(@"\frac{dh}{dt}=\frac{dV/dt}{dV/dh}", ref y);
            AgregarFormula(ObtenerFormulaDerivadaNivel(), ref y);
            AgregarFormula(ObtenerFormulaSustituidaDerivadaNivel(caudalSegundo), ref y);
            string velocidadNivel = ObtenerVelocidadNivelReferencia(caudalSegundo);
            if (!string.IsNullOrEmpty(velocidadNivel))
            {
                AgregarFormula(velocidadNivel, ref y);
            }
            else
            {
                AgregarTexto("En esta altura el area transversal es cero; por eso dh/dt no tiene un valor finito y se reporta como indefinida.", ref y);
            }
            y += 12;

            AgregarResumen(new Dictionary<string, string>
            {
                { "Operación", parametros.NombreOperacion },
                { "Volumen cambiado", FormatoUnidades.Volumen(parametros.VolumenCambiado, 4) },
                { "Caudal por segundo", FormatoUnidades.CaudalSegundo(caudalSegundo) },
                { "Tiempo", FormatoUnidades.TiempoSegundos(parametros.TiempoTotal) },
                { "Equivalente", FormatoUnidades.TiempoMinutos(parametros.TiempoTotal / 60.0) }
            }, ref y);
        }

        private string ObtenerNombreFigura()
        {
            if (figura is Cilindro) return "Cilindro";
            if (figura is Esfera) return "Esfera";
            if (figura is Cisterna) return "Cisterna rectangular";
            return "Recipiente";
        }

        private string ObtenerFormulaGeneralVolumen()
        {
            if (figura is Cilindro) return @"V=\pi r^2h";
            if (figura is Esfera) return @"V=\frac{4}{3}\pi r^3";
            if (figura is Cisterna) return @"V=L\cdot A\cdot H";
            return @"V";
        }

        private string ObtenerFormulaSustituidaVolumen()
        {
            if (figura is Cilindro cilindro)
            {
                return $@"V=\pi({F(cilindro.Radio, 4)})^2({F(cilindro.Altura, 4)})";
            }

            if (figura is Esfera esfera)
            {
                return $@"V=\frac{{4}}{{3}}\pi({F(esfera.Radio, 4)})^3";
            }

            if (figura is Cisterna cisterna)
            {
                return $@"V={F(cisterna.Largo, 4)}\cdot {F(cisterna.Ancho, 4)}\cdot {F(cisterna.Altura, 4)}";
            }

            return $@"V={F(figura.VolumenTotal, 4)}";
        }

        private string ObtenerFormulaDerivadaNivel()
        {
            if (figura is Cilindro) return @"\frac{dV}{dh}=\pi r^2,\quad \frac{dh}{dt}=\frac{Q_s}{\pi r^2}";
            if (figura is Cisterna) return @"\frac{dV}{dh}=L\cdot A,\quad \frac{dh}{dt}=\frac{Q_s}{L\cdot A}";
            if (figura is Esfera) return @"\frac{dV}{dh}=\pi(2Rh-h^2),\quad \frac{dh}{dt}=\frac{Q_s}{\pi(2Rh-h^2)}";
            return @"\frac{dh}{dt}=\frac{Q_s}{dV/dh}";
        }

        private string ObtenerFormulaSustituidaDerivadaNivel(double caudalSegundo)
        {
            double signo = parametros.Operacion == CalculadoraRecipientes.OperacionDrenado ? -1.0 : 1.0;
            double caudalConSigno = signo * caudalSegundo;

            if (figura is Cilindro cilindro)
            {
                double area = Math.PI * cilindro.Radio * cilindro.Radio;
                return $@"\frac{{dV}}{{dh}}=\pi({F(cilindro.Radio, 4)})^2={F(area, 6)},\quad \frac{{dh}}{{dt}}=\frac{{{F(caudalConSigno, 6)}}}{{{F(area, 6)}}}";
            }

            if (figura is Cisterna cisterna)
            {
                double area = cisterna.Largo * cisterna.Ancho;
                return $@"\frac{{dV}}{{dh}}={F(cisterna.Largo, 4)}\cdot {F(cisterna.Ancho, 4)}={F(area, 6)},\quad \frac{{dh}}{{dt}}=\frac{{{F(caudalConSigno, 6)}}}{{{F(area, 6)}}}";
            }

            if (figura is Esfera esfera)
            {
                double h = figura.AlturaLiquido;
                double area = figura.AreaTransversalActual;
                return $@"\frac{{dV}}{{dh}}=\pi(2({F(esfera.Radio, 4)})({F(h, 4)})-{F(h, 4)}^2)={F(area, 6)},\quad \frac{{dh}}{{dt}}=\frac{{{F(caudalConSigno, 6)}}}{{{F(area, 6)}}}";
            }

            return $@"\frac{{dh}}{{dt}}=\frac{{{F(caudalConSigno, 6)}}}{{dV/dh}}";
        }

        private string ObtenerVelocidadNivelReferencia(double caudalSegundo)
        {
            double signo = parametros.Operacion == CalculadoraRecipientes.OperacionDrenado ? -1.0 : 1.0;

            if (figura is Cilindro cilindro)
            {
                double area = Math.PI * cilindro.Radio * cilindro.Radio;
                return $@"\frac{{dh}}{{dt}}=\frac{{{F(signo * caudalSegundo, 6)}}}{{{F(area, 4)}}}={F(signo * caudalSegundo / area, 6)}\;m/s";
            }

            if (figura is Cisterna cisterna)
            {
                double area = cisterna.Largo * cisterna.Ancho;
                return $@"\frac{{dh}}{{dt}}=\frac{{{F(signo * caudalSegundo, 6)}}}{{{F(area, 4)}}}={F(signo * caudalSegundo / area, 6)}\;m/s";
            }

            if (figura is Esfera)
            {
                double area = figura.AreaTransversalActual;
                if (area <= 0.0000001)
                {
                    return "";
                }

                return $@"\frac{{dh}}{{dt}}=\frac{{{F(signo * caudalSegundo, 6)}}}{{{F(area, 6)}}}={F(signo * caudalSegundo / area, 6)}\;m/s";
            }

            return "";
        }

        private string F(double valor, int decimales = 2)
        {
            return ProcedimientoVisual.F(valor, decimales);
        }

        private void AgregarTitulo(string texto, ref int y)
        {
            documento.AgregarTitulo(texto);
            Label label = CrearLabel(texto, new Font("Arial", 15, FontStyle.Bold), Color.MidnightBlue, new Point(20, y), new Size(800, 30));
            label.TextAlign = ContentAlignment.MiddleCenter;
            panelContenido.Controls.Add(label);
            y += label.Height + 10;
        }

        private void AgregarSubtitulo(string texto, ref int y)
        {
            documento.AgregarSubtitulo(texto);
            Label label = CrearLabel(texto, new Font("Arial", 13, FontStyle.Bold), Color.DarkGreen, new Point(20, y), new Size(800, 25));
            panelContenido.Controls.Add(label);
            y += label.Height + 5;
        }

        private void AgregarTexto(string texto, ref int y)
        {
            documento.AgregarTexto(texto);
            Label label = CrearLabel(texto, new Font("Arial", 12), Color.Black, new Point(30, y), new Size(790, 0));
            label.AutoSize = true;
            label.MaximumSize = new Size(790, 0);
            panelContenido.Controls.Add(label);
            y += label.Height + 8;
        }

        private void AgregarFormula(string latex, ref int y)
        {
            documento.AgregarFormula(latex);
            Control formula = ProcedimientoVisual.CrearFormula(latex);
            formula.Location = new Point(50, y);
            panelContenido.Controls.Add(formula);
            y += formula.Height + 10;
        }

        private void AgregarResumen(Dictionary<string, string> filas, ref int y)
        {
            AgregarSubtitulo("Resumen final", ref y);

            int ancho = 750;
            int altoFila = 30;
            Panel resumen = new Panel
            {
                Location = new Point(50, y),
                Size = new Size(ancho, 42 + filas.Count * altoFila),
                BackColor = Color.FromArgb(235, 245, 255),
                BorderStyle = BorderStyle.FixedSingle
            };

            resumen.Controls.Add(CrearLabel("Parámetro", new Font("Arial", 11, FontStyle.Bold), Color.MidnightBlue, new Point(15, 10), new Size(350, 22)));
            resumen.Controls.Add(CrearLabel("Valor", new Font("Arial", 11, FontStyle.Bold), Color.MidnightBlue, new Point(400, 10), new Size(300, 22)));

            int filaY = 38;
            foreach (var fila in filas)
            {
                documento.AgregarTexto($"{fila.Key}: {fila.Value}");
                resumen.Controls.Add(CrearLabel(fila.Key, new Font("Arial", 11), Color.Black, new Point(15, filaY), new Size(350, 22)));
                resumen.Controls.Add(CrearLabel(fila.Value, new Font("Arial", 11, FontStyle.Bold), Color.Black, new Point(400, filaY), new Size(300, 22)));
                filaY += altoFila;
            }

            panelContenido.Controls.Add(resumen);
            y += resumen.Height + 20;
        }

        private Label CrearLabel(string texto, Font fuente, Color color, Point ubicacion, Size tamano)
        {
            return new Label
            {
                Text = texto,
                Font = fuente,
                ForeColor = color,
                Location = ubicacion,
                Size = tamano,
                BackColor = Color.Transparent
            };
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;
            ReproductorSonido.Reproducir("snd/Salir.wav");
            IniciarFadeOut();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(documento.ATextoPlano());
            DialogoApp.MostrarInformacion(this, "Procedimiento copiado al portapapeles.", "Copiar procedimiento");
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            bool exportado = ExportadorProcedimiento.ExportarPdf(
                this,
                documento,
                $"procedimiento_derivadas_{DateTime.Now:yyyyMMdd_HHmmss}");

            if (exportado)
            {
                DialogoApp.MostrarInformacion(this, "Procedimiento exportado a PDF correctamente.", "Exportar procedimiento");
            }
        }

        private void IniciarFadeOut()
        {
            timerEntrada.Stop();
            timerSalida.Stop();
            isAnimating = true;
            timerSalida.Start();
        }

        private void timerEntrada_Tick(object sender, EventArgs e)
        {
            if (Opacity < 1.0)
            {
                Opacity += 0.04;
            }
            else
            {
                timerEntrada.Stop();
                isAnimating = false;
            }
        }

        private void timerSalida_Tick(object sender, EventArgs e)
        {
            if (Opacity > 0)
            {
                Opacity -= 0.07;
            }
            else
            {
                timerSalida.Stop();
                isAnimating = false;
                Close();
            }
        }

        private void FormProcedimientoDerivadas_Load(object sender, EventArgs e)
        {
            isAnimating = true;
            Opacity = 0;
            timerEntrada.Start();
        }
    }
}
