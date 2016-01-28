using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17_Modelo_T2
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["aviso"] as HttpCookie;
            if (cookie != null)
            {
                if (cookie.Value == "mostrado")
                {
                    div_cookies.Visible = false;
                }
                else
                {
                    cookie = new HttpCookie("aviso", "mostrado");
                    cookie.Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Add(cookie);
                }
            }
            else
            {
                cookie = new HttpCookie("aviso", "mostrado");
                cookie.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(cookie);
            }
            if (Request["erro"] != null)
            {
                int erro=int.Parse(Request["erro"].ToString());
                switch (erro)
                {
                    case 1:
                        Response.Write("<script>alert('Tem de iniciar sessão')</script>");
                        break;
                    case 2:
                        Response.Write("<script>alert('Página só para o admin')</script>");
                        break;
                }
                //Request.Browser.Browser
            }
        }
    }
}