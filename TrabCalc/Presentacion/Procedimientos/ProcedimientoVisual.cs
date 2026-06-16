using SkiaSharp;
using System;
using System.Drawing;
using System.Windows.Forms;
using TrabCalc.Servicios;

namespace TrabCalc
{
    internal static class ProcedimientoVisual
    {
        public static string F(double valor, int decimales = 2)
        {
            return FormatoUnidades.NumeroLatex(valor, decimales);
        }

        public static Control CrearFormula(string latex, int ancho = 750, int fuente = 16)
        {
            try
            {
                var mathPainter = new CSharpMath.SkiaSharp.MathPainter
                {
                    LaTeX = latex,
                    FontSize = fuente
                };

                var medida = mathPainter.Measure();
                while (medida.Width > ancho - 24 && mathPainter.FontSize > 11)
                {
                    mathPainter.FontSize -= 1;
                    medida = mathPainter.Measure();
                }
                int alto = Math.Max(72, (int)Math.Ceiling(medida.Height + 34));

                using (var skBitmap = new SKBitmap(ancho, alto))
                using (var canvas = new SKCanvas(skBitmap))
                {
                    canvas.Clear(new SKColor(245, 245, 245));

                    float x = Math.Max(12, ancho / 2f - medida.Width / 2f);
                    float y = alto / 2f;
                    mathPainter.Draw(canvas, new SKPoint(x, y));

                    using (var image = SKImage.FromBitmap(skBitmap))
                    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                    using (var stream = data.AsStream())
                    using (var temporal = new Bitmap(stream))
                    {
                        return new PictureBox
                        {
                            Image = new Bitmap(temporal),
                            Size = new Size(ancho, alto),
                            SizeMode = PictureBoxSizeMode.CenterImage,
                            BorderStyle = BorderStyle.FixedSingle,
                            BackColor = Color.FromArgb(245, 245, 245)
                        };
                    }
                }
            }
            catch
            {
                return new Label
                {
                    Text = latex,
                    Font = new Font("Consolas", 11),
                    ForeColor = Color.Black,
                    BackColor = Color.FromArgb(245, 245, 245),
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(ancho, 56)
                };
            }
        }
    }
}
