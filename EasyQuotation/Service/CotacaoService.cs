using EasyQuotation.Interfaces;
using EasyQuotation.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EasyQuotation.Service
{
    public class CotacaoService : ICotacoes
    {
        private readonly string _caminho;
        private readonly IProdutos _serviceProdutos;
        private readonly IFornecedores _serviceFornecedores;


        public CotacaoService(IProdutos serviceProdutos, IFornecedores serviceFornecedores)
        {
            _caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "cotacao.csv");
            _serviceProdutos = serviceProdutos;
            _serviceFornecedores = serviceFornecedores;
        }


        public List<Cotacao> ObterTodos()
        {
            var cotacoes = new List<Cotacao>();

            try
            {
                if (!File.Exists(_caminho))
                    return cotacoes;

                var linhas = File.ReadAllLines(_caminho);

                foreach (var linha in linhas)
                {
                    if (string.IsNullOrWhiteSpace(linha))
                        continue;

                    var partes = linha.Split(';');
                    if (partes.Length >= 5)
                    {
                        var cotacao = new Cotacao
                        {
                            Id = int.TryParse(partes[0], out int id) ? id : 0,
                            Data = DateTime.TryParse(partes[1], out DateTime data) ? data : DateTime.MinValue,
                            FornecedorId = int.TryParse(partes[2], out int fornecedorId) ? fornecedorId : 0,
                            ProdutoId = int.TryParse(partes[3], out int produtoId) ? produtoId : 0,
                            Preco = decimal.TryParse(partes[4], out decimal preco) ? preco : 0
                        };

                        var fornecedor = _serviceFornecedores.ObterPorId(cotacao.FornecedorId);
                        var produto = _serviceProdutos.ObterPorId(cotacao.ProdutoId);

                        cotacao.FornecedorNome = fornecedor?.Nome ?? "-";
                        cotacao.ProdutoNome = produto?.Nome ?? "-";

                        cotacoes.Add(cotacao);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao carregar fornecedores: {ex.Message}");
            }

            return cotacoes;
        }


        public void Salvar(Cotacao cotacao)
        {
            int novoId = 1;

            if (File.Exists(_caminho))
            {
                var ultimaLinha = File.ReadLines(_caminho).LastOrDefault();
                if (!string.IsNullOrWhiteSpace(ultimaLinha))
                {
                    var partes = ultimaLinha.Split(';');
                    if (int.TryParse(partes[0], out int ultimoId))
                        novoId = ultimoId + 1;
                }
            }

            cotacao.Id = novoId;

            using (var writer = new StreamWriter(_caminho, append: true))
            {
                writer.WriteLine(cotacao.ToString());
            }
        }

        public List<object> ObterMenorPrecoPorProduto()
        {
            var cotacoes = ObterTodos();

            var resultado = cotacoes
                .GroupBy(c => c.ProdutoId)
                .Select(g =>
                {
                    var menor = g.OrderBy(c => c.Preco).First();
                    var produto = _serviceProdutos.ObterPorId(menor.ProdutoId);
                    var fornecedor = _serviceFornecedores.ObterPorId(menor.FornecedorId);

                    return new
                    {
                        ProdutoNome = produto?.Nome ?? "-",
                        FornecedorNome = fornecedor?.Nome ?? "-",
                        Preco = menor.Preco
                    };
                })
                .ToList<object>();

            return resultado;
        }

    }
}