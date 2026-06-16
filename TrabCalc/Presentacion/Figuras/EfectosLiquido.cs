using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TrabCalc
{
    internal static class EfectosLiquido
    {
        public static Brush CrearBrochaLiquido(RectangleF area)
        {
            area = NormalizarArea(area);
            return new LinearGradientBrush(
                area,
                Color.FromArgb(235, 185, 241, 255),
                Color.FromArgb(235, 56, 151, 209),
                LinearGradientMode.Vertical);
        }

        public static Brush CrearBrochaSuperficie(RectangleF area)
        {
            area = NormalizarArea(area);
            return new LinearGradientBrush(
                area,
                Color.FromArgb(235, 34, 53, 151),
                Color.FromArgb(235, 94, 211, 241),
                LinearGradientMode.Horizontal);
        }

        public static void DibujarBrillo(Graphics g, RectangleF area)
        {
            if (area.Width <= 0 || area.Height <= 0) return;

            RectangleF brillo = new RectangleF(
                area.Left + area.Width * 0.10f,
                area.Top + area.Height * 0.10f,
                area.Width * 0.22f,
                Math.Max(8, area.Height * 0.80f));

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(brillo);
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = Color.FromArgb(70, Color.White);
                    brush.SurroundColors = new[] { Color.FromArgb(0, Color.White) };
                    g.FillEllipse(brush, brillo);
                }
            }
        }

        public static void DibujarBurbujas(Graphics g, RectangleF area, float fase, int cantidad)
        {
            if (area.Width < 8 || area.Height < 12 || cantidad <= 0) return;

            GraphicsState estado = g.Save();
            g.SetClip(area, CombineMode.Intersect);

            using (Pen pen = new Pen(Color.FromArgb(130, 255, 255, 255), 1))
            using (Brush brush = new SolidBrush(Color.FromArgb(28, Color.White)))
            {
                for (int i = 0; i < cantidad; i++)
                {
                    float avance = fase * 0.10f + i * 0.173f;
                    avance -= (float)Math.Floor(avance);

                    float x = area.Left + ((i * 47) % Math.Max(1, (int)area.Width));
                    x += (float)Math.Sin(fase * 0.9f + i) * 8f;
                    float y = area.Bottom - avance * area.Height;
                    float tamano = 4f + (i % 3) * 2f;

                    RectangleF burbuja = new RectangleF(x, y, tamano, tamano);
                    g.FillEllipse(brush, burbuja);
                    g.DrawEllipse(pen, burbuja);
                }
            }

            g.Restore(estado);
        }

        public static void DibujarOndasSuperficie(Graphics g, float x, float y, float ancho, float fase, float amplitud)
        {
            if (ancho <= 8) return;

            using (GraphicsPath path = new GraphicsPath())
            {
                PointF anterior = new PointF(x, y + (float)Math.Sin(fase) * amplitud);

                for (float px = 8; px <= ancho; px += 8)
                {
                    float py = y + (float)Math.Sin(px * 0.055f + fase) * amplitud;
                    PointF actual = new PointF(x + px, py);
                    path.AddLine(anterior, actual);
                    anterior = actual;
                }

                using (Pen sombra = new Pen(Color.FromArgb(120, 19, 72, 164), 2.4f))
                using (Pen brillo = new Pen(Color.FromArgb(185, 239, 255, 255), 1.2f))
                {
                    g.DrawPath(sombra, path);
                    g.DrawPath(brillo, path);
                }
            }
        }

        public static void DibujarChorro(Graphics g, float x, float yInicio, float yFin, float fase)
        {
            if (yFin <= yInicio) return;

            float oscilacion = (float)Math.Sin(fase * 1.7f) * 5f;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddBezier(
                    x + oscilacion,
                    yInicio,
                    x - 12 + oscilacion,
                    yInicio + (yFin - yInicio) * 0.35f,
                    x + 12 - oscilacion,
                    yInicio + (yFin - yInicio) * 0.70f,
                    x,
                    yFin);

                using (Pen exterior = new Pen(Color.FromArgb(150, 40, 180, 230), 5f))
                using (Pen interior = new Pen(Color.FromArgb(210, 238, 255, 255), 1.7f))
                {
                    exterior.StartCap = LineCap.Round;
                    exterior.EndCap = LineCap.Round;
                    interior.StartCap = LineCap.Round;
                    interior.EndCap = LineCap.Round;
                    g.DrawPath(exterior, path);
                    g.DrawPath(interior, path);
                }
            }
        }

        public static void DibujarRemolino(Graphics g, PointF centro, float fase)
        {
            using (Pen pen = new Pen(Color.FromArgb(175, 245, 255, 255), 1.8f))
            {
                for (int i = 0; i < 3; i++)
                {
                    float radio = 10 + i * 5;
                    RectangleF rect = new RectangleF(centro.X - radio, centro.Y - radio * 0.45f, radio * 2, radio * 0.9f);
                    float inicio = fase * 45f + i * 70f;
                    g.DrawArc(pen, rect, inicio, 245);
                }
            }
        }

        private static RectangleF NormalizarArea(RectangleF area)
        {
            if (area.Width < 1) area.Width = 1;
            if (area.Height < 1) area.Height = 1;
            return area;
        }
    }
}
