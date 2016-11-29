Public Class Form2

    Dim imsel As Int16



    Private Sub ImSElec(sender As Object, e As EventArgs) Handles PictureBox6.Click, PictureBox5.Click, PictureBox4.Click, PictureBox3.Click, PictureBox2.Click, PictureBox1.Click


        Dim p As PictureBox = sender

        imsel = p.Tag

        'MsgBox("You select " + imsel.ToString + " Now just hit it !!!")

        Select Case imsel

            Case 1
                Form1.Gollum.BackgroundImage = My.Resources.im1
            Case 2
                Form1.Gollum.BackgroundImage = My.Resources.im2
            Case 3
                Form1.Gollum.BackgroundImage = My.Resources.im3
            Case 4
                Form1.Gollum.BackgroundImage = My.Resources.im4
            Case 5
                Form1.Gollum.BackgroundImage = My.Resources.im5
            Case 6
                Form1.Gollum.BackgroundImage = My.Resources.im6
        End Select

        Me.Hide()
        Form1.Show()

    End Sub
End Class