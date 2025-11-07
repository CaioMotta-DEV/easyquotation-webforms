using EasyQuotation.Interfaces;
using EasyQuotation.Modelos;
using EasyQuotation.Service;
using Projeto.Validacoes;
using System;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;

namespace EasyQuotation.Paginas
{
    public partial class Cotacoes : System.Web.UI.Page
    {
        private readonly CotacaoService _service;
        private readonly IFornecedores _fornecedorService = new FornecedoresService();
        private readonly IProdutos _produtoService = new ProdutosService();

        public Cotacoes()
        {
            _service = new CotacaoService(_produtoService, _fornecedorService);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarProdutos();
                CarregarFornecedores();
                CarregarCotacoes();
            }
        }

        private void CarregarFornecedores()
        {
            var fornecedores = _fornecedorService.ObterTodos();
            ddlFornecedor.DataSource = fornecedores;
            ddlFornecedor.DataTextField = "Nome";
            ddlFornecedor.DataValueField = "Id";
            ddlFornecedor.DataBind();
            ddlFornecedor.Items.Insert(0, new ListItem("-- Selecione --", ""));
        }

        private void CarregarProdutos()
        {
            var produtos = _produtoService.ObterTodos();
            ddlProduto.DataSource = produtos;
            ddlProduto.DataTextField = "Nome";
            ddlProduto.DataValueField = "Id";
            ddlProduto.DataBind();
            ddlProduto.Items.Insert(0, new ListItem("-- Selecione --", ""));
        }

        private void CarregarCotacoes()
        {
            grdCotacoes.DataSource = _service.ObterTodos();
            grdCotacoes.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var novaCotacao = new Cotacao
                {
                    Data = DateTime.TryParse(txtData.Text, out DateTime data) ? data : DateTime.MinValue,
                    FornecedorId = int.TryParse(ddlFornecedor.SelectedValue, out int fornecedorId) ? fornecedorId : 0,
                    ProdutoId = int.TryParse(ddlProduto.SelectedValue, out int produtoId) ? produtoId : 0,
                    Preco = decimal.TryParse(txtPreco.Text,
                                            NumberStyles.Any,
                                            new CultureInfo("pt-BR"),
                                            out decimal preco
                                        ) ? preco : 0
                };

                var validacao = new ValidacaoCotacao(new FornecedoresService(), new ProdutosService());
                validacao.Validar(novaCotacao);

                _service.Salvar(novaCotacao);

                lblMensagem.ForeColor = System.Drawing.Color.Green;
                lblMensagem.Text = "Cotação salva com sucesso!";

                Response.Redirect(Request.RawUrl);

                CarregarCotacoes();
            }
            catch (Exception ex)
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = "Erro ao salvar cotação: " + ex.Message;
            }
        }

        protected void btnMenorPreco_Click(object sender, EventArgs e)
        {
            try
            {
                var menoresPrecos = _service.ObterMenorPrecoPorProduto();

                grdMenorPreco.DataSource = menoresPrecos;
                grdMenorPreco.DataBind();

                lblMensagem.ForeColor = System.Drawing.Color.Green;
                lblMensagem.Text = "Consulta concluída com sucesso!";
            }
            catch (Exception ex)
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = "Erro ao consultar menores preços: " + ex.Message;
            }
        }
    }
}
