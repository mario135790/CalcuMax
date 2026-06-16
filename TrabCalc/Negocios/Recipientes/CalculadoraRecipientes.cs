using System;

namespace TrabCalc.Negocios.Recipientes
{
    internal static class CalculadoraRecipientes
    {
        public const int OperacionDrenado = 0;
        public const int OperacionLlenado = 1;

        public static double CalcularCaudalPorSegundo(double caudalPorMinuto)
        {
            return caudalPorMinuto / 60.0;
        }

        public static double CalcularTiempo(double volumenActual, double volumenRestante, double caudalPorSegundo, int operacion)
        {
            if (caudalPorSegundo <= 0)
            {
                return 0;
            }

            switch (operacion)
            {
                case OperacionLlenado:
                    return Math.Max(0, volumenRestante) / caudalPorSegundo;
                case OperacionDrenado:
                    return Math.Max(0, volumenActual) / caudalPorSegundo;
                default:
                    return 0;
            }
        }

        public static double ObtenerVolumenFinal(double volumenTotal, int operacion)
        {
            return operacion == OperacionDrenado ? 0 : volumenTotal;
        }

        public static string ObtenerNombreOperacion(int operacion)
        {
            return operacion == OperacionDrenado ? "Drenado" : "Llenado";
        }

        public static ResultadoPasoRecipiente CalcularPaso(
            double volumenActual,
            double volumenTotal,
            double caudalPorSegundo,
            double tiempoRestante,
            double intervaloSegundos,
            double velocidadSimulacion,
            int operacion)
        {
            double deltaTiempo = Math.Min(tiempoRestante, intervaloSegundos * velocidadSimulacion);
            if (deltaTiempo <= 0 || caudalPorSegundo <= 0 || volumenTotal <= 0)
            {
                return new ResultadoPasoRecipiente
                {
                    DeltaTiempo = 0,
                    VolumenActual = volumenActual,
                    VolumenRestante = Math.Max(0, volumenTotal - volumenActual),
                    Completado = true
                };
            }

            double cambioVolumen = caudalPorSegundo * deltaTiempo;
            double nuevoVolumen = operacion == OperacionDrenado
                ? Math.Max(0, volumenActual - cambioVolumen)
                : Math.Min(volumenTotal, volumenActual + cambioVolumen);

            double volumenRestante = Math.Max(0, volumenTotal - nuevoVolumen);
            bool completado = operacion == OperacionDrenado ? nuevoVolumen <= 0 : volumenRestante <= 0;

            return new ResultadoPasoRecipiente
            {
                DeltaTiempo = deltaTiempo,
                VolumenActual = nuevoVolumen,
                VolumenRestante = volumenRestante,
                Completado = completado
            };
        }
    }
}
