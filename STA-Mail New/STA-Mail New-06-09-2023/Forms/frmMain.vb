Imports System.Windows.Forms

Public Class frmMain

    Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Integer, _
        ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, _
        ByVal nShowCmd As Integer) As Integer
    Const SW_SHOWNORMAL As Short = 1

    Dim fssql As String = ""
    Dim path As String = ""

    Dim DsBusiness As DataSet
    Dim lsPath As String = ""
    Dim lsSheetName As String = ""

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer = 0

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim loginflag As Boolean = True

        Me.Visible = False


        If Not FileIO.FileSystem.FileExists(Application.StartupPath & "\STAConfig.ini") Then
            MessageBox.Show("Configuration File is Missing", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmServerConfiguration.ShowDialog()
            End
        Else
            Call Main()

            Me.WindowState = FormWindowState.Maximized
        End If

        'If loginflag = False Then

        '    If Not FileIO.FileSystem.FileExists(Application.StartupPath & "\AppConfig.ini") Then
        '        MessageBox.Show("Configuration File is Missing", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Exit Sub
        '    Else

        '        Call Main() 'local only
        '        gObjSecurity.SetUserRights(Me.MenuStrip.Items)
        '    End If

        'Else
        '    ' ServerDetails = "Driver={Mysql odbc 3.51 Driver};Server=10.186.44.25;DataBase=exprpt_new;uid=tech;pwd=asng"
        '    'ServerDetails = "Driver={Mysql odbc 3.51 Driver};Server=192.168.250.16;DataBase=abml;uid=root;pwd=gnsa"

        '    ServerDetails = "Driver={Mysql odbc 3.51 Driver};Server=localhost;DataBase=stamail;uid=root;pwd=root"

        '    Call ConOpenOdbc(ServerDetails)
        '    gUserName = "MAIL"
        'End If

        Call PatchProcess()
        Call CompValidation()

        Me.Visible = True
        Me.WindowState = FormWindowState.Maximized
        lblStatus.Text = ""
        lblUserName.Text = "User : " & gObjSecurity.LoginUserName
        lblDate.Text = "Date : " & Format(Now, "dd-MMM-yyyy")

    End Sub

    Private Sub PatchProcess()
        Dim lsSql As String
        Dim lsTxt As String
        Dim ds As New DataSet
        Dim lbTbFlag As Boolean = True
        Dim i As Integer = 0
        Dim lnResult As Long
        Dim lsDbName As String = ""

        lsTxt = gOdbcConn.ConnectionString

        lsTxt = Mid(lsTxt, InStr(lsTxt, "DataBase"))
        lsTxt = Mid(lsTxt, 1, InStr(lsTxt, ";") - 1)
        lsDbName = lsTxt.Split("=")(1)

        lsTxt = gfExecuteScalar("show fields from mail_trn_tmail where Field = 'tds_per'", gOdbcConn)

        If lsTxt = "" Then
            lsSql = "alter table mail_trn_tmail add tds_per varchar(128) default null after dividend_amount"
            lnResult = gfInsertQry(lsSql, gOdbcConn)
        End If

        lsTxt = gfExecuteScalar("show fields from mail_trn_tmail where Field = 'gross_amount'", gOdbcConn)

        If lsTxt = "" Then
            lsSql = "alter table mail_trn_tmail add gross_amount varchar(128) default null after tds_per"
            lnResult = gfInsertQry(lsSql, gOdbcConn)
        End If
    End Sub

    Private Sub CompValidation()
        Dim lnResult As Long = 0
        Dim lsSql As String = ""
        Dim lsTxt As String = ""
        Dim ds As New DataSet

        lsSql = ""
        lsSql &= " select count(*) from mail_mst_tmail "
        lsSql &= " where delete_flag = 'N' "

        lnResult = Val(gfExecuteScalar(lsSql, gOdbcConn))

        Select Case lnResult
            Case 0
                MsgBox("Please configure mail details in mail_mst_tmail table !", MsgBoxStyle.Information, gsProjectName)
                End
            Case 1
                lsSql = ""
                lsSql &= " select * from mail_mst_tmail "
                lsSql &= " where delete_flag = 'N' "

                Call gpDataSet(lsSql, "comp", gOdbcConn, ds)

                With ds.Tables("comp")
                    If .Rows.Count = 1 Then
                        gnCompId = .Rows(0).Item("mail_id")
                        gsCompName = .Rows(0).Item("comp_name").ToString

                        Me.Text = "Bulk Mailing System Version " & Application.ProductVersion.Split(".")(0) & "." & Application.ProductVersion.Split(".")(1) & " (" & gsCompName & ")"

                        ' find smtp ip
                        lsSql = ""
                        lsSql &= " select config_value from mail_mst_tconfig "
                        lsSql &= " where config_field = 'SMTP IP' "

                        lsTxt = gfExecuteScalar(lsSql, gOdbcConn)

                        If lsTxt <> "" Then gsSmtpIp = lsTxt

                        ' find smtp port
                        lsSql = ""
                        lsSql &= " select config_value from mail_mst_tconfig "
                        lsSql &= " where config_field = 'SMTP PORT' "

                        lsTxt = gfExecuteScalar(lsSql, gOdbcConn)

                        If lsTxt <> "" Then gsSmtpPort = lsTxt

                        ' find smtp user
                        lsSql = ""
                        lsSql &= " select config_value from mail_mst_tconfig "
                        lsSql &= " where config_field = 'SMTP USER' "

                        lsTxt = gfExecuteScalar(lsSql, gOdbcConn)

                        If lsTxt <> "" Then gsSmtpUser = lsTxt

                        ' find smtp user password
                        lsSql = ""
                        lsSql &= " select config_value from mail_mst_tconfig "
                        lsSql &= " where config_field = 'SMTP PWD' "

                        lsTxt = gfExecuteScalar(lsSql, gOdbcConn)

                        If lsTxt <> "" Then gsSmtpPwd = lsTxt
                    Else
                        MsgBox("Please configure mail details in mail_mst_tmail table !", MsgBoxStyle.Information, gsProjectName)
                        End
                    End If

                    .Rows.Clear()
                End With
            Case Else
                MsgBox("Only one company information is required ! " & lnResult.ToString & " company information available in mail_mst_tmail table !", MsgBoxStyle.Information, gsPreMonth)
                End
        End Select
    End Sub

    Private Sub MnuCCBSTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            path = GetTemplate("CCBS.xls")
            Call ShellExecute(Handle.ToInt32, "open", path, "", "0", SW_SHOWNORMAL)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub MnumstMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnumstMail.Click
        Dim objfrm As New frmUrlImport
        objfrm.ShowDialog()
    End Sub

    Private Sub mnuAbmImport1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbmImport1.Click
        Dim objfrm As New frmImport
        objfrm.ShowDialog()
    End Sub

    Private Sub MnuDeleteabm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDeleteabm.Click
        Dim objfrm As New frmImportDelete
        objfrm.ShowDialog()
    End Sub

    Private Sub MnuReportP2P_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objfrm As New frmAbmReport
        objfrm.ShowDialog()
    End Sub

    Private Sub MnuSendMailBranchwise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSendMailBranchwise.Click
        Dim objfrm As New frmSendMail
        objfrm.ShowDialog()
    End Sub

    Private Sub MnuReportErrorP2P_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objfrm As New frmErrABMReport
        objfrm.ShowDialog()
    End Sub

    'Private Sub MSMQToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    'Dim objfrm As New frmMSMQ
    '    'objfrm.ShowDialog()
    'End Sub

    Private Sub MnuReportImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuReportImport.Click
        Dim obj As New frmImportReport
        obj.MdiParent = Me
        obj.Show()
    End Sub
End Class
