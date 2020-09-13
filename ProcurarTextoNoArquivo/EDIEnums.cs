using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcurarTextoNoArquivo
{
    public static class EDIEnums
    {
        public enum ETipoEDI { NULL = 0, DESCONHECIDO = -1, INCLUSAO = 9, ALTERACAO = 5, REMOCAO = 1 };
        public enum ETipoConteiner { NULL = 0, DESCONHECIDO = -1, CHEIO = 5, VAZIO = 4 };
        public enum EPosicaoLeitura { NULL, NAO_INICIADO, INICIO, CORPO, FIM };
    }
}
