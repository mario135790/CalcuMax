using System.Collections.Generic;

namespace TrabCalc.Negocios.Movimiento
{
    internal static class PresetsMovimiento
    {
        public static List<PresetMovimiento<ParametrosAceleracionConstante>> ObtenerConstantes()
        {
            return new List<PresetMovimiento<ParametrosAceleracionConstante>>
            {
                new PresetMovimiento<ParametrosAceleracionConstante>
                {
                    Nombre = "Default",
                    Parametros = new ParametrosAceleracionConstante { VelocidadInicialKmh = 0, Aceleracion = 2, TiempoTotal = 10, VelocidadMaximaKmh = 90, Masa = 250, KResistencia = 0.4 }
                },
                new PresetMovimiento<ParametrosAceleracionConstante>
                {
                    Nombre = "Vehículo ligero",
                    Parametros = new ParametrosAceleracionConstante { VelocidadInicialKmh = 0, Aceleracion = 3.5, TiempoTotal = 8, VelocidadMaximaKmh = 120, Masa = 1200, KResistencia = 0.35 }
                },
                new PresetMovimiento<ParametrosAceleracionConstante>
                {
                    Nombre = "Camión",
                    Parametros = new ParametrosAceleracionConstante { VelocidadInicialKmh = 0, Aceleracion = 1.2, TiempoTotal = 14, VelocidadMaximaKmh = 70, Masa = 9000, KResistencia = 0.9 }
                },
                new PresetMovimiento<ParametrosAceleracionConstante>
                {
                    Nombre = "Baja resistencia",
                    Parametros = new ParametrosAceleracionConstante { VelocidadInicialKmh = 0, Aceleracion = 2, TiempoTotal = 10, VelocidadMaximaKmh = 90, Masa = 250, KResistencia = 0.08 }
                }
            };
        }

        public static List<PresetMovimiento<ParametrosAceleracionVariable>> ObtenerVariables()
        {
            return new List<PresetMovimiento<ParametrosAceleracionVariable>>
            {
                new PresetMovimiento<ParametrosAceleracionVariable>
                {
                    Nombre = "Default",
                    Parametros = new ParametrosAceleracionVariable { VelocidadInicialKmh = 0, AceleracionMaxima = 4, AceleracionMinima = 2, TiempoTotal = 10, VelocidadMaximaKmh = 150, Masa = 250, KResistencia = 0.4 }
                },
                new PresetMovimiento<ParametrosAceleracionVariable>
                {
                    Nombre = "Oscilación suave",
                    Parametros = new ParametrosAceleracionVariable { VelocidadInicialKmh = 0, AceleracionMaxima = 3, AceleracionMinima = 1.8, TiempoTotal = 12, VelocidadMaximaKmh = 140, Masa = 900, KResistencia = 0.3 }
                },
                new PresetMovimiento<ParametrosAceleracionVariable>
                {
                    Nombre = "Arranque fuerte",
                    Parametros = new ParametrosAceleracionVariable { VelocidadInicialKmh = 0, AceleracionMaxima = 6, AceleracionMinima = 1, TiempoTotal = 8, VelocidadMaximaKmh = 180, Masa = 1200, KResistencia = 0.45 }
                },
                new PresetMovimiento<ParametrosAceleracionVariable>
                {
                    Nombre = "Baja resistencia",
                    Parametros = new ParametrosAceleracionVariable { VelocidadInicialKmh = 0, AceleracionMaxima = 4, AceleracionMinima = 2, TiempoTotal = 10, VelocidadMaximaKmh = 150, Masa = 250, KResistencia = 0.08 }
                }
            };
        }
    }
}
