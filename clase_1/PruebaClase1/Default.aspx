<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="PruebaClase1._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<asp:Label ID="lblPrueba" runat="server" Text="Label"></asp:Label>
        </div>
    	<p>
			<asp:Button ID="btnClic" runat="server" Text="Clic" />
		</p>
		<p>
			<asp:TextBox ID="txtPrueba" runat="server"></asp:TextBox>
		</p>
    </form>
</body>
</html>
