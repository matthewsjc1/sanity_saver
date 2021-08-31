Public Class dailyLogForm

    Private Sub copyToClipboardBtn_Click(sender As Object, e As EventArgs) Handles copyToClipboardBtn.Click

        Dim textToCopy As String = dailyLogTextBox.Text
        My.Computer.Clipboard.SetText(textToCopy)

        MessageBox.Show("Daily log copied to clipboard.")

    End Sub

    Private Sub doneBtn_Click(sender As Object, e As EventArgs) Handles doneBtn.Click

        dailyLogTextBox.Clear()
        ActiveForm.Close()

    End Sub

End Class