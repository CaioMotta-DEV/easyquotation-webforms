# 🧾 EasyQuotation

Sistema simples de gerenciamento de **cotações**, **fornecedores** e **produtos**, desenvolvido em **ASP.NET WebForms (C#)** — com armazenamento em **arquivos CSV**, sem necessidade de banco de dados.

---

## 🚀 Tecnologias Utilizadas

- **.NET Framework 4.8**
- **ASP.NET WebForms**
- **C#**
- **HTML / CSS**
- **Arquivos CSV** para persistência de dados
- **Git / GitHub**


---

## ⚙️ Funcionalidades

### 🧍 Fornecedores
- Cadastro de fornecedores com **validação de CNPJ (somente números)**
- Listagem em grid
- Armazenamento em `fornecedores.csv`

### 📦 Produtos
- Cadastro e listagem de produtos
- Armazenamento em `produtos.csv`

### 💰 Cotações
- Cadastro de cotações com:
  - **Data**
  - **Fornecedor**
  - **Produto**
  - **Preço** (permite vírgula como separador decimal)
- Exibição do **menor preço por produto**
- Armazenamento em `cotacoes.csv`

---

## 🧠 Validações

- Nenhum campo pode ser deixado em branco.
- Verificação se o **Fornecedor** e **Produto** existem.
- CNPJ aceita apenas **números**.
- Preço permite vírgula (ex: `10,50`).

---

## 🖱️ Navegação

O sistema possui um **menu superior** (controle `Menu.ascx`) para facilitar a navegação entre as páginas:

- **Fornecedores**
- **Produtos**
- **Cotações**

---

## ▶️ Como Executar o Projeto

1. Clone este repositório:
   ```bash
   git clone https://github.com/seu-usuario/EasyQuotation.git
   
2.Abra o projeto no Visual Studio 2022 (ou superior).

3.Verifique se a versão do .NET Framework 4.8 está instalada.

4.Pressione F5 para executar.

5.O sistema abrirá no navegador padrão (ex: http://localhost:xxxx/Paginas/Cotacoes.aspx).

