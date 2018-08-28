Option Explicit On
Option Strict Off

Imports System
Imports System.Runtime
Imports System.Runtime.InteropServices
Imports Microsoft.Win32

'|||||||CREDIT||||||||||||
'https://code.msdn.microsoft.com/windowsdesktop/How-To-Create-Webcam-bbdcc90f#content
'By razorx83
'|||||||||||||||||||||||||
'Thanks for making and sharing this class
'If you also use this class please leave credit where credit is due!
'-Nettro
'|||||||||||||||||||||||||
Module Webcam
#Region "Core"
    Public Const WM_CAP As Short = &H400S

    Public Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    Public Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    Public Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30

    Public Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
    Public Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
    Public Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
    Public Const WS_CHILD As Integer = &H40000000
    Public Const WS_VISIBLE As Integer = &H10000000
    Public Const SWP_NOMOVE As Short = &H2S
    Public Const SWP_NOSIZE As Short = 1
    Public Const SWP_NOZORDER As Short = &H4S
    Public Const HWND_BOTTOM As Short = 1

    Public iDevice As Integer = 0 ' Current device ID
    Public hHwnd As Integer ' Handle to preview window

    Public Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
        (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, _
        <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

    Public Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, _
        ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, _
        ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    Public Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

    Public Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
        (ByVal lpszWindowName As String, ByVal dwStyle As Integer, _
        ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, _
        ByVal nHeight As Short, ByVal hWndParent As Integer, _
        ByVal nID As Integer) As Integer

    Public Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, _
        ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, _
        ByVal cbVer As Integer) As Boolean
    Sub SetCurrentWebCam(Camstr As String)
        WriteToRegistry(RegistryHive.LocalMachine, "SYSTEM\CurrentControlSet\Control\MediaResources\msvideo\MSVideo.VFWWDM\", "DevicePath", Camstr)
        'Dim regKey As RegistryKey
        'Dim ver As Decimal
        'regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Control\MediaResources\msvideo\MSVideo.VFWWDM\", True)
        'MsgBox(regKey)
        'regKey.SetValue("DevicePath", Camstr)
        'ver = regKey.GetValue("Version", 0.0)
        'If ver < 1.1 Then
        '    regKey.SetValue("Version", 1.1)
        'End If
        'regKey.Close()



        'Dim WSHShell As Object
        'Dim MyRegKey As String
        'WSHShell = CreateObject("WScript.Shell")
        'MyRegKey = "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\MediaResources\msvideo\MSVideo.VFWWDM\DevicePath"
        'WSHShell.regwrite(MyRegKey, Camstr)
        'WSHShell = Nothing
    End Sub
    Public Function WriteToRegistry(ByVal _
    ParentKeyHive As RegistryHive, _
    ByVal SubKeyName As String, _
    ByVal ValueName As String, _
    ByVal Value As Object) As Boolean

        'DEMO USAGE
        'Dim bAns As Boolean
        'bAns = WriteToRegistry(RegistryHive.LocalMachine, "SOFTWARE\MyCompany\MyProgram\", "ProgramHasRunBefore", "Y")
        'Debug.WriteLine("Registry Write Successful: " & bAns)

        Dim objSubKey As RegistryKey
        Dim sException As String
        Dim objParentKey As RegistryKey
        Dim bAns As Boolean


        Try

            Select Case ParentKeyHive
                Case RegistryHive.ClassesRoot
                    objParentKey = Registry.ClassesRoot
                Case RegistryHive.CurrentConfig
                    objParentKey = Registry.CurrentConfig
                Case RegistryHive.CurrentUser
                    objParentKey = Registry.CurrentUser
                Case RegistryHive.DynData
                    objParentKey = Registry.DynData
                Case RegistryHive.LocalMachine
                    objParentKey = Registry.LocalMachine
                Case RegistryHive.PerformanceData
                    objParentKey = Registry.PerformanceData
                Case RegistryHive.Users
                    objParentKey = Registry.Users

            End Select


            'Open 
            objSubKey = objParentKey.OpenSubKey(SubKeyName, True)
            'create if doesn't exist
            If objSubKey Is Nothing Then
                objSubKey = objParentKey.CreateSubKey(SubKeyName)
            End If


            objSubKey.SetValue(ValueName, Value)
            bAns = True
        Catch ex As Exception
            bAns = False

        End Try

        Return True

    End Function
    Public Function TakePicture(ByVal WebcamDevice As WebcamDevice) As Bitmap
        Try

            Dim lhHwnd As Integer ' Handle to preview window

            ' Create a form to play with 
            Using loWindow As New System.Windows.Forms.Form
                SetCurrentWebCam(WebcamDevice.deviceName)
                ' Create capture window 
                lhHwnd = capCreateCaptureWindowA(WebcamDevice.deviceVerison, WS_VISIBLE Or WS_CHILD, 0, 0, 1080, _
                   720, loWindow.Handle.ToInt32, 0)

                ' Hook up the device 
                SendMessage(lhHwnd, WM_CAP_DRIVER_CONNECT, WebcamDevice.deviceVerison, 0)
                ' Allow the webcam apeture to let enough light in 
                For i = 1 To 10
                    Application.DoEvents()
                Next

                ' Copy image to clipboard 
                SendMessage(lhHwnd, WM_CAP_EDIT_COPY, WebcamDevice.deviceVerison, 0)

                ' Get image from clipboard and convert it to a bitmap 
                Dim loData As IDataObject = Clipboard.GetDataObject()
                If loData.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
                    Using loBitmap As Image = CType(loData.GetData(GetType(System.Drawing.Bitmap)), Image)
                        Return loBitmap
                    End Using
                End If

                SendMessage(lhHwnd, WM_CAP_DRIVER_DISCONNECT, WebcamDevice.deviceVerison, 0)

            End Using
        Catch ex As Exception
            Dim bi As New Bitmap(512, 512)
            Dim gr As Graphics = Graphics.FromImage(bi)
            gr.Clear(Color.Black)
            gr.DrawString("Error!" & vbNewLine & ex.Message, New Font("Arial", 10, FontStyle.Regular), Brushes.White, New Rectangle(0, 0, 512, 512), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            Return bi
        End Try
        Dim b As New Bitmap(512, 512)
        Dim g As Graphics = Graphics.FromImage(b)
        g.Clear(Color.Black)
        g.DrawString("Error!" & vbNewLine & "No Return!", New Font("Arial", 10, FontStyle.Regular), Brushes.White, New Rectangle(0, 0, 512, 512), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        Return b
    End Function
#End Region
#Region "Effects & Events"
    Public Function InvertPicturesFromCapturedWindow() As Bitmap
        Dim InvertImages As Bitmap
        Dim InvertdataCopy As IDataObject

        Dim X As Integer
        Dim Y As Integer
        Dim r As Integer
        Dim g As Integer
        Dim b As Integer

        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)
        InvertdataCopy = Clipboard.GetDataObject()

        InvertImages = CType(InvertdataCopy.GetData(GetType(System.Drawing.Bitmap)), Image)

        X = 0
        Y = 0
        r = 0
        g = 0
        b = 0

        For X = 0 To InvertImages.Width - 1
            For Y = 0 To InvertImages.Height - 1
                r = 255 - InvertImages.GetPixel(X, Y).R
                g = 255 - InvertImages.GetPixel(X, Y).G
                b = 255 - InvertImages.GetPixel(X, Y).B

                InvertImages.SetPixel(X, Y, Color.FromArgb(r, g, b))
            Next Y
        Next X

        InvertdataCopy = Nothing

        Return InvertImages
        InvertImages.Dispose()
    End Function

    Public Function GrayScalePicture() As Bitmap
        On Error Resume Next
        Dim bmGrayScale As Bitmap
        Dim GrayScaleData As IDataObject

        Dim X As Integer
        Dim Y As Integer
        Dim colorX As Integer

        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)
        GrayScaleData = Clipboard.GetDataObject()
        bmGrayScale = CType(GrayScaleData.GetData(GetType(System.Drawing.Bitmap)), Image)

        X = 0
        Y = 0

        For X = 0 To bmGrayScale.Width - 1
            For Y = 0 To bmGrayScale.Height - 1

                colorX = (CInt(bmGrayScale.GetPixel(X, Y).R) + _
                   bmGrayScale.GetPixel(X, Y).G + _
                   bmGrayScale.GetPixel(X, Y).B) \ 3

                bmGrayScale.SetPixel(X, Y, Color.FromArgb(colorX, colorX, colorX))
            Next Y
        Next X

        GrayScaleData = Nothing

        Return bmGrayScale
        bmGrayScale.Dispose()
    End Function

    Public Function SephiaRed() As Bitmap
        On Error Resume Next
        Dim SephiaRedBmp As Bitmap
        Dim SephiaRedData As IDataObject

        Dim X As Integer
        Dim Y As Integer
        Dim r As Integer
        Dim g As Integer
        Dim b As Integer

        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)
        SephiaRedData = Clipboard.GetDataObject()

        SephiaRedBmp = CType(SephiaRedData.GetData(GetType(System.Drawing.Bitmap)), Image)

        X = 0
        Y = 0
        r = 0
        g = 0
        b = 0

        'Change This Value To Sephia Red
        For X = 0 To SephiaRedBmp.Width - 1
            For Y = 0 To SephiaRedBmp.Height - 1
                r = 255 - SephiaRedBmp.GetPixel(X, Y).R
                g = 255 - SephiaRedBmp.GetPixel(X, Y).G / 3
                b = 255 - SephiaRedBmp.GetPixel(X, Y).B / 3

                SephiaRedBmp.SetPixel(X, Y, Color.FromArgb(r, g, b))
            Next Y
        Next X

        SephiaRedData = Nothing

        Return SephiaRedBmp
        SephiaRedBmp.Dispose()
    End Function

    Public Function DetectMovement() As Long
        On Error Resume Next

        Dim detectPicture As Bitmap
        Dim DetectData As IDataObject

        Dim X As Integer
        Dim Y As Integer
        Dim Tolerance As Integer
        Dim inter As Integer
        Dim r1, r2, g1, g2, b1, b2 As Integer
        Dim Color1, Color2 As Color

        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)
        DetectData = Clipboard.GetDataObject()

        detectPicture = CType(DetectData.GetData(GetType(System.Drawing.Bitmap)), Image)

        Tolerance = 15
        inter = 10
        X = 0 : Y = 0
        r1 = 0 : r2 = 0 : g1 = 0 : g2 = 0 : b1 = 0 : b2 = 0
        Color1 = Nothing : Color2 = Nothing

        Dim MValue(0 To detectPicture.Width, 0 To detectPicture.Height) As Boolean

        For X = 0 To detectPicture.Width / inter - 1
            For Y = 0 To detectPicture.Height / inter - 1
                Color1 = detectPicture.GetPixel(X * inter, Y * inter)
                r1 = Color1.R
                g1 = Color1.G
                b1 = Color1.B

                r2 = Color2.R
                g2 = Color2.G
                b2 = Color2.B
                If System.Math.Abs(r1 - r2) < Tolerance And System.Math.Abs(g1 - g2) < Tolerance And System.Math.Abs(b1 - b2) < Tolerance Then
                    'Remain
                    MValue(X, Y) = True
                Else
                    'Moved
                    Color2 = detectPicture.GetPixel(X * inter, Y * inter)
                    MValue(X, Y) = False
                End If
            Next Y
        Next X
        X = 0
        Y = 0

        Dim RealRi As Long = 0
        For X = 1 To detectPicture.Width / inter - 2
            For Y = 1 To detectPicture.Height / inter - 2
                If MValue(X, Y + 1) = False Then
                    If MValue(X, Y - 1) = False Then
                        If MValue(X + 1, Y) = False Then
                            If MValue(X - 1, Y) = False Then
                                RealRi = RealRi + 1
                            End If
                        End If
                    End If
                End If
            Next
        Next

        Return RealRi
        detectPicture.Dispose()
    End Function


#End Region
End Module
