Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System
Imports FlexiLibrary.iRoutines

Public Class frmImport
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

    Public Sub FormatSheet(ByVal ExcelFileName As String, ByVal SheetName As String)
        Dim objApplication As New Excel.Application
        Dim objBooks As Excel.Workbooks
        Dim objWorkBook As Excel.Workbook
        Dim objWorkSheet As Excel.Worksheet
        Dim objRange As Excel.Range
        Dim a() As Short = {1, 2}
        Dim i As Integer

        Try
            If File.Exists(ExcelFileName) = False Then Exit Sub

            objBooks = objApplication.Workbooks
            objWorkBook = objBooks.Open(ExcelFileName, False, False)
            objWorkSheet = objWorkBook.Sheets(SheetName)

            objApplication.Visible = True

            For i = 1 To 256
                If objWorkSheet.Cells(1, i).Value <> "" Then
                    Select Case objWorkSheet.Cells(2, i).NumberFormat
                        Case "@", "0", "0.00"
                            objWorkSheet.Columns(i).cells.NumberFormat = "@"

                            objRange = objWorkSheet.Columns(i)
                            objRange.TextToColumns(objRange, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote, , , , , , , , a, , )
                        Case Else
                            If IsDate(objWorkSheet.Cells(2, i).ToString()) = False Then
                                objRange = objWorkSheet.Columns(i)
                                objRange.TextToColumns(objRange, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote, , , , , , , , a, , )
                            End If
                    End Select
                Else
                    Exit For
                End If
            Next i

            objWorkBook.Save()
            objWorkBook.Close()
            objBooks.Close()

            objApplication.Quit()

            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(objApplication)

            GC.Collect()
            GC.WaitForPendingFinalizers()

            Call KillAllExcel()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error...")
        End Try
    End Sub

    Private Sub KillAllExcel()
        Dim xlp() As Process = Process.GetProcessesByName("EXCEL")

        For Each proc As Process In xlp
            proc.Kill()
            If Process.GetProcessesByName("EXCEL").Length = 0 Then
                Exit For
            End If
        Next
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

                Call KillAllExcel()
            End If
        End If
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Dim lsSql As String
        Dim count As Integer = 0
        Dim lsArr() As String
        Dim lsResult As Integer = 0

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
            Dim lsFileGid As Integer = 0
            Dim lnAttemptCount As Integer = 0
            Dim lsMessage As String = ""
            Dim lobjOledbConnection As New OleDbConnection
            Dim lsErrorLogPath As String = Application.StartupPath & "\" & "ErrorLog.txt"

            Call FormatSheet(txtFileName.Text, cboSheetName.Text)

            Dim lsConString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" & txtFileName.Text & ";" + "Extended Properties=Excel 8.0;"
            Dim daExcel As New OleDbDataAdapter

            lsArr = Split(txtFileName.Text, "\")

            lsSql = ""
            lsSql &= " SELECT file_gid FROM mail_mst_tfile WHERE file_status = 'A' "
            lsSql &= " and file_name='" & lsArr(UBound(lsArr)) & "'"
            If gfExecuteScalar(lsSql, gOdbcConn) <> "" Then
                MessageBox.Show("Already File Imported", " ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            lsSql = ""
            lsSql &= "insert into mail_mst_tfile(comp_gid,file_name,file_importedby,file_importedon, file_status)"
            lsSql &= "values ("
            lsSql &= " '" & gnCompId & "',"
            lsSql &= " '" & lsArr(UBound(lsArr)) & "', "
            lsSql &= "'" & gObjSecurity.LoginUserCode & "' ,"
            lsSql &= " '" & Format(dtpValueDate.Value, "yyyy-MM-dd") & "','A') "
            gfInsertQry(lsSql, gOdbcConn)

            lsSql = ""
            lsSql &= "SELECT max(file_gid) FROM mail_mst_tfile WHERE file_status = 'A' "
            lsFileGid = Val(gfExecuteScalar(lsSql, gOdbcConn))


            lsSql = "SELECT * FROM [" & cboSheetName.Text & "$]"
            daExcel = New OleDb.OleDbDataAdapter(lsSql, lsConString)
            daExcel.Fill(dsExcel, "dtt")
            lobjOledbConnection.Close()

            count = dsExcel.Tables("dtt").Rows.Count

            For i As Integer = 0 To count - 1
                Me.Text = "Importing..... " & count & " of " & i + 1
                Me.Cursor = Cursors.WaitCursor
                Application.DoEvents()

                lsSql = ""
                lsSql &= " INSERT INTO mail_trn_tmail(comp_gid,mail_file_gid,mail_from,mail_to,folio_no,folio_name,"
                lsSql &= " share_count,dividend_amount,tds_per,gross_amount,bank_acc_no,bank_name,bank_branch,bank_pin,"
                lsSql &= " remittance_date,ref_col1,ref_col2,ref_col3,ref_col4) VALUES ("
                lsSql &= " '" & gnCompId & "',"
                lsSql &= " " & lsFileGid & ","
                lsSql &= "  '" & Mid(QuoteFilter(dsExcel.Tables("dtt").Rows(i).Item("FROM").ToString), 1, 128) & "',"
                lsSql &= "  '" & Mid(QuoteFilter(dsExcel.Tables("dtt").Rows(i).Item("TO").ToString), 1, 128) & "',"
                lsSql &= "  '" & Mid(QuoteFilter(dsExcel.Tables("dtt").Rows(i).Item("FOLIO NO").ToString), 1, 128) & "',"
                lsSql &= "  '" & Mid(QuoteFilter(dsExcel.Tables("dtt").Rows(i).Item("FOLIO NAME").ToString), 1, 128) & "',"
                lsSql &= "  '" & Mid(QuoteFilter(dsExcel.Tables("dtt").Rows(i).Item("SHARE COUNT").ToString), 1, 128) & "',"
                lsSql &= "  '" & Mid(QuoteFilter(dsExcel.Tables("dtt").Rows(i).Item("DIVIDEND AMOUNT").ToString), 1, 128) & "',"
                lsSql &= "  '" & Mid(QuoteFilter(dsExcel.Tables("dtt").Rows(i).Item("TDS PER").ToString), 1, 128) & "',"
                lsSql &= "  '" & Mid(QuoteFilter(dsExcel.Tables("dtt").Rows(i).Item("GROSS AMOUNT").ToString), 1, 128) & "',"
                lsSql &= "  '" & Mid(QuoteFilter(dsExcel.Tables("dtt").Rows(i).Item("BANK ACC NO").ToString), 1, 128) & "',"
                lsSql &= "  '" & Mid(QuoteFilter(dsExcel.Tables("dtt").Rows(i).Item("BANK NAME").ToString), 1, 128) & "',"
                lsSql &= "  '" & Mid(QuoteFilter(dsExcel.Tables("dtt").Rows(i).Item("BANK BRANCH").ToString), 1, 128) & "',"
                lsSql &= "  '" & Mid(QuoteFilter(dsExcel.Tables("dtt").Rows(i).Item("BANK PINCODE").ToString), 1, 128) & "',"
                lsSql &= "  '" & Mid(QuoteFilter(dsExcel.Tables("dtt").Rows(i).Item("REMITTANCE DATE").ToString), 1, 128) & "',"
                lsSql &= "  '" & Mid(QuoteFilter(dsExcel.Tables("dtt").Rows(i).Item("REF COLUMN1").ToString), 1, 255) & "',"
                lsSql &= "  '" & Mid(QuoteFilter(dsExcel.Tables("dtt").Rows(i).Item("REF COLUMN2").ToString), 1, 255) & "',"
                lsSql &= "  '" & Mid(QuoteFilter(dsExcel.Tables("dtt").Rows(i).Item("REF COLUMN3").ToString), 1, 255) & "',"
                lsSql &= "  '" & Mid(QuoteFilter(dsExcel.Tables("dtt").Rows(i).Item("REF COLUMN4").ToString), 1, 255) & "'"
                lsSql &= ")"

                lsResult = gfInsertQry(lsSql, gOdbcConn)

                If lsResult = 0 Then
                    lnInvalidRecords = lnInvalidRecords + 1
                Else
                    lnValidRecords = lnValidRecords + 1
                End If

            Next

            If lnValidRecords > 0 Then
                MessageBox.Show("Imported Successfully " & vbCrLf & "Valid Records : " & lnValidRecords & _
                vbCrLf & "Invalid Records : " & lnInvalidRecords, gsProjectName, MessageBoxButtons.OK)
            Else
                MessageBox.Show("Not Imported... ", gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.Cursor = Cursors.Default
            Application.DoEvents()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTemplate.Click
        Dim lsHeaders As String
        lsHeaders = "FROM,TO,FOLIO NO,FOLIO NAME,SHARE COUNT,DIVIDEND AMOUNT,BANK ACC NO,BANK NAME,BANK BRANCH,BANK PINCODE,REMITTANCE DATE"
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