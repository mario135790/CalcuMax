using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace TrabCalc
{
    public partial class PantInicio : Form
    {
        public void PlaySound(string filePath)
        {
            ReproductorSonido.Reproducir(filePath);
        }
        public PantInicio()
        {
            InitializeComponent();
            this.TransparencyKey = Color.DarkBlue;
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0)
            {
                this.Opacity += 0.02;
            }
            else
            {
                timer1.Stop();
                await Task.Delay(1500);
                PlaySound("snd/Version.wav");
                pbVersion.Visible = true;
            }
        }

        private void PantInicio_Load(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();

            this.Opacity = 0;
            timer1.Start();
            timer3.Start();
            PlaySound("snd/Inicio.wav");
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
                AppManager.CambiarFormulario(this, new MenuPrincipal());
            }
        }

        private async void timer3_Tick(object sender, EventArgs e)
        {
            Random brap = new Random();

            if (progressBar.Value < progressBar.Maximum)
            {
                progressBar.Value += brap.Next(1, 6);
            }
            else
            {
                timer3.Stop();
                await Task.Delay(2000);
                IniciarFadeOut();
            }
        }

        private void IniciarFadeOut()
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer2.Start();
        }
    }
}
