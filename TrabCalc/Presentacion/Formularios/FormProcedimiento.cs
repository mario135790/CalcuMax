using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrabCalc
{
    public partial class FormProcedimiento : Form
    {
        private Panel panelContenido;
        private bool esAceleracionConstante;
        private Dictionary<string, double> parametros;
        private bool isAnimating;

        public void PlaySound(string filePath)
        {
            ReproductorSonido.Reproducir(filePath);
        }

        public FormProcedimiento(bool aceleracionConstante, Dictionary<string, double> parametrosCalculos)
        {
            InitializeComponent();
            esAceleracionConstante = aceleracionConstante;
            parametros = parametrosCalculos;
            MostrarProcedimiento();
            TransparencyKey = Color.DarkBlue;
        }

        private void MostrarProcedimiento()
        {
            panelContenido.Controls.Clear();
            int yPosition = 20;

            if (esAceleracionConstante)
            {
                MostrarProcedimientoConstante(ref yPosition);
            }
            else
            {
                MostrarProcedimientoVariable(ref yPosition);
            }
        }

        private void MostrarProcedimientoConstante(ref int yPosition)
        {
            AgregarTitulo("PROCEDIMIENTO DETALLADO: ACELERACIÓN CONSTANTE", ref yPosition);

            double v0 = parametros["velocidadInicial"];
            double a = parametros["aceleracion"];
            double t = parametros["tiempo"];
            double m = parametros["masa"];
            double k = parametros["kResistencia"];
            double vf = parametros["velocidadFinal"];
            double d = parametros["distancia"];
            double w = parametros["trabajo"];
            double vmax = parametros.ContainsKey("velocidadMaxima") ? parametros["velocidadMaxima"] : 0;
            bool hayLimite = vmax > 0;
            bool iniciaEnLimite = hayLimite && v0 >= vmax;
            double tiempoHastaLimite = hayLimite && a > 0 && v0 < vmax ? (vmax - v0) / a : double.PositiveInfinity;
            bool alcanzaLimite = hayLimite && (iniciaEnLimite || tiempoHastaLimite <= t);

            AgregarSubtitulo("Datos iniciales", ref yPosition);
            AgregarTexto($"Velocidad inicial (v0): {F(v0)} m/s", ref yPosition);
            AgregarTexto($"Aceleración (a): {F(a)} m/s²", ref yPosition);
            AgregarTexto($"Tiempo total (t): {F(t)} s", ref yPosition);
            AgregarTexto($"Masa (m): {F(m)} kg", ref yPosition);
            AgregarTexto($"Coeficiente de resistencia (k): {F(k, 4)} N·s²/m²", ref yPosition);
            if (hayLimite)
            {
                AgregarTexto($"Velocidad máxima permitida (vmax): {F(vmax)} m/s", ref yPosition);
            }
            yPosition += 12;

            AgregarSubtitulo("1. Cálculo de la velocidad final", ref yPosition);
            AgregarTexto("Como la aceleración es constante, revisamos primero si el vehículo alcanza la velocidad máxima antes de terminar la simulación.", ref yPosition);

            if (alcanzaLimite)
            {
                if (iniciaEnLimite)
                {
                    AgregarTexto("La velocidad inicial ya está en el límite, por eso la velocidad queda fija en vmax.", ref yPosition);
                    AgregarFormula(@"v_f = v_{max}", ref yPosition);
                }
                else
                {
                    AgregarFormula(@"t_{max} = \frac{v_{max} - v_0}{a}", ref yPosition);
                    AgregarFormula($@"t_{{max}} = \frac{{{F(vmax)} - {F(v0)}}}{{{F(a)}}}", ref yPosition);
                    AgregarFormula($@"t_{{max}} = {F(tiempoHastaLimite)}\;s", ref yPosition);
                    AgregarTexto("Como tmax es menor o igual que el tiempo total, la velocidad final queda limitada por vmax.", ref yPosition);
                    AgregarFormula(@"v_f = v_{max}", ref yPosition);
                }
            }
            else if (Math.Abs(a) < 0.000001)
            {
                AgregarTexto("Como la aceleración es cero, no hay cambio de velocidad durante el intervalo.", ref yPosition);
                AgregarFormula(@"v_f = v_0", ref yPosition);
            }
            else
            {
                AgregarTexto("Como no se alcanza el límite de velocidad, usamos la ecuación básica de velocidad en MRUA.", ref yPosition);
                AgregarFormula(@"v_f = v_0 + at", ref yPosition);
                AgregarFormula($@"v_f = {F(v0)} + {F(a)}({F(t)})", ref yPosition);
                AgregarFormula($@"v_f = {F(v0 + a * t)}\;m/s", ref yPosition);
            }

            AgregarTexto("Resultado:", ref yPosition);
            AgregarFormula($@"v_f = {F(vf)}\;m/s", ref yPosition);
            yPosition += 12;

            AgregarSubtitulo("2. Cálculo de la distancia recorrida", ref yPosition);
            if (alcanzaLimite)
            {
                double tiempoAcelerando = iniciaEnLimite ? 0 : Math.Min(tiempoHastaLimite, t);
                double tiempoConstante = Math.Max(0, t - tiempoAcelerando);
                double distanciaAcelerando = v0 * tiempoAcelerando + 0.5 * a * tiempoAcelerando * tiempoAcelerando;
                double distanciaConstante = vmax * tiempoConstante;

                AgregarTexto("Como la velocidad se limita, la distancia se calcula en dos partes: primero acelerando y después con velocidad constante.", ref yPosition);
                AgregarFormula(@"d_1 = v_0t_{max} + \frac{1}{2}at_{max}^2", ref yPosition);
                AgregarFormula($@"d_1 = {F(v0)}({F(tiempoAcelerando)}) + \frac{{1}}{{2}}({F(a)})({F(tiempoAcelerando)})^2", ref yPosition);
                AgregarFormula($@"d_1 = {F(distanciaAcelerando)}\;m", ref yPosition);
                AgregarFormula(@"d_2 = v_{max}(t - t_{max})", ref yPosition);
                AgregarFormula($@"d_2 = {F(vmax)}({F(t)} - {F(tiempoAcelerando)})", ref yPosition);
                AgregarFormula($@"d_2 = {F(distanciaConstante)}\;m", ref yPosition);
                AgregarFormula($@"d = d_1 + d_2 = {F(distanciaAcelerando)} + {F(distanciaConstante)}", ref yPosition);
            }
            else
            {
                AgregarTexto("Como la aceleración se mantiene igual todo el tiempo, usamos la ecuación de posición para MRUA.", ref yPosition);
                AgregarFormula(@"d = v_0t + \frac{1}{2}at^2", ref yPosition);
                AgregarFormula($@"d = {F(v0)}({F(t)}) + \frac{{1}}{{2}}({F(a)})({F(t)})^2", ref yPosition);
            }

            AgregarFormula($@"d = {F(d)}\;m", ref yPosition);
            yPosition += 12;

            AgregarSubtitulo("3. Cálculo del trabajo realizado por el motor", ref yPosition);
            AgregarTexto("El trabajo se obtiene sumando la energía necesaria para acelerar y vencer la resistencia del aire durante el recorrido.", ref yPosition);
            double deltaTrabajo = t > 0 ? Math.Min(0.05, t) : 0.05;
            double vPasoInicio = v0;
            double vPasoFin = v0 + a * deltaTrabajo;
            if (hayLimite)
            {
                vPasoFin = Math.Min(vPasoFin, vmax);
            }
            double potenciaInicio = (m * a + k * vPasoInicio * vPasoInicio) * vPasoInicio;
            double potenciaFin = (m * a + k * vPasoFin * vPasoFin) * vPasoFin;
            double trabajoPrimerPaso = ((potenciaInicio + potenciaFin) / 2.0) * deltaTrabajo;

            AgregarFormula(@"F_{motor} = ma_{ef} + kv^2", ref yPosition);
            AgregarTexto("La primera parte, maef, es la fuerza para acelerar la masa. La segunda, kv2, representa la resistencia del aire y crece con la velocidad.", ref yPosition);

            if (alcanzaLimite)
            {
                AgregarTexto("Cuando el vehículo llega a vmax, la aceleración efectiva baja a cero y el motor solo compensa la resistencia.", ref yPosition);
                AgregarFormula(@"W \approx \sum F_{motor}\Delta d", ref yPosition);
                AgregarFormula(@"W = W_{acelerando} + W_{constante}", ref yPosition);
                AgregarFormula($@"F_{{res}}=kv_{{max}}^2={F(k, 4)}({F(vmax)})^2", ref yPosition);
            }
            else if (Math.Abs(a) < 0.000001)
            {
                AgregarTexto("Sin aceleración, la fuerza del motor es la fuerza necesaria para compensar la resistencia.", ref yPosition);
                AgregarFormula(@"W = (kv_0^2)d", ref yPosition);
                AgregarFormula($@"W=({F(k, 4)}({F(v0)})^2)({F(d)})", ref yPosition);
            }
            else
            {
                AgregarTexto("Mientras la velocidad cambia, se integra la potencia del motor en pequeños pasos de tiempo.", ref yPosition);
                AgregarFormula(@"W \approx \sum \frac{P_i + P_{i+1}}{2}\Delta t", ref yPosition);
                AgregarTexto("La potencia es fuerza por velocidad. Como la velocidad cambia, primero se sustituye v(t) y despues se suma paso por paso.", ref yPosition);
                AgregarFormula(@"v(t)=v_0+at", ref yPosition);
                AgregarFormula($@"v(t)={F(v0)}+{F(a)}\cdot t", ref yPosition);
                AgregarFormula(@"P(t) = (ma + kv(t)^2)v(t)", ref yPosition);
                AgregarFormula($@"P(t)=({F(m)}({F(a)})+{F(k, 4)}({F(v0)}+{F(a)}\cdot t)^2)({F(v0)}+{F(a)}\cdot t)", ref yPosition);
                AgregarTexto("Ejemplo del primer paso numerico de la suma:", ref yPosition);
                AgregarFormula($@"v_0={F(vPasoInicio, 4)},\quad v_1={F(vPasoFin, 4)},\quad \Delta t={F(deltaTrabajo, 4)}", ref yPosition);
                AgregarFormula($@"P_0={F(potenciaInicio, 4)},\quad P_1={F(potenciaFin, 4)}", ref yPosition);
                AgregarFormula($@"\Delta W_1=\frac{{{F(potenciaInicio, 4)}+{F(potenciaFin, 4)}}}{{2}}({F(deltaTrabajo, 4)})={F(trabajoPrimerPaso, 4)}\;J", ref yPosition);
                AgregarTexto("El simulador repite esa misma suma desde el primer instante hasta el tiempo total.", ref yPosition);
            }

            AgregarFormula($@"W = {F(w * 1000.0)}\;J", ref yPosition);
            AgregarFormula($@"W = \frac{{{F(w * 1000.0)}}}{{1000}} = {F(w)}\;kJ", ref yPosition);
            yPosition += 12;

            AgregarResumen(new Dictionary<string, string>
            {
                { "Velocidad final", $"{F(vf)} m/s" },
                { "Distancia", $"{F(d)} m" },
                { "Trabajo", $"{F(w)} kJ" },
                { "Tiempo total", $"{F(t)} s" }
            }, ref yPosition);
        }

        private void MostrarProcedimientoVariable(ref int yPosition)
        {
            AgregarTitulo("PROCEDIMIENTO DETALLADO: ACELERACIÓN VARIABLE", ref yPosition);

            double v0 = parametros["velocidadInicial"];
            double aMax = parametros["aceleracion"];
            double aMin = parametros["aceleracionMin"];
            double tTotal = parametros["tiempo"];
            double m = parametros["masa"];
            double k = parametros["kResistencia"];
            double vf = parametros["velocidadFinal"];
            double d = parametros["distancia"];
            double w = parametros["trabajo"];
            double vmax = parametros.ContainsKey("velocidadMaxima") ? parametros["velocidadMaxima"] : 0;
            double deltaT = 0.05;
            double pasoEjemplo = Math.Min(deltaT, Math.Max(tTotal, 0));
            double aceleracionMediaFormula = (aMax + aMin) / 2.0;
            double amplitudFormula = (aMax - aMin) / 2.0;
            double a0 = CalcularAceleracionVariable(0, aMax, aMin);
            double a1 = CalcularAceleracionVariable(pasoEjemplo, aMax, aMin);
            double v1 = v0 + ((a0 + a1) / 2.0) * pasoEjemplo;
            if (vmax > 0)
            {
                v1 = Math.Min(v1, vmax);
            }
            double distanciaPrimerPaso = ((v0 + v1) / 2.0) * pasoEjemplo;
            double aceleracionEfectiva = pasoEjemplo > 0 ? (v1 - v0) / pasoEjemplo : 0;
            double velocidadMedia = (v0 + v1) / 2.0;
            double fuerzaMotor = m * aceleracionEfectiva + k * velocidadMedia * velocidadMedia;
            double trabajoPrimerPaso = fuerzaMotor * distanciaPrimerPaso / 1000.0;

            AgregarSubtitulo("Datos iniciales", ref yPosition);
            AgregarTexto($"Velocidad inicial (v0): {F(v0)} m/s", ref yPosition);
            AgregarTexto($"Aceleración máxima (amax): {F(aMax)} m/s²", ref yPosition);
            AgregarTexto($"Aceleración mínima (amin): {F(aMin)} m/s²", ref yPosition);
            AgregarTexto($"Tiempo total (t): {F(tTotal)} s", ref yPosition);
            AgregarTexto($"Masa (m): {F(m)} kg", ref yPosition);
            AgregarTexto($"Coeficiente de resistencia (k): {F(k, 4)} N·s²/m²", ref yPosition);
            if (vmax > 0)
            {
                AgregarTexto($"Velocidad máxima permitida (vmax): {F(vmax)} m/s", ref yPosition);
            }
            AgregarTexto($"Paso de integración (dt): {F(deltaT)} s", ref yPosition);
            yPosition += 12;

            AgregarSubtitulo("1. Definición de la aceleración", ref yPosition);
            AgregarTexto("Como la aceleración cambia con el tiempo, se usa una función senoidal entre amin y amax.", ref yPosition);
            AgregarFormula(@"a(t)=\frac{a_{max}+a_{min}}{2}+\frac{a_{max}-a_{min}}{2}\sin(t)", ref yPosition);
            AgregarFormula($@"a(t)=\frac{{{F(aMax)}+{F(aMin)}}}{{2}}+\frac{{{F(aMax)}-{F(aMin)}}}{{2}}\sin(t)", ref yPosition);
            AgregarFormula($@"a(t)={F(aceleracionMediaFormula)}+{F(amplitudFormula)}\sin(t)", ref yPosition);
            if (Math.Abs(aMax - aMin) < 0.000001)
            {
                AgregarTexto("Como amax y amin son iguales, la aceleración variable se convierte en una aceleración constante.", ref yPosition);
            }
            yPosition += 12;

            AgregarSubtitulo("2. Cálculo de la velocidad final", ref yPosition);
            AgregarTexto("La velocidad se obtiene acumulando la aceleración con el método del trapecio.", ref yPosition);
            AgregarFormula(@"v_{n+1}=v_n+\frac{a(t_n)+a(t_{n+1})}{2}\Delta t", ref yPosition);
            AgregarFormula($@"v_1={F(v0, 4)}+\frac{{{F(a0, 4)}+{F(a1, 4)}}}{{2}}({F(pasoEjemplo, 4)})", ref yPosition);
            AgregarFormula($@"v_1={F(v1, 4)}\;m/s", ref yPosition);
            if (vmax > 0)
            {
                AgregarTexto("Si un paso supera la velocidad máxima, el valor se recorta al límite permitido.", ref yPosition);
                AgregarFormula(@"v_{n+1}=\min(v_{max},v_{n+1})", ref yPosition);
            }
            AgregarTexto("Repitiendo el mismo cálculo hasta llegar al tiempo total se obtiene:", ref yPosition);
            AgregarFormula($@"v_f={F(vf)}\;m/s", ref yPosition);
            yPosition += 12;

            AgregarSubtitulo("3. Cálculo de la distancia recorrida", ref yPosition);
            AgregarTexto("La distancia se calcula de la misma forma, pero ahora integrando la velocidad.", ref yPosition);
            AgregarFormula(@"d_{n+1}=d_n+\frac{v_n+v_{n+1}}{2}\Delta t", ref yPosition);
            AgregarFormula($@"d_1=0+\frac{{{F(v0, 4)}+{F(v1, 4)}}}{{2}}({F(pasoEjemplo, 4)})", ref yPosition);
            AgregarFormula($@"d_1={F(distanciaPrimerPaso, 4)}\;m", ref yPosition);
            AgregarTexto("Sumando todos los pequeños tramos recorridos:", ref yPosition);
            AgregarFormula($@"d={F(d)}\;m", ref yPosition);
            yPosition += 12;

            AgregarSubtitulo("4. Cálculo del trabajo realizado por el motor", ref yPosition);
            AgregarTexto("En cada paso se calcula la aceleración efectiva, la fuerza del motor y el trabajo de ese tramo.", ref yPosition);
            AgregarFormula(@"a_{ef}=\frac{v_{n+1}-v_n}{\Delta t}", ref yPosition);
            AgregarFormula($@"a_{{ef,1}}=\frac{{{F(v1, 4)}-{F(v0, 4)}}}{{{F(pasoEjemplo, 4)}}}={F(aceleracionEfectiva, 4)}\;m/s^2", ref yPosition);
            AgregarFormula(@"F_{motor}=ma_{ef}+kv_{media}^2", ref yPosition);
            AgregarFormula($@"F_1={F(m)}({F(aceleracionEfectiva, 4)})+{F(k, 4)}({F(velocidadMedia, 4)})^2={F(fuerzaMotor, 4)}\;N", ref yPosition);
            AgregarFormula(@"W_{n+1}=W_n+F_{motor}\Delta d", ref yPosition);
            AgregarFormula($@"W_1={F(fuerzaMotor, 4)}({F(distanciaPrimerPaso, 4)})/1000={F(trabajoPrimerPaso, 4)}\;kJ", ref yPosition);
            AgregarTexto("Repitiendo la suma para todos los pasos:", ref yPosition);
            AgregarFormula($@"W={F(w)}\;kJ", ref yPosition);
            yPosition += 12;

            AgregarResumen(new Dictionary<string, string>
            {
                { "Velocidad final", $"{F(vf)} m/s" },
                { "Distancia", $"{F(d)} m" },
                { "Trabajo", $"{F(w)} kJ" },
                { "Paso de integración", $"{F(deltaT)} s" }
            }, ref yPosition);
        }

        private double CalcularAceleracionVariable(double tiempo, double aMax, double aMin)
        {
            return (aMax + aMin) / 2.0 + (aMax - aMin) / 2.0 * Math.Sin(tiempo);
        }

        private string F(double valor, int decimales = 2)
        {
            return ProcedimientoVisual.F(valor, decimales);
        }

        private void AgregarTitulo(string texto, ref int yPosition)
        {
            Label label = CrearLabel(texto, new Font("Arial", 15, FontStyle.Bold), Color.MidnightBlue, new Point(20, yPosition), new Size(800, 30));
            label.TextAlign = ContentAlignment.MiddleCenter;
            panelContenido.Controls.Add(label);
            yPosition += label.Height + 10;
        }

        private void AgregarSubtitulo(string texto, ref int yPosition)
        {
            Label label = CrearLabel(texto, new Font("Arial", 13, FontStyle.Bold), Color.DarkGreen, new Point(20, yPosition), new Size(800, 25));
            panelContenido.Controls.Add(label);
            yPosition += label.Height + 5;
        }

        private void AgregarTexto(string texto, ref int yPosition)
        {
            Label label = CrearLabel(texto, new Font("Arial", 12), Color.Black, new Point(30, yPosition), new Size(790, 0));
            label.AutoSize = true;
            label.MaximumSize = new Size(790, 0);
            panelContenido.Controls.Add(label);
            yPosition += label.Height + 8;
        }

        private void AgregarFormula(string latex, ref int yPosition)
        {
            Control formula = ProcedimientoVisual.CrearFormula(latex);
            formula.Location = new Point(50, yPosition);
            panelContenido.Controls.Add(formula);
            yPosition += formula.Height + 10;
        }

        private void AgregarResumen(Dictionary<string, string> filas, ref int yPosition)
        {
            AgregarSubtitulo("Resumen final", ref yPosition);

            int ancho = 750;
            int altoFila = 30;
            Panel resumen = new Panel
            {
                Location = new Point(50, yPosition),
                Size = new Size(ancho, 42 + filas.Count * altoFila),
                BackColor = Color.FromArgb(235, 245, 255),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label encabezado1 = CrearLabel("Parámetro", new Font("Arial", 11, FontStyle.Bold), Color.MidnightBlue, new Point(15, 10), new Size(350, 22));
            Label encabezado2 = CrearLabel("Valor", new Font("Arial", 11, FontStyle.Bold), Color.MidnightBlue, new Point(400, 10), new Size(300, 22));
            resumen.Controls.Add(encabezado1);
            resumen.Controls.Add(encabezado2);

            int y = 38;
            foreach (var fila in filas)
            {
                resumen.Controls.Add(CrearLabel(fila.Key, new Font("Arial", 11), Color.Black, new Point(15, y), new Size(350, 22)));
                resumen.Controls.Add(CrearLabel(fila.Value, new Font("Arial", 11, FontStyle.Bold), Color.Black, new Point(400, y), new Size(300, 22)));
                y += altoFila;
            }

            panelContenido.Controls.Add(resumen);
            yPosition += resumen.Height + 20;
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
            PlaySound("snd/Salir.wav");
            IniciarFadeOut();
        }

        private void IniciarFadeOut()
        {
            timer1.Stop();
            timer2.Stop();
            isAnimating = true;
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity > 0)
            {
                Opacity -= 0.07;
            }
            else
            {
                timer2.Stop();
                isAnimating = false;
                Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity < 1.0)
            {
                Opacity += 0.04;
            }
            else
            {
                timer1.Stop();
                isAnimating = false;
            }
        }

        private void FormProcedimiento_Load(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();

            isAnimating = true;
            Opacity = 0;
            timer1.Start();
        }
    }
}
