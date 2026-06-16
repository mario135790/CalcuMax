namespace TrabCalc.Negocios.Recipientes
{
    public sealed class ParametrosRecipiente
    {
        public string NombreFigura { get; set; }
        public int Operacion { get; set; }
        public double CaudalPorMinuto { get; set; }
        public double VolumenTotal { get; set; }
        public double VolumenInicial { get; set; }
        public double VolumenFinal { get; set; }
        public double TiempoTotal { get; set; }

        public double CaudalPorSegundo => CalculadoraRecipientes.CalcularCaudalPorSegundo(CaudalPorMinuto);
        public double VolumenCambiado => System.Math.Abs(VolumenFinal - VolumenInicial);
        public string NombreOperacion => CalculadoraRecipientes.ObtenerNombreOperacion(Operacion);
    }
}
