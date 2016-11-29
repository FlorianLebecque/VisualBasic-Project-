Public Class Form1

    Dim ran_Color As New Random
    Dim InGame As Boolean
    Dim list As New List(Of Control), list2 As New List(Of Control)
    Dim i As Integer = 0
    Dim cur_color As Color
    Dim actu As Boolean = True
    Dim score As Double, Hight_score As Double, Cur_Hs As Integer, pre_score As Double
    Dim Alist As Boolean
    Dim list_fall As New List(Of Control)
    Dim Bord_droit As Integer
    Dim pc As Double

    Private Sub Bt_new_Click(sender As Object, e As EventArgs) Handles Bt_new.Click

        Dim a As Integer = 1
        Dim b As Integer = 1

        Bord_droit = 0


        Select Case ComboBox1.Text

            Case "Petit"
                Bord_droit = 10
                Hight_score = Val(My.Settings.Hight_score_petit)
                Cur_Hs = 0
            Case "Moyen"
                Bord_droit = 15
                Hight_score = Val(My.Settings.Hight_score_moyen)
                Cur_Hs = 1
            Case "Grand"
                Bord_droit = 25
                Hight_score = Val(My.Settings.Hight_score_grand)
                Cur_Hs = 2

        End Select
        pc = 0

        FLP.Controls.Clear()

        If Bord_droit <> 0 Then

            For n = 1 To Bord_droit * Bord_droit

                Dim bt As New Button
                bt.Width = 450 / Bord_droit
                bt.Height = bt.Width
                bt.FlatStyle = FlatStyle.Flat

                bt.Margin = New Padding(0)

                bt.Name = "Bt_" + a.ToString + ":" + b.ToString

                AddHandler bt.Click, AddressOf Dym_bt_click

                FLP.Controls.Add(bt)
                b += 1

                If b > Bord_droit Then
                    b = 1
                    a += 1
                End If

            Next

            Label1.ForeColor = Color.Black
            Label2.Text = Hight_score.ToString
            score = 0
            Label1.Text = score.ToString
            Label3.Text = "0%"

            For Each c As Control In FLP.Controls

                Dim Col As Integer
                Col = ran_Color.Next(0, 4)

                Select Case Col

                    Case 0
                        c.BackColor = Color.Blue
                    Case 1
                        c.BackColor = Color.Red
                    Case 2
                        c.BackColor = Color.Yellow
                    Case 3
                        c.BackColor = Color.Green

                End Select

                InGame = True 'active le jeux

            Next

        Else

            MsgBox("Selectionnez une taille de grill !")

        End If

    End Sub

    Public Sub bt_test()

        Dim Colum As Integer, ligne As Integer

        If actu = True Then

            For Each bt In list 'cherche tout les buttons au alentour

                Colum = Val(Mid(bt.Name, bt.Name.IndexOf(":") + 2))
                ligne = Val(Mid(bt.Name, 4, bt.Name.Count - (bt.Name.IndexOf(":"))))

                Try
                    If bt.BackColor = FLP.Controls("Bt_" + (ligne + 1).ToString + ":" + Colum.ToString).BackColor And list.Contains(FLP.Controls("Bt_" + (ligne + 1).ToString + ":" + Colum.ToString)) = False Then 'button du dessous

                        list2.Add(FLP.Controls("Bt_" + (ligne + 1).ToString + ":" + Colum.ToString))

                    End If
                Catch ex As Exception
                End Try

                Try
                    If bt.BackColor = FLP.Controls("Bt_" + (ligne).ToString + ":" + (Colum + 1).ToString).BackColor And list.Contains(FLP.Controls("Bt_" + (ligne).ToString + ":" + (Colum + 1).ToString)) = False Then 'button de droite

                        list2.Add(FLP.Controls("Bt_" + (ligne).ToString + ":" + (Colum + 1).ToString))

                    End If
                Catch ex As Exception
                End Try

                Try
                    If bt.BackColor = FLP.Controls("Bt_" + (ligne).ToString + ":" + (Colum - 1).ToString).BackColor And list.Contains(FLP.Controls("Bt_" + (ligne).ToString + ":" + (Colum - 1).ToString)) = False Then 'button de gauche

                        list2.Add(FLP.Controls("Bt_" + (ligne).ToString + ":" + (Colum - 1).ToString))

                    End If
                Catch ex As Exception
                End Try

                Try
                    If bt.BackColor = FLP.Controls("Bt_" + (ligne - 1).ToString + ":" + Colum.ToString).BackColor And list.Contains(FLP.Controls("Bt_" + (ligne - 1).ToString + ":" + Colum.ToString)) = False Then 'button du dessu

                        list2.Add(FLP.Controls("Bt_" + (ligne - 1).ToString + ":" + Colum.ToString))

                    End If
                Catch ex As Exception
                End Try

            Next

            If list2.Count = 0 Then 'test si il y a pas eu des nouveau button
                actu = False 'desactive la recherche
            End If

            For Each elem In list2

                If list.Contains(elem) = False Then
                    list.Add(elem)
                End If

            Next

            list2.Clear()

            bt_test()

        End If

    End Sub

    Sub Dym_bt_click(sender As Object, e As EventArgs)

        Dim bt As Button = sender

        Dim Colum As Integer, ligne As Integer
        Colum = Mid(bt.Name, bt.Name.IndexOf(":") + 2)
        ligne = Val(Mid(bt.Name, 4, (bt.Name.Count - (bt.Name.IndexOf(":")))))

        If bt.BackColor <> cur_color Then 'test si on a bien clicker sur un button de la meme couleur

            cur_color = bt.BackColor
            list.Clear()
            actu = True
            Alist = False

        ElseIf list.Contains(bt) = False Then

            cur_color = bt.BackColor
            list.Clear()
            actu = True
            Alist = False

        End If

        If Alist = False And bt.BackColor <> Color.White Then

            Try
                If bt.BackColor = FLP.Controls("Bt_" + (ligne + 1).ToString + ":" + Colum.ToString).BackColor And list.Contains(FLP.Controls("Bt_" + (ligne + 1).ToString + ":" + Colum.ToString)) = False Then 'button du dessous

                    list.Add(FLP.Controls("Bt_" + (ligne + 1).ToString + ":" + Colum.ToString))

                End If

            Catch ex As Exception
            End Try

            Try
                If bt.BackColor = FLP.Controls("Bt_" + (ligne).ToString + ":" + (Colum + 1).ToString).BackColor And list.Contains(FLP.Controls("Bt_" + (ligne).ToString + ":" + (Colum + 1).ToString)) = False Then 'button de droite

                    list.Add(FLP.Controls("Bt_" + (ligne).ToString + ":" + (Colum + 1).ToString))

                End If
            Catch ex As Exception
            End Try

            Try
                If bt.BackColor = FLP.Controls("Bt_" + (ligne).ToString + ":" + (Colum - 1).ToString).BackColor And list.Contains(FLP.Controls("Bt_" + (ligne).ToString + ":" + (Colum - 1).ToString)) = False Then 'button de gauche

                    list.Add(FLP.Controls("Bt_" + (ligne).ToString + ":" + (Colum - 1).ToString))

                End If
            Catch ex As Exception
            End Try

            Try
                If bt.BackColor = FLP.Controls("Bt_" + (ligne - 1).ToString + ":" + Colum.ToString).BackColor And list.Contains(FLP.Controls("Bt_" + (ligne - 1).ToString + ":" + Colum.ToString)) = False Then 'button du dessu

                    list.Add(FLP.Controls("Bt_" + (ligne - 1).ToString + ":" + Colum.ToString))

                End If
            Catch ex As Exception
            End Try

            list.Add(bt)
            Dim tb As New TextBox
            For Each ele In list
                tb.AppendText(ele.Name + vbNewLine)
            Next

            'MsgBox(tb.Text)

            If list.Count > 1 Then
                bt_test()

            End If

            Alist = True

        Else

            If list.Contains(bt) = True And list.Count > 1 Then

                If list.Count > 1 Then 'test si 2 button son selectionner

                    For Each Control In list

                        If Control.BackColor = cur_color Then 'retire la couleur des buttons
                            Control.BackColor = Color.White
                        End If

                    Next

                    pre_score = list.Count * (list.Count - 1)

                    pc += list.Count

                    score += pre_score

                    Label1.Text = score.ToString

                    list.Clear() 'efface la list

                    If score > Hight_score Then

                        Hight_score = score

                        Select Case Cur_Hs

                            Case 0
                                My.Settings.Hight_score_petit = Hight_score.ToString
                            Case 1
                                My.Settings.Hight_score_moyen = Hight_score.ToString
                            Case 2
                                My.Settings.Hight_score_grand = Hight_score.ToString

                        End Select

                        My.Settings.Save()

                        Label2.Text = Hight_score
                        Label1.ForeColor = Color.Green

                    End If

                    Dim t As String

                    t = ((pc / Bord_droit ^ 2) * 100).ToString

                    Label3.Text = Mid(t, 1, 4) + "%"


                End If

                Alist = False

            End If

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim str As New TextBox

        For Each c In list

            str.AppendText(c.Name + vbNewLine)

        Next

        MsgBox(str.Text)

    End Sub 'bt de test

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        list_fall.Clear()

        For Each bt As Button In FLP.Controls 'deplace les lignes

            Dim colum As Integer, ligne As Integer
            colum = Val(Mid(bt.Name, bt.Name.IndexOf(":") + 2))
            ligne = Val(Mid(bt.Name, 4, bt.Name.Count - (bt.Name.IndexOf(":"))))

            If bt.BackColor = Color.White And ligne <> "1" Then

                If FLP.Controls("Bt_" + (ligne - 1).ToString + ":" + colum.ToString).BackColor <> Color.White Then
                    list_fall.Add(bt)
                    bt.BackColor = FLP.Controls("Bt_" + (ligne - 1).ToString + ":" + colum.ToString).BackColor

                    FLP.Controls("Bt_" + (ligne - 1).ToString + ":" + colum.ToString).BackColor = Color.White

                End If

            End If

        Next

        For Each bt As Button In FLP.Controls 'deplace les colones

            Dim colum As Integer, ligne As Integer
            colum = Val(Mid(bt.Name, bt.Name.IndexOf(":") + 2))
            ligne = Val(Mid(bt.Name, 4, bt.Name.Count - (bt.Name.IndexOf(":"))))

            If ligne = Bord_droit.ToString And bt.BackColor = Color.White And colum <> "1" And list_fall.Count = 0 Then

                For n = 1 To Bord_droit

                    FLP.Controls("Bt_" + (n).ToString + ":" + (colum).ToString).BackColor = FLP.Controls("Bt_" + (n).ToString + ":" + (colum - 1).ToString).BackColor
                    FLP.Controls("Bt_" + (n).ToString + ":" + (colum - 1).ToString).BackColor = Color.White

                Next

            End If

        Next

        For Each ctrl As Button In FLP.Controls

            If list.Contains(ctrl) = True Then

                ctrl.FlatAppearance.BorderSize = 5
            Else
                ctrl.FlatAppearance.BorderSize = 0
            End If

        Next


    End Sub 'deplace les couleurs pour les rassenbler

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label2.Text = "0"
        Timer1.Start()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        MsgBox("----------Score----------" + vbNewLine + "Petit : " + My.Settings.Hight_score_petit + vbNewLine + "Moyen : " + My.Settings.Hight_score_moyen + vbNewLine + "Grand : " + My.Settings.Hight_score_grand, , "BubbleBreaker Hight Score")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("FormFl inc Game production , Dev Florian Lebecque")
    End Sub
End Class