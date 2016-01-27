<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editarproduto.aspx.cs" Inherits="M17_Modelo_T2.editarproduto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lbId" runat="server" Text=""></asp:Label>
    
        <br />
        Descrição:<asp:TextBox ID="tbDesc" runat="server"></asp:TextBox>
        <br />
        Preço:<asp:TextBox ID="tbPreco" runat="server"></asp:TextBox>
        <br />
        Quantidade:<asp:TextBox ID="tbQuant" runat="server"></asp:TextBox>
        <br />
        <asp:Image ID="Image1" runat="server" />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />

        <asp:Button ID="Button1" runat="server" Text="Atualizar" OnClick="Button1_Click" />
    
    </div>
    </form>
</body>
</html>
