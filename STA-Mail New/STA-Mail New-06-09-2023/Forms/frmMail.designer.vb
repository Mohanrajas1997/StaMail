<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMail
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.lblMandBankName = New System.Windows.Forms.Label
        Me.lblMandBankCode = New System.Windows.Forms.Label
        Me.txtcc2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblbussorder = New System.Windows.Forms.Label
        Me.lblBusinessName = New System.Windows.Forms.Label
        Me.lblcc1 = New System.Windows.Forms.Label
        Me.pnlSave = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.txtcc1 = New System.Windows.Forms.TextBox
        Me.txtcc3 = New System.Windows.Forms.TextBox
        Me.txtcc4 = New System.Windows.Forms.TextBox
        Me.pnlMain.SuspendLayout()
        Me.pnlSave.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMain.Controls.Add(Me.lblMandBankName)
        Me.pnlMain.Controls.Add(Me.lblMandBankCode)
        Me.pnlMain.Controls.Add(Me.txtcc4)
        Me.pnlMain.Controls.Add(Me.txtcc3)
        Me.pnlMain.Controls.Add(Me.txtcc1)
        Me.pnlMain.Controls.Add(Me.txtcc2)
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Controls.Add(Me.lblbussorder)
        Me.pnlMain.Controls.Add(Me.lblBusinessName)
        Me.pnlMain.Controls.Add(Me.lblcc1)
        Me.pnlMain.Location = New System.Drawing.Point(6, 6)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(404, 121)
        Me.pnlMain.TabIndex = 4
        '
        'lblMandBankName
        '
        Me.lblMandBankName.ForeColor = System.Drawing.Color.Red
        Me.lblMandBankName.Location = New System.Drawing.Point(75, 36)
        Me.lblMandBankName.Name = "lblMandBankName"
        Me.lblMandBankName.Size = New System.Drawing.Size(11, 8)
        Me.lblMandBankName.TabIndex = 59
        Me.lblMandBankName.Text = "*"
        '
        'lblMandBankCode
        '
        Me.lblMandBankCode.ForeColor = System.Drawing.Color.Red
        Me.lblMandBankCode.Location = New System.Drawing.Point(75, 8)
        Me.lblMandBankCode.Name = "lblMandBankCode"
        Me.lblMandBankCode.Size = New System.Drawing.Size(11, 8)
        Me.lblMandBankCode.TabIndex = 1
        Me.lblMandBankCode.Text = "*"
        '
        'txtcc2
        '
        Me.txtcc2.Location = New System.Drawing.Point(89, 33)
        Me.txtcc2.MaxLength = 255
        Me.txtcc2.Name = "txtcc2"
        Me.txtcc2.Size = New System.Drawing.Size(304, 21)
        Me.txtcc2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(31, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "CC4"
        '
        'lblbussorder
        '
        Me.lblbussorder.AutoSize = True
        Me.lblbussorder.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblbussorder.Location = New System.Drawing.Point(31, 64)
        Me.lblbussorder.Name = "lblbussorder"
        Me.lblbussorder.Size = New System.Drawing.Size(28, 13)
        Me.lblbussorder.TabIndex = 4
        Me.lblbussorder.Text = "CC3"
        '
        'lblBusinessName
        '
        Me.lblBusinessName.AutoSize = True
        Me.lblBusinessName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBusinessName.Location = New System.Drawing.Point(31, 36)
        Me.lblBusinessName.Name = "lblBusinessName"
        Me.lblBusinessName.Size = New System.Drawing.Size(28, 13)
        Me.lblBusinessName.TabIndex = 2
        Me.lblBusinessName.Text = "CC2"
        '
        'lblcc1
        '
        Me.lblcc1.AutoSize = True
        Me.lblcc1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblcc1.Location = New System.Drawing.Point(31, 10)
        Me.lblcc1.Name = "lblcc1"
        Me.lblcc1.Size = New System.Drawing.Size(28, 13)
        Me.lblcc1.TabIndex = 0
        Me.lblcc1.Text = "CC1"
        '
        'pnlSave
        '
        Me.pnlSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSave.CausesValidation = False
        Me.pnlSave.Controls.Add(Me.btnCancel)
        Me.pnlSave.Controls.Add(Me.btnSave)
        Me.pnlSave.Location = New System.Drawing.Point(138, 133)
        Me.pnlSave.Name = "pnlSave"
        Me.pnlSave.Size = New System.Drawing.Size(152, 28)
        Me.pnlSave.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.CausesValidation = False
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(76, 1)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Control
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave.Location = New System.Drawing.Point(2, 1)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'txtcc1
        '
        Me.txtcc1.Location = New System.Drawing.Point(89, 5)
        Me.txtcc1.MaxLength = 255
        Me.txtcc1.Name = "txtcc1"
        Me.txtcc1.Size = New System.Drawing.Size(304, 21)
        Me.txtcc1.TabIndex = 1
        '
        'txtcc3
        '
        Me.txtcc3.Location = New System.Drawing.Point(89, 62)
        Me.txtcc3.MaxLength = 255
        Me.txtcc3.Name = "txtcc3"
        Me.txtcc3.Size = New System.Drawing.Size(304, 21)
        Me.txtcc3.TabIndex = 1
        '
        'txtcc4
        '
        Me.txtcc4.Location = New System.Drawing.Point(89, 89)
        Me.txtcc4.MaxLength = 255
        Me.txtcc4.Name = "txtcc4"
        Me.txtcc4.Size = New System.Drawing.Size(304, 21)
        Me.txtcc4.TabIndex = 1
        '
        'frmMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 197)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlSave)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CC Mail"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlSave.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents lblMandBankName As System.Windows.Forms.Label
    Friend WithEvents lblMandBankCode As System.Windows.Forms.Label
    Friend WithEvents txtcc2 As System.Windows.Forms.TextBox
    Friend WithEvents lblBusinessName As System.Windows.Forms.Label
    Friend WithEvents lblcc1 As System.Windows.Forms.Label
    Friend WithEvents pnlSave As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblbussorder As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcc4 As System.Windows.Forms.TextBox
    Friend WithEvents txtcc3 As System.Windows.Forms.TextBox
    Friend WithEvents txtcc1 As System.Windows.Forms.TextBox
End Class
