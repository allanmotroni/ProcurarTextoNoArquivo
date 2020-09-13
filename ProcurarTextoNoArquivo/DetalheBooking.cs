using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcurarTextoNoArquivo
{
    public class DetalheBooking
    {
        public EDIEnums.ETipoEDI TipoEDI { get; set; }

        public EDIEnums.ETipoConteiner TipoConteiner { get; set; }
        public string Isocode { get; set; }
        public int Quantidade { get; set; }        
    }
}
