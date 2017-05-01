Imports System.Data.SqlClient

Public Class frmSummary
    Dim studentList As New List(Of clsSummary)

    Private Sub frmSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LOAD FROM DB
        CPP_DB.dbOpen()
        studentList = CPP_DB.loadSummary()
        CPP_DB.dbClose()

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
        StudentBindingSource.DataSource = studentList

        'SET THE GRID DATASOURCE TO THE BINDING SOURCE
        Me.CPP_SUMMARYDataGridView.DataSource = StudentBindingSource
    End Sub

    Public Sub setMode(strMode As String)
        'CONTROL THE DISPLAY OF LIST VS DETAIL OF STUDENTS
        If strMode = "L" Then
            'MODE IS LIST
            Me.gbSummary.Hide()
            Me.gbSummary.Left = 0
            Me.gbSummary.Top = 0
            Me.Width = gbSummary.Width + 20
            Me.Height = gbSummary.Height + 50
            Me.gbSummary.Visible = True
        Else
            'MODE IS DETAIL
            Me.gbSummary.Hide()
            Me.gbSummary.Left = 0
            Me.gbSummary.Top = 0
            Me.Width = gbSummary.Width + 50
            Me.Height = gbSummary.Height + 50
            Me.gbSummary.Visible = True
        End If
    End Sub
End Class