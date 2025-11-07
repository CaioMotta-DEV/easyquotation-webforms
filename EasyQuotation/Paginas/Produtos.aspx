<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="EasyQuotation.Paginas.Produtos" %>
<%@ Register Src="~/Controle/Menu.ascx" TagPrefix="uc" TagName="Menu" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de Produtos</title>
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
            width: 100px;
        }

        input[type=text] {
            width: 250px;
        }

        .botao {
            margin-top: 10px;
        }

        table {
            border-collapse: collapse;
            margin-top: 20px;
            width: 60%;
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
    <form id="formProduto" runat="server">
        <uc:Menu ID="menuPrincipal" runat="server" />

        <h2>Cadastro de Produtos</h2>

        <div class="form-campo">
            <label for="txtNome">Nome:</label>
            <asp:TextBox ID="txtNome" runat="server" />

            <div class="botao">
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
            </div>

            <hr />

            <h3>Lista de Produtos</h3>
            <asp:GridView ID="grdProdutos" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Id" />
                    <asp:BoundField HeaderText="Nome" DataField="Nome" />
                </Columns>
            </asp:GridView>

            <br />
            <asp:Label ID="lblMensagem" runat="server" ForeColor="Green"></asp:Label>
    </form>
</body>
</html>
