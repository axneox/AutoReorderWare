Imports System.Runtime.InteropServices

Public Class Frm_Main

#Region "WinAPI"
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
    Public Shared Function IsWindowVisible(ByVal hWnd As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function IsIconic(ByVal hWnd As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
    End Function

    'Private Structure RECT
    '    Dim left As Long
    '    Dim top As Long
    '    Dim right As Long
    '    Dim bottom As Long
    '    Overrides Function ToString() As String
    '        Return "{left: " & left & "; top: " & top & "; right: " & right & "; bottom: " & bottom & "}"
    '    End Function
    'End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure RECT
        Dim Left As Integer
        Dim Top As Integer
        Dim Right As Integer
        Dim Bottom As Integer
        Overrides Function ToString() As String
            Return "{left: " & Left & "; top: " & Top & "; right: " & Right & "; bottom: " & Bottom & "}"
        End Function
    End Structure
#End Region

    Private procList As New Collection()

    Private Sub Frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        loadUIProcesses()
        resizeWorkSpace()
        testSub()

    End Sub

    Private Sub resizeWorkSpace()
        addLogEntry("<resizeWorkSpace>")
        Dim virtualScreenSize As Size = SystemInformation.VirtualScreen.Size
        addLogEntry("VirtualScreenSize = " & virtualScreenSize.ToString)
        pnl_workspace.Width = tp_main.Width
        pnl_workspace.Height = virtualScreenSize.Height * (pnl_workspace.Width / virtualScreenSize.Width)
        pnl_workspace.Location = New Point(0, tp_main.Height / 2 - pnl_workspace.Height / 2)
        Dim g As Graphics = pnl_workspace.CreateGraphics
        Dim screenIndex As Integer = 1
        For Each s As Screen In Screen.AllScreens
            addLogEntry("ScreenIndex: " & screenIndex)
            addLogEntry("DeviceName: " & s.DeviceName.ToString)
            addLogEntry("ScreenBounds: " & s.Bounds.ToString)
            addLogEntry("WorkingArea: " & s.WorkingArea.ToString)

            Dim drawingRect As New Rectangle(s.Bounds.X * (pnl_workspace.Width / virtualScreenSize.Width), s.Bounds.Y * (pnl_workspace.Height / virtualScreenSize.Height), s.Bounds.Width * (pnl_workspace.Width / virtualScreenSize.Width), s.Bounds.Height * (pnl_workspace.Height / virtualScreenSize.Height))

            g.FillRectangle(Brushes.Red, drawingRect)
            screenIndex += 1
        Next

        addLogEntry("</resizeWorkSpace>")
    End Sub

    Private Sub loadUIProcesses()
        addLogEntry("<loadUIProcesses>")
        procList.Clear()
        addLogEntry("procList [cleared]")
        For Each p As Process In Process.GetProcesses
            If IsWindowVisible(p.MainWindowHandle) Then 'OrElse IsIconic(p.MainWindowHandle) Then
                Try
                    procList.Add(p, p.Id)
                    addLogEntry("procList [added " & p.Id & " | " & p.ProcessName & "]")
                Catch ex As Exception
                    addLogEntry("procList [ERROR " & p.Id & " | " & p.ProcessName & "]")
                End Try
            End If
        Next
        addLogEntry("procList [count " & procList.Count & "]")
        addLogEntry("</loadUIProcesses>")
    End Sub

    Private Sub testSub()
        addLogEntry("Monitors detected: " & SystemInformation.MonitorCount)

        Dim screenIndex As Integer = 1
        For Each s As Screen In Screen.AllScreens
            addLogEntry("ScreenIndex: " & screenIndex)
            addLogEntry("DeviceName: " & s.DeviceName.ToString)
            addLogEntry("ScreenBounds: " & s.Bounds.ToString)
            addLogEntry("WorkingArea: " & s.WorkingArea.ToString)

            screenIndex += 1
        Next

        Dim rect As Rectangle = Screen.GetWorkingArea(Me)
        addLogEntry(rect.ToString)
        addLogEntry(My.Computer.Screen.WorkingArea.ToString)
        addLogEntry("Screensize: " & SystemInformation.VirtualScreen.Size.ToString)

        'addLogEntry("Software running:")
        'For Each p As Process In Process.GetProcesses
        '    If IsWindowVisible(p.MainWindowHandle) Then 'OrElse IsIconic(p.MainWindowHandle) Then
        '        addLogEntry(p.ProcessName & " " & p.Id)
        '        Dim o As New RECT
        '        GetWindowRect(p.MainWindowHandle, o)
        '        addLogEntry(o.ToString)
        '        procList.Add(p, p.Id)
        '    End If
        'Next

    End Sub

    Private Delegate Sub addLogEntryCallback(ByVal s As String)
    Private Sub addLogEntry(ByVal s As String)
        If lb_log.InvokeRequired Then
            lb_log.Invoke(New addLogEntryCallback(AddressOf addLogEntry), s)
        Else
            lb_log.Items.Add(Now.ToLongTimeString & " > " & s)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

        Dim p As Process = Process.GetCurrentProcess
        Dim o As New RECT
        GetWindowRect(p.MainWindowHandle, o)
        addLogEntry(o.ToString)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'Move specific processes to position
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
End Class
