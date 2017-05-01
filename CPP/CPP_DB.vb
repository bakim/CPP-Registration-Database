Imports System.Data.SqlClient
Public Class CPP_DB
    Private Shared cn As SqlConnection
    Private Shared strError As String

    Public Shared Function loadCatalogs() As List(Of clsCatalog)
        'List of catalog that will be returned
        Dim studentList As New List(Of clsCatalog)

        'DB variables
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""

        Try
            strSQL = "Select * From CPP_CATALOG"

            dbConnect()
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()

            Do While rdr.Read()
                'Add basic catalog information
                Dim aStudent As New clsCatalog
                aStudent.catalogID = rdr("CATALOG_ID")
                aStudent.year = rdr("YEAR")
                aStudent.quarter = rdr("QUARTER")
                aStudent.courseID = rdr("COURSE_ID")
                aStudent.profID = rdr("PROF_ID")

                studentList.Add(aStudent)
            Loop
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return studentList
    End Function

    Public Shared Function loadCourse() As List(Of clsCourse)
        'List of course that will be returned
        Dim studentList As New List(Of clsCourse)

        'DB variables
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""

        Try
            strSQL = "Select * From CPP_COURSES"

            dbConnect()
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()

            Do While rdr.Read()
                'Add basic course information
                Dim aStudent As New clsCourse
                aStudent.courseID = rdr("COURSE_ID")
                aStudent.description = rdr("DESCRIPTION")
                aStudent.units = rdr("UNITS")

                studentList.Add(aStudent)
            Loop
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return studentList
    End Function

    Public Shared Function loadEnrollments() As List(Of clsEnrollment)
        'List of enrollments that will be returned
        Dim studentList As New List(Of clsEnrollment)

        'DB variables
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""

        Try
            strSQL = "Select * From CPP_ENROLLMENT"

            dbConnect()
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()

            Do While rdr.Read()
                'Add basic enrollment information
                Dim aStudent As New clsEnrollment
                aStudent.broncoID = rdr("BRONCO_ID")
                aStudent.catalogID = rdr("CATALOG_ID")

                studentList.Add(aStudent)
            Loop
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return studentList
    End Function

    Public Shared Function loadInstructors() As List(Of clsInstructor)
        'List of instructors that will be returned
        Dim studentList As New List(Of clsInstructor)

        'DB variables
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""

        Try
            'Get all records
            strSQL = "Select * From CPP_INSTRUCTORS"

            dbConnect()
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()

            Do While rdr.Read()
                'Add basic instructor information
                Dim aStudent As New clsInstructor
                aStudent.profID = rdr("PROF_ID")
                aStudent.firstName = rdr("FIRST_NAME")
                aStudent.lastName = rdr("LAST_NAME")
                aStudent.phone = rdr("PHONE")
                aStudent.department = rdr("DEPARTMENT")

                studentList.Add(aStudent)
            Loop
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return studentList
    End Function

    Public Shared Function loadStudents() As List(Of clsStudent)
        'List of students that will be returned
        Dim studentList As New List(Of clsStudent)

        'DB variables
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""

        Try
            strSQL = "Select * From CPP_STUDENTS"

            dbConnect()
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()

            Do While rdr.Read()
                'Add basic student information
                Dim aStudent As New clsStudent
                aStudent.broncoID = rdr("BRONCO_ID")
                aStudent.firstName = rdr("FIRST_NAME")
                aStudent.lastName = rdr("LAST_NAME")
                aStudent.email = rdr("EMAIL")
                aStudent.phone = rdr("PHONE")

                studentList.Add(aStudent)
            Loop
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return studentList
    End Function

    Public Shared Function loadSummary() As List(Of clsSummary)
        'List of students that will be returned
        Dim studentList As New List(Of clsSummary)

        'DB variables
        Dim strView As String = ""
        Dim strSQL As String = ""
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""

        Try
            strSQL = "Select CPP_CATALOG.YEAR,CPP_CATALOG.QUARTER,CPP_STUDENTS.BRONCO_ID,CPP_STUDENTS.FIRST_NAME,CPP_STUDENTS.LAST_NAME,CPP_STUDENTS.PHONE," &
                "CPP_STUDENTS.EMAIL,CPP_COURSES.COURSE_ID,CPP_COURSES.DESCRIPTION,CPP_COURSES.UNITS,CPP_INSTRUCTORS.FIRST_NAME as INSTR_FIRST," &
                "CPP_INSTRUCTORS.LAST_NAME as INSTR_LAST,CPP_INSTRUCTORS.PHONE as INSTR_PHONE,CPP_INSTRUCTORS.DEPARTMENT From CPP_CATALOG,CPP_STUDENTS," &
                "CPP_COURSES,CPP_INSTRUCTORS,CPP_ENROLLMENT Where (CPP_STUDENTS.BRONCO_ID = CPP_ENROLLMENT.BRONCO_ID) and" &
                "(CPP_ENROLLMENT.CATALOG_ID = CPP_CATALOG.CATALOG_ID) and (CPP_CATALOG.COURSE_ID = CPP_COURSES.COURSE_ID) and (CPP_CATALOG.PROF_ID = CPP_INSTRUCTORS.PROF_ID)"

            dbConnect()
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()

            Do While rdr.Read()
                'Add basic student information
                Dim aStudent As New clsSummary
                aStudent.year = rdr("YEAR")
                aStudent.quarter = rdr("QUARTER")

                aStudent.broncoID = rdr("BRONCO_ID")
                aStudent.firstName = rdr("FIRST_NAME")
                aStudent.lastName = rdr("LAST_NAME")
                aStudent.email = rdr("EMAIL")
                aStudent.phone = rdr("PHONE")

                aStudent.courseID = rdr("COURSE_ID")
                aStudent.description = rdr("DESCRIPTION")
                aStudent.units = rdr("UNITS")

                aStudent.profFirstName = rdr("INSTR_FIRST")
                aStudent.profLastName = rdr("INSTR_LAST")
                aStudent.profPhone = rdr("INSTR_PHONE")
                aStudent.department = rdr("DEPARTMENT")

                studentList.Add(aStudent)
            Loop
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return studentList
    End Function

    Public Shared Function deleteCatalog(strStudentID As String) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            strSQL = "Delete from CPP_CATALOG where CATALOG_ID = '" & strStudentID & "'"

            dbConnect()
            cmd.Connection = cn
            cmd.CommandText = strSQL

            intResult = cmd.ExecuteNonQuery()

            If (intResult < 1) Then
                dbAddError("DELETE Failed, Catalog ID " & strStudentID & " was not found!")
            End If

            dbClose()
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Function deleteCourse(strStudentID As String) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            strSQL = "Delete from CPP_COURSES where COURSE_ID = '" & strStudentID & "'"

            dbConnect()
            cmd.Connection = cn
            cmd.CommandText = strSQL

            intResult = cmd.ExecuteNonQuery()

            If (intResult < 1) Then
                dbAddError("DELETE Failed, Course ID " & strStudentID & " was not found!")
            End If

            dbClose()
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Function deleteEnrollment(strStudentID As String) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            strSQL = "Delete from CPP_ENROLLMENT where BRONCO_ID = '" & strStudentID & "'"

            dbConnect()
            cmd.Connection = cn
            cmd.CommandText = strSQL

            intResult = cmd.ExecuteNonQuery()

            If (intResult < 1) Then
                dbAddError("DELETE Failed, Student id " & strStudentID & " was not found!")
            End If

            dbClose()
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Function deleteInstructor(strStudentID As String) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            strSQL = "Delete from CPP_INSTRUCTORS where PROF_ID = '" & strStudentID & "'"

            dbConnect()
            cmd.Connection = cn
            cmd.CommandText = strSQL

            intResult = cmd.ExecuteNonQuery()

            If (intResult < 1) Then
                dbAddError("DELETE Failed, Instructor ID " & strStudentID & " was not found!")
            End If

            dbClose()
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Function deleteStudent(strStudentID As String) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            strSQL = "Delete from CPP_STUDENTS where BRONCO_ID = '" & strStudentID & "'"

            dbConnect()
            cmd.Connection = cn
            cmd.CommandText = strSQL

            intResult = cmd.ExecuteNonQuery()

            If (intResult < 1) Then
                dbAddError("DELETE Failed, Student id " & strStudentID & " was not found!")
            End If

            dbClose()
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Sub updateCatalog(aStudent As clsCatalog)
        strError = ""

        'To update we remove old catalog and add new catalog
        'there are other ways to do this as well using the update statement
        deleteCatalog(aStudent.catalogID)
        insertCatalog(aStudent)

        If strError <> "" Then
            strError = "Could not Update catalog " & aStudent.catalogID & vbCrLf & vbCrLf & strError
        End If
    End Sub

    Public Shared Sub updateCourse(aStudent As clsCourse)
        strError = ""

        'To update we remove old student and add new student
        'there are other ways to do this as well using the update statement
        deleteCourse(aStudent.courseID)
        insertCourse(aStudent)

        If strError <> "" Then
            strError = "Could not Update courses " & aStudent.courseID & vbCrLf & vbCrLf & strError
        End If
    End Sub

    Public Shared Sub updateEnrollment(aStudent As clsEnrollment)
        strError = ""

        'To update we remove old student and add new student
        'there are other ways to do this as well using the update statement
        deleteEnrollment(aStudent.broncoID)
        insertEnrollment(aStudent)

        If strError <> "" Then
            strError = "Could not Update enrollment " & aStudent.broncoID & vbCrLf & vbCrLf & strError
        End If
    End Sub

    Public Shared Sub updateInstructor(aStudent As clsInstructor)
        strError = ""

        'To update we remove old instructor and add new instructor
        'there are other ways to do this as well using the update statement
        deleteInstructor(aStudent.profID)
        insertInstructor(aStudent)

        If strError <> "" Then
            strError = "Could not Update enrollment " & aStudent.profID & vbCrLf & vbCrLf & strError
        End If
    End Sub

    Public Shared Sub updateStudent(aStudent As clsStudent)
        strError = ""

        'To update we remove old student and add new student
        'there are other ways to do this as well using the update statement
        deleteStudent(aStudent.broncoID)
        insertStudent(aStudent)

        If strError <> "" Then
            strError = "Could not Update enrollment " & aStudent.broncoID & vbCrLf & vbCrLf & strError
        End If
    End Sub

    Public Shared Function insertCatalog(aStudent As clsCatalog) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strStudentSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strStudentSQL = "INSERT INTO CPP_CATALOG (CATALOG_ID, YEAR, QUARTER, COURSE_ID, PROF_ID) " & _
                            "values('" & aStudent.catalogID & "','" & aStudent.year & "','" & aStudent.quarter & "','" & aStudent.courseID & "', '" & _
                            aStudent.profID & "')"

            cmd.Connection = cn
            cmd.CommandText = strStudentSQL
            cmd.ExecuteNonQuery()

            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Function insertCourse(aStudent As clsCourse) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strStudentSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strStudentSQL = "INSERT INTO CPP_COURSES (COURSE_ID, DESCRIPTION, UNITS) " & _
                            "values('" & aStudent.courseID & "','" & aStudent.description & "','" & aStudent.units & "')"

            cmd.Connection = cn
            cmd.CommandText = strStudentSQL
            cmd.ExecuteNonQuery()

            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Function insertEnrollment(aStudent As clsEnrollment) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strStudentSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strStudentSQL = "INSERT INTO CPP_ENROLLMENT (BRONCO_ID, CATALOG_ID) " & _
                            "values('" & aStudent.broncoID & "','" & aStudent.catalogID & "')"

            cmd.Connection = cn
            cmd.CommandText = strStudentSQL
            cmd.ExecuteNonQuery()

            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Function insertInstructor(aStudent As clsInstructor) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strStudentSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strStudentSQL = "INSERT INTO CPP_INSTRUCTORS (PROF_ID, FIRST_NAME, LAST_NAME, PHONE, DEPARTMENT) " & _
                            "values('" & aStudent.profID & "','" & aStudent.firstName & "','" & aStudent.lastName & "','" & aStudent.phone & "', '" & _
                            aStudent.department & "')"

            cmd.Connection = cn
            cmd.CommandText = strStudentSQL
            cmd.ExecuteNonQuery()

            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Function insertStudent(aStudent As clsStudent) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strStudentSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strStudentSQL = "INSERT INTO CPP_STUDENTS (BRONCO_ID, FIRST_NAME, LAST_NAME, PHONE, EMAIL) " & _
                            "values('" & aStudent.broncoID & "','" & aStudent.firstName & "','" & aStudent.lastName & "','" & aStudent.phone & "', '" & _
                            aStudent.email & "')"

            cmd.Connection = cn
            cmd.CommandText = strStudentSQL
            cmd.ExecuteNonQuery()

            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Function findCatalog(strStudentID As String) As clsCatalog
        'catalog that will be returned
        Dim aStudent As clsCatalog = New clsCatalog

        'db variables
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim strSQL As String

        'clear error
        strError = ""

        Try
            Dim MyData As New ArrayList

            strSQL = "Select * From CPP_CATALOG Where ID = '" & strStudentID & "'"
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text

            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                aStudent.catalogID = rdr("CATALOG_ID")
                aStudent.year = rdr("YEAR")
                aStudent.quarter = rdr("QUARTER")
                aStudent.courseID = rdr("COURSE_ID")
                aStudent.profID = rdr("PROF_ID")
            Else
                dbAddError("Catalog not found")
            End If

        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try

        Return aStudent
    End Function

    Public Shared Function findCourse(strStudentID As String) As clsCourse
        'course that will be returned
        Dim aStudent As clsCourse = New clsCourse

        'db variables
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim strSQL As String

        'clear error
        strError = ""

        Try
            Dim MyData As New ArrayList

            strSQL = "Select * From CPP_COURSES Where ID = '" & strStudentID & "'"
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text

            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                aStudent.courseID = rdr("COURSE_ID")
                aStudent.description = rdr("DESCRIPTION")
                aStudent.units = rdr("UNITS")
            Else
                dbAddError("Course not found")
            End If

        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try

        Return aStudent
    End Function

    Public Shared Function findEnrollment(strStudentID As String) As clsEnrollment
        'Enrollment that will be returned
        Dim aStudent As clsEnrollment = New clsEnrollment

        'db variables
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim strSQL As String

        'clear error
        strError = ""

        Try
            Dim MyData As New ArrayList

            strSQL = "Select * From CPP_ENROLLMENT Where ID = '" & strStudentID & "'"
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text

            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                aStudent.broncoID = rdr("BRONCO_ID")
                aStudent.catalogID = rdr("CATALOG_ID")
            Else
                dbAddError("Enrollment not found")
            End If

        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try

        Return aStudent
    End Function

    Public Shared Function findInstructor(strProfID As String) As clsInstructor
        'student that will be returned
        Dim aStudent As clsInstructor = New clsInstructor

        'db variables
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim strSQL As String

        'clear error
        strError = ""

        Try
            Dim MyData As New ArrayList

            strSQL = "Select * From CPP_INSTRUCTORS Where ID = '" & strProfID & "'"
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text

            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                aStudent.profID = rdr("PROF_ID")
                aStudent.firstName = rdr("FIRST_NAME")
                aStudent.lastName = rdr("LAST_NAME")
                aStudent.phone = rdr("PHONE")
                aStudent.department = rdr("DEPARTMENT")
            Else
                dbAddError("Instructor not found")
            End If

        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try

        Return aStudent
    End Function

    Public Shared Function findStudent(strStudentID As String) As clsStudent
        'student that will be returned
        Dim aStudent As clsStudent = New clsStudent

        'db variables
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim strSQL As String

        'clear error
        strError = ""

        Try
            Dim MyData As New ArrayList

            strSQL = "Select * From CPP_STUDENT Where ID = '" & strStudentID & "'"
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text

            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                aStudent.broncoID = rdr("BRONCO_ID")
                aStudent.firstName = rdr("FIRST_NAME")
                aStudent.lastName = rdr("LAST_NAME")
                aStudent.email = rdr("EMAIL")
                aStudent.phone = rdr("PHONE")
            Else
                dbAddError("Student not found")
            End If

        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try

        Return aStudent
    End Function

    Public Shared Sub dbOpen()
        'Only assign one reference to the connection
        If IsNothing(cn) Then
            cn = New SqlConnection
            'EXAMPLE OF CONNECTION STRING TO A SQL SERVER INSTANCE
            'cn.ConnectionString = "Data Source=SKYNET\SQLEXPRESS;Initial Catalog=CPP;Integrated Security=True"

            'EXAMPLE OF CONNECTION TO A LOCAL DATABASE FILE. YOU MIGHT NEED TO ADJUST THE CONNECTION STRING
            'BASED ON YOUR PROJECT DATABASE VERSION. 
            cn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CPP.mdf;Integrated Security=True"

        End If
    End Sub

    Public Shared Sub dbConnect()
        'Only open if connection is closed
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
    End Sub

    Public Shared Sub dbClose()
        'Only close if open
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Private Shared Sub dbAddError(ByVal s As String)
        'build error
        If strError = "" Then
            strError = s
        Else
            strError += vbCrLf & s
        End If
    End Sub

    Public Shared Function dbGetError() As String
        'return error
        Return strError
    End Function
End Class
