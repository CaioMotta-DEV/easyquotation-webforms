using EasyQuotation.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyQuotation.Interfaces
{
    public interface ICotacoes
    {
        List<Cotacao> ObterTodos();
        void Salvar(Cotacao cotacao);
        List<object> ObterMenorPrecoPorProduto();

    }
}