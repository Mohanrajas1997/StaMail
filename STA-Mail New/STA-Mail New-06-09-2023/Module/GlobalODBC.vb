Imports System.IO
Imports System.IO.FileStream
Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Data
Imports FlexiLibrary
Module GlobalODBC

    Public gObjConnection As New iODBCconnection
    Public gObjSecurity As New iSecurity
    Public Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hwnd As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32

#Region "Global Declaration"

    Public ServerDetails As String = ""
    Public gsProjectName = "Bulk Mailing System"
    Public softcode = "MAIL"
    Public gsAsciiPath As String = ""
    Public gnCompId As Long = 0
    Public gsCompName As String = ""
    Public gUid As Integer
    Public gUserName As String = "Admin"
    Public gUserFullName As String = "Admin"
    Public gUserRights As String
    Public gsSmtpIp As String = "smtp.gmail.com"
    Public gsSmtpPort As String = "587"
    Public gsSmtpUser As String = "vijayavel.j@flexicodeindia.com"
    Public gsSmtpPwd As String = "Aadhimoolam"

    Public gsDatabase As String
    Public gsPreMonth As String
    Public gsChangeMonth As String
    Public gOdbcConn As New OdbcConnection
    Public gOdbcConn1 As New OdbcConnection

    Public gOdbcConnBIZ As New OdbcConnection
    Public gOdbcDAdp As New OdbcDataAdapter
    Public gOdbcCmd As New OdbcCommand

    Public gOdbcCmdBIZ As New OdbcCommand

    Public gFso As New FileIO.FileSystem
    Public gsReportPath As String = Application.StartupPath & "\"
    Public txt As Long

    Public Const gnAuth As Integer = 1
    Public Const gnReject As Integer = 2
    Public gdtTransactionDate As Date = Date.Today
    Public gsCorpCode As String = ""
    'Public gsBranchCode As String = ""
    'Public gsBranchName As String = ""

    Public gs_FontName As String = "Tahoma"
    Public gd_FontSize As Double = 8.5
    Public gn_HeadingColor As Integer = 21
    Public gn_SubHeadingColor As Integer = 18
    Public gn_QuarterlyColor As Integer = 23
    Public gn_HalfYearlyColor As Integer = 17
    Public gn_AvgColor As Integer = 23
    Public gn_YTDColor As Integer = 34
    Public gn_TotalColor As Integer = 21
    Public gn_OtherColor As Integer = 20
    Public gn_ReasonColor As Integer = 18

