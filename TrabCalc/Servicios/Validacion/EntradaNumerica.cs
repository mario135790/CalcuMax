using System.Globalization;

namespace TrabCalc
{
    internal static class EntradaNumerica
    {
        public static bool TryLeerDouble(string texto, out double valor)
        {
            valor = 0;

            if (string.IsNullOrWhiteSpace(texto))
            {
                return false;
            }

            if (double.TryParse(texto, NumberStyles.Float, CultureInfo.CurrentCulture, out valor))
            {
                return true;
            }

            texto = texto.Replace(',', '.');
            return double.TryParse(texto, NumberStyles.Float, CultureInfo.InvariantCulture, out valor);
        }
    }
}
