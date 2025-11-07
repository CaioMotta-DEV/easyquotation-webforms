using EasyQuotation.Interfaces;
using EasyQuotation.Modelos;
using EasyQuotation.Service;
using EasyQuotation.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyQuotation.Paginas
{
    public partial class Produtos : System.Web.UI.Page
    {
        private readonly IProdutos _service = new ProdutosService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarProdutos();
            } 
        }

        private void CarregarProdutos()
        {
            grdProdutos.DataSource = _service.ObterTodos();
            grdProdutos.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var novoProduto = new Produto
                {
                    Nome = txtNome.Text
                };

                ValidacaoProduto.Validar(novoProduto, _service);

                _service.Salvar(novoProduto);

                lblMensagem.ForeColor = System.Drawing.Color.Green;
                lblMensagem.Text = "Produto salvo com sucesso!";

                CarregarProdutos();

                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = "Erro ao salvar Produto: " + ex.Message;
            }
        }
        protected void btnIrParaFornecedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("Fornecedor.aspx");
        }

        protected void btnIrParaCotacoes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cotacao.aspx");
        }

    }
}