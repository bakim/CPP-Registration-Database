Public Class clsInstructor
    Private strProfID As String
    Private strFirstName As String
    Private strLastName As String
    Private strPhone As String
    Private strDepartment As String

    Public Property profID() As String
        Get
            Return strProfID
        End Get
        Set(ByVal value As String)
            strProfID = value
        End Set
    End Property

    Public Property firstName() As String
        Get
            Return strFirstName
        End Get
        Set(ByVal value As String)
            strFirstName = value
        End Set
    End Property

    Public Property lastName() As String
        Get
            Return strLastName
        End Get
        Set(ByVal value As String)
            strLastName = value
        End Set
    End Property

    Public Property phone() As String
        Get
            Return strPhone
        End Get
        Set(ByVal value As String)
            strPhone = value
        End Set
    End Property

    Public Property department() As String
        Get
            Return strDepartment
        End Get
        Set(ByVal value As String)
            strDepartment = value
        End Set
    End Property

End Class
