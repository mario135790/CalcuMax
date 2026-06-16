namespace TrabCalc.Negocios.Recipientes
{
    internal sealed class ResultadoPasoRecipiente
    {
        public double DeltaTiempo { get; set; }
        public double VolumenActual { get; set; }
        public double VolumenRestante { get; set; }
        public bool Completado { get; set; }
    }
}
