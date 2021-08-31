Imports System.IO

Public Class fileBackupManager

    Private backupDir As String

    Public Sub New()

        If File.Exists(BACKUP_SETTINGS_FILE_NAME) = True Then

            Dim backupFile As New StreamReader(BACKUP_SETTINGS_FILE_NAME)
            Dim curLine As String = backupFile.ReadLine() 'backup directory
            backupDir = curLine
            backupFile.Close()

        ElseIf File.Exists(BACKUP_SETTINGS_FILE_NAME) = False Then

            backupDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\Sanity Saver File Backup"
            Dim backupFile As New StreamWriter(BACKUP_SETTINGS_FILE_NAME)
            backupFile.WriteLine(backupDir)
            backupFile.Close()

            Directory.CreateDirectory(backupDir)

        End If

    End Sub

    Public Sub SetBackupDirectory(ByVal backupDirectory As String)

        backupDir = backupDirectory

    End Sub

    Public Function GetBackupDirectory() As String

        Return backupDir

    End Function

    Public Sub BackUpFiles()

        If Directory.Exists(backupDir) = False Then

            Directory.CreateDirectory(backupDir)

        End If

        If File.Exists(STARTUP_POSITION_FILE_NAME) = True Then

            File.Copy(STARTUP_POSITION_FILE_NAME, Path.Combine(backupDir, STARTUP_POSITION_FILE_NAME), True)

        End If

        If File.Exists(PROJECT_TEMPLATES_FILE_NAME) = True Then

            File.Copy(PROJECT_TEMPLATES_FILE_NAME, Path.Combine(backupDir, PROJECT_TEMPLATES_FILE_NAME), True)

        End If

        If File.Exists(TASK_GROUP_TEMPLATES_FILE_NAME) = True Then

            File.Copy(TASK_GROUP_TEMPLATES_FILE_NAME, Path.Combine(backupDir, TASK_GROUP_TEMPLATES_FILE_NAME), True)

        End If

        If File.Exists(TO_DO_FILE_NAME) = True Then

            File.Copy(TO_DO_FILE_NAME, Path.Combine(backupDir, TO_DO_FILE_NAME), True)

        End If

        If File.Exists(COMPLETED_PROJECTS_FILE_NAME) = True Then

            File.Copy(COMPLETED_PROJECTS_FILE_NAME, Path.Combine(backupDir, COMPLETED_PROJECTS_FILE_NAME), True)

        End If

        If File.Exists(BACKUP_SETTINGS_FILE_NAME) = True Then

            File.Copy(BACKUP_SETTINGS_FILE_NAME, Path.Combine(backupDir, BACKUP_SETTINGS_FILE_NAME), True)

        End If

    End Sub

End Class
