Public Class clsCourse
    Private strCourseID As String
    Private strDescription As String
    Private strUnits As String

    Public Property courseID() As String
        Get
            Return strCourseID
        End Get
        Set(ByVal value As String)
            strCourseID = value
        End Set
    End Property

    Public Property description() As String
        Get
            Return strDescription
        End Get
        Set(ByVal value As String)
            strDescription = value
        End Set
    End Property

    Public Property units() As String
        Get
            Return strUnits
        End Get
        Set(ByVal value As String)
            strUnits = value
        End Set
    End Property

End Class
