﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientes.aspx.cs" Inherits="M17_Modelo_T2.clientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Nome:<asp:TextBox ID="tbNome" runat="server"></asp:TextBox>
        <br />
        Morada:<asp:TextBox ID="tbMorada" runat="server"></asp:TextBox>
        <br />
        Código Postal:<asp:TextBox ID="tbCP" runat="server"></asp:TextBox>
        <br />
        Email:<asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
        <br />
        Data Nascimento:<asp:TextBox ID="tbData" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Adicionar" OnClick="Button1_Click" />
        <br />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateDeleteButton="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
