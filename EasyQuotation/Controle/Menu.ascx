<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="EasyQuotation.Controle.Menu" %>

<div style="margin-bottom: 15px; text-align: center;">
    <asp:Button ID="btnFornecedores" runat="server" Text="Fornec." CssClass="menu-btn" OnClick="btnFornecedores_Click" />
    <asp:Button ID="btnProdutos" runat="server" Text="Prod." CssClass="menu-btn" OnClick="btnProdutos_Click" />
    <asp:Button ID="btnCotacoes" runat="server" Text="Cotações" CssClass="menu-btn" OnClick="btnCotacoes_Click" />
</div>

<style>
    .menu-btn {
        margin: 5px;
        padding: 6px 12px;
        border: 1px solid #ccc;
        background-color: #f5f5f5;
        border-radius: 4px;
        cursor: pointer;
    }
    .menu-btn:hover {
        background-color: #e0e0e0;
    }
</style>
