Public Class Form3

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        OFD.ShowDialog()

        If OFD.FileName <> Nothing Then

            My.Settings.setting = "IMG;" + OFD.FileName
            Form1.ControlZone.BackgroundImage = Image.FromFile(OFD.FileName) 'met l'image en fond
            Form2.FlowLayoutPanel1.BackgroundImage = Image.FromFile(OFD.FileName)
            My.Settings.Save()

        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Select Case ComboBox1.SelectedItem

            Case "bleu"

                My.Settings.setting = "COL;" + "bleu"
                Form1.ControlZone.BackColor = Color.Blue
                Form2.FlowLayoutPanel1.BackColor = Color.Blue

            Case "rouge"

                My.Settings.setting = "COL;" + "rouge"
                Form1.ControlZone.BackColor = Color.Red
                Form2.FlowLayoutPanel1.BackColor = Color.Red

            Case "vert"

                My.Settings.setting = "COL;" + "vert"
                Form1.ControlZone.BackColor = Color.Green
                Form2.FlowLayoutPanel1.BackColor = Color.Green

            Case "viollet"

                My.Settings.setting = "COL;" + "viollet"
                Form1.ControlZone.BackColor = Color.Violet
                Form2.FlowLayoutPanel1.BackColor = Color.Violet

            Case "orange"

                My.Settings.setting = "COL;" + "orange"
                Form1.ControlZone.BackColor = Color.Orange
                Form2.FlowLayoutPanel1.BackColor = Color.Orange

            Case "gris"

                My.Settings.setting = "COL;" + "gris"
                Form1.ControlZone.BackColor = Color.Gray
                Form2.FlowLayoutPanel1.BackColor = Color.Gray

            Case "blanc"

                My.Settings.setting = "COL;" + "blanc"
                Form1.ControlZone.BackColor = Color.White
                Form2.FlowLayoutPanel1.BackColor = Color.White

            Case "noir"

                My.Settings.setting = "COL;" + "noir"
                Form1.ControlZone.BackColor = Color.Black
                Form2.FlowLayoutPanel1.BackColor = Color.Black

        End Select

        My.Settings.Save()

    End Sub
End Class