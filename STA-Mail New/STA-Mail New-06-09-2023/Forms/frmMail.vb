Imports System.Data.Odbc
Public Class frmMail

#Region "Local Declaration"
    Dim fsSql As String
    Dim lobjDatareader As OdbcDataReader
#End Region

    Private Sub ListAll()

        Try
            fsSql = ""
            fsSql = " select  mail_cc1, mail_cc2, mail_cc3, mail_cc4 "
            fsSql &= " from abm_mst_tmail "
            fsSql &= " where delete_flag='N' "

            lobjDatareader = GetDataReader(fsSql)
            If lobjDatareader.HasRows = True Then

                If lobjDatareader.Read() Then

                    txtcc1.Text = lobjDatareader.Item(0).ToString()
                    txtcc2.Text = lobjDatareader.Item(1).ToString()
                    txtcc3.Text = lobjDatareader.Item(2).ToString()
                    txtcc4.Text = lobjDatareader.Item(3).ToString()

                End If
            End If
            lobjDatareader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("Do you want to close?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, gsProjectName) = MsgBoxResult.Yes Then
            MyBase.Close()
        End If
    End Sub


    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim lnResult As Integer
        Try

            'If txtcc1.Text.Trim = "" Then
            '    MsgBox("CC1 can't be empty", MsgBoxStyle.Information, gsProjectName)
            '    txtcc1.Focus()
            '    Exit Sub
            'End If

            'If txtcc2.Text.Trim = "" Then
            '    MsgBox("CC2 Name can't be empty", MsgBoxStyle.Information, gsProjectName)
            '    txtcc2.Focus()
            '    Exit Sub
            'End If




            fsSql = " update abm_mst_tmail "
            fsSql &= " set mail_cc1='" & QuoteFilter(txtcc1.Text) & "',"
            fsSql &= " mail_cc2='" & QuoteFilter(txtcc2.Text) & "',"
            fsSql &= " mail_cc3='" & QuoteFilter(txtcc3.Text) & "',"
            fsSql &= " mail_cc4 ='" & QuoteFilter(txtcc3.Text) & "'"
            fsSql &= " where delete_flag='N'"

           

            lnResult = gfInsertQry(fsSql, gOdbcConn)

            If lnResult <> 0 Then
                MsgBox("Record updated Successfully", MsgBoxStyle.Information, gsProjectName)

            Else
                MsgBox("Record updation Faild", MsgBoxStyle.Information, gsProjectName)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmMail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call ListAll()

      
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class