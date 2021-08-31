Imports System.IO

Public Class doneFileManager

    '=====================================================
    'finished.ss
    'file format:
    '|p|                                    'start of a project block
    'project name
    '8-digit date (ex: 11312020)            'finish date
    '|g|                                    'start of a task group block
    'task group name
    '8-digit date (ex: 11312020)            'finish date
    '|t|                                    'start of a task block
    'task name
    '8-digit date (ex: 11312020)            'finish date
    '=====================================================

    Public Sub SaveProjectToTopOfDoneFile(ByVal projectManagerName As projectManager, ByVal projectIndex As Integer)

        CopyDoneProjectDataToTempFile(projectManagerName, projectIndex)

        CopyDoneFileToTempFile()

        DeleteDoneFile()

        CopyTempFilesToDoneFile()

        DeleteTempFiles()

    End Sub

    Public Sub PopulateProjectManagerAndEasyTreeViewFromPartDoneAndDoneFiles(ByRef projectManagerName As projectManager, ByRef easyToDoTreeView As easyTreeView)

        projectManagerName.Clear()
        easyToDoTreeView.Clear()

        Dim curProjIndex As Integer = -1
        Dim curGroupIndex As Integer = -1
        Dim curTaskIndex As Integer = -1

        '================================================================================================================================
        'LOAD PARTIALLY DONE PROJECTS
        '================================================================================================================================

        If File.Exists(PARTIALLY_DONE_FILE_NAME) Then

            Dim fileStream As New StreamReader(PARTIALLY_DONE_FILE_NAME)
            Dim curLine As String

            Do
                curLine = fileStream.ReadLine()

                '===========================================================================
                'LOAD PROJECT
                '===========================================================================

                If curLine = PROJECT_BLOCK_SYMBOL Then

                    'update counters:
                    curProjIndex += 1
                    curGroupIndex = -1
                    curTaskIndex = -1

                    'name
                    curLine = fileStream.ReadLine()
                    Dim curProjName As String = curLine
                    projectManagerName.AppendNewProject(curProjName)

                    'id number
                    curLine = fileStream.ReadLine()
                    Dim curProjIdNum As Integer = curLine
                    projectManagerName.SetProjecIdNum(curProjIndex, curProjIdNum)

                    'add to tree view (add finish date to name)
                    easyToDoTreeView.AppendNewProject(projectManagerName, curProjName, curProjIdNum)

                    '===========================================================================
                    'LOAD TASK GROUP
                    '===========================================================================

                ElseIf curLine = TASK_GROUP_BLOCK_SYMBOL Then

                    'update counters:
                    curGroupIndex += 1
                    curTaskIndex = -1

                    'name
                    curLine = fileStream.ReadLine()
                    Dim curGroupName As String = curLine
                    projectManagerName.AppendNewTaskGroupToProject(curProjIndex, curGroupName)

                    'finish date
                    curLine = fileStream.ReadLine()
                    If curLine = "true" Then

                        curLine = fileStream.ReadLine()
                        Dim curGroupDoneDate As String = curLine
                        projectManagerName.MarkTaskGroupAsDone(curProjIndex, curGroupIndex)
                        projectManagerName.SetTaskGroupDoneDate(curProjIndex, curGroupIndex, curGroupDoneDate)

                    ElseIf curLine = "false" Then

                        curLine = fileStream.ReadLine() 'advances read pointer past '0' placeholder

                    End If

                    'id number
                    curLine = fileStream.ReadLine()
                    Dim curGroupIdNum As Integer = CInt(curLine)
                    projectManagerName.SetTaskGroupIdNum(curProjIndex, curGroupIndex, curGroupIdNum)

                    'add to tree view
                    easyToDoTreeView.AppendNewTaskGroup(projectManagerName, curProjIndex, curGroupName, curGroupIdNum)

                    '===========================================================================
                    'LOAD TASK
                    '===========================================================================

                ElseIf curLine = TASK_BLOCK_SYMBOL Then

                    'update counter
                    curTaskIndex += 1

                    'name
                    curLine = fileStream.ReadLine()
                    Dim curTaskName As String = curLine
                    projectManagerName.AppendNewTaskToTaskGroup(curProjIndex, curGroupIndex, curTaskName)

                    'finish date
                    curLine = fileStream.ReadLine()
                    Dim curTaskDoneDate As String = curLine
                    projectManagerName.SetTaskDoneDate(curProjIndex, curGroupIndex, curTaskIndex, curTaskDoneDate)

                    'id number
                    curLine = fileStream.ReadLine()
                    Dim curTaskIdNum As Integer = CInt(curLine)
                    projectManagerName.SetTaskIdNum(curProjIndex, curGroupIndex, curTaskIndex, curTaskIdNum)

                    'add to tree view
                    easyToDoTreeView.AppendNewTask(projectManagerName, curProjIndex, curGroupIndex, curTaskName, curTaskIdNum)

                End If

            Loop Until curLine Is Nothing

            fileStream.Close()

            easyToDoTreeView.ExpandAll()

        End If

        '================================================================================================================================
        'LOAD FINISHED PROJECTS
        '================================================================================================================================

        If File.Exists(COMPLETED_PROJECTS_FILE_NAME) Then

            Dim fileStream As New StreamReader(COMPLETED_PROJECTS_FILE_NAME)
            Dim curLine As String

            Dim randIdNum As Integer = -1

            Do
                curLine = fileStream.ReadLine()

                '===========================================================================
                'LOAD PROJECT
                '===========================================================================

                If curLine = PROJECT_BLOCK_SYMBOL Then

                    'update counters:
                    curProjIndex += 1
                    curGroupIndex = -1
                    curTaskIndex = -1

                    'name
                    curLine = fileStream.ReadLine()
                    Dim curProjName As String = curLine
                    projectManagerName.AppendNewProject(curProjName)

                    'finished date
                    curLine = fileStream.ReadLine()
                    Dim curProjDoneDate As String = curLine
                    projectManagerName.SetProjectDoneDate(curProjIndex, curProjDoneDate)

                    'add to tree view (add finish date to name)
                    Dim curProjIdNum As Integer = projectManagerName.GetProjectIdNum(curProjIndex)
                    easyToDoTreeView.AppendNewProject(projectManagerName, curProjName, curProjIdNum)

                    '===========================================================================
                    'LOAD TASK GROUP
                    '===========================================================================

                ElseIf curLine = TASK_GROUP_BLOCK_SYMBOL Then

                    'update counters:
                    curGroupIndex += 1
                    curTaskIndex = -1

                    'name
                    curLine = fileStream.ReadLine()
                    Dim curGroupName As String = curLine
                    projectManagerName.AppendNewTaskGroupToProject(curProjIndex, curGroupName)

                    'finish date
                    curLine = fileStream.ReadLine()
                    Dim curGroupDoneDate As String = curLine
                    projectManagerName.MarkTaskGroupAsDone(curProjIndex, curGroupIndex)
                    projectManagerName.SetTaskGroupDoneDate(curProjIndex, curGroupIndex, curGroupDoneDate)

                    'add to tree view
                    Dim curGroupIdNum As Integer = projectManagerName.GetTaskGroupIdNum(curProjIndex, curGroupIndex)
                    easyToDoTreeView.AppendNewTaskGroup(projectManagerName, curProjIndex, curGroupName, curGroupIdNum)

                    '===========================================================================
                    'LOAD TASK
                    '===========================================================================

                ElseIf curLine = TASK_BLOCK_SYMBOL Then

                    'update counter
                    curTaskIndex += 1

                    'name
                    curLine = fileStream.ReadLine()
                    Dim curTaskName As String = curLine
                    projectManagerName.AppendNewTaskToTaskGroup(curProjIndex, curGroupIndex, curTaskName)

                    'finish date
                    curLine = fileStream.ReadLine()
                    Dim curTaskDoneDate As String = curLine
                    projectManagerName.MarkTaskAsDone(curProjIndex, curGroupIndex, curTaskIndex)
                    projectManagerName.SetTaskDoneDate(curProjIndex, curGroupIndex, curTaskIndex, curTaskDoneDate)

                    'add to tree view
                    Dim curTaskIdNum As Integer = projectManagerName.GetTaskIdNum(curProjIndex, curGroupIndex, curTaskIndex)
                    easyToDoTreeView.AppendNewTask(projectManagerName, curProjIndex, curGroupIndex, curTaskName, curTaskIdNum)

                End If

            Loop Until curLine Is Nothing

            fileStream.Close()

        End If

    End Sub

    '===================================================
    'PRIVATE ROUTINES
    '===================================================

    Private Sub CopyDoneProjectDataToTempFile(ByVal projectManagerName As projectManager, ByVal projectIndex As Integer)

        Dim doneDataTempFile As New StreamWriter(TEMP_DONE_DATA_FILE_NAME, True)

        For curProjIndex As Integer = 0 To projectManagerName.GetCurrentNumberOfProjects() - 1 'loop through projects

            If curProjIndex = projectIndex Then 'if current project is target project

                doneDataTempFile.WriteLine(PROJECT_BLOCK_SYMBOL)

                Dim projName As String = projectManagerName.GetProjectName(curProjIndex)
                doneDataTempFile.WriteLine(projName)

                Dim projDoneDate As String = projectManagerName.GetProjectDoneDate(curProjIndex)
                doneDataTempFile.WriteLine(projDoneDate)

                For curGroupIndex As Integer = 0 To projectManagerName.GetCurrentNumberOfTaskGroupsInProject(curProjIndex) - 1 'loop through task groups

                    doneDataTempFile.WriteLine(TASK_GROUP_BLOCK_SYMBOL)

                    Dim groupName As String = projectManagerName.GetTaskGroupName(curProjIndex, curGroupIndex)
                    doneDataTempFile.WriteLine(groupName)

                    Dim groupDoneDate As String = projectManagerName.GetTaskGroupDoneDate(curProjIndex, curGroupIndex)
                    doneDataTempFile.WriteLine(groupDoneDate)

                    For curTaskIndex As Integer = 0 To projectManagerName.GetCurrentNumberOfTasksInTaskGroup(curProjIndex, curGroupIndex) - 1 'loop through tasks

                        doneDataTempFile.WriteLine(TASK_BLOCK_SYMBOL)

                        Dim taskName As String = projectManagerName.GetTaskName(curProjIndex, curGroupIndex, curTaskIndex)
                        doneDataTempFile.WriteLine(taskName)

                        Dim taskDoneDate As String = projectManagerName.GetTaskDoneDate(curProjIndex, curGroupIndex, curTaskIndex)
                        doneDataTempFile.WriteLine(taskDoneDate)

                    Next

                Next

            End If

        Next

        doneDataTempFile.Close()

    End Sub

    Private Sub CopyDoneFileToTempFile()

        If File.Exists(COMPLETED_PROJECTS_FILE_NAME) Then

            FileCopy(COMPLETED_PROJECTS_FILE_NAME, TEMP_PREVIOUS_DONE_DATA_FILE_NAME)

        End If

    End Sub

    Private Sub DeleteDoneFile()

        File.Delete(COMPLETED_PROJECTS_FILE_NAME)

    End Sub

    Private Sub CopyTempFilesToDoneFile()

        Dim doneFile As New StreamWriter(COMPLETED_PROJECTS_FILE_NAME, True)
        Dim curLine As String

        If File.Exists(TEMP_DONE_DATA_FILE_NAME) = True Then

            Dim tempDataFile As New StreamReader(TEMP_DONE_DATA_FILE_NAME)

            Do

                curLine = tempDataFile.ReadLine()
                doneFile.WriteLine(curLine)

            Loop Until curLine Is Nothing

            tempDataFile.Close()
        End If

        If File.Exists(TEMP_PREVIOUS_DONE_DATA_FILE_NAME) = True Then

            Dim tempPrevDataFile As New StreamReader(TEMP_PREVIOUS_DONE_DATA_FILE_NAME)

            Do

                curLine = tempPrevDataFile.ReadLine()
                doneFile.WriteLine(curLine)

            Loop Until curLine Is Nothing

            tempPrevDataFile.Close()
        End If

        doneFile.Close()

    End Sub

    Private Sub DeleteTempFiles()

        File.Delete(TEMP_DONE_DATA_FILE_NAME)
        File.Delete(TEMP_PREVIOUS_DONE_DATA_FILE_NAME)

    End Sub

End Class
