Public Class easyTreeView

    'how to add nodes:
    '--------------------
    'toDoTreeView.Nodes.Add("node 1 - parent")
    'toDoTreeView.Nodes(0).Nodes.Add("node 1.1 - child of node 1")
    'toDoTreeView.Nodes(0).Nodes(0).Nodes.Add("node 1.1.1 - child of node 1.1; grandchild of node 1")

    'how to get node counts:
    '--------------------
    'toDoTreeView.Nodes.Count()
    'toDoTreeView.Nodes(projectIndex).Nodes.Count()
    'toDoTreeView.Nodes(projectIndex).Nodes(taskGroupIndex).Nodes.Count()

    Private treeViewRef As TreeView 'tree view this class operates on
    Private lastFoundProjIndex As Integer = -1
    Private lastFoundGroupIndex As Integer = -1
    Private lastFoundTaskIndex As Integer = -1

    Public Sub SetTreeView(ByRef treeViewName As TreeView)

        treeViewRef = treeViewName

    End Sub

    Public Sub Clear()

        treeViewRef.Nodes.Clear()

    End Sub

    Public Sub BeginUpdate()

        treeViewRef.BeginUpdate()

    End Sub

    Public Sub EndUpdate()

        treeViewRef.EndUpdate()

    End Sub

    Public Sub ExpandAll()

        treeViewRef.ExpandAll()

    End Sub

    Public Sub RemoveSelectedNode()

        treeViewRef.SelectedNode.Remove()

        treeViewRef.Refresh()

    End Sub

    Public Function GetIsAnyNodeSelected() As Boolean

        If treeViewRef.SelectedNode IsNot Nothing Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function GetSelectedNodeText() As String

        Return treeViewRef.SelectedNode.Text

    End Function

    Public Function GetSelectedNodeIdNum() As Integer

        Return treeViewRef.SelectedNode.Tag

    End Function

    Public Sub ResetSearchCounters()

        lastFoundProjIndex = -1
        lastFoundGroupIndex = -1
        lastFoundTaskIndex = -1

    End Sub

    Public Function SearchForNextTermInstance(ByVal searchTerm As String) As Integer

        If treeViewRef.Nodes.Count > 0 Then

            For curProjIndex As Integer = 0 To treeViewRef.Nodes.Count - 1

                If treeViewRef.Nodes(curProjIndex).Text.ToLower.Contains(searchTerm.ToLower) = True Then

                    treeViewRef.SelectedNode = treeViewRef.Nodes(curProjIndex)
                    lastFoundProjIndex = curProjIndex

                    Return True

                End If

                For curGroupIndex As Integer = 0 To treeViewRef.Nodes(curProjIndex).Nodes.Count - 1

                    If treeViewRef.Nodes(curProjIndex).Nodes(curGroupIndex).Text.ToLower.Contains(searchTerm.ToLower) = True Then

                        treeViewRef.SelectedNode = treeViewRef.Nodes(curProjIndex).Nodes(curGroupIndex)
                        lastFoundProjIndex = curProjIndex
                        lastFoundGroupIndex = curGroupIndex

                        Return True

                    End If

                    For curTaskIndex As Integer = 0 To treeViewRef.Nodes(curProjIndex).Nodes(curGroupIndex).Nodes.Count - 1

                        If treeViewRef.Nodes(curProjIndex).Nodes(curGroupIndex).Nodes(curTaskIndex).Text.ToLower.Contains(searchTerm.ToLower) = True Then

                            treeViewRef.SelectedNode = treeViewRef.Nodes(curProjIndex).Nodes(curGroupIndex).Nodes(curTaskIndex)
                            lastFoundProjIndex = curProjIndex
                            lastFoundGroupIndex = curGroupIndex
                            lastFoundTaskIndex = curTaskIndex

                            Return True

                        End If

                    Next

                Next

            Next

        End If

        Return False

    End Function

    '=============================================================================================
    'PROJECT ROUTINES
    '=============================================================================================

    Public Sub AppendNewProject(ByVal projectManagerName As projectManager, ByVal projectName As String, ByVal projectIdNum As Integer)

        treeViewRef.Nodes.Add(projectName)
        Dim newProjIndex As Integer = projectManagerName.GetCurrentNumberOfProjects() - 1
        treeViewRef.Nodes(newProjIndex).BackColor = Color.DimGray
        treeViewRef.Nodes(newProjIndex).ForeColor = Color.White
        treeViewRef.Nodes(newProjIndex).Tag = projectIdNum
        treeViewRef.Refresh()

    End Sub

    Public Function GetIsSelectedNodeAProject() As Boolean

        If GetSelectedNodeHierarchyDepth() = 1 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub MoveProjectUp(ByVal projectIndex As Integer)

        If projectIndex > 0 Then

            Dim projNodeToMove As TreeNode = treeViewRef.Nodes(projectIndex).Clone()
            treeViewRef.Nodes.Insert(projectIndex - 1, projNodeToMove)
            treeViewRef.Nodes.RemoveAt(projectIndex + 1)

        End If

    End Sub

    Public Sub MoveProjectDown(ByVal currentProjectCount As Integer, projectIndex As Integer)

        If projectIndex < currentProjectCount - 1 Then

            Dim projNodeToMove As TreeNode = treeViewRef.Nodes(projectIndex).Clone()
            treeViewRef.Nodes.Insert(projectIndex + 2, projNodeToMove)
            treeViewRef.Nodes.RemoveAt(projectIndex)

        End If

    End Sub

    Public Function GetIsProjectChecked(ByVal projectIndex As Integer) As Boolean

        Return treeViewRef.Nodes(projectIndex).Checked

    End Function

    Public Function GetProjectCount() As Integer

        Return treeViewRef.Nodes.Count()

    End Function

    Public Sub SetCheckOnForProject(ByVal projectIndex As Integer)

        treeViewRef.Nodes(projectIndex).Checked = True

    End Sub

    Public Sub SetCheckOffForProject(ByVal projectIndex As Integer)

        treeViewRef.Nodes(projectIndex).Checked = False

    End Sub

    Public Sub RemoveProject(ByVal projectIndex As Integer)

        treeViewRef.Nodes.RemoveAt(projectIndex)

    End Sub

    Public Function GetSelectedProjectIndex() As Integer 'return -1 if no node is selected

        If GetIsAnyNodeSelected() = True Then

            For curProjIndex As Integer = 0 To treeViewRef.Nodes.Count() - 1

                If treeViewRef.Nodes(curProjIndex).Tag = GetSelectedNodeIdNum() Then

                    Return curProjIndex

                End If

            Next

        Else

            Return -1

        End If

    End Function

    Public Sub SetProjectName(ByVal projectIndex As Integer, ByVal projectName As String)

        treeViewRef.Nodes(projectIndex).Text = projectName

    End Sub

    Public Sub SelectProject(ByVal projectIndex As Integer)

        If projectIndex >= 0 Then

            treeViewRef.SelectedNode = treeViewRef.Nodes(projectIndex)

        End If

    End Sub

    Public Sub ExpandProject(ByVal projectIndex As Integer)

        treeViewRef.Nodes(projectIndex).Expand()

    End Sub

    Public Sub ExpandProjectAndChildren(ByVal projectManagerName As projectManager, ByVal projectIndex As Integer)

        treeViewRef.Nodes(projectIndex).Expand()

        For curGroupIndex As Integer = 0 To projectManagerName.GetCurrentNumberOfTaskGroupsInProject(projectIndex) - 1

            treeViewRef.Nodes(projectIndex).Nodes(curGroupIndex).Expand()

        Next

    End Sub

    Public Sub CollapseProject(ByVal projectIndex As Integer)

        treeViewRef.Nodes(projectIndex).Collapse()

    End Sub

    Public Function GetIsProjectExpanded(ByVal projectIndex As Integer) As Boolean

        Return treeViewRef.Nodes(projectIndex).IsExpanded

    End Function

    '=============================================================================================
    'TASK GROUP ROUTINES
    '=============================================================================================

    Public Sub SetCheckOnForTaskGroup(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer)

        treeViewRef.Nodes(projectIndex).Nodes(taskGroupIndex).Checked = True

    End Sub

    Public Function GetIsSelectedNodeATaskGroup() As Boolean

        If GetSelectedNodeHierarchyDepth() = 2 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub AppendNewTaskGroup(ByVal projectManagerName As projectManager, ByVal projectIndex As Integer, ByVal taskGroupName As String, ByVal taskGroupIdNum As Integer)

        treeViewRef.Nodes(projectIndex).Nodes.Add(taskGroupName)
        Dim newGroupIndex As Integer = projectManagerName.GetCurrentNumberOfTaskGroupsInProject(projectIndex) - 1
        treeViewRef.Nodes(projectIndex).Nodes(newGroupIndex).BackColor = Color.Silver
        treeViewRef.Nodes(projectIndex).Nodes(newGroupIndex).ForeColor = Color.White
        treeViewRef.Nodes(projectIndex).Nodes(newGroupIndex).Tag = taskGroupIdNum
        treeViewRef.Refresh()

    End Sub

    Public Sub SetTaskGroupName(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskGroupName As String)

        treeViewRef.Nodes(projectIndex).Nodes(taskGroupIndex).Text = taskGroupName

    End Sub

    Public Sub MoveTaskGroupUp(ByVal parentProjectIndex As Integer, ByVal taskGroupIndex As Integer)

        If taskGroupIndex > 0 Then

            Dim groupNodeToMove As TreeNode = treeViewRef.Nodes(parentProjectIndex).Nodes(taskGroupIndex).Clone()
            treeViewRef.Nodes(parentProjectIndex).Nodes.Insert(taskGroupIndex - 1, groupNodeToMove)
            treeViewRef.Nodes(parentProjectIndex).Nodes.RemoveAt(taskGroupIndex + 1)

        End If

    End Sub

    Public Sub MoveTaskGroupDown(ByVal taskGroupCount As Integer, ByVal parentProjectIndex As Integer, ByVal taskGroupIndex As Integer)

        If taskGroupIndex < taskGroupCount - 1 Then

            Dim groupNodeToMove As TreeNode = treeViewRef.Nodes(parentProjectIndex).Nodes(taskGroupIndex).Clone()
            treeViewRef.Nodes(parentProjectIndex).Nodes.Insert(taskGroupIndex + 2, groupNodeToMove)
            treeViewRef.Nodes(parentProjectIndex).Nodes.RemoveAt(taskGroupIndex)

        End If

    End Sub

    Public Function GetIsTaskGroupChecked(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer) As Boolean

        Return treeViewRef.Nodes(projectIndex).Nodes(taskGroupIndex).Checked

    End Function

    Public Function GetTaskGroupCountInProject(ByVal projectIndex As Integer) As Integer

        Return treeViewRef.Nodes(projectIndex).Nodes.Count()

    End Function

    Public Sub SelectTaskGroup(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer)

        If taskGroupIndex >= 0 Then

            treeViewRef.SelectedNode = treeViewRef.Nodes(projectIndex).Nodes(taskGroupIndex)

        End If

    End Sub

    Public Sub ExpandTaskGroup(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer)

        treeViewRef.Nodes(projectIndex).Nodes(taskGroupIndex).Expand()

    End Sub

    Public Sub CollapseTaskGroup(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer)

        treeViewRef.Nodes(projectIndex).Nodes(taskGroupIndex).Collapse()

    End Sub

    Public Function GetIsTaskGroupExpanded(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer) As Boolean

        Return treeViewRef.Nodes(projectIndex).Nodes(taskGroupIndex).IsExpanded

    End Function

    '=============================================================================================
    'TASK ROUTINES
    '=============================================================================================

    Public Function GetIsSelectedNodeATask() As Boolean

        If GetSelectedNodeHierarchyDepth() = 3 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub AppendNewTask(ByVal projectManagerName As projectManager, ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskName As String, ByVal taskIdNum As Integer)

        treeViewRef.Nodes(projectIndex).Nodes(taskGroupIndex).Nodes.Add(taskName)
        Dim newTaskIndex As Integer = projectManagerName.GetCurrentNumberOfTasksInTaskGroup(projectIndex, taskGroupIndex) - 1
        treeViewRef.Nodes(projectIndex).Nodes(taskGroupIndex).Nodes(newTaskIndex).Tag = taskIdNum

        treeViewRef.Refresh()

    End Sub

    Public Sub MoveTaskUp(ByVal parentProjectIndex As Integer, ByVal parentTaskGroupIndex As Integer, ByVal taskIndex As Integer)

        If taskIndex > 0 Then

            Dim taskNodeToMove As TreeNode = treeViewRef.Nodes(parentProjectIndex).Nodes(parentTaskGroupIndex).Nodes(taskIndex).Clone()
            treeViewRef.Nodes(parentProjectIndex).Nodes(parentTaskGroupIndex).Nodes.Insert(taskIndex - 1, taskNodeToMove)
            treeViewRef.Nodes(parentProjectIndex).Nodes(parentTaskGroupIndex).Nodes.RemoveAt(taskIndex + 1)

        End If

    End Sub

    Public Sub MoveTaskDown(ByVal taskCount As Integer, ByVal parentProjectIndex As Integer, ByVal parentTaskGroupIndex As Integer, ByVal taskIndex As Integer)

        If taskIndex < taskCount - 1 Then

            Dim taskNodeToMove As TreeNode = treeViewRef.Nodes(parentProjectIndex).Nodes(parentTaskGroupIndex).Nodes(taskIndex).Clone()
            treeViewRef.Nodes(parentProjectIndex).Nodes(parentTaskGroupIndex).Nodes.Insert(taskIndex + 2, taskNodeToMove)
            treeViewRef.Nodes(parentProjectIndex).Nodes(parentTaskGroupIndex).Nodes.RemoveAt(taskIndex)

        End If

    End Sub

    Public Sub InsertNewTask(ByVal projectManagerName As projectManager, ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskName As String, ByVal taskInsertIndex As Integer)

        treeViewRef.Nodes(projectIndex).Nodes(taskGroupIndex).Nodes.Insert(taskInsertIndex, taskName)
        treeViewRef.Nodes(projectIndex).Nodes(taskGroupIndex).Tag = projectManagerName.GetTaskIdNum(projectIndex, taskGroupIndex, taskInsertIndex)

    End Sub

    Public Function GetIsTaskChecked(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskIndex As Integer) As Boolean

        Return treeViewRef.Nodes(projectIndex).Nodes(taskGroupIndex).Nodes(taskIndex).Checked

    End Function

    Public Sub SetCheckOnForTask(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskIndex As Integer)

        treeViewRef.Nodes(projectIndex).Nodes(taskGroupIndex).Nodes(taskIndex).Checked = True

    End Sub

    Public Sub SetCheckOffForTask(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskIndex As Integer)

        treeViewRef.Nodes(projectIndex).Nodes(taskGroupIndex).Nodes(taskIndex).Checked = False

    End Sub

    Public Function GetTaskCountInTaskGroup(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer) As Integer

        Return treeViewRef.Nodes(projectIndex).Nodes(taskGroupIndex).Nodes.Count()

    End Function

    Public Sub SetTaskFontColor(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskIndex As Integer, ByVal colorName As Color)

        treeViewRef.Nodes(projectIndex).Nodes(taskGroupIndex).Nodes(taskIndex).ForeColor = colorName

    End Sub

    Public Sub SelectTask(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskIndex As Integer)

        If taskIndex >= 0 Then

            treeViewRef.SelectedNode = treeViewRef.Nodes(projectIndex).Nodes(taskGroupIndex).Nodes(taskIndex)

        End If

    End Sub

    Public Sub SetTaskName(ByVal parentProjectIndex As Integer, ByVal parentTaskGroupIndex As Integer, ByVal taskIndex As Integer, ByVal taskName As String)

        treeViewRef.Nodes(parentProjectIndex).Nodes(parentTaskGroupIndex).Nodes(taskIndex).Text = taskName

    End Sub

    '=============================================================================================
    'PRIVATE ROUTINES
    '=============================================================================================

    Private Function GetSelectedNodeHierarchyDepth() 'returns '-1' if no node is selected

        'check if something is selected
        If GetIsAnyNodeSelected() = True Then

            Dim fullPath As String = GetSelectedNodePath()
            Dim slashCount As Integer = 1
            For Each curChar As Char In fullPath

                If curChar = "\" Then

                    slashCount += 1

                End If

            Next
            Return slashCount

        ElseIf GetIsAnyNodeSelected() = False Then

            Return -1

        End If

    End Function

    Private Function GetSelectedNodeParentPath() As String

        If treeViewRef.SelectedNode Is Nothing Then 'error trap if no node selected
            Return ""
        ElseIf treeViewRef.SelectedNode.Parent Is Nothing Then
            Return ""
        Else
            Return treeViewRef.SelectedNode.Parent.FullPath
        End If

    End Function

    Private Function GetSelectedNodePath() As String

        If treeViewRef.SelectedNode Is Nothing Then
            Return ""
        Else
            Return treeViewRef.SelectedNode.FullPath
        End If

    End Function

End Class
