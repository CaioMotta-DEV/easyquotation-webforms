using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyQuotation.Modelos
{
    public class Cotacao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int FornecedorId { get; set; }
        public string FornecedorNome { get; set; }
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public decimal Preco { get; set; }


        public override string ToString() => $"{Id};{Data:dd-MM-yyyyy};{FornecedorId};{ProdutoId};{Preco}";
    }
}