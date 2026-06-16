using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabCalc
{
    public class ProcedimientoHelper
    {
        public static void MostrarProcedimiento(Form parent, bool esAceleracionConstante,
            double velocidadInicial, double aceleracion, double masa, double tiempo,
            double velocidadFinal, double distancia, double trabajo,
            double aceleracionMin = 0, double velocidadMaxima = 0, double kResistencia = 0)
        {
            var parametros = new Dictionary<string, double>
            {
                ["velocidadInicial"] = velocidadInicial,
                ["aceleracion"] = aceleracion,
                ["masa"] = masa,
                ["tiempo"] = tiempo,
                ["velocidadFinal"] = velocidadFinal,
                ["distancia"] = distancia,
                ["trabajo"] = trabajo,
                ["kResistencia"] = kResistencia
            };

            if (!esAceleracionConstante)
            {
                parametros["aceleracionMin"] = aceleracionMin;
            }

            if (velocidadMaxima > 0)
            {
                parametros["velocidadMaxima"] = velocidadMaxima;
            }

            var formProcedimiento = new FormProcedimiento(esAceleracionConstante, parametros);
            formProcedimiento.ShowDialog(parent);
        }
    }
}
