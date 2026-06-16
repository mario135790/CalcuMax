using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TrabCalc.Negocios.Movimiento;
using TrabCalc.Servicios;
using TrabCalc.Servicios.UI;

namespace TrabCalc
{
    public partial class FormParametrosAceleracionConstante : Form
    {
        private bool isAnimating = false;
        private FormSimuladorMovimiento formMovimiento;
        private readonly ToolTip ayuda = new ToolTip();
        bool eleccionCorrecta = false;

        public FormParametrosAceleracionConstante(FormSimuladorMovimiento mainForm)
        {
            InitializeComponent();
            formMovimiento = mainForm;
            this.TransparencyKey = Color.DarkBlue;
            KeyPreview = true;
            KeyDown += FormParametrosAceleracionConstante_KeyDown;
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
            CargarParametros(formMovimiento.ObtenerParametros());
        }

        private void ConfigurarPresets()
        {
            cmbPresets.DataSource = PresetsMovimiento.ObtenerConstantes();
        }

        private void ConfigurarTooltips()
        {
            ayuda.SetToolTip(nudVelInicial, "Velocidad inicial del vehículo en km/h.");
            ayuda.SetToolTip(nudAceleracion, "Aceleración constante en m/s².");
            ayuda.SetToolTip(nudTiempoTotal, "Duración total de la simulación en segundos.");
            ayuda.SetToolTip(nudVelMaxima, "Límite de velocidad en km/h. La simulación no lo supera.");
            ayuda.SetToolTip(nudMasa, "Masa del vehículo en kg.");
            ayuda.SetToolTip(nudResAire, "Coeficiente k de resistencia del aire. Usa 0 para ignorarla.");
            ayuda.SetToolTip(cmbPresets, "Carga combinaciones rápidas de parámetros.");
            ayuda.SetToolTip(btnAplicarPreset, "Copia el preset seleccionado en los campos.");
        }

        private void FormParametrosAceleracionConstante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button2_Click(sender, EventArgs.Empty);
                e.Handled = true;
                return;
            }

