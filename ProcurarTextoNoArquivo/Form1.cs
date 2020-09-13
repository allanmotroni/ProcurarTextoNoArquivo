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

namespace ProcurarTextoNoArquivo
{
    public partial class Form1 : Form
    {
        string arquivoProcessamento;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpDataInicial.Value = DateTime.Now.Date;
            dtpDataFinal.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        }

        private void buttonAbrirPasta_Click(object sender, EventArgs e)
        {
            try
            {
                arquivoProcessamento = string.Empty;
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

        private void buttonPesquisarArquivos_Click(object sender, EventArgs e)
        {
            try
            {
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

                if (string.IsNullOrEmpty(parametro) && !checkBoxNovoFormato.Checked && !checkBoxAntigoFormato.Checked)
                    throw new Exception("É preciso preencher o campo Parâmetro!");

                if(checkBoxAntigoFormato.Checked && checkBoxNovoFormato.Checked)
                    throw new Exception("É preciso checar apenas uma opção de Formato (Novo / Antigo)!");

                dataGridViewLista.Rows.Clear();
                labelTotalEncontrados.Text = string.Empty;
                labelStatus.Text = string.Empty;

                string caminho = txtCaminhoPasta.Text;
                if (!string.IsNullOrEmpty(caminho))
                {
                    ProcurarArquivos(caminho, parametro, dataInicial, dataFinal, checkBoxRegex.Checked, checkBoxNovoFormato.Checked, checkBoxAntigoFormato.Checked);
                }

                labelTotalEncontrados.Text = dataGridViewLista.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ProcurarArquivos(string caminho, string parametro, DateTime? dataInicial, DateTime? dataFinal, bool regex, bool novoFormato, bool antigoFormato)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(caminho);
            FileInfo[] files = (dataInicial.HasValue && dataFinal.HasValue) ? directoryInfo.GetFiles().Where(p => p.LastWriteTimeUtc >= dataInicial && p.LastWriteTimeUtc <= dataFinal).ToArray() : directoryInfo.GetFiles();

            int atual = 0;
            int total = files.Count();

            string caminhoArquivo = string.Empty;
            StringBuilder sb;
            foreach (var file in files)
            {
                atual++;
                caminhoArquivo = file.FullName;
                using (StreamReader sr = new StreamReader(caminhoArquivo))
                {
                    sb = new StringBuilder(sr.ReadToEnd());
                    sr.Close();
                }

                List<string> linhas = sb.ToString().Replace("\n", "").Replace("\r", "").Split('\'').ToList();
                string linhaAlterada = string.Empty;

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
                    if (sb.ToString().Contains(parametro))
                        PreencherLista(file);
                }

                PreencherStatus(total, atual);
                Application.DoEvents();
            }
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
                    {
                        bookings.Add(segmento[2].Split('-')[0]);
                    }
                }
                else
                {
                    if (!novo && segmento.Count > 2 && !segmento[2].Contains("-"))
                    {
                        bookings.Add(segmento[2]);
                    }
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
            labelStatus.Text = string.Format("{0} de {1}", atual, total);
        }

        private void PreencherLista(FileInfo file)
        {
            string caminho = file.FullName;
            string arquivo = file.Name;
            DateTime data = file.LastWriteTime;
            DateTime dataUtc = file.LastWriteTimeUtc;

            dataGridViewLista.Rows.Add(arquivo, data, dataUtc, caminho);
            labelTotalEncontrados.Text = dataGridViewLista.Rows.Count.ToString();
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
            {
                buttonPesquisarArquivos.PerformClick();
            }
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
                        foreach (DataGridViewRow row in dataGridViewLista.Rows)
                        {
                            string arquivo = row.Cells["Arquivo"].Value.ToString();
                            string origem = row.Cells["Caminho"].Value.ToString();
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
            {
                textBoxParametro.Text = ".*BGM.*1'";
            }
            else
            {
                textBoxParametro.Text = string.Empty;
            }
        }
                
    }
}
