<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuickView
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
        Me.dgvQuickView = New System.Windows.Forms.DataGridView
        Me.pnlReport = New System.Windows.Forms.Panel
        Me.lblTotRec = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnExport = New System.Windows.Forms.Button
        CType(Me.dgvQuickView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvQuickView
        '
        Me.dgvQuickView.AllowUserToAddRows = False
        Me.dgvQuickView.AllowUserToDeleteRows = False
        Me.dgvQuickView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQuickView.Location = New System.Drawing.Point(9, 3)
        Me.dgvQuickView.Name = "dgvQuickView"
        Me.dgvQuickView.ReadOnly = True
        Me.dgvQuickView.Size = New System.Drawing.Size(275, 196)
        Me.dgvQuickView.TabIndex = 0
        '
        'pnlReport
        '
        Me.pnlReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlReport.Controls.Add(Me.lblTotRec)
        Me.pnlReport.Controls.Add(Me.btnClose)
        Me.pnlReport.Controls.Add(Me.btnExport)
        Me.pnlReport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlReport.Location = New System.Drawing.Point(9, 220)
        Me.pnlReport.Name = "pnlReport"
        Me.pnlReport.Size = New System.Drawing.Size(319, 41)
        Me.pnlReport.TabIndex = 1
        '
        'lblTotRec
        '
        Me.lblTotRec.AutoSize = True
        Me.lblTotRec.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTotRec.Location = New System.Drawing.Point(169, 15)
        Me.lblTotRec.Name = "lblTotRec"
        Me.lblTotRec.Size = New System.Drawing.Size(85, 13)
        Me.lblTotRec.TabIndex = 4
        Me.lblTotRec.Text = "Total Records"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(87, 7)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(9, 7)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(72, 24)
        Me.btnExport.TabIndex = 0
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'frmQuickView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 428)
        Me.Controls.Add(Me.pnlReport)
        Me.Controls.Add(Me.dgvQuickView)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmQuickView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "QuickView"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvQuickView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlReport.ResumeLayout(False)
        Me.pnlReport.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvQuickView As System.Windows.Forms.DataGridView
    Friend WithEvents pnlReport As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents lblTotRec As System.Windows.Forms.Label
End Class
