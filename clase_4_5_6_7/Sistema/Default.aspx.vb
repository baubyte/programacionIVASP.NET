'Clases de Input Output, para el Manejo de Archivos
Imports System.IO
'Clases para ADO, para la Conexion con la DB
Imports System.Data
Imports System.Data.SqlClient
'System.Globalization
Imports System.Globalization
'Clases para Envio y Recepcion de Mails.
Imports System.Net.Mail
Public Class _Default
    Inherits System.Web.UI.Page
    Public x As Integer
    Public connectionstring As String = ConfigurationManager.ConnectionStrings(ConfigurationManager.AppSettings("Conexion")).ToString()
    Public EmailActivo As String = ConfigurationManager.AppSettings("EmailActivo")
    Public Email As String = ConfigurationManager.AppSettings(EmailActivo)
    Public EmailPass As String = ConfigurationManager.AppSettings(EmailActivo & "Pass")
    Dim con As New SqlConnection(connectionstring)
    Dim ar As String
    Protected Sub btnPortada_Click(sender As Object, e As ImageClickEventArgs) Handles btnPortada.Click
        pnlPortada.Visible = False
        pnlLoginMenu.Visible = True
    End Sub

    Protected Sub btnVolverLogin_Click(sender As Object, e As ImageClickEventArgs) Handles btnVolverLogin.Click
        pnlPortada.Visible = True
        pnlLogin.Visible = False
    End Sub

    Protected Sub btnRegistrarse_Click(sender As Object, e As ImageClickEventArgs) Handles btnRegistrarse.Click
        pnlLoginMenu.Visible = False
        pnlRegistrarse.Visible = True
    End Sub

    Protected Sub btnRegistrarseVolverLoginU13_Click(sender As Object, e As ImageClickEventArgs) Handles btnRegistrarseVolverLoginU13.Click
        pnlLoginMenu.Visible = False
        pnlPortada.Visible = True
    End Sub

    Protected Sub btnRegistrarseU_Click(sender As Object, e As ImageClickEventArgs) Handles btnRegistrarseU.Click
        Dim ok As Boolean = True
        'Llamamos a la Funcion para Limpiar los Errores
        limpiarErroresRegistroU()
        'Comprobamos el Nombre
        txtNombreU.Text = txtNombreU.Text.Trim().ToUpper
        If comprobar(txtNombreU.Text) = False Then
            arreglarCampo(txtNombreU)
            ok = False
            lblErrorNombreU.Text = "El Nombre contenía caracteres inválidos, fueron quitados"
            lblErrorNombreU.Visible = True
        End If
        'Comprobamos el Apellido
        txtApellidoU.Text = txtApellidoU.Text.Trim().ToUpper
        If comprobar(txtApellidoU.Text) = False Then
            arreglarCampo(txtApellidoU)
            ok = False
            lblErrorApellidoU.Text = "El Apellido contenía caracteres inválidos, fueron quitados"
            lblErrorApellidoU.Visible = True
        End If
        'Comprobamos el DNI
        txtDocU.Text = txtDocU.Text.Trim()
        If comprobar(txtDocU.Text) = False Or Not IsNumeric(txtDocU.Text) Then
            soloNumeros(txtDocU)
            ok = False
            lblErrorDocU.Text = "El Documento no era válido, se ajustó a número "
            lblErrorDocU.Visible = True
        End If
        'Comprobamos el Email
        arreglarCampo(txtEmailU)
        If validateEmail(txtEmailU.Text) = False Then
            ok = False
            lblErrorEmailU.Text = "El Email no es válido."
            lblErrorEmailU.Visible = True
        End If
        'Coprobamos la Fecha de Nacimiento y la Edad
        Dim FechaNacimiento As Date
        ControlDeNacimiento(txtFechaNac, ok, lblErrorFechaNacU, lblFechaNacU, True, FechaNacimiento)
        'Comprobamos La Localidad
        txtLocalidadU.Text = txtLocalidadU.Text.Trim().ToUpper
        If comprobar(txtLocalidadU.Text) = False Then
            arreglarCampo(txtLocalidadU)
            ok = False
            lblErrorLocalidadU.Text = "La Localidad contenía caracteres inválidos, fueron quitados"
            lblErrorLocalidadU.Visible = True
        End If
        'Comprobamos La Direccion
        txtDireccionU.Text = txtDireccionU.Text.ToUpper
        If comprobar(txtDireccionU.Text) = False Then
            arreglarCampo(txtDireccionU)
            ok = False
            lblErrorDireccionU.Text = "La Direccion contenía caracteres inválidos, fueron quitados"
            lblErrorDireccionU.Visible = True
        End If
        'Comprobamos el Telefono
        txtTelefonoU.Text = txtTelefonoU.Text.Trim()
        If comprobar(txtTelefonoU.Text) = False Or Not IsNumeric(txtTelefonoU.Text) Then
            soloNumeros(txtTelefonoU)
            ok = False
            lblErrorTelefonoU.Text = "El Telefono no era válido, se ajustó a número "
            lblErrorTelefonoU.Visible = True
        End If
        'Comprobamos el Usuario
        txtUsuarioU.Text = txtUsuarioU.Text.Trim().ToUpper
        If comprobar(txtUsuarioU.Text) = False Or txtUsuarioU.Text.IndexOf(" ") > -1 Then
            txtUsuarioU.Text = txtUsuarioU.Text.Replace(" ", "")
            arreglarCampo(txtUsuarioU)
            ok = False
            lblErrorUsuarioU.Text = "El Usuario contenía caracteres inválidos, fueron quitados."
            lblErrorUsuarioU.Visible = True
        End If
        If txtUsuarioU.Text.Length < 5 Then
            ok = False
            lblErrorUsuarioU.Text = "El Usuario debe tener de 5 a 10 Caracteres, letras y/o Números."
            lblErrorUsuarioU.Visible = True
        End If
        'Comprobamos la Contraseña
        txtClaveU.Text = txtClaveU.Text.Trim()
        If comprobar(txtClaveU.Text) = False Or txtClaveU.Text.IndexOf(" ") > -1 Then
            txtClaveU.Text = txtClaveU.Text.Replace(" ", "")
            arreglarCampo(txtClaveU)
            ok = False
            lblErrorClaveU.Text = "L a Contraseña contenía caracteres inválidos.Prueba con Letras y Números."
            lblErrorClaveU.Visible = True
        End If
        If txtClaveU.Text.Length < 5 Then
            ok = False
            lblErrorClaveU.Text = "L a Contraseña debe tener de 5 a 10 Caracteres, letras y/o Números."
            lblErrorClaveU.Visible = True
        End If
        'Comprobamos la Segunda Contraseña
        txtClaveRepeatU.Text = txtClaveRepeatU.Text.Trim()
        If comprobar(txtClaveRepeatU.Text) = False Or txtClaveRepeatU.Text.IndexOf(" ") > -1 Then
            txtClaveRepeatU.Text = txtClaveRepeatU.Text.Replace(" ", "")
            arreglarCampo(txtClaveRepeatU)
            ok = False
            lblErrorClaveRepeatU.Text = "La Segunda Contraseña contenía caracteres inválidos.Prueba con Letras y Números."
            lblErrorClaveRepeatU.Visible = True
        End If
        If txtClaveU.Text <> txtClaveRepeatU.Text Then
            ok = False
            lblErrorClaveRepeatU.Text = "No Coinciden las Contraseñas."
            lblErrorClaveRepeatU.Visible = True
        End If
        'Si existen Errores los Mostramos el lblErroresU
        If ok = False Then
            lblErroresU.Text = "Surgieron Errores por favor Revisalos e Intenta de Nuevo."
            lblErroresU.Visible = True
            Exit Sub
        End If
        'Creamos las Distintas Sesiones
        Session("Usuario") = txtUsuarioU.Text
        Session("Password") = txtClaveU.Text
        Session("TipoDocumento") = ddlTipoDocU.SelectedValue.Trim
        Session("Documento") = txtDocU.Text.Trim
        'Comprobamos si Existe en la DB
        If YaExisteSql("SELECT idusuario FROM usuarios WHERE usuario='" & Session("Usuario") & "'") Then
            ok = False
            lblErrorUsuarioU.Text = "El usuario elegido ya existe. Prueba con otro."
            lblErrorUsuarioU.Visible = True
        End If
        If YaExisteSql("SELECT idusuario FROM usuarios WHERE Documento= '" & Session("Documento") & "'and tdoc= '" & Session("TipoDocumento") & "'") Then
            ok = False
            lblErrorDocU.Text = "Ya existe el " & Session("TipoDocumento") & " " & Session("Documento") & "."
            lblErrorDocU.Visible = True
        End If
        If ok = False Then
            lblErroresU.Text = "Solo se permite una inscripción por persona."
            lblErroresU.Visible = True
            Exit Sub
        End If
        Session("Usuario") = txtUsuarioU.Text.ToLower
        Session("Password") = txtClaveU.Text
        Session("TipoDocumento") = ddlTipoDocU.SelectedValue.Trim
        Session("Documento") = txtDocU.Text.Trim
        Session("ApellidoYNombre") = txtNombreU.Text.Trim & " " & txtApellidoU.Text.Trim
        Session("Email") = txtEmailU.Text.Trim
        limpiarErroresRegistroU()
        'Si pasa la Validacion lo Insertanos en la DB
        If SqlAccion("INSERT INTO Usuarios (Apellido, Nombre, tDoc , Documento, Usuario, Clave, Email, idProv , Localidad,Domicilio, Telefono, fNacimiento) VALUES ( '" & txtApellidoU.Text.Trim & "','" & txtNombreU.Text.Trim & "', '" & Session("TipoDocumento") & "','" & Session("Documento") & "','" & Session("Usuario") & "', '" & Session("Password") & "' , '" & Session("Email") & "'," & ddlProvU.SelectedValue & ", '" & txtLocalidadU.Text.Trim & "' , '" & txtDireccionU.Text.Trim & "','" & txtTelefonoU.Text.Trim & "','" & FechaNacimiento.ToString("yyyy-MM-dd") & " ' ) ") = False Then
            lblErroresU.Text = "Se ha producido un error al querer guardar tus datos."
            lblErroresU.Visible = True
            Exit Sub
        End If
        Session("idUsuario") = Vnum(LeeUnCampo("SELECT TOP 1 idUsuario FROM usuarios WHERE Usuario='" & Session("Usuario") & "'and Clave='" & Session("Password") & "' ", "idUsuario"))
        lblBienvenido.Text = "Bienvenido " & Session("ApellidoYNombre") & "!!!"
        Dim mensaje As String, xusuario As String = Session("ApellidoYNombre"), en As String = Chr(13) & Chr(10)
        mensaje = "Bienvenido " & xusuario & " a los Cursos de ASP .NET!." & en & en & "Te damos una cordial bienvenida al a comunidad de ASP.NET !." & en & en & "Tu usuario es " & " " & Session("Usuario") & " " & en & en & "Tu clave es " & " " & Session("Password") & " " & en & en & "Ya podés loguearte para ver tus datos! !." & en & en
        limpiarCamposRegistroU()
        pnlRegistrarse.Visible = False
        pnlBienvenido.Visible = True
        btnRegistrarseVolverLoginU.Focus()
    End Sub

    Protected Sub btnReenviarClave_Click(sender As Object, e As ImageClickEventArgs) Handles btnReenviarClave.Click

    End Sub

    Protected Sub btnIrLogin_Click(sender As Object, e As ImageClickEventArgs) Handles btnIrLogin.Click
        pnlLoginMenu.Visible = False
        pnlLogin.Visible = True
    End Sub

    Protected Sub btnCancelarVolverU_Click(sender As Object, e As ImageClickEventArgs) Handles btnCancelarVolverU.Click
        limpiarCamposRegistroU()
        pnlLoginMenu.Visible = True
        pnlRegistrarse.Visible = False
    End Sub

    Protected Sub btnRegistrarseVolverLoginU_Click(sender As Object, e As ImageClickEventArgs) Handles btnRegistrarseVolverLoginU.Click
        pnlBienvenido.Visible = False
        pnlLogin.Visible = True
        txtUsuario.Text = Session("Usuario")
        txtClave.Text = Session("Password")
    End Sub
