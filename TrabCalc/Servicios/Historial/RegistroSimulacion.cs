using System;
using System.Collections.Generic;

namespace TrabCalc.Servicios.Historial
{
    public class RegistroSimulacion
    {
        public DateTime Fecha { get; set; }
        public string Simulador { get; set; }
        public string Tipo { get; set; }
        public string Resumen { get; set; }
        public string ResultadoCorto { get; set; }
        public Dictionary<string, string> Parametros { get; set; }

        public bool TieneParametros
        {
            get { return Parametros != null && Parametros.Count > 0; }
        }

        public override string ToString()
        {
            return $"{Fecha:HH:mm:ss} - {Simulador}: {Tipo}";
        }
    }
}
