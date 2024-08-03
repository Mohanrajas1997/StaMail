<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.MnnmstMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnumstMail = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuImport = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAbmImport1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuDeleteabm = New System.Windows.Forms.ToolStripMenuItem
        Me.ProcessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSendMailBranchwise = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReportImport = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.NewWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TileVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TileHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ArrangeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblCorpStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblUserName = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblDate = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnnmstMaster, Me.MnuImport, Me.ProcessToolStripMenuItem, Me.MnuReport, Me.WindowsMenu, Me.ExitToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip.Size = New System.Drawing.Size(1028, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'MnnmstMaster
        '
        Me.MnnmstMaster.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnumstMail})
        Me.MnnmstMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MnnmstMaster.Name = "MnnmstMaster"
        Me.MnnmstMaster.Size = New System.Drawing.Size(59, 20)
        Me.MnnmstMaster.Text = "&Master"
        Me.MnnmstMaster.Visible = False
        '
        'MnumstMail
        '
        Me.MnumstMail.Name = "MnumstMail"
        Me.MnumstMail.Size = New System.Drawing.Size(152, 22)
        Me.MnumstMail.Text = "&URL"
        '
        'MnuImport
        '
        Me.MnuImport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAbmImport1, Me.ToolStripSeparator2, Me.DeleteToolStripMenuItem})
        Me.MnuImport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MnuImport.Name = "MnuImport"
        Me.MnuImport.Size = New System.Drawing.Size(59, 20)
        Me.MnuImport.Text = "&Import"
        '
        'mnuAbmImport1
        '
        Me.mnuAbmImport1.Name = "mnuAbmImport1"
        Me.mnuAbmImport1.Size = New System.Drawing.Size(152, 22)
        Me.mnuAbmImport1.Text = "&Import"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(149, 6)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuDeleteabm})
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteToolStripMenuItem.Text = "&Delete"
        Me.DeleteToolStripMenuItem.Visible = False
        '
        'MnuDeleteabm
        '
        Me.MnuDeleteabm.Name = "MnuDeleteabm"
        Me.MnuDeleteabm.Size = New System.Drawing.Size(152, 22)
        Me.MnuDeleteabm.Text = "&Transaction"
        '
        'ProcessToolStripMenuItem
        '
        Me.ProcessToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuSendMailBranchwise})
        Me.ProcessToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProcessToolStripMenuItem.Name = "ProcessToolStripMenuItem"
        Me.ProcessToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.ProcessToolStripMenuItem.Text = "Process"
        '
        'MnuSendMailBranchwise
        '
        Me.MnuSendMailBranchwise.Name = "MnuSendMailBranchwise"
        Me.MnuSendMailBranchwise.Size = New System.Drawing.Size(152, 22)
        Me.MnuSendMailBranchwise.Text = "Send Mail"
        '
        'MnuReport
        '
        Me.MnuReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuReportImport})
        Me.MnuReport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MnuReport.Name = "MnuReport"
        Me.MnuReport.Size = New System.Drawing.Size(58, 20)
        Me.MnuReport.Text = "&Report"
        '
        'MnuReportImport
        '
        Me.MnuReportImport.Name = "MnuReportImport"
        Me.MnuReportImport.Size = New System.Drawing.Size(152, 22)
        Me.MnuReportImport.Text = "&Import"
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewWindowToolStripMenuItem, Me.CascadeToolStripMenuItem, Me.TileVerticalToolStripMenuItem, Me.TileHorizontalToolStripMenuItem, Me.CloseAllToolStripMenuItem, Me.ArrangeIconsToolStripMenuItem})
        Me.WindowsMenu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(69, 20)
        Me.WindowsMenu.Text = "&Windows"
        '
        'NewWindowToolStripMenuItem
        '
        Me.NewWindowToolStripMenuItem.Name = "NewWindowToolStripMenuItem"
        Me.NewWindowToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.NewWindowToolStripMenuItem.Text = "&New Window"
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.CascadeToolStripMenuItem.Text = "&Cascade"
        '
        'TileVerticalToolStripMenuItem
        '
        Me.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
        Me.TileVerticalToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.TileVerticalToolStripMenuItem.Text = "Tile &Vertical"
        '
        'TileHorizontalToolStripMenuItem
        '
        Me.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
        Me.TileHorizontalToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.TileHorizontalToolStripMenuItem.Text = "Tile &Horizontal"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.CloseAllToolStripMenuItem.Text = "C&lose All"
        '
        'ArrangeIconsToolStripMenuItem
        '
        Me.ArrangeIconsToolStripMenuItem.Name = "ArrangeIconsToolStripMenuItem"
        Me.ArrangeIconsToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ArrangeIconsToolStripMenuItem.Text = "&Arrange Icons"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = False
        Me.lblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Bump
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(250, 17)
        Me.lblStatus.Text = "Status"
        '
        'lblCorpStatus
        '
        Me.lblCorpStatus.AutoSize = False
        Me.lblCorpStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Bump
        Me.lblCorpStatus.Name = "lblCorpStatus"
        Me.lblCorpStatus.Size = New System.Drawing.Size(200, 17)
        Me.lblCorpStatus.Text = "Status"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = False
        Me.lblUserName.BorderStyle = System.Windows.Forms.Border3DStyle.Bump
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(270, 17)
        Me.lblUserName.Text = "User name"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = False
        Me.lblDate.BorderStyle = System.Windows.Forms.Border3DStyle.Bump
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(150, 17)
        Me.lblDate.Text = "Date"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus, Me.lblCorpStatus, Me.lblUserName, Me.lblDate})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 617)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1028, 22)
        Me.StatusStrip1.TabIndex = 9
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 639)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frmMain"
        Me.Text = "Mail"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ArrangeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAbmImport1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCorpStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblUserName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDeleteabm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnnmstMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnumstMail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuReportImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcessToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSendMailBranchwise As System.Windows.Forms.ToolStripMenuItem

End Class
