using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace M17_Modelo_T2
{
    public partial class venda : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //atualizar as dropdownlists
                DataTable clientes = bd.devolveConsulta("SELECT id,nome FROM cliente");
                if(clientes==null || clientes.Rows.Count == 0)
                {
                    Response.Redirect("clientes.aspx");
                    return;
                }
                foreach(DataRow linha in clientes.Rows)
                {
                    ListItem novo = new ListItem(linha[1].ToString(), linha[0].ToString());
                    ddCliente.Items.Add(novo);
                }
                //produtos
                DataTable produtos = bd.devolveConsulta("SELECT id,descricao FROM produto");
                if (produtos == null || produtos.Rows.Count == 0)
                {
                    Response.Redirect("produtos.aspx");
                    return;
                }
                foreach (DataRow linha in produtos.Rows)
                {
                    ListItem novo = new ListItem(linha[1].ToString(), linha[0].ToString());
                    ddProduto.Items.Add(novo);
                }
                ddProduto.SelectedIndex = 0;
                ddProduto_SelectedIndexChanged(ddProduto, null);
                //atualizar grelha
                atualizaGrelha();
            }
        }
        //autopostback=true
        protected void ddProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //consultar preço do produto
            string strid = ddProduto.SelectedValue;
            int id = int.Parse(strid);
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id }
            };
            DataTable produto = bd.devolveConsulta("SELECT preco FROM produto WHERE id=@id",parametros);
            tbPreco.Text = produto.Rows[0][0].ToString();
        }
        //registar venda
        protected void Button1_Click(object sender, EventArgs e)
        {
            //validar dados do form
            string stridproduto = ddProduto.SelectedValue;
            string stridcliente = ddCliente.SelectedValue;
            int idproduto = int.Parse(stridproduto);
            int idcliente = int.Parse(stridcliente);
            decimal preco = decimal.Parse(tbPreco.Text);
            float quantidade = float.Parse(tbQuant.Text);
            DateTime data = DateTime.Parse(tbData.Text);

            //adicionar à bd
            bd.adicionarVenda(idcliente, idproduto, preco, quantidade, data);
            //atualizar a grelha
            atualizaGrelha();
        }
        void atualizaGrelha()
        {
            string sql = "SELECT * FROM Venda";

            GridView1.DataSource = bd.devolveConsulta(sql);
            GridView1.DataBind();
        }
    }
}