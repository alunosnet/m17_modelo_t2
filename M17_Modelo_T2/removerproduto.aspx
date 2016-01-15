<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="removerproduto.aspx.cs" Inherits="M17_Modelo_T2.removerproduto" %>

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
        <asp:Label ID="lbDescricao" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="lbPreco" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="lbQuantidade" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Remover" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Cancelar" OnClick="Button2_Click" />
    </div>
    </form>
</body>
</html>
