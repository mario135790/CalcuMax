using System;
using System.Drawing;
using System.Windows.Forms;
using TrabCalc.Resources;

namespace TrabCalc
{
    public partial class FormMenuSimuladores : Form
    {
        private int opcionSeleccionada;
        private bool isAnimating;
        private FondoAcuaticoAnimado fondoAcuatico;

        public FormMenuSimuladores()
        {
            InitializeComponent();
            AppManager.RegisterForm(this);
            TransparencyKey = Color.DarkBlue;
            fondoAcuatico = new FondoAcuaticoAnimado(pnlPrincipal, pictureBoxBurbujas);
        }

        private void FormMenuSimuladores_Load(object sender, EventArgs e)
        {
            timerEntrada.Stop();
            timerSalida.Stop();

            isAnimating = true;
            Opacity = 0;
            timerEntrada.Start();

            if (!MusicManager.IsMuted && !MusicManager.IsPlaying)
            {
                MusicManager.PlayLoopingMenuMusic("snd/Menu.wav");
            }

            PlaySound("snd/Form.wav");
        }

        private void timerEntrada_Tick(object sender, EventArgs e)
        {
            if (Opacity < 1.0)
            {
                Opacity += 0.04;
            }
            else
            {
                timerEntrada.Stop();
                isAnimating = false;
                fondoAcuatico?.Iniciar();
            }
        }

        private void timerSalida_Tick(object sender, EventArgs e)
        {
            if (Opacity > 0)
            {
                Opacity -= 0.05;
                return;
            }

            timerSalida.Stop();
            isAnimating = false;

            if (opcionSeleccionada == 1)
            {
                AppManager.CambiarFormulario(this, new FormSimuladorMovimiento());
            }
            else if (opcionSeleccionada == 2)
            {
                AppManager.CambiarFormulario(this, new FormSimuladorRecipientes());
            }
            else
            {
                AppManager.CambiarFormulario(this, new MenuPrincipal());
            }
        }

        private void btnMovimiento_Click(object sender, EventArgs e)
        {
            SeleccionarOpcion(1);
        }

        private void btnBombaAgua_Click(object sender, EventArgs e)
        {
            SeleccionarOpcion(2);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            SeleccionarOpcion(0);
        }

        private void btnFundamento_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;

            PlaySound("snd/Boton.wav");
            using (FormFundamentoMatematico fundamento = new FormFundamentoMatematico())
            {
                fundamento.ShowDialog(this);
            }
        }

        private void SeleccionarOpcion(int opcion)
        {
            if (isAnimating) return;

            opcionSeleccionada = opcion;
            PlaySound("snd/Boton.wav");
            IniciarFadeOut();
        }

        private void IniciarFadeOut()
        {
            timerEntrada.Stop();
            timerSalida.Stop();
            fondoAcuatico?.Detener();
            isAnimating = true;
            timerSalida.Start();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            PlaySound("snd/Cursor.wav");
        }

        private void PlaySound(string filePath)
        {
            ReproductorSonido.Reproducir(filePath);
        }

        private void FormMenuSimuladores_FormClosing(object sender, FormClosingEventArgs e)
        {
            fondoAcuatico?.Dispose();
            fondoAcuatico = null;

            if (!AppManager.EstaNavegando && !AppManager.EstaCerrando)
            {
                AppManager.ShutdownApplication();
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE)
            {
                AppManager.ShutdownApplication();
                return;
            }

            base.WndProc(ref m);
        }
    }
}
