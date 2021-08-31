Imports System.ComponentModel
Imports System.IO

Public Class mainForm

    Private toDoProjMan As New projectManager
    Private doneProjMan As New projectManager

    Private easyToDoTreeView As New easyTreeView
    Private easyDoneTreeView As New easyTreeView

    Private todoFileMan As New toDoFileManager
    Private projTempFileMan As New projectTemplatesFileManager
    Private taskGroupTempFileMan As New taskGroupTemplatesFileManager
    Private doneFileMan As New doneFileManager
    Private partDoneFileMan As New partiallyDoneFileManager
    Private backupFileMan As New fileBackupManager

    Private doesCheckNeedProcessed As Boolean = False
    Private hasPreviousTickFinishedProcessing As Boolean = True

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        easyToDoTreeView.SetTreeView(toDoTreeView)
        easyDoneTreeView.SetTreeView(doneTreeView)

        todoFileMan.PopulateProjectManagerAndEasyTreeViewFromToDoFile(toDoProjMan, easyToDoTreeView)
        projTempFileMan.PopulateComboBoxWithTemplateNamesFromTemplateFile(savedProjTempComboBox)
        taskGroupTempFileMan.PopulateComboBoxWithTemplateNamesFromTemplateFile(savedTaskGroupTempComboBox)
        partDoneFileMan.UpdatePartiallyDoneFileFromProjectManager(toDoProjMan)
        doneFileMan.PopulateProjectManagerAndEasyTreeViewFromPartDoneAndDoneFiles(doneProjMan, easyDoneTreeView)

        Dim doneCount As Integer = easyDoneTreeView.GetProjectCount()

        If doneCount > 0 Then

            easyDoneTreeView.ExpandAll()
            easyDoneTreeView.SelectProject(0)

        End If

    End Sub

    Private Sub mainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        If File.Exists(STARTUP_POSITION_FILE_NAME) Then

            Dim configFile As New StreamReader(STARTUP_POSITION_FILE_NAME)

            Dim curLine As String

            Dim mainFormLocPoint As Point

            curLine = configFile.ReadLine() 'main form x pos
            mainFormLocPoint.X = CInt(curLine)

            curLine = configFile.ReadLine() 'main form y pos
            mainFormLocPoint.Y = CInt(curLine)

            Me.Location = mainFormLocPoint

            configFile.Close()

        End If

        easyDoneTreeView.ExpandAll()

        backupFileMan.BackUpFiles()

        checkUpdateTimer.Start()

    End Sub

    Private Sub PrepareForAppClose()

        todoFileMan.SaveToDoFileFromProjectManager(toDoProjMan)

        partDoneFileMan.DeletePartiallyDoneFile()

        SaveStartupPositionFile()

        backupFileMan.BackUpFiles()

    End Sub

    Private Sub cancelRemSelBtn_Click(sender As Object, e As EventArgs) Handles cancelRemSelBtn.Click

        Dim selNodeIdNum As Integer

        'check if anything is selected
        If easyToDoTreeView.GetIsAnyNodeSelected() = True Then
            If easyToDoTreeView.GetIsSelectedNodeAProject() = True Then 'if selected node is a project

                'get node's id number, then delete the corresponding project:
                selNodeIdNum = easyToDoTreeView.GetSelectedNodeIdNum()
                If MessageBox.Show("Remove + cancel '" + easyToDoTreeView.GetSelectedNodeText() + "'?" + vbNewLine + "(WARNING: This action cannot be undone!)", "Remove Project?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                    toDoProjMan.RemoveProjectByIdNum(selNodeIdNum)
                    easyToDoTreeView.RemoveSelectedNode()

                End If

            ElseIf easyToDoTreeView.GetIsSelectedNodeATaskGroup() = True Then 'if selected node is a task group

                'get node's id number, then delete the corresponding task group:
                selNodeIdNum = easyToDoTreeView.GetSelectedNodeIdNum()
                If MessageBox.Show("Remove + cancel '" + easyToDoTreeView.GetSelectedNodeText() + "'?" + vbNewLine + "(WARNING: This action cannot be undone!)", "Remove Task Group?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                    Dim parentProjIndex As Integer = toDoProjMan.GetIndexOfProjectWithTaskGroupIdNum(selNodeIdNum)
                    toDoProjMan.RemoveTaskGroupFromProjectByIdNum(parentProjIndex, selNodeIdNum)
                    easyToDoTreeView.RemoveSelectedNode()

                End If

            ElseIf easyToDoTreeView.GetIsSelectedNodeATask() = True Then 'if selected node is a task

                'get node's id number, then delete the corresponding task:
                selNodeIdNum = easyToDoTreeView.GetSelectedNodeIdNum()
                If MessageBox.Show("Remove + cancel '" + easyToDoTreeView.GetSelectedNodeText() + "'?" + vbNewLine + "(WARNING: This action cannot be undone!)", "Remove Task?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                    Dim parentProjIndex As Integer = toDoProjMan.GetIndexOfProjectWithTaskIdNum(selNodeIdNum)
                    Dim parentGroupIndex As Integer = toDoProjMan.GetIndexOfTaskGroupWithTaskIdNum(selNodeIdNum)
                    toDoProjMan.RemoveTaskFromTaskGroupByIdNumber(parentProjIndex, parentGroupIndex, selNodeIdNum)
                    easyToDoTreeView.RemoveSelectedNode()

                End If

            End If

        Else 'if nothing is selected

            MessageBox.Show("Nothing is selected." + vbNewLine + "Please select a project, task group, or task to cancel + remove.", "Cancel + Remove")

        End If

        todoFileMan.SaveToDoFileFromProjectManager(toDoProjMan)

        backupFileMan.BackUpFiles()

    End Sub

    Private Sub addEmptyProjBtn_Click_1(sender As Object, e As EventArgs) Handles addEmptyProjBtn.Click

        Dim projName As String
        projName = InputBox("Enter new project's name:", "Add Empty Project")
        If projName = "" Then

            MessageBox.Show("Project name cannot be blank.", "Project Name")

        ElseIf projName <> "" Then

            toDoProjMan.AppendNewProject(projName)

            Dim newProjIndex As Integer = toDoProjMan.GetCurrentNumberOfProjects() - 1
            Dim newProjIdNum As Integer = toDoProjMan.GetProjectIdNum(newProjIndex)
            easyToDoTreeView.AppendNewProject(toDoProjMan, projName, newProjIdNum)

            todoFileMan.SaveToDoFileFromProjectManager(toDoProjMan)

            backupFileMan.BackUpFiles()

        End If

    End Sub

    Private Sub addEmptyTaskGroupBtn_Click(sender As Object, e As EventArgs) Handles addEmptyTaskGroupBtn.Click

        If easyToDoTreeView.GetIsAnyNodeSelected() = True Then

            If easyToDoTreeView.GetIsSelectedNodeAProject() = True Then

                'get parent project info
                Dim parentProjIdNum As Integer = easyToDoTreeView.GetSelectedNodeIdNum()
                Dim parentProjIndex As Integer = toDoProjMan.GetIndexOfProjectWithIdNum(parentProjIdNum)

                Dim taskGroupName As String = InputBox("Enter name of task group:", "New Task Group")
                If taskGroupName = "" Then

                    MessageBox.Show("Task group name cannot be blank.", "Task Group Name")

                ElseIf taskGroupName <> "" Then

                    toDoProjMan.AppendNewTaskGroupToProject(parentProjIndex, taskGroupName)
                    Dim newGroupIndex As Integer = toDoProjMan.GetCurrentNumberOfTaskGroupsInProject(parentProjIndex) - 1
                    Dim newGroupIdNum As Integer = toDoProjMan.GetTaskGroupIdNum(parentProjIndex, newGroupIndex)
                    easyToDoTreeView.AppendNewTaskGroup(toDoProjMan, parentProjIndex, taskGroupName, newGroupIdNum)

                    todoFileMan.SaveToDoFileFromProjectManager(toDoProjMan)

                    backupFileMan.BackUpFiles()

                End If

            Else

                MessageBox.Show("Please select a project to add the new task group to.")

            End If

        Else

            MessageBox.Show("Please select a project to add the new task group to.")

        End If

    End Sub

    Private Sub addTaskBtn_Click(sender As Object, e As EventArgs) Handles addTaskBtn.Click

        If easyToDoTreeView.GetIsAnyNodeSelected() = True Then

            If easyToDoTreeView.GetIsSelectedNodeATaskGroup() = True Then

                'get parent task group's info
                Dim parentGroupIdNum As Integer = easyToDoTreeView.GetSelectedNodeIdNum()
                Dim parentGroupIndex As Integer = toDoProjMan.GetIndexOfTaskGroupWithIdNum(parentGroupIdNum)

                'get parent (grandparent) project's info:
                Dim parentProjIndex As Integer = toDoProjMan.GetIndexOfProjectWithTaskGroupIdNum(parentGroupIdNum)

                Dim taskName As String = InputBox("Enter task description:", "New Task")
                If taskName = "" Then

                    MessageBox.Show("Task description cannot be blank.", "Task Description")

                ElseIf taskName <> "" Then

                    toDoProjMan.AppendNewTaskToTaskGroup(parentProjIndex, parentGroupIndex, taskName)
                    Dim newTaskIndex As Integer = toDoProjMan.GetCurrentNumberOfTasksInTaskGroup(parentProjIndex, parentGroupIndex) - 1
                    Dim newTaskIdNum As Integer = toDoProjMan.GetTaskIdNum(parentProjIndex, parentGroupIndex, newTaskIndex)
                    easyToDoTreeView.AppendNewTask(toDoProjMan, parentProjIndex, parentGroupIndex, taskName, newTaskIdNum)

                    todoFileMan.SaveToDoFileFromProjectManager(toDoProjMan)

                    backupFileMan.BackUpFiles()

                End If

            Else

                MessageBox.Show("Please select a task group to add the new task to.")

            End If

        Else

            MessageBox.Show("Please select a task group to add the new task to.")

        End If

    End Sub

    Private Sub moveSelUpBtn_Click(sender As Object, e As EventArgs) Handles moveSelUpBtn.Click

        If easyToDoTreeView.GetIsAnyNodeSelected() = True Then

            If easyToDoTreeView.GetIsSelectedNodeAProject() = True Then

                Dim projIdNum As Integer = easyToDoTreeView.GetSelectedNodeIdNum()
                Dim projIndex As Integer = toDoProjMan.GetIndexOfProjectWithIdNum(projIdNum)
                toDoProjMan.MoveProjectUp(projIdNum)
                easyToDoTreeView.MoveProjectUp(projIndex)
                easyToDoTreeView.SelectProject(projIndex - 1)
                toDoTreeView.Select()

            ElseIf easyToDoTreeView.GetIsSelectedNodeATaskGroup() = True Then

                Dim groupIdNum As Integer = easyToDoTreeView.GetSelectedNodeIdNum()
                Dim parentProjIndex As Integer = toDoProjMan.GetIndexOfProjectWithTaskGroupIdNum(groupIdNum)
                Dim groupIndex As Integer = toDoProjMan.GetIndexOfTaskGroupWithIdNum(groupIdNum)
                toDoProjMan.MoveTaskGroupUp(groupIdNum)
                easyToDoTreeView.MoveTaskGroupUp(parentProjIndex, groupIndex)
                easyToDoTreeView.SelectTaskGroup(parentProjIndex, groupIndex - 1)
                toDoTreeView.Select()

            ElseIf easyToDoTreeView.GetIsSelectedNodeATask() = True Then

                Dim taskIdNum As Integer = easyToDoTreeView.GetSelectedNodeIdNum()
                Dim parentProjIndex As Integer = toDoProjMan.GetIndexOfProjectWithTaskIdNum(taskIdNum)
                Dim parentGroupIndex As Integer = toDoProjMan.GetIndexOfTaskGroupWithTaskIdNum(taskIdNum)
                Dim taskIndex As Integer = toDoProjMan.GetIndexOfTaskWithIdNum(taskIdNum)
                toDoProjMan.MoveTaskUp(taskIdNum)
                easyToDoTreeView.MoveTaskUp(parentProjIndex, parentGroupIndex, taskIndex)
                easyToDoTreeView.SelectTask(parentProjIndex, parentGroupIndex, taskIndex - 1)
                toDoTreeView.Select()

            End If

        End If

        todoFileMan.SaveToDoFileFromProjectManager(toDoProjMan)

        backupFileMan.BackUpFiles()

    End Sub

    Private Sub moveSelDownBtn_Click(sender As Object, e As EventArgs) Handles moveSelDownBtn.Click

        If easyToDoTreeView.GetIsAnyNodeSelected() = True Then

            If easyToDoTreeView.GetIsSelectedNodeAProject() = True Then

                Dim projIdNum As Integer = easyToDoTreeView.GetSelectedNodeIdNum()
                Dim projIndex As Integer = toDoProjMan.GetIndexOfProjectWithIdNum(projIdNum)
                toDoProjMan.MoveProjectDown(projIdNum)

                Dim curProjCount As Integer = toDoProjMan.GetCurrentNumberOfProjects()

                If projIndex < curProjCount - 1 Then

                    easyToDoTreeView.MoveProjectDown(curProjCount, projIndex)
                    easyToDoTreeView.SelectProject(projIndex + 1)
                    toDoTreeView.Select()

                End If

            ElseIf easyToDoTreeView.GetIsSelectedNodeATaskGroup() = True Then

                Dim groupIdNum As Integer = easyToDoTreeView.GetSelectedNodeIdNum()
                Dim parentProjIndex As Integer = toDoProjMan.GetIndexOfProjectWithTaskGroupIdNum(groupIdNum)
                Dim groupIndex As Integer = toDoProjMan.GetIndexOfTaskGroupWithIdNum(groupIdNum)
                toDoProjMan.MoveTaskGroupDown(groupIdNum)

                Dim curGroupCount As Integer = toDoProjMan.GetCurrentNumberOfTaskGroupsInProject(parentProjIndex)

                If groupIndex < curGroupCount - 1 Then

                    easyToDoTreeView.MoveTaskGroupDown(curGroupCount, parentProjIndex, groupIndex)
                    easyToDoTreeView.SelectTaskGroup(parentProjIndex, groupIndex + 1)
                    toDoTreeView.Select()

                End If

            ElseIf easyToDoTreeView.GetIsSelectedNodeATask() = True Then

                Dim taskIdNum As Integer = easyToDoTreeView.GetSelectedNodeIdNum()
                Dim parentProjIndex As Integer = toDoProjMan.GetIndexOfProjectWithTaskIdNum(taskIdNum)
                Dim parentGroupIndex As Integer = toDoProjMan.GetIndexOfTaskGroupWithTaskIdNum(taskIdNum)
                Dim taskIndex As Integer = toDoProjMan.GetIndexOfTaskWithIdNum(taskIdNum)
                toDoProjMan.MoveTaskDown(taskIdNum)

                Dim taskCount As Integer = toDoProjMan.GetCurrentNumberOfTasksInTaskGroup(parentProjIndex, parentGroupIndex)

                If taskIndex < taskCount - 1 Then

                    easyToDoTreeView.MoveTaskDown(taskCount, parentProjIndex, parentGroupIndex, taskIndex)
                    easyToDoTreeView.SelectTask(parentProjIndex, parentGroupIndex, taskIndex + 1)
                    toDoTreeView.Select()

                End If

            End If

        End If

        todoFileMan.SaveToDoFileFromProjectManager(toDoProjMan)

        backupFileMan.BackUpFiles()

    End Sub

    Private Sub toDoTreeView_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles toDoTreeView.AfterCheck 'node check state changes

        doesCheckNeedProcessed = True

    End Sub

    Private Sub checkUpdateTimer_Tick(sender As Object, e As EventArgs) Handles checkUpdateTimer.Tick

        If hasPreviousTickFinishedProcessing = True Then

            If doesCheckNeedProcessed = True Then

                hasPreviousTickFinishedProcessing = False 'prevent further timer ticks from interrupting current processing

                '===================================================
                'LOOP THROUGH PROJECTS
                '===================================================

                For curProjIndex As Integer = 0 To easyToDoTreeView.GetProjectCount() - 1

                    Dim isCurProjDone As Boolean = easyToDoTreeView.GetIsProjectChecked(curProjIndex)
                    Dim curProjName As String = toDoProjMan.GetProjectName(curProjIndex)

                    If isCurProjDone = True Then

                        If MessageBox.Show("Move '" + curProjName + "' to 'Done'?" + vbNewLine + "(WARNING: This action cannot be undone!)", "Project Done?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                            isCurProjDone = True
                            toDoProjMan.SetProjectDoneDate(curProjIndex, toDoProjMan.GetCurrentDateAsFormattedString()) 'finish date

                        Else 'if 'no' is pressed

                            isCurProjDone = False
                            easyToDoTreeView.SetCheckOffForProject(curProjIndex)
                            toDoProjMan.SetProjectDoneDate(curProjIndex, "") 'reset finish date

                        End If

                    End If

                    '===================================================
                    'LOOP THROUGH TASK GROUPS
                    '===================================================

                    For curGroupIndex As Integer = 0 To easyToDoTreeView.GetTaskGroupCountInProject(curProjIndex) - 1 'loop through task groups

                        Dim isCurGroupDone As Boolean = easyToDoTreeView.GetIsTaskGroupChecked(curProjIndex, curGroupIndex)

                        If isCurProjDone = True Then

                            isCurGroupDone = True

                        End If

                        If isCurGroupDone = True Then 'if current group is finished

                            toDoProjMan.MarkTaskGroupAsDone(curProjIndex, curGroupIndex)

                            'if task group is not checked, check it
                            If easyToDoTreeView.GetIsTaskGroupChecked(curProjIndex, curGroupIndex) = False Then

                                easyToDoTreeView.SetCheckOnForTaskGroup(curProjIndex, curGroupIndex)

                            End If

                            'if group finish date hasn't been assigned (that is, it was just checked), assign current date
                            If toDoProjMan.GetTaskGroupDoneDate(curProjIndex, curGroupIndex) = "" Then

                                toDoProjMan.SetTaskGroupDoneDate(curProjIndex, curGroupIndex, toDoProjMan.GetCurrentDateAsFormattedString())

                            End If

                        Else 'if group is not finished

                            toDoProjMan.MarkTaskGroupAsNotDone(curProjIndex, curGroupIndex)
                            toDoProjMan.SetTaskGroupDoneDate(curProjIndex, curGroupIndex, "") 'reset finish date

                        End If

                        '===================================================
                        'LOOP THROUGH TASKS
                        '===================================================

                        For curTaskIndex As Integer = 0 To easyToDoTreeView.GetTaskCountInTaskGroup(curProjIndex, curGroupIndex) - 1 'loop through tasks

                            Dim isCurTaskDone As Boolean = easyToDoTreeView.GetIsTaskChecked(curProjIndex, curGroupIndex, curTaskIndex)

                            If isCurGroupDone = True Then

                                isCurTaskDone = True

                            End If

                            'if task finish date hasn't been assigned (that is, it was just checked), assign current date
                            If toDoProjMan.GetTaskDoneDate(curProjIndex, curGroupIndex, curTaskIndex) = "" Then

                                toDoProjMan.SetTaskDoneDate(curProjIndex, curGroupIndex, curTaskIndex, toDoProjMan.GetCurrentDateAsFormattedString())

                            End If

                            If isCurTaskDone = True Then 'if current task is finished

                                toDoProjMan.MarkTaskAsDone(curProjIndex, curGroupIndex, curTaskIndex)

                                'change to 'done' font color
                                toDoTreeView.Nodes(curProjIndex).Nodes(curGroupIndex).Nodes(curTaskIndex).ForeColor = Color.LightSteelBlue

                                'if task is not checked, check it
                                If easyToDoTreeView.GetIsTaskChecked(curProjIndex, curGroupIndex, curTaskIndex) = False Then

                                    easyToDoTreeView.SetCheckOnForTask(curProjIndex, curGroupIndex, curTaskIndex)

                                End If

                            Else 'if task is not finished

                                toDoProjMan.MarkTaskAsNotDone(curProjIndex, curGroupIndex, curTaskIndex)
                                toDoProjMan.SetTaskDoneDate(curProjIndex, curGroupIndex, curTaskIndex, "") 'reset finish date

                                'change to 'not done' font color
                                toDoTreeView.Nodes(curProjIndex).Nodes(curGroupIndex).Nodes(curTaskIndex).ForeColor = Color.Black

                            End If

                        Next

                    Next

                    '===================================================
                    'FINISH PROCESSING FINISHED PROJECT
                    '===================================================

                    If isCurProjDone = True Then 'if current project is finished

                        easyToDoTreeView.RemoveProject(curProjIndex)
                        doneFileMan.SaveProjectToTopOfDoneFile(toDoProjMan, curProjIndex)
                        toDoProjMan.RemoveProjectByIndex(curProjIndex)

                        MessageBox.Show("'" + curProjName + "'" + " has been moved to 'Done'.", "Project Done")

                        Exit For 'gives treeview a chance to update (tries to access null data otherwise)

                    End If

                Next

                todoFileMan.SaveToDoFileFromProjectManager(toDoProjMan)
                partDoneFileMan.UpdatePartiallyDoneFileFromProjectManager(toDoProjMan)
                doneFileMan.PopulateProjectManagerAndEasyTreeViewFromPartDoneAndDoneFiles(doneProjMan, easyDoneTreeView)

                backupFileMan.BackUpFiles()

                'reset
                doesCheckNeedProcessed = False
                hasPreviousTickFinishedProcessing = True

            End If

        End If

    End Sub

    Private Sub OpenProjectTemplateEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenProjectTemplateEditorToolStripMenuItem.Click

        projectTemplateEditorForm.ShowDialog()

        projTempFileMan.PopulateComboBoxWithTemplateNamesFromTemplateFile(savedProjTempComboBox)

    End Sub

    Private Sub TaskGroupTemplateEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TaskGroupTemplateEditorToolStripMenuItem.Click

        taskGroupTemplateEditorForm.ShowDialog()

        taskGroupTempFileMan.PopulateComboBoxWithTemplateNamesFromTemplateFile(savedTaskGroupTempComboBox)

    End Sub

    Private Sub generateLogBtn_Click(sender As Object, e As EventArgs) Handles generateLogBtn.Click

        dailyLogForm.Text = "Daily Log"
        Dim dailyLogGen As New dailyLogGenerator
        dailyLogGen.GenerateFromProjectManagerAndPlaceInTextBox(doneProjMan, dailyLogDatePicker.Value, dailyLogForm.dailyLogTextBox)
        dailyLogForm.ShowDialog()

    End Sub

    Private Sub addNewTaskFromTempBtn_Click(sender As Object, e As EventArgs) Handles addNewTaskFromTempBtn.Click

        If easyToDoTreeView.GetIsAnyNodeSelected() = True Then

            If easyToDoTreeView.GetIsSelectedNodeAProject() = True Then

                Dim parentProjIndex As Integer = easyToDoTreeView.GetSelectedProjectIndex()
                Dim groupToAddIndex As Integer = savedTaskGroupTempComboBox.SelectedIndex

                taskGroupTempFileMan.AppendTaskGroupTemplateToProjectManagerAndEasyTreeViewFromTemplateFile(toDoProjMan, easyToDoTreeView, parentProjIndex, groupToAddIndex)
                easyToDoTreeView.ExpandProjectAndChildren(toDoProjMan, parentProjIndex)

                todoFileMan.SaveToDoFileFromProjectManager(toDoProjMan)

                backupFileMan.BackUpFiles()

            Else 'if selected node is not a project

                MessageBox.Show("Please select a project to add task group template to.", "No Project Selected")

            End If

        Else 'if no node is selected

            MessageBox.Show("Please select a project to add task group template to.", "No Project Selected")

        End If

    End Sub

    Private Sub addNewProjFromTempBtn_Click(sender As Object, e As EventArgs) Handles addNewProjFromTempBtn.Click

        Dim projToAddName As String = InputBox("Please enter project name:", "Add Project From Template")

        If projToAddName.Length > 0 Then

            toDoTreeView.BeginUpdate()

            Dim projTempToAddIndex As Integer = savedProjTempComboBox.SelectedIndex
            projTempFileMan.AppendProjectTemplateToProjectManagerAndEasyTreeViewFromTemplateFile(toDoProjMan, easyToDoTreeView, projTempToAddIndex, projToAddName)

            Dim newProjIndex As Integer = toDoProjMan.GetCurrentNumberOfProjects() - 1
            easyToDoTreeView.ExpandProjectAndChildren(toDoProjMan, newProjIndex)

            toDoTreeView.EndUpdate()

            todoFileMan.SaveToDoFileFromProjectManager(toDoProjMan)

            backupFileMan.BackUpFiles()

        ElseIf projToAddName.Length = 0 Then

            MessageBox.Show("Project name cannot be blank.", "Add Project From Template")

        End If

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)

        PrepareForAppClose()

        Application.Exit()

    End Sub

    Private Sub AboutSanitySaverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutSanitySaverToolStripMenuItem.Click

        aboutForm.ShowDialog()

    End Sub

    Private Sub mainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        PrepareForAppClose()

    End Sub

    Private Sub SaveStartupPositionFile()

        Dim configFile As New StreamWriter(STARTUP_POSITION_FILE_NAME)

        Dim mainFormPos As Point = Me.Location

        configFile.WriteLine(mainFormPos.X.ToString)
        configFile.WriteLine(mainFormPos.Y.ToString)

        configFile.Close()

    End Sub

    Private Sub findBtn_Click(sender As Object, e As EventArgs) Handles findBtn.Click

        Dim searchTerm As String = searchTextBox.Text

        If searchTerm.Length > 0 Then

            Dim wasTermFound As Boolean = easyDoneTreeView.SearchForNextTermInstance(searchTerm)

            If wasTermFound = True Then

                doneTreeView.Select()

            Else

                MessageBox.Show("Search term not found.", "Search")

            End If

        ElseIf searchTerm.Length = 0 Then

            MessageBox.Show("Please enter a term to search for.", "Search")

        End If

    End Sub

    Private Sub searchTextBox_TextChanged(sender As Object, e As EventArgs) Handles searchTextBox.TextChanged

        easyDoneTreeView.ResetSearchCounters()

    End Sub

    Private Sub clearSearchBtn_Click(sender As Object, e As EventArgs) Handles clearSearchBtn.Click

        searchTextBox.Clear()

        Dim projCount As Integer = doneProjMan.GetCurrentNumberOfProjects()
        If projCount > 0 Then

            easyDoneTreeView.SelectProject(0)

        End If

    End Sub

    Private Sub editTextBtn_Click(sender As Object, e As EventArgs) Handles editTextBtn.Click

        If easyToDoTreeView.GetIsAnyNodeSelected() = True Then

            If easyToDoTreeView.GetIsSelectedNodeAProject() = True Then

                Dim projIdNum As Integer = easyToDoTreeView.GetSelectedNodeIdNum()
                Dim projIndex As Integer = toDoProjMan.GetIndexOfProjectWithIdNum(projIdNum)
                Dim projCurName As String = toDoProjMan.GetProjectName(projIndex)
                Dim projNewName As String = InputBox("Edit Project Name", "Edit project's name:", projCurName)

                If projNewName.Length > 0 Then

                    toDoProjMan.SetProjectName(projIndex, projNewName)
                    easyToDoTreeView.SetProjectName(projIndex, projNewName)

                End If

            ElseIf easyToDoTreeView.GetIsSelectedNodeATaskGroup() = True Then

                Dim groupIdNum As Integer = easyToDoTreeView.GetSelectedNodeIdNum()
                Dim parentProjIndex As Integer = toDoProjMan.GetIndexOfProjectWithTaskGroupIdNum(groupIdNum)
                Dim groupIndex As Integer = toDoProjMan.GetIndexOfTaskGroupWithIdNum(groupIdNum)
                Dim groupCurName As String = toDoProjMan.GetTaskGroupName(parentProjIndex, groupIndex)
                Dim groupNewName As String = InputBox("Edit Task Group Name", "Edit task group's name:", groupCurName)

                If groupNewName.Length > 0 Then

                    toDoProjMan.SetTaskGroupName(parentProjIndex, groupIndex, groupNewName)
                    easyToDoTreeView.SetTaskGroupName(parentProjIndex, groupIndex, groupNewName)

                End If

            ElseIf easyToDoTreeView.GetIsSelectedNodeATask() = True Then

                Dim taskIdNum As Integer = easyToDoTreeView.GetSelectedNodeIdNum()
                Dim parentProjIndex As Integer = toDoProjMan.GetIndexOfProjectWithTaskIdNum(taskIdNum)
                Dim parentGroupIndex As Integer = toDoProjMan.GetIndexOfTaskGroupWithTaskIdNum(taskIdNum)
                Dim taskIndex As Integer = toDoProjMan.GetIndexOfTaskWithIdNum(taskIdNum)
                Dim taskCurName As String = toDoProjMan.GetTaskName(parentProjIndex, parentGroupIndex, taskIndex)
                Dim taskNewName As String = InputBox("Edit Task Name", "Edit task's name:", taskCurName)

                If taskNewName.Length > 0 Then

                    toDoProjMan.SetTaskName(parentProjIndex, parentGroupIndex, taskIndex, taskNewName)
                    easyToDoTreeView.SetTaskName(parentProjIndex, parentGroupIndex, taskIndex, taskNewName)

                End If

            End If

        End If

        todoFileMan.SaveToDoFileFromProjectManager(toDoProjMan)

        backupFileMan.BackUpFiles()

    End Sub

    Private Sub toDoTreeView_AfterCollapse(sender As Object, e As TreeViewEventArgs) Handles toDoTreeView.AfterCollapse

        Dim projCount As Integer = easyToDoTreeView.GetProjectCount()
        For curProjIndex As Integer = 0 To projCount - 1

            Dim isCurProjExpanded As Boolean = easyToDoTreeView.GetIsProjectExpanded(curProjIndex)
            toDoProjMan.SetIsProjectExpanded(curProjIndex, isCurProjExpanded)

            Dim groupCount As Integer = easyToDoTreeView.GetTaskGroupCountInProject(curProjIndex)
            For curGroupIndex As Integer = 0 To groupCount - 1

                Dim isCurGroupExpanded As Boolean = easyToDoTreeView.GetIsTaskGroupExpanded(curProjIndex, curGroupIndex)
                toDoProjMan.SetIsTaskGroupExpanded(curProjIndex, curGroupIndex, isCurGroupExpanded)

            Next

        Next

        todoFileMan.SaveToDoFileFromProjectManager(toDoProjMan)

        backupFileMan.BackUpFiles()

    End Sub

    Private Sub toDoTreeView_AfterExpand(sender As Object, e As TreeViewEventArgs) Handles toDoTreeView.AfterExpand

        Dim projCount As Integer = easyToDoTreeView.GetProjectCount()
        For curProjIndex As Integer = 0 To projCount - 1

            Dim isCurProjExpanded As Boolean = easyToDoTreeView.GetIsProjectExpanded(curProjIndex)
            toDoProjMan.SetIsProjectExpanded(curProjIndex, isCurProjExpanded)

            Dim groupCount As Integer = easyToDoTreeView.GetTaskGroupCountInProject(curProjIndex)
            For curGroupIndex As Integer = 0 To groupCount - 1

                Dim isCurGroupExpanded As Boolean = easyToDoTreeView.GetIsTaskGroupExpanded(curProjIndex, curGroupIndex)
                toDoProjMan.SetIsTaskGroupExpanded(curProjIndex, curGroupIndex, isCurGroupExpanded)

            Next

        Next

        todoFileMan.SaveToDoFileFromProjectManager(toDoProjMan)

        backupFileMan.BackUpFiles()

    End Sub

    Private Sub BackupSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupSettingsToolStripMenuItem.Click

        backupSettingsForm.ShowDialog()

    End Sub

    Private Sub statRepBtn_Click(sender As Object, e As EventArgs) Handles statRepBtn.Click

        todoFileMan.SaveToDoFileFromProjectManager(toDoProjMan) 'makes sure to do file is up-to-date before status report uses it

        statusReportForm.ShowDialog()

    End Sub

End Class
