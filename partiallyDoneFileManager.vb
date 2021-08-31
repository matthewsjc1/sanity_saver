Imports System.IO

Public Class partiallyDoneFileManager

    'part_done.ss format:
    '|p|
    'project name
    'project id number
    '|g|
    'task group name
    ''true' or 'false' - is task group done
    'done date or '0' if not done
    'task group id number
    '|t|
    'task name
    'task done date
    'task id number

    Public Sub UpdatePartiallyDoneFileFromProjectManager(ByVal projectManagerName As projectManager)

        Dim partDoneFile As New StreamWriter(PARTIALLY_DONE_FILE_NAME)

        For curProjIndex As Integer = 0 To projectManagerName.GetCurrentNumberOfProjects() - 1 'PROJECTS------------------------

            Dim isFirstTaskOfProj As Boolean = True

            For curGroupIndex As Integer = 0 To projectManagerName.GetCurrentNumberOfTaskGroupsInProject(curProjIndex) - 1 'TASK GROUPS------------------------

                Dim isFirstTaskOfGroup As Boolean = True

                For curTaskIndex As Integer = 0 To projectManagerName.GetCurrentNumberOfTasksInTaskGroup(curProjIndex, curGroupIndex) - 1 'TASKS------------------------

                    If projectManagerName.GetIsTaskDone(curProjIndex, curGroupIndex, curTaskIndex) = True Then

                        If isFirstTaskOfProj = True Then

                            partDoneFile.WriteLine(PROJECT_BLOCK_SYMBOL)

                            Dim parentProjName As String = projectManagerName.GetProjectName(curProjIndex)
                            partDoneFile.WriteLine(parentProjName)

                            Dim parentProjIdNum As Integer = projectManagerName.GetProjectIdNum(curProjIndex)
                            partDoneFile.WriteLine(parentProjIdNum)

                            isFirstTaskOfProj = False

                        End If

                        If isFirstTaskOfGroup = True Then

                            partDoneFile.WriteLine(TASK_GROUP_BLOCK_SYMBOL)

                            Dim parentGroupName As String = projectManagerName.GetTaskGroupName(curProjIndex, curGroupIndex)
                            partDoneFile.WriteLine(parentGroupName)

                            Dim isGroupDone As Boolean = projectManagerName.GetIsTaskGroupDone(curProjIndex, curGroupIndex)
                            If isGroupDone = True Then

                                partDoneFile.WriteLine("true")

                                Dim groupDoneDate As String = projectManagerName.GetTaskGroupDoneDate(curProjIndex, curGroupIndex)
                                partDoneFile.WriteLine(groupDoneDate)

                            ElseIf isGroupDone = False Then

                                partDoneFile.WriteLine("false")
                                partDoneFile.WriteLine("0")

                            End If

                            Dim groupIdNum As Integer = projectManagerName.GetTaskGroupIdNum(curProjIndex, curGroupIndex)
                            partDoneFile.WriteLine(groupIdNum)

                            isFirstTaskOfGroup = False

                        End If

                        partDoneFile.WriteLine(TASK_BLOCK_SYMBOL)

                        Dim curTaskName As String = projectManagerName.GetTaskName(curProjIndex, curGroupIndex, curTaskIndex)
                        partDoneFile.WriteLine(curTaskName)

                        Dim curTaskDoneDate As String = projectManagerName.GetTaskDoneDate(curProjIndex, curGroupIndex, curTaskIndex)
                        partDoneFile.WriteLine(curTaskDoneDate)

                        Dim curTaskIdNum As Integer = projectManagerName.GetTaskIdNum(curProjIndex, curGroupIndex, curTaskIndex)
                        partDoneFile.WriteLine(curTaskIdNum)

                    End If

                Next

            Next

        Next

        partDoneFile.Close()

    End Sub

    Public Sub DeletePartiallyDoneFile()

        If File.Exists(PARTIALLY_DONE_FILE_NAME) Then

            File.Delete(PARTIALLY_DONE_FILE_NAME)

        End If

    End Sub

End Class
