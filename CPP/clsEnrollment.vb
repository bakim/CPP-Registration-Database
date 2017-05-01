Public Class clsEnrollment
    Private strBroncoID As String
    Private strCatalogID As String

    Public Property broncoID() As String
        Get
            Return strBroncoID
        End Get
        Set(ByVal value As String)
            strBroncoID = value
        End Set
    End Property

    Public Property catalogID() As String
        Get
            Return strCatalogID
        End Get
        Set(ByVal value As String)
            strCatalogID = value
        End Set
    End Property

End Class
