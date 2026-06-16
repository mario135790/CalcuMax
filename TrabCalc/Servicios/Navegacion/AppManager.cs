using System.Collections.Generic;
using System;
using System.Windows.Forms;
using TrabCalc.Resources;

namespace TrabCalc
{
    internal class AppManager
    {
        private static bool estaCerrando;
        private static bool recursosLiberados;
        private static bool estaNavegando;
        private static readonly object lockObject = new object();
        private static readonly List<Form> activeforms = new List<Form>();
        private static readonly Dictionary<Form, AnimadorBotones> animadoresBotones = new Dictionary<Form, AnimadorBotones>();
        private static ContextoTrabCalc contexto;

        public static bool EstaCerrando => estaCerrando;
        public static bool EstaNavegando => estaNavegando;

        public static ApplicationContext CrearContexto(Form formularioInicial)
        {
            Application.Idle -= Application_Idle;
            Application.Idle += Application_Idle;
            contexto = new ContextoTrabCalc(formularioInicial);
            return contexto;
        }

        public static void RegisterForm(Form form)
        {
            lock (lockObject)
            {
                if (!activeforms.Contains(form))
                {
                    activeforms.Add(form);
                    InstalarAnimadorBotones(form);
                    form.FormClosed += (s, e) => UnregisterForm(form);
                }
            }
        }

        public static void UnregisterForm(Form form)
        {
            lock (lockObject)
            {
                activeforms.Remove(form);
                QuitarAnimadorBotones(form);
            }
        }

        public static void CambiarFormulario(Form actual, Form siguiente)
        {
            if (actual == null || siguiente == null || estaCerrando)
            {
                return;
            }

            if (contexto == null)
            {
                siguiente.Show();
                actual.Hide();
                return;
            }

            estaNavegando = true;
            try
            {
                contexto.Mostrar(siguiente);
                actual.Close();
            }
            finally
            {
                estaNavegando = false;
            }
        }

        public static void ShutdownApplication()
        {
            lock (lockObject)
            {
                if (estaCerrando) return;
                estaCerrando = true;
            }

            LiberarRecursos();

            if (Application.MessageLoop)
            {
                Application.Exit();
            }
            else
            {
                contexto?.ExitThread();
            }
        }

        public static void LiberarRecursos()
        {
            lock (lockObject)
            {
                if (recursosLiberados) return;
                recursosLiberados = true;
            }

            MusicManager.ForceStop();
            ReproductorSonido.DetenerTodos();

            List<Form> formsToCleanup;
            lock (lockObject)
            {
                formsToCleanup = new List<Form>(activeforms);
            }

            foreach (var form in formsToCleanup)
            {
                try
                {
                    if (form is FormSimuladorRecipientes formRecipientes && !formRecipientes.IsDisposed)
                    {
                        formRecipientes.ForceStop();
                    }
                    else if (form is FormSimuladorMovimiento formMovimiento && !formMovimiento.IsDisposed)
                    {
                        formMovimiento.ForceStop();
                    }
                }
                catch
                {
                }
            }

            List<AnimadorBotones> animadores;
            lock (lockObject)
            {
                animadores = new List<AnimadorBotones>(animadoresBotones.Values);
                animadoresBotones.Clear();
            }

            foreach (AnimadorBotones animador in animadores)
            {
                animador.Dispose();
            }
        }

        private static void Application_Idle(object sender, EventArgs e)
        {
            if (estaCerrando) return;

            List<Form> formulariosAbiertos = new List<Form>();
            foreach (Form formulario in Application.OpenForms)
            {
                formulariosAbiertos.Add(formulario);
            }

            lock (lockObject)
            {
                foreach (Form formulario in formulariosAbiertos)
                {
                    InstalarAnimadorBotones(formulario);
                }
            }
        }

        private static void InstalarAnimadorBotones(Form form)
        {
            if (form == null || form.IsDisposed || animadoresBotones.ContainsKey(form))
            {
                return;
            }

            AnimadorBotones animador = AnimadorBotones.Instalar(form);
            if (animador != null)
            {
                animadoresBotones[form] = animador;
                form.FormClosed += (s, e) => QuitarAnimadorBotones(form);
            }
        }

        private static void QuitarAnimadorBotones(Form form)
        {
            if (form == null || !animadoresBotones.ContainsKey(form))
            {
                return;
            }

            AnimadorBotones animador = animadoresBotones[form];
            animadoresBotones.Remove(form);
            animador.Dispose();
        }

        private sealed class ContextoTrabCalc : ApplicationContext
        {
            public ContextoTrabCalc(Form formularioInicial)
            {
                Mostrar(formularioInicial);
            }

            public void Mostrar(Form formulario)
            {
                RegisterForm(formulario);
                MainForm = formulario;
                formulario.FormClosed += Formulario_FormClosed;
                formulario.Show();
            }

            private void Formulario_FormClosed(object sender, FormClosedEventArgs e)
            {
                Form formulario = sender as Form;
                if (formulario != null)
                {
                    formulario.FormClosed -= Formulario_FormClosed;
                }

                lock (lockObject)
                {
                    if (!estaNavegando && !estaCerrando && activeforms.Count == 0)
                    {
                        ExitThread();
                    }
                }
            }
        }
    }
}
