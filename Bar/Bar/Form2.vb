Imports System.IO
Imports System.Math

Public Class Form2
    Dim op As String
    Dim nbr As Double, nbr2 As Double
    Dim Nombre As String
    Public NbrN As Integer
    Dim supMod As Boolean

    Dim FolName As String

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Form1.menushow = False
        Form1.Timer1.Start()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        NbrN += 1

        Dim NP As New TabPage 'creer le tab
        Dim Rtb As New RichTextBox 'creer la boite de text
        Rtb.Dock = DockStyle.Fill
        NP.Tag = NbrN

        AddHandler Rtb.TextChanged, AddressOf Rtb_textchanges 'ajoute l'event au rtb

        NP.Controls.Add(Rtb) 'ajout la rtb au tab
        TabControl1.TabPages.Add(NP) 'ajoute le tab au tabcontrol

        Dim NbrnSav As New StreamWriter("C:\FormFL\Bar\Setting.txt") 'sauvgarde le nombre de page de note il y a
        NbrnSav.WriteLine(NbrN.ToString)
        NbrnSav.Close()

    End Sub

    Sub Rtb_textchanges(sender As Object, e As EventArgs)
        Dim rt As RichTextBox = sender

        If rt.Text <> Nothing Then
            rt.Parent.Text = rt.Lines(rt.Lines.Length - rt.Lines.Length).ToString 'definit le titre du tab
        End If

        Dim Nsav As New StreamWriter("C:\FormFL\Bar\Note\" + rt.Parent.Tag.ToString) 'sauvgarde le text
        Nsav.WriteLine(rt.Text)
        Nsav.Close()

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load

        For Each fol In My.Computer.FileSystem.GetDirectories("C:\FormFl\Bar\Folder") 'creation des dossiers

            Dim tab As New TabPage 'creation de la page
            tab.Text = Mid(fol, 22)
            tab.Tag = "f"

            Dim flow As New FlowLayoutPanel 'du flow panel
            flow.Dock = DockStyle.Fill

            Dim btadd As New Button 'button ajouter 
            btadd.Text = "Add"
            AddHandler btadd.Click, AddressOf btadd_click

            Dim btsupp As New Button 'button supprimer
            btsupp.Text = "del"
            AddHandler btsupp.Click, AddressOf btsupp_click

            flow.Controls.Add(btadd)
            flow.Controls.Add(btsupp)

            For i = 0 To My.Computer.FileSystem.GetFiles(fol).Count - 1 'list le dossier des button pour les recreer au demmarage

                Dim btn As New Button 'definit proprieter basic du button
                btn.Height = 50
                btn.Width = 50
                btn.BackColor = Color.WhiteSmoke

                Dim SBC As New StreamReader(My.Computer.FileSystem.GetFiles(fol).Item(i)) 'lit les proprieter du button
                btn.Text = SBC.ReadLine 'le nom
                btn.Tag = SBC.ReadLine  'chemin d'acces
                SBC.Close()

                AddHandler btn.Click, AddressOf b_click 'ajout l'event click au button
                flow.Controls.Add(btn)

            Next i


            tab.Controls.Add(flow)
            TabControl1.Controls.Add(tab)


        Next

        Dim sw As New StreamReader("C:\FormFL\Bar\Setting.txt") 'definit le Nombre tab note
        NbrN = sw.ReadLine
        sw.Close()

        If NbrN <> 0 Then 'creer un tab en fonction du nombre enregister

            For i = 1 To NbrN

                Dim NP As New TabPage 'creer le tab
                Dim Rtb As New RichTextBox 'creer la boite de text
                Rtb.Dock = DockStyle.Fill
                NP.Tag = NbrN

                AddHandler Rtb.TextChanged, AddressOf Rtb_textchanges 'ajoute l'event au rtb

                Dim Nread As New StreamReader("C:\FormFL\Bar\Note\" + i.ToString) 'lit la note en fonction de i pour que sa colle avec le tab
                Rtb.Text = Nread.ReadToEnd
                Nread.Close()

                NP.Controls.Add(Rtb) 'ajout la rtb au tab
                Rtb.Parent.Text = Rtb.Lines(Rtb.Lines.Length - Rtb.Lines.Length).ToString

                TabControl1.TabPages.Add(NP) 'ajoute le tab au tabcontrol

            Next
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If SupMod = False Then 'active le mode du suppression
            SupMod = True
            Button2.BackColor = Color.Red
        Else 'desactive le mod suppression
            SupMod = False
            Button2.ResetBackColor()
        End If

    End Sub

    Private Sub TabControl1_Click(sender As Object, e As EventArgs) Handles TabControl1.Click

        If supMod = True Then

            If TabControl1.SelectedTab.Tag.ToString = "f" Then

                My.Computer.FileSystem.DeleteDirectory("C:\FormFl\Bar\Folder\" + TabControl1.SelectedTab.Text, FileIO.DeleteDirectoryOption.DeleteAllContents) 'supprime le dossier et son contenu
                TabControl1.Controls.Remove(TabControl1.SelectedTab) 'supprime le tab

            ElseIf TabControl1.SelectedTab.Tag.ToString <> "cal" Or TabControl1.SelectedTab.Tag.ToString <> "f" Then

                My.Computer.FileSystem.DeleteFile("C:\FormFL\Bar\Note\" + TabControl1.SelectedTab.Tag.ToString) 'supprime la note associer
                TabControl1.Controls.Remove(TabControl1.SelectedTab) 'supprime le tab

                NbrN -= 1
                Dim NbrnSav As New StreamWriter("C:\FormFL\Bar\Setting.txt") 'sauvgarde le nombre de page de note il y a
                NbrnSav.WriteLine(NbrN.ToString)
                NbrnSav.Close()

            End If

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Form3.Show()


    End Sub

    Private Sub Btclick(sender As Object, e As EventArgs) Handles bt4.Click, bt3.Click, bt2.Click, bt1.Click, bt0.Click, bt9.Click, bt8.Click, bt7.Click, bt6.Click, bt5.Click, btvir.Click

        Dim bt As Button = sender 'ajoute le chiffre du button dans la textbox1
        TextBox1.AppendText(bt.Text)

    End Sub

    Private Sub btce_Click(sender As Object, e As EventArgs) Handles btce.Click

        op = Nothing 'efface tout
        nbr = Nothing
        nbr2 = Nothing
        TextBox1.Clear()
        TextBox2.Clear()
        Label2.Text = "."

    End Sub

    Private Sub btegal_Click(sender As Object, e As EventArgs) Handles btegal.Click
        If op <> Nothing And TextBox1.Text <> Nothing Then

            nbr = Val(TextBox1.Text)
            nbr2 = Val(TextBox2.Text)
            Dim res As Double

            Select Case op 'execute l'operation

                Case "+"
                    res = nbr2 + +nbr
                    ListBox1.Items.Add(nbr2.ToString + " + " + nbr.ToString + " = " + res.ToString)

                Case "-"
                    res = nbr2 - nbr
                    ListBox1.Items.Add(nbr2.ToString + " - " + nbr.ToString + " = " + res.ToString)
                Case "x"
                    res = nbr2 * nbr
                    ListBox1.Items.Add(nbr2.ToString + " x " + nbr.ToString + " = " + res.ToString)
                Case "/"
                    res = nbr2 / nbr
                    ListBox1.Items.Add(nbr2.ToString + " / " + nbr.ToString + " = " + res.ToString)

            End Select

            TextBox1.Text = res.ToString
            ListBox1.TopIndex = ListBox1.Items.Count - 1 'auto scroll

        End If
    End Sub

    Private Sub Btop(sender As Object, e As EventArgs) Handles btplus.Click, btmoin.Click, btfois.Click, btdiv.Click

        Dim bt As Button = sender

        If TextBox1.Text <> Nothing Then 'selectionne une operation

            op = bt.Text
            Label2.Text = bt.Text

            TextBox2.Text = TextBox1.Text
            TextBox1.Clear()

        End If
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click

        Dim ran As New Random, nbe As Integer 'creer un nombre aleatoire
        nbe = ran.Next(0, 100)
        TextBox1.AppendText(nbe)

    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        TextBox1.AppendText(PI) 'met pi
    End Sub

    Private Sub Nombret(sender As Object, e As EventArgs) Handles Button31.Click, Button30.Click, Button29.Click, Button28.Click, Button27.Click, Button26.Click, Button25.Click, Button24.Click, Button23.Click, Button22.Click

        Dim bt As Button = sender 'creer la fenetre de calcule des operation specifique

        Nombre = bt.Text

        Dim f As New Form 'creer la form
        f.Height = 80
        f.Width = 300
        f.Text = bt.Text
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        f.MaximizeBox = False

        Dim tb As New TextBox 'creer la textbox
        tb.Location = New Point(12, 12)
        tb.Width = 200
        tb.Name = "tbNbr"


        Dim bte As New Button 'creer un button
        bte.Location = New Point(213, 12)
        bte.Width = 60
        bte.Height = 20
        bte.Text = bt.Text

        AddHandler bte.Click, AddressOf nombrete

        f.Controls.Add(bte)
        f.Controls.Add(tb)
        f.Show()


    End Sub

    Sub nombrete(sender As Object, e As EventArgs)

        Dim bt As Button = sender


        Dim nom As Double = Val(bt.Parent.Controls("tbNbr").Text)
        Dim nom2 As Double

        nom2 = PI * nom / 180 'convertit les degreer en radian

        Select Case Nombre 'effectue l'operation

            Case "Cos"
                TextBox1.Text = Cos(nom2)
            Case "Sin"
                TextBox1.Text = Sin(nom2)
            Case "Tan"
                TextBox1.Text = Tan(nom2)
            Case "CoTan"
                TextBox1.Text = 1 / Tan(nom2)
            Case "Acs"
                TextBox1.Text = Acos(nom2)
            Case "Asn"
                TextBox1.Text = Asin(nom2)
            Case "Atn"
                TextBox1.Text = Atan(nom2)
            Case "Acotn"
                TextBox1.Text = 1 / Atan(nom2)
            Case "^"
                If TextBox1.Text <> Nothing Then
                    TextBox1.Text = Val(TextBox1.Text) ^ nom
                End If
            Case "v-"
                TextBox1.Text = Sqrt(nom)


        End Select



    End Sub 'operation mathematique specifique

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        TextBox1.Text = TextBox1.Text.Replace(",", ".")

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim f As New Form 'creation d'une form pour nommer le dossier
        f.Height = 100
        f.Width = 300
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        f.Text = "Name your folder"

        Dim bt As New Button 'creation d'un button de validation
        bt.Text = "ok"
        bt.Location = New Point(200)
        AddHandler bt.Click, AddressOf Btn

        Dim tb As New TextBox 'creation d'un champ pour ecrire le nom
        tb.Width = 200
        tb.Name = "Tbnom"

        
        f.Controls.Add(tb)
        f.Controls.Add(bt)
        f.Show()

        

    End Sub 'creation de tab et du dossier partie 1

    Sub ajouttab()

        Dim tab As New TabPage
        tab.Text = FolName
        tab.Tag = "f"

        Dim flow As New FlowLayoutPanel
        flow.Dock = DockStyle.Fill

        Dim btadd As New Button
        btadd.Text = "Add"
        AddHandler btadd.Click, AddressOf btadd_click

        Dim btsupp As New Button
        btsupp.Text = "del"
        AddHandler btsupp.Click, AddressOf btsupp_click

        My.Computer.FileSystem.CreateDirectory("C:\FormFL\Bar\Folder\" + FolName + "\")


        flow.Controls.Add(btadd)
        flow.Controls.Add(btsupp)
        tab.Controls.Add(flow)
        TabControl1.Controls.Add(tab)

    End Sub 'creation du tab et du dossier partie 2

    Sub Btn(sender As Object, e As EventArgs)

        Dim bt As Button = sender
        FolName = bt.Parent.Controls("Tbnom").Text 'definition du nom du tab
        ajouttab()
        bt.Parent.Dispose()

    End Sub 'definition du nom du tab


    Sub btadd_click(sender As Object, e As EventArgs)

        Dim bt As Button = sender

        Dim Path As String
        Dim path2 As FileInfo

        OPD.ShowDialog()

        If OPD.FileName <> Nothing Then

            Path = OPD.FileName
            path2 = New FileInfo(Path) 'recupere le nom du fichier a ouvrir

            Dim b As New Button 'creer le button
            b.Height = 50
            b.Width = 50
            b.Text = Mid(path2.Name, 1, path2.Name.IndexOf(".")) 'recuperation du nom du button
            b.Tag = Path

            AddHandler b.Click, AddressOf b_click

            bt.Parent.Controls.Add(b)

            Dim BTsave As New StreamWriter("C:\FormFL\Bar\Folder\" + bt.Parent.Parent.Text + "\" + b.Text + ".FLBB") 'sauvgarde le button dans le dossier Bprim
            BTsave.WriteLine(b.Text) 'le text
            BTsave.WriteLine(b.Tag) 'le chemin d'acces
            BTsave.Close()

        End If

    End Sub 'sauvgarde des buttons dans le dossier

    Sub btsupp_click(sender As Object, e As EventArgs)

        Dim bt As Button = sender

        If supMod = False Then 'active le mode du suppression
            supMod = True
            bt.BackColor = Color.Red
        Else 'desactive le mod suppression
            supMod = False
            bt.ResetBackColor()
        End If

    End Sub

    Sub b_click(sender As Object, e As EventArgs)

        Dim bt As Button = sender

        If supMod = False Then
            Process.Start(bt.Tag) 'ouvre le fichier avec le chemin d'acces compris dans le tag
        ElseIf supMod = True Then
            My.Computer.FileSystem.DeleteFile("C:\FormFL\Bar\Folder\" + bt.Parent.Parent.Text + "\" + bt.Text + ".FLBB") 'supprime le fichier de sauvgarde du button
            bt.Parent.Controls.Remove(bt) 'supprimme le button de control
        End If

    End Sub

  

End Class