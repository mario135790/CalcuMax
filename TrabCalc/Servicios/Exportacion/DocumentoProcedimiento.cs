using System.Collections.Generic;
using System.Text;

namespace TrabCalc.Servicios.Exportacion
{
    internal enum TipoElementoProcedimiento
    {
        Titulo,
        Subtitulo,
        Texto,
        Formula,
        Separador
    }

    internal sealed class ElementoProcedimiento
    {
        public TipoElementoProcedimiento Tipo { get; }
        public string Texto { get; }

        public ElementoProcedimiento(TipoElementoProcedimiento tipo, string texto)
        {
            Tipo = tipo;
            Texto = texto ?? "";
        }
    }

    internal sealed class DocumentoProcedimiento
    {
        private readonly List<ElementoProcedimiento> elementos = new List<ElementoProcedimiento>();

        public IEnumerable<ElementoProcedimiento> Elementos => elementos;

        public void Limpiar()
        {
            elementos.Clear();
        }

        public void AgregarTitulo(string texto) => elementos.Add(new ElementoProcedimiento(TipoElementoProcedimiento.Titulo, texto));
        public void AgregarSubtitulo(string texto) => elementos.Add(new ElementoProcedimiento(TipoElementoProcedimiento.Subtitulo, texto));
        public void AgregarTexto(string texto) => elementos.Add(new ElementoProcedimiento(TipoElementoProcedimiento.Texto, texto));
        public void AgregarFormula(string latex) => elementos.Add(new ElementoProcedimiento(TipoElementoProcedimiento.Formula, latex));
        public void AgregarSeparador() => elementos.Add(new ElementoProcedimiento(TipoElementoProcedimiento.Separador, ""));

        public string ATextoPlano()
        {
            StringBuilder texto = new StringBuilder();

            foreach (ElementoProcedimiento elemento in elementos)
            {
                switch (elemento.Tipo)
                {
                    case TipoElementoProcedimiento.Titulo:
                        texto.AppendLine(elemento.Texto.ToUpperInvariant());
                        texto.AppendLine(new string('=', elemento.Texto.Length));
                        break;
                    case TipoElementoProcedimiento.Subtitulo:
                        texto.AppendLine();
                        texto.AppendLine(elemento.Texto);
                        texto.AppendLine(new string('-', elemento.Texto.Length));
                        break;
                    case TipoElementoProcedimiento.Formula:
                        texto.AppendLine("Formula: " + elemento.Texto);
                        break;
                    case TipoElementoProcedimiento.Separador:
                        texto.AppendLine(new string('-', 60));
                        break;
                    default:
                        texto.AppendLine(elemento.Texto);
                        break;
                }
            }

            return texto.ToString();
        }
    }
}
