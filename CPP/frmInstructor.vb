Public Class frmInstructor

    Dim instructorList As New List(Of clsInstructor)

    Private Sub frmInstructor_Load(sender As Object, e As EventArgs) Handles Me.Load
        'LOAD FROM DB
        CPP_DB.dbOpen()
        instructorList = CPP_DB.loadInstructors()
        CPP_DB.dbClose()

        'check errors
        If (CPP_DB.dbGetError = "") Then
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If
    End Sub

    Private Sub refreshDataGrid()
        'CREATE A BINDING SOURCE AND 
        Dim StudentBindingSource As New BindingSource

        'ASSIGN THE DATAROUCE TO THE INSTRUCTOR LIST
        StudentBindingSource.DataSource = instructorList

        'SET THE GRID DATASOURCE TO THE BINDING SOURCE
        Me.CPP_INSTRUCTORSDataGridView.DataSource = StudentBindingSource
    End Sub

    Public Sub setMode(strMode As String)
        'CONTROL THE DISPLAY OF LIST VS DETAIL OF INSTRUCTOR
        If strMode = "L" Then
            'MODE IS LIST
            Me.gbInstructorDetail.Hide()
            Me.gbInstructorList.Left = 0
            Me.gbInstructorList.Top = 0
            Me.Width = gbInstructorList.Width + 50
            Me.Height = gbInstructorList.Height + 50
            Me.gbInstructorList.Visible = True
        Else
            'MODE IS DETAIL
            Me.gbInstructorList.Hide()
            Me.gbInstructorDetail.Left = 0
            Me.gbInstructorDetail.Top = 0
            Me.Width = gbInstructorDetail.Width + 50
            Me.Height = gbInstructorDetail.Height + 50
            Me.gbInstructorDetail.Visible = True
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'create an instructor object
        Dim anInstructor As New clsInstructor

        'populate instructor
        anInstructor.profID = Me.PROF_IDTextBox.Text
        anInstructor.firstName = Me.FIRST_NAMETextBox.Text
        anInstructor.lastName = Me.LAST_NAMETextBox.Text
        anInstructor.phone = Me.PHONETextBox.Text
        anInstructor.department = Me.DEPARTMENTTextBox.Text

        If clsValidator.getError() <> "" Then
            MessageBox.Show(clsValidator.getError)
            Exit Sub
        End If

        'check if saving or updating
        If (btnSave.Text = "&Save") Then

            'save instructor
            CPP_DB.dbOpen()
            CPP_DB.insertInstructor(anInstructor)
            CPP_DB.dbClose()

            'check for errors
            If CPP_DB.dbGetError <> "" Then
                MessageBox.Show(CPP_DB.dbGetError)
            Else
                instructorList.Add(anInstructor)                       'add instructor
                refreshDataGrid()
                MessageBox.Show("Instructor Saved!")
                Me.setMode("L")                                 'SWITCH TO LIST MODE
            End If
        Else

            'update instructor
            CPP_DB.dbOpen()
            CPP_DB.updateInstructor(anInstructor)
            CPP_DB.dbClose()

            'CHECK FOR ERRORS
            If CPP_DB.dbGetError <> "" Then
                MessageBox.Show(CPP_DB.dbGetError)
            Else
                'remove instructor
                For Each student In instructorList
                    If student.profID = anInstructor.profID Then
                        instructorList.Remove(student)
                        Exit For
                    End If
                Next
                instructorList.Add(anInstructor)                       'add instructor
                refreshDataGrid()
                MessageBox.Show("Instructor Updated!")
                Me.setMode("L")                                 'SWITCH TO LIST MODE
                Me.btnSave.Text = "&Save"                       'MAKE SURE WE SET THE SAVE BUTTON BACK TO DEFAULT
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'clear controls
        For Each ctrl In gbInstructorDetail.Controls
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
        Me.PROF_IDTextBox.Focus()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'get instructor
        Dim row As DataGridViewRow = Me.CPP_INSTRUCTORSDataGridView.CurrentRow

        'validate
        If IsNothing(row) Then
            MessageBox.Show("Nothing Selected!")
            Exit Sub
        End If

        'convert row to instructor
        Dim aStudent As clsInstructor = TryCast(row.DataBoundItem, clsInstructor)

        'retrieve data from textboxes
        Me.PROF_IDTextBox.Text = aStudent.profID
        Me.FIRST_NAMETextBox.Text = aStudent.firstName
        Me.LAST_NAMETextBox.Text = aStudent.lastName
        Me.PHONETextBox.Text = aStudent.phone
        Me.DEPARTMENTTextBox.Text = aStudent.department

        'SET THE FOCUS ON ID
        Me.PROF_IDTextBox.Focus()

        'SWITCH SAVE TO UPDATE
        Me.btnSave.Text = "&Update"

        'DISPLAY DETAIL MODE
        Me.setMode("D")
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim row As DataGridViewRow = Me.CPP_INSTRUCTORSDataGridView.CurrentRow

        'validate
        If IsNothing(row) Then
            MessageBox.Show("Please select an instructor")
            Exit Sub
        End If

        'convert row to instructor
        Dim aStudent As clsInstructor = TryCast(row.DataBoundItem, clsInstructor)

        'delete instructor
        CPP_DB.dbOpen()
        CPP_DB.deleteInstructor(aStudent.profID)
        CPP_DB.dbClose()

        'check for errors
        If CPP_DB.dbGetError = "" Then
            MessageBox.Show("Instructor deleted")
            'remove instructor
            For Each student In instructorList
                If student.profID = aStudent.profID Then
                    instructorList.Remove(student)
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
        Dim strProfId As String = InputBox("Enter Instructor ID")

        For Each row As DataGridViewRow In CPP_INSTRUCTORSDataGridView.Rows
            If row.Cells(0).Value = strProfId And row.Cells(0).Value <> "" Then
                row.Selected = True
                MessageBox.Show("Instructor found")
                Exit Sub
            End If
        Next

        MessageBox.Show("Instructor not found")
    End Sub
End Class