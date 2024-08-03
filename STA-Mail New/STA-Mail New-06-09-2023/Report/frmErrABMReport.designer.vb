<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmErrABMReport
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
        Me.grpExport = New System.Windows.Forms.Panel
        Me.btnexport = New System.Windows.Forms.Button
        Me.lblrecordcount = New System.Windows.Forms.Label
        Me.dGrid = New System.Windows.Forms.DataGridView
        Me.grpMain = New System.Windows.Forms.Panel
        Me.cboFileName = New System.Windows.Forms.ComboBox
        Me.txtbranchId = New System.Windows.Forms.TextBox
        Me.txtmobileno = New System.Windows.Forms.TextBox
        Me.lblfilename = New System.Windows.Forms.Label
        Me.lblallocpercent = New System.Windows.Forms.Label
        Me.btnclear = New System.Windows.Forms.Button
        Me.btnclose = New System.Windows.Forms.Button
        Me.lblimportdate = New System.Windows.Forms.Label
        Me.dtpImportFrom = New System.Windows.Forms.DateTimePicker
        Me.lblimportdateto = New System.Windows.Forms.Label
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.txtClientName = New System.Windows.Forms.TextBox
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.dtpImportTo = New System.Windows.Forms.DateTimePicker
        Me.lblbranch = New System.Windows.Forms.Label
        Me.lbClientName = New System.Windows.Forms.Label
        Me.lblTallyFlag = New System.Windows.Forms.Label
        Me.grpExport.SuspendLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpExport
        '
        Me.grpExport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.grpExport.Controls.Add(Me.btnexport)
        Me.grpExport.Controls.Add(Me.lblrecordcount)
        Me.grpExport.Location = New System.Drawing.Point(10, 434)
        Me.grpExport.Name = "grpExport"
        Me.grpExport.Size = New System.Drawing.Size(811, 39)
        Me.grpExport.TabIndex = 8
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
        'dGrid
        '
        Me.dGrid.AllowUserToAddRows = False
        Me.dGrid.AllowUserToDeleteRows = False
        Me.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dGrid.Location = New System.Drawing.Point(9, 140)
        Me.dGrid.Name = "dGrid"
        Me.dGrid.ReadOnly = True
        Me.dGrid.RowHeadersVisible = False
        Me.dGrid.Size = New System.Drawing.Size(813, 262)
        Me.dGrid.TabIndex = 7
        '
        'grpMain
        '
        Me.grpMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.grpMain.Controls.Add(Me.cboFileName)
        Me.grpMain.Controls.Add(Me.txtbranchId)
        Me.grpMain.Controls.Add(Me.txtmobileno)
        Me.grpMain.Controls.Add(Me.lblfilename)
        Me.grpMain.Controls.Add(Me.lblallocpercent)
        Me.grpMain.Controls.Add(Me.btnclear)
        Me.grpMain.Controls.Add(Me.btnclose)
        Me.grpMain.Controls.Add(Me.lblimportdate)
        Me.grpMain.Controls.Add(Me.dtpImportFrom)
        Me.grpMain.Controls.Add(Me.lblimportdateto)
        Me.grpMain.Controls.Add(Me.txtAmount)
        Me.grpMain.Controls.Add(Me.txtClientName)
        Me.grpMain.Controls.Add(Me.btnRefresh)
        Me.grpMain.Controls.Add(Me.dtpImportTo)
        Me.grpMain.Controls.Add(Me.lblbranch)
        Me.grpMain.Controls.Add(Me.lbClientName)
        Me.grpMain.Controls.Add(Me.lblTallyFlag)
        Me.grpMain.Location = New System.Drawing.Point(10, 8)
        Me.grpMain.Name = "grpMain"
        Me.grpMain.Size = New System.Drawing.Size(712, 126)
        Me.grpMain.TabIndex = 4
        '
        'cboFileName
        '
        Me.cboFileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFileName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFileName.ItemHeight = 13
        Me.cboFileName.Location = New System.Drawing.Point(96, 67)
        Me.cboFileName.Name = "cboFileName"
        Me.cboFileName.Size = New System.Drawing.Size(367, 21)
        Me.cboFileName.TabIndex = 31
        '
        'txtbranchId
        '
        Me.txtbranchId.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbranchId.Location = New System.Drawing.Point(565, 8)
        Me.txtbranchId.MaxLength = 15
        Me.txtbranchId.Name = "txtbranchId"
        Me.txtbranchId.Size = New System.Drawing.Size(135, 21)
        Me.txtbranchId.TabIndex = 13
        '
        'txtmobileno
        '
        Me.txtmobileno.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmobileno.Location = New System.Drawing.Point(96, 39)
        Me.txtmobileno.MaxLength = 15
        Me.txtmobileno.Name = "txtmobileno"
        Me.txtmobileno.Size = New System.Drawing.Size(135, 21)
        Me.txtmobileno.TabIndex = 19
        '
        'lblfilename
        '
        Me.lblfilename.AutoSize = True
        Me.lblfilename.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfilename.Location = New System.Drawing.Point(30, 71)
        Me.lblfilename.Name = "lblfilename"
        Me.lblfilename.Size = New System.Drawing.Size(61, 13)
        Me.lblfilename.TabIndex = 24
        Me.lblfilename.Text = "File Name"
        Me.lblfilename.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblallocpercent
        '
        Me.lblallocpercent.AutoSize = True
        Me.lblallocpercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblallocpercent.Location = New System.Drawing.Point(10, 41)
        Me.lblallocpercent.Name = "lblallocpercent"
        Me.lblallocpercent.Size = New System.Drawing.Size(61, 13)
        Me.lblallocpercent.TabIndex = 18
        Me.lblallocpercent.Text = "Mobile No"
        Me.lblallocpercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnclear
        '
        Me.btnclear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclear.Location = New System.Drawing.Point(554, 92)
        Me.btnclear.Name = "btnclear"
        Me.btnclear.Size = New System.Drawing.Size(72, 24)
        Me.btnclear.TabIndex = 29
        Me.btnclear.Text = "&Clear"
        Me.btnclear.UseVisualStyleBackColor = True
        '
        'btnclose
        '
        Me.btnclose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.Location = New System.Drawing.Point(632, 92)
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
        Me.lblimportdate.Location = New System.Drawing.Point(9, 13)
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
        Me.dtpImportFrom.Location = New System.Drawing.Point(96, 9)
        Me.dtpImportFrom.Name = "dtpImportFrom"
        Me.dtpImportFrom.ShowCheckBox = True
        Me.dtpImportFrom.Size = New System.Drawing.Size(135, 21)
        Me.dtpImportFrom.TabIndex = 3
        '
        'lblimportdateto
        '
        Me.lblimportdateto.AutoSize = True
        Me.lblimportdateto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblimportdateto.Location = New System.Drawing.Point(298, 13)
        Me.lblimportdateto.Name = "lblimportdateto"
        Me.lblimportdateto.Size = New System.Drawing.Size(24, 13)
        Me.lblimportdateto.TabIndex = 4
        Me.lblimportdateto.Text = " To"
        Me.lblimportdateto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(328, 40)
        Me.txtAmount.MaxLength = 16
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(135, 21)
        Me.txtAmount.TabIndex = 15
        '
        'txtClientName
        '
        Me.txtClientName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientName.Location = New System.Drawing.Point(566, 36)
        Me.txtClientName.MaxLength = 16
        Me.txtClientName.Name = "txtClientName"
        Me.txtClientName.Size = New System.Drawing.Size(135, 21)
        Me.txtClientName.TabIndex = 15
        '
        'btnRefresh
        '
        Me.btnRefresh.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(476, 92)
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
        Me.dtpImportTo.Location = New System.Drawing.Point(328, 9)
        Me.dtpImportTo.Name = "dtpImportTo"
        Me.dtpImportTo.ShowCheckBox = True
        Me.dtpImportTo.Size = New System.Drawing.Size(135, 21)
        Me.dtpImportTo.TabIndex = 5
        '
        'lblbranch
        '
        Me.lblbranch.AutoSize = True
        Me.lblbranch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbranch.Location = New System.Drawing.Point(492, 11)
        Me.lblbranch.Name = "lblbranch"
        Me.lblbranch.Size = New System.Drawing.Size(62, 13)
        Me.lblbranch.TabIndex = 12
        Me.lblbranch.Text = "Branch ID"
        Me.lblbranch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbClientName
        '
        Me.lbClientName.AutoSize = True
        Me.lbClientName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbClientName.Location = New System.Drawing.Point(481, 40)
        Me.lbClientName.Name = "lbClientName"
        Me.lbClientName.Size = New System.Drawing.Size(74, 13)
        Me.lbClientName.TabIndex = 14
        Me.lbClientName.Text = "Client Name"
        Me.lbClientName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTallyFlag
        '
        Me.lblTallyFlag.AutoSize = True
        Me.lblTallyFlag.Location = New System.Drawing.Point(262, 42)
        Me.lblTallyFlag.Name = "lblTallyFlag"
        Me.lblTallyFlag.Size = New System.Drawing.Size(52, 13)
        Me.lblTallyFlag.TabIndex = 22
        Me.lblTallyFlag.Text = "Amount"
        Me.lblTallyFlag.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmErrABMReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 480)
        Me.Controls.Add(Me.grpMain)
        Me.Controls.Add(Me.grpExport)
        Me.Controls.Add(Me.dGrid)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmErrABMReport"
        Me.Text = "ErrABM Report"
        Me.grpExport.ResumeLayout(False)
        Me.grpExport.PerformLayout()
        CType(Me.dGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMain.ResumeLayout(False)
        Me.grpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpExport As System.Windows.Forms.Panel
    Friend WithEvents btnexport As System.Windows.Forms.Button
    Friend WithEvents lblrecordcount As System.Windows.Forms.Label
    Friend WithEvents dGrid As System.Windows.Forms.DataGridView
    Friend WithEvents grpMain As System.Windows.Forms.Panel
    Friend WithEvents cboFileName As System.Windows.Forms.ComboBox
    Friend WithEvents txtbranchId As System.Windows.Forms.TextBox
    Friend WithEvents txtmobileno As System.Windows.Forms.TextBox
    Friend WithEvents lblfilename As System.Windows.Forms.Label
    Friend WithEvents lblallocpercent As System.Windows.Forms.Label
    Friend WithEvents btnclear As System.Windows.Forms.Button
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents lblimportdate As System.Windows.Forms.Label
    Friend WithEvents dtpImportFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblimportdateto As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtClientName As System.Windows.Forms.TextBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents dtpImportTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblbranch As System.Windows.Forms.Label
    Friend WithEvents lbClientName As System.Windows.Forms.Label
    Friend WithEvents lblTallyFlag As System.Windows.Forms.Label
End Class
