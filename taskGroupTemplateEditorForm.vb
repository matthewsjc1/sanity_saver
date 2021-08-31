Public Class taskGroupTemplateEditorForm

    Const HOLDER_PROJECT_NAME As String = "<project>"

    Private projMan As New projectManager
    Private easyPreviewTreeView As New easyTreeView
    Private fileMan As New taskGroupTemplatesFileManager
    Private doUnsavedChangesExist As Boolean = False

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        projMan.AppendNewProject(HOLDER_PROJECT_NAME) 'holder project
        projMan.AppendNewTaskGroupToProject(0, "") 'group used to hold template info

        easyPreviewTreeView.SetTreeView(taskGroupPrevTreeView)
        easyPreviewTreeView.AppendNewProject(projMan, HOLDER_PROJECT_NAME, 0)
        easyPreviewTreeView.AppendNewTaskGroup(projMan, 0, "", 0)
        easyPreviewTreeView.ExpandAll()

    End Sub

    Private Sub ResetTemplateForm()

        projMan.Clear()
        projMan.AppendNewProject(HOLDER_PROJECT_NAME) 'holder project
        projMan.AppendNewTaskGroupToProject(0, "") 'group used to hold template info

        taskGroupNameTextBox.Clear()

        easyPreviewTreeView.Clear()
        easyPreviewTreeView.AppendNewProject(projMan, HOLDER_PROJECT_NAME, 0)
        easyPreviewTreeView.AppendNewTaskGroup(projMan, 0, "", 0)
        easyPreviewTreeView.ExpandAll()

        fileMan.PopulateComboBoxWithTemplateNamesFromTemplateFile(savedTempsComboBox)

        doUnsavedChangesExist = False

    End Sub

    Private Sub taskGroupTemplateEditorForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        ResetTemplateForm()

        fileMan.PopulateComboBoxWithTemplateNamesFromTemplateFile(savedTempsComboBox)

        doUnsavedChangesExist = False

        easyPreviewTreeView.ExpandAll()

    End Sub

    Private Sub doneBtn_Click_1(sender As Object, e As EventArgs) Handles doneBtn.Click

        If doUnsavedChangesExist = True Then

            If MessageBox.Show("The current template has not been saved." + vbNewLine + "Close editor anyway?", "Template Not Saved", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                ActiveForm.Close()

            End If

        ElseIf doUnsavedChangesExist = False Then

            ActiveForm.Close()

        End If

    End Sub

    Private Sub addTaskBtn_Click(sender As Object, e As EventArgs) Handles addTaskBtn.Click

        Dim newTaskName As String = InputBox("Task Description", "Enter task description:")
        If newTaskName <> "" Then

            projMan.AppendNewTaskToTaskGroup(0, 0, newTaskName)
            Dim taskCount As Integer = projMan.GetCurrentNumberOfTasksInTaskGroup(0, 0)
            Dim newTaskIdNum As Integer = projMan.GetTaskIdNum(0, 0, taskCount - 1)
            easyPreviewTreeView.AppendNewTask(projMan, 0, 0, newTaskName, newTaskIdNum)

            doUnsavedChangesExist = True

        End If

        easyPreviewTreeView.ExpandAll()

    End Sub

    Private Sub taskGroupNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles taskGroupNameTextBox.TextChanged

        Dim newName As String = taskGroupNameTextBox.Text
        projMan.SetTaskGroupName(0, 0, newName)
        easyPreviewTreeView.SetTaskGroupName(0, 0, newName)

    End Sub

    Private Sub removeSelTaskBtn_Click(sender As Object, e As EventArgs) Handles removeSelTaskBtn.Click

        If easyPreviewTreeView.GetIsAnyNodeSelected() = True Then

            If easyPreviewTreeView.GetIsSelectedNodeATask() = True Then

                Dim taskIdNum As Integer = easyPreviewTreeView.GetSelectedNodeIdNum()
                projMan.RemoveTaskFromTaskGroupByIdNumber(0, 0, taskIdNum)
                easyPreviewTreeView.RemoveSelectedNode()

                doUnsavedChangesExist = True

            End If

        End If

        easyPreviewTreeView.ExpandAll()

    End Sub

    Private Sub saveTaskGroupTempBtn_Click_1(sender As Object, e As EventArgs) Handles saveTaskGroupTempBtn.Click

        'make sure a name has been entered and at least one task has been added
        If taskGroupNameTextBox.TextLength <> 0 Then 'if name has been entered

            If projMan.GetCurrentNumberOfTasksInTaskGroup(0, 0) > 0 Then 'if template has name entered and has tasks assigned

                Dim templateName As String = taskGroupNameTextBox.Text
                Dim doesTemplateNameExist As Boolean = fileMan.DoesTemplateNameExistInTemplateFile(templateName)
                If doesTemplateNameExist = False Then 'if this template name hasn't already been used

                    fileMan.AppendNewTaskGroupTemplateToFileFromProjectManager(projMan)
                    MessageBox.Show("Template saved.")

                    ResetTemplateForm()

                    doUnsavedChangesExist = False

                ElseIf doesTemplateNameExist = True Then

                    MessageBox.Show("This template name has already been used. Please change the template name before saving.")

                End If


            Else 'if template has no tasks

                MessageBox.Show("The task group template has no tasks assigned. Please add tasks before saving.")

            End If

        ElseIf taskGroupNameTextBox.TextLength = 0 Then 'if no name has been entered

            MessageBox.Show("'Task Group Name' is empty. Please enter a name before saving.")

        End If

    End Sub

    Private Sub clearBtn_Click(sender As Object, e As EventArgs) Handles clearBtn.Click

        ResetTemplateForm()

        doUnsavedChangesExist = False

    End Sub

    Private Sub loadSelTempBtn_Click(sender As Object, e As EventArgs) Handles loadSelTempBtn.Click

        easyPreviewTreeView.BeginUpdate()
        Dim taskGroupToLoadIndex As Integer = savedTempsComboBox.SelectedIndex
        fileMan.LoadTemplateIntoFormFromTemplateFile(projMan, taskGroupToLoadIndex, taskGroupNameTextBox, easyPreviewTreeView, HOLDER_PROJECT_NAME)
        easyPreviewTreeView.EndUpdate()

        doUnsavedChangesExist = False

        easyPreviewTreeView.ExpandAll()

    End Sub

    Private Sub delSelTempBtn_Click(sender As Object, e As EventArgs) Handles delSelTempBtn.Click

        If savedTempsComboBox.Items.Count > 0 Then 'make sure there are items to delete

            Dim taskGroupToDeleteName As String = savedTempsComboBox.SelectedItem.ToString
            If MessageBox.Show("Delete '" + taskGroupToDeleteName + "'?", "Delete Template?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                fileMan.DeleteTemplateFromTemplateFile(taskGroupToDeleteName)
                fileMan.PopulateComboBoxWithTemplateNamesFromTemplateFile(savedTempsComboBox)

            End If

        ElseIf savedTempsComboBox.Items.Count = 0 Then

            savedTempsComboBox.Text = ""

        End If

        easyPreviewTreeView.ExpandAll()

    End Sub

    Private Sub moveSelUpBtn_Click(sender As Object, e As EventArgs) Handles moveSelUpBtn.Click

        If easyPreviewTreeView.GetIsAnyNodeSelected() = True Then

            If easyPreviewTreeView.GetIsSelectedNodeATask() = True Then

                Dim taskIdNum As Integer = easyPreviewTreeView.GetSelectedNodeIdNum()
                Dim taskIndex As Integer = projMan.GetIndexOfTaskWithIdNum(taskIdNum)
                projMan.MoveTaskUp(taskIdNum)
                easyPreviewTreeView.MoveTaskUp(0, 0, taskIndex)
                easyPreviewTreeView.SelectTask(0, 0, taskIndex - 1)
                taskGroupPrevTreeView.Select()

                doUnsavedChangesExist = True

            End If

        End If

        easyPreviewTreeView.ExpandAll()

    End Sub

    Private Sub moveSelDownBtn_Click(sender As Object, e As EventArgs) Handles moveSelDownBtn.Click

        If easyPreviewTreeView.GetIsAnyNodeSelected() = True Then

            If easyPreviewTreeView.GetIsSelectedNodeATask() = True Then

                Dim taskIdNum As Integer = easyPreviewTreeView.GetSelectedNodeIdNum()
                Dim taskIndex As Integer = projMan.GetIndexOfTaskWithIdNum(taskIdNum)
                projMan.MoveTaskDown(taskIdNum)
                Dim taskCount As Integer = projMan.GetCurrentNumberOfTasksInTaskGroup(0, 0)
                easyPreviewTreeView.MoveTaskDown(taskCount, 0, 0, taskIndex)
                easyPreviewTreeView.SelectTask(0, 0, taskIndex + 1)
                taskGroupPrevTreeView.Select()

                doUnsavedChangesExist = True

            End If

        End If

        easyPreviewTreeView.ExpandAll()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If easyPreviewTreeView.GetIsAnyNodeSelected() = True Then

            If easyPreviewTreeView.GetIsSelectedNodeATask() = True Then

                Dim taskIdNum As Integer = easyPreviewTreeView.GetSelectedNodeIdNum()
                Dim parentProjIndex As Integer = projMan.GetIndexOfProjectWithTaskIdNum(taskIdNum)
                Dim parentGroupIndex As Integer = projMan.GetIndexOfTaskGroupWithTaskIdNum(taskIdNum)
                Dim taskIndex As Integer = projMan.GetIndexOfTaskWithIdNum(taskIdNum)
                Dim taskCurName As String = projMan.GetTaskName(parentProjIndex, parentGroupIndex, taskIndex)
                Dim taskNewName As String = InputBox("Edit Task Name", "Edit task's name:", taskCurName)

                If taskNewName.Length > 0 Then

                    projMan.SetTaskName(parentProjIndex, parentGroupIndex, taskIndex, taskNewName)
                    easyPreviewTreeView.SetTaskName(parentProjIndex, parentGroupIndex, taskIndex, taskNewName)
                    taskGroupPrevTreeView.Select()

                End If

            End If

        End If

    End Sub

End Class