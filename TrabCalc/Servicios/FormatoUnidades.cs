using System;
using System.Globalization;

namespace TrabCalc.Servicios
{
    internal static class FormatoUnidades
    {
        public static string Numero(double valor, int decimales = 2)
        {
            if (double.IsPositiveInfinity(valor)) return "∞";
            if (double.IsNegativeInfinity(valor)) return "-∞";
            if (double.IsNaN(valor)) return "0";

            return valor.ToString("F" + decimales, CultureInfo.InvariantCulture);
        }

        public static string NumeroLatex(double valor, int decimales = 2)
        {
            if (double.IsPositiveInfinity(valor)) return @"\infty";
            if (double.IsNegativeInfinity(valor)) return @"-\infty";
            if (double.IsNaN(valor)) return "0";

            return Numero(valor, decimales);
        }

        public static string Volumen(double valor, int decimales = 3)
        {
            return $"{Numero(valor, decimales)} m³";
        }

        public static string CaudalMinuto(double valor, int decimales = 4)
        {
            return $"{Numero(valor, decimales)} m³/min";
        }

        public static string CaudalSegundo(double valor, int decimales = 6)
        {
            return $"{Numero(valor, decimales)} m³/s";
        }

        public static string VelocidadMs(double valor, int decimales = 2)
        {
            return $"{Numero(valor, decimales)} m/s";
        }

        public static string VelocidadKmh(double valor, int decimales = 2)
        {
            return $"{Numero(valor, decimales)} km/h";
        }

        public static string Aceleracion(double valor, int decimales = 2)
        {
            return $"{Numero(valor, decimales)} m/s²";
        }

        public static string Distancia(double valor, int decimales = 2)
        {
            return $"{Numero(valor, decimales)} m";
        }

        public static string TrabajoKj(double valor, int decimales = 2)
        {
            return $"{Numero(valor, decimales)} kJ";
        }

        public static string TiempoSegundos(double valor, int decimales = 2)
        {
            return $"{Numero(valor, decimales)} s";
        }

        public static string TiempoMinutos(double valor, int decimales = 2)
        {
            return $"{Numero(valor, decimales)} min";
        }

        public static string MasaKg(double valor, int decimales = 2)
        {
            return $"{Numero(valor, decimales)} kg";
        }

        public static string VelocidadSimulacion(double valor)
        {
            return $"{Numero(valor, 1)}x";
        }

        public static string TiempoDuracion(double segundos)
        {
            if (segundos > 922337203685 || segundos < -922337203685)
            {
                double dias = Math.Abs(segundos) / 86400;
                return $"{Numero(dias, 0)} días";
            }

            try
            {
                TimeSpan tiempo = TimeSpan.FromSeconds(segundos);
                if (tiempo.TotalDays >= 1)
                {
                    return $"{(int)tiempo.TotalDays}d {tiempo.Hours:D2}:{tiempo.Minutes:D2}:{tiempo.Seconds:D2}";
                }

                return $"{tiempo.Hours:D2}:{tiempo.Minutes:D2}:{tiempo.Seconds:D2}";
            }
            catch
            {
                return "Tiempo inválido";
            }
        }
    }
}
