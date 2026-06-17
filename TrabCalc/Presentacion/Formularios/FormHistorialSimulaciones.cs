using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrabCalc.Servicios.Exportacion;
using TrabCalc.Servicios.Historial;
using TrabCalc.Servicios.UI;

namespace TrabCalc
{
    public partial class FormHistorialSimulaciones : Form
    {
        private List<RegistroSimulacion> registros = new List<RegistroSimulacion>();
        private readonly FormSimuladorMovimiento simuladorMovimiento;
        private readonly FormSimuladorRecipientes simuladorRecipientes;

        public FormHistorialSimulaciones()
            : this(null, null)
        {
        }

        public FormHistorialSimulaciones(FormSimuladorMovimiento simuladorMovimiento)
            : this(simuladorMovimiento, null)
        {
        }

        public FormHistorialSimulaciones(FormSimuladorRecipientes simuladorRecipientes)
            : this(null, simuladorRecipientes)
        {
        }

        private FormHistorialSimulaciones(FormSimuladorMovimiento simuladorMovimiento, FormSimuladorRecipientes simuladorRecipientes)
        {
            this.simuladorMovimiento = simuladorMovimiento;
            this.simuladorRecipientes = simuladorRecipientes;
            InitializeComponent();
            TemaApp.AplicarFormularioDialogo(this, pnlContenedor);
            btnReabrir.Visible = PuedeReabrirDesdeContexto();
            cmbFiltro.SelectedIndex = 0;
            CargarRegistros();
        }

        private void CargarRegistros()
        {
            string filtro = cmbFiltro.SelectedItem?.ToString() ?? "Todos";
            registros = HistorialSimulaciones.Obtener(filtro);
            lstRegistros.DataSource = null;
            lstRegistros.DataSource = registros;

            bool tieneRegistros = registros.Any();
            btnCopiar.Enabled = tieneRegistros;
            btnExportar.Enabled = tieneRegistros;
            btnLimpiar.Enabled = tieneRegistros;
            ActualizarEstadoReabrir();

            if (tieneRegistros)
            {
                lstRegistros.SelectedIndex = 0;
            }
            else
            {
                txtDetalle.Text = HistorialSimulaciones.TieneRegistros()
                    ? "No hay simulaciones para el filtro seleccionado."
                    : "Aún no hay simulaciones registradas.";
            }
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarRegistros();
        }

        private void lstRegistros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRegistros.SelectedItem is RegistroSimulacion registro)
            {
                txtDetalle.Text =
                    $"{registro.Fecha:dd/MM/yyyy HH:mm:ss}" + Environment.NewLine +
                    $"{registro.Simulador} - {registro.Tipo}" + Environment.NewLine +
                    $"{registro.ResultadoCorto}" + Environment.NewLine +
                    Environment.NewLine +
                    registro.Resumen +
                    (registro.TieneParametros
                        ? Environment.NewLine + Environment.NewLine + "Este registro conserva parametros para reabrir la simulacion."
                        : "");
            }

            ActualizarEstadoReabrir();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (lstRegistros.SelectedItem is RegistroSimulacion)
            {
                Clipboard.SetText(txtDetalle.Text);
                DialogoApp.MostrarInformacion(this, "Registro copiado al portapapeles.", "Historial");
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (!registros.Any())
            {
                return;
            }

            bool exportado = ExportadorResultados.ExportarTextoOCsv(
                this,
                $"historial_simulaciones_{DateTime.Now:yyyyMMdd_HHmmss}",
                ConstruirTextoHistorial(),
                ConstruirCsvHistorial());

            if (exportado)
            {
                DialogoApp.MostrarInformacion(this, "Historial exportado correctamente.", "Historial");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            HistorialSimulaciones.Limpiar();
            CargarRegistros();
            DialogoApp.MostrarInformacion(this, "Historial limpiado.", "Historial");
        }

        private void btnReabrir_Click(object sender, EventArgs e)
        {
            if (!(lstRegistros.SelectedItem is RegistroSimulacion registro))
            {
                return;
            }

            bool reabierto = false;
            if (simuladorMovimiento != null && EsRegistroDe(registro, "Integrales"))
            {
                reabierto = simuladorMovimiento.ReabrirDesdeHistorial(registro);
            }
            else if (simuladorRecipientes != null && EsRegistroDe(registro, "Derivadas"))
            {
                reabierto = simuladorRecipientes.ReabrirDesdeHistorial(registro);
            }

            if (reabierto)
            {
                Close();
                return;
            }

            DialogoApp.MostrarAdvertencia(
                this,
                "Este registro no contiene suficientes parametros para reconstruir la simulacion. Los registros creados antes de esta version solo se pueden consultar como texto.",
                "Historial");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormHistorialSimulaciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                e.Handled = true;
                return;
            }

            if (e.Control && e.KeyCode == Keys.C && btnCopiar.Enabled)
            {
                btnCopiar.PerformClick();
                e.Handled = true;
            }

            if (e.Control && e.KeyCode == Keys.E && btnExportar.Enabled)
            {
                btnExportar.PerformClick();
                e.Handled = true;
            }

            if (e.Control && e.KeyCode == Keys.R && btnReabrir.Enabled)
            {
                btnReabrir.PerformClick();
                e.Handled = true;
            }
        }

