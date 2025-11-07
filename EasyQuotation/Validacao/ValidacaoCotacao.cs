using EasyQuotation.Modelos;
using EasyQuotation.Service;
using System;
using System.Linq;

namespace Projeto.Validacoes
{
    public class ValidacaoCotacao
    {
        private readonly FornecedoresService _fornecedorService;
        private readonly ProdutosService _produtoService;

        public ValidacaoCotacao(FornecedoresService fornecedoresService, ProdutosService produtosService)
        {
            _fornecedorService = fornecedoresService;
            _produtoService = produtosService;
        }

        public void Validar(Cotacao cotacao)
        {
            if (cotacao == null)
            {
                throw new Exception("O campos devem estar preenchidos");
            }

            if (cotacao.Data == DateTime.MinValue)
            {
                throw new Exception("O campo Data deve ser preenchido.");
            }

            if (cotacao.FornecedorId <= 0)
            {
                throw new Exception("O campo Fornecedor deve ser selecionado.");
            }

            if (cotacao.ProdutoId <= 0)
            {
                throw new Exception("O campo Produto deve ser selecionado.");
            }

            if (cotacao.Preco <= 0)
            {
                throw new Exception("O campo Preço deve ser maior que zero.");
            }

            var fornecedor = _fornecedorService.ObterPorId(cotacao.FornecedorId);
            if (fornecedor == null)
            {
                throw new Exception("Fornecedor não encontrado.");
            }

            var produto = _produtoService.ObterPorId(cotacao.ProdutoId);
            if (produto == null)
            {
                throw new Exception("Produto não encontrado.");
            }

        }
    }
}
