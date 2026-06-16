using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using TrabCalc;

namespace TrabCalc
{
    internal class Esfera : Figura3D
    {
        public Esfera(double radio, Panel panel) : base(panel)
        {
            Radio = radio;
            Porcentaje = 0;
        }

        public double Radio { get; set; }

        public override double VolumenTotal
        {
            get { return (4.0 / 3.0) * Math.PI * Math.Pow(Radio, 3); }
        }

        public override double AlturaTotal => Radio * 2.0;
        public override double AlturaLiquido
        {
            get
            {
                double total = VolumenTotal;
                if (total <= 0) return 0;

                return CalcularAlturaDesdeFraccion(VolumenActual / total, Radio);
            }
        }

        public override double AreaTransversalActual
        {
            get
            {
                double h = AlturaLiquido;
                return Math.PI * Math.Max(0, 2.0 * Radio * h - h * h);
            }
        }

        protected override void DibujarConTransformaciones(Graphics g, float zoom, Point pan, FormSimuladorRecipientes.ModoVista modo)
        {
            PrepararLienzo(g);
            GraphicsState estado = g.Save();

            AplicarTransformaciones(g, zoom, pan, modo);
            DibujarAyudasVisuales(g);

            switch (modo)
            {
                case FormSimuladorRecipientes.ModoVista.Frontal:
                case FormSimuladorRecipientes.ModoVista.Isometrica:
                    DibujarVistaFrontal(g);
                    break;
                case FormSimuladorRecipientes.ModoVista.Lateral:
                    DibujarVistaLateral(g);
                    break;
            }

            g.Restore(estado);
            DibujarInformacionEstado(g);
        }

