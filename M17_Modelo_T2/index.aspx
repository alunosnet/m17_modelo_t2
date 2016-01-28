<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="M17_Modelo_T2.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/jquery-1.12.0.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
    <!--Menu-->
        <nav class="navbar navbar-default">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#minhaBarra">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="index.aspx">PSI</a>
                </div>
                <div class="collapse navbar-collapse" id="minhaBarra">
                    <ul class="nav navbar-nav">
                        <li>
                            <a href="clientes.aspx">Clientes</a>
                        </li>
                        <li>
                            <a href="produtos.aspx">Produtos</a>
                        </li>
                        <li>
                            <a href="venda.aspx">Vendas</a>
                        </li>
                        <%if (Session["nome"] == null)
                            { %>
                            <li>
                                <a href="login.aspx">Login</a>
                            </li>
                        <%} else { %>
                            <li>
                                <a href="logout.aspx">Logout</a>
                            </li>
                        <%} %>
                    </ul>
                </div>
            </div>
        </nav>
    <!--Menu-->
    </div>
    </form>
</body>
</html>
