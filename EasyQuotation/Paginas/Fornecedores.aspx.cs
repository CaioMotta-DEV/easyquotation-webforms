using EasyQuotation.Interfaces;
using EasyQuotation.Modelos;
using EasyQuotation.Service;
using EasyQuotation.Validacoes;
using System;
using System.Linq;

namespace EasyQuotation.Paginas
{
    public partial class Fornecedores : System.Web.UI.Page
    {
        private readonly IFornecedores _service = new FornecedoresService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarFornecedores();
            }
        }

        private void CarregarFornecedores()
        {
            grdFornecedores.DataSource = _service.ObterTodos();
            grdFornecedores.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var novoFornecedor = new Fornecedor
                {
                    Nome = txtNome.Text,
                    CNPJ = txtCnpj.Text
                };

                ValidadorFornecedor.Validar(novoFornecedor, _service);

                _service.Salvar(novoFornecedor);

                lblMensagem.ForeColor = System.Drawing.Color.Green;
                lblMensagem.Text = "Fornecedor salvo com sucesso!";

                CarregarFornecedores();

                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = "Erro ao salvar fornecedor: " + ex.Message;
            }
        }

        protected void btnIrParaProdutos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produto.aspx");
        }

        protected void btnIrParaCotacoes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cotacao.aspx");
        }

    }
}
