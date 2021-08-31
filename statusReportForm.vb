Imports System.IO

Public Class statusReportForm

    Private statRepProjMan As New projectManager
    Private toDoFileMan As New toDoFileManager

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ResetReportForm()

        statRepProjMan.Clear()

        statRepTextBox.Clear()

        toDoFileMan.PopulateStatusReportProjectManagerFromToDoFile(statRepProjMan)
        toDoFileMan.GenerateStatusReportIntoTextBoxFromProjectManager(statRepTextBox, statRepProjMan)

    End Sub

    Private Sub statusReportForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        ResetReportForm()

    End Sub

    Private Sub copyToClipboardBtn_Click(sender As Object, e As EventArgs) Handles copyToClipboardBtn.Click

        Dim textToCopy As String = statRepTextBox.Text
        My.Computer.Clipboard.SetText(textToCopy)

        MessageBox.Show("Status report copied to clipboard.")

    End Sub

    Private Sub doneBtn_Click(sender As Object, e As EventArgs) Handles doneBtn.Click

        statRepTextBox.Clear()

        ActiveForm.Close()

    End Sub

End Class