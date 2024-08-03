Option Strict On
Option Explicit On 
Public Class frmSearch
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal cnstring As String, ByVal sqlstr As String, ByVal rawfld As String, ByVal cond As String)
        MyBase.New()

        cnstr = cnstring
        sql = sqlstr
        rawFldName = rawfld
        condition = cond

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        FillCombo()
        txt = 0
        RefreshGrid(sql & " where " & cond)
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cboFld As System.Windows.Forms.ComboBox
    Friend WithEvents lblFld As System.Windows.Forms.Label
    Friend WithEvents cboCondition As System.Windows.Forms.ComboBox
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents dgridView As System.Windows.Forms.DataGrid
    Friend WithEvents pnlInput As System.Windows.Forms.Panel
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlInput = New System.Windows.Forms.Panel
        Me.btnExport = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.cboCondition = New System.Windows.Forms.ComboBox
        Me.cboFld = New System.Windows.Forms.ComboBox
        Me.lblFld = New System.Windows.Forms.Label
        Me.dgridView = New System.Windows.Forms.DataGrid
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.pnlInput.SuspendLayout()
        CType(Me.dgridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlInput
        '
        Me.pnlInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInput.Controls.Add(Me.btnExport)
        Me.pnlInput.Controls.Add(Me.btnClose)
        Me.pnlInput.Controls.Add(Me.btnSearch)
        Me.pnlInput.Controls.Add(Me.txtSearch)
        Me.pnlInput.Controls.Add(Me.cboCondition)
        Me.pnlInput.Controls.Add(Me.cboFld)
        Me.pnlInput.Controls.Add(Me.lblFld)
        Me.pnlInput.Location = New System.Drawing.Point(9, 5)
        Me.pnlInput.Name = "pnlInput"
        Me.pnlInput.Size = New System.Drawing.Size(710, 51)
        Me.pnlInput.TabIndex = 4
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(621, 12)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(72, 24)
        Me.btnExport.TabIndex = 11
        Me.btnExport.Text = "Export"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(548, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "C&lose"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(475, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(72, 24)
        Me.btnSearch.TabIndex = 9
        Me.btnSearch.Text = "&Search"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(326, 13)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(136, 21)
        Me.txtSearch.TabIndex = 8
        '
        'cboCondition
        '
        Me.cboCondition.Location = New System.Drawing.Point(232, 13)
        Me.cboCondition.Name = "cboCondition"
        Me.cboCondition.Size = New System.Drawing.Size(85, 21)
        Me.cboCondition.TabIndex = 7
        '
        'cboFld
        '
        Me.cboFld.Location = New System.Drawing.Point(80, 13)
        Me.cboFld.Name = "cboFld"
        Me.cboFld.Size = New System.Drawing.Size(144, 21)
        Me.cboFld.TabIndex = 5
        '
        'lblFld
        '
        Me.lblFld.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblFld.AutoSize = True
        Me.lblFld.Location = New System.Drawing.Point(13, 14)
        Me.lblFld.Name = "lblFld"
        Me.lblFld.Size = New System.Drawing.Size(63, 13)
        Me.lblFld.TabIndex = 4
        Me.lblFld.Text = "Search by"
        '
        'dgridView
        '
        Me.dgridView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgridView.CaptionVisible = False
        Me.dgridView.DataMember = ""
        Me.dgridView.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgridView.Location = New System.Drawing.Point(7, 65)
        Me.dgridView.Name = "dgridView"
        Me.dgridView.PreferredColumnWidth = 100
        Me.dgridView.ReadOnly = True
        Me.dgridView.Size = New System.Drawing.Size(712, 319)
        Me.dgridView.TabIndex = 5
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Text = "StatusBarPanel1"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Controls.Add(Me.btnOk)
        Me.Panel1.Location = New System.Drawing.Point(487, 392)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(232, 40)
        Me.Panel1.TabIndex = 15
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(152, 8)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "&Cancel"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(80, 8)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
        Me.btnRefresh.TabIndex = 16
        Me.btnRefresh.Text = "&Refresh"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(8, 8)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(72, 24)
        Me.btnOk.TabIndex = 15
        Me.btnOk.Text = "&Ok"
        '
        'frmSearch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(728, 437)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgridView)
        Me.Controls.Add(Me.pnlInput)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search"
        Me.pnlInput.ResumeLayout(False)
        Me.pnlInput.PerformLayout()
        CType(Me.dgridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim cnstr As String
    Dim sql As String
    Dim rawFldName As String
    Dim condition As String
    Private Sub FillCombo()
        ' Fill Condition
        With cboCondition
            .Items.Clear()
            .Items.Add("Like")
            .Items.Add("Not Like")
            .Items.Add("=")
            .Items.Add(">")
            .Items.Add(">=")
            .Items.Add("<")
            .Items.Add("<=")
            .Items.Add("<>")
            .SelectedIndex = 0
        End With
    End Sub
    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        With dgridView
            pnlInput.Top = 12
            pnlInput.Left = 12

            .Left = 12

            .Top = Math.Abs(pnlInput.Top + pnlInput.Height + 8)
            .Height = Math.Abs(Me.Height - .Top - 85)
            .Width = Math.Abs(Me.Width - 24)
        End With
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim cond As String = " where " & condition
        Dim fld() As String = Split(rawFldName, ",")

        txtSearch.Text = txtSearch.Text.Trim()

        If cboFld.Text <> "" And txtSearch.Text <> "" And cboCondition.Text <> "" Then
            If condition = "" Then
                cond = " where " & fld(cboFld.Items.IndexOf(cboFld.Text)) & " "
            Else
                cond &= " and " & fld(cboFld.Items.IndexOf(cboFld.Text)) & " "
            End If

            Select Case UCase(cboCondition.Text)
                Case "LIKE", "NOT LIKE"
                    cond = cond & " " & cboCondition.Text & " '" & txtSearch.Text & "%' "
                Case ""
                    cond = ""
                Case Else
                    cond = cond & " " & cboCondition.Text & " '" & txtSearch.Text & "' "
            End Select
        End If

        RefreshGrid(sql & cond)
    End Sub
    Private Sub RefreshGrid(ByVal sqlstr As String)
        Dim cn As New Odbc.OdbcConnection(cnstr)
        Dim cmd As New Odbc.OdbcCommand
        Dim adp As New Odbc.OdbcDataAdapter
        Dim ds As New DataSet

        If cnstr Is Nothing Then Exit Sub

        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = sqlstr
        cmd.CommandType = CommandType.Text

        adp.SelectCommand = cmd
        adp.Fill(ds, "search")
        dgridView.DataSource = ds.Tables("search")

        ' Add column name
        If cboFld.Items.Count = 0 Then
            For i As Integer = 0 To ds.Tables("search").Columns.Count - 1
                cboFld.Items.Add(ds.Tables("search").Columns(i).ColumnName)
            Next
        End If
        dgridView.PreferredColumnWidth = 200
        cn.Close()
    End Sub
    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        btnSearch.PerformClick()
    End Sub
    Private Sub dgridView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgridView.DoubleClick
        'MsgBox(dgridView.Item(dgridView.CurrentCell.RowNumber, 0))
        txt = Convert.ToInt64(dgridView.Item(dgridView.CurrentCell.RowNumber, 0))
        txt = CLng(txt)
        MyBase.Close()
    End Sub
    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If dgridView.VisibleRowCount > 0 Then
            Call PrintDGridXML(dgridView, gsReportPath & "Search Report.xls", "Search Report")
        Else
            MsgBox("No Records Found", MsgBoxStyle.Information, gsProjectName)
            Exit Sub
        End If
    End Sub
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        txt = Convert.ToInt64(dgridView.Item(dgridView.CurrentCell.RowNumber, 0))
        txt = CLng(txt)
        MyBase.Close()
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        MyBase.Close()
    End Sub

    Private Sub frmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
