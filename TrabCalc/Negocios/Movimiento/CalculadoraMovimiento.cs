using System;
using TrabCalc.Servicios;

namespace TrabCalc.Negocios.Movimiento
{
    internal static class CalculadoraMovimiento
    {
        public static ResultadoMovimiento CalcularAceleracionConstante(ParametrosMovimiento parametros)
        {
            double velocidadMaximaMs = ConversorUnidades.KmhAMs(parametros.VelocidadMaximaKmh);
            double tiempoMaxVelocidad = ObtenerTiempoHastaVelocidadMaxima(parametros.VelocidadInicial, parametros.AceleracionMaxima, velocidadMaximaMs);
            double tiempoAceleracion = Math.Min(parametros.TiempoActual, tiempoMaxVelocidad);
            double velocidadFinal;
            double distanciaRecorrida;

            if (parametros.TiempoActual <= tiempoMaxVelocidad)
            {
                velocidadFinal = parametros.VelocidadInicial + parametros.AceleracionMaxima * parametros.TiempoActual;
                distanciaRecorrida = parametros.VelocidadInicial * parametros.TiempoActual +
                    0.5 * parametros.AceleracionMaxima * parametros.TiempoActual * parametros.TiempoActual;
            }
            else
            {
                double distanciaAceleracion = parametros.VelocidadInicial * tiempoMaxVelocidad +
                    0.5 * parametros.AceleracionMaxima * tiempoMaxVelocidad * tiempoMaxVelocidad;
                double tiempoConstante = parametros.TiempoActual - tiempoMaxVelocidad;
                double distanciaConstante = velocidadMaximaMs * tiempoConstante;
                velocidadFinal = velocidadMaximaMs;
                distanciaRecorrida = distanciaAceleracion + distanciaConstante;
            }

            if (velocidadMaximaMs > 0)
            {
                velocidadFinal = Math.Min(velocidadFinal, velocidadMaximaMs);
            }

            return new ResultadoMovimiento
            {
                VelocidadFinal = velocidadFinal,
                DistanciaRecorrida = distanciaRecorrida,
                TrabajoRealizadoKj = CalcularTrabajoConstante(parametros, tiempoAceleracion, tiempoMaxVelocidad, velocidadMaximaMs) / 1000.0,
                AceleracionActual = ObtenerAceleracionActualConstante(parametros, velocidadFinal)
            };
        }

        public static ResultadoMovimiento CalcularAceleracionVariable(ParametrosMovimiento parametros)
        {
            ResultadoMovimiento resultado = new ResultadoMovimiento();
            double trabajoAcumulado = 0;
            double velocidadTemp = parametros.VelocidadInicial;
            double distanciaIntegrada = 0;
            double velocidadMaximaMs = ConversorUnidades.KmhAMs(parametros.VelocidadMaximaKmh);
            double t = 0;
            double ultimaAceleracionEfectiva = 0;
            int contador = 0;
            int cadaN = 3;

            while (t < parametros.TiempoActual)
            {
                double paso = Math.Min(parametros.DeltaT, parametros.TiempoActual - t);
                double aInicio = CalcularAceleracionVariable(t, parametros.AceleracionMaxima, parametros.AceleracionMinima);
                double aFin = CalcularAceleracionVariable(t + paso, parametros.AceleracionMaxima, parametros.AceleracionMinima);
                double incrementoVelocidad = ((aInicio + aFin) / 2.0) * paso;
                double nuevaVelocidad = velocidadTemp + incrementoVelocidad;

                if (velocidadMaximaMs > 0)
                {
                    nuevaVelocidad = Math.Min(nuevaVelocidad, velocidadMaximaMs);
                }

                double aceleracionEfectiva = paso > 0 ? (nuevaVelocidad - velocidadTemp) / paso : 0;
                ultimaAceleracionEfectiva = aceleracionEfectiva;
                double velocidadMedia = (velocidadTemp + nuevaVelocidad) / 2.0;
                double incrementoDistancia = velocidadMedia * paso;
                distanciaIntegrada += incrementoDistancia;

                double fuerzaMotor = parametros.Masa * aceleracionEfectiva + parametros.KResistencia * velocidadMedia * velocidadMedia;
                trabajoAcumulado += fuerzaMotor * incrementoDistancia;

                if (contador % cadaN == 0)
                {
                    resultado.Muestras.Add(new MuestraMovimiento
                    {
                        Tiempo = t,
                        Aceleracion = aceleracionEfectiva,
                        VelocidadKmh = ConversorUnidades.MsAKmh(velocidadTemp),
                        TrabajoKj = trabajoAcumulado / 1000.0
                    });
                }

                velocidadTemp = nuevaVelocidad;
                t += paso;
                contador++;
            }

            resultado.Muestras.Add(new MuestraMovimiento
            {
                Tiempo = parametros.TiempoActual,
                Aceleracion = ultimaAceleracionEfectiva,
                VelocidadKmh = ConversorUnidades.MsAKmh(velocidadTemp),
                TrabajoKj = trabajoAcumulado / 1000.0
            });

            resultado.VelocidadFinal = velocidadTemp;
            resultado.DistanciaRecorrida = distanciaIntegrada;
            resultado.TrabajoRealizadoKj = trabajoAcumulado / 1000.0;
            resultado.AceleracionActual = ultimaAceleracionEfectiva;

            return resultado;
        }

