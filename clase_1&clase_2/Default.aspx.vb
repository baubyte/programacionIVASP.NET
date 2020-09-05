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
End Class