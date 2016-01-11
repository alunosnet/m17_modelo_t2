using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace M17_Modelo_T2
{
    public partial class clientes : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbData.Text = DateTime.Now.ToShortDateString();
                atualizaGrelha();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //retirar os dados do form
            string nome = tbNome.Text;
            string morada = tbMorada.Text;
            string cp = tbCP.Text;
            string email = tbEmail.Text;
            DateTime data = DateTime.Parse(tbData.Text);

            //guardar na bd
            bd.adicionarCliente(nome, morada, cp, email, data);
            //atualizar grelha
            atualizaGrelha();
            //limpar o form
            tbNome.Text = "";
            tbMorada.Text = "";
            tbEmail.Text = "";
            tbData.Text = DateTime.Now.ToShortDateString();
            tbCP.Text = "";
        }

        private void atualizaGrelha()
        {
            DataTable dados = bd.devolveConsulta("Select * from cliente");
            if (dados == null) return;
            //adicionar coluna só para a data
            DataColumn data = new DataColumn();
            data.DataType = Type.GetType("System.String");
            data.ColumnName = "Data";
            dados.Columns.Add(data);
            //copiar os dados da coluna 5 para a coluna 6
            foreach(DataRow linha in dados.Rows)
            {
                linha[6] = DateTime.Parse(linha[5].ToString()).ToShortDateString();
            }
            //remover a coluna 5
            dados.Columns.RemoveAt(5);

            GridView1.DataSource = dados;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int linha = e.RowIndex;
            string id = GridView1.Rows[linha].Cells[1].Text;

            if (bd.removerCliente(int.Parse(id)) == false)
            {
                Label1.Text = "Não foi possível remover o cliente selecionado";
                Response.Write("<script>alert('Não foi possível remover o cliente')</script>");
            }
            //atualizar grelha
            atualizaGrelha();

        }
        //paginação dos registos
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            atualizaGrelha();
        }
    }
}