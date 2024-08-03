<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportReport
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
        Me.grpExport = New System.Windows.Forms.Panel()
        Me.btnexport = New System.Windows.Forms.Button()
        Me.lblrecordcount = New System.Windows.Forms.Label()
        Me.grpMain = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.optSend = New System.Windows.Forms.RadioButton()
        Me.optNotSend = New System.Windows.Forms.RadioButton()
        Me.cboFileName = New System.Windows.Forms.ComboBox()
        Me.lblfilename = New System.Windows.Forms.Label()
        Me.btnclear = New System.Windows.Forms.Button()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.lblimportdate = New System.Windows.Forms.Label()
        Me.dtpImportFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblimportdateto = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.dtpImportTo = New System.Windows.Forms.DateTimePicker()
        Me.dGrid = New System.Windows.Forms.DataGridView()
        Me.grpExport.SuspendLayout()
        Me.grpMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpExport
        '
        Me.grpExport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.grpExport.Controls.Add(Me.btnexport)
        Me.grpExport.Controls.Add(Me.lblrecordcount)
        Me.grpExport.Location = New System.Drawing.Point(10, 552)
        Me.grpExport.Name = "grpExport"
        Me.grpExport.Size = New System.Drawing.Size(811, 39)
        Me.grpExport.TabIndex = 5
        '
        'btnexport
        '
        Me.btnexport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexport.Location = New System.Drawing.Point(730, 7)
        Me.btnexport.Name = "btnexport"
        Me.btnexport.Size = New System.Drawing.Size(72, 24)
        Me.btnexport.TabIndex = 0
        Me.btnexport.Text = "&Export"
        Me.btnexport.UseVisualStyleBackColor = True
        '
        'lblrecordcount
        '
        Me.lblrecordcount.AutoSize = True
        Me.lblrecordcount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblrecordcount.Location = New System.Drawing.Point(3, 13)
        Me.lblrecordcount.Name = "lblrecordcount"
        Me.lblrecordcount.Size = New System.Drawing.Size(91, 13)
        Me.lblrecordcount.TabIndex = 0
        Me.lblrecordcount.Text = "Total Records :"
        '
        'grpMain
        '
        Me.grpMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.grpMain.Controls.Add(Me.Panel1)
        Me.grpMain.Controls.Add(Me.cboFileName)
        Me.grpMain.Controls.Add(Me.lblfilename)
        Me.grpMain.Controls.Add(Me.btnclear)
        Me.grpMain.Controls.Add(Me.btnclose)
        Me.grpMain.Controls.Add(Me.lblimportdate)
        Me.grpMain.Controls.Add(Me.dtpImportFrom)
        Me.grpMain.Controls.Add(Me.lblimportdateto)
        Me.grpMain.Controls.Add(Me.btnRefresh)
        Me.grpMain.Controls.Add(Me.dtpImportTo)
        Me.grpMain.Location = New System.Drawing.Point(10, 8)
        Me.grpMain.Name = "grpMain"
        Me.grpMain.Size = New System.Drawing.Size(811, 101)
        Me.grpMain.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.optSend)
        Me.Panel1.Controls.Add(Me.optNotSend)
        Me.Panel1.Location = New System.Drawing.Point(574, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(163, 44)
        Me.Panel1.TabIndex = 35
        '
        'optSend
        '
        Me.optSend.AutoSize = True
        Me.optSend.Location = New System.Drawing.Point(12, 13)
        Me.optSend.Name = "optSend"
        Me.optSend.Size = New System.Drawing.Size(53, 17)
        Me.optSend.TabIndex = 36
        Me.optSend.Text = "Send"
        Me.optSend.UseVisualStyleBackColor = True
        '
        'optNotSend
        '
        Me.optNotSend.AutoSize = True
        Me.optNotSend.Checked = True
        Me.optNotSend.Location = New System.Drawing.Point(75, 13)
        Me.optNotSend.Name = "optNotSend"
        Me.optNotSend.Size = New System.Drawing.Size(75, 17)
        Me.optNotSend.TabIndex = 37
        Me.optNotSend.TabStop = True
        Me.optNotSend.Text = "Not Send"
        Me.optNotSend.UseVisualStyleBackColor = True
        '
        'cboFileName
        '
        Me.cboFileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFileName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFileName.ItemHeight = 13
        Me.cboFileName.Location = New System.Drawing.Point(109, 40)
        Me.cboFileName.Name = "cboFileName"
        Me.cboFileName.Size = New System.Drawing.Size(367, 21)
        Me.cboFileName.TabIndex = 31
        '
        'lblfilename
        '
        Me.lblfilename.AutoSize = True
        Me.lblfilename.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfilename.Location = New System.Drawing.Point(42, 44)
        Me.lblfilename.Name = "lblfilename"
        Me.lblfilename.Size = New System.Drawing.Size(61, 13)
        Me.lblfilename.TabIndex = 24
        Me.lblfilename.Text = "File Name"
        Me.lblfilename.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnclear
        '
        Me.btnclear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclear.Location = New System.Drawing.Point(652, 67)
        Me.btnclear.Name = "btnclear"
        Me.btnclear.Size = New System.Drawing.Size(72, 24)
        Me.btnclear.TabIndex = 29
        Me.btnclear.Text = "&Clear"
        Me.btnclear.UseVisualStyleBackColor = True
        '
        'btnclose
        '
        Me.btnclose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.Location = New System.Drawing.Point(730, 67)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(72, 24)
        Me.btnclose.TabIndex = 30
        Me.btnclose.Text = "&Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'lblimportdate
        '
        Me.lblimportdate.AutoSize = True
        Me.lblimportdate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblimportdate.Location = New System.Drawing.Point(21, 13)
        Me.lblimportdate.Name = "lblimportdate"
        Me.lblimportdate.Size = New System.Drawing.Size(82, 13)
        Me.lblimportdate.TabIndex = 2
        Me.lblimportdate.Text = "Import  From"
        Me.lblimportdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpImportFrom
        '
        Me.dtpImportFrom.CustomFormat = "dd-MMM-yyyy"
        Me.dtpImportFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpImportFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpImportFrom.Location = New System.Drawing.Point(109, 9)
        Me.dtpImportFrom.Name = "dtpImportFrom"
        Me.dtpImportFrom.ShowCheckBox = True
        Me.dtpImportFrom.Size = New System.Drawing.Size(135, 21)
        Me.dtpImportFrom.TabIndex = 3
        '
        'lblimportdateto
        '
        Me.lblimportdateto.AutoSize = True
        Me.lblimportdateto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblimportdateto.Location = New System.Drawing.Point(311, 13)
        Me.lblimportdateto.Name = "lblimportdateto"
        Me.lblimportdateto.Size = New System.Drawing.Size(24, 13)
        Me.lblimportdateto.TabIndex = 4
        Me.lblimportdateto.Text = " To"
        Me.lblimportdateto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnRefresh
        '
        Me.btnRefresh.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(574, 67)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 28
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'dtpImportTo
        '
        Me.dtpImportTo.CustomFormat = "dd-MMM-yyyy"
        Me.dtpImportTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpImportTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpImportTo.Location = New System.Drawing.Point(341, 9)
        Me.dtpImportTo.Name = "dtpImportTo"
        Me.dtpImportTo.ShowCheckBox = True
        Me.dtpImportTo.Size = New System.Drawing.Size(135, 21)
        Me.dtpImportTo.TabIndex = 5
        '
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dGrid.Location = New System.Drawing.Point(10, 115)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.ReadOnly = True
        Me.dGrid.RowHeadersVisible = False
        Me.dGrid.Size = New System.Drawing.Size(813, 423)
        Me.dGrid.TabIndex = 4
        '
        'frmImportReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 598)
        Me.Controls.Add(Me.grpExport)
        Me.Controls.Add(Me.grpMain)
        Me.Controls.Add(Me.dGrid)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmImportReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Report"
        Me.grpExport.ResumeLayout(False)
        Me.grpExport.PerformLayout()
        Me.grpMain.ResumeLayout(False)
        Me.grpMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpExport As System.Windows.Forms.Panel
    Friend WithEvents btnexport As System.Windows.Forms.Button
    Friend WithEvents lblrecordcount As System.Windows.Forms.Label
    Friend WithEvents grpMain As System.Windows.Forms.Panel
    Friend WithEvents cboFileName As System.Windows.Forms.ComboBox
    Friend WithEvents lblfilename As System.Windows.Forms.Label
    Friend WithEvents btnclear As System.Windows.Forms.Button
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents lblimportdate As System.Windows.Forms.Label
    Friend WithEvents dtpImportFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblimportdateto As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents dtpImportTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents optSend As System.Windows.Forms.RadioButton
    Friend WithEvents optNotSend As System.Windows.Forms.RadioButton
End Class
