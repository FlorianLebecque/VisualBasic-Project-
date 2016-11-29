Public Class Form2

    Dim msg As String
    Dim key As String


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If RadioButton1.Checked = True Then

            key = Mid(TextBox1.Text, 1, 27)
            msg = TextBox1.Text.Remove(0, 27)

            TextBox2.Text = key
            TextBox3.Text = msg

        ElseIf RadioButton2.Checked = True Then

            key = Mid(TextBox1.Text, 1, 38)
            msg = TextBox1.Text.Remove(0, 38)

            TextBox2.Text = key
            TextBox3.Text = msg

        End If




    End Sub
End Class