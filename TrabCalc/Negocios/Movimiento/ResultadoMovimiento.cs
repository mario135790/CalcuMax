using System.Collections.Generic;

namespace TrabCalc.Negocios.Movimiento
{
    internal sealed class ResultadoMovimiento
    {
        public double VelocidadFinal { get; set; }
        public double DistanciaRecorrida { get; set; }
        public double TrabajoRealizadoKj { get; set; }
        public double AceleracionActual { get; set; }
        public List<MuestraMovimiento> Muestras { get; } = new List<MuestraMovimiento>();
    }
}
