namespace TrabCalc.Negocios.Movimiento
{
    internal sealed class ParametrosMovimiento
    {
        public double Masa { get; set; }
        public double KResistencia { get; set; }
        public double VelocidadInicial { get; set; }
        public double AceleracionMaxima { get; set; }
        public double AceleracionMinima { get; set; }
        public double TiempoActual { get; set; }
        public double VelocidadMaximaKmh { get; set; }
        public double DeltaT { get; set; } = 0.05;
    }
}
