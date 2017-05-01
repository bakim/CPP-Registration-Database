Public Class frmEnrollment

    Dim studentEnrollList As New List(Of clsEnrollment)
    Dim studentL As New List(Of clsStudent)
    Dim catalogList As New List(Of clsCatalog)

    Private Sub frmEnrollment_Load(sender As Object, e As EventArgs) Handles Me.Load
        'LOAD FROM DB
        CPP_DB.dbOpen()
        studentEnrollList = CPP_DB.loadEnrollments()
        CPP_DB.dbClose()

        CPP_DB.dbOpen()
        studentL = CPP_DB.loadStudents()
        CPP_DB.dbClose()

        CPP_DB.dbOpen()
        catalogList = CPP_DB.loadCatalogs()
        CPP_DB.dbClose()

        For i As Integer = 0 To studentL.Count - 1
            Me.BRONCO_IDComboBox.Items.Add(studentL(i).broncoID & " - " & studentL(i).firstName & " " & studentL(i).lastName)
        Next

        For i As Integer = 0 To catalogList.Count - 1
            Me.CATALOG_IDComboBox.Items.Add(catalogList(i).year & " - " & catalogList(i).quarter & " " & catalogList(i).courseID)
        Next

        'check for errors
        If (CPP_DB.dbGetError = "") Then
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If
    End Sub

    Private Sub refreshDataGrid()
        'CREATE A BINDING SOURCE AND
        Dim StudentBindingSource As New BindingSource

        'ASSIGN THE DATAROUCE TO THE STUDENT LIST
        StudentBindingSource.DataSource = studentEnrollList

        'SET THE GRID DATASOURCE TO THE BINDING SOURCE
        Me.CPP_ENROLLMENTDataGridView.DataSource = StudentBindingSource
    End Sub

    Public Sub setMode(strMode As String)
        'CONTROL THE DISPLAY OF LIST VS DETAIL OF EnrollmentS

        If strMode = "L" Then
            'MODE IS LIST

            Me.gbEnrollmentDetail.Hide()
            Me.gbEnrollmentList.Left = 0
            Me.gbEnrollmentList.Top = 0
            Me.Width = gbEnrollmentList.Width + 50
            Me.Height = gbEnrollmentList.Height + 50

            Me.gbEnrollmentList.Visible = True
        Else
            'MODE IS DETAIL

            Me.gbEnrollmentList.Hide()
            Me.gbEnrollmentDetail.Left = 0
            Me.gbEnrollmentDetail.Top = 0
            Me.Width = gbEnrollmentDetail.Width + 50
            Me.Height = gbEnrollmentDetail.Height + 50

            Me.gbEnrollmentDetail.Visible = True
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        setMode("D")
        Me.BRONCO_IDComboBox.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'create enrollment object
        Dim anEnrollment As New clsEnrollment

        'populate enrollments
        anEnrollment.broncoID = BRONCO_IDComboBox.Text.Split(" - ").GetValue(0)
        anEnrollment.catalogID = CATALOG_IDComboBox.Text.Split(" - ").GetValue(0)

        If clsValidator.getError() <> "" Then
            MessageBox.Show(clsValidator.getError)
            Exit Sub
        End If

        'check if saving or updating
        If (btnSave.Text = "&Save") Then

            'save enrollment
            CPP_DB.dbOpen()
            CPP_DB.insertEnrollment(anEnrollment)
            CPP_DB.dbClose()

            'validate input
            If CPP_DB.dbGetError <> "" Then
                MessageBox.Show(CPP_DB.dbGetError)
            Else
                studentEnrollList.Add(anEnrollment)                 'add new enrollment to list
                refreshDataGrid()
                MessageBox.Show("Enrollment saved")
                Me.setMode("L")                                 'SWITCH TO LIST MODE
            End If
        Else

            'update enrollments
            CPP_DB.dbOpen()
            CPP_DB.updateEnrollment(anEnrollment)
            CPP_DB.dbClose()

            'check for errors
            If CPP_DB.dbGetError <> "" Then
                MessageBox.Show(CPP_DB.dbGetError)
            Else
                'remove enrollment
                For Each student In studentEnrollList
                    If student.broncoID = anEnrollment.broncoID Then
                        studentEnrollList.Remove(student)
                        Exit For
                    End If
                Next
                studentEnrollList.Add(anEnrollment)                 'add new enrollment to list
                refreshDataGrid()
                MessageBox.Show("Enrollment updated")
                Me.setMode("L")                                 'SWITCH TO LIST MODE
                Me.btnSave.Text = "&Save"                       'MAKE SURE WE SET THE SAVE BUTTON BACK TO DEFAULT
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'clear controls
        For Each ctrl In gbEnrollmentDetail.Controls
            If TypeOf (ctrl) Is ComboBox Then
                TryCast(ctrl, ComboBox).Text = ""
            End If
        Next

        'SET SAVE BUTTON TO DEFAULT 
        btnSave.Text = "&Save"

        'SWITCH TO LIST MODE
        setMode("L")
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'get enrollment from grid
        Dim row As DataGridViewRow = Me.CPP_ENROLLMENTDataGridView.CurrentRow

        'validate row
        If IsNothing(row) Then
            MessageBox.Show("Please select an enrollment")
            Exit Sub
        End If

        'convert row to enrollment
        Dim aStudent As clsEnrollment = TryCast(row.DataBoundItem, clsEnrollment)

        'retrieve combobox data
        Me.BRONCO_IDComboBox.Text = aStudent.broncoID
        Me.CATALOG_IDComboBox.Text = aStudent.catalogID

        Me.BRONCO_IDComboBox.Focus()

        'turn save to update
        Me.btnSave.Text = "&Update"

        'DISPLAY DETAIL MODE
        Me.setMode("D")
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim row As DataGridViewRow = Me.CPP_ENROLLMENTDataGridView.CurrentRow

        'validate row
        If IsNothing(row) Then
            MessageBox.Show("Please select a row to delete")
            Exit Sub
        End If

        'convert row to enrollment
        Dim aStudent As clsStudent = TryCast(row.DataBoundItem, clsStudent)

        'delete
        CPP_DB.dbOpen()
        CPP_DB.deleteEnrollment(aStudent.broncoID)
        CPP_DB.dbClose()

        'validate errors
        If CPP_DB.dbGetError = "" Then
            MessageBox.Show("Enrollment deleted")
            'Remove enrollment from the list
            For Each student In studentEnrollList
                If student.broncoID = aStudent.broncoID Then
                    studentEnrollList.Remove(student)
                    Exit For
                End If
            Next
            'Update grid
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        'Find students enrolled in classes

        Dim strBroncoId As String = InputBox("Enter a Bronco ID")

        For Each row As DataGridViewRow In CPP_ENROLLMENTDataGridView.Rows
            If (row.Cells(0).Value = "") Then
                MessageBox.Show("Enrollment not found")
            ElseIf row.Cells(0).Value = strBroncoId Then
                row.Selected = True 'CPP_ENROLLMENTDataGridView.CurrentRow
                MessageBox.Show("Enrollment found")
                Exit Sub
            End If
        Next
    End Sub
End Class