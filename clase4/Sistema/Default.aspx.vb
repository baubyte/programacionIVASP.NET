Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnPortada_Click(sender As Object, e As ImageClickEventArgs) Handles btnPortada.Click
        pnlPortada.Visible = False
        pnlLogin.Visible = True
    End Sub

    Protected Sub btnVolverLogin_Click(sender As Object, e As ImageClickEventArgs) Handles btnVolverLogin.Click
        pnlPortada.Visible = True
        pnlLogin.Visible = False
    End Sub
End Class