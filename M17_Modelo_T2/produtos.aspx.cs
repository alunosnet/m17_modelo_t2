using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace M17_Modelo_T2
{
    public partial class produtos : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nome"] == null)
            {
                Response.Redirect("index.aspx?erro=1");
                return;
            }
            if (Session["perfil"].Equals("0") == false)
            {
                Response.Redirect("index.aspx?erro=2");
                return;
            }
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
            //limpar grelha
            GridView1.Columns.Clear();
            DataTable dados = bd.devolveConsulta("SELECT * FROM produto");
            if (dados == null || dados.Rows.Count == 0) return;
            //adicionar coluna remover
            DataColumn cRemover = new DataColumn();
            cRemover.ColumnName = "Remover";
            cRemover.DataType = Type.GetType("System.String");
            dados.Columns.Add(cRemover);

            //adicionar coluna editar
            DataColumn cEditar = new DataColumn();
            cEditar.ColumnName = "Editar";
            cEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(cEditar);

            //associar datatable
            GridView1.DataSource = dados;
            GridView1.AutoGenerateColumns = false;

            //definir as colunas manualmente
            //coluna remover
            HyperLinkField lnkRemover = new HyperLinkField();
            lnkRemover.HeaderText = "Remover";
            lnkRemover.DataTextField = "Remover"; //nome da coluna no datatable
            lnkRemover.Text = "Remover";
            lnkRemover.DataNavigateUrlFormatString = "removerproduto.aspx?id={0}";
            lnkRemover.DataNavigateUrlFields = new string[] {"id" };
            GridView1.Columns.Add(lnkRemover);////////////////////////////////////

            //coluna editar
            HyperLinkField lnkEditar = new HyperLinkField();
            lnkEditar.HeaderText = "Editar";
            lnkEditar.DataTextField = "Editar";
            lnkEditar.Text = "Editar";
            lnkEditar.DataNavigateUrlFormatString = "editarproduto.aspx?id={0}";
            lnkEditar.DataNavigateUrlFields = new string[] { "id" };
            GridView1.Columns.Add(lnkEditar);

            //coluna id
            BoundField bfId = new BoundField();
            bfId.DataField = "id";
            bfId.HeaderText = "Id";
            GridView1.Columns.Add(bfId);

            //coluna descrição
            BoundField bfDesc = new BoundField();
            bfDesc.DataField = "descricao";
            bfDesc.HeaderText = "Descrição";
            GridView1.Columns.Add(bfDesc);

            //coluna preço
            BoundField bfPreco = new BoundField();
            bfPreco.DataField = "preco";
            bfPreco.HeaderText = "Preço";
            GridView1.Columns.Add(bfPreco);

            //coluna quantidade
            BoundField bfQuant = new BoundField();
            bfQuant.DataField = "quantidade";
            bfQuant.HeaderText = "Quantidade";
            GridView1.Columns.Add(bfQuant);

            //Imagem
            ImageField imagem = new ImageField();
            imagem.DataImageUrlFormatString = "~/Imagens/{0}.jpg";
            imagem.DataImageUrlField = "id";
            imagem.HeaderText = "Imagem";
            imagem.ControlStyle.Width = 100;
            GridView1.Columns.Add(imagem);

            //refresh/bind
            GridView1.DataBind();
        }
    }
}