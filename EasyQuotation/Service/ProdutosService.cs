using EasyQuotation.Interfaces;
using EasyQuotation.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EasyQuotation.Service
{
    public class ProdutosService : IProdutos
    {
        private readonly string _caminho;
        public ProdutosService()
        {
            _caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "produto.csv");
        }

        public Produto ObterPorId(int id)
        {
            return ObterTodos().FirstOrDefault(p => p.Id == id);
        }

        public List<Produto> ObterTodos()
        {
            var produtos = new List<Produto>();

            try
            {
                if (!File.Exists(_caminho))
                    return produtos;

                var linhas = File.ReadAllLines(_caminho);

                foreach (var linha in linhas)
                {
                    if (string.IsNullOrWhiteSpace(linha))
                        continue;

                    var partes = linha.Split(';');
                    if (partes.Length >= 2)
                    {
                        var produto = new Produto
                        {
                            Id = int.TryParse(partes[0], out int id) ? id : 0,
                            Nome = partes[1]
                        };
                        produtos.Add(produto);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao carregar fornecedores: {ex.Message}");
            }

            return produtos;
        }

        public void Salvar(Produto produto)
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

            produto.Id = novoId;

            using (var writer = new StreamWriter(_caminho, append: true))
            {
                writer.WriteLine(produto.ToString());
            }
        }
    }
}