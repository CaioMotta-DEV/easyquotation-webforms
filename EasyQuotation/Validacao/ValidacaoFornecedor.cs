using EasyQuotation.Interfaces;
using EasyQuotation.Modelos;
using EasyQuotation.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EasyQuotation.Validacoes
{
    public static class ValidadorFornecedor
    {
        public static void Validar(Fornecedor fornecedor, IFornecedores service)
        {
            if (fornecedor == null)
            {
                throw new Exception("Fornecedor inválido.");
            }

            if (string.IsNullOrWhiteSpace(fornecedor.Nome) || string.IsNullOrWhiteSpace(fornecedor.CNPJ))
            {
                throw new Exception("Preencha todos os campos.");
            }

            if (fornecedor.CNPJ.Length != 14)
            {
                throw new Exception("CNPJ inválido. Deve ter 14 caracteres.");
            }

            var fornecedoresExistentes = service.ObterTodos();
            if (fornecedoresExistentes.Any(f => f.CNPJ == fornecedor.CNPJ))
            {
                throw new Exception("Já existe um fornecedor cadastrado com este CNPJ.");
            }

        }
    }
}
