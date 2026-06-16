namespace TrabCalc.Servicios
{
    internal static class ConversorUnidades
    {
        public static double MsAKmh(double velocidadMs)
        {
            return velocidadMs * 3.6;
        }

        public static double KmhAMs(double velocidadKmh)
        {
            return velocidadKmh / 3.6;
        }
    }
}
