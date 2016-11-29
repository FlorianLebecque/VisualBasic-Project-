Public Class Form2
    Dim colortt(5) As Color, selectedcolor As Integer
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Definition du tableau couleur
        colortt(0) = Color.Green
        colortt(1) = Color.Blue
        colortt(2) = Color.Violet
        colortt(3) = Color.Pink
        colortt(4) = Color.Orange
        colortt(5) = Color.Red

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.Show() 'afficher la form de jeu
        Me.Hide()
    End Sub

    Private Sub clicks(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bc4.Click, bc3.Click, bc2.Click, Bc1.Click

        Dim bc As Button = sender 'definit la couleur du boutton
        bc.BackColor = colortt(selectedcolor)

    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged, RadioButton5.CheckedChanged, RadioButton4.CheckedChanged, RadioButton3.CheckedChanged, RadioButton2.CheckedChanged, RadioButton1.CheckedChanged

        Dim rd As RadioButton = sender 'defini la couleur selectionner
        selectedcolor = rd.Tag
    End Sub

    Private Sub RD(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RD2.CheckedChanged, RD1.CheckedChanged

        Dim bt As RadioButton = sender 'afficher ou cache le panel couleur, definit le mode 1 ou 2 joueurs

        If bt.Name = "RD1" Then
            Panel2.Visible = False
        Else
            Panel2.Visible = True
        End If

    End Sub
End Class