Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports FlexiLibrary.iRoutines
Public Class frmUrlImport
    Dim objXls As New Excel.Application
    Dim fsSql As String
    Dim FileId As Integer
    Dim lnValidRecords As Integer = 0

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim myStream As Stream = Nothing
        Dim OpenFileDialog1 As New OpenFileDialog

        Try
            OpenFileDialog1.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*"
            OpenFileDialog1.FilterIndex = 2
            OpenFileDialog1.RestoreDirectory = True
            OpenFileDialog1.FileName.ToString()

            If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                myStream = OpenFileDialog1.OpenFile()
                If Not myStream Is Nothing Then
                    txtFileName.Text = OpenFileDialog1.FileName.ToString()
                End If
            End If

            Call LoadSheet()

        Catch Ex As Exception
            MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
        End Try
    End Sub
    Private Sub LoadSheet()

        Dim objBook As Excel.Workbook

        If Trim(txtFileName.Text) <> "" Then
            If File.Exists(txtFileName.Text) Then
                objBook = objXls.Workbooks.Open(txtFileName.Text)
                cboSheetName.Items.Clear()
                For i As Integer = 1 To objXls.ActiveWorkbook.Worksheets.Count
                    cboSheetName.Items.Add(objXls.ActiveWorkbook.Worksheets(i).Name)
                Next i
                objXls.Workbooks.Close()
                objXls.Quit()
            End If
        End If
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Dim lsSql As String
        Dim count As Integer = 0
        Dim lsArr() As String
        Dim lsResult As String

        Try
            If txtFileName.Text.Trim = "" Then
                MessageBox.Show("Please Select the File Name to Import", gsProjectName, MessageBoxButtons.OK)
                Exit Sub
            End If

            If cboSheetName.Text.Trim = "" Then
                MessageBox.Show("Please Select the Sheet to Import", gsProjectName, MessageBoxButtons.OK)
                Exit Sub
            End If
            Dim dsExcel As New DataSet
            Dim lnInvalidRecords As Integer = 0
            Dim lsUrlGid As Integer = 0
            Dim lnAttemptCount As Integer = 0
            Dim lnAmount As Double = 0
            Dim lsMessage As String = ""
            Dim lobjOledbConnection As New OleDbConnection
            Dim lsErrorLogPath As String = Application.StartupPath & "\" & "ErrorLog.txt"

            Dim lsConString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" & txtFileName.Text & ";" + "Extended Properties=Excel 8.0;"
            Dim daExcel As New OleDbDataAdapter

            lsArr = Split(txtFileName.Text, "\")

            'lsSql = "select content_gid from abm_trn_tcontent where content_training_gid"
            'FileId = Val(gObjConnection.GetExecuteScalar(lsSql))


            lsSql = "SELECT * FROM [" & cboSheetName.Text & "$]"
            daExcel = New OleDb.OleDbDataAdapter(lsSql, lsConString)
            daExcel.Fill(dsExcel, "dtt")
            lobjOledbConnection.Close()

            count = dsExcel.Tables("dtt").Rows.Count

            For i As Integer = 0 To count - 1
                Me.Text = "Importing..... " & count & " of " & i + 1
                Me.Cursor = Cursors.WaitCursor
                Application.DoEvents()

                lsSql = "SELECT url_gid FROM hr_mst_turl WHERE url_activity_code='" & dsExcel.Tables("dtt").Rows(i).Item("ACTIVITY CODE") & "' "
                lsUrlGid = Val(gfExecuteScalar(lsSql, gOdbcConn))
                If lsUrlGid = 0 Then
                    lsSql = ""
                    lsSql &= " INSERT INTO hr_mst_turl(url_activity_code,url_link)"
                    lsSql &= " VALUES("
                    lsSql &= "  '" & dsExcel.Tables("dtt").Rows(i).Item("TRAINING").ToString.Trim & "',"
                    lsSql &= "  '" & dsExcel.Tables("dtt").Rows(i).Item("CODE").ToString.Trim & "',"
                    lsSql &= "  '" & Replace(dsExcel.Tables("dtt").Rows(i).Item("URL").ToString, "\", "\\") & "')"

                    lsResult = gfInsertQry(lsSql, gOdbcConn)
                Else
                    lsSql = ""
                    lsSql &= " UPDATE hr_mst_turl SET "
                    lsSql &= " url_link='" & Replace(dsExcel.Tables("dtt").Rows(i).Item("URL"), "\", "\\").ToString.Trim & "'"
                    lsSql &= " WHERE url_gid=" & lsUrlGid

                    lsResult = gfInsertQry(lsSql, gOdbcConn)
                End If

                If lsResult = "" Then
                    lnValidRecords = lnValidRecords + 1
                Else
                    lnInvalidRecords = lnInvalidRecords + 1
                End If
            Next
            Me.Text = "URL Import"
            Me.Cursor = Cursors.Default
            If lnValidRecords > 0 Then
                MessageBox.Show("Imported Successfully" & vbCrLf & "Valid Records: " & lnValidRecords & vbCrLf & "Invalid Records: " & lnInvalidRecords, gsProjectName, MessageBoxButtons.OK)
            Else
                MessageBox.Show("Not Imported... ", gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTemplate.Click
        Dim lsHeaders As String
        lsHeaders = "TRAINING,CODE,URL"
        Call CreateTemplate(lsHeaders.Split(","), "IMPORT")
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub CreateTemplate(ByVal lsHeaders As String(), ByVal lsTemplateName As String)
        Dim xlApp As New Excel.Application
        Dim xlBook As Excel.Workbook
        Dim xlSheet As New Excel.Worksheet
        Dim iCol As Integer

        Const cFirstRow = 1

        xlBook = xlApp.Workbooks.Add
        xlSheet = xlApp.ActiveSheet
        xlSheet.Name = "Sheet1"
        xlApp.Visible = True
        With xlSheet
            For iCol = 1 To UBound(lsHeaders) + 1
                .Cells(cFirstRow, iCol) = lsHeaders(iCol - 1)
                .Cells(cFirstRow, iCol).Font.Bold = True
                .Columns(iCol).AutoFit()
            Next
            .Name = lsTemplateName
        End With
        xlBook.Sheets("Sheet2").Delete()
        xlBook.Sheets("Sheet3").Delete()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtFileName.Text = ""
        cboSheetName.SelectedIndex = -1
    End Sub
End Class