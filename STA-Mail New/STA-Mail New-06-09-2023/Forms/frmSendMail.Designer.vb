<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSendMail
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.grpMain = New System.Windows.Forms.GroupBox()
        Me.lblimportdate = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.cboFileName = New System.Windows.Forms.ComboBox()
        Me.lblfilename = New System.Windows.Forms.Label()
        Me.chkSelect = New System.Windows.Forms.CheckBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblBatchNo = New System.Windows.Forms.Label()
        Me.btnsendmail = New System.Windows.Forms.Button()
        Me.lblrecords = New System.Windows.Forms.Label()
        Me.pnlAttachment = New System.Windows.Forms.Panel()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.lstAttachment = New System.Windows.Forms.ListBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.lblAsciiPath = New System.Windows.Forms.Label()
        Me.txtAddCC = New System.Windows.Forms.TextBox()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMain.SuspendLayout()
        Me.pnlAttachment.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgvList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvList.Location = New System.Drawing.Point(6, 56)
        Me.dgvList.Name = "dgvList"
        Me.dgvList.Size = New System.Drawing.Size(870, 360)
        Me.dgvList.TabIndex = 1
        '
        'grpMain
        '
        Me.grpMain.Controls.Add(Me.lblimportdate)
        Me.grpMain.Controls.Add(Me.dtpDate)
        Me.grpMain.Controls.Add(Me.cboFileName)
        Me.grpMain.Controls.Add(Me.lblfilename)
        Me.grpMain.Controls.Add(Me.chkSelect)
        Me.grpMain.Controls.Add(Me.btnClear)
        Me.grpMain.Controls.Add(Me.btnRefresh)
        Me.grpMain.Location = New System.Drawing.Point(6, -1)
        Me.grpMain.Name = "grpMain"
        Me.grpMain.Size = New System.Drawing.Size(870, 49)
        Me.grpMain.TabIndex = 0
        Me.grpMain.TabStop = False
        '
        'lblimportdate
        '
        Me.lblimportdate.AutoSize = True
        Me.lblimportdate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblimportdate.Location = New System.Drawing.Point(7, 21)
        Me.lblimportdate.Name = "lblimportdate"
        Me.lblimportdate.Size = New System.Drawing.Size(34, 13)
        Me.lblimportdate.TabIndex = 34
        Me.lblimportdate.Text = "Date"
        Me.lblimportdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(49, 17)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(113, 21)
        Me.dtpDate.TabIndex = 35
        '
        'cboFileName
        '
        Me.cboFileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFileName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFileName.ItemHeight = 13
        Me.cboFileName.Location = New System.Drawing.Point(243, 17)
        Me.cboFileName.Name = "cboFileName"
        Me.cboFileName.Size = New System.Drawing.Size(295, 21)
        Me.cboFileName.TabIndex = 33
        '
        'lblfilename
        '
        Me.lblfilename.AutoSize = True
        Me.lblfilename.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfilename.Location = New System.Drawing.Point(176, 21)
        Me.lblfilename.Name = "lblfilename"
        Me.lblfilename.Size = New System.Drawing.Size(61, 13)
        Me.lblfilename.TabIndex = 32
        Me.lblfilename.Text = "File Name"
        Me.lblfilename.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkSelect
        '
        Me.chkSelect.AutoSize = True
        Me.chkSelect.Location = New System.Drawing.Point(710, 20)
        Me.chkSelect.Name = "chkSelect"
        Me.chkSelect.Size = New System.Drawing.Size(78, 17)
        Me.chkSelect.TabIndex = 7
        Me.chkSelect.Text = "Select &All"
        Me.chkSelect.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.GhostWhite
        Me.btnClear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.Location = New System.Drawing.Point(632, 15)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "&Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.GhostWhite
        Me.btnRefresh.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.Black
        Me.btnRefresh.Location = New System.Drawing.Point(557, 15)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'lblBatchNo
        '
        Me.lblBatchNo.AutoSize = True
        Me.lblBatchNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBatchNo.Location = New System.Drawing.Point(190, 349)
        Me.lblBatchNo.Name = "lblBatchNo"
        Me.lblBatchNo.Size = New System.Drawing.Size(0, 13)
        Me.lblBatchNo.TabIndex = 0
        '
        'btnsendmail
        '
        Me.btnsendmail.Location = New System.Drawing.Point(789, 499)
        Me.btnsendmail.Name = "btnsendmail"
        Me.btnsendmail.Size = New System.Drawing.Size(92, 31)
        Me.btnsendmail.TabIndex = 2
        Me.btnsendmail.Text = "Send"
        Me.btnsendmail.UseVisualStyleBackColor = True
        '
        'lblrecords
        '
        Me.lblrecords.AutoSize = True
        Me.lblrecords.ForeColor = System.Drawing.Color.Red
        Me.lblrecords.Location = New System.Drawing.Point(20, 561)
        Me.lblrecords.Name = "lblrecords"
        Me.lblrecords.Size = New System.Drawing.Size(10, 13)
        Me.lblrecords.TabIndex = 3
        Me.lblrecords.Text = "!"
        '
        'pnlAttachment
        '
        Me.pnlAttachment.Controls.Add(Me.btnRemove)
        Me.pnlAttachment.Controls.Add(Me.lstAttachment)
        Me.pnlAttachment.Controls.Add(Me.btnAdd)
        Me.pnlAttachment.Controls.Add(Me.Label2)
        Me.pnlAttachment.Location = New System.Drawing.Point(193, 492)
        Me.pnlAttachment.Name = "pnlAttachment"
        Me.pnlAttachment.Size = New System.Drawing.Size(590, 83)
        Me.pnlAttachment.TabIndex = 6
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.Color.AliceBlue
        Me.btnRemove.Location = New System.Drawing.Point(500, 43)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(75, 29)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.Text = "&Remove"
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'lstAttachment
        '
        Me.lstAttachment.FormattingEnabled = True
        Me.lstAttachment.Location = New System.Drawing.Point(105, 7)
        Me.lstAttachment.Name = "lstAttachment"
        Me.lstAttachment.Size = New System.Drawing.Size(390, 69)
        Me.lstAttachment.TabIndex = 1
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.AliceBlue
        Me.btnAdd.Location = New System.Drawing.Point(500, 10)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 29)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Attachment(s)"
        '
        'ofd
        '
        Me.ofd.FileName = "OpenFileDialog1"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(789, 537)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(92, 31)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'lblAsciiPath
        '
        Me.lblAsciiPath.AutoSize = True
        Me.lblAsciiPath.Location = New System.Drawing.Point(245, 425)
        Me.lblAsciiPath.Name = "lblAsciiPath"
        Me.lblAsciiPath.Size = New System.Drawing.Size(46, 13)
        Me.lblAsciiPath.TabIndex = 9
        Me.lblAsciiPath.Text = "Add CC"
        Me.lblAsciiPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAddCC
        '
        Me.txtAddCC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddCC.Location = New System.Drawing.Point(298, 425)
        Me.txtAddCC.MaxLength = 0
        Me.txtAddCC.Multiline = True
        Me.txtAddCC.Name = "txtAddCC"
        Me.txtAddCC.Size = New System.Drawing.Size(390, 61)
        Me.txtAddCC.TabIndex = 10
        '
        'frmSendMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(889, 585)
        Me.Controls.Add(Me.txtAddCC)
        Me.Controls.Add(Me.lblAsciiPath)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.pnlAttachment)
        Me.Controls.Add(Me.lblrecords)
        Me.Controls.Add(Me.btnsendmail)
        Me.Controls.Add(Me.grpMain)
        Me.Controls.Add(Me.lblBatchNo)
        Me.Controls.Add(Me.dgvList)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSendMail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SEND MAIL"
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMain.ResumeLayout(False)
        Me.grpMain.PerformLayout()
        Me.pnlAttachment.ResumeLayout(False)
        Me.pnlAttachment.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvList As System.Windows.Forms.DataGridView
    Friend WithEvents grpMain As System.Windows.Forms.GroupBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents chkSelect As System.Windows.Forms.CheckBox
    Friend WithEvents lblBatchNo As System.Windows.Forms.Label
    Friend WithEvents btnsendmail As System.Windows.Forms.Button
    Friend WithEvents lblrecords As System.Windows.Forms.Label
    Friend WithEvents pnlAttachment As System.Windows.Forms.Panel
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents lstAttachment As System.Windows.Forms.ListBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cboFileName As System.Windows.Forms.ComboBox
    Friend WithEvents lblfilename As System.Windows.Forms.Label
    Friend WithEvents lblimportdate As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents lblAsciiPath As System.Windows.Forms.Label
    Friend WithEvents txtAddCC As System.Windows.Forms.TextBox
End Class