            if (e.Control && e.KeyCode == Keys.Enter)
            {
                BtnAplicar_Click(sender, EventArgs.Empty);
                e.Handled = true;
            }
        }

        private void CargarParametros(ParametrosAceleracionConstante parametros)
        {
            nudVelInicial.Value = AjustarDecimal(parametros.VelocidadInicialKmh, nudVelInicial.Minimum, nudVelInicial.Maximum);
            nudAceleracion.Value = AjustarDecimal(parametros.Aceleracion, nudAceleracion.Minimum, nudAceleracion.Maximum);
            nudTiempoTotal.Value = AjustarDecimal(parametros.TiempoTotal, nudTiempoTotal.Minimum, nudTiempoTotal.Maximum);
            nudVelMaxima.Value = AjustarDecimal(parametros.VelocidadMaximaKmh, nudVelMaxima.Minimum, nudVelMaxima.Maximum);
            nudMasa.Value = AjustarDecimal(parametros.Masa, nudMasa.Minimum, nudMasa.Maximum);
            nudResAire.Value = AjustarDecimal(parametros.KResistencia, nudResAire.Minimum, nudResAire.Maximum);
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
            if (cmbPresets.SelectedItem is PresetMovimiento<ParametrosAceleracionConstante> preset)
            {
                CargarParametros(preset.Parametros);
            }
        }

        private ParametrosAceleracionConstante LeerParametros()
        {
            return new ParametrosAceleracionConstante
            {
                VelocidadInicialKmh = (double)nudVelInicial.Value,
                Aceleracion = (double)nudAceleracion.Value,
                TiempoTotal = (double)nudTiempoTotal.Value,
                VelocidadMaximaKmh = (double)nudVelMaxima.Value,
                Masa = (double)nudMasa.Value,
                KResistencia = (double)nudResAire.Value
            };
        }

        private void BtnAplicar_Click(object sender, EventArgs e)
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

    // Validaciones de coherencia física
    if (nudVelMaxima.Value < nudVelInicial.Value)
    {
        DialogoApp.MostrarError(this, "La velocidad máxima no puede ser menor que la velocidad inicial.");
        nudVelMaxima.Focus();
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

    // Validaciones de coherencia cinemática
    double velInicial = (double)nudVelInicial.Value;
    double PvelInicial = ConversorUnidades.KmhAMs((double)nudVelInicial.Value);
    double acel = (double)nudAceleracion.Value;
    double tiempo = (double)nudTiempoTotal.Value;
    double velMaxima = (double)nudVelMaxima.Value;
    double PvelMaxima = ConversorUnidades.KmhAMs((double)nudVelMaxima.Value);

    // Verificar si es posible alcanzar la velocidad máxima con la aceleración dada
    double velFinalCalculada = PvelInicial + (acel * tiempo);
    if (acel > 0 && velFinalCalculada > PvelMaxima * 1.1) // 10% de tolerancia
    {
        if (!DialogoAdvertenciaSimulacion.Mostrar(this, $"La velocidad final estimada sería {FormatoUnidades.VelocidadKmh(velFinalCalculada * 3.6)}, mayor que el límite de {FormatoUnidades.VelocidadKmh((double)nudVelMaxima.Value)}."))
        {
            return;
        }
    }

    // Validación de estabilidad numérica
    if (nudResAire.Value > 0 && (float)nudMasa.Value / (float)nudResAire.Value < 0.001)
    {
        if (!DialogoAdvertenciaSimulacion.Mostrar(this, "La masa es muy baja para esa resistencia; el cálculo puede volverse inestable."))
        {
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

    ParametrosAceleracionConstante parametros = LeerParametros();
    if (!MostrarAdvertenciasInteligentes(parametros))
    {
        return;
    }

    try
    {
        formMovimiento.AplicarParametros(parametros);
        eleccionCorrecta = true;
        DialogResult = DialogResult.OK;
        this.Close();
    }
    catch (Exception ex)
    {
        DialogoApp.MostrarError(this, $"Error al aplicar los parámetros: {ex.Message}");
    }
}

        private bool MostrarAdvertenciasInteligentes(ParametrosAceleracionConstante parametros)
        {
            List<string> avisos = new List<string>();

            if (Math.Abs(parametros.KResistencia) < 0.000001)
            {
                avisos.Add("Sin resistencia del aire, el trabajo no incluye pérdidas.");
            }

            double velocidadMaximaMs = ConversorUnidades.KmhAMs(parametros.VelocidadMaximaKmh);
            double velocidadInicialMs = ConversorUnidades.KmhAMs(parametros.VelocidadInicialKmh);
            if (parametros.Aceleracion > 0 && velocidadMaximaMs > velocidadInicialMs)
            {
                double tiempoHastaLimite = (velocidadMaximaMs - velocidadInicialMs) / parametros.Aceleracion;
                if (tiempoHastaLimite <= parametros.TiempoTotal)
                {
                    avisos.Add($"La velocidad máxima se alcanza cerca de {FormatoUnidades.TiempoSegundos(tiempoHastaLimite)}.");
                }
            }

            if (avisos.Count > 0)
            {
                return DialogoAdvertenciaSimulacion.Mostrar(this, string.Join(Environment.NewLine, avisos));
            }

            return true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;

            PlaySound("snd/Salir.wav");
            IniciarFadeOut(); 
            eleccionCorrecta = false;
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
        private void IniciarFadeOut()
        {
            timer1.Stop();
            timer2.Stop();
            isAnimating = true;
            timer2.Start();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            PlaySound("snd/Cursor.wav");
        }

        private void FormParametrosAceleracionConstante_Load(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();

            isAnimating = true;
            this.Opacity = 0;
            timer1.Start();
        }

        private void FormParametrosAceleracionConstante_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isAnimating) return;
            if (eleccionCorrecta) return;
            DialogResult = DialogResult.Cancel;
        }
    }
}

