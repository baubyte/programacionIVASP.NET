Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss") & " Esta hora es del Page Load"
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnClic.Click
        'lblHora.Text = DateTime.Now.ToString("HH:mm:ss")
    End Sub

    Protected Sub txtPrueba_TextChanged(sender As Object, e As EventArgs) Handles txtPrueba.TextChanged
        lblPrueba.Text = txtPrueba.Text
    End Sub
End Class