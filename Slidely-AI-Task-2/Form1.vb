Public Class Form1
    Private backendService As BackendService
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        backendService = New BackendService()

        ' Check connection to backend
        CheckBackendConnection()
    End Sub

    Private Async Sub CheckBackendConnection()
        Dim isConnected = Await backendService.Ping()
        If isConnected Then
            MessageBox.Show("Connected to backend successfully.")
        Else
            MessageBox.Show("Failed to connect to backend.")
        End If
    End Sub

    Private Sub btnViewSubmissions_Click(sender As Object, e As EventArgs) Handles btnViewSubmissions.Click
        Dim viewForm As New ViewSubmissionsForm(backendService)
        viewForm.ShowDialog()
    End Sub

    Private Sub btnCreateSubmission_Click(sender As Object, e As EventArgs) Handles btnCreateSubmission.Click
        Dim createForm As New CreateSubmissionForm(backendService)
        createForm.ShowDialog()
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            btnViewSubmissions.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
            btnCreateSubmission.PerformClick()
        End If
    End Sub
End Class
