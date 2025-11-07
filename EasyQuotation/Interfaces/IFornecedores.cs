using EasyQuotation.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyQuotation.Interfaces
{
    public interface IFornecedores
    {
        Fornecedor ObterPorId(int id);
        List<Fornecedor> ObterTodos();
        void Salvar(Fornecedor fornecedor);

    }
}