using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace M17_Modelo_T2
{
    public partial class editarproduto : System.Web.UI.Page
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
                    //dados do produto
                    string sql = "select * from produto where id=@id";
                    List<SqlParameter> parametros = new List<SqlParameter>()
                    {
                        new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value=id }
                    };
                    DataTable dados = bd.devolveConsulta(sql, parametros);
                    if (dados == null || dados.Rows.Count == 0) throw new Exception("Erro. Produto não existe.");
                    //mostrar dados
                    lbId.Text = dados.Rows[0][0].ToString();
                    tbDesc.Text = dados.Rows[0][1].ToString();
                    tbPreco.Text = dados.Rows[0][2].ToString();
                    tbQuant.Text = dados.Rows[0][3].ToString();
                    //imagem
                    string ficheiro = @"~\Imagens\" + dados.Rows[0][0].ToString() + ".jpg";
                    Image1.ImageUrl = ficheiro;
                    Image1.Width = 100;
                }
                catch (Exception erro)
                {
                    Debug.WriteLine(erro.Message);
                    Response.Redirect("produtos.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //validar dados do form
            string strid = Request["id"].ToString();
            int id = int.Parse(strid);
            string descricao = tbDesc.Text;
            decimal preco = decimal.Parse(tbPreco.Text);
            float quantidade = float.Parse(tbQuant.Text);

            //atualizar bd
            bd.atualizarProduto(id, descricao, preco, quantidade);
            //atualizar imagem
            if (FileUpload1.HasFile == true)
            {
                if (FileUpload1.PostedFile.ContentLength > 0)
                {
                    string ficheiro = Server.MapPath(@"~\Imagens");
                    ficheiro += @"\" + id + ".jpg";
                    FileUpload1.SaveAs(ficheiro);
                }
            }
            //redirect
            Response.Redirect("produtos.aspx");
        }
    }
}