#End Region
    'For calling the Main form
    Public Sub Main()
        Dim DbUId As String = ""
        Dim DbPort As String = ""
        Dim DbPwd As String = ""
        Dim DbIP As String = ""
        Dim Db As String = ""

        Dim n As Integer = 0
        Dim sr As StreamReader
        Dim lsLine As String

        Try
            sr = FileIO.FileSystem.OpenTextFileReader(Application.StartupPath & "\STAConfig.ini")

            While Not sr.EndOfStream
                lsLine = sr.ReadLine()
                lsLine = DecryptTripleDES(lsLine)
                n += 1

                Select Case n
                    Case 1
                        DbIP = lsLine
                    Case 2
                        DbPort = lsLine
                    Case 3
                        DbUId = lsLine
                    Case 4
                        DbPwd = lsLine
                    Case 5
                        Db = lsLine
                    Case 6
                        gsAsciiPath = lsLine
                End Select
            End While

            sr.Close()

            If FileIO.FileSystem.DirectoryExists(gsAsciiPath) = False Then
                MsgBox("Invalid Ascii Path", MsgBoxStyle.Information, gsProjectName)
                frmServerConfiguration.ShowDialog()
                Exit Sub
            End If

            ServerDetails = "Driver={Mysql odbc 3.51 Driver};Server=" & DbIP & ";DataBase=" & Db & ";uid=" & DbUId & ";pwd=" & DbPwd & ";port=" & DbPort

            Call ConOpenOdbc(ServerDetails)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
            frmServerConfiguration.ShowDialog()
        End Try
    End Sub

    Public Sub InsertErrorLog(ByVal lsModule As String, ByVal lsProcedure As String, ByVal lsDescription As String)

        Dim gsSql As String

        gsSql = "INSERT INTO  abm_log_errorlog" & _
                  "(" & _
                        "module_name, procedure_name, description, user_id, trans_date" & _
                  ") " & _
                  "VALUES " & _
                  "(" & _
                        "'" & lsModule & "'," & _
                        "'" & lsProcedure & "'," & _
                        "'" & iRoutines.FormatTextInput(lsDescription) & "'," & _
                        "'" & gUid & "'," & _
                        "now()" & _
                  ")"

        gfInsertQry(gsSql, gOdbcConn)

        MessageBox.Show(lsDescription, gsProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Public Sub CaptureError(ByVal lsMessage As String)
        If lsMessage <> "" Then
            Throw New Exception(lsMessage)
        End If
    End Sub

    'Public Sub gpAutoFillCombo(ByVal cboBox As ComboBox)
    '    Dim l As Long

    '    With cboBox
    '        l = .Text.Length
    '        .SelectedIndex = .FindString(.Text)
    '        .SelectionStart = l
    '        .SelectionLength = Math.Abs(.Text.Length - l)
    '    End With
    'End Sub

    'To open the Connection
    Public Sub ConOpenOdbc(ByVal ServerDetails As String)
        If gOdbcConn.State = ConnectionState.Closed Then
            gOdbcConn.ConnectionString = ServerDetails
            gOdbcConn.Open()
            gOdbcCmd.Connection = gOdbcConn
        End If
        'empid = Security.clsEmpId
    End Sub

    'To open the Connection
    Public Sub ConOpenOdbcBIZ(ByVal ServerDetailsBIZ As String)
        If gOdbcConnBIZ.State = ConnectionState.Closed Then
            gOdbcConnBIZ.ConnectionString = ServerDetailsBIZ
            gOdbcConnBIZ.Open()
            gOdbcCmdBIZ.Connection = gOdbcConnBIZ
        End If
        'empid = Security.clsEmpId
    End Sub

    'To Close the Connection
    Public Sub ConCloseOdbc(ByVal ServerDetails As String)
        If gOdbcConn.State = ConnectionState.Open Then
            gOdbcConn.Close()
        End If
    End Sub
    'To Execute Query and return as datareader
    Public Function gfExecuteQry(ByVal strsql As String, ByVal odbcConn As OdbcConnection)
        Dim objCommand As OdbcCommand
        Dim objDataReader As OdbcDataReader
        objCommand = New OdbcCommand(strsql, odbcConn)
        Try
            objDataReader = objCommand.ExecuteReader()
            objCommand.Dispose()
            Return objDataReader
        Catch ex As Exception
            MsgBox(ex.Message)
            Return (0)
        End Try
    End Function
    'To Execute Query and return value as boolean
    Public Function gfExecuteQryBln(ByVal strsql As String, ByVal odbcConn As OdbcConnection) As Boolean
        gOdbcCmd = New OdbcCommand(strsql, odbcConn)
        Dim objDataReader As OdbcDataReader
        Try
            objDataReader = gOdbcCmd.ExecuteReader()
            If objDataReader.HasRows Then
                gfExecuteQryBln = True
            Else
                gfExecuteQryBln = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Function
        End Try
    End Function
    'To Execute Query and return value as string
    Public Function GetDataReader(ByVal SQL As String) As OdbcDataReader
        Dim cmdQuery As New OdbcCommand
        Dim lsobjDR As OdbcDataReader
        cmdQuery.Connection = gOdbcConn
        cmdQuery.CommandText = SQL
        cmdQuery.CommandType = CommandType.Text
        lsobjDR = cmdQuery.ExecuteReader
        Return lsobjDR
    End Function
    'To Execute Query and return value as string
    Public Function gfExecuteScalar(ByVal strsql As String, ByVal odbcConn As OdbcConnection) As String
        Dim StrVal As String
        Dim objCommand As OdbcCommand
        objCommand = New OdbcCommand(strsql, odbcConn)

        Try
            If IsDBNull(objCommand.ExecuteScalar()) Or IsNothing(objCommand.ExecuteScalar()) Then
                StrVal = ""
            Else
                StrVal = objCommand.ExecuteScalar()
            End If

            objCommand.Dispose()
            Return StrVal

        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function
    'To Execute Query and return value as integer
    Public Function gfInsertQry(ByVal strsql As String, ByVal odbcConn As OdbcConnection) As Integer
        Dim recAffected As Long
        gOdbcCmd = New OdbcCommand(strsql, odbcConn)
        gOdbcCmd.CommandType = CommandType.Text
        'Try
        recAffected = gOdbcCmd.ExecuteNonQuery()
        Return recAffected
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    Exit Function
        'End Try
    End Function
    'To Bind values to Datagrid
    Public Sub gpPopGrid(ByVal GridName As DataGrid, ByVal Qry As String, ByVal odbcConn As OdbcConnection)
        Dim lobjDataTable As New DataTable
        Dim lobjDataView As New DataView
        Dim lobjDataSet As New DataSet
        Dim lobjDataAdapter As New Odbc.OdbcDataAdapter
        Try
            lobjDataAdapter = New OdbcDataAdapter(Qry, odbcConn)
            lobjDataSet = New DataSet("TBL")
            lobjDataAdapter.Fill(lobjDataSet, "TBL")
            lobjDataTable = lobjDataSet.Tables(0)
            lobjDataView = New DataView(lobjDataTable)
            GridName.DataSource = lobjDataView
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'To Bind values to Datagrid
    Public Sub gpPopGridView(ByVal GridName As DataGridView, ByVal Qry As String, ByVal odbcConn As OdbcConnection)
        Dim lda As New Odbc.OdbcDataAdapter(Qry, odbcConn)
        Dim lds As New DataSet
        Dim ldt As DataTable

        Try
            lda.Fill(lds, "tbl")
            ldt = lds.Tables("tbl")
            GridName.DataSource = ldt
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'To filter single quote in the give text
    Public Function QuoteFilter(ByVal txt As String) As String
        QuoteFilter = Trim(Replace(Replace(Replace(txt, "'", " "), """", """"""), "\", "\\"))
    End Function
    'To Clear control in a form
    Public Sub frmCtrClear(ByVal frmName As Form)
        Dim ctrl As Control
        For Each ctrl In frmName.Controls
            If ctrl.Tag <> "*" Then
                If TypeOf ctrl Is TextBox Then ctrl.Text = ""
                If TypeOf ctrl Is ComboBox Then
                    ctrl.Text = ""
                End If
                'If TypeOf ctrl Is CheckBox Then
                '    ctrl = False
                'End If 
            End If
        Next
    End Sub
    'To get Dataset
    Public Function gfDataSet(ByVal SQL As String, ByVal tblName As String, ByVal odbcConn As Odbc.OdbcConnection) As DataSet
        Try
            Dim objDataAdapter As New OdbcDataAdapter(SQL, odbcConn)
            Dim objDataSet As New DataSet
            objDataAdapter.Fill(objDataSet, tblName)
            Return objDataSet
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    'LoadExcelSheet
    Public Sub gfLoadXLSheet(ByVal FileName As String, ByVal objCbo As ComboBox)
        Dim objXL As New Excel.Application
        Dim i As Integer

        objCbo.Items.Clear()
        objXL.Workbooks.Open(FileName)

        For i = 1 To objXL.ActiveWorkbook.Worksheets.Count
            objCbo.Items.Add(objXL.ActiveWorkbook.Worksheets(i).name)
        Next i

        objXL.Workbooks.Close()

        GC.Collect()
        GC.WaitForPendingFinalizers()
        objXL.Quit()
        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(objXL)
        objXL = Nothing
    End Sub
    'Binding combo
    Public Sub gpBindCombo(ByVal SQL As String, ByVal Dispfld As String, _
                               ByVal Valfld As String, ByRef ComboName As ComboBox, _
                                ByVal odbcConn As Odbc.OdbcConnection)

        Dim objDataAdapter As New OdbcDataAdapter
        Dim objCommand As New OdbcCommand
        Dim objDataTable As New Data.DataTable
        Try
            objCommand.Connection = odbcConn
            objCommand.CommandType = CommandType.Text
            objCommand.CommandText = SQL
            objDataAdapter.SelectCommand = objCommand
            objDataAdapter.Fill(objDataTable)
            ComboName.DataSource = objDataTable
            ComboName.DisplayMember = Dispfld
            ComboName.ValueMember = Valfld
            ComboName.SelectedIndex = -1

        Catch ex As Exception
            MsgBox(ex.Message)
            objDataTable.Dispose()
            objCommand.Dispose()
            objDataAdapter.Dispose()
        End Try
    End Sub

    'Binding combo
    Public Sub gpBindDGridCombo(ByVal SQL As String, ByVal Dispfld As String, _
                               ByVal Valfld As String, ByRef ComboName As DataGridViewComboBoxColumn, _
                                ByVal odbcConn As Odbc.OdbcConnection)

        Dim objDataAdapter As New OdbcDataAdapter
        Dim objCommand As New OdbcCommand
        Dim objDataTable As New Data.DataTable
        Try
            objCommand.Connection = odbcConn
            objCommand.CommandType = CommandType.Text
            objCommand.CommandText = SQL
            objDataAdapter.SelectCommand = objCommand
            objDataAdapter.Fill(objDataTable)
            ComboName.DataSource = objDataTable
            ComboName.DisplayMember = Dispfld
            ComboName.ValueMember = Valfld
            'ComboName.SelectedIndex = -1

        Catch ex As Exception
            MsgBox(ex.Message)
            objDataTable.Dispose()
            objCommand.Dispose()
            objDataAdapter.Dispose()
        End Try
    End Sub

    'Validating for Integer only
    Public Function gfIntEntryOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs) As Boolean
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8
                gfIntEntryOnly = False
            Case Else
                gfIntEntryOnly = True
        End Select
    End Function
    Public Function gfAmtEntryOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs) As Boolean
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 46
                gfAmtEntryOnly = False
            Case Else
                gfAmtEntryOnly = True
        End Select
    End Function
    'To Get the DataTable
    Public Function GetDataTable(ByVal SqlQry As String) As DataTable
        Dim lobjDataTable As New DataTable
        Dim lobjDataView As New DataView
        Dim lobjDataSet As New DataSet
        Dim lobjDataAdapter As New Odbc.OdbcDataAdapter
        GetDataTable = Nothing
        Try

            gOdbcDAdp = New OdbcDataAdapter(SqlQry, gOdbcConn)
            lobjDataSet = New DataSet("TBL")
            gOdbcDAdp.Fill(lobjDataSet, "TBL")
            lobjDataTable = lobjDataSet.Tables(0)
            lobjDataView = New DataView(lobjDataTable)
            Return lobjDataTable

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    'Disables the addition of rows in the given DataGrid
    Public Sub DisableAddNew(ByRef dg As DataGrid, _
                                    ByRef Frm As Form)
        ' Disable addnew capability on the grid.
        ' Note that AllowEdit and AllowDelete can be disabled
        ' by adding or changing the "AllowNew" property to
        ' AllowDelete or AllowEdit.
        Dim cm As CurrencyManager = _
           CType(Frm.BindingContext(dg.DataSource, dg.DataMember), _
                 CurrencyManager)
        CType(cm.List, DataView).AllowNew = False
    End Sub
    ' Aligns the given text in specified format
    Public Function AlignTxt(ByVal txt As String, ByVal Length As Integer, ByVal Alignment As Integer) As String
        Dim X As String = ""

        Select Case Alignment
            Case 1
                Return LSet(txt, Length)
            Case 4
                Return CSet(txt, Length)
            Case 7
                Return RSet(txt, Length)
            Case Else
                Return (0)
        End Select
    End Function
    ' Center Align the Given Text
    Public Function CSet(ByVal txt As String, ByVal PaperChrWidth As Integer) As String
        Dim s As String                 ' Temporary String Variable
        Dim l As Integer                ' Length of the String
        If txt.Length > PaperChrWidth Then
            CSet = Left(txt, PaperChrWidth)
        Else
            l = (PaperChrWidth - txt.Length) / 2
            s = RSet(txt, l + txt.Length)
            CSet = Space(PaperChrWidth - s.Length)
            CSet = s + CSet
        End If
    End Function
    Public Function SwapChkSum(ByVal txt As String) As Double
        Dim TempTxt As String
        Dim TempChkSum As Double
        Dim i As Long

        TempTxt = txt
        TempChkSum = 0

        For i = 1 To Len(TempTxt)
            TempChkSum = TempChkSum + Asc(Mid(TempTxt, i, 1)) + (i - 1)
        Next i

        SwapChkSum = TempChkSum
    End Function
    Public Function SwapChkSumNew(ByVal txt As String) As Double
        Dim TempTxt As String
        Dim TempChkSum As Double
        Dim i As Long

        TempTxt = txt
        TempChkSum = 0

        For i = 1 To Len(TempTxt)
            TempChkSum = TempChkSum + Asc(Mid(TempTxt, i, 1)) + (i)
        Next i

        SwapChkSumNew = TempChkSum
    End Function
    Public Function ConvUcase(ByVal keychar As String) As String
        Select Case keychar
            Case "a" To "z"
                ConvUcase = keychar.ToUpper
            Case Else
                ConvUcase = keychar
        End Select
    End Function
    'To Kill the Excel EXE
    Public Sub Kill_Excel()
        Dim proc As System.Diagnostics.Process
        For Each proc In System.Diagnostics.Process.GetProcessesByName("EXCEL")
            proc.Kill()
        Next
    End Sub
    'To get Dataset
    Public Sub gpDataSet(ByVal SQL As String, ByVal tblName As String, ByVal odbcConn As Odbc.OdbcConnection, ByVal ds As DataSet)
        Dim objDataAdapter As New OdbcDataAdapter(SQL, odbcConn)
        Try
            objDataAdapter.Fill(ds, tblName)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub
    'For Aging Calculation
    ' TAT - (T)urn (A)round (T)ime
    Public Function Ageing(ByVal FromDt As Date, ByVal ToDt As Date) As Long
        Dim m As Long, n As Long

        n = Val(gfExecuteScalar("select count(*) from rec_mst_tholiday " _
            & "where holiday_date >= '" & Format(FromDt, "yyyy-MM-dd") & "' " _
            & "and holiday_date <= '" & Format(ToDt, "yyyy-MM-dd") & "' " _
            & "and delete_flag is null", gOdbcConn))

        m = DateDiff("d", FromDt, ToDt)

        Ageing = m - n
    End Function

    Public Function SLSAgeing(ByVal FromDt As Date, ByVal ToDt As Date, ByVal limit As Integer) As Long
        Dim m As Long, n As Long

        n = Val(gfExecuteScalar("select count(*) from rec_mst_tholiday " _
            & "where holiday_date >= '" & Format(FromDt, "yyyy-MM-dd") & "' " _
            & "and holiday_date <= '" & Format(ToDt, "yyyy-MM-dd") & "' " _
            & "and delete_flag is null", gOdbcConn))

        m = DateDiff("d", FromDt, ToDt)

        SLSAgeing = m + n
    End Function
    'For Aging Date Calculation
    Public Function AgeingDt(ByVal dt As Date, ByVal Interval As Long) As Date
        Dim m As Long, N As Long, i As Long
        Dim mdToDate As Date
        i = 0
        Do
            mdToDate = DateAdd("d", ((Interval + i) * -1), dt)

            N = Val(gfExecuteScalar("select count(*) from rec_mst_tholiday " _
                & "where holiday_date <= '" & Format(dt, "yyyy-MM-dd") & "' " _
                & "and holiday_date >= '" & Format(mdToDate, "yyyy-MM-dd") & "' " _
                & "and delete_flag is null", gOdbcConn))


            m = DateDiff("d", mdToDate, dt) - N

            'i = i + 1
            i = i + (Interval - m)
        Loop Until m = Interval

        AgeingDt = DateAdd("d", -(Interval + i), dt)
    End Function
    ' With Location 
    Public Function LocationWiseAgeingDt_old(ByVal dt As Date, ByVal Interval As Long, ByVal llLocation_gid As Long) As Date
        Dim m As Long, N As Long, i As Long
        Dim mdToDate As Date
        i = 0

        Do
            'mdToDate = DateAdd(DateInterval.Day, ((Interval + i) * -1), dt)
            mdToDate = DateAdd(DateInterval.Day, (Interval + i), dt)

            N = Val(gfExecuteScalar("select count(*) from rec_mst_tholiday " _
                & "where holiday_date <= '" & Format(dt, "yyyy-MM-dd") & "' " _
                & "and holiday_date >= '" & Format(mdToDate, "yyyy-MM-dd") & "' " _
                & " and location_gid=" & llLocation_gid _
                & " and delete_flag is null", gOdbcConn))


            m = DateDiff(DateInterval.Day, mdToDate, dt) - N

            'i = i + 1
            i = i + (Interval - m)
        Loop Until m = Interval

        LocationWiseAgeingDt_old = DateAdd(DateInterval.Day, -(Interval + i), dt)
    End Function
    ' With Location 
    Public Function LocationWiseAgeingDt(ByVal dt As Date, ByVal Interval As Long, ByVal LocationId As Long) As Date
        Dim m As Long, n As Long, i As Long
        Dim todt As Date

        i = 0

        Do
            If Interval > 0 Then
                todt = DateAdd(DateInterval.Day, -(Interval - i), dt)

                n = gfExecuteScalar("select count(*) from rec_mst_tholiday " _
                    & "where holiday_date <= '" & Format(dt, "yyyy-MM-dd") & "' " _
                    & "and holiday_date >= '" & Format(todt, "yyyy-MM-dd") & "' " _
                    & "and location_gid = '" & LocationId & "' " _
                    & "and delete_flag is null", gOdbcConn)

                m = DateDiff(DateInterval.Day, todt, dt) - n
                i = i - 1
            Else
                todt = DateAdd(DateInterval.Day, -(Interval - i), dt)

                n = gfExecuteScalar("select count(*) from rec_mst_tholiday " _
                    & "where holiday_date >= '" & Format(dt, "yyyy-MM-dd") & "' " _
                    & "and holiday_date <= '" & Format(todt, "yyyy-MM-dd") & "' " _
                    & "and location_gid = '" & LocationId & "' " _
                    & "and delete_flag is null", gOdbcConn)

                m = (DateDiff(DateInterval.Day, dt, todt) - n) * -1
                i = i + 1
            End If

        Loop Until m = Interval

        If Interval > 0 Then
            i = i + 1
        Else
            i = i - 1
        End If

        LocationWiseAgeingDt = DateAdd(DateInterval.Day, -(Interval + i * -1), dt)
    End Function

    'For Getting Loan Type 
    Public Function gfLoanType(ByVal lsLoanNo As String)
        Dim lsLoanType As String = ""
        Dim lnLoanLen As Integer

        lnLoanLen = lsLoanNo.Length
        If IsNumeric(lsLoanNo) Then
            lsLoanType = "H"
        Else
            lsLoanType = Mid(lsLoanNo, 1, 1)
            If lsLoanType = "A" Then
                lsLoanType = "A"
            ElseIf lsLoanType = "C" Or lsLoanType = "D" Then
                lsLoanType = "C"
            Else
                lsLoanType = "P"
            End If
        End If
        Return lsLoanType
    End Function

    'Excel To DS :Created Date :23-02-2009 :Created By :Ilaya
    Public Function gpExcelDataset(ByVal Qry As String, ByVal Excelpath As String) As DataTable
        Dim fOleDbConString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" & Excelpath & ";" + "Extended Properties=Excel 8.0;"
        Dim lobjDataTable As New DataTable
        Dim lobjDataSet As New DataSet
        Dim lobjDataAdapter As New OleDbDataAdapter

        lobjDataAdapter = New OleDbDataAdapter(Qry, fOleDbConString)
        lobjDataSet = New DataSet("TBL")
        lobjDataAdapter.Fill(lobjDataSet, "TBL")
        lobjDataTable = lobjDataSet.Tables(0)
        Return lobjDataTable

    End Function

    'DBF To DS :Created Date :03-03-2009 :Created By :Kali
    Public Function gpDBFDataset(ByVal Qry As String, ByVal DBFPath As String) As DataTable
        Dim fOleDbConString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" & DBFPath & ";" + "Extended Properties=dBASE IV;User ID=Admin;Password=;"
        Dim lobjDataTable As New DataTable
        Dim lobjDataSet As New DataSet
        Dim lobjDataAdapter As New OleDbDataAdapter

        lobjDataAdapter = New OleDbDataAdapter(Qry, fOleDbConString)
        lobjDataSet = New DataSet("TBL")
        lobjDataAdapter.Fill(lobjDataSet, "TBL")
        lobjDataTable = lobjDataSet.Tables(0)
        Return lobjDataTable

    End Function

    'Chq Number validate :Created Date :23-02-2009 :Created By :Ilaya
    Public Function gfValidate_chqDate(ByVal chqdt As Date, ByVal CycleDate As Date) As Boolean
        Dim monthdt As Date = Nothing
        monthdt = DateAdd(DateInterval.Month, -6, CycleDate) 'Date less than 6 month from cycle date
        If IsDate(chqdt) Then
            If CDate(monthdt) <= CDate(chqdt) Then
                If CDate(chqdt) <= CDate(CycleDate) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    'AutoFillCombo :Created Date :24-02-2009 :Created By :Ilaya
    Public Sub gpAutoFillCombo(ByVal cboBox As ComboBox)

        Dim lnLenght As Long

        With cboBox

            lnLenght = .Text.Length

            .SelectedIndex = .FindString(.Text)

            .SelectionStart = lnLenght

            .SelectionLength = Math.Abs(.Text.Length - lnLenght)

        End With

    End Sub
    'AutoFillCombo :Created Date :24-02-2009 Created By :Ilaya
    Public Sub gpAutoFindCombo(ByVal cboBox As ComboBox)
        cboBox.SelectedIndex = cboBox.FindString(cboBox.Text)
    End Sub

    Public Sub KillProcess(ByVal lnHwnd As Integer)
        Dim ReturnVal = PostMessage(lnHwnd, &H12, 0, 0)
    End Sub

    Public Sub RowColor(ByVal ctrl As AxMSFlexGridLib.AxMSFlexGrid, ByVal StartRow As Integer, ByVal EndRow As Integer, ByVal BkColor As Long)
        Dim i As Integer, j As Integer

        Try
            With ctrl
                For i = StartRow To EndRow
                    .Row = i

                    For j = .FixedCols To .Cols - 1
                        .Col = j
                        .CellBackColor = ColorTranslator.FromWin32(BkColor)
                    Next j
                Next i
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
        End Try
    End Sub

    Public Function gpEnterAmount(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal Amount As TextBox) As Boolean
        Dim lnValue As Integer = 0
        Dim i As Integer = 0
        Dim givenlength As Long = 0
        Dim lnWhole As Long = 0
        Dim lnPoint As Long = 0
        Dim lsPercent() As String
        Dim llPercent As Long
        Dim lsVal As String = ""
        Try
            If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 13 Then
                e.Handled = False
            Else
                llPercent = Val(Amount.Text)
                lsVal = Amount.Text & e.KeyChar

                givenlength = llPercent.ToString.Length

                lsPercent = Split(Amount.Text, ".")

                lnValue = UBound(lsPercent)
                If lnValue = 0 Then
                    lnWhole = Val(lsPercent(0))             'Whole Number
                ElseIf lnValue = 1 Then
                    lnWhole = Val(lsPercent(0))             'Whole Number
                    lnPoint = Val(lsPercent(1))             'Point Value
                End If

                If lnPoint.ToString.Length < 2 Then
                    gpEnterAmount = False
                Else
                    gpEnterAmount = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function GetTemplate(ByVal lsTemplateFileName As String) As String
        Dim lsPath As String
        Dim fssql As String
        Dim objDataReader As Odbc.OdbcDataReader
        lsPath = Application.StartupPath & "\Template"
        If Not Directory.Exists(lsPath) Then
            Directory.CreateDirectory(lsPath)
        End If
        fssql = "SELECT template_binary,template_name FROM erpt_mst_ttemplate where template_name ='" & lsTemplateFileName & "'"
        objDataReader = GetDataReader(fssql)
        With objDataReader
            If .HasRows Then
                If File.Exists(lsPath & "\" & .Item("template_name")) Then
                    Kill(lsPath & "\" & .Item("template_name"))
                End If
                Dim objfs As New FileStream(lsPath & "\" & .Item("template_name"), FileMode.OpenOrCreate, FileAccess.Write)
                Dim MyData As Byte() = .Item("template_binary")
                objfs.Write(MyData, 0, System.Convert.ToInt32(MyData.Length))
                objfs.Close()
            End If
            GetTemplate = lsPath & "\" & .Item("template_name")

        End With
    End Function

    Public Function HolidayCount(ByVal from_date As Date, ByVal to_date As Date) As Long
        Dim lnCount As Long
        Dim fssql As String

        fssql = " select count(*) from acrl_mst_tholiday "
        fssql &= " where holiday_date <= '" & Format(CDate(from_date), "yyyy-MM-dd") & "' "
        fssql &= " and holiday_date >= '" & Format(CDate(to_date), "yyyy-MM-dd") & "' "
        fssql &= " and delete_flag ='N'"

        lnCount = gfExecuteScalar(fssql, gOdbcConn)

        Return lnCount

    End Function

    'For Zip A File
    Public Sub gp_WinZip(ByVal password As String, ByVal DirPath As String, ByVal ZipPath As String)
        Dim FileName As String
        Dim X As String
        Dim lb_Flag As Boolean
        Try
            Const ZIPEXE = "C:\Program Files\WinZip\WINZIP32.EXE "

            If Dir(ZipPath, vbDirectory) = "" Then
                MkDir(ZipPath)
            End If
            FileName = Dir(DirPath, vbNormal)
            While FileName <> ""

                X = ZIPEXE & " -a -s" & password & " " & ZipPath & "\" & Mid(FileName, 1, Len(FileName) - 4) & ".zip " & DirPath
                Microsoft.VisualBasic.Interaction.Shell(X)

                FileName = Dir()
                lb_Flag = True
            End While

            If lb_Flag = True Then
                'MsgBox("Successfully Created at " & ZipPath, MsgBoxStyle.Information, gsProjectName)
                System.Threading.Thread.Sleep(1000)
            Else
                MsgBox("ZIP Process Failed", MsgBoxStyle.Information, gsProjectName)
            End If
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub gp_MISExportSettings()
        Dim fsSql As String
        Dim ds As DataSet
        Try

            fsSql = ""
            fsSql &= " SELECT * FROM erpt_mst_tsettings "
            fsSql &= " WHERE active_flag='Y' "

            ds = gfDataSet(fsSql, "setting", gOdbcConn)

            If ds.Tables("setting").Rows.Count > 0 Then

                gs_FontName = ds.Tables(0).Rows(0).Item("font_name").ToString
                gd_FontSize = Val(ds.Tables(0).Rows(0).Item("font_size").ToString)

                fsSql = " SELECT color_index FROM erpt_mst_tcolorvalue "
                fsSql &= " WHERE color_hexavalue='" & ds.Tables(0).Rows(0).Item("heading_color").ToString & "' "
                gn_HeadingColor = Val(gfExecuteScalar(fsSql, gOdbcConn))

                fsSql = " SELECT color_index FROM erpt_mst_tcolorvalue "
                fsSql &= " WHERE color_hexavalue='" & ds.Tables(0).Rows(0).Item("subheading_color").ToString & "' "
                gn_SubHeadingColor = Val(gfExecuteScalar(fsSql, gOdbcConn))

                fsSql = " SELECT color_index FROM erpt_mst_tcolorvalue "
                fsSql &= " WHERE color_hexavalue='" & ds.Tables(0).Rows(0).Item("quarterly_color").ToString & "' "
                gn_QuarterlyColor = Val(gfExecuteScalar(fsSql, gOdbcConn))

                fsSql = " SELECT color_index FROM erpt_mst_tcolorvalue "
                fsSql &= " WHERE color_hexavalue='" & ds.Tables(0).Rows(0).Item("half_yearly_color").ToString & "' "
                gn_HalfYearlyColor = Val(gfExecuteScalar(fsSql, gOdbcConn))

                fsSql = " SELECT color_index FROM erpt_mst_tcolorvalue "
                fsSql &= " WHERE color_hexavalue='" & ds.Tables(0).Rows(0).Item("avg_color").ToString & "' "
                gn_AvgColor = Val(gfExecuteScalar(fsSql, gOdbcConn))

                fsSql = " SELECT color_index FROM erpt_mst_tcolorvalue "
                fsSql &= " WHERE color_hexavalue='" & ds.Tables(0).Rows(0).Item("ytd_color").ToString & "' "
                gn_YTDColor = Val(gfExecuteScalar(fsSql, gOdbcConn))

                fsSql = " SELECT color_index FROM erpt_mst_tcolorvalue "
                fsSql &= " WHERE color_hexavalue='" & ds.Tables(0).Rows(0).Item("total_color").ToString & "' "
                gn_TotalColor = Val(gfExecuteScalar(fsSql, gOdbcConn))

                fsSql = " SELECT color_index FROM erpt_mst_tcolorvalue "
                fsSql &= " WHERE color_hexavalue='" & ds.Tables(0).Rows(0).Item("other_color").ToString & "' "
                gn_OtherColor = Val(gfExecuteScalar(fsSql, gOdbcConn))

                fsSql = " SELECT color_index FROM erpt_mst_tcolorvalue "
                fsSql &= " WHERE color_hexavalue='" & ds.Tables(0).Rows(0).Item("reason_color").ToString & "' "
                gn_ReasonColor = Val(gfExecuteScalar(fsSql, gOdbcConn))
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function GetDataTable(ByVal psSql As String, ByVal tbl As String) As DataTable
        Dim lobjDataAdapter As New OdbcDataAdapter()
        Dim lobjCommand As New OdbcCommand()
        Dim lobjDataTable As New DataTable(tbl)
        Try

            lobjCommand.Connection = gOdbcConn
            lobjCommand.CommandType = CommandType.Text
            lobjCommand.CommandText = psSql
            lobjDataAdapter.SelectCommand = lobjCommand
            lobjDataAdapter.Fill(lobjDataTable)
            Return lobjDataTable
            lobjCommand.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gsProjectName)
            Return Nothing
        End Try


    End Function

    Public Function IPAddresses(ByVal server As String) As String
        Try
            ' Get server related information.
            Dim heserver As Net.IPHostEntry = Net.Dns.GetHostEntry(server)
            ' Loop on the AddressList
            Dim curAdd As Net.IPAddress
            Dim lsIpAddr As String = ""

            For Each curAdd In heserver.AddressList
                ' Display the server IP address in the standard format. In 
                ' IPv4 the format will be dotted-quad notation, in IPv6 it will be
                ' in in colon-hexadecimal notation.
                lsIpAddr = curAdd.ToString()
            Next curAdd

            Return lsIpAddr
        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical, gsProjectName)
            Return ""
        End Try
    End Function 'IPAddresses
End Module