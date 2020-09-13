using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProcurarTextoNoArquivo.Utilitarios
{
    public class GeradorArquivo
    {
        private string caminho;

        public GeradorArquivo(string caminho)
        {
            this.caminho = caminho;
        }

        public string LerArquivoTexto()
        {
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(caminho))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected List<string> LerArquivoTextoPorLinha()
        {
            try
            {
                List<string> lista = new List<string>();
                FileInfo file = new FileInfo(caminho);
                if (file.Exists)
                {
                    using (StreamReader sr = new StreamReader(caminho))
                    {
                        while (sr.Peek() > -1)
                        {
                            lista.Add(sr.ReadLine());
                        }
                    }
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected bool Atualizar(List<string> lista)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(caminho))
                {
                    foreach (string linha in lista)
                    {
                        sw.WriteLine(linha);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public StringBuilder LerArquivoTextoStringBuilder()
        {
            try
            {
                using (StreamReader sr = new StreamReader(caminho))
                {
                    return new StringBuilder(sr.ReadToEnd());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected bool Existe(string texto)
        {
            try
            {
                FileInfo file = new FileInfo(caminho);
                if (file.Exists)
                {
                    using (StreamReader sr = new StreamReader(caminho))
                    {
                        while (sr.Peek() > -1)
                        {
                            if (sr.ReadLine().ToUpper() == texto.ToUpper())
                                return true;
                        }

                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected bool Incluir(string texto)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(caminho, true))
                {
                    sw.WriteLine(texto);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
