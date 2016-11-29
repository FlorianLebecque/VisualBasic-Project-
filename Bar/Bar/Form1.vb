Imports System.IO

Public Class Form1

    Dim path As String, path2 As FileInfo
    Dim SupMod As Boolean = False
    Public menushow As Boolean
    Dim back As String

    Dim hides As Boolean


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Computer.FileSystem.DirectoryExists("C:\FormFL\Bar\Bprim\") = False Then 'check le dossier du programme
            My.Computer.FileSystem.CreateDirectory("C:\FormFL\Bar\Bprim\") 'creer le dossier des button
            My.Computer.FileSystem.CreateDirectory("C:\FormFL\Bar\Note\") 'creer le dossier des note
            My.Computer.FileSystem.CreateDirectory("C:\FormFL\Bar\Folder\") 'creer le dossier des note
            Dim NbrnSav As New StreamWriter("C:\FormFL\Bar\Setting.txt") 'creer le fichier des parametres
            NbrnSav.Close()
        End If

        Me.Height = My.Computer.Screen.Bounds.Height 'definit la taile du programme

        For i = 0 To My.Computer.FileSystem.GetFiles("C:\FormFL\Bar\Bprim\").Count - 1 'list le dossier des button pour les recreer au demmarage

            Dim btn As New Button 'definit proprieter basic du button
            btn.Height = 30
            btn.Width = 138
            btn.BackColor = Color.WhiteSmoke

            Dim SBC As New StreamReader(My.Computer.FileSystem.GetFiles("C:\FormFL\Bar\Bprim\").Item(i)) 'lit les proprieter du button
            btn.Text = SBC.ReadLine 'le nom
            btn.Tag = SBC.ReadLine  'chemin d'acces
            SBC.Close()

            AddHandler btn.Click, AddressOf B_click 'ajout l'event click au button
            ControlZone.Controls.Add(btn) 'ajout le button au control

        Next i

        Dim Sett As String 'lecture des paramettres

        Sett = Mid(My.Settings.setting, 1, 3)

        If Sett = "IMG" Then 'affiche l'image

            back = Mid(My.Settings.setting, 5)
            ControlZone.BackgroundImage = Image.FromFile(back) 'met l'image en fond
            Form2.FlowLayoutPanel1.BackgroundImage = Image.FromFile(back)

        ElseIf Sett = "COL" Then 'definit la couleur

            Dim b As String
            b = Mid(My.Settings.setting, 5)

            Select Case b

                Case "bleu"

                    ControlZone.BackColor = Color.Blue
                    Form2.FlowLayoutPanel1.BackColor = Color.Blue

                Case "rouge"

                    ControlZone.BackColor = Color.Red
                    Form2.FlowLayoutPanel1.BackColor = Color.Red

                Case "vert"

                    ControlZone.BackColor = Color.Green
                    Form2.FlowLayoutPanel1.BackColor = Color.Green

                Case "viollet"

                    ControlZone.BackColor = Color.Violet
                    Form2.FlowLayoutPanel1.BackColor = Color.Violet

                Case "orange"

                    ControlZone.BackColor = Color.Orange
                    Form2.FlowLayoutPanel1.BackColor = Color.Orange

                Case "gris"

                    ControlZone.BackColor = Color.Gray
                    Form2.FlowLayoutPanel1.BackColor = Color.Gray

                Case "blanc"

                    ControlZone.BackColor = Color.White
                    Form2.FlowLayoutPanel1.BackColor = Color.White

                Case "noir"

                    ControlZone.BackColor = Color.Black
                    Form2.FlowLayoutPanel1.BackColor = Color.Black

            End Select

        End If




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End 'Ferme le programme
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        
            OPD.ShowDialog()
            If OPD.FileName <> Nothing Then

                Dim b As New Button 'definition des proprieter du button
                b.Height = 30
                b.Width = 138
                b.Tag = OPD.FileName 'definit chemin d'acces du programme a ouvrir
            b.BackColor = Color.WhiteSmoke
                path = OPD.FileName
                path2 = New FileInfo(path) 'recupere le nom du fichier a ouvrir

                b.Text = Mid(path2.Name, 1, path2.Name.IndexOf(".")) ' definit le text du button et retire l'extention du fichier

                AddHandler b.Click, AddressOf B_click 'ajout l'event click au button

                ControlZone.Controls.Add(b) 'ajout le button au FlowLayoutPanel

                Dim BTsave As New StreamWriter("C:\FormFL\Bar\Bprim\" + b.Text + ".FLBB") 'sauvgarde le button dans le dossier Bprim
                BTsave.WriteLine(b.Text) 'le text
                BTsave.WriteLine(b.Tag) 'le chemin d'acces
                BTsave.Close()

        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If SupMod = False Then 'active le mode du suppression
            SupMod = True
            Button4.BackColor = Color.Red
        Else 'desactive le mod suppression
            SupMod = False
            Button4.ResetBackColor()
        End If

    End Sub 'mod suppresion

    Sub B_click(sender As Object, e As EventArgs)

        Dim bt As Button = sender

        If SupMod = False Then
            Process.Start(bt.Tag) 'ouvre le fichier avec le chemin d'acces compris dans le tag
        ElseIf SupMod = True Then
            My.Computer.FileSystem.DeleteFile("C:\FormFL\Bar\Bprim\" + bt.Text + ".FLBB") 'supprime le fichier de sauvgarde du button
            ControlZone.Controls.Remove(bt) 'supprimme le button de control
        End If

    End Sub 'click sur un btn

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        menushow = True
        Timer1.Start()
        Form2.Show()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If menushow = True And Form2.Location.X <> 0 Then

            Form2.Location = New Point(Form2.Location.X + 67, Form2.Location.Y)
            Form2.BringToFront()

        ElseIf menushow = False And Form2.Location.X <> -737 Then

            Form2.Location = New Point(Form2.Location.X - 67, Form2.Location.Y)

        End If

        If menushow = True And Form2.Location.X = 0 Then

            Timer1.Stop()
        ElseIf menushow = False And Form2.Location.X = -732 Then
            Timer1.Stop()
            Form2.Hide()
        End If

    End Sub 'cacher le menu

    Private Sub BtHide_Click(sender As Object, e As EventArgs) Handles BtHide.Click

        hides = True
        Timer2.Start()

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If Me.Location.X = -142 And hides = True Then
            Timer2.Stop()
            hides = False
            Form4.Show()

        ElseIf hides = True And Me.Location.X <= 0 Then

            Me.Location = New Point(Me.Location.X - 2)

        End If


    End Sub 'cacher la bar
End Class
