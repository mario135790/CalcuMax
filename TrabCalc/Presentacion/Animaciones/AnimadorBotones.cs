using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrabCalc
{
    internal sealed class AnimadorBotones : IDisposable
    {
        private readonly Control raiz;
        private readonly Timer timer = new Timer();
        private readonly Dictionary<Guna2GradientButton, EstadoBoton> botones = new Dictionary<Guna2GradientButton, EstadoBoton>();
        private readonly HashSet<Control> controlesObservados = new HashSet<Control>();
        private bool disposeRealizado;

        private AnimadorBotones(Control raiz)
        {
            this.raiz = raiz;
            timer.Interval = 15;
            timer.Tick += Timer_Tick;

            RegistrarControl(raiz);
        }

        public static AnimadorBotones Instalar(Control raiz)
        {
            if (raiz == null || raiz.IsDisposed)
            {
                return null;
            }

            return new AnimadorBotones(raiz);
        }

        public void Dispose()
        {
            if (disposeRealizado) return;
            disposeRealizado = true;

            timer.Stop();
            timer.Tick -= Timer_Tick;
            timer.Dispose();

            foreach (Control control in controlesObservados)
            {
                if (control != null && !control.IsDisposed)
                {
                    control.ControlAdded -= Control_ControlAdded;
                }
            }

            foreach (EstadoBoton estado in botones.Values)
            {
                DesconectarBoton(estado);
            }

            botones.Clear();
            controlesObservados.Clear();
        }

        private void RegistrarControl(Control control)
        {
            if (control == null || control.IsDisposed || controlesObservados.Contains(control))
            {
                return;
            }

            controlesObservados.Add(control);
            control.ControlAdded += Control_ControlAdded;

            Guna2GradientButton boton = control as Guna2GradientButton;
            if (boton != null)
            {
                RegistrarBoton(boton);
            }

            foreach (Control hijo in control.Controls)
            {
                RegistrarControl(hijo);
            }
        }

        private void RegistrarBoton(Guna2GradientButton boton)
        {
            if (boton == null || boton.IsDisposed || botones.ContainsKey(boton))
            {
                return;
            }

            EstadoBoton estado = new EstadoBoton(boton);
            botones.Add(boton, estado);

            boton.Cursor = Cursors.Hand;
            boton.MouseEnter += Boton_MouseEnter;
            boton.MouseLeave += Boton_MouseLeave;
            boton.MouseDown += Boton_MouseDown;
            boton.MouseUp += Boton_MouseUp;
            boton.EnabledChanged += Boton_EnabledChanged;
            boton.Disposed += Boton_Disposed;
        }

        private void DesconectarBoton(EstadoBoton estado)
        {
            Guna2GradientButton boton = estado.Boton;
            if (boton == null || boton.IsDisposed)
            {
                return;
            }

            boton.MouseEnter -= Boton_MouseEnter;
            boton.MouseLeave -= Boton_MouseLeave;
            boton.MouseDown -= Boton_MouseDown;
            boton.MouseUp -= Boton_MouseUp;
            boton.EnabledChanged -= Boton_EnabledChanged;
            boton.Disposed -= Boton_Disposed;
            estado.Restaurar();
        }

        private void Control_ControlAdded(object sender, ControlEventArgs e)
        {
            RegistrarControl(e.Control);
        }

        private void Boton_MouseEnter(object sender, EventArgs e)
        {
            EstadoBoton estado = ObtenerEstado(sender);
            if (estado == null || !estado.Boton.Enabled) return;

            estado.RefrescarBaseSiEstaQuieto();
            estado.HoverObjetivo = 1f;
            IniciarTimer();
        }

        private void Boton_MouseLeave(object sender, EventArgs e)
        {
            EstadoBoton estado = ObtenerEstado(sender);
            if (estado == null) return;

            estado.HoverObjetivo = 0f;
            estado.Presionado = false;
            IniciarTimer();
        }

        private void Boton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            EstadoBoton estado = ObtenerEstado(sender);
            if (estado == null || !estado.Boton.Enabled) return;

            estado.Presionado = true;
            IniciarTimer();
        }

        private void Boton_MouseUp(object sender, MouseEventArgs e)
        {
            EstadoBoton estado = ObtenerEstado(sender);
            if (estado == null) return;

            estado.Presionado = false;
            IniciarTimer();
        }

        private void Boton_EnabledChanged(object sender, EventArgs e)
        {
            EstadoBoton estado = ObtenerEstado(sender);
            if (estado == null) return;

            if (!estado.Boton.Enabled)
            {
                estado.HoverObjetivo = 0f;
                estado.Presionado = false;
            }
            else
            {
                estado.RefrescarBaseSiEstaQuieto();
            }

            IniciarTimer();
        }

        private void Boton_Disposed(object sender, EventArgs e)
        {
            Guna2GradientButton boton = sender as Guna2GradientButton;
            if (boton == null || !botones.ContainsKey(boton))
            {
                return;
            }

            botones.Remove(boton);
        }

        private EstadoBoton ObtenerEstado(object sender)
        {
            Guna2GradientButton boton = sender as Guna2GradientButton;
            if (boton == null || !botones.ContainsKey(boton))
            {
                return null;
            }

            return botones[boton];
        }

        private void IniciarTimer()
        {
            if (!disposeRealizado && !timer.Enabled)
            {
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            bool hayMovimiento = false;
            List<Guna2GradientButton> botonesEliminados = null;

            foreach (KeyValuePair<Guna2GradientButton, EstadoBoton> par in botones)
            {
                EstadoBoton estado = par.Value;
                Guna2GradientButton boton = estado.Boton;

                if (boton == null || boton.IsDisposed)
                {
                    if (botonesEliminados == null) botonesEliminados = new List<Guna2GradientButton>();
                    botonesEliminados.Add(par.Key);
                    continue;
                }

                float objetivoHover = boton.Enabled ? estado.HoverObjetivo : 0f;
                float objetivoPresionado = boton.Enabled && estado.Presionado ? 1f : 0f;
                bool cambio = Avanzar(ref estado.Hover, objetivoHover, 0.24f);
                cambio |= Avanzar(ref estado.Presion, objetivoPresionado, 0.35f);

                if (cambio || estado.Hover > 0f || estado.Presion > 0f)
                {
                    estado.Aplicar();
                }

                if (Math.Abs(estado.Hover - objetivoHover) > 0.001f || Math.Abs(estado.Presion - objetivoPresionado) > 0.001f)
                {
                    hayMovimiento = true;
                }
            }

            if (botonesEliminados != null)
            {
                foreach (Guna2GradientButton boton in botonesEliminados)
                {
                    botones.Remove(boton);
                }
            }

            if (!hayMovimiento)
            {
                timer.Stop();
            }
        }

        private static bool Avanzar(ref float valor, float objetivo, float suavizado)
        {
            if (Math.Abs(valor - objetivo) < 0.01f)
            {
                if (Math.Abs(valor - objetivo) < 0.0001f)
                {
                    return false;
                }

                valor = objetivo;
                return true;
            }

            valor += (objetivo - valor) * suavizado;
            return true;
        }

        private sealed class EstadoBoton
        {
            public readonly Guna2GradientButton Boton;
            public float Hover;
            public float HoverObjetivo;
            public float Presion;
            public bool Presionado;

            private Point ubicacionBase;
            private Cursor cursorBase;
            private Color fillBase;
            private Color fill2Base;
            private Color bordeBase;
            private Color hoverFillOriginal;
            private Color hoverFill2Original;
            private Color hoverBordeOriginal;
            private Color hoverFillBase;
            private Color hoverFill2Base;
            private Color hoverBordeBase;

            public EstadoBoton(Guna2GradientButton boton)
            {
                Boton = boton;
                CapturarBase();
            }

            public void RefrescarBaseSiEstaQuieto()
            {
                if (Hover <= 0.001f && Presion <= 0.001f)
                {
                    CapturarBase();
                }
            }

            public void Aplicar()
            {
                float intensidad = Limitar(Hover);
                float presion = Limitar(Presion);
                int desplazamientoY = (int)Math.Round(-3 * intensidad + 2 * presion);

                Boton.Location = new Point(ubicacionBase.X, ubicacionBase.Y + desplazamientoY);
                Boton.FillColor = Oscurecer(Aclarar(fillBase, 0.16f * intensidad), 0.08f * presion);
                Boton.FillColor2 = Oscurecer(Aclarar(fill2Base, 0.12f * intensidad), 0.08f * presion);
                Boton.BorderColor = Aclarar(bordeBase, 0.18f * intensidad);
                Boton.HoverState.FillColor = Aclarar(hoverFillBase, 0.10f * intensidad);
                Boton.HoverState.FillColor2 = Aclarar(hoverFill2Base, 0.08f * intensidad);
                Boton.HoverState.BorderColor = Aclarar(hoverBordeBase, 0.14f * intensidad);
            }

            public void Restaurar()
            {
                Boton.Location = ubicacionBase;
                Boton.Cursor = cursorBase;
                Boton.FillColor = fillBase;
                Boton.FillColor2 = fill2Base;
                Boton.BorderColor = bordeBase;
                Boton.HoverState.FillColor = hoverFillOriginal;
                Boton.HoverState.FillColor2 = hoverFill2Original;
                Boton.HoverState.BorderColor = hoverBordeOriginal;
            }

            private void CapturarBase()
            {
                ubicacionBase = Boton.Location;
                cursorBase = Boton.Cursor;
                fillBase = Normalizar(Boton.FillColor, Color.LightGray);
                fill2Base = Normalizar(Boton.FillColor2, fillBase);
                bordeBase = Normalizar(Boton.BorderColor, Color.RoyalBlue);
                hoverFillOriginal = Boton.HoverState.FillColor;
                hoverFill2Original = Boton.HoverState.FillColor2;
                hoverBordeOriginal = Boton.HoverState.BorderColor;
                hoverFillBase = Normalizar(hoverFillOriginal, fillBase);
                hoverFill2Base = Normalizar(hoverFill2Original, fill2Base);
                hoverBordeBase = Normalizar(hoverBordeOriginal, bordeBase);
            }
        }

        private static Color Normalizar(Color color, Color respaldo)
        {
            return color.IsEmpty ? respaldo : color;
        }

        private static Color Aclarar(Color color, float intensidad)
        {
            return Mezclar(color, Color.White, Limitar(intensidad));
        }

        private static Color Oscurecer(Color color, float intensidad)
        {
            return Mezclar(color, Color.Black, Limitar(intensidad));
        }

        private static Color Mezclar(Color origen, Color destino, float t)
        {
            t = Limitar(t);
            int a = origen.A + (int)((destino.A - origen.A) * t);
            int r = origen.R + (int)((destino.R - origen.R) * t);
            int g = origen.G + (int)((destino.G - origen.G) * t);
            int b = origen.B + (int)((destino.B - origen.B) * t);
            return Color.FromArgb(a, r, g, b);
        }

        private static float Limitar(float valor)
        {
            if (valor < 0f) return 0f;
            if (valor > 1f) return 1f;
            return valor;
        }
    }
}
