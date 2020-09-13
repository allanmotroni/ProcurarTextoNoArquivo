using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcurarTextoNoArquivo
{
    public class Erro
    {
        public string Mensagem { get; set; }
        public string Linha { get; set; }
        public int NumeroLinha { get; set; }

        public Erro(string linha, string mensagem, int numeroLinha)
        {
            Linha = linha;
            Mensagem = mensagem;
            NumeroLinha = numeroLinha;
        }
                
        public override string ToString()
        {
            return 
                $"Linha: {NumeroLinha}{Environment.NewLine}" +
                $"Conteúdo: {Linha}{Environment.NewLine}" +
                $"Erro: {Mensagem}";
        }
    }
}
