Imports System.IO

Public Class dailyLogGenerator

    Public Sub GenerateFromProjectManagerAndPlaceInTextBox(ByVal projectManagerName As projectManager, ByVal logDate As Date, ByRef textBoxName As RichTextBox)

        Dim tempLogFile As New StreamWriter(TEMP_DAILY_LOG_FILE_NAME)

        Dim headerText As String = "Daily log for " + logDate.Month.ToString + "/" + logDate.Day.ToString + "/" + logDate.Year.ToString
        tempLogFile.WriteLine(headerText)
        tempLogFile.WriteLine()

        Dim targLogDate As String = logDate.Month.ToString + logDate.Day.ToString + logDate.Year.ToString

        For curProjIndex As Integer = 0 To projectManagerName.GetCurrentNumberOfProjects() - 1 'CURRENT PROJECT-----------------------

            Dim isFirstTaskOfProject As Boolean = True

            Dim didProjHaveTargTasks = False

            For curGroupIndex As Integer = 0 To projectManagerName.GetCurrentNumberOfTaskGroupsInProject(curProjIndex) - 1 'CURRENT TASK GROUP-----------------------

                Dim isFirstTaskOfGroup As Boolean = True

                For curTaskIndex As Integer = 0 To projectManagerName.GetCurrentNumberOfTasksInTaskGroup(curProjIndex, curGroupIndex) - 1 'CURRENT TASK-----------------------

                    Dim curTaskDoneDate As String = projectManagerName.GetTaskDoneDate(curProjIndex, curGroupIndex, curTaskIndex)

                    If curTaskDoneDate = targLogDate Then

                        If isFirstTaskOfProject = True Then

                            Dim curProjName As String = projectManagerName.GetProjectName(curProjIndex)
                            tempLogFile.WriteLine(curProjName)

                            isFirstTaskOfProject = False

                        End If

                        If isFirstTaskOfGroup = True Then

                            Dim curGroupName As String = projectManagerName.GetTaskGroupName(curProjIndex, curGroupIndex)
                            tempLogFile.WriteLine(vbTab + curGroupName)

                            isFirstTaskOfGroup = False

                        End If

                        Dim curTaskName As String = projectManagerName.GetTaskName(curProjIndex, curGroupIndex, curTaskIndex)
                        tempLogFile.WriteLine(vbTab + vbTab + curTaskName)

                        didProjHaveTargTasks = True

                    End If

                Next

            Next

            If didProjHaveTargTasks = True Then

                tempLogFile.WriteLine() 'add a space between projects

            End If

        Next

        tempLogFile.Close()

        Dim dailyLogText As String = File.ReadAllText(TEMP_DAILY_LOG_FILE_NAME)
        textBoxName.Text = dailyLogText

        File.Delete(TEMP_DAILY_LOG_FILE_NAME)

    End Sub

End Class