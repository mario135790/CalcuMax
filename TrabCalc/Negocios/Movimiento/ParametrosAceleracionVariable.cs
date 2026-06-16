namespace TrabCalc.Negocios.Movimiento
{
    public sealed class ParametrosAceleracionVariable
    {
        public double VelocidadInicialKmh { get; set; }
        public double AceleracionMaxima { get; set; }
        public double AceleracionMinima { get; set; }
        public double TiempoTotal { get; set; }
        public double VelocidadMaximaKmh { get; set; }
        public double Masa { get; set; }
        public double KResistencia { get; set; }
    }
}
