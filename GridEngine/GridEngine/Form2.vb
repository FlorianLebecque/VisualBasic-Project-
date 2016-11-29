Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        CheckBox1.Checked = My.Settings.IsTore
        NumericUpDown1.Value = My.Settings.Vgmax
        NumericUpDown2.Value = My.Settings.VgBase
        NumericUpDown3.Value = My.Settings.G
        NumericUpDown4.Value = My.Settings.MvmaxG
        NumericUpDown5.Value = My.Settings.MvmaxA
        NumericUpDown6.Value = My.Settings.FA
        NumericUpDown7.Value = My.Settings.FG
        NumericUpDown8.Value = My.Settings.JumpTime
        NumericUpDown9.Value = My.Settings.JumpState

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        My.Settings.Vgmax = NumericUpDown1.Value
        My.Settings.VgBase = NumericUpDown2.Value
        My.Settings.G = NumericUpDown3.Value
        My.Settings.MvmaxG = NumericUpDown4.Value
        My.Settings.MvmaxA = NumericUpDown5.Value
        My.Settings.FA = NumericUpDown6.Value
        My.Settings.FG = NumericUpDown7.Value
        My.Settings.JumpTime = NumericUpDown8.Value
        My.Settings.JumpState = NumericUpDown9.Value
        My.Settings.IsTore = CheckBox1.Checked
        Form1.Show()

        Form1.jump_time = My.Settings.JumpTime
        Form1.Vg_max = My.Settings.Vgmax
        Form1.Mv_maxA = My.Settings.MvmaxA
        Form1.Mv_maxG = My.Settings.MvmaxG
        Form1.FricG = My.Settings.FG
        Form1.FricA = My.Settings.FA

        Form1.listing()


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        My.Settings.Reset()


        CheckBox1.Checked = My.Settings.IsTore
        NumericUpDown1.Value = My.Settings.Vgmax
        NumericUpDown2.Value = My.Settings.VgBase
        NumericUpDown3.Value = My.Settings.G
        NumericUpDown4.Value = My.Settings.MvmaxG
        NumericUpDown5.Value = My.Settings.MvmaxA
        NumericUpDown6.Value = My.Settings.FA
        NumericUpDown7.Value = My.Settings.FG
        NumericUpDown8.Value = My.Settings.JumpTime
        NumericUpDown9.Value = My.Settings.JumpState

    End Sub 'remet tout a zero

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        My.Settings.Vgmax = NumericUpDown1.Value
        My.Settings.VgBase = NumericUpDown2.Value
        My.Settings.G = NumericUpDown3.Value
        My.Settings.MvmaxG = NumericUpDown4.Value
        My.Settings.MvmaxA = NumericUpDown5.Value
        My.Settings.FA = NumericUpDown6.Value
        My.Settings.FG = NumericUpDown7.Value
        My.Settings.JumpTime = NumericUpDown8.Value
        My.Settings.JumpState = NumericUpDown9.Value
        My.Settings.IsTore = CheckBox1.Checked
        My.Settings.Save()
        MsgBox("les parametres on été sauvgardé")
    End Sub 'enregistrer

End Class