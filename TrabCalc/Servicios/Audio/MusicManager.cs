using NAudio.Wave;
using System.Diagnostics;
using System.IO;

namespace TrabCalc.Resources
{
    public static class MusicManager
    {
        private static WaveOutEvent player;
        private static AudioFileReader file;
        private static bool isMuted;
        private static bool isPlaying;
        private static readonly object candado = new object();

        public static bool IsMuted { get => isMuted; set => isMuted = value; }
        public static bool IsPlaying { get => isPlaying; set => isPlaying = value; }

        public static void PlayLoopingMenuMusic(string path)
        {
            lock (candado)
            {
                if (isPlaying || isMuted)
                    return;

                string rutaFinal = RutasApp.Resolver(path);
                if (!File.Exists(rutaFinal))
                {
                    Debug.WriteLine($"No se encontró la música: {rutaFinal}");
                    return;
                }

                file = new AudioFileReader(rutaFinal);
                player = new WaveOutEvent();
                player.Init(file);
                player.PlaybackStopped += Player_PlaybackStopped;
                player.Play();
                isPlaying = true;
            }
        }

        private static void Player_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            lock (candado)
            {
                if (!isPlaying || isMuted || player == null || file == null)
                    return;

                file.Position = 0;
                player.Play();
            }
        }

        public static void StopLoopingMenuMusic()
        {
            WaveOutEvent salida;
            AudioFileReader archivo;

            lock (candado)
            {
                isPlaying = false;
                salida = player;
                archivo = file;
                player = null;
                file = null;
            }

            salida?.Stop();
            salida?.Dispose();
            archivo?.Dispose();
        }

        public static void Stop()
        {
            StopLoopingMenuMusic();
        }

        public static void Mute(bool mute)
        {
            lock (candado)
            {
                isMuted = mute;
                if (file != null)
                    file.Volume = isMuted ? 0.0f : 1.0f;
            }

            if (mute)
            {
                StopLoopingMenuMusic();
            }
        }

        public static void ToggleMute()
        {
            Mute(!IsMuted);
        }

        public static void ForceStop()
        {
            try
            {
                isMuted = true;
                StopLoopingMenuMusic();
            }
            catch
            {
            }
        }
    }
}
