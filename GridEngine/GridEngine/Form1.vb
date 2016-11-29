Public Class Form1

    Public Cur_Ground As Integer, hight As Integer, cur_wall_left As Integer, cur_wall_right As Integer, cur_roof As Integer
    '       altitude du sol        altitude de player   ou se trouve le mur                             hauteur du plafond
    Public state As Integer = 0, dir As Integer = 0
    '0 = tombe,1 = saut,2 = au sol////// 0 = aucune,1= gauche,2 = droite,3 = gauche ralenti,4=droite ralenti

    Public jump_time As Integer, jmt As Integer = 0
    '   temps d'un saut             'etat du saut

    Public Vg_max As Double, Vg As Double, Mv_maxG As Double, Mv_maxA As Double, Mv As Double = 1, FricA As Double, FricG As Double
    'V de chute max         V de chute      V au sol max       V en l'aire max    V horizontal      Friction en l'aire  Friction au sol         

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll

        Timer1.Interval = TrackBar1.Value

    End Sub 'definit la vitesse de la simu

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        player.Select()

        'definit la hauteur du joueur
        hight = player.Location.Y + player.Height

        'definit un minimum (max)
        Dim min_Cur_ground As Integer
        min_Cur_ground = Me.Height * 2
        Dim Max_cur_wall_left_left As Integer
        Max_cur_wall_left_left = -1000
        Dim Min_cur_wall_Right As Integer
        Min_cur_wall_Right = Me.Width * 2
        Dim Max_Roof As Integer
        Max_Roof = -Me.Height * 2

        'cherche la platephorme de chute
        For i = 0 To ListBox1.Items.Count - 1
            Dim area() As String = Split(ListBox1.Items(i), "/")
            'area(0) = altitude
            'area(1) = position X de gauche
            'area(2) = position X de droite
            'area(3) = altitude du bas

            If hight <= Val(area(0)) And (player.Location.X + (player.Width - 1)) >= Val(area(1)) And player.Location.X <= Val(area(2)) Then 'test si le joueur est dedans
                Cur_Ground = Val(area(0))
                'test si c'est la plus haut
                If Cur_Ground <= min_Cur_ground Then
                    min_Cur_ground = Cur_Ground 'si oui definit le minimum sur la platephorm
                End If
            Else
                Cur_Ground = Me.hight * 2
            End If

            If (player.Location.X + player.Width) >= area(1) And player.Location.X <= area(2) And player.Location.Y >= area(3) Then 'cherche le plafond

                'test la valeur la plus haute
                cur_roof = area(3)
                If cur_roof >= Max_Roof Then
                    Max_Roof = cur_roof
                End If

            End If

            If dir = 1 Or dir = 3 Then 'test les murs sur la gauche

                If player.Location.X >= area(2) And (player.Location.Y + player.Height) >= area(0) And player.Location.Y <= area(3) Then

                    cur_wall_left = area(2)
                    If cur_wall_left >= Max_cur_wall_left_left Then
                        Max_cur_wall_left_left = cur_wall_left
                    End If

                End If

            ElseIf dir = 2 Or dir = 4 Then 'test sur la droite

                If (player.Location.X + player.Width) <= area(1) And (player.Location.Y + player.Height) >= area(0) And player.Location.Y <= area(3) Then

                    cur_wall_right = area(1)
                    If cur_wall_right <= Min_cur_wall_Right Then
                        Min_cur_wall_Right = cur_wall_right
                    End If

                End If

            End If

        Next

        cur_roof = Max_Roof 'definit le plafond
        Cur_Ground = min_Cur_ground 'prend le minimu comme base
        cur_wall_left = Max_cur_wall_left_left 'prend le max
        cur_wall_right = Min_cur_wall_Right

        'fait une action de monté ou de desente
        If state = 0 Then
            fall()
        ElseIf state = 1 Then
            jump()
        ElseIf state = 2 Then
            If hight <> Cur_Ground Then
                state = 0
            End If
        End If

        'test si un mouvement doit etre effectuer
        If dir <> 0 Then
            moveLR()
        End If

        Label1.Text = ("player_X : " + player.Location.X.ToString + " / player_Y : " + player.Location.Y.ToString + " / cur_wall_right : " + cur_wall_right.ToString + " / cur_wall_left : " + cur_wall_left.ToString + " / Cur_Ground : " + Cur_Ground.ToString + " / Cur_roof : " + cur_roof.ToString + " / State : " + state.ToString + " / dir : " + dir.ToString + " / Vg : " + Vg.ToString + " / Mv : " + Mv.ToString + " / Mv_maxG : " + Mv_maxG.ToString + " / Mv_maxA : " + Mv_maxA.ToString)

    End Sub

    Sub fall()
        hight = player.Location.Y + player.Height

        If Vg < Vg_max Then 'acceleration verticale
            Vg += My.Settings.G
        End If

        If hight + Vg <= Cur_Ground Then 'fait tomber le joueur
            player.Location = New Point(player.Location.X, player.Location.Y + Vg)
        Else 'fait tombe le jouer parfaitement sur la platephorme
            player.Location = New Point(player.Location.X, player.Location.Y + (Cur_Ground - hight))

        End If

        If hight = Cur_Ground Then 'definit que le joueur touche le sol
            state = 2
            Vg = My.Settings.VgBase
        End If

    End Sub

    Sub jump()

        If jmt < jump_time Then 'fais sauté

            If player.Location.Y - My.Settings.JumpState > cur_roof Then 'check si en dessous du plafond
                player.Location = New Point(player.Location.X, player.Location.Y - My.Settings.JumpState)
            Else
                player.Location = New Point(player.Location.X, player.Location.Y - (player.Location.Y - cur_roof))
                jmt = jump_time
            End If

            jmt += 1

        Else 'arrete le saut
            state = 0
            jmt = 0

        End If

    End Sub

    Sub moveLR()

        If dir = 1 Or dir = 2 Then 'acceleration

            If state = 2 Then 'sur le sol
                If Mv < Mv_maxG Then
                    Mv += FricG
                ElseIf Mv > Mv_maxG + 1 Then
                    Mv -= FricG
                End If
            ElseIf state = 0 Or state = 1 Then 'dans les aires
                If Mv < Mv_maxA Then
                    Mv += FricG
                ElseIf Mv > Mv_maxA Then
                    Mv -= FricA
                End If
            End If

        ElseIf dir = 3 Or dir = 4 Then 'deceleration

            If state = 2 Then 'sur le sol
                If Mv > 1 Then
                    Mv -= FricG
                End If
            ElseIf state = 0 Or state = 1 Then 'dans les aires

                If Mv > 1 Then
                    Mv -= FricA
                End If


            End If

            If Mv <= 1 Then 'arrete le mouvement
                dir = 0
                Mv = Math.Floor(Mv)
            End If

        End If

        If dir = 1 Then 'gauche
            If player.Location.X - Mv > cur_wall_left Then
                player.Location = New Point(player.Location.X - Mv, player.Location.Y)
            Else
                player.Location = New Point(player.Location.X - (player.Location.X - cur_wall_left), player.Location.Y)
            End If

        ElseIf dir = 2 Then 'droite

            If (player.Location.X + player.Width) + Mv < cur_wall_right Then
                player.Location = New Point(player.Location.X + Mv, player.Location.Y)
            Else
                player.Location = New Point(player.Location.X + (cur_wall_right - (player.Location.X + player.Width)), player.Location.Y)
            End If


        ElseIf dir = 3 And player.Location.X > cur_wall_left Then 'gauche decceleration

            If player.Location.X - Mv > cur_wall_left Then
                player.Location = New Point(player.Location.X - Mv, player.Location.Y)
            Else
                player.Location = New Point(player.Location.X - (player.Location.X - cur_wall_left), player.Location.Y)
            End If

        ElseIf dir = 4 Then 'droite decceleration

            If (player.Location.X + player.Width) + Mv < cur_wall_right Then
                player.Location = New Point(player.Location.X + Mv, player.Location.Y)
            Else
                player.Location = New Point(player.Location.X + (cur_wall_right - (player.Location.X + player.Width)), player.Location.Y)
            End If

        End If

        If My.Settings.IsTore = True Then 'si le monde est comme un tore

            If player.Location.X < 0 Then 'sortie a droite
                player.Location = New Point(Me.Width - player.Width, player.Location.Y)

            ElseIf player.Location.X > Me.Width Then 'sortie a gauche
                player.Location = New Point(0, player.Location.Y)

            End If

        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        jump_time = My.Settings.JumpTime
        Vg_max = My.Settings.Vgmax
        Mv_maxA = My.Settings.MvmaxA
        Mv_maxG = My.Settings.MvmaxG
        FricG = My.Settings.FG
        FricA = My.Settings.FA

        listing()

        Timer1.Start()

    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

        If e.Button = MouseButtons.Left Then 'teleporte le joueur

            player.Location = New Point(MousePosition.X - Me.Location.X, MousePosition.Y - Me.Location.Y)

        ElseIf e.Button = MouseButtons.Right Then 'creer une platphorme

            Dim P As New Panel
            P.Tag = "G"
            P.BackColor = Panel1.BackColor
            P.BackgroundImage = Panel1.BackgroundImage

            AddHandler P.MouseDown, AddressOf Destroy

            P.Location = New Point(MousePosition.X - Me.Location.X, MousePosition.Y - Me.Location.Y)

            Me.Controls.Add(P)
            listing()

        End If

    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        listing()
    End Sub

    Private Sub player_KeyDown(sender As Object, e As KeyEventArgs) Handles player.KeyDown

        If e.KeyCode = Keys.Space And state = 2 Then 'saut
            state = 1
        ElseIf e.KeyCode = Keys.Q Then 'gauche
            dir = 1

        ElseIf e.KeyCode = Keys.D Then 'droite
            dir = 2

        End If

    End Sub

    Private Sub Player_KeyUp(sender As Object, e As KeyEventArgs) Handles player.KeyUp

        'arrete l'action de gauche ou droite
        If e.KeyCode = Keys.Q Then
            dir = 3
        ElseIf e.KeyCode = Keys.D Then
            dir = 4
        End If

    End Sub

    Sub listing()

        ListBox1.Items.Clear()

        For Each panels In Me.Controls
            If panels.tag = "G" Then

                ListBox1.Items.Add(panels.Location.Y.ToString + "/" + panels.Location.X.ToString + "/" + (panels.location.x + panels.Width).ToString + "/" + (panels.Location.Y + panels.Height).ToString)

            End If
        Next

        ListBox1.Sorted = True

    End Sub 'liste les platphorme

    Sub Destroy(sender As Object, e As MouseEventArgs)

        Dim p As Panel = sender

        If e.Button = MouseButtons.Middle Then

            p.Dispose()
            listing()

        End If

    End Sub  'supprime le panel

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        jump_time = My.Settings.JumpTime
        Vg_max = My.Settings.Vgmax
        Mv_maxA = My.Settings.MvmaxA
        Mv_maxG = My.Settings.MvmaxG
        FricG = My.Settings.FG
        FricA = My.Settings.FA

        listing()

        Timer1.Start()


    End Sub
End Class