using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

namespace ProcurarTextoNoArquivo
{
    public partial class FormPrincipal : Form
    {
        private Utilitarios.GeradorHistorico geradorHistorico;
        private bool pesquisando;
        private Thread threadProcurarArquivos;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                dtpDataInicial.Value = DateTime.Now.Date;
                dtpDataFinal.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                geradorHistorico = new Utilitarios.GeradorHistorico("arquivoHistorico.dat");

                pesquisando = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonAbrirPasta_Click(object sender, EventArgs e)
        {
            try
            {
                txtCaminhoPasta.Text = "";
                if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtCaminhoPasta.Text = folderBrowserDialog1.SelectedPath;
                    textBoxParametro.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GravarHistorico(string item)
        {
            try
            {
                if (!ObterHistorico(item))
                {
                    if (!Incluir(item))
                        throw new Exception("Erro ao gravar caminho no Histórico!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool Incluir(string itemHistorico)
        {
            try
            {
                return geradorHistorico.Incluir(itemHistorico);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ObterHistorico(string item)
        {
            try
            {
                return geradorHistorico.Existe(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void buttonPesquisarArquivos_Click(object sender, EventArgs e)
        {
            try
            {
                pesquisando = !pesquisando;

                if (pesquisando)
                {
                    string caminho = txtCaminhoPasta.Text;
                    if (string.IsNullOrWhiteSpace(caminho))
                        throw new Exception("Favor preencher o campo Pasta!");

                    DirectoryInfo directoryInfo = new DirectoryInfo(caminho);
                    if (!directoryInfo.Exists)
                        throw new Exception("Pasta não encontrada!");

                    string parametro = textBoxParametro.Text;
                    DateTime? dataInicial = null;
                    DateTime? dataFinal = null;

                    labelStatus.Text = string.Empty;

                    if (checkBoxData.Checked)
                    {
                        dataInicial = dtpDataInicial.Value;
                        dataFinal = dtpDataFinal.Value;
                        if (dataInicial.Value.CompareTo(dataFinal) > 0)
                            throw new Exception("A data inicial deve ser menor que a data final!");
                    }

                    if (checkBoxAntigoFormato.Checked && checkBoxNovoFormato.Checked)
                        throw new Exception("É preciso checar apenas uma opção de Formato (Novo / Antigo)!");

                    dataGridViewLista.Rows.Clear();
                    labelTotalEncontrados.Text = string.Empty;
                    labelStatus.Text = string.Empty;

                    GravarHistorico(caminho);

                    AtualizarEstadoPesquisa("Pesquisando...");

                    threadProcurarArquivos = new Thread(() => ProcurarArquivos(caminho, parametro, dataInicial, dataFinal, checkBoxRegex.Checked, checkBoxNovoFormato.Checked, checkBoxAntigoFormato.Checked, checkBoxMultiplosParametros.Checked));
                    threadProcurarArquivos.Start();

                    //ProcurarArquivos(caminho, parametro, dataInicial, dataFinal, checkBoxRegex.Checked, checkBoxNovoFormato.Checked, checkBoxAntigoFormato.Checked, checkBoxMultiplosParametros.Checked); 
                }
                else
                {
                    if (threadProcurarArquivos.IsAlive)
                        threadProcurarArquivos.Suspend();

                    AtualizarEstadoPesquisa("Parada.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AtualizarEstadoPesquisa(string texto)
        {
            this.labelEstadoPesquisa.BeginInvoke((MethodInvoker)delegate ()
            {
                labelEstadoPesquisa.Text = texto;
            });
        }

        private void ProcurarArquivos(string caminho, string parametro, DateTime? dataInicial, DateTime? dataFinal, bool regex, bool novoFormato, bool antigoFormato, bool multiplosParametros)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(caminho);
                FileInfo[] files = (dataInicial.HasValue && dataFinal.HasValue) ?
                                        directoryInfo.GetFiles().Where(p => p.LastWriteTimeUtc >= dataInicial && p.LastWriteTimeUtc <= dataFinal).ToArray() :
                                        directoryInfo.GetFiles().ToArray();

                int atual = 0;
                int total = files.Count();

                string caminhoArquivo = string.Empty;
                StringBuilder sb;

                List<string> linhas;
                string linhaAlterada;
                string[] parametros = null;
                if (multiplosParametros) parametros = parametro.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                bool achou;
                foreach (var file in files)
                {
                    achou = false;
                    atual++;
                    caminhoArquivo = file.FullName;

                    Utilitarios.GeradorArquivo geradorArquivo = new Utilitarios.GeradorArquivo(caminhoArquivo);
                    sb = geradorArquivo.LerArquivoTextoStringBuilder();

                    linhas = TransformarEmLista(sb.ToString());
                    linhaAlterada = string.Empty;

                    if (!string.IsNullOrWhiteSpace(parametro))
                    {
                        if (regex)
                        {
                            foreach (string linha in linhas)
                            {
                                if (linhas.Count > 1) linhaAlterada = linha + "\'";
                                if (Regex.IsMatch(linhaAlterada, @parametro))
                                {
                                    PreencherLista(file);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (multiplosParametros && parametros != null && parametros.Count() > 1)
                            {
                                achou = parametros.Any(p => sb.ToString().Contains(p));
                            }
                            else
                            {
                                achou = sb.ToString().Contains(parametro);
                            }

                            if (achou)
                                PreencherLista(file);
                        }
                    }
                    else if (novoFormato)
                    {
                        if (VerificarFormato(linhas, true))
                            PreencherLista(file);
                    }
                    else if (antigoFormato)
                    {
                        if (VerificarFormato(linhas, false))
                            PreencherLista(file);
                    }
                    else
                    {
                        PreencherLista(file);
                    }

                    PreencherStatus(total, atual);
                }

                AtualizarEstadoPesquisa("Finalizada.");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                pesquisando = false;
            }
        }

        private List<string> TransformarEmLista(string texto)
        {
            return texto.Replace("\n", "").Replace("\r", "").Split('\'').ToList();
        }

        private bool VerificarFormato(List<string> linhas, bool novo)
        {
            List<string> segmento = new List<string>();
            string valorSegmento = string.Empty;

            bool retorno = false;
            var listaBGM = linhas.Where(p => p.StartsWith("BGM+")).ToList();
            List<string> bookings = new List<string>();
            foreach (string linhaBGM in listaBGM)
            {
                segmento = linhaBGM.Split('+').ToList();
                if (novo)
                {
                    if (segmento.Count > 2 && segmento[2].Contains("-"))
                        bookings.Add(segmento[2].Split('-')[0]);

                }
                else
                {
                    if (!novo && segmento.Count > 2 && !segmento[2].Contains("-"))
                        bookings.Add(segmento[2]);
                }
            }

            if (novo)
                retorno = bookings.Where(p => !string.IsNullOrEmpty(p)).GroupBy(p => p).Select(g => g.Count()).Where(p => p > 1).ToList().Count > 0;
            else
                retorno = bookings.Where(p => !string.IsNullOrEmpty(p)).GroupBy(p => p).Select(g => g.Count()).Where(p => p > 0).ToList().Count > 0;

            return retorno;
        }

        private void PreencherStatus(int total, int atual)
        {
            this.labelStatus.BeginInvoke((MethodInvoker)delegate ()
            {
                labelStatus.Text = string.Format("{0} de {1}", atual, total);
            });
        }

        private void PreencherLista(FileInfo file)
        {
            string caminho = file.FullName;
            string arquivo = file.Name;
            DateTime data = file.LastWriteTime;
            DateTime dataUtc = file.LastWriteTimeUtc;

            this.Invoke((MethodInvoker)delegate ()
            {
                dataGridViewLista.Rows.Add(arquivo, data, dataUtc, caminho);
                labelTotalEncontrados.Text = dataGridViewLista.Rows.Count.ToString();
            });
        }

        private void dataGridViewLista_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int indice = dataGridViewLista.SelectedRows[0].Index;
                if (indice > -1)
                {
                    string arquivo = dataGridViewLista.Rows[indice].Cells["Caminho"].Value.ToString();
                    try
                    {
                        System.Diagnostics.Process.Start("notepad++", arquivo);
                    }
                    catch (Win32Exception)
                    {
                        System.Diagnostics.Process.Start("notepad", arquivo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBoxParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                buttonPesquisarArquivos.PerformClick();
        }

        private void checkBoxData_CheckedChanged(object sender, EventArgs e)
        {
            dtpDataInicial.Enabled = checkBoxData.Checked;
            dtpDataFinal.Enabled = checkBoxData.Checked;
        }

        private void buttonCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                var senderGrid = dataGridViewLista;
                if (senderGrid.Rows.Count > 0)
                {
                    if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string destino = folderBrowserDialog1.SelectedPath;
                        string arquivo;
                        string origem;
                        foreach (DataGridViewRow row in dataGridViewLista.Rows)
                        {
                            arquivo = row.Cells["Arquivo"].Value.ToString();
                            origem = row.Cells["Caminho"].Value.ToString();
                            File.Copy(origem, string.Concat(destino, @"\", arquivo));
                        }
                        MessageBox.Show("Arquivo(s) copiado(s) com sucesso!", "Cópia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkBoxRegex_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRegex.Checked)
                textBoxParametro.Text = ".*BGM.*1'";
            else
                textBoxParametro.Text = string.Empty;
        }

        private void buttonDetalhes_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewLista.SelectedRows.Count > 0)
                {
                    string caminhoArquivoSelecionado = Convert.ToString(dataGridViewLista.SelectedRows[0].Cells["Caminho"].Value);
                    FileInfo fileInfo = new FileInfo(caminhoArquivoSelecionado);
                    if (fileInfo.Exists)
                    {
                        DetalhesEDI frmDetalhesEDI = new DetalhesEDI(fileInfo);
                        frmDetalhesEDI.ShowDialog();
                    }
                    else
                        throw new FileNotFoundException("Arquivo não encontrado");
                }
                else
                    throw new Exception("Favor selecionar um item da lista!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonHistorico_Click(object sender, EventArgs e)
        {
            try
            {
                Historico frmHistorico = new Historico(geradorHistorico);
                frmHistorico.ShowDialog();

                if (!string.IsNullOrWhiteSpace(frmHistorico.CaminhoSelecionado))
                    txtCaminhoPasta.Text = frmHistorico.CaminhoSelecionado;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
