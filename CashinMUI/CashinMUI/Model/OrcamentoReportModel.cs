using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashinMUI.Model
{
    public class OrcamentoReportModel
    {
        public string Cliente {get; set;}

        public string Titulo { get; set; }
        public string Usuario { get; set; }        
        public string Descricao { get; set; }
        public string NomeFantasia { get; set; }
        public string Documento { get; set; }
        public string EndUsuario { get; set; }
        public string Cidade { get; set; }
        public string FoneUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public DateTime Data { get; set; }
        public DateTime Validade {get; set;}
        public string Codigo { get; set; }

        public List<ItemOrcamentoReportModel> Itens { get; set; }
    }
    public class ItemOrcamentoReportModel
    {
        public ItemOrcamentoReportModel(string desc, decimal valor)
        {
            this.Descricao = desc;
            this.Valor = valor;
        }

        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
