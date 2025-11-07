<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cotacoes.aspx.cs" Inherits="EasyQuotation.Paginas.Cotacoes" %>
<%@ Register Src="~/Controle/Menu.ascx" TagPrefix="uc" TagName="Menu" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cotações de Produtos</title>
    <style>
        body {
            font-family: Arial;
            margin: 20px;
        }

        h2 {
            color: #2c3e50;
        }

        .form-campo {
            margin-bottom: 10px;
        }

        label {
            display: inline-block;
            width: 120px;
        }

        input[type=text], select {
            width: 250px;
        }

        .botao {
            margin-top: 10px;
        }

        table {
            border-collapse: collapse;
            margin-top: 20px;
            width: 80%;
        }

        th, td {
            border: 1px solid #ccc;
            padding: 8px;
            text-align: left;
        }

        th {
            background-color: #f4f4f4;
        }
    </style>
</head>
<body>
    <form id="formCotacao" runat="server">
        <uc:Menu ID="menuPrincipal" runat="server" />

        <h2>Cadastro de Cotações</h2>

        <div class="form-campo">
            <label for="txtData">Data:</label>
            <asp:TextBox ID="txtData" runat="server" TextMode="Date" />
        </div>

        <div class="form-campo">
            <label for="ddlFornecedor">Fornecedor:</label>
            <asp:DropDownList ID="ddlFornecedor" runat="server" />
        </div>

        <div class="form-campo">
            <label for="ddlProduto">Produto:</label>
            <asp:DropDownList ID="ddlProduto" runat="server" />
        </div>

        <div class="form-campo">
            <label for="txtPreco">Preço:</label>
            <asp:TextBox ID="txtPreco" runat="server" />
        </div>

        <div class="botao">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        </div>

        <hr />

        <h3>Lista de Cotações</h3>
        <asp:GridView ID="grdCotacoes" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Id" />
                <asp:BoundField HeaderText="Data" DataField="Data" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField HeaderText="Fornecedor" DataField="FornecedorNome" />
                <asp:BoundField HeaderText="Produto" DataField="ProdutoNome" />
                <asp:BoundField HeaderText="Preço" DataField="Preco" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>

        <br />

        <hr />

        <div class="botao">
            <asp:Button ID="btnMenorPreco" runat="server" Text="Consultar Menor Preço por Produto" OnClick="btnMenorPreco_Click" />
        </div>

        <h3>Menor Preço por Produto</h3>
        <asp:GridView ID="grdMenorPreco" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Produto" DataField="ProdutoNome" />
                <asp:BoundField HeaderText="Fornecedor" DataField="FornecedorNome" />
                <asp:BoundField HeaderText="Menor Preço" DataField="Preco" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>

        <asp:Label ID="lblMensagem" runat="server" ForeColor="Green"></asp:Label>
    </form>
</body>
</html>
