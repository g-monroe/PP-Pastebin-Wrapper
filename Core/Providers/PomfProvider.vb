Imports System.Net.Http
Imports System.Text.RegularExpressions

Public Class PomfProvider
    Implements IDisposable

    Private _client As HttpClient

    Sub New()
        _client = New HttpClient()
    End Sub

    Public Async Function UploadBytes(filepath As String) As Task(Of String)
        Dim form As New MultipartFormDataContent()

        Dim file As Byte() = System.IO.File.ReadAllBytes(filepath)
        Dim fileName As String = System.IO.Path.GetFileName(filepath)

        form.Add(New ByteArrayContent(file, 0, file.Count()), "files[]", fileName)

        Dim response = Await _client.PostAsync("https://pomf.cat/upload.php", form)
        Dim content As String = Await response.Content.ReadAsStringAsync()

        Return "http://a.pomf.cat/" & Regex.Match(content, """url"":""([^""]+)""").Groups(1).Value
    End Function

    Public Async Function UploadBytes2(filepath As String) As Task(Of String)
        Dim form As New MultipartFormDataContent()

        Dim file As Byte() = System.IO.File.ReadAllBytes(filepath)
        Dim fileName As String = System.IO.Path.GetFileName(filepath)

        form.Add(New ByteArrayContent(file, 0, file.Count()), "upload", fileName)

        Dim response = Await _client.PostAsync("http://uploads.im/api", form)
        Dim content As String = Await response.Content.ReadAsStringAsync()

        Return content
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        _client.Dispose()
    End Sub

End Class
