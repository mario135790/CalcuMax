using CSharpMath.SkiaSharp;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TrabCalc.Servicios.Exportacion
{
    internal static class ExportadorProcedimiento
    {
        private const float AnchoPagina = 595;
        private const float AltoPagina = 842;
        private const float Margen = 44;

        public static bool ExportarPdf(IWin32Window owner, DocumentoProcedimiento documento, string nombreBase)
        {
            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Title = "Exportar procedimiento a PDF";
                dialogo.FileName = LimpiarNombreArchivo(nombreBase);
                dialogo.Filter = "Documento PDF (*.pdf)|*.pdf";
                dialogo.DefaultExt = "pdf";
                dialogo.AddExtension = true;
                dialogo.OverwritePrompt = true;

                if (dialogo.ShowDialog(owner) != DialogResult.OK)
                {
                    return false;
                }

                using (FileStream stream = File.Open(dialogo.FileName, FileMode.Create, FileAccess.Write))
                using (SKDocument pdf = SKDocument.CreatePdf(stream))
                {
                    DibujarDocumento(pdf, documento);
                }

                return true;
            }
        }

        private static void DibujarDocumento(SKDocument pdf, DocumentoProcedimiento documento)
        {
            SKCanvas canvas = null;
            float y = Margen;

            using (SKPaint texto = CrearPaint(12, SKColors.Black, false))
            using (SKPaint titulo = CrearPaint(19, new SKColor(15, 45, 115), true))
            using (SKPaint subtitulo = CrearPaint(15, new SKColor(0, 105, 35), true))
            using (SKPaint formulaFondo = new SKPaint { Color = new SKColor(245, 245, 245), IsAntialias = true })
            using (SKPaint formulaBorde = new SKPaint { Color = new SKColor(110, 110, 110), Style = SKPaintStyle.Stroke, StrokeWidth = 1, IsAntialias = true })
            {
                NuevaPagina(pdf, ref canvas, ref y);

                foreach (ElementoProcedimiento elemento in documento.Elementos)
                {
                    switch (elemento.Tipo)
                    {
                        case TipoElementoProcedimiento.Titulo:
                            DibujarTextoEnvuelto(pdf, ref canvas, ref y, elemento.Texto, titulo, 10);
                            break;
                        case TipoElementoProcedimiento.Subtitulo:
                            y += 8;
                            DibujarTextoEnvuelto(pdf, ref canvas, ref y, elemento.Texto, subtitulo, 6);
                            break;
                        case TipoElementoProcedimiento.Formula:
                            DibujarFormula(pdf, ref canvas, ref y, elemento.Texto, formulaFondo, formulaBorde);
                            break;
                        case TipoElementoProcedimiento.Separador:
                            AsegurarEspacio(pdf, ref canvas, ref y, 20);
                            canvas.DrawLine(Margen, y, AnchoPagina - Margen, y, formulaBorde);
                            y += 18;
                            break;
                        default:
                            DibujarTextoEnvuelto(pdf, ref canvas, ref y, elemento.Texto, texto, 5);
                            break;
                    }
                }

                pdf.EndPage();
            }
        }

        private static void NuevaPagina(SKDocument pdf, ref SKCanvas canvas, ref float y)
        {
            if (canvas != null)
            {
                pdf.EndPage();
            }

            canvas = pdf.BeginPage(AnchoPagina, AltoPagina);
            canvas.Clear(SKColors.White);
            y = Margen;
        }

        private static void AsegurarEspacio(SKDocument pdf, ref SKCanvas canvas, ref float y, float altoNecesario)
        {
            if (y + altoNecesario > AltoPagina - Margen)
            {
                NuevaPagina(pdf, ref canvas, ref y);
            }
        }

        private static void DibujarTextoEnvuelto(SKDocument pdf, ref SKCanvas canvas, ref float y, string texto, SKPaint paint, float espacioDespues)
        {
            float ancho = AnchoPagina - Margen * 2;
            List<string> lineas = Envolver(texto ?? "", paint, ancho);
            float altoLinea = paint.TextSize + 5;

            foreach (string linea in lineas)
            {
                AsegurarEspacio(pdf, ref canvas, ref y, altoLinea + espacioDespues);
                canvas.DrawText(linea, Margen, y + paint.TextSize, paint);
                y += altoLinea;
            }

            y += espacioDespues;
        }

        private static void DibujarFormula(SKDocument pdf, ref SKCanvas canvas, ref float y, string latex, SKPaint fondo, SKPaint borde)
        {
            float ancho = AnchoPagina - Margen * 2;

            try
            {
                MathPainter painter = new MathPainter
                {
                    LaTeX = latex ?? "",
                    FontSize = 16
                };

                var medida = painter.Measure();
                while (medida.Width > ancho - 28 && painter.FontSize > 10)
                {
                    painter.FontSize -= 1;
                    medida = painter.Measure();
                }

                float alto = Math.Max(54, medida.Height + 28);
                AsegurarEspacio(pdf, ref canvas, ref y, alto + 10);
                SKRect rect = new SKRect(Margen, y, Margen + ancho, y + alto);
                canvas.DrawRect(rect, fondo);
                canvas.DrawRect(rect, borde);

                float x = Math.Max(Margen + 12, Margen + ancho / 2f - medida.Width / 2f);
                painter.Draw(canvas, new SKPoint(x, y + alto / 2f));
                y += alto + 10;
            }
            catch
            {
                using (SKPaint formulaTexto = CrearPaint(11, SKColors.Black, false))
                {
                    DibujarTextoEnvuelto(pdf, ref canvas, ref y, "Formula: " + latex, formulaTexto, 6);
                }
            }
        }

        private static List<string> Envolver(string texto, SKPaint paint, float anchoMaximo)
        {
            List<string> lineas = new List<string>();
            string[] parrafos = (texto ?? "").Replace("\r", "").Split('\n');

            foreach (string parrafo in parrafos)
            {
                string[] palabras = parrafo.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (palabras.Length == 0)
                {
                    lineas.Add("");
                    continue;
                }

                string actual = "";
                foreach (string palabra in palabras)
                {
                    string candidata = string.IsNullOrEmpty(actual) ? palabra : actual + " " + palabra;
                    if (paint.MeasureText(candidata) <= anchoMaximo)
                    {
                        actual = candidata;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(actual))
                        {
                            lineas.Add(actual);
                        }

                        actual = palabra;
                    }
                }

                if (!string.IsNullOrEmpty(actual))
                {
                    lineas.Add(actual);
                }
            }

            return lineas;
        }

        private static SKPaint CrearPaint(float tamano, SKColor color, bool negrita)
        {
            return new SKPaint
            {
                Color = color,
                IsAntialias = true,
                TextSize = tamano,
                Typeface = SKTypeface.FromFamilyName("Segoe UI", negrita ? SKFontStyle.Bold : SKFontStyle.Normal)
            };
        }

        private static string LimpiarNombreArchivo(string nombre)
        {
            string limpio = string.IsNullOrWhiteSpace(nombre) ? "procedimiento" : nombre.Trim();
            foreach (char invalido in Path.GetInvalidFileNameChars())
            {
                limpio = limpio.Replace(invalido, '_');
            }

            return limpio;
        }
    }
}
