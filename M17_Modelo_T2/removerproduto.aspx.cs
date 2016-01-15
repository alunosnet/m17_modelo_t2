using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;      //datatable
using System.Data.SqlClient;    //sqlparameter

namespace M17_Modelo_T2
{
    public partial class removerproduto : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string strid = Request["id"].ToString();
                    int id = int.Parse(strid);
                    //select à bd com o id recebido
                    string sql = "select * from produto where id=@id";
                    List<SqlParameter> parametros = new List<SqlParameter>()
                    {
                        new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value=id }
                    };
                    DataTable dados = bd.devolveConsulta(sql, parametros);
                    if (dados == null || dados.Rows.Count == 0) throw new Exception("Erro. Produto não existe.");
                    //mostrar os dados ao utilizador
                    lbId.Text = "Id: " + dados.Rows[0][0].ToString();
                    lbDescricao.Text = "Descrição: " + dados.Rows[0][1].ToString();
                    lbPreco.Text = "Preço: " + dados.Rows[0][2].ToString();
                    lbQuantidade.Text = "Quantidade: " + dados.Rows[0][3].ToString();
                }
                catch (Exception erro)
                {
                    Response.Redirect("produtos.aspx");
                }
            }
        }
        //remover
        protected void Button1_Click(object sender, EventArgs e)
        {
            string strid = Request["id"].ToString();
            int id = int.Parse(strid);
            bd.removerProduto(id);
            Response.Redirect("produtos.aspx");
        }
        //cancelar
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("produtos.aspx");
        }
    }
}