using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace TrabCalc
{
    internal sealed class FondoAcuaticoAnimado : IDisposable
    {
        private readonly Guna2CustomGradientPanel panel;
        private readonly Control lienzoBurbujas;
        private readonly Timer timer = new Timer();
        private readonly Stopwatch reloj = new Stopwatch();
        private readonly Random random = new Random();
        private readonly List<Burbuja> burbujas = new List<Burbuja>();
        private readonly Color colorBase1;
        private readonly Color colorBase2;
        private readonly Color colorBase3;
        private readonly Color colorBase4;
        private double tiempo;
        private bool disposeRealizado;

        public FondoAcuaticoAnimado(Guna2CustomGradientPanel panel, Control lienzoBurbujas, int cantidadBurbujas = 34)
        {
            this.panel = panel;
            this.lienzoBurbujas = lienzoBurbujas;
            colorBase1 = NormalizarColor(panel.FillColor, Color.FromArgb(158, 229, 221));
            colorBase2 = NormalizarColor(panel.FillColor2, Color.CornflowerBlue);
            colorBase3 = NormalizarColor(panel.FillColor3, Color.DarkCyan);
            colorBase4 = NormalizarColor(panel.FillColor4, Color.DarkSlateGray);

            ActivarDobleBuffer(panel);
            ActivarDobleBuffer(lienzoBurbujas);

            if (lienzoBurbujas is PictureBox pictureBox)
            {
                pictureBox.Image = null;
            }

            lienzoBurbujas.Visible = false;
            panel.Paint += DibujarBurbujas;

            for (int i = 0; i < cantidadBurbujas; i++)
            {
                burbujas.Add(CrearBurbuja(true));
            }

            timer.Interval = 33;
            timer.Tick += Timer_Tick;
        }

        public void Iniciar()
        {
            if (disposeRealizado) return;

            reloj.Restart();
            timer.Start();
        }

        public void Detener()
        {
            timer.Stop();
            reloj.Stop();
        }

        public void Dispose()
        {
            if (disposeRealizado) return;
            disposeRealizado = true;

            Detener();
            timer.Tick -= Timer_Tick;
            panel.Paint -= DibujarBurbujas;
            timer.Dispose();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            double delta = Math.Min(0.08, Math.Max(0.001, reloj.Elapsed.TotalSeconds));
            reloj.Restart();
            tiempo += delta;

            AnimarGradiente();
            AnimarBurbujas(delta);

            panel.Invalidate();
        }

        private void AnimarGradiente()
        {
            double pulso = Math.Sin(tiempo * 0.45);
            double pulsoLento = Math.Sin(tiempo * 0.31);

            panel.FillColor = Oscilar(colorBase1, pulso, 0.07);
            panel.FillColor2 = Oscilar(colorBase2, pulsoLento, 0.06);
            panel.FillColor3 = Oscilar(colorBase3, -pulso, 0.05);
            panel.FillColor4 = Oscilar(colorBase4, -pulsoLento, 0.06);
        }

        private void AnimarBurbujas(double delta)
        {
            int ancho = Math.Max(1, panel.Width);

            foreach (Burbuja burbuja in burbujas)
            {
                burbuja.Y -= (float)(burbuja.Velocidad * delta);
                burbuja.X += (float)(Math.Sin(tiempo * burbuja.Oscilacion + burbuja.Fase) * burbuja.Deriva * delta);

                if (burbuja.Y < -burbuja.Radio * 2 || burbuja.X < -40 || burbuja.X > ancho + 40)
                {
                    ReiniciarBurbuja(burbuja, false);
                }
            }
        }

        private void DibujarBurbujas(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (Burbuja burbuja in burbujas)
            {
                float pulso = 1.0f + (float)Math.Sin(tiempo * 2.0 + burbuja.Fase) * 0.08f;
                float radio = burbuja.Radio * pulso;
                RectangleF rect = new RectangleF(burbuja.X - radio, burbuja.Y - radio, radio * 2, radio * 2);

                using (Brush relleno = new SolidBrush(Color.FromArgb(burbuja.Alfa / 4, Color.White)))
                using (Pen borde = new Pen(Color.FromArgb(burbuja.Alfa, Color.White), Math.Max(1.0f, radio * 0.08f)))
                using (Pen brillo = new Pen(Color.FromArgb(Math.Min(210, burbuja.Alfa + 35), Color.White), 1.0f))
                {
                    e.Graphics.FillEllipse(relleno, rect);
                    e.Graphics.DrawEllipse(borde, rect);
                    e.Graphics.DrawArc(brillo, rect.X + radio * 0.28f, rect.Y + radio * 0.22f, radio * 0.72f, radio * 0.55f, 205, 80);
                }
            }
        }

        private Burbuja CrearBurbuja(bool distribuirEnPantalla)
        {
            Burbuja burbuja = new Burbuja();
            ReiniciarBurbuja(burbuja, distribuirEnPantalla);
            return burbuja;
        }

        private void ReiniciarBurbuja(Burbuja burbuja, bool distribuirEnPantalla)
        {
            int ancho = Math.Max(1, panel.Width);
            int alto = Math.Max(1, panel.Height);

            burbuja.Radio = random.Next(5, 22);
            burbuja.X = random.Next(12, Math.Max(13, ancho - 12));
            burbuja.Y = distribuirEnPantalla
                ? random.Next(0, alto + 80)
                : alto + random.Next(15, 120);
            burbuja.Velocidad = random.Next(18, 58);
            burbuja.Alfa = random.Next(55, 145);
            burbuja.Fase = (float)(random.NextDouble() * Math.PI * 2);
            burbuja.Deriva = random.Next(6, 22);
            burbuja.Oscilacion = 0.7f + (float)random.NextDouble() * 1.4f;
        }

        private Color Mezclar(Color origen, Color destino, double cantidad)
        {
            cantidad = Math.Max(0, Math.Min(1, cantidad));
            int r = (int)(origen.R + (destino.R - origen.R) * cantidad);
            int g = (int)(origen.G + (destino.G - origen.G) * cantidad);
            int b = (int)(origen.B + (destino.B - origen.B) * cantidad);
            return Color.FromArgb(r, g, b);
        }

        private Color Oscilar(Color baseColor, double onda, double intensidad)
        {
            Color destino = onda >= 0
                ? Color.FromArgb(225, 250, 255)
                : Color.FromArgb(20, 70, 88);

            return Mezclar(baseColor, destino, Math.Abs(onda) * intensidad);
        }

        private Color NormalizarColor(Color color, Color respaldo)
        {
            if (color.IsEmpty || color.A == 0)
            {
                return respaldo;
            }

            return color;
        }

        private void ActivarDobleBuffer(Control control)
        {
            if (control == null) return;

            PropertyInfo propiedad = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            propiedad?.SetValue(control, true, null);
        }

        private sealed class Burbuja
        {
            public float X { get; set; }
            public float Y { get; set; }
            public float Radio { get; set; }
            public float Velocidad { get; set; }
            public int Alfa { get; set; }
            public float Fase { get; set; }
            public float Deriva { get; set; }
            public float Oscilacion { get; set; }
        }
    }
}
