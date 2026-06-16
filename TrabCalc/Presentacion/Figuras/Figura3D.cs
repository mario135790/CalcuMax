using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using TrabCalc.Servicios;

namespace TrabCalc
{
    public abstract class Figura3D
    {
        private double porcentaje;
        private double volumenActual;
        private double volumenRestante;
        protected Panel panel;

        public abstract double VolumenTotal { get; }
        public virtual double AlturaTotal => 0;
        public virtual double AlturaLiquido
        {
            get
            {
                return AlturaTotal > 0 ? AlturaTotal * Porcentaje / 100.0 : 0;
            }
        }
        public virtual double AreaTransversalActual => AlturaTotal > 0 ? VolumenTotal / AlturaTotal : 0;
        public bool AnimacionLiquidoActiva { get; set; }
        public bool Drenando { get; set; }
        protected float FaseLiquido { get; private set; }

        public double Porcentaje
        {
            get
            {
                double total = VolumenTotal;
                if (total <= 0)
                {
                    return 0;
                }

                porcentaje = (VolumenActual / total) * 100;
                return Math.Round(porcentaje, 2);
            }
            set
            {
                porcentaje = Math.Max(0, Math.Min(100, value));
                ActualizarVolumen();
            }
        }

        public double VolumenActual
        {
            get => volumenActual;
            set
            {
                double total = VolumenTotal;
                volumenActual = total > 0 ? Math.Max(0, Math.Min(total, value)) : 0;
                volumenRestante = Math.Max(0, total - volumenActual);
            }
        }

        public double VolumenRestante
        {
            get => volumenRestante;
            set => volumenRestante = Math.Max(0, value);
        }

        public Panel Panel { get => panel; set => panel = value; }

        public Figura3D(Panel panel)
        {
            Panel = panel;
        }

        private void ActualizarVolumen()
        {
            double total = VolumenTotal;
            VolumenActual = porcentaje * total / 100;
            VolumenRestante = total - VolumenActual;
        }

        public virtual void dibujarFigura()
        {
            panel?.Invalidate();
        }

        public void AvanzarAnimacionLiquido(double segundos)
        {
            if (!AnimacionLiquidoActiva || segundos <= 0)
            {
                return;
            }

            FaseLiquido += (float)(segundos * 5.0);
            if (FaseLiquido > 10000)
            {
                FaseLiquido = 0;
            }
        }

        public void Dibujar(Graphics g)
        {
            if (panel == null || g == null)
            {
                return;
            }

            if (panel.FindForm() is FormSimuladorRecipientes form1)
            {
                DibujarConTransformaciones(g, form1.GetZoomFactor(), form1.GetPanOffset(), form1.GetModoVista());
            }
            else
            {
                DibujarConTransformaciones(g, 1.0f, new Point(0, 0), FormSimuladorRecipientes.ModoVista.Frontal);
            }
        }

        protected virtual void DibujarConTransformaciones(Graphics g, float zoom, Point pan, FormSimuladorRecipientes.ModoVista modo)
        {
            PrepararLienzo(g);
            GraphicsState estado = g.Save();

            AplicarTransformaciones(g, zoom, pan, modo);
            DibujarAyudasVisuales(g);
            DibujarFiguraEspecifica(g, modo);

            g.Restore(estado);
            DibujarInformacionEstado(g);
        }

        protected virtual void DibujarFiguraEspecifica(Graphics g, FormSimuladorRecipientes.ModoVista modo)
        {
        }

        protected void PrepararLienzo(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.Clear(Color.FromArgb(240, 240, 240));
        }

        protected void AplicarTransformaciones(Graphics g, float zoom, Point pan, FormSimuladorRecipientes.ModoVista modo)
        {
            g.TranslateTransform(pan.X, pan.Y);
            float centerX = panel.Width / 2f;
            float centerY = panel.Height / 2f;
            g.TranslateTransform(centerX, centerY);
            g.ScaleTransform(zoom, zoom);
            g.TranslateTransform(-centerX, -centerY);
        }

        protected void DibujarAyudasVisuales(Graphics g)
        {
            using (Pen gridPen = new Pen(Color.LightGray, 1))
            {
                gridPen.DashStyle = DashStyle.Dot;

                for (int i = 0; i < panel.Width; i += 50)
                {
                    g.DrawLine(gridPen, i, 0, i, panel.Height);
                }

                for (int i = 0; i < panel.Height; i += 50)
                {
                    g.DrawLine(gridPen, 0, i, panel.Width, i);
                }
            }
        }

        protected void DibujarInformacionEstado(Graphics g)
        {
            using (Font infoFont = new Font("Arial", 14, FontStyle.Bold))
            using (Brush infoBrush = new SolidBrush(Color.MidnightBlue))
            using (Brush backgroundBrush = new SolidBrush(Color.FromArgb(180, 240, 240, 255)))
            {
                string info = $"Volumen: {FormatoUnidades.Volumen(VolumenActual, 2)} / {FormatoUnidades.Volumen(VolumenTotal, 2)}";
                string porcentajeInfo = $"Llenado: {FormatoUnidades.Numero(Porcentaje, 2)}%";
                string alturaInfo = AlturaTotal > 0 ? $"Altura: {FormatoUnidades.Distancia(AlturaLiquido, 2)}" : "";

                SizeF infoSize = g.MeasureString(info, infoFont);
                SizeF porcentajeSize = g.MeasureString(porcentajeInfo, infoFont);
                SizeF alturaSize = string.IsNullOrEmpty(alturaInfo) ? SizeF.Empty : g.MeasureString(alturaInfo, infoFont);

                g.FillRectangle(backgroundBrush, 10, 10, infoSize.Width, infoSize.Height);
                g.DrawString(info, infoFont, infoBrush, 10, 10);
                g.FillRectangle(backgroundBrush, 10, 30, porcentajeSize.Width, porcentajeSize.Height);
                g.DrawString(porcentajeInfo, infoFont, infoBrush, 10, 30);

                if (!string.IsNullOrEmpty(alturaInfo))
                {
                    g.FillRectangle(backgroundBrush, 10, 50, alturaSize.Width, alturaSize.Height);
                    g.DrawString(alturaInfo, infoFont, infoBrush, 10, 50);
                }
            }
        }

        public virtual double VelocidadLLenado(double bomba)
        {
            return 0;
        }
    }
}
