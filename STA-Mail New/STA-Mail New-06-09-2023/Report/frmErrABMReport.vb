Public Class frmErrABMReport

#Region "Form Level Declarations"
    Dim fsSql As String
#End Region

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Try

            btnRefresh.Enabled = Not btnRefresh.Enabled
            Me.Cursor = Cursors.WaitCursor
            Application.DoEvents()

            Call LoadData()

            btnRefresh.Enabled = Not btnRefresh.Enabled
            Me.Cursor = Cursors.Default
            Application.DoEvents()

        Catch ex As Exception

            Call InsertErrorLog(Me.Name, MethodBase.GetCurrentMethod().Name, Err.Description)

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
            lsCondn &= " and b.import_date >= '" & Format(CDate(dtpImportFrom.Value), "yyyy-MM-dd") & "' "
        End If

        If dtpImportTo.Checked = True Then
            lsCondn &= " and b.import_date < '" & Format(DateAdd(DateInterval.Day, 1, CDate(dtpImportTo.Value)), "yyyy-MM-dd") & "' "
        End If

        If txtAmount.Text <> "" Then
            lsCondn &= " and concat(a.cc,a.bs) = '" & QuoteFilter(txtAmount.Text.Trim) & "' "
        End If

        If txtmobileno.Text <> "" Then
            lsCondn &= " and a.alloc_percent = '" & QuoteFilter(txtmobileno.Text.Trim) & "' "
        End If


        If txtClientName.Text.Trim <> "" Then
            lsCondn &= " and a.business_code = '" & QuoteFilter(txtClientName.Text.Trim) & "'"
        End If
        If txtbranchId.Text.Trim <> "" Then
            lsCondn &= " and a.dept_name = '" & QuoteFilter(txtbranchId.Text.Trim) & "'"
        End If

      

        '*******************************************
        'Display Table Fields
        '*******************************************

        fsSql = ""
        fsSql &= " select "
        fsSql &= " date_format(a.abm_StartTime,'%d-%m-%Y') as 'StartTime',"
        fsSql &= " date_format(a.abm_EndTime,'%d-%m-%Y') as 'EndTime',"
        fsSql &= " abm_Agent as Agent,"
        fsSql &= " abm_CLI as CLI,"
        fsSql &= " abm_Type as Type,"
        fsSql &= " abm_Disposition as Disposition,"
        fsSql &= " abm_AlternatePhone as AlternatePhone,"
        fsSql &= " abm_Remarks as Remarks,"
        fsSql &= " abm_VoiceFile as VoiceFile,"
        fsSql &= " date_format(a.abm_NextDialTime,'%d-%m-%Y') as NextDialTime,"
        fsSql &= "abm_TrunkNumber as TrunkNumber,"
        fsSql &= "abm_Module as Module,"
        fsSql &= "abm_PreviewTime as PreviewTime,"
        fsSql &= "abm_DialTime as DialTime,"
        fsSql &= "abm_LeadAttempts as LeadAttempts,"
        fsSql &= "abm_Parameter1 as Parameter1,"
        fsSql &= "abm_ClientId as ClientId,"
        fsSql &= "abm_ClientName as ClientName,"
        fsSql &= "abm_MobileNo as MobileNo,"
        fsSql &= "abm_DebitAmount as DebitAmount,"
        fsSql &= "abm_BranchID as BranchID,"
        fsSql &= "abm_BranchName as BranchName,"
        fsSql &= "abm_Count as Count,"
        fsSql &= "abm_Uniq as Uniq,"
        fsSql &= "date_format(a.abm_FollDate,'%d-%m-%Y') as FollDate,"
        fsSql &= "abm_Source as Source,"
        fsSql &= "abm_MailID as MailID,"
        fsSql &= "abm_ClusterID as ClusterID,"
        fsSql &= " date_format(b.import_date,'%d-%m-%Y') as 'Import Date',"
        fsSql &= " b.import_by as 'Import By'"

        fsSql &= " from  abm_trn_terrbranch a"

        fsSql &= " inner join abm_trn_tbranchfile b"
        fsSql &= " on b.branchfile_gid = a.branchfile_gid"
        fsSql &= " and b.delete_flag ='N'"

        fsSql &= " where 1 = 1  " & lsCondn & " "
        fsSql &= " and a.delete_flag ='N'"
        fsSql &= " order by  b.import_date"

        lobjDataSet = gfDataSet(fsSql, "tblReports", gOdbcConn)

        dGrid.DataSource = lobjDataSet.Tables("tblReports")

        lblrecordcount.Text = "RecordCount: " & dGrid.Rows.Count

        '***********************************************************************
        'Total Amount
        fsSql = ""
        fsSql &= " select count(*) as '#'"

        fsSql &= " from  abm_trn_terrbranch a"

        fsSql &= " inner join  erpt_trn_tbranchfile b"
        fsSql &= " on b.branchfile_gid = a.branchfile_gid"
        fsSql &= " and b.delete_flag ='N'"

        fsSql &= " where 1 = 1  " & lsCondn & " "
        fsSql &= " and a.delete_flag ='N'"

        lobjDataSet = gfDataSet(fsSql, "tblReports", gOdbcConn)
        lblrecordcount.Text = "Total Records : " & lobjDataSet.Tables("tblReports").Rows(0).Item(0).ToString

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
            txtClientName.Text = ""
            txtAmount.Text = ""
            txtbranchId.Text = ""
            cboFileName.SelectedIndex = -1
            cboFileName.SelectedIndex = -1
            dGrid.DataSource = Nothing
            lblrecordcount.Text = "Total Record : "

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmErrAllocationReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub frmErrAllocationReport_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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
            PrintDGViewXML(dGrid, gsReportPath & "P2P.xls", "P2P Report")
        Else
            MsgBox("No Record found !...")
        End If
    End Sub

    Private Sub dtpImportFrom_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpImportFrom.ValueChanged

        fsSql = ""
        fsSql &= " select file_name,branchfile_gid from  erpt_trn_tbranchfile where 1=1"


        If dtpImportFrom.Checked = True And dtpImportTo.Checked = False Then
            fsSql &= " AND date_format(import_date,'%Y-%m-%d') = '" & Format(dtpImportFrom.Value, "yyyy-MM-dd") & "'"
        End If
        If dtpImportTo.Checked = True And dtpImportFrom.Checked = False Then
            fsSql &= " AND date_format(import_date,'%Y-%m-%d') = '" & Format(dtpImportTo.Value, "yyyy-MM-dd") & "'"
        End If

        If dtpImportFrom.Checked = True And dtpImportTo.Checked = True Then
            fsSql &= " AND date_format(import_date,'%Y-%m-%d') >= '" & Format(dtpImportFrom.Value, "yyyy-MM-dd") & "'"
        End If

        If dtpImportTo.Checked = True And dtpImportFrom.Checked = True Then
            fsSql &= " AND date_format(import_date,'%Y-%m-%d') <=  '" & Format(dtpImportTo.Value, "yyyy-MM-dd") & "'"
        End If
        fsSql &= " and delete_flag ='N' order by branchfile_gid"

        If (dtpImportFrom.Checked = True Or dtpImportTo.Checked = True) Then
            gpBindCombo(fsSql, "file_name", "branchfile_gid", cboFileName, gOdbcConn)
        Else
            cboFileName.DataSource = Nothing
        End If

    End Sub

    Private Sub dtpImportTo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpImportTo.ValueChanged

        fsSql = ""
        fsSql &= " select file_name,branchfile_gid from  erpt_trn_tbranchfile where 1=1"


        If dtpImportFrom.Checked = True And dtpImportTo.Checked = False Then
            fsSql &= " AND date_format(import_date,'%Y-%m-%d') = '" & Format(dtpImportFrom.Value, "yyyy-MM-dd") & "'"
        End If
        If dtpImportTo.Checked = True And dtpImportFrom.Checked = False Then
            fsSql &= " AND date_format(import_date,'%Y-%m-%d') = '" & Format(dtpImportTo.Value, "yyyy-MM-dd") & "'"
        End If

        If dtpImportFrom.Checked = True And dtpImportTo.Checked = True Then
            fsSql &= " AND date_format(import_date,'%Y-%m-%d') >= '" & Format(dtpImportFrom.Value, "yyyy-MM-dd") & "'"
        End If

        If dtpImportTo.Checked = True And dtpImportFrom.Checked = True Then
            fsSql &= " AND date_format(import_date,'%Y-%m-%d') <=  '" & Format(dtpImportTo.Value, "yyyy-MM-dd") & "'"
        End If
        fsSql &= " and delete_flag ='N' order by branchfile_gid"

        If (dtpImportFrom.Checked = True Or dtpImportTo.Checked = True) Then
            gpBindCombo(fsSql, "file_name", "branchfile_gid", cboFileName, gOdbcConn)
        Else
            cboFileName.DataSource = Nothing
        End If

    End Sub

    Private Sub cboFileName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFileName.TextChanged
        If cboFileName.SelectedIndex = -1 And cboFileName.Text <> "" Then gpAutoFillCombo(cboFileName)
    End Sub
End Class