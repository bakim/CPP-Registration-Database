Public Class clsSummary
    Private strYear As String
    Private strQuarter As String

    Private strBroncoID As String
    Private strFirstName As String
    Private strLastName As String
    Private strPhone As String
    Private strEmail As String

    Private strCourseID As String
    Private strDescription As String
    Private strUnits As String

    Private strProfFirstName As String
    Private strProfLastName As String
    Private strProfPhone As String
    Private strDepartment As String

    Public Property year As String
        Get
            Return strYear
        End Get
        Set(value As String)
            strYear = value
        End Set
    End Property
    Public Property quarter As String
        Get
            Return strQuarter
        End Get
        Set(value As String)
            strQuarter = value
        End Set
    End Property

    Public Property broncoID As String
        Get
            Return strBroncoID
        End Get
        Set(value As String)
            strBroncoID = value
        End Set
    End Property

    Public Property firstName As String
        Get
            Return strFirstName
        End Get
        Set(value As String)
            strFirstName = value
        End Set
    End Property
    Public Property lastName As String
        Get
            Return strLastName
        End Get
        Set(value As String)
            strLastName = value
        End Set
    End Property

    Public Property phone As String
        Get
            Return strPhone
        End Get
        Set(value As String)
            strPhone = value
        End Set
    End Property

    Public Property email As String
        Get
            Return strEmail
        End Get
        Set(value As String)
            strEmail = value
        End Set
    End Property

    Public Property courseID As String
        Get
            Return strCourseID
        End Get
        Set(value As String)
            strCourseID = value
        End Set
    End Property

    Public Property description As String
        Get
            Return strDescription
        End Get
        Set(value As String)
            strDescription = value
        End Set
    End Property

    Public Property units As String
        Get
            Return strUnits
        End Get
        Set(value As String)
            strUnits = value
        End Set
    End Property

    Public Property profFirstName As String
        Get
            Return strProfFirstName
        End Get
        Set(value As String)
            strProfFirstName = value
        End Set
    End Property

    Public Property profLastName As String
        Get
            Return strProfLastName
        End Get
        Set(value As String)
            strProfLastName = value
        End Set
    End Property

    Public Property profPhone As String
        Get
            Return strProfPhone
        End Get
        Set(value As String)
            strProfPhone = value
        End Set
    End Property

    Public Property department As String
        Get
            Return strDepartment
        End Get
        Set(value As String)
            strDepartment = value
        End Set
    End Property

End Class