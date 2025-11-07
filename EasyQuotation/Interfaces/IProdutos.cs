using EasyQuotation.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyQuotation.Interfaces
{
    public interface IProdutos
    {
        Produto ObterPorId(int id);
        List<Produto> ObterTodos();
        void Salvar(Produto produto);
    }
}