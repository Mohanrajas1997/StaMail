Imports System.IO
Imports System.Security.Cryptography

Module modFunction
    Private KEY_192() As Byte = {42, 16, 93, 156, 78, 4, 218, 32, _
                15, 167, 44, 80, 26, 250, 155, 112, 2, 94, 11, 204, 119, 35, 184, 198}

    Private IV_192() As Byte = {55, 103, 246, 79, 36, 99, 167, 3, _
            42, 5, 62, 83, 184, 7, 209, 13, 145, 23, 200, 58, 173, 10, 121, 222}

    ' Function to convert Infix to Postfix expression
    Private Function PostFix(ByVal infix As String) As String
        On Error Resume Next

        Dim i As Integer, m As String, s As String, c As String = "", j As Integer
        Dim num As String = "", a As String = "", n As Integer

        n = 0
        s = ""

        For i = 1 To Len(infix)
            m = Mid(infix, i, 1)

            Select Case m
                Case "(", ")", "^", "*", "/", "+", "-"
                    If num <> "" Then
                        num = num + """"
                        s = s + num
                        num = ""
                    End If

                    If m <> ")" Then
                        For j = n To 1 Step -1

                            'c = pop

                            c = Mid(a, n, 1)
                            n = n - 1
                            a = Mid(a, 1, n)

                            If priority(c) >= priority(m) And priority(c) <> 4 Then
                                s = s + c + """"
                            Else
                                'push (c)

                                n = n + 1
                                a = a + c

                                Exit For
                            End If
                        Next j

                        'push (m)
                        n = n + 1
                        a = a + m
                    Else
                        For j = n To 1 Step -1
                            'c = pop

                            c = Mid(a, n, 1)
                            n = n - 1
                            a = Mid(a, 1, n)

                            If c <> "(" Then
                                s = s + c + """"
                            Else
                                Exit For
                            End If
                        Next j
                    End If
                Case Else
                    num = num + m
                    's = s + m
            End Select
        Next i

        If num <> "" Then
            s = s + num + """"
        End If

        For i = n To 1 Step -1
            'c = pop

            c = Mid(a, n, 1)
            n = n - 1
            a = Mid(a, 1, n)

            s = s + c + """"
        Next i

        PostFix = s
    End Function

    Private Function priority(ByVal token As String) As Integer
        Select Case token
            Case "^"
                priority = 3
            Case "*", "/"
                priority = 2
            Case "+", "-"
                priority = 1
            Case "("
                priority = 4
        End Select
    End Function

    ' Function to evaluate the value of infix string
    Public Function evaluate(ByVal infix As String) As Double
        On Error Resume Next

        Dim i As Integer, m As String, t As String = "", post_fix As String
        Dim stack() As Double, n As Integer
        Dim X As Double, Y As Double

        ReDim stack(infix.Length * 2)

        post_fix = PostFix(CompressInfix(infix))
        n = -1

        For i = 1 To Len(post_fix)
            m = Mid(post_fix, i, 1)

            If m = """" Then
                Select Case t
                    Case "+", "-", "*", "/", "^"
                        X = stack(n)

                        If n > 0 Then
                            Y = stack(n - 1)
                        Else
                            Y = 0
                        End If

                        If n <= 0 Then
                            n = 0
                        Else
                            n = n - 1
                        End If

                        Select Case t
                            Case "*"
                                stack(n) = X * Y
                            Case "/"
                                stack(n) = Y / X
                            Case "+"
                                stack(n) = X + Y
                            Case "-"
                                stack(n) = Y - X
                            Case "^"
                                stack(n) = Y ^ X
                        End Select
                    Case Else
                        n = n + 1
                        stack(n) = Val(t)
                End Select
                t = ""
            Else
                t = t + m
            End If
        Next i

        evaluate = stack(0)
    End Function

    ' Function to compress Infix expression
    Private Function CompressInfix(ByVal Infix As String) As String
        On Error Resume Next

        Dim i As Integer, m As String, t As String = "", post_fix As String
        Dim stack() As Double, n As Integer, p As Integer = 0, q As Integer = 0
        Dim CompInfix() As String

        ReDim CompInfix(Infix.Length)

        n = -1

        For i = 1 To Infix.Length
            n += 1

            m = Mid(Infix, i, 1)
            CompInfix(n) = m

            If m = ")" Then
                m = ""
                t = ""
                p = 1
                q = 0

                CompInfix(n) = ""
                n = n - 1

                While Not (m = "(" And p = q)
                    m = CompInfix(n)
                    If m = ")" Then p += 1

                    CompInfix(n) = ""
                    t = m + t

                    n = n - 1
                    m = CompInfix(n)

                    If m = "(" Then q += 1
                End While

                m = CStr(evaluate(t))

                If m < 0 Then
                    n = n + 1
                    CompInfix(n) = "0"
                End If

                n = n + 1
                CompInfix(n) = m

                n = n + 1
                CompInfix(n) = ")"
            End If
        Next i

        m = ""

        For i = 0 To n
            m = m + CompInfix(i)
        Next i

        Return m
    End Function

    Public Function DecryptTripleDES(ByVal value As String) As String
        Try
            If value <> "" Then
                value = value.Replace(" ", "+")
                Dim cryptoProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()

                'convert from string to byte array
                Dim buffer As Byte() = Convert.FromBase64String(value)
                Dim ms As MemoryStream = New MemoryStream(buffer)
                Dim cs As CryptoStream = New CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_192, IV_192), CryptoStreamMode.Read)
                Dim sr As StreamReader = New StreamReader(cs)

                Return sr.ReadToEnd()
            Else
                Return ""
            End If
        Catch ex As Exception
            'Handle Exception - Redirect to Error Page
        End Try
    End Function

    Public Function EncryptTripleDES(ByVal value As String) As String
        Try
            If value <> "" Then
                Dim cryptoProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
                Dim ms As MemoryStream = New MemoryStream()
                Dim cs As CryptoStream = New CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_192, IV_192), CryptoStreamMode.Write)
                Dim sw As StreamWriter = New StreamWriter(cs)

                sw.Write(value)
                sw.Flush()
                cs.FlushFinalBlock()
                ms.Flush()

                'convert back to a string
                Return Convert.ToBase64String(ms.GetBuffer(), 0, ms.Length)
            Else
                Return ""
            End If
        Catch ex As Exception
            'Handle Exception - Redirect to Error Page
        End Try
    End Function
End Module
