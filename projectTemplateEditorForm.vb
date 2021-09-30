Imports System.ComponentModel

Public Class projectTemplateEditorForm

    Private projMan As New projectManager
    Private easyPreviewTreeView As New easyTreeView
    Private projTempFileMan As New projectTemplatesFileManager
    Private taskGroupTempFileMan As New taskGroupTemplatesFileManager
    Private doUnsavedChangesExist As Boolean = False

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        easyPreviewTreeView.SetTreeView(projPrevTreeView)

    End Sub

    Private Sub ResetTemplateForm()

        projMan.Clear()
        projMan.AppendNewProject("")

        projNameTextBox.Clear()

        easyPreviewTreeView.Clear()
        Dim projIdNum As Integer = projMan.GetProjectIdNum(0)
        easyPreviewTreeView.AppendNewProject(projMan, "", projIdNum)
        easyPreviewTreeView.ExpandAll()

        taskGroupTempFileMan.PopulateComboBoxWithTemplateNamesFromTemplateFile(savedTaskGroupTempsComboBox)
        projTempFileMan.PopulateComboBoxWithTemplateNamesFromTemplateFile(savedProjTempsComboBox)

        projTempFileMan.PopulateComboBoxWithTemplateNamesFromTemplateFile(savedProjTempsComboBox)

        doUnsavedChangesExist = False

    End Sub

    Private Sub projectTemplateEditorForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        ResetTemplateForm()

        doUnsavedChangesExist = False

        easyPreviewTreeView.ExpandAll()

    End Sub

    Private Sub doneBtn_Click(sender As Object, e As EventArgs) Handles doneBtn.Click

        If doUnsavedChangesExist = True Then

            If MessageBox.Show("The current template has not been saved." + vbCrLf + "Close editor anyway?", "Template Not Saved", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                ActiveForm.Close()

            End If

        ElseIf doUnsavedChangesExist = False Then

            ActiveForm.Close()

        End If

    End Sub

    Private Sub projNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles projNameTextBox.TextChanged

        Dim newName As String = projNameTextBox.Text
        projMan.SetProjectName(0, newName)
        easyPreviewTreeView.SetProjectName(0, newName)

    End Sub

    Private Sub removeSelBtn_Click(sender As Object, e As EventArgs) Handles removeSelBtn.Click

        If easyPreviewTreeView.GetIsAnyNodeSelected() = True Then

            If easyPreviewTreeView.GetIsSelectedNodeATaskGroup() = True Then

                Dim groupIdNum As Integer = easyPreviewTreeView.GetSelectedNodeIdNum()
                projMan.RemoveTaskGroupFromProjectByIdNum(0, groupIdNum)
                easyPreviewTreeView.RemoveSelectedNode()

                doUnsavedChangesExist = True

            ElseIf easyPreviewTreeView.GetIsSelectedNodeATask() = True Then

                Dim taskIdNum As Integer = easyPreviewTreeView.GetSelectedNodeIdNum()
                Dim parentProjIndex As Integer = projMan.GetIndexOfTaskGroupWithTaskIdNum(taskIdNum)
                Dim parentGroupIndex As Integer = projMan.GetIndexOfProjectWithTaskIdNum(taskIdNum)
                projMan.RemoveTaskFromTaskGroupByIdNumber(parentProjIndex, parentGroupIndex, taskIdNum)
                easyPreviewTreeView.RemoveSelectedNode()

                doUnsavedChangesExist = True

            End If

        End If

        easyPreviewTreeView.ExpandAll()

    End Sub

    Private Sub saveProjTempBtn_Click(sender As Object, e As EventArgs) Handles saveProjTempBtn.Click

        'make sure a name has been entered and at least one task group has been added
        If projNameTextBox.TextLength <> 0 Then

            If projMan.GetCurrentNumberOfTaskGroupsInProject(0) > 0 Then

                Dim templateName As String = projNameTextBox.Text
                Dim doesTemplateNameExist As Boolean = projTempFileMan.DoesTemplateNameExistInTemplateFile(templateName)

                If doesTemplateNameExist = False Then 'if this template name hasn't already been used

                    projTempFileMan.AppendNewProjectTemplateToFileFromProjectManager(projMan)
                    MessageBox.Show("Template saved.")

                    ResetTemplateForm()

                    doUnsavedChangesExist = False

                ElseIf doesTemplateNameExist = True Then

                    MessageBox.Show("This template name has already been used. Please change the template name before saving.")

                End If

            Else 'if template has no task groups

                MessageBox.Show("The task group template has no task groups assigned. Please add task groups before saving.")

            End If

        ElseIf projNameTextBox.TextLength = 0 Then 'if no name has been entered

            MessageBox.Show("'Project Name' is empty. Please enter a name before saving.")

        End If

    End Sub

    Private Sub clearBtn_Click(sender As Object, e As EventArgs) Handles clearBtn.Click

        ResetTemplateForm()

        doUnsavedChangesExist = False

    End Sub

    Private Sub loadSelTempBtn_Click(sender As Object, e As EventArgs) Handles loadSelTempBtn.Click

        easyPreviewTreeView.BeginUpdate()
        Dim projToLoadIndex As Integer = savedProjTempsComboBox.SelectedIndex
        projTempFileMan.LoadTemplateIntoFormFromTemplateFile(projMan, projToLoadIndex, projNameTextBox, easyPreviewTreeView)
        easyPreviewTreeView.EndUpdate()

        doUnsavedChangesExist = False

        easyPreviewTreeView.ExpandAll()

    End Sub

    Private Sub delSelTempBtn_Click(sender As Object, e As EventArgs) Handles delSelTempBtn.Click

        If savedProjTempsComboBox.Items.Count > 0 Then 'make sure there are items to delete

            Dim projToDelName As String = savedProjTempsComboBox.SelectedItem.ToString

            If MessageBox.Show("Delete '" + projToDelName + "'?", "Delete Template?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                projTempFileMan.DeleteTemplateFromTemplateFile(projToDelName)
                projTempFileMan.PopulateComboBoxWithTemplateNamesFromTemplateFile(savedProjTempsComboBox)

            End If

        ElseIf savedProjTempsComboBox.Items.Count = 0 Then

            savedProjTempsComboBox.Text = ""

        End If

        easyPreviewTreeView.ExpandAll()

    End Sub

    Private Sub addSelTaskGroupTempBtn_Click(sender As Object, e As EventArgs) Handles addSelTaskGroupTempBtn.Click

        Dim selGroupIndex As Integer = savedTaskGroupTempsComboBox.SelectedIndex

        taskGroupTempFileMan.AppendTaskGroupTemplateToProjectManagerAndEasyTreeViewFromTemplateFile(projMan, easyPreviewTreeView, 0, selGroupIndex)

        doUnsavedChangesExist = True

        easyPreviewTreeView.ExpandAll()

    End Sub

    Private Sub moveSelUpBtn_Click(sender As Object, e As EventArgs) Handles moveSelUpBtn.Click

        If easyPreviewTreeView.GetIsAnyNodeSelected() = True Then

            If easyPreviewTreeView.GetIsSelectedNodeATaskGroup() = True Then

                easyPreviewTreeView.BeginUpdate()

                Dim groupIdNum As Integer = easyPreviewTreeView.GetSelectedNodeIdNum()
                Dim groupIndex As Integer = projMan.GetIndexOfTaskGroupWithIdNum(groupIdNum)
                projMan.MoveTaskGroupUp(groupIdNum)
                easyPreviewTreeView.MoveTaskGroupUp(0, groupIndex)
                easyPreviewTreeView.SelectTaskGroup(0, groupIndex - 1)
                projPrevTreeView.Select()

                easyPreviewTreeView.EndUpdate()

            ElseIf easyPreviewTreeView.GetIsSelectedNodeATask() = True Then

                easyPreviewTreeView.BeginUpdate()

                Dim taskIdNum As Integer = easyPreviewTreeView.GetSelectedNodeIdNum()
                Dim taskIndex As Integer = projMan.GetIndexOfTaskWithIdNum(taskIdNum)
                Dim parentGroupIndex As Integer = projMan.GetIndexOfTaskGroupWithTaskIdNum(taskIdNum)
                projMan.MoveTaskUp(taskIdNum)
                easyPreviewTreeView.MoveTaskUp(0, parentGroupIndex, taskIndex)
                easyPreviewTreeView.SelectTask(0, parentGroupIndex, taskIndex - 1)
                projPrevTreeView.Select()

                easyPreviewTreeView.EndUpdate()

            End If

        End If

        easyPreviewTreeView.ExpandAll()

        doUnsavedChangesExist = True

        easyPreviewTreeView.ExpandAll()

    End Sub

    Private Sub moveSelDownBtn_Click(sender As Object, e As EventArgs) Handles moveSelDownBtn.Click

        If easyPreviewTreeView.GetIsAnyNodeSelected() = True Then

            If easyPreviewTreeView.GetIsSelectedNodeATaskGroup() = True Then

                easyPreviewTreeView.BeginUpdate()

                Dim groupIdNum As Integer = easyPreviewTreeView.GetSelectedNodeIdNum()
                Dim groupIndex As Integer = projMan.GetIndexOfTaskGroupWithIdNum(groupIdNum)
                projMan.MoveTaskGroupDown(groupIdNum)
                Dim groupCount As Integer = projMan.GetCurrentNumberOfTaskGroupsInProject(0)
                easyPreviewTreeView.MoveTaskGroupDown(groupCount, 0, groupIndex)
                easyPreviewTreeView.SelectTaskGroup(0, groupIndex + 1)
                projPrevTreeView.Select()

                easyPreviewTreeView.EndUpdate()

            ElseIf easyPreviewTreeView.GetIsSelectedNodeATask() = True Then

                easyPreviewTreeView.BeginUpdate()

                Dim taskIdNum As Integer = easyPreviewTreeView.GetSelectedNodeIdNum()
                Dim taskIndex As Integer = projMan.GetIndexOfTaskWithIdNum(taskIdNum)
                projMan.MoveTaskDown(taskIdNum)
                Dim parentGroupIndex As Integer = projMan.GetIndexOfTaskGroupWithTaskIdNum(taskIdNum)
                Dim taskCount As Integer = projMan.GetCurrentNumberOfTasksInTaskGroup(0, parentGroupIndex)
                easyPreviewTreeView.MoveTaskDown(taskCount, 0, parentGroupIndex, taskIndex)
                easyPreviewTreeView.SelectTask(0, parentGroupIndex, taskIndex + 1)
                projPrevTreeView.Select()

                easyPreviewTreeView.EndUpdate()

            End If

        End If

        easyPreviewTreeView.ExpandAll()

        doUnsavedChangesExist = True

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If easyPreviewTreeView.GetIsAnyNodeSelected() = True Then

            If easyPreviewTreeView.GetIsSelectedNodeATaskGroup() = True Then

                Dim groupIdNum As Integer = easyPreviewTreeView.GetSelectedNodeIdNum()
                Dim parentProjIndex As Integer = projMan.GetIndexOfProjectWithTaskGroupIdNum(groupIdNum)
                Dim groupIndex As Integer = projMan.GetIndexOfTaskGroupWithIdNum(groupIdNum)
                Dim groupCurName As String = projMan.GetTaskGroupName(parentProjIndex, groupIndex)
                Dim groupNewName As String = InputBox("Edit Task Group Name", "Edit task group's name:", groupCurName)

                If groupNewName.Length > 0 Then

                    projMan.SetTaskGroupName(parentProjIndex, groupIndex, groupCurName)
                    easyPreviewTreeView.SetTaskGroupName(parentProjIndex, groupIndex, groupNewName)

                End If

            ElseIf easyPreviewTreeView.GetIsSelectedNodeATask() = True Then

                Dim taskIdNum As Integer = easyPreviewTreeView.GetSelectedNodeIdNum()
                Dim parentProjIndex As Integer = projMan.GetIndexOfProjectWithTaskIdNum(taskIdNum)
                Dim parentGroupIndex As Integer = projMan.GetIndexOfTaskGroupWithTaskIdNum(taskIdNum)
                Dim taskIndex As Integer = projMan.GetIndexOfTaskWithIdNum(taskIdNum)
                Dim taskCurName As String = projMan.GetTaskName(parentProjIndex, parentGroupIndex, taskIndex)
                Dim taskNewName As String = InputBox("Edit Task Name", "Edit task's name:", taskCurName)

                If taskNewName.Length > 0 Then

                    projMan.SetTaskName(parentProjIndex, parentGroupIndex, taskIndex, taskNewName)
                    easyPreviewTreeView.SetTaskName(parentProjIndex, parentGroupIndex, taskIndex, taskNewName)

                End If

            End If

        End If

    End Sub

End Class