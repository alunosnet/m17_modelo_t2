using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17_Modelo_T2
{
    public partial class produtos : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                atualizarGrelha();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string desc = TextBox1.Text;
            decimal preco = decimal.Parse(TextBox2.Text);
            float quantidade = float.Parse(TextBox3.Text);

            int id=bd.adicionarProduto(desc, preco, quantidade);
            //guardar a imagem
            if (FileUpload1.HasFile == true)
            {
                if (FileUpload1.PostedFile.ContentLength > 0)
                {
                    string ficheiro = Server.MapPath(@"~\Imagens");
                    ficheiro += @"\" + id + ".jpg";
                    FileUpload1.SaveAs(ficheiro);
                }
            }

            atualizarGrelha();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }

        void atualizarGrelha()
        {
            GridView1.DataSource = bd.devolveConsulta("select * from produto");
            GridView1.DataBind();
        }
    }
}