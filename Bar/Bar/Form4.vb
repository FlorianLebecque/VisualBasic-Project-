Public Class Form4

    Dim hides As Boolean

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        hides = True
        Timer1.Start()


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Form1.Location.X = 0 And hides = True Then
            Timer1.Stop()
            hides = False
            Me.Close()

        ElseIf hides = True And Form1.Location.X >= -142 Then

            Form1.Location = New Point(Form1.Location.X + 2)

        End If

    End Sub

End Class