Public Class DeveloperEvent

    Public Shared Event StartLoadedEvent()
    Public Shared Sub Raise_StartLoadedEvent()
        RaiseEvent StartLoadedEvent()
    End Sub


    Public Shared Event SubLibraryListUpdatedEvent()
    Public Shared Sub Raise_SubLibraryListUpdatedEvent()
        RaiseEvent SubLibraryListUpdatedEvent()
    End Sub


    Public Shared Event CategoryListUpdatedEvent()
    Public Shared Sub Raise_CategoryListUpdatedEvent()
        RaiseEvent CategoryListUpdatedEvent()
    End Sub


    Public Shared Event CategoryListviewSelectedIndexChangedEvent()
    Public Shared Sub Raise_CategoryListviewSelectedIndexChangedEvent()
        RaiseEvent CategoryListviewSelectedIndexChangedEvent()
    End Sub


    Public Shared Event ItemListviewSelectedIndexChangedEvent()
    Public Shared Sub Raise_ItemListviewSelectedIndexChangedEvent()
        RaiseEvent ItemListviewSelectedIndexChangedEvent()
    End Sub

End Class
