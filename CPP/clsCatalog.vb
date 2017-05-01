Public Class clsCatalog
    Private strCatalogID As String
    Private strYear As String
    Private strQuarter As String
    Private strCourseID As String
    Private strProfID As String

    Public Property catalogID() As String
        Get
            Return strCatalogID
        End Get
        Set(ByVal value As String)
            strCatalogID = value
        End Set
    End Property

    Public Property year() As String
        Get
            Return strYear
        End Get
        Set(ByVal value As String)
            strYear = value
        End Set
    End Property

    Public Property quarter() As String
        Get
            Return strQuarter
        End Get
        Set(ByVal value As String)
            strQuarter = value
        End Set
    End Property

    Public Property courseID() As String
        Get
            Return strCourseID
        End Get
        Set(ByVal value As String)
            strCourseID = value
        End Set
    End Property

    Public Property profID() As String
        Get
            Return strProfID
        End Get
        Set(ByVal value As String)
            strProfID = value
        End Set
    End Property

End Class
