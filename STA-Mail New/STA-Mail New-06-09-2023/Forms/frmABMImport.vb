Imports System.Data.Odbc
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Net

Imports System.Net.Mail


Public Class frmABMImport

    Inherits System.Windows.Forms.Form
#Region "Local Declaration"

    Dim fsSql As String
    Dim fnResult As Integer = 0
    Private mobjWriter As StreamWriter
    Dim lnResult As Long
    Dim path As String = ""
    Dim fsImportType As String = ""

    Dim fsFilePath As String = ""
    Dim fsFileName As String
    Dim fsExtName As String
    Dim DsBusiness As DataSet

#End Region

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        'User Selected Browse file 
        With OpenFileDialog1

            .Filter = "Excel Files|*.xls|Text Files|*.*|DBF Files|*.dbf|Text Files|*.txt|Word Files|*.doc"
            .Title = "Select Files to Import"
            .RestoreDirectory = True
            .ShowDialog()
            If .FileName <> "" And .FileName <> "OpenFileDialog1" Then
                txtFileName.Text = .FileName
            End If
            .FileName = ""
        End With

        If (InStr(1, LCase(Trim(txtFileName.Text)), ".xls")) > 0 Then
            cboSheetName.Enabled = True

            Call LoadSheet()

            cboSheetName.Focus()
        Else
            cboSheetName.Enabled = False
        End If

        Exit Sub

    End Sub

    Private Sub LoadSheet()
        Dim objXls As New Excel.Application
        Dim objBook As Excel.Workbook

        If Trim(txtFileName.Text) <> "" Then
            If File.Exists(txtFileName.Text) Then
                objBook = objXls.Workbooks.Open(txtFileName.Text)
                cboSheetName.Items.Clear()
                For i As Integer = 1 To objXls.ActiveWorkbook.Worksheets.Count
                    cboSheetName.Items.Add(objXls.ActiveWorkbook.Worksheets(i).Name)
                Next i
                objXls.Workbooks.Close()

            End If
        End If
        objXls.Quit()
        KillProcess(objXls.Hwnd)
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Do you want to Close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            MyBase.Close()
        End If
    End Sub
    Private Sub frmImportP2P_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'dtpImportFrom.Value = Now.Date
        'dtpImportFrom.MaxDate = Now.Date
        'dtpImportFrom.MinDate = Now.Date
        'Call NewMsg()
    End Sub
    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click

        Try
            If txtFileName.Text = "" Then
                MsgBox("Select File Name", MsgBoxStyle.Information, gsProjectName)
                txtFileName.Focus()
                Exit Sub
            End If

            Panel1.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            Application.DoEvents()
            fsFilePath = txtFileName.Text.Trim
            fsFileName = fsFilePath.Substring(fsFilePath.LastIndexOf("\") + 1)
            fsExtName = fsFilePath.Substring(fsFilePath.LastIndexOf(".") + 1)

            If txtFileName.Text <> "" Then

                If cboSheetName.Text <> "" Then
                    If fsExtName.ToUpper = "XLS" Then
                        Call ImportABM()

                    End If
                Else
                    MsgBox("Select Sheet Name!", MsgBoxStyle.Information, gsProjectName)
                    Exit Sub
                End If

            Else
                MsgBox("Select File to Import!", MsgBoxStyle.Information, gsProjectName)
                Exit Sub
            End If
            Call lp_Clear()
            Panel1.Enabled = True
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Call InsertErrorLog(Me.Name, MethodBase.GetCurrentMethod().Name, Err.Description)
        End Try

    End Sub

    Sub ImportABM()
        'On Error GoTo ErrorHandler
        Dim frm As Form
        Dim lsBusCol As String = ""
        Dim fsCorrectFormat As String = ""
        Dim dtExcel As New DataTable
        Dim dsExcel As New DataSet
        Dim lnTotalRecords As Integer = 0
        Dim lsErrorLogPath As String = Application.StartupPath & "\" & "ErrorLog.txt"
        Dim daExcel As New OleDbDataAdapter
        Dim ldTotalPercent As Double = 0
        Dim ldPercent As Double = 0
        Dim lsIDs As String = ""

        Dim lnErrCount As Integer = 0
        Dim lnTotCount As Integer = 0
        Dim lnSkipCount As Integer = 0
        Dim InsCount As Integer = 0
        Dim InValidCount As Integer = 0
        Dim lsStatus As Boolean = False
        Dim lsFileName As String = ""
        Dim lnTranFileGID As Long
        Dim lsErrDescription As String = ""

        Dim lsabm_StartTime As String = ""
        Dim lsabm_EndTime As String = ""
        Dim lsabm_Agent As String = ""
        Dim lsabm_CLI As String = ""
        Dim lsabm_Type As String = ""
        Dim lsabm_Disposition As String = ""
        Dim lsabm_AlternatePhone As String = ""
        Dim lsabm_Remarks As String = ""
        Dim lsabm_VoiceFile As String = ""
        Dim lsabm_NextDialTime As String = ""
        Dim lsabm_TrunkNumber As String = ""
        Dim lsabm_Module As String = ""
        Dim lsabm_PreviewTime As String = ""
        Dim lsabm_DialTime As String = ""
        Dim lsabm_LeadAttempts As String = ""
        Dim lsabm_Parameter1 As String = ""
        Dim lsabm_ClientId As String = ""
        Dim lsabm_ClientName As String = ""
        Dim lsabm_MobileNo As String = ""
        Dim lsabm_DebitAmount As Double = 0
        Dim lsabm_BranchID As String = ""
        Dim lsabm_BranchName As String = ""
        Dim lsabm_Count As String = ""
        Dim lsabm_Uniq As String = ""
        Dim lsabm_FollDate As String = ""
        Dim lsabm_Source As String = ""
        Dim lsabm_MailID As String = ""
        Dim lsabm_ClusterID As String = ""
        Dim lsabm_Disposition1 As String = ""




        lsFileName = QuoteFilter(fsFileName)

        fsSql = ""
        fsSql = "delete from abm_trn_terrbranch where abm_empcode='" & gUserName & "'"
        fnResult = gfInsertQry(fsSql, gOdbcConn)

        'File Name Duplicates
        fsSql = ""
        fsSql &= " select branchfile_gid from  abm_trn_tbranchfile"
        fsSql &= " where 1=1 "
        fsSql &= " and file_name = '" & lsFileName & "'"
        fsSql &= " and delete_flag ='N'"

        lnTranFileGID = Val(gfExecuteScalar(fsSql, gOdbcConn))
        If Not lnTranFileGID = 0 Then
            MsgBox("File Already Imported !", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gsProjectName)
            txtFileName.Focus()
            Exit Sub
        End If
        '---------------------------------
        Try
            dtExcel = gpExcelDataset("select * from [" & cboSheetName.Text & "$]", fsFilePath)
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        If dtExcel.Columns.Count <> 29 Then
            MsgBox("Column count mismatch" & vbCrLf & fsCorrectFormat, vbOKOnly + vbExclamation, gsProjectName)
            Exit Sub
        End If

        Call WriteErrLog(dtExcel)

        '   Accrual file insert

        fsSql = ""
        fsSql &= " insert into  abm_trn_tbranchfile"
        fsSql &= " (import_date,file_name,sheet_name,"
        fsSql &= " import_by)"
        fsSql &= " values ("
        fsSql &= " sysdate(),"
        fsSql &= " '" & lsFileName & "','" & cboSheetName.Text.Trim & "',"
        fsSql &= " '" & gUserName & "')"

        fnResult = gfInsertQry(fsSql, gOdbcConn)

        If fnResult = 0 Then

            MsgBox("Import Failure")
            btnImport.Enabled = Not btnImport.Enabled
            Me.Cursor = Cursors.Default
            Application.DoEvents()
            Exit Sub

        End If

        fsSql = " select max(branchfile_gid) from  abm_trn_tbranchfile "
        lnTranFileGID = gfExecuteScalar(fsSql, gOdbcConn)
        '																									Dispostion1

        Me.Enabled = False
        With dtExcel
            For i As Integer = 0 To .Rows.Count - 1
                With .Rows(i)

                    If .Item("Start Time").ToString() = "" Then
                        Exit For
                    End If

                    Application.DoEvents()

                    lsabm_StartTime = QuoteFilter(.Item("Start Time").ToString())
                    lsabm_EndTime = QuoteFilter(.Item("End Time").ToString())

                    If IsDate(lsabm_StartTime) = True Then
                        lsabm_StartTime = "'" & Format(CDate(lsabm_StartTime), "yyyy-MM-dd") & "'"
                    Else
                        lsabm_StartTime = "Null"
                        lsErrDescription = "Invaild StartTime"
                        lsStatus = True
                    End If

                    If IsDate(lsabm_EndTime) = True Then
                        lsabm_EndTime = "'" & Format(CDate(lsabm_EndTime), "yyyy-MM-dd") & "'"
                    Else
                        lsabm_EndTime = "Null"
                        lsErrDescription = "Invaild StartTime"
                        lsStatus = True
                    End If

                    lsabm_Agent = QuoteFilter(.Item("Agent").ToString())
                    lsabm_CLI = QuoteFilter(.Item("CLI").ToString())
                    lsabm_Type = QuoteFilter(.Item("Type").ToString())
                    lsabm_Disposition = QuoteFilter(.Item("Disposition").ToString())
                    lsabm_AlternatePhone = QuoteFilter(.Item("Alternate Phone").ToString())
                    lsabm_Remarks = QuoteFilter(.Item("Remarks").ToString())
                    lsabm_VoiceFile = QuoteFilter(.Item("Voice File").ToString())
                    lsabm_NextDialTime = QuoteFilter(.Item("Next Dial Time").ToString())

                    If IsDate(lsabm_NextDialTime) = True Then
                        lsabm_NextDialTime = "'" & Format(CDate(lsabm_NextDialTime), "yyyy-MM-dd") & "'"
                    Else
                        lsabm_NextDialTime = "Null"
                        lsErrDescription = "Invaild StartTime"
                        lsStatus = True
                    End If
                    lsabm_TrunkNumber = QuoteFilter(.Item("Trunk Number").ToString())
                    lsabm_Module = QuoteFilter(.Item("Module").ToString())
                    If lsabm_Module = "" Then
                        lsabm_Module = ""
                    End If
                    lsabm_PreviewTime = QuoteFilter(.Item("Preview Time").ToString())
                    lsabm_DialTime = QuoteFilter(.Item("Dial Time").ToString())
                    lsabm_LeadAttempts = QuoteFilter(.Item("Lead Attempts").ToString())
                    lsabm_Parameter1 = QuoteFilter(.Item("Parameter 1").ToString())
                    lsabm_ClientId = QuoteFilter(.Item("Client Id").ToString())
                    lsabm_ClientName = QuoteFilter(.Item("Client Name").ToString())
                    lsabm_MobileNo = QuoteFilter(.Item("Mobile No").ToString())
                    lsabm_DebitAmount = QuoteFilter(Val(.Item("Debit Amount").ToString()))
                    lsabm_BranchID = QuoteFilter(.Item("Branch ID").ToString())
                    lsabm_BranchName = QuoteFilter(.Item("Branch Name").ToString())
                    lsabm_Count = QuoteFilter(.Item("Count").ToString())
                    lsabm_Uniq = QuoteFilter(.Item("Uniq").ToString())
                    lsabm_FollDate = QuoteFilter(.Item("Foll Date").ToString())

                    If IsDate(lsabm_FollDate) = True Then
                        lsabm_FollDate = "'" & Format(CDate(lsabm_FollDate), "yyyy-MM-dd") & "'"
                    Else
                        lsabm_FollDate = "Null"
                        lsErrDescription = "Invaild StartTime"
                        lsStatus = True
                    End If
                    lsabm_Source = QuoteFilter(.Item("Source").ToString())
                    lsabm_MailID = LCase(QuoteFilter(.Item("Mail ID").ToString()))
                    lsabm_ClusterID = LCase(QuoteFilter(.Item("Cluster ID").ToString()))
                    lsabm_Disposition1 = QuoteFilter(.Item("Dispostion1").ToString())


                    If lsabm_BranchID <> "" Then
                        'Insert Main TBL

                        fsSql = ""
                        fsSql = " insert into abm_trn_tbranch("
                        fsSql &= " branchfile_gid,"
                        fsSql &= " abm_StartTime,"
                        fsSql &= " abm_EndTime,"
                        fsSql &= " abm_Agent,"
                        fsSql &= " abm_CLI,"
                        fsSql &= " abm_Type,"
                        fsSql &= " abm_Disposition,"
                        fsSql &= " abm_AlternatePhone,"
                        fsSql &= " abm_Remarks,"
                        fsSql &= " abm_VoiceFile,"
                        fsSql &= " abm_NextDialTime,"
                        fsSql &= " abm_TrunkNumber,"
                        fsSql &= " abm_Module,"
                        fsSql &= " abm_PreviewTime,"
                        fsSql &= " abm_DialTime,"
                        fsSql &= " abm_LeadAttempts,"
                        fsSql &= " abm_Parameter1,"
                        fsSql &= " abm_ClientId,"
                        fsSql &= " abm_ClientName,"
                        fsSql &= " abm_MobileNo,"
                        fsSql &= " abm_DebitAmount,"
                        fsSql &= " abm_BranchID,"
                        fsSql &= " abm_BranchName,"
                        fsSql &= " abm_Count,"
                        fsSql &= " abm_Uniq,"
                        fsSql &= " abm_FollDate,"
                        fsSql &= " abm_Source,"
                        fsSql &= " abm_MailID,"
                        fsSql &= " abm_ClusterID,abm_Dispostion1"
                        fsSql &= " ) values ( "
                        fsSql &= " " & lnTranFileGID & ","
                        fsSql &= " " & lsabm_StartTime & ","
                        fsSql &= " " & lsabm_EndTime & ","
                        fsSql &= " '" & lsabm_Agent & "',"
                        fsSql &= "  '" & lsabm_CLI & "',"
                        fsSql &= "  '" & lsabm_Type & "',"
                        fsSql &= "  '" & lsabm_Disposition & "',"
                        fsSql &= "  '" & lsabm_AlternatePhone & "',"
                        fsSql &= " '" & lsabm_Remarks & "',"
                        fsSql &= "  '" & lsabm_VoiceFile & "',"
                        fsSql &= "  " & lsabm_NextDialTime & ","
                        fsSql &= "  '" & lsabm_TrunkNumber & "',"
                        fsSql &= "  '" & lsabm_Module & "',"
                        fsSql &= " '" & lsabm_PreviewTime & "',"
                        fsSql &= "  '" & lsabm_DialTime & "',"
                        fsSql &= "  '" & lsabm_LeadAttempts & "',"
                        fsSql &= "  '" & lsabm_Parameter1 & "',"
                        fsSql &= "  '" & lsabm_ClientId & "',"
                        fsSql &= " '" & lsabm_ClientName & "',"
                        fsSql &= "  '" & lsabm_MobileNo & "',"
                        fsSql &= "  " & Val(lsabm_DebitAmount) & ","
                        fsSql &= "  '" & lsabm_BranchID & "',"
                        fsSql &= "  '" & lsabm_BranchName & "',"
                        fsSql &= " '" & lsabm_Count & "',"
                        fsSql &= "  '" & lsabm_Uniq & "',"
                        fsSql &= "  " & lsabm_FollDate & ","
                        fsSql &= "  '" & lsabm_Source & "',"
                        fsSql &= "  '" & lsabm_MailID & "',"
                        fsSql &= "  '" & lsabm_ClusterID & "','" & lsabm_Disposition1 & "')"

                        InsCount += 1

                        lnResult = gfInsertQry(fsSql, gOdbcConn)

                    Else
                        'Insert Main Err TBL

                        fsSql = ""
                        fsSql = " insert into abm_trn_terrbranch("
                        fsSql &= " branchfile_gid,"
                        fsSql &= " abm_StartTime,"
                        fsSql &= " abm_EndTime,"
                        fsSql &= " abm_Agent,"
                        fsSql &= " abm_CLI,"
                        fsSql &= " abm_Type,"
                        fsSql &= " abm_Disposition,"
                        fsSql &= " abm_AlternatePhone,"
                        fsSql &= " abm_Remarks,"
                        fsSql &= " abm_VoiceFile,"
                        fsSql &= " abm_NextDialTime,"
                        fsSql &= " abm_TrunkNumber,"
                        fsSql &= " abm_Module,"
                        fsSql &= " abm_PreviewTime,"
                        fsSql &= " abm_DialTime,"
                        fsSql &= " abm_LeadAttempts,"
                        fsSql &= " abm_Parameter1,"
                        fsSql &= " abm_ClientId,"
                        fsSql &= " abm_ClientName,"
                        fsSql &= " abm_MobileNo,"
                        fsSql &= " abm_DebitAmount,"
                        fsSql &= " abm_BranchID,"
                        fsSql &= " abm_BranchName,"
                        fsSql &= " abm_Count,"
                        fsSql &= " abm_Uniq,"
                        fsSql &= " abm_FollDate,"
                        fsSql &= " abm_Source,"
                        fsSql &= " abm_MailID,"
                        fsSql &= " abm_ClusterID,abm_Dispostion1"
                        fsSql &= " abm_empcode"
                        fsSql &= " ) values ( "
                        fsSql &= " " & lnTranFileGID & ","
                        fsSql &= " " & lsabm_StartTime & ","
                        fsSql &= " " & lsabm_EndTime & ","
                        fsSql &= " '" & lsabm_Agent & "',"
                        fsSql &= "  '" & lsabm_CLI & "',"
                        fsSql &= "  '" & lsabm_Type & "',"
                        fsSql &= "  '" & lsabm_Disposition & "',"
                        fsSql &= "  '" & lsabm_AlternatePhone & "',"
                        fsSql &= " '" & lsabm_Remarks & "',"
                        fsSql &= "  '" & lsabm_VoiceFile & "',"
                        fsSql &= "  " & lsabm_NextDialTime & ","
                        fsSql &= "  '" & lsabm_TrunkNumber & "',"
                        fsSql &= "  '" & lsabm_Module & "',"
                        fsSql &= " '" & lsabm_PreviewTime & "',"
                        fsSql &= "  '" & lsabm_DialTime & "',"
                        fsSql &= "  '" & lsabm_LeadAttempts & "',"
                        fsSql &= "  '" & lsabm_Parameter1 & "',"
                        fsSql &= "  '" & lsabm_ClientId & "',"
                        fsSql &= " '" & lsabm_ClientName & "',"
                        fsSql &= "  '" & lsabm_MobileNo & "',"
                        fsSql &= "  '" & lsabm_DebitAmount & "',"
                        fsSql &= "  '" & lsabm_BranchID & "',"
                        fsSql &= "  '" & lsabm_BranchName & "',"
                        fsSql &= " '" & lsabm_Count & "',"
                        fsSql &= "  '" & lsabm_Uniq & "',"
                        fsSql &= "  " & lsabm_FollDate & ","
                        fsSql &= "  '" & lsabm_Source & "',"
                        fsSql &= "  '" & lsabm_MailID & "',"
                        fsSql &= "  '" & lsabm_ClusterID & "','" & lsabm_Disposition1 & "','" & gUserName & "')"

                        lnErrCount += 1

                        lnResult = gfInsertQry(fsSql, gOdbcConn)
                        lsStatus = False
                    End If

                End With

                lsErrDescription = ""

                lnTotalRecords += 1

                frmMain.lblStatus.Text = " Imported Records Count:" & lnTotalRecords
                Application.DoEvents()
            Next
        End With

        Me.Enabled = True

        If lnErrCount > 0 Then

            fsSql = ""
            fsSql = "delete from abm_trn_tbranch where  branchfile_gid=" & lnTranFileGID & ""
            fnResult = gfInsertQry(fsSql, gOdbcConn)

            fsSql = ""
            fsSql = "delete from abm_trn_tbranchfile where  branchfile_gid=" & lnTranFileGID & ""
            fnResult = gfInsertQry(fsSql, gOdbcConn)

            MsgBox("There are error in the file,pls check the Error Report " & Chr(13) & _
                              "Total Records: " & lnTotalRecords & Chr(13) & _
                              "Invalid Records : " & lnErrCount, MsgBoxStyle.Information, "Import Error...")
            fsSql = ""
            fsSql = " select "
            fsSql &= " branchfile_gid,"
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
            fsSql &= "abm_ClusterID as ClusterID,abm_Dispostion1 as Dispostion1"
            fsSql &= "abm_empcode as usercode"
            fsSql &= " from  abm_trn_terrbranch a"

            fsSql &= " where a.branchfile_gid = " & lnTranFileGID & " "
            fsSql &= " and a.delete_flag ='N' "

            frm = New frmQuickView(gOdbcConn, fsSql)
            frm.ShowDialog()

        Else


            MsgBox(" Imported Successfully ! " & Chr(13) & _
                               "Total Records: " & lnTotalRecords & Chr(13) & _
                               "Inserted Records : " & InsCount & Chr(13) & _
                               "Invalid Records : " & lnErrCount, MsgBoxStyle.Information, gsProjectName)

            fsSql = ""
            fsSql = " insert into abm_trn_tbranchgroup(branchfile_gid, branch_id, branch_name, mail_id, cluster_id)  "
            fsSql &= " select branchfile_gid,abm_BranchID,abm_BranchName,abm_MailID,abm_ClusterID from abm_trn_tbranch"
            fsSql &= " where branchfile_gid= " & lnTranFileGID & ""
            fsSql &= " and delete_flag='N'"
            fsSql &= " and sendmail_flag='N' and abm_Dispostion1 ='Okay' group by abm_BranchID "

            lnResult = gfInsertQry(fsSql, gOdbcConn)

            fsSql = ""
            fsSql &= " select "
            fsSql &= " branchfile_gid,"
            fsSql &= " date_format(a.abm_StartTime,'%d-%m-%Y') as 'StartTime',"
            fsSql &= " date_format(a.abm_EndTime,'%d-%m-%Y') as 'EndTime',"
            fsSql &= "abm_Agent as Agent,"
            fsSql &= "abm_CLI as CLI,"
            fsSql &= "abm_Type as Type,"
            fsSql &= "abm_Disposition as Disposition,"
            fsSql &= "abm_AlternatePhone as AlternatePhone,"
            fsSql &= "abm_Remarks as Remarks,"
            fsSql &= "abm_VoiceFile as VoiceFile,"
            fsSql &= "abm_NextDialTime as NextDialTime,"
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
            fsSql &= "abm_FollDate as FollDate,"
            fsSql &= "abm_Source as Source,"
            fsSql &= "abm_MailID as MailID,"
            fsSql &= "abm_ClusterID as ClusterID,abm_Dispostion1 as Dispostion1"

            fsSql &= " from  abm_trn_tbranch a"

            fsSql &= " where a.branchfile_gid = " & lnTranFileGID & " "
            fsSql &= " and a.delete_flag ='N' "

            frm = New frmQuickView(gOdbcConn, fsSql)
            frm.ShowDialog()

        End If
        frmMain.lblStatus.Text = gsProjectName

        Panel1.Enabled = True
        Me.Cursor = Cursors.Default
        Application.DoEvents()
        Exit Sub

ErrorHandler:
        Select Case Err.Description
            Case "No value given for one or more required parameters."
                MessageBox.Show("Template mismatch. ", gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Case "External table is not in the expected format."
                MessageBox.Show("Import file should be Excel Format", gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
        End Select
        Call InsertErrorLog(Me.Name, MethodBase.GetCurrentMethod().Name, Err.Description)
    End Sub

    Sub lp_Clear()
        txtFileName.Text = ""
        cboSheetName.SelectedIndex = -1
        cboSheetName.SelectedIndex = -1
        cboSheetName.Text = ""
    End Sub

    Private Function WriteErrLog(ByVal dtExcel As DataTable) As Boolean

        Dim lnRow As Integer
        Dim lbHasError As Boolean = False
        Dim lsErrorLogPath As String = Application.StartupPath & "\" & "ErrorLog.txt"
        mobjWriter = New StreamWriter(lsErrorLogPath)
        With dtExcel
            For lnRow = 0 To .Rows.Count - 1
                With .Rows(lnRow)

                    If .Item("Branch ID").ToString.Trim = "" Then
                        WriteLog(lnRow + 1 & " - Branch Id should not be Blank")
                        lbHasError = True
                    End If


                End With
            Next
        End With
        mobjWriter.Close()
        WriteErrLog = Not lbHasError
    End Function
    Private Sub WriteLog(ByVal lsText As String)
        mobjWriter.WriteLine(lsText)
    End Sub



    Private Sub NewMsg()

        Dim obj As New SmtpClient

        Dim mailmsg As New MailMessage

        Dim ma As New MailAddress("vijayavel@gnsaindia.com", "Vijayavel")

        Dim lsMsg As String



        obj.Host = "61.16.172.2"

        obj.Port = 1415

        mailmsg.From = ma

        mailmsg.To.Add("sysadmin@gnsaindia.com")

        mailmsg.Subject = "Subject"



        lsMsg = "  <html><body><p align=center style='text-align:center'><b>Subject</b></p>" _
                    & " <hr><span style='color:blue'><b>Form Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp:</span>FormName</b><br>" _
                    & " <span style='color:blue'><b>Button Name&nbsp;&nbsp;&nbsp:</span>Button Name</b><br>" _
                    & " <br><span style='color:blue'><b>Error Desc&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp :</b></span>Error Message<br><br>" _
                    & " <span style='color:brown;font-size=26;font-family:""Wingdings""'> " _
                    & " <b>?</b></span><span style='color:brown;font-family:""Times New Roman""'> " _
                    & " <b>Thanks & Regards, <br> " _
                    & " &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbspVijayavel<br>" _
                    & " &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbspImpact</b></span>" _
                    & " <br> </body> </html>"

        mailmsg.Body = lsMsg


        Try

            obj.Send(mailmsg)

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub
End Class