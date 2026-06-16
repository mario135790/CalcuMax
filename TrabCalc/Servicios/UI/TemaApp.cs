using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace TrabCalc.Servicios.UI
{
    internal static class TemaApp
    {
        public static readonly Color FondoFormulario = Color.FromArgb(10, 28, 76);
        public static readonly Color BordePrincipal = Color.FromArgb(27, 52, 120);
        public static readonly Color AzulAccion = Color.FromArgb(34, 116, 224);
        public static readonly Color AzulAccionClaro = Color.FromArgb(227, 242, 255);
        public static readonly Color VerdeAccion = Color.FromArgb(45, 162, 102);
        public static readonly Color RojoAccion = Color.FromArgb(198, 80, 80);
        public static readonly Color TextoOscuro = Color.FromArgb(18, 28, 48);
        public static readonly Color Superficie = Color.FromArgb(246, 249, 253);

        public static void AplicarFormularioPrincipal(Form form, Control contenedorRaiz, Size minimo)
        {
            form.AutoScaleMode = AutoScaleMode.Dpi;
            form.BackColor = FondoFormulario;
            form.MinimumSize = minimo;
            form.ControlBox = false;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.FormBorderStyle = FormBorderStyle.None;

            if (contenedorRaiz != null)
            {
                contenedorRaiz.Dock = DockStyle.Fill;
                AplicarTema(contenedorRaiz);
            }
        }

        public static void AplicarFormularioDialogo(Form form, Control contenedorRaiz)
        {
            form.AutoScaleMode = AutoScaleMode.Dpi;
            form.BackColor = FondoFormulario;

            if (contenedorRaiz != null)
            {
                contenedorRaiz.Dock = DockStyle.Fill;
                AplicarTema(contenedorRaiz);
            }
        }

        public static void AplicarTema(Control control)
        {
            foreach (Control hijo in control.Controls)
            {
                AplicarTema(hijo);
            }

            if (control is Label label)
            {
                label.ForeColor = TextoOscuro;
                return;
            }

            if (control is GroupBox groupBox)
            {
                groupBox.ForeColor = TextoOscuro;
                return;
            }

            if (control is Guna2CustomGradientPanel panel)
            {
                panel.BorderColor = BordePrincipal;
                panel.BorderThickness = 2;
                return;
            }

            if (control is Guna2GradientButton boton)
            {
                boton.Cursor = Cursors.Hand;
                boton.ForeColor = TextoOscuro;

                if (boton.BorderColor == Color.Firebrick)
                {
                    boton.BorderColor = RojoAccion;
                    boton.FillColor2 = Color.FromArgb(235, 132, 132);
                }
                else if (boton.BorderColor == Color.SeaGreen)
                {
                    boton.BorderColor = VerdeAccion;
                    boton.FillColor2 = VerdeAccion;
                }
                else
                {
                    boton.BorderColor = AzulAccion;
                    boton.FillColor2 = AzulAccion;
                }

                boton.FillColor = Color.WhiteSmoke;
                return;
            }

            if (control is Guna2ComboBox combo)
            {
                combo.BorderColor = BordePrincipal;
                combo.FillColor = Color.White;
                combo.ForeColor = TextoOscuro;
                return;
            }

            if (control is Guna2TextBox textBox)
            {
                textBox.BorderColor = BordePrincipal;
                textBox.FillColor = Color.White;
                textBox.ForeColor = TextoOscuro;
                return;
            }

            if (control is Guna2NumericUpDown numero)
            {
                numero.BorderColor = BordePrincipal;
                numero.FillColor = Color.White;
                numero.ForeColor = TextoOscuro;
                return;
            }

            if (control is Guna2TrackBar trackBar)
            {
                trackBar.FillColor = Color.FromArgb(190, 202, 220);
                trackBar.ThumbColor = AzulAccion;
            }
        }
    }
}
