using EasyQuotation.Interfaces;
using EasyQuotation.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EasyQuotation.Service
{
    public class FornecedoresService : IFornecedores
    {
        private readonly string _caminho;
        public FornecedoresService()
        {
            _caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "fornecedores.csv");
        }

        public Fornecedor ObterPorId(int id)
        {
            return ObterTodos().FirstOrDefault(f => f.Id == id);
        }

        public List<Fornecedor> ObterTodos()
        {
            var fornecedores = new List<Fornecedor>();

            try
            {
                if (!File.Exists(_caminho))
                    return fornecedores;

                var linhas = File.ReadAllLines(_caminho);

                foreach (var linha in linhas)
                {
                    if (string.IsNullOrWhiteSpace(linha))
                        continue;

                    var partes = linha.Split(';');
                    if (partes.Length >= 3)
                    {
                        var fornecedor = new Fornecedor
                        {
                            Id = int.TryParse(partes[0], out int id) ? id : 0,
                            Nome = partes[1],
                            CNPJ = partes[2]
                        };
                        fornecedores.Add(fornecedor);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao carregar fornecedores: {ex.Message}");
            }

            return fornecedores;
        }

        public void Salvar(Fornecedor fornecedor)
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

            fornecedor.Id = novoId;

            using (var writer = new StreamWriter(_caminho, append: true))
            {
                writer.WriteLine(fornecedor.ToString());
            }
        }

    }
}