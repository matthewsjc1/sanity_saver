Public Class projectManager

    Private projectList As New ArrayList()
    Private randGen As New Random()

    Public Sub New()

        Randomize()

    End Sub

    Public Function GetCurrentDateAsFormattedString() As String

        Dim month As String = DateTime.Today.Month.ToString
        Dim day As String = DateTime.Today.Day.ToString
        Dim year As String = DateTime.Today.Year.ToString
        Dim formattedDate As String = month + day + year
        Return formattedDate

    End Function

    '=======================================================================
    'PROJECTS
    '=======================================================================

    Public Sub Clear()

        projectList = Nothing
        projectList = New ArrayList()

    End Sub

    Public Sub AppendNewProject(ByVal projName As String)

        Dim newProj As New project
        newProj.name = projName
        Dim idNum As Integer = randGen.Next()
        newProj.idNum = idNum
        projectList.Add(newProj)

    End Sub

    Public Function GetCurrentNumberOfProjects() As Integer

        Return projectList.Count

    End Function

    Public Sub SetProjectName(ByVal projectIndex As Integer, ByVal projectName As String)

        Dim proj As project = projectList.Item(projectIndex)
        proj.name = projectName

    End Sub

    Public Function GetProjectName(ByVal projectIndex As Integer) As String

        Dim proj As project = projectList.Item(projectIndex)
        Return proj.name

    End Function

    Public Sub SetProjecIdNum(ByVal projectIndex As Integer, ByVal projectIdNum As Integer)

        Dim proj As project = projectList.Item(projectIndex)
        proj.idNum = projectIdNum

    End Sub

    Public Function GetProjectIdNum(ByVal projectIndex As Integer) As Integer

        Dim proj As project = projectList.Item(projectIndex)
        Return proj.idNum

    End Function

    Public Sub RemoveProjectByIdNum(ByVal projectToRemoveIdNum As Integer)

        Dim projectToRemoveIndex As Integer = -1
        For curProjIndex As Integer = 0 To projectList.Count - 1

            Dim proj As project = projectList.Item(curProjIndex)
            If proj.idNum = projectToRemoveIdNum Then

                projectToRemoveIndex = curProjIndex
                Exit For

            End If

        Next

        projectList.RemoveAt(projectToRemoveIndex)

    End Sub

    Public Sub RemoveProjectByIndex(ByVal projectToRemoveIndex As Integer)

        projectList.RemoveAt(projectToRemoveIndex)

    End Sub

    Public Function GetIndexOfProjectWithIdNum(ByVal projectIdNum As Integer) As Integer

        For curProjIndex As Integer = 0 To projectList.Count - 1

            Dim proj As project = projectList.Item(curProjIndex)
            If proj.idNum = projectIdNum Then

                Return curProjIndex

            End If

        Next

    End Function

    Public Function GetIndexOfProjectWithTaskGroupIdNum(ByVal taskGroupIdNum As Integer) As Integer

        Dim targProjIndex As Integer = -1
        For curProjIndex As Integer = 0 To projectList.Count - 1

            Dim curProj As project = projectList.Item(curProjIndex)
            For curGroupIndex As Integer = 0 To curProj.taskGroupList.Count - 1

                Dim curGroup As taskGroup = curProj.taskGroupList.Item(curGroupIndex)
                Dim curGroupIdNum As Integer = curGroup.idNum
                If curGroupIdNum = taskGroupIdNum Then

                    targProjIndex = curProjIndex
                    Return targProjIndex

                End If

            Next

        Next

    End Function

    Public Function GetIndexOfProjectWithTaskIdNum(ByVal taskIdNum As Integer) As Integer

        For curProjIndex As Integer = 0 To projectList.Count - 1

            Dim curProj As project = projectList.Item(curProjIndex)

            For curGroupIndex As Integer = 0 To curProj.taskGroupList.Count - 1

                Dim curGroup As taskGroup = curProj.taskGroupList.Item(curGroupIndex)

                For curTaskIndex As Integer = 0 To curGroup.taskList.Count - 1

                    Dim curTask As task = curGroup.taskList.Item(curTaskIndex)

                    If curTask.idNum = taskIdNum Then

                        Return curProjIndex

                    End If
                Next
            Next

        Next

    End Function

    Public Function GetDoesIdNumBelongToAProject(ByVal idNum As Integer) As Boolean

        For curProjIndex As Integer = 0 To projectList.Count - 1

            Dim curProj As project = projectList.Item(curProjIndex)
            If curProj.idNum = idNum Then

                Return True

            End If

        Next

        'if no no return has been called (idNum doesn't belong to a project), return false
        Return False

    End Function

    Public Sub MoveProjectUp(ByVal projectIdNum As Integer)

        Dim projOrigIndex As Integer = GetIndexOfProjectWithIdNum(projectIdNum)

        If projOrigIndex > 0 Then

            Dim projToMove As project = projectList.Item(projOrigIndex)
            projectList.Insert(projOrigIndex - 1, projToMove)
            projectList.RemoveAt(projOrigIndex + 1)

        End If

    End Sub

    Public Sub MoveProjectDown(ByVal projectIdNum As Integer)

        Dim projOrigIndex As Integer = GetIndexOfProjectWithIdNum(projectIdNum)

        If projOrigIndex < projectList.Count - 1 Then

            Dim projToMove As project = projectList.Item(projOrigIndex)
            projectList.Insert(projOrigIndex + 2, projToMove)
            projectList.RemoveAt(projOrigIndex)

        End If

    End Sub

    Public Sub SetProjectDoneDate(ByVal projectIndex As Integer, ByVal doneDate As String)

        Dim proj As project = projectList.Item(projectIndex)
        proj.doneDate = doneDate

    End Sub

    Public Function GetProjectDoneDate(ByVal projectIndex As Integer) As String

        Dim proj As project = projectList.Item(projectIndex)
        Return proj.doneDate

    End Function

    Public Sub SetIsProjectExpanded(ByVal projectIndex As Integer, ByVal isExpanded As Boolean)

        Dim proj As project = projectList.Item(projectIndex)
        proj.isExpanded = isExpanded

    End Sub

    Public Function GetIsProjectExpanded(ByVal projectIndex As Integer) As Boolean

        Dim proj As project = projectList.Item(projectIndex)
        Return proj.isExpanded

    End Function

    '=======================================================================
    'TASK GROUPS
    '=======================================================================

    Public Sub SetWasTaskGroupChecked(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal wasChecked As Boolean)

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)

    End Sub

    Public Function GetWasTaskGroupChecked(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer) As Boolean

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)

    End Function

    Public Sub MarkTaskGroupAsDone(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer)

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        group.isDone = True

    End Sub

    Public Sub MarkTaskGroupAsNotDone(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer)

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        group.isDone = False

    End Sub

    Public Function GetIsTaskGroupDone(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer) As Boolean

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        Return group.isDone

    End Function

    Public Sub AppendNewTaskGroupToProject(ByVal projectIndex As Integer, ByVal taskGroupName As String)

        Dim proj As project = projectList.Item(projectIndex)
        Dim newGroup As New taskGroup
        newGroup.name = taskGroupName
        Dim idNum As Integer = randGen.Next()
        newGroup.idNum = idNum
        proj.taskGroupList.Add(newGroup)

    End Sub

    Public Sub InsertNewTaskGroupIntoProject(ByVal projectIndex As Integer, ByVal taskGroupName As String, ByVal taskGroupInsertIndex As Integer)

        Dim proj As project = projectList.Item(projectIndex)
        Dim newGroup As New taskGroup
        newGroup.name = taskGroupName
        Dim idNum As Integer = randGen.Next()
        newGroup.idNum = idNum
        proj.taskGroupList.Insert(taskGroupInsertIndex, newGroup)

    End Sub

    Public Function GetCurrentNumberOfTaskGroupsInProject(ByVal projectIndex As Integer) As Integer

        Dim proj As project = projectList.Item(projectIndex)
        Return proj.taskGroupList.Count

    End Function

    Public Sub RemoveTaskGroupFromProjectByIdNum(ByVal projectIndex As Integer, ByVal taskGroupToRemoveIdNum As Integer)

        Dim proj As project = projectList.Item(projectIndex)
        For curGroupIndex As Integer = 0 To proj.taskGroupList.Count - 1

            Dim curGroup As taskGroup = proj.taskGroupList.Item(curGroupIndex)
            If curGroup.idNum = taskGroupToRemoveIdNum Then

                proj.taskGroupList.RemoveAt(curGroupIndex)
                Exit Sub

            End If

        Next

    End Sub

    Public Sub RemoveTaskGroupFromProjectByIndex(ByVal projectIndex As Integer, ByVal taskGroupToRemoveIndex As Integer)

        Dim proj As project = projectList.Item(projectIndex)
        proj.taskGroupList.RemoveAt(taskGroupToRemoveIndex)

    End Sub

    Public Sub SetTaskGroupName(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskGroupName As String)

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        group.name = taskGroupName

    End Sub

    Public Function GetTaskGroupName(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer) As String

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        Return group.name

    End Function

    Public Sub SetTaskGroupIdNum(ByVal projectIndex As Integer, taskGroupIndex As Integer, taskGroupIdNum As Integer)

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        group.idNum = taskGroupIdNum

    End Sub

    Public Function GetTaskGroupIdNum(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer) As Integer

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        Return group.idNum

    End Function

    Public Function GetIndexOfTaskGroupWithTaskIdNum(ByVal taskIdNum As Integer) As Integer

        For curProjIndex As Integer = 0 To projectList.Count - 1

            Dim curProj As project = projectList.Item(curProjIndex)
            For curGroupIndex As Integer = 0 To curProj.taskGroupList.Count - 1

                Dim curGroup As taskGroup = curProj.taskGroupList.Item(curGroupIndex)
                For curTaskIndex As Integer = 0 To curGroup.taskList.Count - 1

                    Dim curTask As task = curGroup.taskList.Item(curTaskIndex)
                    If curTask.idNum = taskIdNum Then

                        Return curGroupIndex

                    End If

                Next

            Next

        Next

    End Function

    Public Function GetIndexOfTaskGroupWithIdNum(ByVal idNum As Integer) As Integer

        For curProjIndex As Integer = 0 To projectList.Count - 1

            Dim curProj As project = projectList.Item(curProjIndex)
            For curGroupIndex As Integer = 0 To curProj.taskGroupList.Count - 1

                Dim curGroup As taskGroup = curProj.taskGroupList.Item(curGroupIndex)
                If curGroup.idNum = idNum Then

                    Return curGroupIndex

                End If

            Next

        Next

    End Function

    Public Function GetDoesIdNumBelongToATaskGroup(ByVal idNum As Integer) As Boolean

        For curProjIndex As Integer = 0 To projectList.Count - 1

            Dim curProj As project = projectList.Item(curProjIndex)
            For curGroupIndex As Integer = 0 To curProj.taskGroupList.Count - 1

                Dim curGroup As taskGroup = curProj.taskGroupList.Item(curGroupIndex)
                If curGroup.idNum = idNum Then

                    Return True

                End If

            Next

        Next

        'if no return has been called (idNum doesn't belong to a task group), return false
        Return False

    End Function

    Public Sub MoveTaskGroupUp(ByVal taskGroupIdNum As Integer)

        Dim groupOrigIndex As Integer = GetIndexOfTaskGroupWithIdNum(taskGroupIdNum)
        Dim parentProjIndex As Integer = GetIndexOfProjectWithTaskGroupIdNum(taskGroupIdNum)

        If groupOrigIndex > 0 Then

            Dim parentProj As project = projectList.Item(parentProjIndex)
            Dim groupToMove As taskGroup = parentProj.taskGroupList.Item(groupOrigIndex)
            parentProj.taskGroupList.Insert(groupOrigIndex - 1, groupToMove)
            parentProj.taskGroupList.RemoveAt(groupOrigIndex + 1)

        End If

    End Sub

    Public Sub MoveTaskGroupDown(ByVal taskGroupIdNum As Integer)

        Dim groupOrigIndex As Integer = GetIndexOfTaskGroupWithIdNum(taskGroupIdNum)
        Dim parentProjIndex As Integer = GetIndexOfProjectWithTaskGroupIdNum(taskGroupIdNum)
        Dim groupCount As Integer = GetCurrentNumberOfTaskGroupsInProject(parentProjIndex)

        If groupOrigIndex < groupCount - 1 Then

            Dim parentProj As project = projectList.Item(parentProjIndex)
            Dim groupToMove As taskGroup = parentProj.taskGroupList.Item(groupOrigIndex)
            parentProj.taskGroupList.Insert(groupOrigIndex + 2, groupToMove)
            parentProj.taskGroupList.RemoveAt(groupOrigIndex)

        End If

    End Sub

    Public Sub SetTaskGroupDoneDate(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal doneDate As String)

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        group.doneDate = doneDate

    End Sub

    Public Function GetTaskGroupDoneDate(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer) As String

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        Return group.doneDate

    End Function

    Public Sub SetIsTaskGroupExpanded(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal isExpanded As Boolean)

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        group.isExpanded = isExpanded

    End Sub

    Public Function GetIsTaskGroupExpanded(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer) As Boolean

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        Return group.isExpanded

    End Function

    '=======================================================================
    'TASKS
    '=======================================================================

    Public Sub AppendNewTaskToTaskGroup(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskName As String)

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        Dim newTask As New task
        newTask.name = taskName
        Dim idNum As Integer = randGen.Next()
        newTask.idNum = idNum
        group.taskList.Add(newTask)

    End Sub

    Public Sub InsertNewTaskIntoTaskGroup(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskName As String, ByVal taskInsertIndex As Integer)

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        Dim newTask As New task
        newTask.name = taskName
        Dim idNum As Integer = randGen.Next()
        newTask.idNum = idNum
        group.taskList.Insert(taskInsertIndex, newTask)

    End Sub

    Public Function GetCurrentNumberOfTasksInTaskGroup(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer) As Integer

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        Return group.taskList.Count

    End Function

    Public Sub SetTaskName(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskIndex As Integer, ByVal taskName As String)

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        Dim targTask As task = group.taskList.Item(taskIndex)
        targTask.name = taskName

    End Sub

    Public Function GetTaskName(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskIndex As Integer) As String

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        Dim targTask As task = group.taskList.Item(taskIndex)
        Return targTask.name

    End Function

    Public Sub SetTaskIdNum(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskIndex As Integer, ByVal taskIdNum As Integer)

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        Dim targTask As task = group.taskList.Item(taskIndex)
        targTask.idNum = taskIdNum

    End Sub

    Public Function GetTaskIdNum(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskIndex As Integer) As Integer

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        Dim targTask As task = group.taskList.Item(taskIndex)
        Return targTask.idNum

    End Function

    Public Sub MarkTaskAsDone(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskIndex As Integer)

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        Dim targTask As task = group.taskList.Item(taskIndex)
        targTask.isDone = True

    End Sub

    Public Sub MarkTaskAsNotDone(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskIndex As Integer)

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        Dim targTask As task = group.taskList.Item(taskIndex)
        targTask.isDone = False

    End Sub

    Public Function GetIsTaskDone(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskIndex As Integer) As Boolean

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        Dim targTask As task = group.taskList.Item(taskIndex)
        Return targTask.isDone

    End Function

    Public Sub RemoveTaskFromTaskGroupByIdNumber(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskToRemoveIdNum As Integer)

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        For curTaskIndex As Integer = 0 To group.taskList.Count - 1

            Dim curTask As task = group.taskList.Item(curTaskIndex)
            If curTask.idNum = taskToRemoveIdNum Then

                group.taskList.RemoveAt(curTaskIndex)
                Exit Sub

            End If

        Next

    End Sub

    Public Sub RemoveTaskFromTaskGroupByIndex(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskToRemoveIndex As Integer)

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        group.taskList.RemoveAt(taskToRemoveIndex)

    End Sub

    Public Function GetDoesIdNumBelongToATask(ByVal idNum As Integer) As Boolean

        For curProjIndex As Integer = 0 To projectList.Count - 1

            Dim curProj As project = projectList.Item(curProjIndex)
            For curGroupIndex As Integer = 0 To curProj.taskGroupList.Count - 1

                Dim curGroup As taskGroup = curProj.taskGroupList.Item(curGroupIndex)
                For curTaskIndex As Integer = 0 To curGroup.taskList.Count - 1

                    Dim curTask As task = curGroup.taskList.Item(curTaskIndex)
                    If curTask.idNum = idNum Then

                        Return True

                    End If

                Next

            Next

        Next

        'if no return has been called (idNum doesn't belong to a task), return false
        Return False

    End Function

    Public Sub MoveTaskUp(ByVal taskIdNum As Integer)

        Dim taskOrigIndex As Integer = GetIndexOfTaskWithIdNum(taskIdNum)
        Dim parentProjIndex As Integer = GetIndexOfProjectWithTaskIdNum(taskIdNum)
        Dim parentGroupIndex As Integer = GetIndexOfTaskGroupWithTaskIdNum(taskIdNum)

        If taskOrigIndex > 0 Then

            Dim parentProj As project = projectList.Item(parentProjIndex)
            Dim parentGroup As taskGroup = parentProj.taskGroupList.Item(parentGroupIndex)
            Dim taskToMove As task = parentGroup.taskList.Item(taskOrigIndex)
            parentGroup.taskList.Insert(taskOrigIndex - 1, taskToMove)
            parentGroup.taskList.RemoveAt(taskOrigIndex + 1)

        End If

    End Sub

    Public Sub MoveTaskDown(ByVal taskIdNum As Integer)

        Dim taskOrigIndex As Integer = GetIndexOfTaskWithIdNum(taskIdNum)
        Dim parentProjIndex As Integer = GetIndexOfProjectWithTaskIdNum(taskIdNum)
        Dim parentGroupIndex As Integer = GetIndexOfTaskGroupWithTaskIdNum(taskIdNum)
        Dim taskCount As Integer = GetCurrentNumberOfTasksInTaskGroup(parentProjIndex, parentGroupIndex)

        If taskOrigIndex < taskCount - 1 Then

            Dim parentProj As project = projectList.Item(parentProjIndex)
            Dim parentGroup As taskGroup = parentProj.taskGroupList.Item(parentGroupIndex)
            Dim taskToMove As task = parentGroup.taskList.Item(taskOrigIndex)
            parentGroup.taskList.Insert(taskOrigIndex + 2, taskToMove)
            parentGroup.taskList.RemoveAt(taskOrigIndex)

        End If

    End Sub

    Public Sub SetTaskDoneDate(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskIndex As Integer, ByVal taskDoneDate As String)

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        Dim taskObj As task = group.taskList.Item(taskIndex)
        taskObj.doneDate = taskDoneDate

    End Sub

    Public Function GetTaskDoneDate(ByVal projectIndex As Integer, ByVal taskGroupIndex As Integer, ByVal taskIndex As Integer) As String

        Dim proj As project = projectList.Item(projectIndex)
        Dim group As taskGroup = proj.taskGroupList.Item(taskGroupIndex)
        Dim taskObj As task = group.taskList.Item(taskIndex)
        Return taskObj.doneDate

    End Function

    Public Function GetIndexOfTaskWithIdNum(ByVal taskIdNum As Integer)

        For curProjIndex As Integer = 0 To projectList.Count - 1

            Dim curProj As project = projectList.Item(curProjIndex)

            For curGroupIndex As Integer = 0 To curProj.taskGroupList.Count - 1

                Dim curGroup As taskGroup = curProj.taskGroupList.Item(curGroupIndex)

                For curTaskIndex As Integer = 0 To curGroup.taskList.Count - 1

                    Dim curTask As task = curGroup.taskList.Item(curTaskIndex)

                    If curTask.idNum = taskIdNum Then

                        Return curTaskIndex

                    End If

                Next

            Next

        Next

    End Function

End Class
