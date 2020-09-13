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
    public partial class DetalhesBooking : Form
    {
        private List<DetalheBooking> listaDetalheBooking;
        private List<DetalheBooking> ListaDetalheBookingAgrupado
        {
            get
            {
                return listaDetalheBooking
                .GroupBy(p => new
                {
                    p.Isocode,
                    p.TipoConteiner,
                    p.TipoEDI
                })
                .Select(g => new DetalheBooking()
                {
                    Isocode = g.Key.Isocode,
                    Quantidade = g.Count(),
                    TipoEDI = g.Key.TipoEDI,
                    TipoConteiner = g.Key.TipoConteiner
                })
                .ToList();
            }
        }
        private string booking;

        public DetalhesBooking(string booking, List<DetalheBooking> listaDetalheBooking)
        {
            InitializeComponent();
            this.listaDetalheBooking = listaDetalheBooking;
            this.booking = booking;
        }

        private void DetalhesBooking_Load(object sender, EventArgs e)
        {
            try
            {
                Text = string.Concat(Text, " - ", booking.ToUpper());
                PreencherGridLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PreencherGridLista()
        {
            try
            {
                if (checkBoxAgrupar.Checked)
                {
                    dataGridViewLista.DataSource = ListaDetalheBookingAgrupado;
                }
                else
                {
                    dataGridViewLista.DataSource = listaDetalheBooking;
                }
                labelTotal.Text = listaDetalheBooking.Count.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void checkBoxAgrupar_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                PreencherGridLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
