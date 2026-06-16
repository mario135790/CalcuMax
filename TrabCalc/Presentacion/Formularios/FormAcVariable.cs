using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabCalc.Negocios.Movimiento;
using TrabCalc.Servicios;
using TrabCalc.Servicios.UI;

namespace TrabCalc
{
    public partial class FormAcVariable : Form
    {
        private bool isAnimating = false;
        private FormSimuladorMovimiento formMovimiento;
        private readonly ToolTip ayuda = new ToolTip();
        bool eleccionCorrecta = false;
        public FormAcVariable(FormSimuladorMovimiento mainForm)
        {
            InitializeComponent();
            formMovimiento = mainForm;
            this.TransparencyKey = Color.DarkBlue;
            KeyPreview = true;
            KeyDown += FormAcVariable_KeyDown;
            ConfigurarPresets();
            ConfigurarTooltips();
            TemaApp.AplicarFormularioDialogo(this, guna2CustomGradientPanel1);
            CargarValoresActuales();
        }

        public void PlaySound(string filePath)
        {
            ReproductorSonido.Reproducir(filePath);
        }

        private void CargarValoresActuales()
        {
            CargarParametros(formMovimiento.ObtenerParametrosVarFormulario());
        }

        private void ConfigurarPresets()
        {
            cmbPresets.DataSource = PresetsMovimiento.ObtenerVariables();
        }

        private void ConfigurarTooltips()
        {
            ayuda.SetToolTip(nudVelInicial, "Velocidad inicial del vehículo en km/h.");
            ayuda.SetToolTip(nudAceleracion, "Aceleración máxima de la función variable.");
            ayuda.SetToolTip(nudAceleracionMin, "Aceleración mínima de la función variable.");
            ayuda.SetToolTip(nudTiempoTotal, "Duración total de la simulación en segundos.");
            ayuda.SetToolTip(nudVelMaxima, "Límite de velocidad en km/h. La simulación no lo supera.");
            ayuda.SetToolTip(nudMasa, "Masa del vehículo en kg.");
            ayuda.SetToolTip(nudResAire, "Coeficiente k de resistencia del aire. Usa 0 para ignorarla.");
            ayuda.SetToolTip(cmbPresets, "Carga combinaciones rápidas de parámetros.");
            ayuda.SetToolTip(btnAplicarPreset, "Copia el preset seleccionado en los campos.");
        }

        private void FormAcVariable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button2_Click(sender, EventArgs.Empty);
                e.Handled = true;
                return;
            }

