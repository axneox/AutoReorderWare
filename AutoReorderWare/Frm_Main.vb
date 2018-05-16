Imports System.Runtime.InteropServices

Public Class Frm_Main
    Const HWND_TOPMOST = -1
    Const HWND_NOTOPMOST = -2
    Const SWP_NOSIZE = &H1
    Const SWP_NOMOVE = &H2
    Const SWP_NOACTIVATE = &H10
    Const SWP_SHOWWINDOW = &H40

    Const SM_CXVIRTUALSIZE = 78 'Breite aller Monitore zusammen
    Const SM_CYVIRTUALSIZE = 79 'Höhe aller Monitore
    Const SM_CMONITORS = 80     'Anzahl der Monitore

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Int32, ByVal Y As Int32, ByVal cx As Int32, ByVal cy As Int32, ByVal uFlags As Int32) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function ShowWindow(ByVal hWnd As IntPtr, ByVal nCmdShow As Int32) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function GetSystemMetrics(ByVal nIndex As Int32) As Int32
    End Function


    Public Const MONITORINFOF_PRIMARY = &H1
    Public Const MONITOR_DEFAULTTONEAREST = &H2
    Public Const MONITOR_DEFAULTTONULL = &H0
    Public Const MONITOR_DEFAULTTOPRIMARY = &H1
    Public Structure RECT
        Dim Left As Long
        Dim Top As Long
        Dim Right As Long
        Dim Bottom As Long
    End Structure
    Structure MONITORINFO
        Dim cbSize As Integer
        Dim rcMonitor As RECT
        Dim rcWork As RECT
        Dim dwFlags As Long
    End Structure
    Public Structure POINT
        Dim x As Long
        Dim y As Long
    End Structure

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function EnumDisplayMonitors(ByVal hdc As IntPtr, ByRef lprcClip As IntPtr, ByVal lpfnEnum As IntPtr, ByVal dwData As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function GetMonitorInfo(ByVal hMonitor As Long, ByRef lpmi As MONITORINFO) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function MonitorFromPoint(ByVal x As Long, ByVal y As Long, ByVal dwFlags As Long) As Long
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function MonitorFromRect(ByRef lprc As RECT, ByVal dwFlags As Long) As Long
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function MonitorFromWindow(ByVal hwnd As IntPtr, ByVal dwFlags As IntPtr) As Long
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function GetWindowRect(ByVal hwnd As Long, lpRect As RECT) As Long
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Public Shared Function GetLastError() As Integer
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        For Each p As Process In Process.GetProcesses
            If p.ProcessName.ToLower.Contains("discord") Then
                ShowWindow(p.MainWindowHandle, 1)
                SetWindowPos(p.MainWindowHandle, New IntPtr(HWND_NOTOPMOST), 1919, 0, 960, 540, SWP_SHOWWINDOW)
            ElseIf p.ProcessName.ToLower.Contains("spotify") Then
                SetWindowPos(p.MainWindowHandle, New IntPtr(HWND_NOTOPMOST), 1919, 540, 960, 540, SWP_SHOWWINDOW)
            ElseIf p.ProcessName.ToLower.Contains("ts3client") Then
                SetWindowPos(p.MainWindowHandle, New IntPtr(HWND_NOTOPMOST), 2879, 0, 960, 1080, SWP_SHOWWINDOW)
            End If
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox("Monitore: " & GetSystemMetrics(SM_CMONITORS) & vbCrLf & "X: " & GetSystemMetrics(SM_CXVIRTUALSIZE) & vbCrLf & "Y: " & GetSystemMetrics(SM_CYVIRTUALSIZE))

        Dim rect As Rectangle = Screen.GetWorkingArea(Me)
        addItem(rect.ToString)
        addItem(My.Computer.Screen.WorkingArea.ToString)

        addItem(EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, Marshal.GetFunctionPointerForDelegate(New MonitorEnumProcCallback(AddressOf MonitorEnumProc)), IntPtr.Zero))

        addItem("LastError: " & Marshal.GetLastWin32Error)

    End Sub

    Public Delegate Function MonitorEnumProcCallback(ByVal hMonitor As IntPtr, ByVal hdcMonitor As IntPtr, ByVal lprcMonitor As RECT, ByVal dwData As IntPtr) As Boolean
    Public Shared Function MonitorEnumProc(ByVal hMonitor As IntPtr, ByVal hdcMonitor As IntPtr, lprcMonitor As RECT, ByVal dwData As IntPtr) As Boolean
        MsgBox("Test")
        Return True
    End Function

    Private Delegate Sub addItemCallback(ByVal s As String)
    Private Sub addItem(ByVal s As String)
        If ListBox1.InvokeRequired Then
            ListBox1.Invoke(New addItemCallback(AddressOf addItem), s)
        Else
            ListBox1.Items.Add(s)
        End If
    End Sub

End Class
