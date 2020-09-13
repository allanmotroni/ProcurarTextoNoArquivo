using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProcurarTextoNoArquivo
{
    public partial class DetalhesEDI : Form
    {
        private FileInfo fileInfo;

        public DetalhesEDI(FileInfo fileInfo)
        {
            InitializeComponent();
            this.fileInfo= fileInfo;
        }

        private void DetalhesEDI_Load(object sender, EventArgs e)
        {
            try
            {
                GeradorDetalhesEDI geradorDetalhesEDI = new GeradorDetalhesEDI(fileInfo.FullName);
                var bookings = geradorDetalhesEDI.IniciarProcessamento().ObterBookings();
                if(bookings.Count > 0)
                {
                    PreencherGridLista(bookings);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Retornar();
            }
        }

        private void PreencherGridLista(List<Booking> bookings)
        {
            dataGridViewLista.DataSource = bookings;
            labelTotal.Text = bookings.Count.ToString(); 
        }

        private void Retornar()
        {
            Close();
        }

        private void dataGridViewLista_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int indice = dataGridViewLista.SelectedRows[0].Index;
                if (indice > -1)
                {
                    Booking booking = (Booking)dataGridViewLista.SelectedRows[0].DataBoundItem;
                    if(booking != null && booking.ObterDetalhesBooking().Count > 0)
                    {
                        DetalhesBooking frmDetalhesBooking = new DetalhesBooking(booking.Descricao, booking.ObterDetalhesBooking());
                        frmDetalhesBooking.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonVerErros_Click(object sender, EventArgs e)
        {
            try
            {
                int indice = dataGridViewLista.SelectedRows[0].Index;
                if (indice > -1)
                {
                    Booking booking = (Booking)dataGridViewLista.SelectedRows[0].DataBoundItem;
                    if (booking != null && booking.ObterErros().Count > 0)
                    {
                        DetalhesErros frmDetalhesErros = new DetalhesErros(booking.ObterErros());
                        frmDetalhesErros.Show();
                    }
                    else
                    {
                        throw new Exception("A linha selecionada não possui erros!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
