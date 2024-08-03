Imports System.IO
Imports Microsoft.VisualBasic
Imports System.Web
'Imports System.Net.Mail.Attachment
'Imports System.Net.Mail
'Imports System.Web.Mail
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mail.Attachment
Imports Microsoft.Office.Interop
Imports System.Threading
'Imports ExcelExport

Public Class frmSendMail

#Region "Form Level Declarations"
    Dim fsSql As String = String.Empty
    Dim lobjDataSet As New DataSet
    Dim lsPath As String = ""
    Dim lsPath1 As String = ""


#End Region

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Call LoadPickUp()
    End Sub

    Private Sub LoadPickUp()
        Dim lnFileId As Long
        '
        With cboFileName
            If .Text <> "" And .SelectedIndex <> -1 Then
                lnFileId = Val(.SelectedValue)
            Else
                MsgBox("Please select the file !", MsgBoxStyle.Information, gsProjectName)
                Exit Sub
            End If
        End With

        fsSql = ""
        fsSql &= " SELECT"
        fsSql &= " mail_gid,mail_from,mail_to,folio_no,folio_name"

        fsSql &= " From mail_trn_tmail "

        fsSql &= " WHERE true "
        fsSql &= " and comp_gid = " & gnCompId & " "
        fsSql &= " and mail_file_gid = " & lnFileId & " "
        fsSql &= " and mail_sendflag='N' and mail_from is not null and mail_from <>''"
        fsSql &= " and mail_to is not null and mail_to <>''"

        dgvList.Columns.Clear()
        dgvList.DataSource = Nothing
        lobjDataSet = gfDataSet(fsSql, "tblReports", gOdbcConn)

        dgvList.Columns.Clear()
        dgvList.DataSource = lobjDataSet.Tables("tblReports")

        Dim objCheck As New DataGridViewCheckBoxColumn
        objCheck.ReadOnly = False
        objCheck.HeaderText = "Select"
        dgvList.Columns.Insert(5, objCheck)
        dgvList.Columns(0).Visible = False

        dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        'dgvList.AutoResizeColumns()

        'lobjDataSet = gfDataSet(fsSql, "tblReports", gOdbcConn)

        lblrecords.Text = "Total Records : " & dgvList.RowCount

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If MsgBox("Are you sure you want to Close?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gsTitle) = MsgBoxResult.Yes Then
        '    Me.Close()
        'End If
    End Sub


    Private Sub frmCourierProcess_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call LoadPickUp()
    End Sub

    Private Sub chkSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSelect.Click
        For i As Integer = 0 To dgvList.RowCount - 1
            dgvList.Item(5, i).Value = chkSelect.Checked
        Next
    End Sub

    Private Function UploadMail(ByVal MailGid As String)
        Dim ds As New DataSet
        Dim lnCount As Integer = 0
        Dim llMailGid As Long = 0
        Dim lsMailContent As String = ""
        Dim lsMailTo As String = ""
        Dim fnResult As Integer = 0
        Dim lsMailSubject As String = ""
        'Dim objMail As New MailMessage
        Dim lsresult As Integer
        Dim lsUrl As String = ""

        Dim objmail As New SmtpClient
        Dim mailmsg As New MailMessage

        Dim lsTraining As String = ""
        Dim dr As Odbc.OdbcDataReader
        Dim lsImagePath As String = My.Application.Info.DirectoryPath

        Try

            fsSql = ""
            fsSql &= " select content,subject from mail_mst_tmail"
            fsSql &= " where "
            fsSql &= "delete_flag ='N' "

            Call gpDataSet(fsSql, "tblRecords", gOdbcConn, ds)

            For lnCount = 0 To ds.Tables("tblRecords").Rows.Count - 1
                lsMailContent = ds.Tables("tblRecords").Rows(lnCount).Item("content").ToString
                lsMailSubject = ds.Tables("tblRecords").Rows(lnCount).Item("subject").ToString
            Next

            ds.Tables("tblRecords").Rows.Clear()

            ' records
            fsSql = ""
            fsSql &= " select * from mail_trn_tmail "
            fsSql &= " where mail_gid = " & MailGid & " "

            Call gpDataSet(fsSql, "rec", gOdbcConn, ds)

            With ds.Tables("rec")

                If .Rows.Count > 0 Then
                    Dim frmmailid As New MailAddress(.Rows(0).Item("mail_from").ToString)
                    mailmsg.From = frmmailid

                    mailmsg.To.Add(.Rows(0).Item("mail_to").ToString)
                    If txtAddCC.Text <> "" Then mailmsg.CC.Add(txtAddCC.Text)
                    'mailmsg.Bcc.Add("giri@flexicodeindia.com")
                    'mailmsg.Bcc.Add("sta@gnsaindia.com")
                    'mailmsg.To.Add("maruthibalan@gnsaindia.com")
                    'lsMailContent = Replace(lsMailContent, "#Name#", FromName)
                    lsMailContent = Replace(lsMailContent, "#FolioNo#", .Rows(0).Item("folio_no").ToString)
                    lsMailContent = Replace(lsMailContent, "#FolioName#", .Rows(0).Item("folio_name").ToString)
                    lsMailContent = Replace(lsMailContent, "#MailID#", .Rows(0).Item("mail_to").ToString)
                    lsMailContent = Replace(lsMailContent, "#ShareCount#", .Rows(0).Item("share_count").ToString)
                    lsMailContent = Replace(lsMailContent, "#DividendAmount#", .Rows(0).Item("dividend_amount").ToString)
                    lsMailContent = Replace(lsMailContent, "#TdsPer#", .Rows(0).Item("tds_per").ToString)
                    lsMailContent = Replace(lsMailContent, "#GrossAmount#", .Rows(0).Item("gross_amount").ToString)
                    lsMailContent = Replace(lsMailContent, "#BankAccNo#", .Rows(0).Item("bank_acc_no").ToString)
                    lsMailContent = Replace(lsMailContent, "#BankName#", .Rows(0).Item("bank_name").ToString)
                    lsMailContent = Replace(lsMailContent, "#BankBranch#", .Rows(0).Item("bank_branch").ToString)
                    lsMailContent = Replace(lsMailContent, "#BankPincode#", .Rows(0).Item("bank_pin").ToString)
                    lsMailContent = Replace(lsMailContent, "#RemittanceDate#", .Rows(0).Item("remittance_date").ToString)
                    lsMailContent = Replace(lsMailContent, "#RefColumn1#", .Rows(0).Item("ref_col1").ToString)
                    lsMailContent = Replace(lsMailContent, "#RefColumn2#", .Rows(0).Item("ref_col2").ToString)
                    lsMailContent = Replace(lsMailContent, "#RefColumn3#", .Rows(0).Item("ref_col3").ToString)
                    lsMailContent = Replace(lsMailContent, "#RefColumn4#", .Rows(0).Item("ref_col3").ToString)
                    'Dim logo As New LinkedResource("C:/STA/Template_files/image001.jpg")
                    'Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(lsMailContent, Nothing, "text/html")
                    'logo.ContentId = "#IMAGEPATH#"

                    'add the LinkedResource to the appropriate view

                    'htmlView.LinkedResources.Add(logo)

                    'add the views

                    'mailmsg.AlternateViews.Add(plainView)

                    ' mailmsg.AlternateViews.Add(htmlView)

                    mailmsg.Body = lsMailContent

                    mailmsg.IsBodyHtml = True
                    mailmsg.Attachments.Clear()
                    mailmsg.Subject = lsMailSubject


                    '------------------------------------------------------------
                    For Counter As Integer = 0 To lstAttachment.Items.Count - 1
                        Dim b As New Net.Mail.Attachment(lstAttachment.Items(Counter).ToString)
                        mailmsg.Attachments.Add(b)
                    Next
                    '------------------------------------------------------------

                    'send the message
                    ''Dim smtp As New SmtpClient("61.16.172.21""14.141.18.219") 'specify the mail server address
                    ''smtp.Port = "25"
                    ''smtp.Send(mailmsg)

                    Dim smtp As SmtpClient

                    If gsSmtpPort <> "" Then
                        smtp = New SmtpClient(gsSmtpIp, gsSmtpPort)

                        If gsSmtpUser <> "" And gsSmtpPwd <> "" Then
                            smtp.Credentials = New System.Net.NetworkCredential(gsSmtpUser, gsSmtpPwd)
                        End If
                    Else
                        smtp = New SmtpClient(gsSmtpIp)
                    End If

                    smtp.EnableSsl = True

                    Thread.Sleep(6000)
                    smtp.Send(mailmsg)

                    lsresult = 1
                Else
                    lsresult = 0
                End If

                .Rows.Clear()
            End With

            Return lsresult
        Catch ex As Exception
            'MsgBox(ex.Message)
            ' MsgBox(branchId & ":- Not Send ! ")
            lsresult = 0
            Return lsresult
        End Try

    End Function

    ''Private Function UploadMail(ByVal MailGid As String, ByVal FromMail As String, ByVal FromName As String, ByVal ToMail As String, ByVal ToName As String)
    'Dim liResult As Integer
    'Dim ds As New DataSet
    'Dim lnCount As Integer = 0
    'Dim llMailGid As Long = 0
    'Dim lsMailContent As String = ""
    'Dim lsMailTo As String = ""
    'Dim fnResult As Integer = 0
    'Dim lsMailSubject As String = ""
    ''Dim objMail As New MailMessage
    'Dim lsresult As Integer
    'Dim lsUrl As String = ""

    'Dim objmail As New SmtpClient
    'Dim mailmsg As New MailMessage

    'Dim lsTraining As String = ""
    'Dim dr As Odbc.OdbcDataReader
    'Dim lsImagePath As String = My.Application.Info.DirectoryPath

    'Dim ObjOutLook As New Outlook.Application
    'Dim objnamespace As Outlook.NameSpace
    'Dim OBJinbox As Outlook.MAPIFolder
    'Dim ObjItem As Outlook.Items
    'Dim Omsg As Outlook.MailItem

    '    Try
    '        If ObjOutLook Is Nothing Then
    '            ObjOutLook = CreateObject("Outlook.application")
    '            objnamespace = ObjOutLook.GetNamespace("MAPI")
    '            OBJinbox = objnamespace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox)
    '            ObjItem = OBJinbox.Items
    '        Else
    '            objnamespace = ObjOutLook.GetNamespace("MAPI")
    '            OBJinbox = objnamespace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox)
    '            ObjItem = OBJinbox.Items
    '        End If

    '        Omsg = ObjItem.Add

    '        fsSql = ""
    '        fsSql &= " select content,subject from mail_mst_tmail"
    '        fsSql &= " where "
    '        fsSql &= "delete_flag ='N' "

    '        ds = gfDataSet(fsSql, "tblRecords", gOdbcConn)
    '        For lnCount = 0 To ds.Tables("tblRecords").Rows.Count - 1

    '            lsMailContent = ds.Tables("tblRecords").Rows(lnCount).Item("content").ToString
    '            lsMailSubject = ds.Tables("tblRecords").Rows(lnCount).Item("subject").ToString

    '        Next

    ''objMail.From = lsMailCC1


    '        lsMailContent = Replace(lsMailContent, "#FROMNAME#", FromName)
    '        lsMailContent = Replace(lsMailContent, "#TONAME#", ToName)
    ''lsMailContent = Replace(lsMailContent, "#IMAGEPATH#", lsSource)

    'Dim FromMailID As New MailAddress(FromMail)
    '        mailmsg.From = FromMailID
    '        mailmsg.To.Add(ToMail)
    ''mailmsg.Bcc.Add("rajesh.m@gnsaindia.com")

    'Dim plainView As AlternateView = AlternateView.CreateAlternateViewFromString("This is my plain text content, viewable by those clients that don't support html", Nothing, "text/plain")
    'Dim logo As New LinkedResource(lsImagePath & "\image001.jpg")
    'Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(lsMailContent, Nothing, "text/html")
    '        logo.ContentId = "#IMAGEPATH#"

    ''add the LinkedResource to the appropriate view

    '        htmlView.LinkedResources.Add(logo)

    ''add the views

    '        mailmsg.AlternateViews.Add(plainView)
    '        mailmsg.AlternateViews.Add(htmlView)
    '        mailmsg.IsBodyHtml = True
    '        mailmsg.Subject = lsMailSubject

    '        With Omsg
    '            .To = ToMail
    '            .Subject = lsMailSubject
    '            .Body = lsMailContent
    '            .BodyFormat = Outlook.OlBodyFormat.olFormatHTML
    '            .HTMLBody = lsMailContent
    '            Application.DoEvents()
    '            .Send()
    '        End With
    '        Omsg = Nothing
    '        liResult = 1
    '        Return liResult
    '    Catch ex As Exception
    '        liResult = 0
    '        Return liResult
    '    End Try
    'End Function

    Private Sub btnsendmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsendmail.Click

        Dim m As Integer
        Dim fnResult, lnresult As Integer
        Dim lsFrom As String
        Dim lsFolioName As String
        Dim lsTo As String
        Dim lsFolioNo As String
        Dim lsMailGid As String
        Dim liCount As Integer = 0

        btnsendmail.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        For m = 0 To dgvList.RowCount - 1
            If dgvList.Rows(m).Cells(5).Value = True Then
                lsMailGid = dgvList.Rows(m).Cells("mail_gid").Value.ToString
                lsFrom = dgvList.Rows(m).Cells("mail_from").Value.ToString
                lsTo = dgvList.Rows(m).Cells("mail_to").Value.ToString
                lsFolioName = dgvList.Rows(m).Cells("folio_name").Value.ToString
                lsFolioNo = dgvList.Rows(m).Cells("folio_no").Value.ToString

                'send mail
                lnresult = UploadMail(lsMailGid)

                If lnresult = 1 Then

                    fsSql = ""
                    fsSql = "update mail_trn_tmail set mail_sendflag='Y' where mail_gid=" & lsMailGid & " "
                    fnResult = gfInsertQry(fsSql, gOdbcConn)
                    liCount += 1
                End If

                lsTo = ""
            End If

        Next

        Call LoadPickUp()

        MsgBox(liCount & " Mails Send Successfully.")

        btnsendmail.Enabled = True
        Me.Cursor = Cursors.Default
        Application.DoEvents()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim Counter As Integer

        ofd.CheckFileExists = True
        ofd.Title = "Select the file(s) to attach"
        ofd.ShowDialog()

        For Counter = 0 To UBound(ofd.FileNames)
            lstAttachment.Items.Add(ofd.FileNames(Counter))
        Next

    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If lstAttachment.SelectedIndex > -1 Then
            lstAttachment.Items.RemoveAt(lstAttachment.SelectedIndex)
        End If
    End Sub

    Private Sub cboFileName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFileName.GotFocus
        fsSql = ""
        fsSql &= " select file_name,file_gid from mail_mst_tfile "
        fsSql &= " where comp_gid = " & gnCompId & " "
        fsSql &= " and file_importedon >= '" & Format(dtpDate.Value, "yyyy-MM-dd") & "' "
        fsSql &= " and file_importedon < '" & Format(DateAdd(DateInterval.Day, 1, dtpDate.Value), "yyyy-MM-dd") & "' "
        fsSql &= " and file_status ='A' order by file_gid"

        With cboFileName
            If .Text <> "" And .SelectedIndex <> -1 Then
                .Tag = .SelectedValue.ToString
            Else
                .Tag = ""
            End If

            gpBindCombo(fsSql, "file_name", "file_gid", cboFileName, gOdbcConn)

            If .Tag <> "" Then
                .SelectedValue = .Tag
            End If
        End With
    End Sub

    Private Sub cboFileName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFileName.SelectedIndexChanged

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure to delete ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.Yes Then
            Call DeleteMailId()
        End If
    End Sub

    Private Sub DeleteMailId()
        Dim m As Integer
        Dim fnResult, lnresult As Integer
        Dim lsMailGid As String
        Dim liCount As Integer = 0

        btnsendmail.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        For m = 0 To dgvList.RowCount - 1
            If dgvList.Rows(m).Cells(5).Value = True Then
                lsMailGid = dgvList.Rows(m).Cells("mail_gid").Value.ToString

                If lnresult = 1 Then
                    fsSql = ""
                    fsSql = "delete from mail_trn_tmail where mail_gid=" & lsMailGid & " and mail_sendflag='N' "
                    fnResult = gfInsertQry(fsSql, gOdbcConn)
                    liCount += 1
                End If
            End If
        Next

        Call LoadPickUp()

        MsgBox(liCount & " MailId(s) Deleted Successfully.")

        btnsendmail.Enabled = True
        Me.Cursor = Cursors.Default
        Application.DoEvents()
    End Sub
End Class