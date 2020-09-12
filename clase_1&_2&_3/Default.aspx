<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="PruebaClase1._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Prueba de Reloj</title>
    <!--Script para el Reloj-->
    <script>
        var timerId = null;
        var timerCorre = false;

        function stopClock() {
            if (timerCorre) {
                clearTimeout(timerId);
                timerCorre = false;
            }
        }
        function mostrarHora() {
            /**Instanciamos el Objeto Date() 
             * sin pasarle parámetros se inicializa a la fecha y hora actuales
             *Guardamos en "ahora"
             */
            var ahora = new Date();
            /**Obtenemos solo la Hora*/
            var horas = ahora.getHours();
            /**Obtenemos solo los Minutos*/
            var minutos = ahora.getMinutes();
            /**Obtenemos solo los Segundos*/
            var segundos = ahora.getSeconds();
            /**Para obtener la hora en formato 12hs */
            var valorHora = "" + ((horas > 12) ? horas -12 : horas)
            if (valorHora == "0") {
                valorHora = 12;
            }
            /**Para simpre tener dos digitos en los Minutos y Segundos
             *Cuando esta entre el 0 y el 9 le conctenamos un 0
             * asi simpre tenemos dos digitos
             */
            valorHora += ((minutos < 10) ? ":0" : ":") + minutos
            valorHora += ((segundos < 10) ? ":0" : ":") + segundos
            /**Para ver si nos encontramos en PM o AM*/
            valorHora += (horas >= 12) ? " P.M." : " A.M."
            /**Le asignamos el valor al Label con ID "lblHora" */
            document.getElementById('lblHora').innerText = valorHora;

            /**Para despues llamar la funcion en un intervalo de tiempo*/
            timerId = setTimeout("mostrarHora()", 1000);
            timerCorre = true;
        }
        function startClock() {
            stopClock();
            mostrarHora();
        }
    </script>
    <!--Fin Script para el Reloj-->
</head>
<body onload="startClock()">
    <form id="form1" runat="server">
        <div>
        	<asp:Label ID="lblHora" runat="server" Text="Hora"></asp:Label>
            <br />
            <br />
        	<asp:Label ID="lblPrueba" runat="server" Text="Label"></asp:Label>
        </div>
    	<p>
			<asp:Button ID="btnClic" runat="server" Text="Clic" />
		</p>
		<p>
			<asp:TextBox ID="txtPrueba" runat="server"></asp:TextBox>
		</p>
        <p>
            <asp:Button ID="btnClientes" runat="server" Text="Ver Clientes" style="height: 26px" />
        </p>
        <p>
           <asp:Button ID="btnGoogle" runat="server" Text="Google" />
        </p>

        <asp:ListBox ID="lstLista" runat="server" AutoPostBack="True" Width="84px">
            <asp:ListItem Value="https://github.com/">GitHub</asp:ListItem>
            <asp:ListItem Value="https://es.stackoverflow.com/">StackOverflow</asp:ListItem>
            <asp:ListItem Value="https://mail.google.com/mail/u/0/#inbox">Gmail</asp:ListItem>
        </asp:ListBox>
        <br />
        <asp:Button ID="btnPDF" runat="server" Text="Clase 3" />

    </form>
</body>
</html>
