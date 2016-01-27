using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17_Modelo_T2
{
    public partial class adicionarUtilizador : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //confirmar password
            if (tbPassword.Text != tbConfirma.Text)
            {
                Response.Write("<script>alert('As palavras passes não são iguais.')</script>");
                return;
            }
            //adicionar à bd
            string nome = tbNome.Text;
            string password = tbPassword.Text;
            int perfil = int.Parse(tbPerfil.Text);
            bd.adicionarUtilizador(nome, password, perfil);
        }
    }
}