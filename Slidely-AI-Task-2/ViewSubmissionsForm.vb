Public Class ViewSubmissionsForm
    Private backendService As BackendService
    Private currentSubmissionIndex As Integer = 0
    Private submissions As Submission

    Public Sub New(service As BackendService)
        InitializeComponent()
        backendService = service
    End Sub

    Private Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load Submissions from the backend
        LoadSubmission(currentSubmissionIndex)
    End Sub

    Private Async Sub LoadSubmission(index As Integer)
        Dim submission = Await backendService.Read(index)
        If submission IsNot Nothing Then
            DisplaySubmission(submission)
        Else
            MessageBox.Show("Submission not found.")
        End If
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentSubmissionIndex > 0 Then
            currentSubmissionIndex -= 1
            LoadSubmission(currentSubmissionIndex)
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        currentSubmissionIndex += 1
        LoadSubmission(currentSubmissionIndex)
    End Sub

    Private Sub DisplaySubmission(submission As Submission)
        NameTextBox.Text = submission.Name
        EmailTextBox.Text = submission.Email
        PhoneTextBox.Text = submission.Phone
        GithubTextBox.Text = submission.GithubLink
        StopwatchTextBox.Text = submission.StopwatchTime
    End Sub

    Private Sub ViewSubmissionsForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.P Then
            btnPrevious.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
            btnNext.PerformClick()
        End If
    End Sub
End Class


Public Class Submission
    Public Property Name As String
    Public Property Email As String
    Public Property Phone As String
    Public Property GithubLink As String
    Public Property StopwatchTime As String
End Class