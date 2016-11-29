<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Bc1 = New System.Windows.Forms.Button()
        Me.Bc2 = New System.Windows.Forms.Button()
        Me.Bc3 = New System.Windows.Forms.Button()
        Me.Bc4 = New System.Windows.Forms.Button()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.Btcheck = New System.Windows.Forms.Button()
        Me.bt4 = New System.Windows.Forms.Button()
        Me.bt3 = New System.Windows.Forms.Button()
        Me.bt2 = New System.Windows.Forms.Button()
        Me.Bt1 = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RectangleShape1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Bthelp = New System.Windows.Forms.Button()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bc1
        '
        Me.Bc1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Bc1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bc1.Location = New System.Drawing.Point(12, 48)
        Me.Bc1.Name = "Bc1"
        Me.Bc1.Size = New System.Drawing.Size(42, 42)
        Me.Bc1.TabIndex = 1
        Me.Bc1.UseVisualStyleBackColor = False
        '
        'Bc2
        '
        Me.Bc2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Bc2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bc2.Location = New System.Drawing.Point(60, 48)
        Me.Bc2.Name = "Bc2"
        Me.Bc2.Size = New System.Drawing.Size(42, 42)
        Me.Bc2.TabIndex = 2
        Me.Bc2.UseVisualStyleBackColor = False
        '
        'Bc3
        '
        Me.Bc3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Bc3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bc3.Location = New System.Drawing.Point(108, 48)
        Me.Bc3.Name = "Bc3"
        Me.Bc3.Size = New System.Drawing.Size(42, 42)
        Me.Bc3.TabIndex = 3
        Me.Bc3.UseVisualStyleBackColor = False
        '
        'Bc4
        '
        Me.Bc4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Bc4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bc4.Location = New System.Drawing.Point(156, 48)
        Me.Bc4.Name = "Bc4"
        Me.Bc4.Size = New System.Drawing.Size(42, 42)
        Me.Bc4.TabIndex = 4
        Me.Bc4.UseVisualStyleBackColor = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(10, 613)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(44, 17)
        Me.RadioButton1.TabIndex = 53
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Tag = "0"
        Me.RadioButton1.Text = "Vert"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(83, 613)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(46, 17)
        Me.RadioButton2.TabIndex = 54
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Tag = "1"
        Me.RadioButton2.Text = "Bleu"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(156, 613)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(51, 17)
        Me.RadioButton3.TabIndex = 55
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Tag = "2"
        Me.RadioButton3.Text = "Violet"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(10, 638)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(50, 17)
        Me.RadioButton4.TabIndex = 56
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Tag = "3"
        Me.RadioButton4.Text = "Rose"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(83, 638)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(60, 17)
        Me.RadioButton5.TabIndex = 57
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Tag = "4"
        Me.RadioButton5.Text = "Orange"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Location = New System.Drawing.Point(156, 636)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(57, 17)
        Me.RadioButton6.TabIndex = 58
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Tag = "5"
        Me.RadioButton6.Text = "Rouge"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'Btcheck
        '
        Me.Btcheck.Enabled = False
        Me.Btcheck.Location = New System.Drawing.Point(213, 568)
        Me.Btcheck.Name = "Btcheck"
        Me.Btcheck.Size = New System.Drawing.Size(123, 85)
        Me.Btcheck.TabIndex = 71
        Me.Btcheck.Text = "Test"
        Me.Btcheck.UseVisualStyleBackColor = True
        '
        'bt4
        '
        Me.bt4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.bt4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt4.Location = New System.Drawing.Point(156, 568)
        Me.bt4.Name = "bt4"
        Me.bt4.Size = New System.Drawing.Size(42, 39)
        Me.bt4.TabIndex = 75
        Me.bt4.UseVisualStyleBackColor = False
        '
        'bt3
        '
        Me.bt3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.bt3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt3.Location = New System.Drawing.Point(108, 568)
        Me.bt3.Name = "bt3"
        Me.bt3.Size = New System.Drawing.Size(42, 39)
        Me.bt3.TabIndex = 74
        Me.bt3.UseVisualStyleBackColor = False
        '
        'bt2
        '
        Me.bt2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.bt2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt2.Location = New System.Drawing.Point(60, 568)
        Me.bt2.Name = "bt2"
        Me.bt2.Size = New System.Drawing.Size(42, 39)
        Me.bt2.TabIndex = 73
        Me.bt2.UseVisualStyleBackColor = False
        '
        'Bt1
        '
        Me.Bt1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Bt1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bt1.Location = New System.Drawing.Point(16, 568)
        Me.Bt1.Name = "Bt1"
        Me.Bt1.Size = New System.Drawing.Size(38, 39)
        Me.Bt1.TabIndex = 72
        Me.Bt1.UseVisualStyleBackColor = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(16, 108)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(320, 454)
        Me.FlowLayoutPanel1.TabIndex = 76
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(12, 13)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDown1.TabIndex = 77
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(138, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 78
        Me.Button1.Text = "Gen"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BackColor = System.Drawing.SystemColors.ControlText
        Me.RectangleShape1.Location = New System.Drawing.Point(-15, 39)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(414, 63)
        Me.RectangleShape1.TabIndex = 79
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(213, 10)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 80
        Me.Button2.Text = "New"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Bthelp
        '
        Me.Bthelp.Location = New System.Drawing.Point(294, 10)
        Me.Bthelp.Name = "Bthelp"
        Me.Bthelp.Size = New System.Drawing.Size(41, 23)
        Me.Bthelp.TabIndex = 81
        Me.Bthelp.Text = "?"
        Me.Bthelp.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 667)
        Me.Controls.Add(Me.Bthelp)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.bt4)
        Me.Controls.Add(Me.bt3)
        Me.Controls.Add(Me.bt2)
        Me.Controls.Add(Me.Bt1)
        Me.Controls.Add(Me.Btcheck)
        Me.Controls.Add(Me.RadioButton6)
        Me.Controls.Add(Me.RadioButton5)
        Me.Controls.Add(Me.RadioButton4)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Bc4)
        Me.Controls.Add(Me.Bc3)
        Me.Controls.Add(Me.Bc2)
        Me.Controls.Add(Me.Bc1)
        Me.Controls.Add(Me.RectangleShape1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "MasterMind Power"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bc1 As System.Windows.Forms.Button
    Friend WithEvents Bc2 As System.Windows.Forms.Button
    Friend WithEvents Bc3 As System.Windows.Forms.Button
    Friend WithEvents Bc4 As System.Windows.Forms.Button
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents Btcheck As System.Windows.Forms.Button
    Friend WithEvents bt4 As System.Windows.Forms.Button
    Friend WithEvents bt3 As System.Windows.Forms.Button
    Friend WithEvents bt2 As System.Windows.Forms.Button
    Friend WithEvents Bt1 As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents RectangleShape1 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Bthelp As System.Windows.Forms.Button

End Class
