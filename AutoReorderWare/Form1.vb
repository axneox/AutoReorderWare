Imports System.Runtime.InteropServices

Public Class Form1
    Const HWND_TOPMOST = -1
    Const HWND_NOTOPMOST = -2
    Const SWP_NOSIZE = &H1
    Const SWP_NOMOVE = &H2
    Const SWP_NOACTIVATE = &H10
    Const SWP_SHOWWINDOW = &H40

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Int32, ByVal Y As Int32, ByVal cx As Int32, ByVal cy As Int32, ByVal uFlags As Int32) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function ShowWindow(ByVal hWnd As IntPtr, ByVal nCmdShow As Int32) As Boolean
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
