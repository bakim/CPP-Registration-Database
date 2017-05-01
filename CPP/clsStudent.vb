Public Class clsStudent
    Private strBroncoId As String
    Private strFirstName As String
    Private strLastName As String
    Private strPhone As String
    Private strEmail As String

    Public Property broncoID As String
        Get
            Return strBroncoId
        End Get
        Set(value As String)
            strBroncoId = value
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

End Class
