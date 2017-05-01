Imports System.Text.RegularExpressions

Public Class clsValidator
    Private Shared sError As String

    Public Shared Function getError()
        'public Function to return the error 
        'To other objects
        Return sError
    End Function

    Public Shared Function clearError()
        'public Function to return the error 
        'To other objects
        sError = ""
        Return sError
    End Function

    Private Shared Sub addError(ByVal s As String)
        'private function to format our error message by
        'adding line breaks when necessary
        If sError = "" Then
            sError = s
        Else
            sError += vbCrLf & s
        End If
    End Sub

    Public Shared Function isValidPhone(ByVal s As String) As Boolean
        Dim bResult As Boolean
        Try
            If s <> "" Then
                bResult = True
            Else
                addError("Phone: Phone number must not be left blank")
                bResult = False
            End If
            If s.Length = 10 Then
                bResult = True
            Else
                addError("Phone: Phone number must be 10 characters long")
                bResult = False
            End If
        Catch ex As Exception
            addError("Phone: Invalid Phone Number(" & ex.Message & ")")
            bResult = False
        End Try
        Return bResult
    End Function

    Public Shared Function isValidName(ByVal s As String) As Boolean
        Dim bResult As Boolean
        Try
            If s <> "" Then
                bResult = True
            Else
                addError("Name: Invalid Customer Name")
                bResult = False
            End If
            If IsNumeric(s) Then
                addError("Name: Enter a non-numeric name")
                bResult = False
            End If
        Catch ex As Exception
            addError("Name: Invalid Customer Name (" & ex.Message & ")")
            bResult = False
        End Try

        Return bResult
    End Function

    Public Shared Function isValidID(ByVal s As String) As Boolean
        Dim bResult As Boolean
        Try
            If s <> "" Then
                bResult = True
            Else
                addError("ID: Must not be left blank")
                bResult = False
            End If
        Catch ex As Exception
            addError("ID: Invalid ID (" & ex.Message & ")")
            bResult = False
        End Try
        Return bResult
    End Function

    Public Shared Function isValidDepartment(ByVal s As String) As Boolean
        Dim bResult As Boolean
        Try
            If s <> "" Then
                bResult = True
            Else
                addError("Department: Please enter a department")
                bResult = False
            End If
        Catch ex As Exception
            addError("Department: Invalid Department(" & ex.Message & ")")
        End Try
        Return bResult
    End Function

    Public Shared Function isValidDescription(ByVal s As String) As Boolean
        Dim bResult As Boolean
        Try
            If s <> "" Then
                bResult = True
            Else
                addError("Description: Please enter a description")
                bResult = False
            End If
        Catch ex As Exception
            addError("Description: Invalid Description(" & ex.Message & ")")
        End Try
        Return bResult
    End Function

    Public Shared Function isValidUnits(ByVal s As String) As Boolean
        Dim bResult As Boolean
        Try
            If s <> "" Then
                bResult = True
            Else
                addError("Units: Please enter units")
                bResult = False
            End If
            If IsNumeric(s) Then
                bResult = True
            Else
                addError("Units: Enter numeric units")
                bResult = False
            End If
            If s > 4 Then
                addError("Units: Must be less than 4")
                bResult = False
            Else
                bResult = True
            End If
        Catch ex As Exception
            addError("Units: Invalid units (" & ex.Message & ")")
            bResult = False
        End Try
        Return bResult
    End Function

    Public Shared Function isValidYear(ByVal s As String) As Boolean
        Dim bResult As Boolean
        Try
            If s <> "" Then
                bResult = True
            Else
                addError("Year: Please enter a year")
                bResult = False
            End If
            If IsNumeric(s) Then
                bResult = True
            Else
                addError("Year: Please enter an integer")
                bResult = False
            End If
            If s.Length <> 4 Then
                addError("Year: Must be 4 digits")
                bResult = False
            Else
                bResult = True
            End If
        Catch ex As Exception
            addError("Year: Invalid year (" & ex.Message & ")")
            bResult = False
        End Try
        Return bResult
    End Function

    Public Shared Function isValidQuarter(ByVal s As String) As Boolean
        Dim bResult As Boolean
        Try
            If s <> "" Then
                bResult = True
            Else
                addError("Quarter: Please enter a quarter")
                bResult = False
            End If
        Catch ex As Exception
            addError("Quarter: Invalid quarter (" & ex.Message & ")")
            bResult = False
        End Try
        Return bResult
    End Function

    Public Shared Function isValidEmail(ByVal s As String) As Boolean
        Dim bResult As Boolean
        Try
            If s <> "" Then
                bResult = True
            Else
                addError("Email: Please enter an email")
                bResult = False
            End If
            ' Declare local variable to hold regular expression
            Dim email As New Regex("^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")
            ' Check if matching email format
            If Not email.IsMatch(s) Then
                ' Not a valid email address
                addError("Email: Enter valid email address" + vbNewLine + "Example of Email Format: STUDENTNAME@DOMAIN.COM")
            End If
        Catch ex As Exception
            addError("Email: Invalid email( " & ex.Message & ")")
            bResult = False
        End Try
        Return bResult
    End Function
End Class
