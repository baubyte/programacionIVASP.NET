Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'lblHora.Text = DateTime.Now.ToString("HH:mm:ss") & " Esta hora es del Page Load"
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnClic.Click
        'lblHora.Text = DateTime.Now.ToString("HH:mm:ss")
        lblPrueba.Text = Vnum(txtPrueba.Text)
    End Sub
    'Para convertir los String o Num
    Function Vnum(ByVal NTexto As String) As Decimal
        'transforma un texto con algo, que puede ser un numero con coma o punto o perro, y devuelve un valor decimal siempre
        Return CDec(Val(NTexto.Trim.Replace(",", ".")))
    End Function

    Protected Sub btnGoogle_Click(sender As Object, e As EventArgs) Handles btnGoogle.Click
        Response.Redirect("https://www.google.com")
    End Sub

    Protected Sub lstLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstLista.SelectedIndexChanged
        txtPrueba.Text = lstLista.SelectedItem.Text
        Response.Redirect(lstLista.SelectedValue)
    End Sub

    Protected Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        Dim nombrePDF As String = "pdfs/Programación IV - Clase 3.pdf"
        Response.Clear()
        Response.ContentType = "application/pdf"
        Response.AddHeader("Content-disposition", "attachment; filename=" & nombrePDF)
        Response.Redirect(nombrePDF)
        Response.Flush()
        Response.Clear()
    End Sub

    Protected Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        Session("pasoEsto") = txtPrueba.Text.Trim
        Server.Transfer("Clientes.aspx")
    End Sub
End Class