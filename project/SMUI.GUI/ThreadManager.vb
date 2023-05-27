Imports System.Threading

Public Class ThreadManager
    Public Threads As List(Of Thread)
    Public SyncContext As SynchronizationContext

    Public Sub New()
        threads = New List(Of Thread)()
        syncContext = SynchronizationContext.Current
    End Sub

    Public Sub StartThreads(threadCount As Integer)
        For i As Integer = 1 To threadCount
            Dim thread As New Thread(AddressOf DoWork)
            threads.Add(thread)
            thread.Start(i)
        Next
    End Sub

    Public Sub DoWork()

    End Sub

    'SyncContext.Post(AddressOf UpdateUI, parameter)

    Public Sub StopThreads()
        For Each thread As Thread In threads
            thread.Abort()
        Next
        threads.Clear()
    End Sub

End Class
