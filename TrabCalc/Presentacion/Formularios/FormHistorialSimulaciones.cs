using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrabCalc.Servicios.Exportacion;
using TrabCalc.Servicios.Historial;

namespace TrabCalc
{
    public partial class FormHistorialSimulaciones : Form
    {
        private List<RegistroSimulacion> registros = new List<RegistroSimulacion>();

        public FormHistorialSimulaciones()
        {
            InitializeComponent();
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
                    registro.Resumen;
            }
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
                texto.AppendLine(new string('-', 60));
            }

            return texto.ToString();
        }

        private string ConstruirCsvHistorial()
        {
            StringBuilder csv = new StringBuilder();
            csv.AppendLine("fecha,simulador,tipo,resultado,resumen");

            foreach (RegistroSimulacion registro in registros)
            {
                csv.AppendLine(string.Join(",",
                    ExportadorResultados.CsvEscape(registro.Fecha.ToString("yyyy-MM-dd HH:mm:ss")),
                    ExportadorResultados.CsvEscape(registro.Simulador),
                    ExportadorResultados.CsvEscape(registro.Tipo),
                    ExportadorResultados.CsvEscape(registro.ResultadoCorto),
                    ExportadorResultados.CsvEscape(registro.Resumen)));
            }

            return csv.ToString();
        }
    }
}
