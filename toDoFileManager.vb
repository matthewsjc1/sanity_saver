Imports System.IO

Public Class toDoFileManager

    '=====================================================
    'to_do.ss
    'file format:
    '|p|                                    'start of a project block
    'project name
    ''true' or 'false'                      'is project expanded
    '|g|                                    'start of a task group block
    'task group name
    ''true' or 'false'                      'is task group finished
    ''true' or 'false'                      'is task group expanded
    '|t|                                    'start of a task block
    'task name
    ''true' or 'false'                      'is task finished
    ''0' or 8-digit date (ex: 11312020)     'if not complete, "0", otherwise is finish date
    '=====================================================

    Public Sub SaveToDoFileFromProjectManager(ByVal projectManagerName As projectManager)

        Dim fileStream As New StreamWriter(TO_DO_FILE_NAME, False)

        'cycle through project manager, writing info to file using format
        For curProjIndex As Integer = 0 To projectManagerName.GetCurrentNumberOfProjects() - 1

            '===========================================================================
            'SAVE PROJECT DATA
            '===========================================================================

            fileStream.WriteLine(PROJECT_BLOCK_SYMBOL)
            fileStream.WriteLine(projectManagerName.GetProjectName(curProjIndex)) 'name

            If projectManagerName.GetIsProjectExpanded(curProjIndex) = True Then

                fileStream.WriteLine("true")

            Else

                fileStream.WriteLine("false")

            End If

            '===========================================================================
            'SAVE TASK GROUP DATA
            '===========================================================================

            For curGroupIndex As Integer = 0 To projectManagerName.GetCurrentNumberOfTaskGroupsInProject(curProjIndex) - 1

                fileStream.WriteLine(TASK_GROUP_BLOCK_SYMBOL)
                fileStream.WriteLine(projectManagerName.GetTaskGroupName(curProjIndex, curGroupIndex)) 'name
                Dim isGroupDone As Boolean = projectManagerName.GetIsTaskGroupDone(curProjIndex, curGroupIndex)
                If isGroupDone = True Then

                    fileStream.WriteLine("true") 'is finished
                    Dim dateString As String = projectManagerName.GetTaskGroupDoneDate(curProjIndex, curGroupIndex)
                    fileStream.WriteLine(dateString) 'finish date

                ElseIf isGroupDone = False Then

                    fileStream.WriteLine("false") 'is not finished
                    fileStream.WriteLine("0") 'finish date placeholder

                End If

                If projectManagerName.GetIsTaskGroupExpanded(curProjIndex, curGroupIndex) = True Then

                    fileStream.WriteLine("true")

                Else

                    fileStream.WriteLine("false")

                End If

                '===========================================================================
                'SAVE TASK DATA
                '===========================================================================

                For curTaskIndex As Integer = 0 To projectManagerName.GetCurrentNumberOfTasksInTaskGroup(curProjIndex, curGroupIndex) - 1

                    fileStream.WriteLine(TASK_BLOCK_SYMBOL)
                    fileStream.WriteLine(projectManagerName.GetTaskName(curProjIndex, curGroupIndex, curTaskIndex)) 'name
                    Dim isTaskDone As Boolean = projectManagerName.GetIsTaskDone(curProjIndex, curGroupIndex, curTaskIndex)
                    If isTaskDone = True Then

                        fileStream.WriteLine("true") 'is finished
                        Dim dateString As String = projectManagerName.GetTaskDoneDate(curProjIndex, curGroupIndex, curTaskIndex)
                        fileStream.WriteLine(dateString) 'finish date

                    ElseIf isTaskDone = False Then

                        fileStream.WriteLine("false") 'is not finished
                        fileStream.WriteLine("0") 'finish date placeholder

                    End If

                Next

            Next

        Next

        fileStream.Close()

    End Sub

    Public Sub PopulateProjectManagerAndEasyTreeViewFromToDoFile(ByRef projectManagerName As projectManager, ByRef easyToDoTreeView As easyTreeView)

        If File.Exists(TO_DO_FILE_NAME) Then

            projectManagerName.Clear()
            easyToDoTreeView.Clear()

            Dim fileStream As New StreamReader(TO_DO_FILE_NAME)

            Dim curLine As String
            Dim curProjIndex As Integer = -1
            Dim curGroupIndex As Integer = -1
            Dim curTaskIndex As Integer = -1
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
                    projectManagerName.AppendNewProject(curLine)

                    'add to tree view
                    Dim curProjIdNum As Integer = projectManagerName.GetProjectIdNum(curProjIndex)
                    easyToDoTreeView.AppendNewProject(projectManagerName, curLine, curProjIdNum)

                    'is expanded
                    curLine = fileStream.ReadLine()
                    Dim isExpanded As Boolean = True
                    If curLine = "false" Then

                        isExpanded = False

                    End If

                    projectManagerName.SetIsProjectExpanded(curProjIndex, isExpanded)

                    If isExpanded = True Then

                        easyToDoTreeView.ExpandProject(curProjIndex)

                    ElseIf isExpanded = False Then

                        easyToDoTreeView.CollapseProject(curProjIndex)

                    End If

                ElseIf curLine = TASK_GROUP_BLOCK_SYMBOL Then

                    '===========================================================================
                    'LOAD TASK GROUP
                    '===========================================================================

                    'update counters:
                    curGroupIndex += 1
                    curTaskIndex = -1

                    'name
                    curLine = fileStream.ReadLine()
                    projectManagerName.AppendNewTaskGroupToProject(curProjIndex, curLine)

                    'add to tree view
                    Dim curGroupIdNum As Integer = projectManagerName.GetTaskGroupIdNum(curProjIndex, curGroupIndex)
                    easyToDoTreeView.AppendNewTaskGroup(projectManagerName, curProjIndex, curLine, curGroupIdNum)

                    'is task group finished?
                    curLine = fileStream.ReadLine()
                    If curLine = "true" Then

                        projectManagerName.MarkTaskGroupAsDone(curProjIndex, curGroupIndex)
                        easyToDoTreeView.SetCheckOnForTaskGroup(curProjIndex, curGroupIndex)

                        curLine = fileStream.ReadLine() 'finish date
                        projectManagerName.SetTaskGroupDoneDate(curProjIndex, curGroupIndex, curLine)

                    End If

                    'is expanded
                    curLine = fileStream.ReadLine()
                    Dim isExpanded As Boolean = True
                    If curLine = "false" Then

                        isExpanded = False

                    End If

                    projectManagerName.SetIsTaskGroupExpanded(curProjIndex, curGroupIndex, isExpanded)

                    If isExpanded = True Then

                        easyToDoTreeView.ExpandTaskGroup(curProjIndex, curGroupIndex)

                    ElseIf isExpanded = False Then

                        easyToDoTreeView.CollapseTaskGroup(curProjIndex, curGroupIndex)

                    End If

                ElseIf curLine = TASK_BLOCK_SYMBOL Then

                    '===========================================================================
                    'LOAD TASK
                    '===========================================================================

                    'update counter
                    curTaskIndex += 1

                    'name
                    curLine = fileStream.ReadLine()
                    projectManagerName.AppendNewTaskToTaskGroup(curProjIndex, curGroupIndex, curLine)

                    'add to tree view
                    Dim curTaskIdNum As Integer = projectManagerName.GetTaskIdNum(curProjIndex, curGroupIndex, curTaskIndex)
                    easyToDoTreeView.AppendNewTask(projectManagerName, curProjIndex, curGroupIndex, curLine, curTaskIdNum)

                    'check if finished
                    curLine = fileStream.ReadLine()
                    If curLine = "true" Then

                        projectManagerName.MarkTaskAsDone(curProjIndex, curGroupIndex, curTaskIndex)
                        easyToDoTreeView.SetCheckOnForTask(curProjIndex, curGroupIndex, curTaskIndex)

                        curLine = fileStream.ReadLine() 'finish date
                        projectManagerName.SetTaskDoneDate(curProjIndex, curGroupIndex, curTaskIndex, curLine)

                    End If

                End If

            Loop Until curLine Is Nothing

            fileStream.Close()

        End If

    End Sub

    Public Sub PopulateStatusReportProjectManagerFromToDoFile(ByRef projectManagerName As projectManager)

        If File.Exists(TO_DO_FILE_NAME) Then

            projectManagerName.Clear()

            Dim fileStream As New StreamReader(TO_DO_FILE_NAME)

            Dim curLine As String
            Dim curProjIndex As Integer = -1
            Dim curGroupIndex As Integer = -1
            Dim curTaskIndex As Integer = -1

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
                    projectManagerName.AppendNewProject(curLine)

                ElseIf curLine = TASK_GROUP_BLOCK_SYMBOL Then

                    '===========================================================================
                    'LOAD TASK GROUP
                    '===========================================================================

                    'update counters:
                    curGroupIndex += 1
                    curTaskIndex = -1

                    'name
                    curLine = fileStream.ReadLine()
                    projectManagerName.AppendNewTaskGroupToProject(curProjIndex, curLine)

                    'is task group finished?
                    curLine = fileStream.ReadLine()
                    If curLine = "true" Then

                        projectManagerName.MarkTaskGroupAsDone(curProjIndex, curGroupIndex)

                        curLine = fileStream.ReadLine() 'finish date
                        projectManagerName.SetTaskGroupDoneDate(curProjIndex, curGroupIndex, curLine)

                    End If

                ElseIf curLine = TASK_BLOCK_SYMBOL Then

                    '===========================================================================
                    'LOAD TASK
                    '===========================================================================

                    'update counter
                    curTaskIndex += 1

                    'name
                    curLine = fileStream.ReadLine()
                    projectManagerName.AppendNewTaskToTaskGroup(curProjIndex, curGroupIndex, curLine)

                    'check if finished
                    curLine = fileStream.ReadLine()
                    If curLine = "true" Then

                        projectManagerName.MarkTaskAsDone(curProjIndex, curGroupIndex, curTaskIndex)

                        curLine = fileStream.ReadLine() 'finish date
                        projectManagerName.SetTaskDoneDate(curProjIndex, curGroupIndex, curTaskIndex, curLine)

                    End If

                End If

            Loop Until curLine Is Nothing

            fileStream.Close()

        End If

    End Sub

    Public Sub GenerateStatusReportIntoTextBoxFromProjectManager(ByRef statusReportTextBoxName As RichTextBox, ByRef statusReportProjectManager As projectManager)

        'cycle through projects
        For curProjIndex As Integer = 0 To statusReportProjectManager.GetCurrentNumberOfProjects() - 1

            Dim curProjName As String
            curProjName = statusReportProjectManager.GetProjectName(curProjIndex)
            statusReportTextBoxName.AppendText("CURRENT TASKS:")
            statusReportTextBoxName.AppendText(vbCrLf)
            statusReportTextBoxName.AppendText(curProjName + vbCrLf)

            'cycle through task groups in current project
            For curGroupIndex As Integer = 0 To statusReportProjectManager.GetCurrentNumberOfTaskGroupsInProject(curProjIndex) - 1

                Dim curGroupName As String = statusReportProjectManager.GetTaskGroupName(curProjIndex, curGroupIndex)

                Dim isCurGroupDone As Boolean = statusReportProjectManager.GetIsTaskGroupDone(curProjIndex, curGroupIndex)

                If isCurGroupDone = True Then

                    'statusReportTextBoxName.AppendText(vbTab + curGroupName + " -   ::: DONE :::" + vbCrLf) *decided to not show finished lines due to messiness

                ElseIf isCurGroupDone = False Then 'if current task group is not done

                    Dim curTaskName As String = ""
                    Dim wasFirstTaskNotDoneFound As Boolean = False
                    Dim doesCurTaskBelongToSomeoneElse As Boolean = True

                    'cycle through tasks in current task group
                    For curTaskIndex As Integer = 0 To statusReportProjectManager.GetCurrentNumberOfTasksInTaskGroup(curProjIndex, curGroupIndex) - 1

                        curTaskName = statusReportProjectManager.GetTaskName(curProjIndex, curGroupIndex, curTaskIndex)
                        doesCurTaskBelongToSomeoneElse = curTaskName.Contains("**")

                        Dim isCurTaskDone As Boolean = statusReportProjectManager.GetIsTaskDone(curProjIndex, curGroupIndex, curTaskIndex)

                        If isCurTaskDone = True Then 'if current task is done

                        ElseIf isCurTaskDone = False Then 'if current task is not done

                            If doesCurTaskBelongToSomeoneElse = True Then 'if current task is not done and belongs to someone else

                                Exit For

                            ElseIf doesCurTaskBelongToSomeoneElse = False Then 'if current task is not done and belongs to me

                                statusReportTextBoxName.AppendText(vbTab + curGroupName + " :: ")
                                statusReportTextBoxName.AppendText(curTaskName + vbCrLf)

                                Exit For

                            End If

                        End If

                    Next

                End If

            Next

            statusReportTextBoxName.AppendText(vbCrLf + vbCrLf) 'add space between projects

        Next

    End Sub

End Class
