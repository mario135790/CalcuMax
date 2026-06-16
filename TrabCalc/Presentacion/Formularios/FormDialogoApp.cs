using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrabCalc
{
    internal partial class FormDialogoApp : Form
    {
        public FormDialogoApp(string titulo, string mensaje, string textoAceptar, string textoCancelar, TipoDialogoApp tipo)
        {
            InitializeComponent();
            lblTitulo.Text = titulo;
            lblMensaje.Text = mensaje;
            btnAceptar.Text = textoAceptar;
            ConfigurarTipo(tipo);
            ConfigurarCancelacion(textoCancelar);
            AjustarAlto(mensaje);
        }

        private void ConfigurarTipo(TipoDialogoApp tipo)
        {
            if (tipo == TipoDialogoApp.Error)
            {
                pnlContenedor.FillColor3 = Color.LightCoral;
                pnlContenedor.FillColor4 = Color.FromArgb(130, 52, 70);
                return;
            }

            if (tipo == TipoDialogoApp.Advertencia)
            {
                pnlContenedor.FillColor3 = Color.FromArgb(238, 180, 86);
                pnlContenedor.FillColor4 = Color.FromArgb(94, 116, 134);
            }
        }

        private void ConfigurarCancelacion(string textoCancelar)
        {
            if (string.IsNullOrWhiteSpace(textoCancelar))
            {
                btnCancelar.Visible = false;
                btnAceptar.Location = new Point(336, btnAceptar.Location.Y);
                CancelButton = btnAceptar;
                return;
            }

            btnCancelar.Text = textoCancelar;
        }

        private void AjustarAlto(string mensaje)
        {
            Size areaTexto = new Size(lblMensaje.Width, 1000);
            Size textoMedido = TextRenderer.MeasureText(mensaje ?? "", lblMensaje.Font, areaTexto, TextFormatFlags.WordBreak);
            int altoNecesario = Math.Max(lblMensaje.Height, textoMedido.Height + 10);
            int altoMaximo = Math.Min(440, Screen.FromControl(this).WorkingArea.Height - 90);
            int altoExtra = Math.Max(0, altoNecesario - lblMensaje.Height);
            altoExtra = Math.Min(altoExtra, Math.Max(0, altoMaximo - Height));
            if (altoExtra <= 0) return;

            Height += altoExtra;
            pnlContenedor.Height += altoExtra;
            lblMensaje.Height += altoExtra;
            btnAceptar.Top += altoExtra;
            btnCancelar.Top += altoExtra;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormDialogoApp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = btnCancelar.Visible ? DialogResult.Cancel : DialogResult.OK;
                Close();
            }
        }
    }
}
