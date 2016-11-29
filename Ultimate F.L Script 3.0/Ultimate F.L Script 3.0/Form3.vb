Public Class Form3

    Dim a As String
    Dim b As Integer
    Dim c As Integer, er As Integer, pa As Integer, pb As Integer
    Dim d As Integer
    Dim f As String
    Dim r As Boolean
    Dim cr As Integer
    Dim first As Boolean = True

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        mela()

    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        r = True

    End Sub



    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        MsgBox("Text-melanger vas melanger les lettres du text pour le crypter ,pour decrypter crypter le message ressu jusque quand cela donne une phrase un mot ")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim x As Integer
        Dim y As Double


        x = TextBox1.Text.Length

        y = 0.0000003 * x ^ 8 - 0.0000324 * x ^ 7 + 0.0013871 * x ^ 6 - 0.0312588 * x ^ 5 + 0.3987255 * x ^ 4 - 2.8821781 * x ^ 3 + 11.0493864 * x ^ 2 - 17.1673561 * x + 5


        While y > 0

            mela()
            y = y - 1

        End While


    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        

        Label1.Text = TextBox1.Text.Length

        If Val(Label1.Text) Mod 2 = 0 Then

            Label1.ForeColor = Color.Red
        ElseIf Val(Label1.Text) Mod 2 = 1 And TextBox1.Text.Length >= 5 Then
            Label1.ForeColor = Color.Green

        End If



    End Sub

    Sub mela()



        b = TextBox1.Text.Length
        c = b
        d = b
        f = b
        first = True
        TextBox2.Text = ""

        While c > 0

            If first = False Then

                d = d - 1

            End If


            If r = True And first = False Then

                r = False
                b = b - d
            ElseIf r = False And first = False Then

                r = True
                b = b + d

            End If

            If first = True Then

                b = TextBox1.Text.Length
                first = False

            End If


            a = Mid(TextBox1.Text, b, 1)

            TextBox2.AppendText(a)

            c = c - 1

        End While

        TextBox1.Text = TextBox2.Text


    End Sub

End Class