<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fornecedores.aspx.cs" Inherits="EasyQuotation.Paginas.Fornecedores" %>
<%@ Register Src="~/Controle/Menu.ascx" TagPrefix="uc" TagName="Menu" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de Fornecedores</title>
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
    <form id="formFornecedor" runat="server">
        <uc:Menu ID="menuPrincipal" runat="server" />

        <h2>Cadastro de Fornecedores</h2>

        <div class="form-campo">
            <label for="txtNome">Nome:</label>
            <asp:TextBox ID="txtNome" runat="server" />
        </div>
        <div class="form-campo">
            <label for="txtCnpj">CNPJ:</label>
            <asp:TextBox ID="txtCnpj" runat="server" />
        </div>

        <div class="botao">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        </div>

        <hr />

        <h3>Lista de Fornecedores</h3>
        <asp:GridView ID="grdFornecedores" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Id" />
                <asp:BoundField HeaderText="Nome" DataField="Nome" />
                <asp:BoundField HeaderText="CNPJ" DataField="Cnpj" />
            </Columns>
        </asp:GridView>

        <br />
        <asp:Label ID="lblMensagem" runat="server" ForeColor="Green"></asp:Label>
    </form>
</body>
</html>
