Public Class frmCatalog

    Dim studentList As New List(Of clsCatalog)
    Dim courseList As New List(Of clsCourse)
    Dim profList As New List(Of clsInstructor)

    Private Sub frmCatalog_Load(sender As Object, e As EventArgs) Handles Me.Load
        'LOAD FROM DB
        CPP_DB.dbOpen()
        studentList = CPP_DB.loadCatalogs()
        CPP_DB.dbClose()

        CPP_DB.dbOpen()
        courseList = CPP_DB.loadCourse()
        CPP_DB.dbClose()

        CPP_DB.dbOpen()
        profList = CPP_DB.loadInstructors()
        CPP_DB.dbClose()

        Dim courseInfo As New List(Of String)
        For Each aCourse As clsCourse In courseList
            courseInfo.Add(aCourse.courseID & "-(" & aCourse.description & ")")
        Next

        COURSE_IDComboBox.DataSource = courseInfo

        Dim profInfo As New List(Of String)

        For Each aProf As clsInstructor In profList
            profInfo.Add(aProf.profID & "-(" & aProf.firstName & ", " & aProf.lastName & ")")
        Next

        PROF_IDComboBox.DataSource = profInfo

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

        'ASSIGN THE DATAROUCE TO THE STUDENT LIST
        StudentBindingSource.DataSource = studentList

        'SET THE GRID DATASOURCE TO THE BINDING SOURCE
        Me.CPP_CATALOGDataGridView.DataSource = StudentBindingSource
    End Sub

    Public Sub setMode(strMode As String)
        'CONTROL THE DISPLAY OF LIST VS DETAIL OF CatalogS

        If strMode = "L" Then
            'MODE IS LIST

            Me.gbCatalogDetail.Hide()
            Me.gbCatalogList.Left = 0
            Me.gbCatalogList.Top = 0
            Me.Width = gbCatalogList.Width + 50
            Me.Height = gbCatalogList.Height + 50

            Me.gbCatalogList.Visible = True
        Else
            'MODE IS DETAIL

            Me.gbCatalogList.Hide()
            Me.gbCatalogDetail.Left = 0
            Me.gbCatalogDetail.Top = 0
            Me.Width = gbCatalogDetail.Width + 50
            Me.Height = gbCatalogDetail.Height + 50

            Me.gbCatalogDetail.Visible = True
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Me.setMode("D")
        Me.CATALOG_IDTextBox.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'create catalog
        Dim aStudent As New clsCatalog

        'populate catalog
        aStudent.catalogID = Me.CATALOG_IDTextBox.Text
        aStudent.year = Me.YEARTextBox.Text
        aStudent.quarter = Me.QUARTERComboBox.Text
        aStudent.courseID = COURSE_IDComboBox.Text.Split(" - ").GetValue(0)
        aStudent.profID = PROF_IDComboBox.Text.Split(" - ").GetValue(0)

        If clsValidator.getError() <> "" Then
            MessageBox.Show(clsValidator.getError)
            Exit Sub
        End If

        'check if saving or updating
        If (btnSave.Text = "&Save") Then

            'save catalog
            CPP_DB.dbOpen()
            CPP_DB.insertCatalog(aStudent)
            CPP_DB.dbClose()

            'check for errors
            If CPP_DB.dbGetError <> "" Then
                MessageBox.Show(CPP_DB.dbGetError)
            Else
                studentList.Add(aStudent)                       'add catalog
                refreshDataGrid()
                MessageBox.Show("Catalog Saved!")
                Me.setMode("L")                                 'SWITCH TO LIST MODE
            End If
        Else

            'update catlog
            CPP_DB.dbOpen()
            CPP_DB.updateCatalog(aStudent)
            CPP_DB.dbClose()

            'check for errors
            If CPP_DB.dbGetError <> "" Then
                MessageBox.Show(CPP_DB.dbGetError)
            Else
                'remove catalog
                For Each student In studentList
                    If student.catalogID = aStudent.catalogID Then
                        studentList.Remove(student)
                        Exit For
                    End If
                Next
                studentList.Add(aStudent)                       'add catalog
                refreshDataGrid()
                MessageBox.Show("Student Updated!")
                Me.setMode("L")                                 'SWITCH TO LIST MODE
                Me.btnSave.Text = "&Save"                       'MAKE SURE WE SET THE SAVE BUTTON BACK TO DEFAULT
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'clear controls
        For Each ctrl In gbCatalogDetail.Controls
            If TypeOf (ctrl) Is TextBox Then
                TryCast(ctrl, TextBox).Clear()
            ElseIf TypeOf (ctrl) Is ComboBox Then
                TryCast(ctrl, ComboBox).Text = ""
            End If
        Next

        'SET SAVE BUTTON TO DEFAULT 
        btnSave.Text = "&Save"

        'SWITCH TO LIST MODE
        setMode("L")
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'get catalog row
        Dim row As DataGridViewRow = Me.CPP_CATALOGDataGridView.CurrentRow

        'validate
        If IsNothing(row) Then
            MessageBox.Show("Nothing Selected!")
            Exit Sub
        End If

        'convert row to catalog
        Dim aStudent As clsCatalog = TryCast(row.DataBoundItem, clsCatalog)

        'retrieve data from textboxes
        Me.CATALOG_IDTextBox.Text = aStudent.catalogID
        Me.YEARTextBox.Text = aStudent.year
        Me.QUARTERComboBox.Text = aStudent.quarter
        Me.COURSE_IDComboBox.Text = aStudent.courseID
        Me.PROF_IDComboBox.Text = aStudent.profID

        'SET THE FOCUS ON ID
        Me.CATALOG_IDTextBox.Focus()

        'SWITCH SAVE TO UPDATE
        Me.btnSave.Text = "&Update"

        'DISPLAY DETAIL MODE
        Me.setMode("D")
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim row As DataGridViewRow = Me.CPP_CATALOGDataGridView.CurrentRow

        'validate
        If IsNothing(row) Then
            MessageBox.Show("Nothing selected!")
            Exit Sub
        End If

        'convert row to catalog
        Dim aStudent As clsCatalog = TryCast(row.DataBoundItem, clsCatalog)

        'delete catalog
        CPP_DB.dbOpen()
        CPP_DB.deleteCatalog(aStudent.catalogID)
        CPP_DB.dbClose()

        'check for errors
        If CPP_DB.dbGetError = "" Then
            MessageBox.Show("Catalog Deleted!")
            'remove catalog
            For Each student In studentList
                If student.catalogID = aStudent.catalogID Then
                    studentList.Remove(student)
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
        Dim strCatalogId As String = InputBox("Enter Catalog ID")

        For Each row As DataGridViewRow In CPP_CATALOGDataGridView.Rows
            If row.Cells(0).Value = strCatalogId And row.Cells(0).Value <> "" Then
                row.Selected = True 'CPP_CATALOGDataGridView.CurrentRow.
                MessageBox.Show("Catalog found")
                Exit Sub
            End If
        Next

        MessageBox.Show("Catalog not found")
    End Sub
End Class