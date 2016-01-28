using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace M17_Modelo_T2
{
    public partial class login : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nome"] != null)
                Response.Redirect("index.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //validar login
            string nome = TextBox1.Text;
            string password = TextBox2.Text;
            DataTable utilizador = bd.verificarLogin(nome, password);
            if (utilizador == null)
            {
                Label1.Text = "Login falhou. Tente novamente.";
                return;
            }
            //iniciar sessão
            Session["nome"] = utilizador.Rows[0][0].ToString();
            Session["perfil"] = utilizador.Rows[0][2].ToString();
            //redirect

        }
    }
}