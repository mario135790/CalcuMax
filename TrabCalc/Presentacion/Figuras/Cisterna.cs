using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using TrabCalc;

namespace TrabCalc
{
    internal class Cisterna : Figura3D
    {
        public Cisterna(double largo, double ancho, double alto, Panel panel) : base(panel)
        {
            Largo = largo;
            Ancho = ancho;
            Altura = alto;
            Porcentaje = 0;
        }

        public double Largo { get; set; }
        public double Ancho { get; set; }
        public double Altura { get; set; }

        public override double VolumenTotal => Largo * Ancho * Altura;
        public override double AlturaTotal => Altura;
        public override double AreaTransversalActual => Largo * Ancho;

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
                    DibujarVistaIsometrica(g);
                    break;
                case FormSimuladorRecipientes.ModoVista.Lateral:
                    DibujarVistaLateral(g);
                    break;
            }

            g.Restore(estado);
            DibujarInformacionEstado(g);
        }

        private void DibujarVistaLateral(Graphics g)
        {
            float porcen = Convert.ToSingle(Porcentaje / 100);
            int x = 200;
            int y = 100;
            int ancho = 200;
            int altura = 250;

            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.DrawRectangle(pen, x, y, ancho, altura);
            }

            if (porcen > 0)
            {
                int alturaLiquido = (int)(altura * porcen);
                RectangleF areaLiquido = new RectangleF(x + 1, y + altura - alturaLiquido, ancho - 2, alturaLiquido);
                RectangleF areaSuperficie = new RectangleF(x + 1, y + altura - alturaLiquido - 4, ancho - 2, 8);

                using (Brush brushLiquido = EfectosLiquido.CrearBrochaLiquido(areaLiquido))
                using (Brush brushSuperficie = EfectosLiquido.CrearBrochaSuperficie(areaSuperficie))
                {
                    g.FillRectangle(brushLiquido, areaLiquido);
                    g.FillRectangle(brushSuperficie, areaSuperficie);
                }

                EfectosLiquido.DibujarBrillo(g, areaLiquido);
                EfectosLiquido.DibujarBurbujas(g, areaLiquido, FaseLiquido, 7);
                EfectosLiquido.DibujarOndasSuperficie(g, x + 6, y + altura - alturaLiquido, ancho - 12, FaseLiquido, 2.4f);

                if (AnimacionLiquidoActiva && !Drenando)
                {
                    EfectosLiquido.DibujarChorro(g, x + ancho / 2, y - 35, y + altura - alturaLiquido, FaseLiquido);
                }
                else if (AnimacionLiquidoActiva)
                {
                    EfectosLiquido.DibujarRemolino(g, new PointF(x + ancho / 2, y + altura - 18), FaseLiquido);
                }
            }
        }

        private void DibujarVistaIsometrica(Graphics g)
        {
            float llenado2 = 100 - Convert.ToSingle(Porcentaje);
            float llenado = llenado2 / 100;

            int x = 100;
            int y = 100;
            int ancho = 300;
            int altura = 250;
            int largo = 90;

            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.DrawRectangle(pen, x, y, ancho, altura);

                g.DrawLine(pen, x, y, x + largo, y - largo);
                g.DrawLine(pen, x + ancho, y, x + ancho + largo, y - largo);
                g.DrawLine(pen, x, y + altura, x + largo, y + altura - largo);
                g.DrawLine(pen, x + ancho, y + altura, x + ancho + largo, y + altura - largo);

                g.DrawLine(pen, x + largo, y - largo, x + largo, y + altura - largo);
                g.DrawLine(pen, x + ancho + largo, y - largo, x + ancho + largo, y + altura - largo);
                g.DrawLine(pen, x + largo, y - largo, x + ancho + largo, y - largo);
                g.DrawLine(pen, x + largo, y + altura - largo, x + ancho + largo, y + altura - largo);
            }

            if (Porcentaje > 0)
            {
                float nivelY = y + altura * llenado;
                RectangleF areaLiquido = new RectangleF(x + 1, nivelY - 1, ancho - 1, altura - 1 - (altura * llenado) + 2);
                Point[] fillDer = new Point[]
                {
                    new Point(x + ancho + 1, y + Convert.ToInt32(altura * llenado) - 3),
                    new Point(x + ancho + 1, y + altura - 1),
                    new Point(x + ancho + largo, y + altura - largo - 1),
                    new Point(x + ancho + largo, y - largo + Convert.ToInt32(altura * llenado) - 1)
                };
                Point[] fillSup = new Point[]
                {
                    new Point(x + largo + 1, y + Convert.ToInt32(altura * llenado) - largo - 1),
                    new Point(x + 1, y + Convert.ToInt32(altura * llenado) - 1),
                    new Point(x + ancho - 1, y + Convert.ToInt32(altura * llenado) - 1),
                    new Point(x + ancho + largo - 1, y - largo + Convert.ToInt32(altura * llenado) - 1)
                };

                using (Brush brushLiquido = EfectosLiquido.CrearBrochaLiquido(areaLiquido))
                using (Brush brushSuperficie = EfectosLiquido.CrearBrochaSuperficie(new RectangleF(x, nivelY - largo, ancho + largo, largo + 8)))
                using (Pen pen = new Pen(Color.FromArgb(210, 24, 43, 139), 2))
                {
                    g.FillRectangle(brushLiquido, areaLiquido);
                    g.FillPolygon(brushLiquido, fillDer);
                    g.FillPolygon(brushSuperficie, fillSup);
                    g.DrawPolygon(pen, fillSup);
                }

                EfectosLiquido.DibujarBrillo(g, areaLiquido);
                EfectosLiquido.DibujarBurbujas(g, areaLiquido, FaseLiquido, 10);
                EfectosLiquido.DibujarOndasSuperficie(g, x + 12, nivelY, ancho - 24, FaseLiquido, 2.4f);

                if (AnimacionLiquidoActiva && !Drenando)
                {
                    EfectosLiquido.DibujarChorro(g, x + ancho / 2, y - largo - 45, nivelY - 4, FaseLiquido);
                }
                else if (AnimacionLiquidoActiva)
                {
                    EfectosLiquido.DibujarRemolino(g, new PointF(x + ancho / 2, y + altura - 22), FaseLiquido);
                }
            }
        }

        private void DibujarOndasLaterales(Graphics g, int x, int y, int ancho)
        {
            Pen ondaPen = new Pen(Color.Blue, 1);
            ondaPen.DashStyle = DashStyle.Dash;

            for (int i = 0; i < ancho; i += 20)
            {
                int offset = ((i / 20) % 2 == 0) ? -1 : 1;
                g.DrawLine(ondaPen, x + i, y + offset, x + i + 10, y + offset);
            }

            ondaPen.Dispose();
        }

        public override double VelocidadLLenado(double bomba)
        {
            return bomba / (Ancho * Largo);
        }
    }
}
