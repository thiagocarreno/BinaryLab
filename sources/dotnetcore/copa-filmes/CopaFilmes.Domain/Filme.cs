using System;

namespace CopaFilmes.Domain
{
    public class Filme
    {
        public int Id { get; }
        public string Titulo { get; }
        public DateTime AnoLancamento { get; }
        public string Nota { get; }

        public Filme(string titulo, DateTime anoLancamento, string nota)
        {
            Titulo = titulo;
            AnoLancamento = anoLancamento;
            Nota = nota;
        }
    }
}