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
            margin-bottom: auto;
        }
        #body{
            background: #ffffff;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <%--Panel Portada--%>
        <asp:Panel ID="pnlPortada" runat="server" Width="765px" Height="350px">
            <asp:ImageButton ID="btnPortada" ImageUrl="~/imagenes/portada.jpg" ImageAlign="Middle" runat="server" />
        </asp:Panel>
         <%--Panel Login--%>
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
                    <td colspan="5" style="text-align:center">
                        <asp:Label ID="lblErrorLogin" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="text-align:center">
                        <asp:ImageButton ID="btnReenviarClave" ImageUrl="~/imagenes/reenviarclave.png" runat="server" Visible="true" />
                        <asp:Label ID="lblReenviarClave" Text="" runat="server"  Visible="false" Font-Bold="true" ForeColor="Blue"/>
                    </td>
                </tr>
            </table>
            <%--Tabla Cerrar Sesion o Volver al Login--%>
            <table style="width:100%">
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnVolverLogin" ImageUrl="~/imagenes/terminarvolver.png" runat="server" Width="259px" Height="68px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
         <%--Panel Menu Login--%>
        <asp:Panel ID="pnlLoginMenu" runat="server" Width="767px" Height="392px" Font-Bold="True" ForeColor="Blue" Font-Size="Large" BorderStyle="Solid" Visible="false">
            <table style="width:100%">
                <tr>
                    <td style="text-align:center">
                        <asp:Image ImageUrl="~/imagenes/registrate.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnRegistrarse" ImageUrl="~/imagenes/registrateaqui.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnIrLogin" ImageUrl="~/imagenes/yaregistrado.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnRegistrarseVolverLoginU13" ImageUrl="~/imagenes/terminarvolver.png" runat="server" Width="259px" Height="68px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
         <%--Panel Registrarse--%>
        <asp:Panel ID="pnlRegistrarse" runat="server" Height="850px" BackColor="#66CCFF" ForeColor="#372C57" Font-Size="Large" Visible="false">
            <%--Tabla Titulos de Registro e Informacion--%>
            <table style="width:100%">
                <tr>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:Image ImageUrl="~/imagenes/registrarsetitulo.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:justify">
                        <p>
                        Para Poder registrarte debés ser mayor de 18 años, residir en Argentina y contar con documento válido en Argentina que acredite tu identidad.
                        </p>
                        <p>
                            Sólo se pude hacer un resgistro por documento. Los datos deben ser reales, correctos y vigintes.
                        </p>
                        <p>
                            Todos los datos a continuación (menos Origen) son Obligarios.
                        </p>
                    </td>
                </tr>
            </table>
             <%--Tabla Datos para Registro--%>
            <table style="width:100%">
                 <%--Campos y Validacion Nombres--%>
                <tr>
                    <td>Tu/s Nombre/s:</td>
                    <td>
                      <asp:TextBox ID="txtNombreU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="20" Width="262px" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorNombreU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Apellidos--%>
                <tr>
                    <td>Apellido/s:</td>
                    <td>
                      <asp:TextBox ID="txtApellidoU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="20" Width="262px" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorApellidoU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Lista Desplegable para el Tipo de Documento--%>
                <tr>
                    <td>Tipo de Doc.:</td>
                    <td>
        
                        <asp:DropDownList ID="ddlTipoDocU" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="White" BackColor="#382858" Height="28px" Width="279px">
                            <asp:ListItem Value="DNI" Text="Doc. Nacional de Identidad" />
                            <asp:ListItem Value="LC" Text="Libreta Cívica" />
                            <asp:ListItem Value="LE" Text="Libreta de Enrolamiento" />
                        </asp:DropDownList>
                    </td>
                    <td style="text-align:center">
                    </td>
                </tr>
                <%--Campos y Validacion Numero de Doc.--%>
                <tr>
                    <td>Nº de Doc. (sin puntos ni espacios):</td>
                    <td>
                      <asp:TextBox ID="txtDocU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="8" Width="262px" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorDocU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Fecha de Nacimiento y Edad.--%>
                <tr>
                    <td>Fecha de Nac. (ddmmaa):</td>
                    <td>
                      <asp:TextBox ID="txtFechaNac" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="6" Width="150px" />
                        <asp:Label ID="lblFechaNacU" Text="" runat="server" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorFechaNacU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Email.--%>
                <tr>
                    <td>Email Válido para Notificaciones:</td>
                    <td>
                      <asp:TextBox ID="txtEmailU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="70" Width="262px" Rows="2" TextMode="MultiLine" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorEmailU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Lista Desplegable para el Provincia--%>
                <tr>
                    <td>Provincia:</td>
                    <td>
                        <asp:DropDownList ID="ddlProvU" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="White" BackColor="#382858" Width="276px">
                            <asp:ListItem Value="1" Text="Buenos Aires" />
                            <asp:ListItem Value="2" Text="Catamarca" />
                            <asp:ListItem Value="3" Text="Chaco" />
                            <asp:ListItem Value="4" Text="Chubut" />
                            <asp:ListItem Value="5" Text="CABA" />
                            <asp:ListItem Value="6" Text="Córdoba" />
                            <asp:ListItem Value="7" Text="Corrientes" />
                            <asp:ListItem Value="8" Text="Entre Ríos" />
                            <asp:ListItem Value="9" Text="Formosa" />
                            <asp:ListItem Value="10" Text="Jujuy" />
                            <asp:ListItem Value="11" Text="La Pampa" />
                            <asp:ListItem Value="12" Text="La Rioja" />
                            <asp:ListItem Value="12" Text="La Rioja" />
                            <asp:ListItem Value="13" Text="Mendoza" />
                            <asp:ListItem Value="14" Text="Misiones" />
                            <asp:ListItem Value="15" Text="Neuquén" />
                            <asp:ListItem Value="16" Text="Río Negro" />
                            <asp:ListItem Value="17" Text="Salta" />
                            <asp:ListItem Value="18" Text="San Juan" />
                            <asp:ListItem Value="19" Text="San Luis" />
                            <asp:ListItem Value="20" Text="Santa Cruz" />
                            <asp:ListItem Value="21" Text="Santa Fe" />
                            <asp:ListItem Value="22" Text="Santiago del Estero" />
                            <asp:ListItem Value="23" Text="Tucumán" />
                            <asp:ListItem Value="24" Text="Tierra del Fuego" />
                        </asp:DropDownList>
                    </td>
                    <td style="text-align:center">
                    </td>
                </tr>
                <%--Campos y Validacion Localidad--%>
                <tr>
                    <td>Localidad:</td>
                    <td>
                      <asp:TextBox ID="txtLocalidadU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="25" Width="262px" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorLocalidadU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Direccion.--%>
                <tr>
                    <td>Dirección:</td>
                    <td>
                      <asp:TextBox ID="txtDireccionU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="100" Width="262px" Rows="2" TextMode="MultiLine" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorDireccionU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Telefono--%>
                <tr>
                    <td>Teléfono (agregue carateristica):</td>
                    <td>
                      <asp:TextBox ID="txtTelefonoU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="25" Width="262px" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorTelefonoU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Usuario--%>
                <tr>
                    <td>Usuario:</td>
                    <td>
                      <asp:TextBox ID="txtUsuarioU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="10" Width="262px"/>
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorUsuarioU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Contraseña--%>
                <tr>
                    <td>Contraseña:</td>
                    <td>
                      <asp:TextBox ID="txtClaveU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="10" Width="262px" TextMode="Password" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorClaveU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Repetir Contraseña--%>
                <tr>
                    <td>Repetir Contraseña:</td>
                    <td>
                      <asp:TextBox ID="txtClaveRepeatU" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="10" Width="262px" TextMode="Password" />
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="lblErrorClaveRepeatU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Todos los Errores--%>
                <tr>
                    <td colspan="3" style="text-align:center">
                        <asp:Label ID="lblErroresU" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
            </table>
            <%--Tabla Botones --%>
            <table style="width:100%">
                <tr style="text-align:center">
                    <td>
                        <asp:ImageButton ID="btnRegistrarseU" ImageUrl="~/imagenes/registrarse.png" runat="server" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnCancelarVolverU" ImageUrl="~/imagenes/cancelarvolver.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Bienvenido--%>
        <asp:Panel ID="pnlBienvenido" runat="server" BorderColor="#66CCFF" Height="535px" ForeColor="#372c57" Font-Size="Large" Visible="false">
            <%--Tabla Bienvenida para al Registrarse --%>
            <table style="width:100%">
                <tr>
                    <td style="text-align:justify">
                        <asp:Label ID="lblBienvenido" Text="" runat="server"  Visible="false" />
                        <p>Ya estás anotado en los cursos de ASP .NET!</p>
                        <p></p>
                        <p>Nos alegra mucho que estés con nosotros . El Equipo de Cursos de Martin</p>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnRegistrarseVolverLoginU" ImageUrl="~/imagenes/todook.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Area Usuario--%>
        <asp:Panel ID="pnlAreaUsuario" runat="server" BorderColor="#66CCFF" Height="535px" ForeColor="#372c57" Font-Size="Large" Visible="false">
            <table style="width:100%">
                <tr>
                    <td style="text-align:center">
                        <asp:Label ID="lblBienvenidoAreaU" Text="Bienvenido/a" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="#000000" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnAhoraQueHago" ImageUrl="~/imagenes/ahora_que_hago.png" runat="server" />
                        <p>Desde acá vas a poder hacer varias cosas relacionadas con tu cuenta en ASP.NET</p>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnHacerPedido" ImageUrl="~/imagenes/hacerpedido.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnVerHistorico" ImageUrl="~/imagenes/vertodosmov.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnModificarDatos" ImageUrl="~/imagenes/modificardatos.png" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnVolverLoginU1" ImageUrl="~/imagenes/terminarvolver.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Ahora que Hago--%>
        <asp:Panel ID="pnlAhoraQueHago" runat="server" BorderColor="#66CCFF" Height="535px" ForeColor="#372c57" Font-Size="Large" Visible="false">
            <table style="width: 100%">
                <tr>
                    <td style="text-align: center">
                        <asp:Label ID="lblTeCuento" Text="Te Cuento un Poco" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="#000000" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:justify">
                        <p>Ya estás anotado en los cursos de ASP .NET!</p>
                        <p></p>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc mi velit, congue ac quam sed, congue iaculis sapien. Pellentesque nunc augue, imperdiet ut metus eget, facilisis finibus sapien. Aenean lobortis ex sit amet massa rhoncus, congue tempor nibh fermentum. Phasellus at metus et libero blandit consectetur. Mauris sit amet eros ac lectus sollicitudin sollicitudin sit amet a risus. Sed eu pellentesque orci. In imperdiet mattis volutpat. Maecenas semper tortor eu nunc ultricies, ac eleifend enim varius. Duis porttitor facilisis metus, vel fringilla diam pretium nec. Nam molestie quam ut quam volutpat aliquet ut a ex. </p>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="btnVolverU2" ImageUrl="~/imagenes/terminarvolver.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--Panel Ahora que Hago--%>
        <asp:Panel ID="pnlCambiarDatosPersonales" runat="server" BorderColor="#66CCFF" Height="489px" ForeColor="#372c57" Font-Size="Large" Visible="false" BackImageUrl="~/imagenes/datospersonales.jpg">
            <%--Tabla Datos para Registro--%>
            <table style="width: 100%">
                <%--Campos y Validacion Email.--%>
                <tr>
                    <td>Email Válido para Notificaciones:</td>
                    <td>
                        <asp:TextBox ID="txtEmailUedit" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="70" Width="262px" Rows="2" TextMode="MultiLine" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorEmailUedit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Lista Desplegable para el Provincia--%>
                <tr>
                    <td>Provincia:</td>
                    <td>
                        <asp:DropDownList ID="ddlProvUedit" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="White" BackColor="#382858" Width="276px">
                            <asp:ListItem Value="1" Text="Buenos Aires" />
                            <asp:ListItem Value="2" Text="Catamarca" />
                            <asp:ListItem Value="3" Text="Chaco" />
                            <asp:ListItem Value="4" Text="Chubut" />
                            <asp:ListItem Value="5" Text="CABA" />
                            <asp:ListItem Value="6" Text="Córdoba" />
                            <asp:ListItem Value="7" Text="Corrientes" />
                            <asp:ListItem Value="8" Text="Entre Ríos" />
                            <asp:ListItem Value="9" Text="Formosa" />
                            <asp:ListItem Value="10" Text="Jujuy" />
                            <asp:ListItem Value="11" Text="La Pampa" />
                            <asp:ListItem Value="12" Text="La Rioja" />
                            <asp:ListItem Value="12" Text="La Rioja" />
                            <asp:ListItem Value="13" Text="Mendoza" />
                            <asp:ListItem Value="14" Text="Misiones" />
                            <asp:ListItem Value="15" Text="Neuquén" />
                            <asp:ListItem Value="16" Text="Río Negro" />
                            <asp:ListItem Value="17" Text="Salta" />
                            <asp:ListItem Value="18" Text="San Juan" />
                            <asp:ListItem Value="19" Text="San Luis" />
                            <asp:ListItem Value="20" Text="Santa Cruz" />
                            <asp:ListItem Value="21" Text="Santa Fe" />
                            <asp:ListItem Value="22" Text="Santiago del Estero" />
                            <asp:ListItem Value="23" Text="Tucumán" />
                            <asp:ListItem Value="24" Text="Tierra del Fuego" />
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: center"></td>
                </tr>
                <%--Campos y Validacion Localidad--%>
                <tr>
                    <td>Localidad:</td>
                    <td>
                        <asp:TextBox ID="txtLocalidadUedit" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="25" Width="262px" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorLocalidadUedit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Direccion.--%>
                <tr>
                    <td>Dirección:</td>
                    <td>
                        <asp:TextBox ID="txtDireccionUedit" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="100" Width="262px" Rows="2" TextMode="MultiLine" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorDireccionUedit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Telefono--%>
                <tr>
                    <td>Teléfono (agregue carateristica):</td>
                    <td>
                        <asp:TextBox ID="txtTelefonoUedit" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="25" Width="262px" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorTelefonoUedit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Usuario--%>
                <tr>
                    <td>Usuario:</td>
                    <td>
                        <asp:TextBox ID="txtUsuarioUedit" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="10" Width="262px" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorUsuarioUedit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Campos y Validacion Contraseña--%>
                <tr>
                    <td>Contraseña:</td>
                    <td>
                        <asp:TextBox ID="txtClaveUedit" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="White" BackColor="#382858" MaxLength="10" Width="262px" />
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblErrorClaveUedit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
                <%--Todos los Errores--%>
                <tr>
                    <td colspan="3" style="text-align: center">
                        <asp:Label ID="lblErrorEdit" Text="" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" />
                    </td>
                </tr>
            </table>
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnCambiarDatos" ImageUrl="~/imagenes/cambiarlosdatos.png" runat="server" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnCancelarVolverEdit" ImageUrl="~/imagenes/cancelarvolver.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlDatosModificadosOk" runat="server" BorderColor="#66CCFF" Height="489px" ForeColor="#372c57" Font-Size="Large" Visible="false" BackImageUrl="~/imagenes/datospersonales.jpg">
            <%--Tabla Botones --%>
            <table style="width: 100%">
                <tr style="text-align: center">
                    <td>
                    </td>
                </tr>                
                <tr style="text-align: center">
                    <td></td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:Label ID="lblDatosModificadosOk" Text="Tus Datos han sido Modificados Correctamente" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="#000000" />

                    </td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:ImageButton ID="btnVolverAreaUsuario" ImageUrl="~/imagenes/volveratuarea.png" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </form>
</body>
</html>
