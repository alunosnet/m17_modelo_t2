<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="produtos.aspx.cs" Inherits="M17_Modelo_T2.produtos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Descrição:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        Preço:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        Quantidade:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        Escolha a imagem do produto
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Adicionar" OnClick="Button1_Click" />
    
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
