using Guna.UI2.WinForms;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabCalc;

namespace TrabCalc
{
    public partial class FormSeleccionRecipiente : Form
    {
        int eleccion = 3;
        Panel panel;
        private bool isAnimating = false;
        private DialogResult resultado = DialogResult.None;

        public void PlaySound(string filePath)
        {
            ReproductorSonido.Reproducir(filePath);
        }

        public int Numero { get; private set; }
        public Figura3D Figura { get; private set; }
        public FormSeleccionRecipiente(Panel panel)
        {
            InitializeComponent();
            this.TransparencyKey = Color.DarkBlue;
            KeyPreview = true;
            KeyDown += FormSeleccionRecipiente_KeyDown;
            Mostrar();
            this.panel = panel;
        }

        private void Mostrar()
        {
            // Cambiar el texto de los labels dependiendo de la elección
            if (eleccion == 0)
            {
                label1.Visible = true;
                label1.Text = "Radio";
                textBox1.Visible = true;

                label2.Visible = false;
                textBox2.Visible = false;

                label3.Visible = true;
                label3.Text = "Altura";
                textBox3.Visible = true;
            }
            else if (eleccion == 1)
            {
                label1.Visible = false;
                textBox1.Visible = false;

                label2.Visible = true;
                label2.Text = "Radio";
                textBox2.Visible = true;

                label3.Visible = false;
                textBox3.Visible = false;
            }
            else if (eleccion == 2)
            {
                label1.Visible = true;
                label1.Text = "Largo";
                textBox1.Visible = true;

                label2.Visible = true;
                label2.Text = "Ancho";
                textBox2.Visible = true;

                label3.Visible = true;
                label3.Text = "Altura";
                textBox3.Visible = true;
            }
            else
            {
                label1.Visible = false;
                textBox1.Visible = false;

                label2.Visible = false;
                textBox2.Visible = false;

                label3.Visible = false;
                textBox3.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Numero = 0;
            if (!TryCrearFigura(out Figura3D figuraCreada))
            {
                return;
            }

            Figura = figuraCreada;
            Figura.Porcentaje = (double)nudPorcentaje.Value;
            resultado = DialogResult.OK;
            PlaySound("snd/Boton.wav");
            IniciarFadeOut();
        }

        private bool TryCrearFigura(out Figura3D figuraCreada)
        {
            figuraCreada = null;

            switch (eleccion)
            {
                case 0:
                    if (!TryLeerValor(textBox1, "Radio", out double radioCilindro)) return false;
                    if (!TryLeerValor(textBox3, "Altura", out double alturaCilindro)) return false;
                    figuraCreada = new Cilindro(radioCilindro, alturaCilindro, panel);
                    return true;

                case 1:
                    if (!TryLeerValor(textBox2, "Radio", out double radioEsfera)) return false;
                    figuraCreada = new Esfera(radioEsfera, panel);
                    return true;

                case 2:
                    if (!TryLeerValor(textBox1, "Largo", out double largo)) return false;
                    if (!TryLeerValor(textBox2, "Ancho", out double ancho)) return false;
                    if (!TryLeerValor(textBox3, "Altura", out double altura)) return false;
                    figuraCreada = new Cisterna(largo, ancho, altura, panel);
                    return true;
            }

            PlaySound("snd/Error.mp3");
            DialogoApp.MostrarAdvertencia(this, "Seleccione una figura.", "Campo requerido");
            return false;
        }

        private bool TryLeerValor(Guna2TextBox textBox, string nombre, out double valor)
        {
            if (!EntradaNumerica.TryLeerDouble(textBox.Text, out valor))
            {
                PlaySound("snd/Error.mp3");
                DialogoApp.MostrarAdvertencia(this, $"El campo {nombre} no puede estar vacío.", "Campo requerido");
                textBox.Focus();
                return false;
            }

            if (valor <= 0)
            {
                PlaySound("snd/Error.mp3");
                DialogoApp.MostrarAdvertencia(this, $"El campo {nombre} debe ser mayor que cero.", "Valor inválido");
                textBox.Focus();
                return false;
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Numero = 1;
            if (isAnimating) return;

            PlaySound("snd/Salir.wav");
            resultado = DialogResult.Cancel;
            IniciarFadeOut();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            PlaySound("snd/Cursor.wav");
        }

        private void FormSeleccionRecipiente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button2_Click(sender, EventArgs.Empty);
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.Enter && !e.Control)
            {
                button1_Click(sender, EventArgs.Empty);
                e.Handled = true;
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Guna2TextBox textBox = (Guna2TextBox)sender;

            e.Handled = true;
            if ((e.KeyChar == 'v' || e.KeyChar == 'V') && (Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == '.' && !textBox.Text.Contains(".") && textBox.Text.Any(char.IsDigit))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void FormSeleccionRecipiente_Load(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();

            isAnimating = true;
            this.Opacity = 0;
            timer1.Start();
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
                DialogResult = resultado == DialogResult.None ? DialogResult.Cancel : resultado;
                this.Close();
            }
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
            }
        }

        private void IniciarFadeOut()
        {
            timer1.Stop();
            timer2.Stop();
            isAnimating = true;
            timer2.Start();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (eleccion != 0)
            {
                PlaySound("snd/Check.mp3");
                eleccion = 0;
                Mostrar();
            }
            
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            if (eleccion != 1)
            {
                PlaySound("snd/Check.mp3");
                eleccion = 1;
                Mostrar();
            }
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            if (eleccion != 2)
            {
                PlaySound("snd/Check.mp3");
                eleccion = 2;
                Mostrar();
            }
        }
    }
}
