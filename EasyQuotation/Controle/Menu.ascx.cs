using System;
using System.Web.UI;

namespace EasyQuotation.Controle
{
    public partial class Menu : UserControl
    {
        protected void btnFornecedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Fornecedores.aspx");
        }

        protected void btnProdutos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Produtos.aspx");
        }

        protected void btnCotacoes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Cotacoes.aspx");
        }
    }
}
