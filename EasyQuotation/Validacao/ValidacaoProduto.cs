using EasyQuotation.Interfaces;
using EasyQuotation.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyQuotation.Validacao
{
    public class ValidacaoProduto
    {
        public static void Validar(Produto produto, IProdutos service)
        {
            if (produto == null)
            {
                throw new Exception("Produto inválido.");
            }

            if (string.IsNullOrWhiteSpace(produto.Nome))
            {
                throw new Exception("Preencha todos os campos.");
            }

            var produtosExistentes = service.ObterTodos();

            if (produtosExistentes.Any(f => f.Nome == produto.Nome))
            {
                throw new Exception("Já existe um produto cadastrado com este nome.");
            }

        }
    }
}