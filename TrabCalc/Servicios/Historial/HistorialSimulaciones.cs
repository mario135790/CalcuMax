using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

namespace TrabCalc.Servicios.Historial
{
    public static class HistorialSimulaciones
    {
        private const int LimiteRegistros = 50;
        private static readonly List<RegistroSimulacion> registros = new List<RegistroSimulacion>();
        private static readonly string rutaHistorial = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "SimuladorCalculoITLP",
            "historial_simulaciones.json");
        private static readonly string rutaHistorialAnterior = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "TrabCalc",
            "historial_simulaciones.json");

        static HistorialSimulaciones()
        {
            Cargar();
        }

        public static void Agregar(string simulador, string tipo, string resultadoCorto, string resumen)
        {
            Agregar(simulador, tipo, resultadoCorto, resumen, null);
        }

        public static void Agregar(
            string simulador,
            string tipo,
            string resultadoCorto,
            string resumen,
            Dictionary<string, string> parametros)
        {
            registros.Insert(0, new RegistroSimulacion
            {
                Fecha = DateTime.Now,
                Simulador = simulador,
                Tipo = tipo,
                ResultadoCorto = resultadoCorto,
                Resumen = resumen,
                Parametros = parametros
            });

            if (registros.Count > LimiteRegistros)
            {
                registros.RemoveRange(LimiteRegistros, registros.Count - LimiteRegistros);
            }

            Guardar();
        }

        public static List<RegistroSimulacion> Obtener()
        {
            return new List<RegistroSimulacion>(registros);
        }

        public static List<RegistroSimulacion> Obtener(string simulador)
        {
            if (string.IsNullOrWhiteSpace(simulador) || simulador == "Todos")
            {
                return Obtener();
            }

            return registros
                .Where(r => string.Equals(r.Simulador, simulador, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public static void Limpiar()
        {
            registros.Clear();
            Guardar();
        }

        public static bool TieneRegistros()
        {
            return registros.Count > 0;
        }

        private static void Cargar()
        {
            try
            {
                MigrarHistorialAnterior();

                if (!File.Exists(rutaHistorial))
                {
                    return;
                }

                string json = File.ReadAllText(rutaHistorial);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                List<RegistroSimulacion> cargados = serializer.Deserialize<List<RegistroSimulacion>>(json);
                if (cargados == null) return;

                registros.Clear();
                registros.AddRange(cargados
                    .Where(r => r != null)
                    .OrderByDescending(r => r.Fecha)
                    .Take(LimiteRegistros));
            }
            catch
            {
                registros.Clear();
            }
        }

        private static void MigrarHistorialAnterior()
        {
            if (File.Exists(rutaHistorial) || !File.Exists(rutaHistorialAnterior))
            {
                return;
            }

            string carpeta = Path.GetDirectoryName(rutaHistorial);
            if (!Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
            }

            File.Copy(rutaHistorialAnterior, rutaHistorial);
        }

        private static void Guardar()
        {
            try
            {
                string carpeta = Path.GetDirectoryName(rutaHistorial);
                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                }

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                File.WriteAllText(rutaHistorial, serializer.Serialize(registros));
            }
            catch
            {
            }
        }
    }
}
