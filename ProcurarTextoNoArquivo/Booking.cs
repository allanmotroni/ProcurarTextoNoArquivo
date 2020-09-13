using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcurarTextoNoArquivo
{
    public class Booking
    {
        public string Descricao { get; set; }
        private List<DetalheBooking> detalhesBooking { get; set; }
        private List<Erro> erros { get; set; }
        public bool PossuiErros { get { return erros != null && erros.Count > 0; } }

        public void IncluirDetalhe(DetalheBooking detalheBooking)
        {
            if(detalhesBooking == null) detalhesBooking = new List<DetalheBooking>();
            detalhesBooking.Add(detalheBooking);            
        }

        public List<DetalheBooking> ObterDetalhesBooking()
        {
            return detalhesBooking ?? new List<DetalheBooking>();
        }

        public void GravarErro(string linha, string mensagem, int numeroLinha)
        {
            if (erros == null) erros = new List<Erro>();
            erros.Add(new Erro(linha, mensagem, numeroLinha));            
        }

        public List<Erro> ObterErros()
        {
            return erros ?? new List<Erro>();
        }
    }
}
