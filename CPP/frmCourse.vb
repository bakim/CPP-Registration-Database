Public Class frmCourse

    Dim courseList As New List(Of clsCourse)

    Private Sub frmCourse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LOAD FROM DB
        CPP_DB.dbOpen()
        courseList = CPP_DB.loadCourse()
        CPP_DB.dbClose()

        'CHECK ERRORS
        If (CPP_DB.dbGetError = "") Then
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If
    End Sub

    Private Sub refreshDataGrid()
        'CREATE A BINDING SOURCE AND 
        Dim StudentBindingSource As New BindingSource

        'ASSIGN THE DATAROUCE TO THE COURSE LIST
        StudentBindingSource.DataSource = courseList

        'SET THE GRID DATASOURCE TO THE BINDING SOURCE
        Me.CPP_COURSESDataGridView.DataSource = StudentBindingSource
    End Sub

    Public Sub setMode(strMode As String)
        'CONTROL THE DISPLAY OF LIST VS DETAIL OF COURSE
        If strMode = "L" Then
            'MODE IS LIST
            Me.gbCourseDetail.Hide()
            Me.gbCourseList.Left = 0
            Me.gbCourseList.Top = 0
            Me.Width = gbCourseList.Width + 50
            Me.Height = gbCourseList.Height + 50
            Me.gbCourseList.Visible = True
        Else
            'MODE IS DETAIL
            Me.gbCourseList.Hide()
            Me.gbCourseDetail.Left = 0
            Me.gbCourseDetail.Top = 0
            Me.Width = gbCourseDetail.Width + 50
            Me.Height = gbCourseDetail.Height + 50
            Me.gbCourseDetail.Visible = True
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'create course object
        Dim aStudent As New clsCourse

        'populate student
        aStudent.courseID = Me.COURSE_IDTextBox.Text
        aStudent.description = Me.DESCRIPTIONTextBox.Text
        aStudent.units = Me.UNITSTextBox.Text

        If clsValidator.getError() <> "" Then
            MessageBox.Show(clsValidator.getError)
            Exit Sub
        End If

        'check if saving or updating
        If (btnSave.Text = "&Save") Then

            'save student
            CPP_DB.dbOpen()
            CPP_DB.insertCourse(aStudent)
            CPP_DB.dbClose()

            'check for errors
            If CPP_DB.dbGetError <> "" Then
                MessageBox.Show(CPP_DB.dbGetError)
            Else
                courseList.Add(aStudent)                        'add course
                refreshDataGrid()
                MessageBox.Show("Course Saved!")
                Me.setMode("L")                                 'SWITCH TO LIST MODE
            End If
        Else

            'update course
            CPP_DB.dbOpen()
            CPP_DB.updateCourse(aStudent)
            CPP_DB.dbClose()

            'check for errors
            If CPP_DB.dbGetError <> "" Then
                MessageBox.Show(CPP_DB.dbGetError)
            Else
                'remove course
                For Each student In courseList
                    If student.courseID = aStudent.courseID Then
                        courseList.Remove(student)
                        Exit For
                    End If
                Next
                courseList.Add(aStudent)                        'add new course
                refreshDataGrid()
                MessageBox.Show("Course Updated!")
                Me.setMode("L")                                 'SWITCH TO LIST MODE
                Me.btnSave.Text = "&Save"                       'MAKE SURE WE SET THE SAVE BUTTON BACK TO DEFAULT
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'clear controls
        For Each ctrl In gbCourseDetail.Controls
            If TypeOf (ctrl) Is TextBox Then
                TryCast(ctrl, TextBox).Clear()
            End If
        Next

        'SET SAVE BUTTON TO DEFAULT 
        btnSave.Text = "&Save"

        'SWITCH TO LIST MODE
        setMode("L")
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'SWITCH TO DETAIL DATA ENTRY
        Me.setMode("D")
        Me.COURSE_IDTextBox.Focus()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'get course row
        Dim row As DataGridViewRow = Me.CPP_COURSESDataGridView.CurrentRow

        'validate
        If IsNothing(row) Then
            MessageBox.Show("Nothing Selected!")
            Exit Sub
        End If

        'convert row to course
        Dim aStudent As clsCourse = TryCast(row.DataBoundItem, clsCourse)

        'retrieve data from textboxes
        Me.COURSE_IDTextBox.Text = aStudent.courseID
        Me.DESCRIPTIONTextBox.Text = aStudent.description
        Me.UNITSTextBox.Text = aStudent.units

        'SET THE FOCUS ON ID
        Me.COURSE_IDTextBox.Focus()

        'SWITCH SAVE TO UPDATE
        Me.btnSave.Text = "&Update"

        'DISPLAY DETAIL MODE
        Me.setMode("D")
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim row As DataGridViewRow = Me.CPP_COURSESDataGridView.CurrentRow

        'validate
        If IsNothing(row) Then
            MessageBox.Show("Nothing selected!")
            Exit Sub
        End If

        'convert row to course
        Dim aStudent As clsCourse = TryCast(row.DataBoundItem, clsCourse)

        'delete course
        CPP_DB.dbOpen()
        CPP_DB.deleteCourse(aStudent.courseID)
        CPP_DB.dbClose()

        'check for errors
        If CPP_DB.dbGetError = "" Then
            MessageBox.Show("Course Deleted!")
            'remove course
            For Each student In courseList
                If student.courseID = aStudent.courseID Then
                    courseList.Remove(student)
                    Exit For
                End If
            Next
            'UPDATE GRID
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Dim strCourseId As String = InputBox("Enter Course ID")

        For Each row As DataGridViewRow In CPP_COURSESDataGridView.Rows
            If row.Cells(0).Value = strCourseId And row.Cells(0).Value <> "" Then
                row.Selected = True
                MessageBox.Show("Course found")
                Exit Sub
            End If
        Next

        MessageBox.Show("Course not found")
    End Sub
End Class