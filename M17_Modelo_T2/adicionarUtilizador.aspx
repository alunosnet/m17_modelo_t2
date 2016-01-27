<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adicionarUtilizador.aspx.cs" Inherits="M17_Modelo_T2.adicionarUtilizador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Nome Utilizador:<asp:TextBox ID="tbNome" runat="server"></asp:TextBox>
        <br />
        Palavra passe:<asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        Confirmar palavra passe:<asp:TextBox ID="tbConfirma" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        Perfil:<asp:TextBox ID="tbPerfil" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Adicionar" OnClick="Button1_Click" />
    
    </div>
    </form>
</body>
</html>
