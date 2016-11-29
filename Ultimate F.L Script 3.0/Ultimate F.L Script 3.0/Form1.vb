Public Class Form1

    Dim lenght As Integer
    Dim chars As String
    Dim mss As String
    Dim cryp As String
    Dim ma As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        My.Computer.FileSystem.CreateDirectory("C:\Fl crypt\27\")

        My.Computer.FileSystem.CreateDirectory("C:\Fl crypt\38\")

        For i = 0 To My.Computer.FileSystem.GetFiles("C:\Fl crypt\38\").Count - 1

            ListBox2.Items.Add(My.Computer.FileSystem.GetFiles("C:\Fl crypt\38\").Item(i))

        Next i

        For i = 0 To My.Computer.FileSystem.GetFiles("C:\Fl crypt\27\").Count - 1

            ListBox1.Items.Add(My.Computer.FileSystem.GetFiles("C:\Fl crypt\27\").Item(i))

        Next i

        Button3.Enabled = False
        Button4.Enabled = False
        Button8.BackColor = Color.Red
        Button3.BackColor = Color.Red
        Button4.BackColor = Color.Red
        Timer1.Enabled = True

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ran As New Random, rb As Integer
        Dim st As String
        Dim keys As String
        Dim a As Integer

        reset()

        If RadioButton1.Checked = True Then

            a = 27
            TextBox1.Text = ("")
            keys = ("")
            ProgressBar1.Maximum = a
            ProgressBar1.Value = 0

            While a > 0

                rb = ran.Next(1, 66)

                st = ("ABCDEFGHIJKLMNOPQRSTUVWXYZ 1234567890!£$%^&*()_+=-[]}{#~'@;:/?.>,<")

                keys = keys + Mid(st, rb, 1)
                a = a - 1
                ProgressBar1.Value = ProgressBar1.Value + 1


            End While
            TextBox1.Text = keys

        End If

        If RadioButton2.Checked = True Then

            a = 38
            TextBox1.Text = ("")
            keys = ("")
            ProgressBar1.Maximum = a
            ProgressBar1.Value = 0

            While a > 0

                rb = ran.Next(1, 66)

                st = ("ABCDEFGHIJKLMNOPQRSTUVWXYZ 1234567890!£$%^&*()_+=-[]}{#~'@;:/?.>,<")

                keys = keys + Mid(st, rb, 1)
                a = a - 1
                ProgressBar1.Value = ProgressBar1.Value + 1

            End While
            TextBox1.Text = keys

        End If




    End Sub 'Key gen

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()

        If RadioButton1.Checked = True Then

            Dim sw As New System.IO.StreamWriter("C:\Fl crypt\27\" + TextBox4.Text + ".key")

            sw.WriteLine(TextBox1.Text)
            sw.Close()

        ElseIf RadioButton2.Checked = True Then

            Dim sw As New System.IO.StreamWriter("C:\Fl crypt\38\" + TextBox4.Text + ".key")

            sw.WriteLine(TextBox1.Text)
            sw.Close()

        End If

        Dim i As Integer

        For i = 0 To My.Computer.FileSystem.GetFiles("C:\Fl crypt\38\").Count - 1

            ListBox2.Items.Add(My.Computer.FileSystem.GetFiles("C:\Fl crypt\38\").Item(i))

        Next i

        For i = 0 To My.Computer.FileSystem.GetFiles("C:\Fl crypt\27\").Count - 1

            ListBox1.Items.Add(My.Computer.FileSystem.GetFiles("C:\Fl crypt\27\").Item(i))

        Next i


    End Sub 'save key

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        reset()


    End Sub 'reset

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        crypt()

    End Sub 'crypt

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        decrypt()

    End Sub 'decrypt

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        If RadioButton1.Checked = True Then

            Dim sr As New System.IO.StreamReader(ListBox1.SelectedItem.ToString)

            TextBox1.Text = sr.ReadLine
            ma = Mid(ListBox1.SelectedItem.ToString, 16)
            ma = Mid(ma, 1, Len(ma) - 4)
            TextBox4.Text = ma

            sr.Close()

        ElseIf RadioButton2.Checked = True Then

            Dim sr As New System.IO.StreamReader(ListBox2.SelectedItem.ToString)

            TextBox1.Text = sr.ReadLine
            ma = Mid(ListBox2.SelectedItem.ToString, 16)
            ma = Mid(ma, 1, Len(ma) - 4)
            TextBox4.Text = ma
            sr.Close()

        End If

    End Sub 'key select

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        If RadioButton1.Checked = True Then

            My.Computer.FileSystem.DeleteFile(ListBox1.SelectedItem.ToString)

        ElseIf RadioButton2.Checked = True Then

            My.Computer.FileSystem.DeleteFile(ListBox2.SelectedItem.ToString)

        End If

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()

        For i = 0 To My.Computer.FileSystem.GetFiles("C:\Fl crypt\38\").Count - 1

            ListBox2.Items.Add(My.Computer.FileSystem.GetFiles("C:\Fl crypt\38\").Item(i))

        Next i

        For i = 0 To My.Computer.FileSystem.GetFiles("C:\Fl crypt\27\").Count - 1

            ListBox1.Items.Add(My.Computer.FileSystem.GetFiles("C:\Fl crypt\27\").Item(i))

        Next i

    End Sub 'key delete

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        MsgBox("la key 27 pour convertire un text sans espace ni chiffre et une key 38 pour les espace et les chiffre")

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click


        If RadioButton1.Checked = True Then

            TextBox2.Text = "abcdefghijklmnopqrstuvwxyz"
            crypt()
            TextBox2.Text = TextBox3.Text
            TextBox3.Text = ""
            decrypt()

            If TextBox3.Text = "abcdefghijklmnopqrstuvwxyz" Then
                MsgBox("Votre key est utilisable")
                Button3.BackColor = Color.Green
                Button4.BackColor = Color.Green
                Button3.Enabled = True
                Button4.Enabled = True
                Button8.BackColor = Color.Green
                Timer1.Enabled = False
                Label4.Visible = True
                Label3.Visible = False

            ElseIf TextBox3.Text <> "abcdefghijklmnopqrstuvwxyz" Then
                MsgBox("Votre key n'est pas valide vous devez en regen une")
                Button3.BackColor = Color.Orange
                Button4.BackColor = Color.Orange
                Button3.Enabled = True
                Button4.Enabled = True
                Button8.BackColor = Color.Red
                Beep()

            End If

            TextBox2.Text = ""
            TextBox3.Text = ""

        ElseIf RadioButton2.Checked = True Then

            TextBox2.Text = "abcdefghijklmnopqrstuvwxyz 1234567890"
            crypt()
            TextBox2.Text = TextBox3.Text
            TextBox3.Text = ""
            decrypt()

            If TextBox3.Text = "abcdefghijklmnopqrstuvwxyz 1234567890" Then
                MsgBox("Votre key est utilisable")
                Button3.BackColor = Color.Green
                Button4.BackColor = Color.Green
                Button3.Enabled = True
                Button4.Enabled = True
                Button8.BackColor = Color.Green
                Timer1.Enabled = False
                Label4.Visible = True
                Label3.Visible = False

            ElseIf TextBox3.Text <> "abcdefghijklmnopqrstuvwxyz 1234567890" Then
                MsgBox("Votre key n'est pas valide vous devez en regen une")
                Button3.BackColor = Color.Orange
                Button4.BackColor = Color.Orange
                Button3.Enabled = True
                Button4.Enabled = True
                Button8.BackColor = Color.Red
                Beep()

            End If

            TextBox2.Text = ""
            TextBox3.Text = ""

        End If

    End Sub 'tester des key

    Sub crypt()

        If RadioButton1.Checked = True Then

            lenght = TextBox2.Text.Length
            ProgressBar1.Maximum = lenght
            ProgressBar1.Value = 0

            While lenght > 0

                chars = Mid(TextBox2.Text, 1, 1)

                mss = mss + chars

                TextBox2.Text = TextBox2.Text.Remove(0, 1)

                If chars = "a" Then
                    cryp = Mid(TextBox1.Text, 1, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "b" Then
                    cryp = Mid(TextBox1.Text, 2, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "c" Then
                    cryp = Mid(TextBox1.Text, 3, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "d" Then
                    cryp = Mid(TextBox1.Text, 4, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "e" Then
                    cryp = Mid(TextBox1.Text, 5, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "f" Then
                    cryp = Mid(TextBox1.Text, 6, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "g" Then
                    cryp = Mid(TextBox1.Text, 7, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "h" Then
                    cryp = Mid(TextBox1.Text, 8, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "i" Then
                    cryp = Mid(TextBox1.Text, 9, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "j" Then
                    cryp = Mid(TextBox1.Text, 10, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "k" Then
                    cryp = Mid(TextBox1.Text, 11, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "l" Then
                    cryp = Mid(TextBox1.Text, 12, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "m" Then
                    cryp = Mid(TextBox1.Text, 13, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "n" Then
                    cryp = Mid(TextBox1.Text, 14, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "o" Then
                    cryp = Mid(TextBox1.Text, 15, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "p" Then
                    cryp = Mid(TextBox1.Text, 16, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "q" Then
                    cryp = Mid(TextBox1.Text, 17, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "r" Then
                    cryp = Mid(TextBox1.Text, 18, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "s" Then
                    cryp = Mid(TextBox1.Text, 19, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "t" Then
                    cryp = Mid(TextBox1.Text, 20, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "u" Then
                    cryp = Mid(TextBox1.Text, 21, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "v" Then
                    cryp = Mid(TextBox1.Text, 22, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "w" Then
                    cryp = Mid(TextBox1.Text, 23, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "x" Then
                    cryp = Mid(TextBox1.Text, 24, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "y" Then
                    cryp = Mid(TextBox1.Text, 25, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "z" Then
                    cryp = Mid(TextBox1.Text, 26, 2)
                    TextBox3.AppendText(cryp)
                End If

                lenght = lenght - 1
                ProgressBar1.Value = ProgressBar1.Value + 1

            End While

        ElseIf RadioButton2.Checked = True Then

            lenght = TextBox2.Text.Length
            ProgressBar1.Maximum = lenght
            ProgressBar1.Value = 0

            While lenght > 0

                chars = Mid(TextBox2.Text, 1, 1)

                mss = mss + chars

                TextBox2.Text = TextBox2.Text.Remove(0, 1)

                If chars = "a" Then
                    cryp = Mid(TextBox1.Text, 1, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "b" Then
                    cryp = Mid(TextBox1.Text, 2, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "c" Then
                    cryp = Mid(TextBox1.Text, 3, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "d" Then
                    cryp = Mid(TextBox1.Text, 4, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "e" Then
                    cryp = Mid(TextBox1.Text, 5, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "f" Then
                    cryp = Mid(TextBox1.Text, 6, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "g" Then
                    cryp = Mid(TextBox1.Text, 7, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "h" Then
                    cryp = Mid(TextBox1.Text, 8, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "i" Then
                    cryp = Mid(TextBox1.Text, 9, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "j" Then
                    cryp = Mid(TextBox1.Text, 10, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "k" Then
                    cryp = Mid(TextBox1.Text, 11, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "l" Then
                    cryp = Mid(TextBox1.Text, 12, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "m" Then
                    cryp = Mid(TextBox1.Text, 13, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "n" Then
                    cryp = Mid(TextBox1.Text, 14, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "o" Then
                    cryp = Mid(TextBox1.Text, 15, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "p" Then
                    cryp = Mid(TextBox1.Text, 16, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "q" Then
                    cryp = Mid(TextBox1.Text, 17, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "r" Then
                    cryp = Mid(TextBox1.Text, 18, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "s" Then
                    cryp = Mid(TextBox1.Text, 19, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "t" Then
                    cryp = Mid(TextBox1.Text, 20, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "u" Then
                    cryp = Mid(TextBox1.Text, 21, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "v" Then
                    cryp = Mid(TextBox1.Text, 22, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "w" Then
                    cryp = Mid(TextBox1.Text, 23, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "x" Then
                    cryp = Mid(TextBox1.Text, 24, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "y" Then
                    cryp = Mid(TextBox1.Text, 25, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "z" Then
                    cryp = Mid(TextBox1.Text, 26, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = " " Then
                    cryp = Mid(TextBox1.Text, 27, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "1" Then
                    cryp = Mid(TextBox1.Text, 28, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "2" Then
                    cryp = Mid(TextBox1.Text, 29, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "3" Then
                    cryp = Mid(TextBox1.Text, 30, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "4" Then
                    cryp = Mid(TextBox1.Text, 31, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "5" Then
                    cryp = Mid(TextBox1.Text, 32, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "6" Then
                    cryp = Mid(TextBox1.Text, 33, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "7" Then
                    cryp = Mid(TextBox1.Text, 34, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "8" Then
                    cryp = Mid(TextBox1.Text, 35, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "9" Then
                    cryp = Mid(TextBox1.Text, 36, 2)
                    TextBox3.AppendText(cryp)
                ElseIf chars = "0" Then
                    cryp = Mid(TextBox1.Text, 37, 2)
                    TextBox3.AppendText(cryp)

                End If

                lenght = lenght - 1
                ProgressBar1.Value = ProgressBar1.Value + 1

            End While
        End If

    End Sub

    Sub decrypt()

        If RadioButton1.Checked = True Then

            lenght = TextBox2.Text.Length
            ProgressBar1.Maximum = lenght
            ProgressBar1.Value = 0

            While lenght > 0

                chars = Mid(TextBox2.Text, 1, 2)

                mss = mss + chars

                TextBox2.Text = TextBox2.Text.Remove(0, 2)

                If chars = Mid(TextBox1.Text, 1, 2) Then
                    cryp = "a"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 2, 2) Then
                    cryp = "b"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 3, 2) Then
                    cryp = "c"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 4, 2) Then
                    cryp = "d"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 5, 2) Then
                    cryp = "e"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 6, 2) Then
                    cryp = "f"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 7, 2) Then
                    cryp = "g"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 8, 2) Then
                    cryp = "h"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 9, 2) Then
                    cryp = "i"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 10, 2) Then
                    cryp = "j"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 11, 2) Then
                    cryp = "k"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 12, 2) Then
                    cryp = "l"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 13, 2) Then
                    cryp = "m"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 14, 2) Then
                    cryp = "n"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 15, 2) Then
                    cryp = "o"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 16, 2) Then
                    cryp = "p"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 17, 2) Then
                    cryp = "q"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 18, 2) Then
                    cryp = "r"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 19, 2) Then
                    cryp = "s"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 20, 2) Then
                    cryp = "t"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 21, 2) Then
                    cryp = "u"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 22, 2) Then
                    cryp = "v"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 23, 2) Then
                    cryp = "w"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 24, 2) Then
                    cryp = "x"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 25, 2) Then
                    cryp = "y"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 26, 2) Then
                    cryp = "z"
                    TextBox3.AppendText(cryp)


                End If

                lenght = lenght - 2
                ProgressBar1.Value = ProgressBar1.Value + 2

            End While

        ElseIf RadioButton2.Checked = True Then

            lenght = TextBox2.Text.Length
            ProgressBar1.Maximum = lenght
            ProgressBar1.Value = 0

            While lenght > 0

                chars = Mid(TextBox2.Text, 1, 2)

                mss = mss + chars

                TextBox2.Text = TextBox2.Text.Remove(0, 2)

                If chars = Mid(TextBox1.Text, 1, 2) Then
                    cryp = "a"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 2, 2) Then
                    cryp = "b"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 3, 2) Then
                    cryp = "c"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 4, 2) Then
                    cryp = "d"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 5, 2) Then
                    cryp = "e"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 6, 2) Then
                    cryp = "f"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 7, 2) Then
                    cryp = "g"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 8, 2) Then
                    cryp = "h"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 9, 2) Then
                    cryp = "i"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 10, 2) Then
                    cryp = "j"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 11, 2) Then
                    cryp = "k"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 12, 2) Then
                    cryp = "l"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 13, 2) Then
                    cryp = "m"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 14, 2) Then
                    cryp = "n"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 15, 2) Then
                    cryp = "o"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 16, 2) Then
                    cryp = "p"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 17, 2) Then
                    cryp = "q"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 18, 2) Then
                    cryp = "r"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 19, 2) Then
                    cryp = "s"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 20, 2) Then
                    cryp = "t"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 21, 2) Then
                    cryp = "u"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 22, 2) Then
                    cryp = "v"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 23, 2) Then
                    cryp = "w"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 24, 2) Then
                    cryp = "x"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 25, 2) Then
                    cryp = "y"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 26, 2) Then
                    cryp = "z"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 27, 2) Then
                    cryp = " "
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 28, 2) Then
                    cryp = "1"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 29, 2) Then
                    cryp = "2"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 30, 2) Then
                    cryp = "3"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 31, 2) Then
                    cryp = "4"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 32, 2) Then
                    cryp = "5"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 33, 2) Then
                    cryp = "6"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 34, 2) Then
                    cryp = "7"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 35, 2) Then
                    cryp = "8"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 36, 2) Then
                    cryp = "9"
                    TextBox3.AppendText(cryp)
                ElseIf chars = Mid(TextBox1.Text, 37, 2) Then
                    cryp = "0"
                    TextBox3.AppendText(cryp)


                End If

                lenght = lenght - 2
                ProgressBar1.Value = ProgressBar1.Value + 2

            End While

        End If

    End Sub

    Sub reset()

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ProgressBar1.Value = 0

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()

        For i = 0 To My.Computer.FileSystem.GetFiles("C:\Fl crypt\38\").Count - 1

            ListBox2.Items.Add(My.Computer.FileSystem.GetFiles("C:\Fl crypt\38\").Item(i))

        Next i

        For i = 0 To My.Computer.FileSystem.GetFiles("C:\Fl crypt\27\").Count - 1

            ListBox1.Items.Add(My.Computer.FileSystem.GetFiles("C:\Fl crypt\27\").Item(i))

        Next i

        Button3.Enabled = False
        Button4.Enabled = False
        Button8.BackColor = Color.Red
        Button3.BackColor = Color.Red
        Button4.BackColor = Color.Red
        Timer1.Enabled = True
        Label4.Visible = False
        Beep()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If Button8.BackColor = Color.Red Then
            Button8.BackColor = Color.Orange
            Label3.Visible = False
        Else : Button8.BackColor = Color.Red
            Label3.Visible = True
        End If

    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked

        MsgBox("Pour envoyer un msg a quelq'un metter la key au debut de votre msg dite lui de quelle type de key donc il peut l'isoler et recuperer le msg sans la key et peut donc le decrypter :D ex: key:HJHSD msg:KIHJDSO msg a envoyer HJHSDKIHJDSO vous luis dite de quelle type de key il s'agit par exemple une 38 donc il sais le nombre de charactere il y a il compte dans le message qu'il a recu HJHSDKIHJDSO il isole la key HJHSD et sen sert pour decrypter le msg KIHJDSO ou alors il utilise key-separator")

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Form2.Show()
    End Sub

    Private Sub TextMelangerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextMelangerToolStripMenuItem.Click

        Form3.Show()

    End Sub

    Private Sub Key27ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Key27ToolStripMenuItem.Click
        Process.Start("C:\Fl crypt\27")
    End Sub

    Private Sub Key38ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Key38ToolStripMenuItem.Click
        Process.Start("C:\Fl crypt\38")
    End Sub

    Private Sub QuitterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitterToolStripMenuItem1.Click
        End
    End Sub
End Class
