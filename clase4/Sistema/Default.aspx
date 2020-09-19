<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Sistema._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sistema</title>
    <style>
        #form1{
            width:767px;
            height:886px;
            margin: auto auto;
            margin-top: auto;
            margin-bottom: auto:
        }
        #body{
            background: #ffffff;
        }
        .auto-style1 {
            width: 401px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="pnlPortada" runat="server" Width="765px" Height="350px">
            <asp:ImageButton ID="btnPortada" ImageUrl="~/imagenes/portada.jpg" ImageAlign="Middle" runat="server" />
        </asp:Panel>
        <asp:Panel ID="pnlLogin" runat="server" Width="765px" Height="350px" Font-Bold="true" ForeColor="Blue" Font-Size="Large" BorderStyle="Solid" Visible="false" >
            <%--Tabla Info Login--%>
            <table style="width:100%">
                <tr>
                    <td>
                        <asp:Label ID="lblVersion" Text="Versión" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="#999999"/>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:Label ID="lblMsgLogin" Text="Ingresa tu Usuario y Contraseña, y presiona ENTRAR" runat="server" Font-Bold="true" Font-Size="X-Large" />
                    </td>
                </tr>
            </table>
            <%--Tabla Datos para Login--%>
            <table style="width:100%">
                <tr>
                    <td>
                        <asp:Label ID="lblUsuario" Text="Usuario: " runat="server"  Font-Bold="true" Font-Size="Large" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsuario" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="10" />
                    </td>
                    <td>
                        <asp:Label ID="lblClave" Text="Contraseña: " runat="server"  Font-Bold="true" Font-Size="Large" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtClave" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="10" TextMode="Password" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnEntrar" ImageUrl="~/imagenes/entrar.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:Label ID="lblErrorLogin" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="text-align:center">
                        <asp:ImageButton ID="btnReenviarClave" ImageUrl="~/imagenes/reenviarclave.png" runat="server" Visible="true" />
                    </td>
                </tr>
            </table>
            <%--Tabla Cerrar Sesion o Volver al Login--%>
            <table style="width:100%">
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnVolverLogin" ImageUrl="~/imagenes/terminarvolver.png" runat="server" Width="259px" Height="68px" />
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </form>
</body>
</html>
