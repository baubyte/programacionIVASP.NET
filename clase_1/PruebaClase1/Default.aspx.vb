Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnClic.Click
    End Sub

    Protected Sub txtPrueba_TextChanged(sender As Object, e As EventArgs) Handles txtPrueba.TextChanged
        lblPrueba.Text = txtPrueba.Text
    End Sub
End Class