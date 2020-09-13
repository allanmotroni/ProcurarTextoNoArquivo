using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProcurarTextoNoArquivo
{
    public class GeradorDetalhesEDI
    {
        private string caminhoArquivo;
        private List<Booking> bookings;

        public GeradorDetalhesEDI(string caminhoArquivo)
        {
            this.caminhoArquivo = caminhoArquivo;
        }

        public GeradorDetalhesEDI ObterInstancia()
        {
            return this;
        }

        public GeradorDetalhesEDI IniciarProcessamento()
        {
            try
            {
                string texto = LerInformacoes();
                List<string> linhas = ObterLista(texto);
                ExtrairInformacoes(linhas);
                return this;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Booking> ObterBookings()
        {
            return bookings;
        }

        private string LerInformacoes()
        {
            try
            {
                string texto = string.Empty;
                using (StreamReader sr = new StreamReader(caminhoArquivo))
                {
                    texto = sr.ReadToEnd();
                }
                return texto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<string> ObterLista(string texto)
        {
            try
            {
                List<string> lista = TransformarEmLista(TratarTexto(texto));
                if (lista.Count == 0) throw new Exception("O arquivo não possui conteúdo!");
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ExtrairInformacoes(List<string> lista)
        {
            bookings = new List<Booking>();
            Booking booking = new Booking();
            DetalheBooking detalheBooking = new DetalheBooking();
            EDIEnums.EPosicaoLeitura posicaoLeitura = EDIEnums.EPosicaoLeitura.NAO_INICIADO;

            lista = lista.Where(linha => linha.Length > 2).ToList();
            int numeroLinha = 0;
            foreach (string linha in lista)
            {
                numeroLinha++;
                try
                {
                    if (linha.StartsWith(EDIConstantes.UNH))
                    {
                        posicaoLeitura = EDIEnums.EPosicaoLeitura.INICIO;
                        booking = new Booking();
                        detalheBooking = new DetalheBooking();
                    }
                    else if (linha.StartsWith(EDIConstantes.BGM))
                    {
                        if (detalheBooking.TipoEDI != EDIEnums.ETipoEDI.NULL)
                        {
                            booking.IncluirDetalhe(detalheBooking);
                            detalheBooking = new DetalheBooking();
                        }
                        detalheBooking.TipoEDI = ObterTipoEDI(linha);
                    }
                    else if (linha.StartsWith(EDIConstantes.SegmentoBooking))
                    {
                        posicaoLeitura = EDIEnums.EPosicaoLeitura.CORPO;
                        if (string.IsNullOrEmpty(booking.Descricao))
                            booking.Descricao = TratarBooking(ObterNumeroBooking(linha));
                    }
                    else if (linha.StartsWith(EDIConstantes.SegmentoConteinerIsocodeTipo))
                    {
                        posicaoLeitura = EDIEnums.EPosicaoLeitura.CORPO;

                        if (!string.IsNullOrEmpty(detalheBooking.Isocode) || detalheBooking.TipoConteiner != EDIEnums.ETipoConteiner.NULL)
                        {
                            booking.IncluirDetalhe(detalheBooking);
                            var tipoEDI = detalheBooking.TipoEDI;
                            detalheBooking = new DetalheBooking();
                            detalheBooking.TipoEDI = tipoEDI;
                        }
                        detalheBooking.Isocode = ObterISOCODE(linha);
                        detalheBooking.TipoConteiner = ObterTipoConteiner(linha);
                    }
                    else if (linha.StartsWith(EDIConstantes.SegmentoQuantidade))
                    {
                        posicaoLeitura = EDIEnums.EPosicaoLeitura.CORPO;
                        detalheBooking.Quantidade = ObterQuantidade(linha);
                    }
                    else if (linha.StartsWith(EDIConstantes.UNT))
                    {
                        posicaoLeitura = EDIEnums.EPosicaoLeitura.FIM;
                        var bookingEncontrado = ObterBooking(booking.Descricao);
                        if (bookingEncontrado == null)
                        {
                            booking.IncluirDetalhe(detalheBooking);
                            bookings.Add(booking);
                        }
                        else
                        {
                            bookingEncontrado.IncluirDetalhe(detalheBooking);
                        }
                    }
                }
                catch (Exception ex)
                {
                    booking.GravarErro(linha, ex.Message, numeroLinha);
                }
            }
        }

        private Booking ObterBooking(string numeroBooking)
        {
            try
            {
                if (bookings != null)
                {
                    return bookings.Where(p => p.Descricao == numeroBooking).FirstOrDefault();
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string TratarBooking(string numeroBooking)
        {
            try
            {
                var retorno = numeroBooking.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                return retorno[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        private int ObterQuantidade(string linha)
        {
            try
            {
                string dado = ExtrairDado(linha, 2);
                return Convert.ToInt16(dado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private EDIEnums.ETipoConteiner ObterTipoConteiner(string linha)
        {
            try
            {
                string dado = ExtrairDado(linha, 7);
                if (Enum.IsDefined(typeof(EDIEnums.ETipoConteiner), Convert.ToInt32(dado)))
                {
                    return (EDIEnums.ETipoConteiner)Convert.ToInt32(dado);
                }
                else
                {
                    throw new ArgumentException($"Tipo Contêiner possui um valor não suportador. Valor: {dado}", nameof(dado));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string ObterISOCODE(string linha)
        {
            try
            {
                return ExtrairDado(linha, 4, 1);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string ObterNumeroBooking(string linha)
        {
            try
            {
                return ExtrairDado(linha, 2, 2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private EDIEnums.ETipoEDI ObterTipoEDI(string linha)
        {
            try
            {
                string dado = ExtrairDado(linha, 4);
                if (Enum.IsDefined(typeof(EDIEnums.ETipoEDI), Convert.ToInt32(dado)))
                {
                    return (EDIEnums.ETipoEDI)Convert.ToInt32(dado);
                }
                else
                {
                    throw new ArgumentException($"Tipo EDI possui um valor não suportador. Valor: {dado}", nameof(dado));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string TratarTexto(string texto)
        {
            texto = texto.Replace("\n", string.Empty).Replace("\r", string.Empty);
            return texto;
        }

        private List<string> TransformarEmLista(string texto)
        {
            try
            {
                List<string> lista = texto.Split(new string[] { "'" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string ExtrairDado(string linha, int posicao)
        {
            try
            {
                string retorno = string.Empty;
                var partes = linha.Split('+').ToList();
                if (partes.Count >= posicao)
                    retorno = partes[posicao - 1];

                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string ExtrairDado(string linha, int posicao, int subPosicao)
        {
            try
            {
                string retorno = string.Empty;
                string primeiraParte = ExtrairDado(linha, posicao);

                var partes = primeiraParte.Split(':').ToList();
                if (partes.Count >= subPosicao)
                    retorno = partes[subPosicao - 1];

                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
