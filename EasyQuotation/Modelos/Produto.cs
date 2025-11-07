using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyQuotation.Modelos
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public override string ToString() => $"{Id};{Nome}";
    }
}