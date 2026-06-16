using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace TrabCalc
{
    internal static class ReproductorSonido
    {
        private sealed class SonidoActivo
        {
            public WaveOutEvent Salida { get; set; }
            public AudioFileReader Archivo { get; set; }
        }

        private static readonly object candado = new object();
        private static readonly List<SonidoActivo> sonidosActivos = new List<SonidoActivo>();

        public static void Reproducir(string ruta)
        {
            string rutaFinal = RutasApp.Resolver(ruta);

            if (!File.Exists(rutaFinal))
            {
                Debug.WriteLine($"No se encontró el sonido: {rutaFinal}");
                return;
            }

            SonidoActivo sonido = null;

            try
            {
                sonido = new SonidoActivo
                {
                    Archivo = new AudioFileReader(rutaFinal),
                    Salida = new WaveOutEvent()
                };

                lock (candado)
                {
                    sonidosActivos.Add(sonido);
                }

                sonido.Salida.Init(sonido.Archivo);
                sonido.Salida.PlaybackStopped += (sender, e) => Liberar(sonido);
                sonido.Salida.Play();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al reproducir sonido: {ex.Message}");
                if (sonido != null)
                {
                    Liberar(sonido);
                }
            }
        }

        public static void DetenerTodos()
        {
            List<SonidoActivo> copia;

            lock (candado)
            {
                copia = new List<SonidoActivo>(sonidosActivos);
                sonidosActivos.Clear();
            }

            foreach (var sonido in copia)
            {
                try
                {
                    sonido.Salida?.Stop();
                    sonido.Salida?.Dispose();
                    sonido.Archivo?.Dispose();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error al detener sonido: {ex.Message}");
                }
            }
        }

        private static void Liberar(SonidoActivo sonido)
        {
            lock (candado)
            {
                sonidosActivos.Remove(sonido);
            }

            sonido.Salida?.Dispose();
            sonido.Archivo?.Dispose();
        }
    }
}
