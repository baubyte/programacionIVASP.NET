Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

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
        'Comprobamos la Fecha de Nacimiento
        txtFechaNac.Text = txtFechaNac.Text.Trim()
        If comprobar(txtFechaNac.Text) = False Or Not IsNumeric(txtFechaNac.Text) Then
            soloNumeros(txtFechaNac)
            ok = False
            lblErrorFechaNacU.Text = "La Fecha de Nacimiento no era válido, se ajustó a número "
            lblErrorFechaNacU.Visible = True
        End If
        'Comprobamos el Email
        arreglarCampo(txtEmailU)
        If validateEmail(txtEmailU.Text) = False Then
            ok = False
            lblErrorEmailU.Text = "El Email no es válido."
            lblErrorEmailU.Visible = True
        End If
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
        If comprobar(txtUsuarioU.Text) = False Then
            arreglarCampo(txtUsuarioU)
            ok = False
            lblErrorUsuarioU.Text = "El Usuario contenía caracteres inválidos, fueron quitados"
            lblErrorUsuarioU.Visible = True
        End If
        'Si paso todas las Validaciones Mostramos los Paneles
        If ok Then
            limpiarCamposRegistroU()
            pnlRegistrarse.Visible = False
            pnlBienvenido.Visible = True
        End If
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
End Class