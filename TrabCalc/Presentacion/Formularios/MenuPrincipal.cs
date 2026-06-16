using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Windows.Forms;
using TrabCalc.Resources;

namespace TrabCalc
{
    public partial class MenuPrincipal : Form
    {
        int BtnPresionado;
        private bool isAnimating = false;
        private FondoAcuaticoAnimado fondoAcuatico;

        public void PlaySound(string filePath)
        {
            ReproductorSonido.Reproducir(filePath);
        }
        public MenuPrincipal()
        {
            InitializeComponent();
            AppManager.RegisterForm(this);
            this.TransparencyKey = Color.DarkBlue;
            fondoAcuatico = new FondoAcuaticoAnimado(guna2CustomGradientPanel1, pictureBox1);
        }
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();

            isAnimating = true;
            this.Opacity = 0;
            timer1.Start();

            if (!MusicManager.IsMuted && !MusicManager.IsPlaying)
            {
                MusicManager.PlayLoopingMenuMusic("snd/Menu.wav");
            }
            PlaySound("snd/Form.wav");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0)
            {
                this.Opacity += 0.04;
            }
            else
            {
                timer1.Stop();
                isAnimating = false;
                fondoAcuatico?.Iniciar();
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            PlaySound("snd/Cursor.wav");
        }

        private void btnSimulador_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;

            PlaySound("snd/Boton.wav");
            BtnPresionado = 0;
            IniciarFadeOut();
        }

        private void btnCreditos_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;

            PlaySound("snd/Boton.wav");
            BtnPresionado = 1;
            IniciarFadeOut();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;

            PlaySound("snd/Cerrar.mp3");
            BtnPresionado = 2;
            IniciarFadeOut();
        }
        private void IniciarFadeOut()
        {
            timer1.Stop();
            timer2.Stop();
            fondoAcuatico?.Detener();
            isAnimating = true;
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.05;
            }
            else
            {
                timer2.Stop();
                isAnimating = false;

                if (BtnPresionado == 0)
                {
                    AppManager.CambiarFormulario(this, new FormMenuSimuladores());
                }
                else if (BtnPresionado == 1)
                {
                    AppManager.CambiarFormulario(this, new Creditos());
                }
                else
                {
                    PlaySound("snd/Cerrar.mp3");
                    AppManager.ShutdownApplication();
                }
            }
        }

        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            if (isAnimating) return;

            if (MusicManager.IsMuted)
            {
                MusicManager.Mute(false);
                MusicManager.PlayLoopingMenuMusic("snd/Menu.wav");
            }
            else
            {
                MusicManager.Mute(true);
                MusicManager.StopLoopingMenuMusic();
            }
        }

        protected override void WndProc(ref Message m)
        {
            //Gracias san GPTín por los siguientes 2 renglones
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE)
            {
                AppManager.ShutdownApplication();
                return;
            }

            base.WndProc(ref m);
        }

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            fondoAcuatico?.Dispose();
            fondoAcuatico = null;

            if (!AppManager.EstaNavegando && !AppManager.EstaCerrando)
            {
                AppManager.ShutdownApplication();
            }
        }

    }
}
