using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProcurarTextoNoArquivo
{
    public partial class Historico : Form
    {
        private Utilitarios.GeradorHistorico geradorHistorico;
        public string CaminhoSelecionado { get; private set; }
        private BindingList<string> Lista { get; set; }

        public Historico(Utilitarios.GeradorHistorico geradorHistorico)
        {
            InitializeComponent();
            this.geradorHistorico = geradorHistorico;
        }

        private void Historico_Load(object sender, EventArgs e)
        {
            try
            {
                Lista = new BindingList<string>(geradorHistorico.Listar());
                PreencherHistorico();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PreencherHistorico()
        {
            try
            {
                listBoxHistorico.DataSource = Lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                ExcluirItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExcluirItem()
        {
            try
            {
                if (listBoxHistorico.SelectedIndex > -1)
                {
                    Lista.Remove(listBoxHistorico.SelectedItem as string);
                    listBoxHistorico.Update();
                    geradorHistorico.Atualizar(Lista.ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void listBoxHistorico_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (listBoxHistorico.SelectedIndex > -1)
                {
                    string item = listBoxHistorico.SelectedItem as string;
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        CaminhoSelecionado = item;
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
                
        private void Historico_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    ExcluirItem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