        private void DibujarVistaFrontal(Graphics g)
        {
            int x = 200;
            int y = 200;
            int radio = 150;
            RectangleF areaEsfera = new RectangleF(x - radio, y - radio, radio * 2, radio * 2);

            using (Brush brushEsfera = new SolidBrush(Color.LightGray))
            {
                g.FillEllipse(brushEsfera, areaEsfera);
            }
            float porcentajeLlenado = (float)Porcentaje / 100f;

            if (porcentajeLlenado > 0)
            {
                float alturaLlenado = CalcularAlturaLlenadoDesdeFraccion(porcentajeLlenado, radio);
                RectangleF rectLlenado = new RectangleF(
                    x - radio,
                    y + radio - alturaLlenado,
                    radio * 2,
                    alturaLlenado
                );

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(areaEsfera);
                    using (Region region = new Region(path))
                    {
                        g.SetClip(region, CombineMode.Replace);

                        using (Brush brushLiquido = EfectosLiquido.CrearBrochaLiquido(rectLlenado))
                        {
                            g.FillRectangle(brushLiquido, rectLlenado);
                        }

                        EfectosLiquido.DibujarBrillo(g, rectLlenado);
                        EfectosLiquido.DibujarBurbujas(g, rectLlenado, FaseLiquido, 9);

                        if (porcentajeLlenado > 0 && porcentajeLlenado < 1)
                        {
                            float h = alturaLlenado;
                            float R = radio;
                            float dy = R - h;
                            float rInterseccion = (float)Math.Sqrt(Math.Max(0, R * R - dy * dy));

                            float sombraX = x - rInterseccion;
                            float sombraY = y + R - h - 5;
                            float sombraAncho = rInterseccion * 2;
                            float sombraAlto = 10;
                            RectangleF areaSuperficie = new RectangleF(sombraX, sombraY, sombraAncho, sombraAlto);

                            using (Brush brushSuperficie = EfectosLiquido.CrearBrochaSuperficie(areaSuperficie))
                            {
                                g.FillEllipse(brushSuperficie, areaSuperficie);
                            }

                            EfectosLiquido.DibujarOndasSuperficie(g, sombraX + 6, sombraY + sombraAlto / 2, sombraAncho - 12, FaseLiquido, 2.4f);
                        }

                        g.ResetClip();
                    }
                }

                if (AnimacionLiquidoActiva && !Drenando)
                {
                    EfectosLiquido.DibujarChorro(g, x, y - radio - 45, rectLlenado.Top + 8, FaseLiquido);
                }
                else if (AnimacionLiquidoActiva)
                {
                    EfectosLiquido.DibujarRemolino(g, new PointF(x, y + radio - 36), FaseLiquido);
                }
            }

            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.DrawEllipse(pen, areaEsfera);
            }
            DibujarSombreado(g, x, y, radio);
        }

        private void DibujarVistaLateral(Graphics g)
        {
            int centerX = 250;
            int centerY = 200;
            int radio = 120;
            RectangleF areaEsfera = new RectangleF(centerX - radio, centerY - radio, radio * 2, radio * 2);

            using (Brush brushEsfera = new SolidBrush(Color.LightGray))
            {
                g.FillEllipse(brushEsfera, areaEsfera);
            }
            float porcentajeLlenado = (float)Porcentaje / 100f;

            if (porcentajeLlenado > 0)
            {
                float alturaLlenado = CalcularAlturaLlenadoDesdeFraccion(porcentajeLlenado, radio);
                RectangleF rectLlenado = new RectangleF(
                    centerX - radio,
                    centerY + radio - alturaLlenado,
                    radio * 2,
                    alturaLlenado
                );

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(areaEsfera);
                    using (Region region = new Region(path))
                    {
                        g.SetClip(region, CombineMode.Replace);

                        using (Brush brushLiquido = EfectosLiquido.CrearBrochaLiquido(rectLlenado))
                        {
                            g.FillRectangle(brushLiquido, rectLlenado);
                        }

                        EfectosLiquido.DibujarBrillo(g, rectLlenado);
                        EfectosLiquido.DibujarBurbujas(g, rectLlenado, FaseLiquido, 7);

                        if (porcentajeLlenado > 0 && porcentajeLlenado < 1)
                        {
                            float h = alturaLlenado;
                            float R = radio;
                            float dy = R - h;
                            float rInterseccion = (float)Math.Sqrt(Math.Max(0, R * R - dy * dy));

                            float sombraX = centerX - rInterseccion;
                            float sombraY = centerY + R - h - 3;
                            float sombraAncho = rInterseccion * 2;
                            EfectosLiquido.DibujarOndasSuperficie(g, sombraX, sombraY, sombraAncho, FaseLiquido, 2.0f);
                        }

                        g.ResetClip();
                    }
                }

                if (AnimacionLiquidoActiva && !Drenando)
                {
                    EfectosLiquido.DibujarChorro(g, centerX, centerY - radio - 35, rectLlenado.Top + 8, FaseLiquido);
                }
                else if (AnimacionLiquidoActiva)
                {
                    EfectosLiquido.DibujarRemolino(g, new PointF(centerX, centerY + radio - 30), FaseLiquido);
                }
            }

            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.DrawEllipse(pen, areaEsfera);
            }
            DibujarLineasReferenciaLateral(g, centerX, centerY, radio);
        }

        private float CalcularAlturaLlenadoDesdeFraccion(float fraccionVolumen, float radio)
        {
            return (float)CalcularAlturaDesdeFraccion(fraccionVolumen, radio);
        }

        private double CalcularAlturaDesdeFraccion(double fraccionVolumen, double radio)
        {
            if (fraccionVolumen <= 0) return 0;
            if (fraccionVolumen >= 1) return radio * 2;

            double inferior = 0;
            double superior = radio * 2.0;
            double radioCubo = Math.Pow(radio, 3);

            for (int i = 0; i < 40; i++)
            {
                double altura = (inferior + superior) / 2.0;
                double fraccion = altura * altura * (3.0 * radio - altura) / (4.0 * radioCubo);

                if (fraccion < fraccionVolumen)
                {
                    inferior = altura;
                }
                else
                {
                    superior = altura;
                }
            }

            return (inferior + superior) / 2.0;
        }

        private void DibujarLineasReferenciaLateral(Graphics g, int centerX, int centerY, int radio)
        {
            Pen penReferencia = new Pen(Color.FromArgb(80, Color.Gray), 1);
            penReferencia.DashStyle = DashStyle.Dot;
            g.DrawLine(penReferencia, centerX - radio, centerY, centerX + radio, centerY);
            g.DrawLine(penReferencia, centerX, centerY - radio, centerX, centerY + radio);
            penReferencia.Dispose();
        }

        private void DibujarSombreado(Graphics g, int centerX, int centerY, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(centerX - radio, centerY - radio, radio * 2, radio * 2);

            PathGradientBrush gradient = new PathGradientBrush(path);
            gradient.CenterPoint = new PointF(centerX - radio * 0.3f, centerY - radio * 0.3f);
            gradient.CenterColor = Color.FromArgb(50, Color.White);
            gradient.SurroundColors = new Color[] { Color.FromArgb(30, Color.Black) };

            g.FillEllipse(gradient, centerX - radio, centerY - radio, radio * 2, radio * 2);

            path.Dispose();
            gradient.Dispose();
        }

        public override double VelocidadLLenado(double bomba)
        {
            double area = AreaTransversalActual;
            return area > 0 ? bomba / area : 0;
        }
    }
}
