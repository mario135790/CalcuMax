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
    internal class Cilindro : Figura3D
    {
        public Cilindro(double radio, double altura, Panel panel) : base(panel)
        {
            Radio = radio;
            Altura = altura;
            Porcentaje = 0;
        }

        public double Radio { get; set; }
        public double Altura { get; set; }

        public override double VolumenTotal
        {
            get { return CalcularVolumenCilindro(); }
        }

        public override double AlturaTotal => Altura;
        public override double AreaTransversalActual => Math.PI * Math.Pow(Radio, 2);

        private double CalcularVolumenCilindro()
        {
            return Math.PI * Math.Pow(Radio, 2) * Altura;
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
                    DibujarVistaFrontal(g);
                    break;
                case FormSimuladorRecipientes.ModoVista.Lateral:
                    DibujarVistaLateral(g);
                    break;
                case FormSimuladorRecipientes.ModoVista.Isometrica:
                    DibujarVistaFrontal(g);
                    break;
            }

            g.Restore(estado);
            DibujarInformacionEstado(g);
        }

        private void DibujarVistaFrontal(Graphics g)
        {
            float porcen = Convert.ToSingle(Porcentaje / 100);
            int x = 100;
            int y = 250;
            int radio = 200;
            int altElp = Convert.ToInt32(Convert.ToDouble(radio) * 0.60);
            int altura = 250;

            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.DrawEllipse(pen, x, y, radio * 2, altElp);
                g.DrawLine(pen, x, y + (altElp / 2), x, y + (altElp / 2) - altura);
                g.DrawLine(pen, (radio * 2) + x, y + (altElp / 2), (radio * 2) + x, y + (altElp / 2) - altura);
                g.DrawEllipse(pen, x, y - altura, radio * 2, altElp);
            }

            if (porcen > 0)
            {
                float cuerpoY = y - (altura * porcen) + (altElp / 2);
                float superficieY = y - altura * porcen - 1;
                RectangleF areaLiquido = new RectangleF(x, cuerpoY, radio * 2, (altura * porcen) + altElp / 2);
                RectangleF areaSuperficie = new RectangleF(x, superficieY, radio * 2, altElp);

                using (Brush brushLiquido = EfectosLiquido.CrearBrochaLiquido(areaLiquido))
                using (Brush brushSuperficie = EfectosLiquido.CrearBrochaSuperficie(areaSuperficie))
                using (Pen penSuperficie = new Pen(Color.FromArgb(210, 24, 43, 139), 2))
                {
                    g.FillRectangle(brushLiquido, x, cuerpoY, radio * 2, altura * porcen);
                    g.FillEllipse(brushLiquido, x, y, radio * 2, altElp);
                    g.FillEllipse(brushSuperficie, areaSuperficie);
                    g.DrawEllipse(penSuperficie, areaSuperficie);
                }

                EfectosLiquido.DibujarBrillo(g, areaLiquido);
                EfectosLiquido.DibujarBurbujas(g, new RectangleF(x + 12, cuerpoY, radio * 2 - 24, Math.Max(12, y + altElp / 2 - cuerpoY)), FaseLiquido, 10);
                EfectosLiquido.DibujarOndasSuperficie(g, x + 35, superficieY + altElp / 2, radio * 2 - 70, FaseLiquido, 3.0f);

                if (AnimacionLiquidoActiva && !Drenando)
                {
                    EfectosLiquido.DibujarChorro(g, x + radio, y - altura - 60, superficieY + altElp / 2, FaseLiquido);
                }
                else if (AnimacionLiquidoActiva)
                {
                    EfectosLiquido.DibujarRemolino(g, new PointF(x + radio, y + altElp / 2 - 14), FaseLiquido);
                }
            }
        }

        private void DibujarVistaLateral(Graphics g)
        {
            float porcen = Convert.ToSingle(Porcentaje / 100);
            int x = 150;
            int y = 100;
            int ancho = 300;
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
                EfectosLiquido.DibujarBurbujas(g, areaLiquido, FaseLiquido, 8);
                EfectosLiquido.DibujarOndasSuperficie(g, x + 8, y + altura - alturaLiquido, ancho - 16, FaseLiquido, 2.6f);

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

        private void DibujarOndas(Graphics g, int centerX, int centerY, int radio)
        {
            Pen ondaPen = new Pen(Color.Blue, 1);
            ondaPen.DashStyle = DashStyle.Dash;

            for (int i = 0; i < 3; i++)
            {
                int offset = (i % 2 == 0) ? -2 : 2;
                g.DrawArc(ondaPen, centerX - radio + i * 20, centerY + offset, radio / 2, 10, 0, 180);
            }

            ondaPen.Dispose();
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
            return bomba / (Math.PI * Math.Pow(Radio, 2));
        }
    }
}
