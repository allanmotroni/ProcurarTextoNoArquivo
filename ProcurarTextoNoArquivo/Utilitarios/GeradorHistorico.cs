using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcurarTextoNoArquivo.Utilitarios
{
    public class GeradorHistorico : GeradorArquivo
    {
        public GeradorHistorico(string caminho)
            : base(caminho) { }  
        
        public new bool Existe(string texto)
        {
            return base.Existe(texto);
        }

        public new bool Incluir(string texto)
        {
            return base.Incluir(texto);
        }

        public List<string> Listar()
        {
            return LerArquivoTextoPorLinha();
        }

        public new bool Atualizar(List<string> lista)
        {
            return base.Atualizar(lista);
        }
    }
}
