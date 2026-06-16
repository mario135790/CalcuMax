using System.Windows.Forms;

namespace TrabCalc
{
    internal static class DialogoAdvertenciaSimulacion
    {
        public static bool Mostrar(IWin32Window owner, string mensaje)
        {
            return DialogoApp.Confirmar(owner, "Aviso de simulación", mensaje, "Continuar de todos modos", "Volver");
        }
    }
}
