Public Class CreateSubmissionForm
    Private backendService As BackendService
    Private stopwatchRunning As Boolean = False
    Private stopwatchTime As TimeSpan = TimeSpan.Zero

    Public Sub New(service As BackendService)
        InitializeComponent()
        backendService = service
    End Sub

    Private Sub CreateSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 1000
    End Sub

    Private Sub btnToggleStopwatch_Click(sender As Object, e As EventArgs) Handles btnToggleStopwatch.Click
        ToggleStopwatch()
    End Sub

    Private Sub ToggleStopwatch()
        If stopwatchRunning Then
            Timer1.Stop()
        Else
            Timer1.Start()
        End If

        stopwatchRunning = Not stopwatchRunning
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        stopwatchTime = stopwatchTime.Add(TimeSpan.FromSeconds(1))
        lblStopwatch.Text = stopwatchTime.ToString("hh\:mm\:ss")
    End Sub

    Private Async Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim submission As New Submission With {
            .Name = NameTextBox.Text,
            .Email = EmailTextBox.Text,
            .Phone = PhoneTextBox.Text,
            .GithubLink = GithubTextBox.Text,
            .StopwatchTime = lblStopwatch.Text
        }

        Dim isSubmitted = Await backendService.Submit(submission)
        If isSubmitted Then
            MessageBox.Show("Submission successful!")
            NameTextBox.Text = ""
            EmailTextBox.Text = ""
            PhoneTextBox.Text = ""
            GithubTextBox.Text = ""

        Else
            MessageBox.Show("Failed to submit.")
        End If
    End Sub

    Private Sub CreateSubmissionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.T Then
            btnToggleStopwatch.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            btnSubmit.PerformClick()
        End If
    End Sub
End Class