            if (e.Control && e.KeyCode == Keys.Enter)
            {
                btnAplicar_Click(sender, EventArgs.Empty);
                e.Handled = true;
            }
        }

        private void CargarParametros(ParametrosAceleracionVariable parametros)
        {
            nudVelInicial.Value = AjustarDecimal(parametros.VelocidadInicialKmh, nudVelInicial.Minimum, nudVelInicial.Maximum);
            nudAceleracion.Value = AjustarDecimal(parametros.AceleracionMaxima, nudAceleracion.Minimum, nudAceleracion.Maximum);
            nudTiempoTotal.Value = AjustarDecimal(parametros.TiempoTotal, nudTiempoTotal.Minimum, nudTiempoTotal.Maximum);
            nudVelMaxima.Value = AjustarDecimal(parametros.VelocidadMaximaKmh, nudVelMaxima.Minimum, nudVelMaxima.Maximum);
            nudMasa.Value = AjustarDecimal(parametros.Masa, nudMasa.Minimum, nudMasa.Maximum);
            nudResAire.Value = AjustarDecimal(parametros.KResistencia, nudResAire.Minimum, nudResAire.Maximum);
            nudAceleracionMin.Value = AjustarDecimal(parametros.AceleracionMinima, nudAceleracionMin.Minimum, nudAceleracionMin.Maximum);
        }

        private decimal AjustarDecimal(double valor, decimal minimo, decimal maximo)
        {
            decimal decimalValor = (decimal)valor;
            if (decimalValor < minimo) return minimo;
            if (decimalValor > maximo) return maximo;
            return decimalValor;
        }

        private void btnAplicarPreset_Click(object sender, EventArgs e)
        {
            if (cmbPresets.SelectedItem is PresetMovimiento<ParametrosAceleracionVariable> preset)
            {
                CargarParametros(preset.Parametros);
            }
        }

        private ParametrosAceleracionVariable LeerParametros()
        {
            return new ParametrosAceleracionVariable
            {
                VelocidadInicialKmh = (double)nudVelInicial.Value,
                AceleracionMaxima = (double)nudAceleracion.Value,
                AceleracionMinima = (double)nudAceleracionMin.Value,
                TiempoTotal = (double)nudTiempoTotal.Value,
                VelocidadMaximaKmh = (double)nudVelMaxima.Value,
                Masa = (double)nudMasa.Value,
                KResistencia = (double)nudResAire.Value
            };
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas de rangos
            if (nudMasa.Value <= 0)
            {
                DialogoApp.MostrarError(this, "La masa debe ser mayor que cero.");
                nudMasa.Focus();
                return;
            }

            if (nudTiempoTotal.Value <= 0)
            {
                DialogoApp.MostrarError(this, "El tiempo total debe ser mayor que cero.");
                nudTiempoTotal.Focus();
                return;
            }

            if (nudVelInicial.Value < 0)
            {
                DialogoApp.MostrarError(this, "La velocidad inicial no puede ser negativa.");
                nudVelInicial.Focus();
                return;
            }

            if (nudAceleracion.Value < 0)
            {
                DialogoApp.MostrarError(this, "La aceleración no puede ser negativa.");
                nudAceleracion.Focus();
                return;
            }

            if (nudVelMaxima.Value < 0)
            {
                DialogoApp.MostrarError(this, "La velocidad máxima no puede ser negativa.");
                nudVelMaxima.Focus();
                return;
            }

            if (nudResAire.Value < 0)
            {
                DialogoApp.MostrarError(this, "La resistencia del aire no puede ser negativa.");
                nudResAire.Focus();
                return;
            }

            if (nudAceleracionMin.Value < 0)
            {
                DialogoApp.MostrarError(this, "La aceleración mínima no puede ser negativa.");
                nudAceleracionMin.Focus();
                return;
            }

            // Validaciones de coherencia física
            if (nudVelMaxima.Value < nudVelInicial.Value)
            {
                DialogoApp.MostrarError(this, "La velocidad máxima no puede ser menor que la velocidad inicial.");
                nudVelMaxima.Focus();
                return;
            }

            if (nudAceleracionMin.Value > nudAceleracion.Value)
            {
                DialogoApp.MostrarError(this, "La aceleración mínima no puede ser mayor que la aceleración máxima.");
                nudAceleracionMin.Focus();
                return;
            }

            // Validaciones de límites extremos
            if (nudMasa.Value > 1000000) // 1 tonelada
            {
                DialogoApp.MostrarError(this, "La masa es demasiado grande para la simulación (máximo 1,000,000 kg).");
                nudMasa.Focus();
                return;
            }

            if (nudVelMaxima.Value > 1080000000) // velocidad de la luz en km/h
            {
                DialogoApp.MostrarError(this, "La velocidad máxima no puede exceder la velocidad de la luz.");
                nudVelMaxima.Focus();
                return;
            }

            if (nudVelInicial.Value > 1080000000)
            {
                DialogoApp.MostrarError(this, "La velocidad inicial no puede exceder la velocidad de la luz.");
                nudVelInicial.Focus();
                return;
            }

            if (nudAceleracion.Value > 1000000) // aceleración extrema
            {
                DialogoApp.MostrarError(this, "La aceleración es demasiado alta para la simulación (máximo 1,000,000 m/s²).");
                nudAceleracion.Focus();
                return;
            }

            if (nudTiempoTotal.Value > 86400) // 24 horas
            {
                DialogoApp.MostrarError(this, "El tiempo total es demasiado largo para la simulación (máximo 86,400 segundos).");
                nudTiempoTotal.Focus();
                return;
            }

            if (nudResAire.Value > 1000)
            {
                DialogoApp.MostrarError(this, "El coeficiente de resistencia del aire es demasiado alto (máximo 1000).");
                nudResAire.Focus();
                return;
            }

            // Validación de estabilidad numérica
            if (nudResAire.Value > 0 && ((float)nudMasa.Value / (float)nudResAire.Value) < 0.001)
            {
                if (!DialogoAdvertenciaSimulacion.Mostrar(this, "La masa es muy baja para esa resistencia; el cálculo puede volverse inestable."))
                {
                    nudResAire.Focus();
                    return;
                }
            }

            // Validación de valores decimales extremos
            if ((float)nudMasa.Value < 0.000001)
            {
                DialogoApp.MostrarError(this, "La masa es demasiado pequeña para cálculos precisos (mínimo 0.000001 kg).");
                nudMasa.Focus();
                return;
            }

            if ((float)nudTiempoTotal.Value < 0.001)
            {
                DialogoApp.MostrarError(this, "El tiempo total es demasiado pequeño para cálculos precisos (mínimo 0.001 s).");
                nudTiempoTotal.Focus();
                return;
            }

            ParametrosAceleracionVariable parametros = LeerParametros();
            if (!MostrarAdvertenciasInteligentes(parametros))
            {
                return;
            }

            try
            {
                formMovimiento.AplicarParametrosVar(parametros);
                eleccionCorrecta = true;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                DialogoApp.MostrarError(this, $"Error al aplicar los parámetros: {ex.Message}");
            }
        }

        private bool MostrarAdvertenciasInteligentes(ParametrosAceleracionVariable parametros)
        {
            List<string> avisos = new List<string>();

            if (Math.Abs(parametros.AceleracionMaxima - parametros.AceleracionMinima) < 0.000001)
            {
                avisos.Add("La aceleración mínima y máxima son iguales; será aceleración constante.");
            }

            if (Math.Abs(parametros.KResistencia) < 0.000001)
            {
                avisos.Add("Sin resistencia del aire, el trabajo no incluye pérdidas.");
            }

            double velocidadInicialMs = ConversorUnidades.KmhAMs(parametros.VelocidadInicialKmh);
            double velocidadMaximaMs = ConversorUnidades.KmhAMs(parametros.VelocidadMaximaKmh);
            if (velocidadMaximaMs > velocidadInicialMs && parametros.AceleracionMaxima > 0)
            {
                double tiempoEstimado = (velocidadMaximaMs - velocidadInicialMs) / parametros.AceleracionMaxima;
                if (tiempoEstimado <= parametros.TiempoTotal)
                {
                    avisos.Add($"La velocidad máxima podría alcanzarse cerca de {FormatoUnidades.TiempoSegundos(tiempoEstimado)}.");
                }
            }

            if (avisos.Count > 0)
            {
                return DialogoAdvertenciaSimulacion.Mostrar(this, string.Join(Environment.NewLine, avisos));
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;

            PlaySound("snd/Salir.wav");
            IniciarFadeOut();
            eleccionCorrecta = false;
        }
        private void IniciarFadeOut()
        {
            timer1.Stop();
            timer2.Stop();
            isAnimating = true;
            timer2.Start();
        }

        private void FormAcVariable_Load(object sender, EventArgs e)
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
                DialogResult = DialogResult.Cancel;
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

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            PlaySound("snd/Cursor.wav");
        }

        private void FormAcVariable_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isAnimating) return;
            if (eleccionCorrecta) return;
            DialogResult = DialogResult.Cancel;
        }
    }
}
