using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace TrabCalc
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ApplicationExit += (s, e) => AppManager.LiberarRecursos();
            AppDomain.CurrentDomain.ProcessExit += (s, e) => AppManager.LiberarRecursos();
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string assemblyName = new AssemblyName(args.Name).Name + ".dll";
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "libs", assemblyName);
                if (File.Exists(path))
                {
                    return Assembly.LoadFrom(path);
                }
                return null;
            };

            Application.Run(AppManager.CrearContexto(new PantInicio()));
        }
    }
}
