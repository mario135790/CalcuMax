using System;
using System.IO;

namespace TrabCalc
{
    internal static class RutasApp
    {
        public static string Resolver(string ruta)
        {
            if (string.IsNullOrWhiteSpace(ruta) || Path.IsPathRooted(ruta))
            {
                return ruta;
            }

            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ruta);
        }
    }
}
