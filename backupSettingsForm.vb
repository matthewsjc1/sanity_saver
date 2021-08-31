Imports System.IO

Public Class backupSettingsForm

    Private curDir As String

    Private Sub backupSettingsForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        If File.Exists(BACKUP_SETTINGS_FILE_NAME) = True Then

            Dim backupFile As New StreamReader(BACKUP_SETTINGS_FILE_NAME)

            Dim curLine As String = backupFile.ReadLine() 'backup directory
            curDir = curLine
            backupDirTextBox.Text = curDir
            backupFile.Close()

        ElseIf File.Exists(BACKUP_SETTINGS_FILE_NAME) = False Then

            curDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\Sanity Saver File Backup"
            backupDirTextBox.Text = curDir

        End If

    End Sub

    Private Sub changeBackupDirBtn_Click(sender As Object, e As EventArgs) Handles changeBackupDirBtn.Click

        dirBrowser.SelectedPath = curDir

        If dirBrowser.ShowDialog() = DialogResult.OK Then

            curDir = dirBrowser.SelectedPath

            backupDirTextBox.Text = curDir

            If File.Exists(BACKUP_SETTINGS_FILE_NAME) = True Then

                File.Delete(BACKUP_SETTINGS_FILE_NAME)

            End If

            Dim backupFile As New StreamWriter(BACKUP_SETTINGS_FILE_NAME)
            backupFile.WriteLine(curDir)
            backupFile.Close()

        End If

    End Sub

    Private Sub okBtn_Click(sender As Object, e As EventArgs) Handles okBtn.Click

        Dim backupFile As New StreamWriter(BACKUP_SETTINGS_FILE_NAME)
        backupFile.WriteLine(curDir)
        backupFile.Close()

        ActiveForm.Close()

    End Sub

End Class