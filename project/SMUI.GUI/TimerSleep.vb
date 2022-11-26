Imports System.Runtime.InteropServices

''' 抄于网络

Class TimerSleep
	Public Delegate Sub TimerCompleteDelegate()

	<DllImport("kernel32.dll")>
	Private Shared Function CreateWaitableTimer(lpTimerAttributes As IntPtr, bManualReset As Boolean, lpTimerName As String) As IntPtr
	End Function

	<DllImport("kernel32.dll")>
	Private Shared Function SetWaitableTimer(hTimer As IntPtr, <[In]> ByRef ft As Long, lPeriod As Integer, pfnCompletionRoutine As TimerCompleteDelegate, pArgToCompletionRoutine As IntPtr, fResume As Boolean) As Boolean
	End Function

	<DllImport("kernel32.dll", SetLastError:=True, CallingConvention:=CallingConvention.Winapi, CharSet:=CharSet.Auto)>
	Private Shared Function CloseHandle(hObject As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
	End Function

	<DllImport("User32.dll")>
	Private Shared Function MsgWaitForMultipleObjects(nCount As Integer, ByRef handle As IntPtr, fWaitAll As Boolean, dwMilliseconds As Integer, dwWakeMask As Integer) As Integer
	End Function

	Public Shared Function Sleep(time As Integer) As Boolean
		Dim TimerComplete As New TimerCompleteDelegate(AddressOf TimerCompleted)
		Dim Interval As Long = -10 * time * 1000
		Dim handle As IntPtr = CreateWaitableTimer(IntPtr.Zero, True, "WaitableTimer")
		SetWaitableTimer(handle, Interval, 0, TimerComplete, IntPtr.Zero, True)
		While MsgWaitForMultipleObjects(1, handle, False, -1, 255) <> 0
			Application.DoEvents()
		End While
		Return CloseHandle(handle)
	End Function

	Private Shared Sub TimerCompleted()

	End Sub

End Class