#Region "Limpiar Campos"
    'Funcion para limpiar los campos del Fomulario
    Sub arreglarCampo(ByRef campo As TextBox)
        campo.Text = campo.Text.Trim.Replace("'", "").Replace("""", "").Replace("*", "").Replace("+", "").Replace("-", "").Replace("/", "").Replace(": ", "").Replace("' ", "").Replace("<", "").Replace(">", "").Replace("=", "").Replace("&", "")
    End Sub
#End Region
#Region "Evitar SQL Injection"
    'Funcion para Evitar el SQL Injection
    Function comprobar(ByVal user As String) As Boolean
        If user Is System.DBNull.Value Then
            Return False
        Else
            Dim aux As Boolean = True
            Dim listanegra, x As String
            listanegra = "'*+-/:;'><&" & """"
            If user <> "" Then
                For Each x In user
                    If aux = True Then
                        If InStr(1, listanegra, x) > 0 Then
                            aux = False
                        Else
                            aux = True
                        End If
                    Else
                        Return False
                    End If
                Next
                If aux = True Then
                    Return True
                End If
            Else
                Return False
            End If
        End If
    End Function
#End Region
#Region "Limpiar Errores Registro"

    'Funcion para Limpiar y Oculatar el Label que Muestra los Errores de Cada Campo 
    Sub limpiarErroresRegistroU()
        'Dejamos Vacios todos los campos
        lblErroresU.Text = ""
        lblErrorFechaNacU.Text = ""
        lblErrorNombreU.Text = ""
        lblErrorApellidoU.Text = ""
        lblErrorDocU.Text = ""
        lblErrorEmailU.Text = ""
        lblErrorLocalidadU.Text = ""
        lblErrorDireccionU.Text = ""
        lblErrorTelefonoU.Text = ""
        lblErrorUsuarioU.Text = ""
        lblErrorClaveU.Text = ""
        lblErrorClaveRepeatU.Text = ""
        'Ocultamos los Labels de los Errores
        lblErroresU.Visible = False
        lblErrorFechaNacU.Visible = False
        lblErrorNombreU.Visible = False
        lblErrorApellidoU.Visible = False
        lblErrorDocU.Visible = False
        lblErrorEmailU.Visible = False
        lblErrorLocalidadU.Visible = False
        lblErrorDireccionU.Visible = False
        lblErrorTelefonoU.Visible = False
        lblErrorUsuarioU.Visible = False
        lblErrorClaveU.Visible = False
        lblErrorClaveRepeatU.Visible = False
    End Sub
#End Region
#Region "Limpiar Campos"
    Sub limpiarCamposRegistroU()
        'Llamamos a la Funcion para Limpiar los Errores
        limpiarErroresRegistroU()
        pnlRegistrarse.Visible = False
        txtNombreU.Text = ""
        txtApellidoU.Text = ""
        ddlTipoDocU.SelectedIndex = 0
        txtDocU.Text = ""
        txtEmailU.Text = ""
        txtFechaNac.Text = ""
        ddlProvU.SelectedIndex = 0
        txtLocalidadU.Text = ""
        txtDireccionU.Text = ""
        txtTelefonoU.Text = ""
        txtUsuarioU.Text = ""
        txtClaveU.Text = ""
        txtClaveRepeatU.Text = ""
    End Sub
#End Region
#Region "Validar Mail Valido"
    Public Function validateEmail(ByVal email As String) As Boolean
        Dim emailRegex As New System.Text.RegularExpressions.Regex("^(?<user>[^@]+)@(?<host>.+)$")
        Dim emailMatch As System.Text.RegularExpressions.Match = emailRegex.Match(email)
        Return emailMatch.Success
    End Function
#End Region
#Region "Solo Numeros"
    Sub soloNumeros(ByRef campo As TextBox)
        Dim cam As String = campo.Text.Trim, salida As String = "", c As String
        For Each c In cam
            If IsNumeric(c) Then salida &= c
        Next
        campo.Text = salida
    End Sub
#End Region
#Region "Transforma a Numero"
    'Para convertir los String o Num
    Function Vnum(ByVal NTexto As String) As Decimal
        'transforma un texto con algo, que puede ser un numero con coma o punto o perro, y devuelve un valor decimal siempre
        Return CDec(Val(NTexto.Trim.Replace(", ", ".")))
    End Function
#End Region
#Region "Formato Numero SQL"
    'Para convertir los Numeros en el formato correcto para SQL 
    Function NumSql(ByVal numero As String) As String
        'Recibe un número desde un textbox por ejemplo, lo verifica como número válido, 
        'y luego le cambia la coma por punto para que sea válido en una sentencia de sql,
        'luego lo devuelve
        Return CStr(Vnum(numero)).Trim.Replace(", ", ".")
    End Function
#End Region
#Region "Rellenar Numeros"
    'Para Rellenar los Numeros con la cantidad que necesitemos
    Function RellenaNum(ByVal numero As Integer, ByVal cantidad As Integer) As String
        'Rellena con 0s adelante el numero. Ideal para dias y meses:
        'RellenaNum(3,2)---> "03" RellenaNum(3,4)--->"0003"
        Dim snum As String = CStr(numero).Trim
        Return "00000000000000000000".Substring(0, cantidad - snum.Length) & snum
    End Function
#End Region
#Region "Fecha para SQL"
    'Para Formatear las Fechas en el formato correcto para SQL 
    Function FechaSql(ByVal fecha As Date) As String
        'Devuelve fecha en el formato 'AAAAMMDD'
        Return "'" & RellenaNum(Year(fecha), 4) & RellenaNum(Month(fecha), 2) & RellenaNum(fecha.Day, 2) & "'"
    End Function
#End Region
#Region "Fomato Americano Fecha"
    'Devuelve la fecha en formato Americano AAAA-MM
    Public Function AnioMes(ByVal fecha As Date) As String

        Return RellenaNum(Year(fecha), 4) & "-" & RellenaNum(Month(fecha), 2)
    End Function
#End Region
#Region "Verifica String"
    Public Function Vstr(ByVal algo As Object) As String
        If IsDBNull(algo) Then Return "" Else Return CStr(algo)
    End Function
#End Region
#Region "Calcular Edad"
    Public Function CalcularEdad(ByVal FechaNac As Date) As Integer
        Dim edad As Integer = DateTime.Today.AddTicks(-FechaNac.Ticks).Year - 1
        Return edad
    End Function
#End Region
#Region "Control de Fecha Nacimiento"
    Sub ControlDeNacimiento(ByRef xtF_Nac As TextBox,
                            ByRef ok As Boolean,
                            ByRef xlEFNac As Label,
                            ByRef xlEdad As Label,
                            ByVal Valida18 As Boolean,
                            ByRef FechaNacimiento As Date)
        arreglarCampo(xtF_Nac)
        xlEFNac.Visible = False
        If xtF_Nac.Text.Length < 6 Then
            ok = False
            xlEFNac.Text &= "El Campo de la Fecha de Nacimiento debe Tener 6 Números."
            xlEdad.Text = "0"
            xlEFNac.Visible = True
        Else
            Dim fechaX As String = xtF_Nac.Text
            Dim anioX As Integer = Vnum(fechaX.Substring(4, 2))
            If anioX + 2000 > Date.Today.Year Then anioX += 1900 Else anioX += 2000
            fechaX = anioX.ToString.Trim & "-" & fechaX.Substring(2, 2) & "-" & fechaX.Substring(0, 2)
            If Not IsDate(fechaX) Then
                ok = False
                xlEFNac.Text &= "El Campo de la Fecha de Nacimiento, es una Fecha Inválida."
                xlEdad.Text = "0"
                xlEFNac.Visible = True
            Else
                Dim dFechaX As Date
                dFechaX = CDate(fechaX)
                FechaNacimiento = dFechaX
                If dFechaX > Date.Today Then
                    ok = False
                    xlEFNac.Text &= "Creo que Naciste en el Futuro."
                    xlEdad.Text = "0"
                    xlEFNac.Visible = True
                Else
                    Dim edad As Integer = CalcularEdad(dFechaX)
                    xlEdad.Text = edad
                    If edad < 18 And Valida18 Then
                        ok = False
                        xlEFNac.Text &= "Debes ser Mayor de Edad (18 Años)."
                        xlEdad.Text = "0"
                        xlEFNac.Visible = True
                    End If
                End If
            End If
        End If
    End Sub
#End Region
#Region "Acciones del ABM"
    'Ejecuta las distintas acciones del ABM
    Public Function SqlAccion(ByVal Sql_de_accion As String) As Boolean
        'Ejecuta la consulta de accion 'sql_de_accion' abriendo la conexion automaticamente
        'se da cuenta si es de insert, update o delete, porque mira dentro de la sentencia que se le pasa
        'devuelve true si se pudo hacer, y false si hubo algún error
        Dim adapter As New SqlDataAdapter, salida As Boolean = True
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            If Sql_de_accion.ToUpper.IndexOf("INSERT") Then
                'MsgBox(Sql_de_accion)
                adapter.InsertCommand = New SqlCommand(Sql_de_accion, con)
                adapter.InsertCommand.ExecuteNonQuery()
            Else
                If Sql_de_accion.ToUpper.IndexOf("UPDATE") Then
                    adapter.UpdateCommand = New SqlCommand(Sql_de_accion, con)
                    adapter.UpdateCommand.ExecuteNonQuery()
                Else
                    If Sql_de_accion.ToUpper.IndexOf("DELETE") Then
                        adapter.DeleteCommand = New SqlCommand(Sql_de_accion, con)
                        adapter.DeleteCommand.ExecuteNonQuery()
                    Else
                        'esta mal la sintaxis porque no hay ni insert, ni delete ni update
                        salida = False
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            salida = False
        End Try
        'con. Close()
        Return salida
    End Function
#End Region
#Region "Lee un Campo del DB"
    Function LeeUnCampo(ByVal sql As String, ByVal campo As String) As Object
        'se le pasa un select de sql con un campo y devuelve el valor del campo como object. Se supone que devuelve nada o 1 registro (no más que 1)
        'por ejemplo valor=LeeUnCampo("select cosa from tabla where condi=1","cosa") valor tomará cosa. Si no encuentra nada devuelve "**NADA**". Si hay error devuelve "**ERROR**"
        Dim da1 As New SqlDataAdapter(sql, con)
        Dim ds1 As New DataSet
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            da1.Fill(ds1, "datos")
            If ds1.Tables("datos").Rows.Count < 1 Then
                Return "**NADA**"
            Else
                Return ds1.Tables("datos").Rows(0)(campo)
            End If
        Catch
            Return "**ERROR**"
        End Try
    End Function
#End Region
#Region "Existe en la DB"
    'Para comprobar si existe en la DB
    Function YaExisteSql(ByVal sql As String) As Boolean
        'Le pasamos un SELECT de SQL que en teoria busca algo, por ejemplo un numero de cheque, si hay registros la Funcion devuelve 
        'True, estilo "el cheque ya existe", si no esta, devuelve False
        Dim con As New SqlConnection(connectionstring)
        Dim da1 As New SqlDataAdapter(sql, con)
        Dim dsl As New DataSet
        da1.Fill(dsl, "afidesc")
        If dsl.Tables("afidesc").Rows.Count < 1 Then
            Return False
        Else
            Return True
        End If
    End Function
#End Region
#Region "Limpiar Errores Nodificar Datos Personales"
    'Funcion para Limpiar y Oculatar el Label que Muestra los Errores de Cada Campo 
    Sub limpiarErroresModificarDatosU()
        'Dejamos Vacios todos los campos
        lblErrorEdit.Text = ""
        lblErrorEmailUedit.Text = ""
        lblErrorLocalidadUedit.Text = ""
        lblErrorDireccionUedit.Text = ""
        lblErrorTelefonoUedit.Text = ""
        lblErrorUsuarioUedit.Text = ""
        lblErrorClaveUedit.Text = ""
        'Ocultamos los Labels de los Errores
        lblErrorEdit.Visible = False
        lblErrorEmailUedit.Visible = False
        lblErrorLocalidadUedit.Visible = False
        lblErrorDireccionUedit.Visible = False
        lblErrorTelefonoUedit.Visible = False
        lblErrorUsuarioUedit.Visible = False
        lblErrorClaveUedit.Visible = False
    End Sub
#End Region
    Protected Sub btnEntrar_Click(sender As Object, e As ImageClickEventArgs) Handles btnEntrar.Click
        Session("QueEs") = "Usuarios"
        Loguea()
    End Sub
#Region "Loguear Usuario"
    Sub Loguea()
        Dim usu As String = txtUsuario.Text.Trim.ToUpper, pass As String = txtClave.Text.Trim
        If comprobar(txtUsuario.Text.Trim) = False Or comprobar(txtClave.Text.Trim) = False Then
            lblErrorLogin.Text = "El Usuario o la Contraseña son Incorrectos. Revise por favor."
            lblErrorLogin.Visible = True
            Exit Sub
        End If
        Dim da1 As New SqlDataAdapter("SELECT * FROM " & Session("QueEs") & " WHERE UPPER(LTRIM(RTRIM(usuario)))='" & usu & "' AND LTRIM(RTRIM(clave))='" & pass & "'", con)
        Dim ds1 As New DataSet
        da1.Fill(ds1, "Login")
        If ds1.Tables("Login").Rows.Count = 0 Then
            lblErrorLogin.Text = "El Usuario o la Contraseña son Incorrectos. Revise por favor."
            lblErrorLogin.Visible = True
            Exit Sub
        End If
        'Para Comprobar que Tipo de Usuario es y ver de donde tomamos los datos
        Select Case Session("QueEs")
            Case "Usuarios"
                Session("idUsuario") = ds1.Tables("Login").Rows(0)("idUsuario")
                Session("Usuario") = usu
                Session("Password") = pass
                Session("TipoDocumento") = ds1.Tables("Login").Rows(0)("tDoc")
                Session("Documento") = ds1.Tables("Login").Rows(0)("Documento").ToString.Trim
                Session("ApellidoYNombre") = ds1.Tables("Login").Rows(0)("Nombre").ToString.Trim & " " & ds1.Tables("Login").Rows(0)("Apellido").ToString.Trim
                Session("Email") = ds1.Tables("Login").Rows(0)("Email").ToString.Trim
                Session("idprov") = ds1.Tables("Login").Rows(0)("idProv").ToString.Trim
                Session("Localidad") = ds1.Tables("Login").Rows(0)("Localidad").ToString.Trim
                Session("Direccion") = ds1.Tables("Login").Rows(0)("Domicilio").ToString.Trim
                Session("Telefono") = ds1.Tables("Login").Rows(0)("Telefono").ToString.Trim
                lblBienvenidoAreaU.Text = "Bienvenido " & Session("ApellidoYNombre") & ", a tu Área de Usuario."
                limpiarCamposRegistroU()
                pnlLogin.Visible = False
                pnlAreaUsuario.Visible = True
            Case "Administradores"
                'Session("idAdmin") = ds1.Tables("Login").Rows(0)("idAdmin")
                'Session("Denominacion") = ds1.Tables("Login").Rows(0)("Administrador").ToString.Trim
                'lblAdherente0.Text = "Bienvenido Administrador " & Session("Denominacion") & "."
                'pnlLogin.Visible = False
                'MostrarCuantosAEliminar()
                'MostrarCuantosUsuariosHay()
                'pnlAdministradores.Visible = True
        End Select
    End Sub
#End Region
    Protected Sub btnAhoraQueHago_Click(sender As Object, e As ImageClickEventArgs) Handles btnAhoraQueHago.Click
        pnlAreaUsuario.Visible = False
        pnlAhoraQueHago.Visible = True
    End Sub
#Region "Para Limpiar el Login"
    Sub limpiarLogin()
        lblErrorLogin.Text = ""
        lblErrorLogin.Visible = False
        txtUsuario.Text = ""
        pnlRegistrarse.Visible = False
    End Sub
#End Region
    Protected Sub btnVolverLoginU1_Click(sender As Object, e As ImageClickEventArgs) Handles btnVolverLoginU1.Click
        limpiarLogin()
        limpiarCamposRegistroU()
        lblReenviarClave.Text = "" : lblReenviarClave.Visible = False
        pnlLogin.Visible = True
        pnlAreaUsuario.Visible = False
        txtUsuario.Text = Session("Usuario")
        txtClave.Text = Session("Password")
    End Sub

    Protected Sub btnVolverU2_Click(sender As Object, e As ImageClickEventArgs) Handles btnVolverU2.Click
        pnlAhoraQueHago.Visible = False
        pnlAreaUsuario.Visible = True
    End Sub
#Region "Mostrar Datos Personales"
    Sub mostrarDatosPersonales()
        txtEmailUedit.Text = Session("Email")
        txtLocalidadUedit.Text = Session("Localidad")
        txtDireccionUedit.Text = Session("Direccion")
        ddlProvUedit.SelectedValue = Session("idprov")
        txtTelefonoUedit.Text = Session("Telefono")
        txtUsuarioUedit.Text = Session("Usuario")
        txtClaveUedit.Text = Session("Password")
    End Sub
#End Region
    Protected Sub btnModificarDatos_Click(sender As Object, e As ImageClickEventArgs) Handles btnModificarDatos.Click
        mostrarDatosPersonales()
        pnlAreaUsuario.Visible = False
        pnlCambiarDatosPersonales.Visible = True
    End Sub

    Protected Sub btnCancelarVolverEdit_Click(sender As Object, e As ImageClickEventArgs) Handles btnCancelarVolverEdit.Click
        pnlAreaUsuario.Visible = True
        pnlCambiarDatosPersonales.Visible = False
    End Sub
#Region "Modificar Datos Personales"
    Sub editarDatosPersonales()
        Dim ok As Boolean = True
        'Llamamos a la Funcion para Limpiar los Errores
        limpiarErroresModificarDatosU()
        'Comprobamos el Email
        arreglarCampo(txtEmailUedit)
        If validateEmail(txtEmailUedit.Text) = False Then
            ok = False
            lblErrorEmailUedit.Text = "El Email no es válido."
            lblErrorEmailUedit.Visible = True
        End If
        'Comprobamos La Localidad
        txtLocalidadUedit.Text = txtLocalidadUedit.Text.Trim().ToUpper
        If comprobar(txtLocalidadUedit.Text) = False Then
            arreglarCampo(txtLocalidadUedit)
            ok = False
            lblErrorLocalidadUedit.Text = "La Localidad contenía caracteres inválidos, fueron quitados"
            lblErrorLocalidadUedit.Visible = True
        End If
        'Comprobamos La Direccion
        txtDireccionUedit.Text = txtDireccionUedit.Text.ToUpper
        If comprobar(txtDireccionUedit.Text) = False Then
            arreglarCampo(txtDireccionUedit)
            ok = False
            lblErrorDireccionUedit.Text = "La Direccion contenía caracteres inválidos, fueron quitados"
            lblErrorDireccionUedit.Visible = True
        End If
        'Comprobamos el Telefono
        txtTelefonoUedit.Text = txtTelefonoUedit.Text.Trim()
        If comprobar(txtTelefonoUedit.Text) = False Or Not IsNumeric(txtTelefonoUedit.Text) Then
            soloNumeros(txtTelefonoUedit)
            ok = False
            lblErrorTelefonoUedit.Text = "El Telefono no era válido, se ajustó a número "
            lblErrorTelefonoUedit.Visible = True
        End If
        'Comprobamos el Usuario
        txtUsuarioUedit.Text = txtUsuarioUedit.Text.Trim().ToUpper
        If comprobar(txtUsuarioUedit.Text) = False Or txtUsuarioUedit.Text.IndexOf(" ") > -1 Then
            txtUsuarioUedit.Text = txtUsuarioUedit.Text.Replace(" ", "")
            arreglarCampo(txtUsuarioUedit)
            ok = False
            lblErrorUsuarioUedit.Text = "El Usuario contenía caracteres inválidos, fueron quitados."
            lblErrorUsuarioUedit.Visible = True
        End If
        If txtUsuarioUedit.Text.Length < 5 Then
            ok = False
            lblErrorUsuarioUedit.Text = "El Usuario debe tener de 5 a 10 Caracteres, letras y/o Números."
            lblErrorUsuarioUedit.Visible = True
        End If
        'Comprobamos la Contraseña
        txtClaveUedit.Text = txtClaveUedit.Text.Trim()
        If comprobar(txtClaveUedit.Text) = False Or txtClaveUedit.Text.IndexOf(" ") > -1 Then
            txtClaveUedit.Text = txtClaveUedit.Text.Replace(" ", "")
            arreglarCampo(txtClaveUedit)
            ok = False
            lblErrorClaveUedit.Text = "L a Contraseña contenía caracteres inválidos.Prueba con Letras y Números."
            lblErrorClaveUedit.Visible = True
        End If
        If txtClaveUedit.Text.Length < 5 Then
            ok = False
            lblErrorClaveUedit.Text = "L a Contraseña debe tener de 5 a 10 Caracteres, letras y/o Números."
            lblErrorClaveUedit.Visible = True
        End If
        'Si existen Errores los Mostramos el lblErroresU
        If ok = False Then
            lblErrorEdit.Text = "Surgieron Errores por favor Revisalos e Intenta de Nuevo."
            lblErrorEdit.Visible = True
            Exit Sub
        End If
        'Creamos las Distintas Sesiones
        If txtUsuarioUedit.Text <> Session("Usuario") Then
            Session("Usuario") = txtUsuarioUedit.Text
            'Comprobamos si Existe en la DB
            If YaExisteSql("SELECT idusuario FROM usuarios WHERE usuario='" & Session("Usuario") & "'") Then
                ok = False
                lblErrorUsuarioU.Text = "El usuario elegido ya existe. Prueba con otro."
                lblErrorUsuarioU.Visible = True
            End If
        End If
        Session("Password") = txtClaveUedit.Text
        Session("Usuario") = txtUsuarioUedit.Text.ToLower
        Session("Password") = txtClaveUedit.Text
        Session("Email") = txtEmailUedit.Text.Trim
        limpiarErroresModificarDatosU()
        'Si pasa la Validacion lo Insertanos en la DB
        If SqlAccion("UPDATE Usuarios SET Email='" & Session("Email") & "', idProv='" & ddlProvUedit.SelectedValue & "', Localidad = '" & txtLocalidadUedit.Text.Trim & "', Domicilio= '" & txtDireccionUedit.Text.Trim & "', Telefono='" & txtTelefonoUedit.Text.Trim & "', Usuario='" & Session("Usuario") & "', Clave='" & Session("Password") & "' WHERE idUsuario =" & Session("idUsuario")) = False Then
            lblErroresU.Text = "Se ha producido un error al querer guardar tus datos."
            lblErroresU.Visible = True
            Exit Sub
        End If
        pnlCambiarDatosPersonales.Visible = False
        pnlDatosModificadosOk.Visible = True
        btnVolverAreaUsuario.Focus()
    End Sub
#End Region
    Protected Sub btnCambiarDatos_Click(sender As Object, e As ImageClickEventArgs) Handles btnCambiarDatos.Click
        editarDatosPersonales()
    End Sub

    Protected Sub btnVolverAreaUsuario_Click(sender As Object, e As ImageClickEventArgs) Handles btnVolverAreaUsuario.Click
        pnlDatosModificadosOk.Visible = False
        pnlAreaUsuario.Visible = True
    End Sub
End Class