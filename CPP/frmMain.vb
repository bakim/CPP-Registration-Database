Public Class frmMain

    Private Sub StudentEnrollmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentEnrollmentToolStripMenuItem.Click
        Dim f As New frmEnrollment()
        f.MdiParent = Me
        f.setMode("L")
        f.Show()
    End Sub

    Private Sub StudentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentsToolStripMenuItem.Click
        Dim f As New frmStudent()
        f.MdiParent = Me
        f.setMode("L")
        f.Show()
    End Sub

    Private Sub CourseCatalogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CourseCatalogToolStripMenuItem.Click
        Dim f As New frmCatalog
        f.MdiParent = Me
        f.setMode("L")
        f.Show()
    End Sub

    Private Sub InstructorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstructorToolStripMenuItem.Click
        Dim f As New frmInstructor
        f.MdiParent = Me
        f.setMode("L")
        f.Show()
    End Sub

    Private Sub CoursesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CoursesToolStripMenuItem.Click
        Dim f As New frmCourse
        f.MdiParent = Me
        f.setMode("L")
        f.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim message As String = "CPP Enrollment" + vbCrLf + "Author: Bryan Kim" + vbCrLf + "Email: bakim@cpp.edu"
        MessageBox.Show(message, "Contact Information")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub StudentSummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentSummaryToolStripMenuItem.Click
        Dim f As New frmSummary
        f.MdiParent = Me
        f.setMode("L")
        f.Show()
    End Sub
End Class