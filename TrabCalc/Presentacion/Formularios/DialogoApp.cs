using System.Windows.Forms;

namespace TrabCalc
{
    internal enum TipoDialogoApp
    {
        Informacion,
        Advertencia,
        Error
    }

    internal static class DialogoApp
    {
        public static void MostrarInformacion(IWin32Window owner, string mensaje, string titulo = "Información")
        {
            Mostrar(owner, titulo, mensaje, TipoDialogoApp.Informacion, "Aceptar");
        }

        public static void MostrarAdvertencia(IWin32Window owner, string mensaje, string titulo = "Aviso")
        {
            Mostrar(owner, titulo, mensaje, TipoDialogoApp.Advertencia, "Aceptar");
        }

        public static void MostrarError(IWin32Window owner, string mensaje, string titulo = "Error")
        {
            Mostrar(owner, titulo, mensaje, TipoDialogoApp.Error, "Aceptar");
        }

        public static bool Confirmar(IWin32Window owner, string titulo, string mensaje, string textoAceptar, string textoCancelar, TipoDialogoApp tipo = TipoDialogoApp.Advertencia)
        {
            return Mostrar(owner, titulo, mensaje, tipo, textoAceptar, textoCancelar) == DialogResult.OK;
        }

        private static DialogResult Mostrar(IWin32Window owner, string titulo, string mensaje, TipoDialogoApp tipo, string textoAceptar, string textoCancelar = null)
        {
            using (FormDialogoApp dialogo = new FormDialogoApp(titulo, mensaje, textoAceptar, textoCancelar, tipo))
            {
                return dialogo.ShowDialog(owner);
            }
        }
    }
}