        public static double CalcularAceleracionVariable(double tiempo, double aceleracionMaxima, double aceleracionMinima)
        {
            return (aceleracionMaxima + aceleracionMinima) / 2.0 +
                (aceleracionMaxima - aceleracionMinima) / 2.0 * Math.Sin(tiempo);
        }

        public static double ObtenerAceleracionActualConstante(ParametrosMovimiento parametros, double velocidadFinal)
        {
            double velocidadMaximaMs = ConversorUnidades.KmhAMs(parametros.VelocidadMaximaKmh);
            return velocidadMaximaMs > 0 && velocidadFinal >= velocidadMaximaMs ? 0 : parametros.AceleracionMaxima;
        }

        public static double ObtenerTiempoHastaVelocidadMaxima(double velocidadInicial, double aceleracion, double velocidadMaximaMs)
        {
            if (velocidadMaximaMs <= 0)
            {
                return double.PositiveInfinity;
            }

            if (velocidadInicial >= velocidadMaximaMs)
            {
                return 0;
            }

            if (aceleracion <= 0)
            {
                return double.PositiveInfinity;
            }

            return (velocidadMaximaMs - velocidadInicial) / aceleracion;
        }

        private static double CalcularTrabajoConstante(ParametrosMovimiento parametros, double tiempoAceleracion, double tiempoMaxVelocidad, double velocidadMaximaMs)
        {
            double trabajoMotor = 0;

            for (double t = 0; t < tiempoAceleracion; t += parametros.DeltaT)
            {
                double paso = Math.Min(parametros.DeltaT, tiempoAceleracion - t);
                double vInicio = parametros.VelocidadInicial + parametros.AceleracionMaxima * t;
                double vFin = parametros.VelocidadInicial + parametros.AceleracionMaxima * (t + paso);
                double potenciaInicio = (parametros.Masa * parametros.AceleracionMaxima + parametros.KResistencia * vInicio * vInicio) * vInicio;
                double potenciaFin = (parametros.Masa * parametros.AceleracionMaxima + parametros.KResistencia * vFin * vFin) * vFin;
                trabajoMotor += ((potenciaInicio + potenciaFin) / 2.0) * paso;
            }

            if (parametros.TiempoActual > tiempoMaxVelocidad && velocidadMaximaMs > 0)
            {
                double tiempoConstante = parametros.TiempoActual - tiempoMaxVelocidad;
                double fuerzaConstante = parametros.KResistencia * velocidadMaximaMs * velocidadMaximaMs;
                double distanciaConstante = velocidadMaximaMs * tiempoConstante;
                trabajoMotor += fuerzaConstante * distanciaConstante;
            }

            return trabajoMotor;
        }
    }
}
