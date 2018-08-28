Imports System.Net.Http
Imports System.Text.RegularExpressions

Public Class IpAPIProvider
    Implements IDisposable

    Private _client As HttpClient

    Sub New()
        _client = New HttpClient
    End Sub

    Public Async Function IpInfo() As Task(Of String)
        Dim form As New MultipartFormDataContent()

        Dim response = Await _client.PostAsync("http://ip-api.com/line", form)
        Dim content = Await response.Content.ReadAsStringAsync()
        If Not content.Contains("fail") Then
            Return content
        Else
            Return "error"
        End If
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        _client.Dispose()
    End Sub


End Class
