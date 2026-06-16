using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TrabCalc.Servicios.Exportacion
{
    internal static class ExportadorResultados
    {
        public static bool ExportarTextoOCsv(IWin32Window owner, string nombreBase, string texto, string csv = null)
        {
            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Title = "Exportar resultados";
                dialogo.FileName = LimpiarNombreArchivo(nombreBase);
                dialogo.Filter = string.IsNullOrWhiteSpace(csv)
                    ? "Archivo de texto (*.txt)|*.txt"
                    : "Archivo de texto (*.txt)|*.txt|Datos CSV (*.csv)|*.csv";
                dialogo.DefaultExt = "txt";
                dialogo.AddExtension = true;
                dialogo.OverwritePrompt = true;

                if (dialogo.ShowDialog(owner) != DialogResult.OK)
                {
                    return false;
                }

                string contenido = dialogo.FilterIndex == 2 && !string.IsNullOrWhiteSpace(csv)
                    ? csv
                    : texto;
                File.WriteAllText(dialogo.FileName, contenido, Encoding.UTF8);
                return true;
            }
        }

        private static string LimpiarNombreArchivo(string nombre)
        {
            string limpio = string.IsNullOrWhiteSpace(nombre) ? "resultados" : nombre.Trim();
            foreach (char invalido in Path.GetInvalidFileNameChars())
            {
                limpio = limpio.Replace(invalido, '_');
            }

            return limpio;
        }

        public static string CsvEscape(string valor)
        {
            if (valor == null) return "";
            bool requiereComillas = valor.Contains(",") || valor.Contains("\"") || valor.Contains("\r") || valor.Contains("\n");
            string escapado = valor.Replace("\"", "\"\"");
            return requiereComillas ? $"\"{escapado}\"" : escapado;
        }
    }
}
