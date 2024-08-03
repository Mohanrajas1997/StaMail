Imports FlexiLibrary
Imports FlexiLibrary.iRoutines
Public Class frmImportReport

#Region "Form Level Declarations"
    Dim fsSql As String
#End Region

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Try

            btnRefresh.Enabled = Not btnRefresh.Enabled
            Me.Cursor = Cursors.WaitCursor
            Application.DoEvents()

            Call LoadData()

            If dGrid.Rows.Count > 0 Then
                dGrid.EditMode = True
            End If

            btnRefresh.Enabled = Not btnRefresh.Enabled
            Me.Cursor = Cursors.Default
            Application.DoEvents()

        Catch ex As Exception
            btnRefresh.Enabled = Not btnRefresh.Enabled
            Me.Cursor = Cursors.Default
            Application.DoEvents()
            'Call InsertErrorLog(Me.Name, MethodBase.GetCurrentMethod().Name, Err.Description)

        End Try
    End Sub

    Private Sub LoadData()

        Dim lobjDataSet As New DataSet

        Dim lsCondn As String = ""
        Dim lsAccMode As String = ""

        '**************************************
        'Condition
        '**************************************


        lsCondn = ""

        If dtpImportFrom.Checked = True Then
            lsCondn &= " and file_importedon >= '" & Format(CDate(dtpImportFrom.Value), "yyyy-MM-dd") & "' "
        End If

        If dtpImportTo.Checked = True Then
            lsCondn &= " and file_importedon < '" & Format(DateAdd(DateInterval.Day, 1, CDate(dtpImportTo.Value)), "yyyy-MM-dd") & "' "
        End If


        If cboFileName.Text.Trim <> "" Then
            lsCondn &= " and file_gid = '" & cboFileName.SelectedValue.ToString & "'"
        End If


        '*******************************************
        'Display Table Fields
        '*******************************************

        fsSql = ""
        fsSql &= " SELECT"
        fsSql &= " mail_gid,mail_from,mail_to,folio_no,folio_name,"
        fsSql &= " share_count,dividend_amount,tds_per,gross_amount,bank_acc_no,bank_name,bank_branch,bank_pin,remittance_date,"
        fsSql &= " ref_col1,ref_col2,ref_col3,ref_col4"

        fsSql &= " from mail_trn_tmail "

        fsSql &= " inner join mail_mst_tfile"
        fsSql &= " on file_gid = mail_file_gid"

        fsSql &= " where 1 = 1  " & lsCondn & ""
        fsSql &= " and mail_sendflag = " & IIf(optSend.Checked, "'Y'", "'N'")
        fsSql &= " and file_status ='A'"
        fsSql &= " order by file_importedon"

        lobjDataSet = gfDataSet(fsSql, "tblReports", gOdbcConn)

        If dGrid.Rows.Count > 0 Then
            'dGrid.Rows.Clear()
        End If

        dGrid.DataSource = Nothing
        dGrid.Columns.Clear()
        dGrid.DataSource = lobjDataSet.Tables("tblReports")

        Dim objtxt As New DataGridViewTextBoxColumn
        objtxt.HeaderText = "Select"
        objtxt.ReadOnly = False
        objtxt.DisplayIndex = 0
        dGrid.Columns.Add(objtxt)

        dGrid.Columns("mail_gid").Visible = False
        dGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        lblrecordcount.Text = "RecordCount: " & dGrid.Rows.Count

        '***********************************************************************

    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        If MsgBox("Do you want to close ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        Try
            dtpImportTo.Value = Now
            dtpImportFrom.Value = Now

            dtpImportFrom.Checked = False
            dtpImportTo.Checked = False

            cboFileName.SelectedIndex = -1
            cboFileName.SelectedIndex = -1


            dGrid.DataSource = Nothing

            lblrecordcount.Text = "Total Record : "

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmAllocationReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' MyBase.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmAllocationReport_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            grpMain.Top = 6
            grpMain.Left = 8

            With dGrid
                .Top = grpMain.Top + grpMain.Height + 6
                .Left = 8
                .Width = Me.Width - 24
                .Height = (Me.Height - grpMain.Height) - grpMain.Height / 1.2
            End With

            grpExport.Top = Me.Height - (grpExport.Height * 1.9)
            grpExport.Width = Me.Width - 24
            btnexport.Left = grpExport.Width - (btnexport.Width * 1.2)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexport.Click
        If dGrid.RowCount > 0 Then
            PrintDGViewXML(dGrid, gsReportPath & "ImportReport.xls", "Import Report")
        Else
            MsgBox("No Record found !...")
        End If
    End Sub

    Private Sub cboFileName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFileName.GotFocus
        fsSql = ""
        fsSql &= " select file_name,file_gid from mail_mst_tfile where 1=1"

        fsSql &= " and comp_gid = " & gnCompId & " "
        If dtpImportFrom.Checked = True Then
            fsSql &= " AND file_importedon >= '" & Format(dtpImportFrom.Value, "yyyy-MM-dd") & "'"
        End If

        If dtpImportTo.Checked = True Then
            fsSql &= " AND file_importedon < '" & Format(DateAdd(DateInterval.Day, 1, dtpImportTo.Value), "yyyy-MM-dd") & "'"
        End If

        fsSql &= " and file_status ='A' order by file_gid"

        gpBindCombo(fsSql, "file_name", "file_gid", cboFileName, gOdbcConn)
    End Sub

    Private Sub cboFileName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFileName.TextChanged
        If cboFileName.SelectedIndex = -1 And cboFileName.Text <> "" Then gpAutoFillCombo(cboFileName)
    End Sub

    Private Sub optSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optSend.Click
        Call LoadData()
    End Sub

    Private Sub optNotSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optNotSend.Click
        Call LoadData()
    End Sub

    'Private Sub dGrid_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellLeave
    '    If dGrid.CurrentCell.Value = 5 Then
    '        Dim lsVal As String
    '        lsVal = dGrid.CurrentRow.Cells(5).Value
    '    End If
    'End Sub

    Private Sub dGrid_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.CurrentCellDirtyStateChanged
        If dGrid.IsCurrentCellDirty Then
            dGrid.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
        Dim lsVal As String
        lsVal = dGrid.CurrentRow.Cells(5).Value
    End Sub

    Private Sub lblimportdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblimportdate.Click

    End Sub

    Private Sub cboFileName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFileName.SelectedIndexChanged

    End Sub
End Class