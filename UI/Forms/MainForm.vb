Imports System.Net
Imports System.Text
Imports System.Net.Http

Public Class MainForm
    Private _pasteBinProvider As PasteBinProvider

    Private Async Sub bLogin_Click(sender As Object, e As EventArgs) Handles bLogin.Click
        _pasteBinProvider = New PasteBinProvider(tbApi.Text)
        Try
            Dim credential = New NetworkCredential(tbUsername.Text, tbPassword.Text)
            Dim response = Await _pasteBinProvider.Login(credential)
            If (response.Success) Then
                MessageBox.Show("Logged in!")
            Else
                MessageBox.Show(response.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
 
    End Sub

    Private Async Sub bCreate_Click(sender As Object, e As EventArgs) Handles bCreate.Click
        Dim paste = New Paste With {.Name = tbPasteName.Text, .Code = rtbCode.Text}

        Dim response = Await _pasteBinProvider.CreatePaste(paste)
        If (response.Success) Then
            MessageBox.Show("Created paste!")
            MessageBox.Show(response.ContentData)
        Else
            MessageBox.Show(response.Error)
        End If
    End Sub

    Private Async Sub bDelete_Click(sender As Object, e As EventArgs) Handles bDelete.Click
        Dim response = Await _pasteBinProvider.DeletePaste(tbPastekey.Text)
        If (response.Success) Then
            MessageBox.Show("Deleted paste!")
        Else
            MessageBox.Show(response.Error)
        End If
    End Sub

    Private Async Sub bLoadList_Click(sender As Object, e As EventArgs) Handles bLoadList.Click
        Dim response = Await _pasteBinProvider.GetPastes()
        If (response.Success) Then
            rtbPastes.Text = response.ContentData
        Else
            MessageBox.Show(response.Error)
        End If
    End Sub

    Private Async Sub bLoad_Click(sender As Object, e As EventArgs) Handles bLoad.Click
        Dim response = Await _pasteBinProvider.GetRaw(tbPastekey.Text)
        If (response.Success) Then
            rtbCode.Text = response.ContentData
        Else
            MessageBox.Show(response.Error)
        End If
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '","url":"kalofb.jpg"
        Using pomfProvider = New PomfProvider
            Dim response = Await pomfProvider.UploadBytes(TextBox1.Text)
            MsgBox(response)
        End Using
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim paste As New Paste With {.Name = tbPasteName.Text, .Code = rtbCode.Text, .ExpireDate = ExpireDate.Never, .Exposure = Exposure.Unlisted}
        'Dim response = Await _pasteBinProvider.EditPaste(paste, _pasteBinProvider)
        'If response = "Success" Then
        '    MsgBox("Edit Complete!")
        'End If
        Dim src As String
        For Each line As String In rtbcode.lines
            If line.contains("Public") Then
                line = line.replace("Publis Shared ", "<Description(" & chr(34))
                Dim codename As String = line.split(New String() {"<Description("}, stringsplitoptions.none)
            End If
        Next
    End Sub

    Private Async Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using IpAPIProvider As New IpAPIProvider
            Dim response = Await IpAPIProvider.IpInfo
        End Using
    End Sub
    Dim Monitors As New Monitors
    Public Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Monitors = WindowsHandler.GetMonitors
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        pView.Image = WindowsHandler.ScreenShotMonitor(Monitors.Item(0))
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)
        Dim TempWebcams As Webcams = WindowsHandler.GetWebcams
        Dim i As Integer = 0
        For Each WebcamDevice As WebcamDevice In TempWebcams
            i += 1
            ListBox1.Items.Add(WebcamDevice.deviceName)
        Next
        If i = 0 Then
            MsgBox("No")
        Else
            pView.Image = Webcam.TakePicture(TempWebcams.Item(0))
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

    End Sub
End Class