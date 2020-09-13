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
    public partial class DetalhesErros : Form
    {
        private List<Erro> erros;
        public DetalhesErros(List<Erro> erros)
        {
            InitializeComponent();
            this.erros = erros;
        }

        private void DetalhesErros_Load(object sender, EventArgs e)
        {
            try
            {
                PreencherErros(erros);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PreencherErros(List<Erro> erros)
        {
            try
            {
                richTextBoxErros.Clear();
                foreach (Erro erro in erros)
                {
                    richTextBoxErros.AppendText(string.Concat(erro.ToString(), Environment.NewLine, "==========", Environment.NewLine));
                }
                labelTotal.Text = erros.Count.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
