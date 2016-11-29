Public Class Form1

    Dim colort(5) As Color, ran As New Random, nbr As Integer, lastnbr As Int16, code As String, selectedcolor As Integer, codeuser As String, pos As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        colort(0) = Color.Green 'Deffinit le tableau de couleur
        colort(1) = Color.Blue
        colort(2) = Color.Violet
        colort(3) = Color.Pink
        colort(4) = Color.Orange
        colort(5) = Color.Red

    End Sub

    Private Sub Closings(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Form2.Close()
    End Sub

    Private Sub colorselct(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton6.CheckedChanged, RadioButton5.CheckedChanged, RadioButton4.CheckedChanged, RadioButton3.CheckedChanged, RadioButton2.CheckedChanged, RadioButton1.CheckedChanged

        Dim rd As RadioButton = sender 'definit la couleur selectionner
        selectedcolor = rd.Tag

    End Sub

    Private Sub bt4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt4.Click, bt3.Click, bt2.Click, Bt1.Click

        Dim bt As Button = sender 'definit la couleur du boutton
        bt.BackColor = colort(selectedcolor)

    End Sub

    Private Sub Gen(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        code = Nothing 'Gen la grille,definit le code en fontion du mode

        FlowLayoutPanel1.Controls.Clear()

        If Form2.RD1.Checked = True Then 'Choisi le mode
            randomGen()
        Else
            codess()
        End If

        Dim a As Integer
        a = NumericUpDown1.Value
        Dim p As Integer = 1

        While a > 0 'Gen la grille/chaque ligne

            For x = 1 To 4 'creation de 4bt
                Dim ee As New Padding(0) 'proprieter du btn/grille
                Dim aze As New Button
                aze.Name = ("P" + p.ToString + "B" + x.ToString)
                aze.Margin = ee
                aze.Height = 25
                aze.Width = 45
                aze.FlatStyle = FlatStyle.Flat
                FlowLayoutPanel1.Controls.Add(aze)

            Next

            Dim lab As New Label 'Creer le label de test
            lab.Name = "P" + p.ToString
            lab.Text = ""
            FlowLayoutPanel1.Controls.Add(lab)

            a = a - 1
            p = p + 1

        End While

        pos = 1

        Btcheck.Enabled = True
        RectangleShape1.BringToFront()

    End Sub

    Private Sub Btcheck_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btcheck.Click

        codeuser = Nothing 'Demarre de check

        For i = 1 To 4 'definit la code utilisateur

            For x = 1 To 6

                If Me.Controls("Bt" + i.ToString).BackColor = colort(x - 1) Then
                    codeuser = codeuser + (x - 1).ToString
                End If

            Next

        Next

        Dim codes = codeuser
        Dim c As Integer

        If pos <= NumericUpDown1.Value And pos > Not NumericUpDown1.Value Then 'Place les couleur dans la grille
            For i = 1 To 4

                c = Mid(codes, 1, 1)
                codes = codes.Remove(0, 1)
                FlowLayoutPanel1.Controls("P" + pos.ToString + "B" + i.ToString).BackColor = colort(c)


                If Mid(code, i, 1) = Mid(codeuser, i, 1) Then 'definit si les button son bon ou pas;si bonne place

                    FlowLayoutPanel1.Controls("P" + pos.ToString).Text = FlowLayoutPanel1.Controls("P" + pos.ToString).Text + "A"

                ElseIf InStr(code, Mid(codeuser, i, 1)) <> Nothing Then 'Si maivaise place

                    FlowLayoutPanel1.Controls("P" + pos.ToString).Text = FlowLayoutPanel1.Controls("P" + pos.ToString).Text + "B"

                Else 'si mauvais
                    FlowLayoutPanel1.Controls("P" + pos.ToString).Text = FlowLayoutPanel1.Controls("P" + pos.ToString).Text + "X"

                End If

            Next
        Else
            MsgBox("fini")
            RectangleShape1.SendToBack()

        End If

        pos = pos + 1

        If code = codeuser Then
            MsgBox("ok tu la fais en " + (pos - 1).ToString)
            RectangleShape1.SendToBack()
        End If

    End Sub

    Sub randomGen() 'Gen a code aleatoire

        For i = 1 To 4

            Do Until nbr <> lastnbr

                nbr = ran.Next(0, 6)

            Loop

            Me.Controls(("Bc" + i.ToString).ToString).BackColor = colort(nbr)
            lastnbr = nbr
            code = code + nbr.ToString

        Next

    End Sub

    Sub codess() 'definit le code en fonction de la form2

        code = Nothing

        For i = 1 To 4

            For x = 1 To 6

                If Form2.Panel2.Controls("Bc" + i.ToString).BackColor = colort(x - 1) Then
                    code = code + (x - 1).ToString
                End If

            Next

        Next

        For i = 1 To 4

            Me.Controls("Bc" + i.ToString).BackColor = colort(Mid(code, i, 1))

        Next

    End Sub

    Private Sub form2load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Me.Hide() 'affiche la form2
        Form2.Show()

    End Sub

    Private Sub help(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bthelp.Click

        MsgBox("A : Bonne couleur, B : Mauvaise place, X : Faux")

    End Sub
End Class
