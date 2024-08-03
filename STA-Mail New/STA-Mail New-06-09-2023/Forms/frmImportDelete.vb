Public Class frmImportDelete

#Region "Form Level Declarations"
    Dim fsSql As String
    Dim fnCount As Long
    Dim fsImportType As String

    Dim fsQueryDesc As String
    Dim fsQueryDetail As String
    Dim lsSql As String
    Dim lnResult As Integer
#End Region

    'Public Sub New(ByVal Flag As String)

    '    ' This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.
    '    fsImportType = Flag

    'End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Are you sure to close ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, gsProjectName) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub
    Private Sub frmImportDelete_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpImportDate.Value = DateSerial(2000, 1, 1)
        dtpImportDate.Value = Now
    End Sub
    Private Sub cboFileName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFileName.TextChanged
        If cboFileName.SelectedIndex = -1 And cboFileName.Text <> "" Then gpAutoFillCombo(cboFileName)
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click


        Dim lnchqCount As Long = 0
        Dim lnchqAmount As Double = 0
        Dim lnBranchFilegid As Integer

        Try

            If cboFileName.SelectedIndex = -1 Or cboFileName.Text = "" Then
                MsgBox("Please select the file name to delete ?", MsgBoxStyle.Information, gsProjectName)
                cboFileName.Focus()
                Exit Sub
            End If

            If MsgBox("Are you sure to delete ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.Yes Then


                fsSql = ""
                fsSql &= " select branchfile_gid"
                fsSql &= " from abm_trn_tbranchgroup"
                fsSql &= " where branchfile_gid = " & cboFileName.SelectedValue.ToString
                fsSql &= " and sendmail_flag ='Y'"
                fsSql &= " and delete_flag ='N'"

                lnBranchFilegid = Val(gfExecuteScalar(fsSql, gOdbcConn))
                If lnBranchFilegid <> 0 Then
                    MsgBox("Already Send this File !...", MsgBoxStyle.Information, gsProjectName)
                    cboFileName.Focus()
                    Exit Sub
                End If


                fsSql = ""
                fsSql = " update abm_trn_tbranchfile set"
                fsSql &= " delete_flag = 'Y',"
                fsSql &= " delete_by = '" & gUserName & "',"
                fsSql &= " delete_date = sysdate()"
                fsSql &= " where branchfile_gid = " & cboFileName.SelectedValue.ToString & " "
                fsSql &= " and delete_flag ='N'"

                fnCount = gfInsertQry(fsSql, gOdbcConn)

                fsSql = ""
                fsSql = " update abm_trn_tbranch"
                fsSql &= " set delete_flag = 'Y'"
                fsSql &= " where branchfile_gid = " & cboFileName.SelectedValue.ToString & " "
                fsSql &= " and delete_flag ='N'"

                fnCount = gfInsertQry(fsSql, gOdbcConn)

                fsSql = ""
                fsSql = " delete from abm_trn_terrbranch"
                fsSql &= " where branchfile_gid = " & cboFileName.SelectedValue.ToString & " "
                fsSql &= " and delete_flag ='N'"

                fnCount = gfInsertQry(fsSql, gOdbcConn)

                fsSql = ""
                fsSql = " delete from abm_trn_tbranchgroup"
                fsSql &= " where branchfile_gid = " & cboFileName.SelectedValue.ToString & " "
                fsSql &= " and delete_flag ='N'"

                fnCount = gfInsertQry(fsSql, gOdbcConn)


                MsgBox("File deleted successfully !", MsgBoxStyle.Information, gsProjectName)

                dtpImportDate.Tag = dtpImportDate.Value
                dtpImportDate.Value = DateAdd(DateInterval.Day, 1, Now)
                dtpImportDate.Value = dtpImportDate.Tag
                dtpImportDate.Tag = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub dtpImportDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpImportDate.ValueChanged



        fsSql = ""
        fsSql &= " select branchfile_gid ,file_name as file_name from abm_trn_tbranchfile"
        fsSql &= " where import_date >= '" & Format(CDate(dtpImportDate.Value), "yyyy-MM-dd") & "' "
        fsSql &= " and import_date < '" & Format(DateAdd("d", 1, CDate(dtpImportDate.Value)), "yyyy-MM-dd") & "' "
        fsSql &= " and import_by ='" & gUserName & "'"
        fsSql &= " and delete_flag ='N'"

        gpBindCombo(fsSql, "file_name", "branchfile_gid", cboFileName, gOdbcConn)

      

    End Sub


End Class