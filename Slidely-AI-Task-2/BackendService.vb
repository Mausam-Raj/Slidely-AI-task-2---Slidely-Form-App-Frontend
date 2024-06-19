Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
Public Class BackendService
    Private ReadOnly client As HttpClient

    Public Sub New()
        client = New HttpClient()
        client.BaseAddress = New Uri("http://localhost:3000/")
    End Sub

    Public Async Function Ping() As Task(Of Boolean)
        Dim response = Await client.GetAsync("ping")
        Return response.IsSuccessStatusCode
    End Function

    Public Async Function Submit(submission As Submission) As Task(Of Boolean)
        Dim json = JsonConvert.SerializeObject(submission)
        Dim Content = New StringContent(json, Encoding.UTF8, "application/json")
        Dim response = Await client.PostAsync("submit", Content)
        Return response.IsSuccessStatusCode
    End Function

    Public Async Function Read(index As Integer) As Task(Of Submission)
        Dim response = Await client.GetAsync($"read?index={index}")
        If response.IsSuccessStatusCode Then
            Dim jsonResponse = Await response.Content.ReadAsStringAsync()
            Return JsonConvert.DeserializeObject(Of Submission)(jsonResponse)
        End If
        Return Nothing
    End Function
End Class
