namespace TrabCalc.Negocios.Movimiento
{
    internal sealed class PresetMovimiento<TParametros>
    {
        public string Nombre { get; set; }
        public TParametros Parametros { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