        private bool PuedeReabrirDesdeContexto()
        {
            return simuladorMovimiento != null || simuladorRecipientes != null;
        }

        private bool PuedeReabrirRegistro(RegistroSimulacion registro)
        {
            if (!PuedeReabrirDesdeContexto() || registro == null || !registro.TieneParametros)
            {
                return false;
            }

            return (simuladorMovimiento != null && EsRegistroDe(registro, "Integrales"))
                || (simuladorRecipientes != null && EsRegistroDe(registro, "Derivadas"));
        }

        private void ActualizarEstadoReabrir()
        {
            if (btnReabrir == null)
            {
                return;
            }

            btnReabrir.Enabled = PuedeReabrirRegistro(lstRegistros.SelectedItem as RegistroSimulacion);
        }

        private bool EsRegistroDe(RegistroSimulacion registro, string simulador)
        {
            return registro != null && string.Equals(registro.Simulador, simulador, StringComparison.OrdinalIgnoreCase);
        }

        private string ConstruirTextoHistorial()
        {
            StringBuilder texto = new StringBuilder();
            string filtro = cmbFiltro.SelectedItem?.ToString() ?? "Todos";
            texto.AppendLine($"Historial de simulaciones - {filtro}");
            texto.AppendLine();

            foreach (RegistroSimulacion registro in registros)
            {
                texto.AppendLine($"{registro.Fecha:dd/MM/yyyy HH:mm:ss}");
                texto.AppendLine($"{registro.Simulador} - {registro.Tipo}");
                texto.AppendLine(registro.ResultadoCorto);
                texto.AppendLine(registro.Resumen);
                if (registro.TieneParametros)
                {
                    texto.AppendLine("Parametros guardados:");
                    texto.AppendLine(ConstruirTextoParametros(registro));
                }
                texto.AppendLine(new string('-', 60));
            }

            return texto.ToString();
        }

        private string ConstruirCsvHistorial()
        {
            StringBuilder csv = new StringBuilder();
            csv.AppendLine("fecha,simulador,tipo,resultado,resumen,parametros");

            foreach (RegistroSimulacion registro in registros)
            {
                csv.AppendLine(string.Join(",",
                    ExportadorResultados.CsvEscape(registro.Fecha.ToString("yyyy-MM-dd HH:mm:ss")),
                    ExportadorResultados.CsvEscape(registro.Simulador),
                    ExportadorResultados.CsvEscape(registro.Tipo),
                    ExportadorResultados.CsvEscape(registro.ResultadoCorto),
                    ExportadorResultados.CsvEscape(registro.Resumen),
                    ExportadorResultados.CsvEscape(ConstruirTextoParametros(registro))));
            }

            return csv.ToString();
        }

        private string ConstruirTextoParametros(RegistroSimulacion registro)
        {
            if (registro == null || !registro.TieneParametros)
            {
                return "";
            }

            return string.Join("; ", registro.Parametros.Select(p => $"{p.Key}={p.Value}"));
        }
    }
}
