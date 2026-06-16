using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabCalc
{
    public partial class Creditos : Form
    {
        private bool isAnimating = false;
        public Creditos()
        {
            InitializeComponent();
            this.TransparencyKey = Color.DarkBlue;
        }
        public void PlaySound(string filePath)
        {
            ReproductorSonido.Reproducir(filePath);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0)
            {
                this.Opacity += 0.05;
            }
            else
            {
                timer1.Stop();
                isAnimating = false;
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            PlaySound("snd/Cursor.wav");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;

            PlaySound("snd/Salir.wav");
            IniciarFadeOut();
        }

        private void IniciarFadeOut()
        {
            timer1.Stop();
            timer2.Stop();
            isAnimating = true;
            timer2.Start();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.07;
            }
            else
            {
                timer2.Stop();
                isAnimating = false;
                AppManager.CambiarFormulario(this, new MenuPrincipal());
            }
        }

        private void Creditos_Load(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();

            isAnimating = true;
            this.Opacity = 0;
            timer1.Start();
            PlaySound("snd/Form.wav");
        }
    }

}
