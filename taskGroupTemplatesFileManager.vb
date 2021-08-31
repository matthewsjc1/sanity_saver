Imports System.IO

Public Class taskGroupTemplatesFileManager

    '=====================================================
    'task_group_templates.ss
    'file format:
    '|g|                                    'start of a task group block
    'task group name
    '|t|                                    'start of a task block
    'task name
    '=====================================================

    Public Sub AppendNewTaskGroupTemplateToFileFromProjectManager(ByVal projectManagerName As projectManager)

        Dim fileStream As New StreamWriter(TASK_GROUP_TEMPLATES_FILE_NAME, True)

        fileStream.WriteLine(TASK_GROUP_BLOCK_SYMBOL)
        fileStream.WriteLine(projectManagerName.GetTaskGroupName(0, 0)) 'task group name

        For curTaskIndex As Integer = 0 To projectManagerName.GetCurrentNumberOfTasksInTaskGroup(0, 0) - 1

            fileStream.WriteLine(TASK_BLOCK_SYMBOL)
            fileStream.WriteLine(projectManagerName.GetTaskName(0, 0, curTaskIndex)) 'task name (description)

        Next

        fileStream.WriteLine(END_OF_TEMPLATE_SYMBOL)

        fileStream.Close()

    End Sub

    Public Function DoesTemplateNameExistInTemplateFile(ByVal templateName As String) As Boolean

        If File.Exists(TASK_GROUP_TEMPLATES_FILE_NAME) = True Then

            Dim fileStream As New StreamReader(TASK_GROUP_TEMPLATES_FILE_NAME)
            Dim curLine As String
            Dim curGroupIndex As Integer = -1
            Do

                curLine = fileStream.ReadLine()
                If curLine = TASK_GROUP_BLOCK_SYMBOL Then

                    curGroupIndex += 1

                    curLine = fileStream.ReadLine()
                    Dim curLineLowercase As String = curLine.ToLower()
                    Dim templateNameLowercase As String = templateName.ToLower()
                    If curLineLowercase = templateNameLowercase Then 'check in all lower, so it's not case-depedent

                        fileStream.Close()
                        Return True

                    End If

                End If

            Loop Until curLine Is Nothing

            fileStream.Close()

            Return False

        ElseIf File.Exists(TASK_GROUP_TEMPLATES_FILE_NAME) = False Then

            Return False

        End If

    End Function

    Public Sub PopulateComboBoxWithTemplateNamesFromTemplateFile(ByRef comboBoxName As ComboBox)

        comboBoxName.Items.Clear()

        If File.Exists(TASK_GROUP_TEMPLATES_FILE_NAME) = True Then

            Dim fileStream As New StreamReader(TASK_GROUP_TEMPLATES_FILE_NAME)
            Dim curLine As String
            Dim curGroupIndex As Integer = -1
            Do

                curLine = fileStream.ReadLine()
                If curLine = TASK_GROUP_BLOCK_SYMBOL Then

                    curGroupIndex += 1

                    curLine = fileStream.ReadLine() 'task group name
                    comboBoxName.Items.Add(curLine)

                End If

            Loop Until curLine Is Nothing

            fileStream.Close()

            If comboBoxName.Items.Count > 0 Then

                comboBoxName.SelectedIndex = 0

            End If

        End If

    End Sub

    Public Sub LoadTemplateIntoFormFromTemplateFile(ByRef projectManagerName As projectManager, ByVal templateToLoadIndex As Integer, ByRef taskGroupNameTextBox As TextBox, ByRef easyTreeViewName As easyTreeView, ByVal holderProjectName As String)

        If File.Exists(TASK_GROUP_TEMPLATES_FILE_NAME) = True Then

            projectManagerName.Clear()
            projectManagerName.AppendNewProject(holderProjectName)
            projectManagerName.AppendNewTaskGroupToProject(0, "")

            taskGroupNameTextBox.Clear()

            easyTreeViewName.Clear()
            easyTreeViewName.AppendNewProject(projectManagerName, holderProjectName, 0)
            easyTreeViewName.AppendNewTaskGroup(projectManagerName, 0, "", 0)
            easyTreeViewName.ExpandAll()

            Dim fileStream As New StreamReader(TASK_GROUP_TEMPLATES_FILE_NAME)
            Dim curLine As String
            Dim curGroupIndex As Integer = -1
            Dim wasTemplateFound As Boolean = False
            Do

                curLine = fileStream.ReadLine()
                If curLine = TASK_GROUP_BLOCK_SYMBOL Then

                    curGroupIndex += 1

                    If curGroupIndex = templateToLoadIndex Then

                        curLine = fileStream.ReadLine() 'task group name
                        taskGroupNameTextBox.Text = curLine

                        Dim curTaskIndex As Integer = -1
                        Do

                            curLine = fileStream.ReadLine()
                            If curLine = TASK_BLOCK_SYMBOL Then

                                curTaskIndex += 1

                                curLine = fileStream.ReadLine() 'task name
                                projectManagerName.AppendNewTaskToTaskGroup(0, 0, curLine)
                                Dim curTaskIdNum As Integer = projectManagerName.GetTaskIdNum(0, 0, curTaskIndex)
                                easyTreeViewName.AppendNewTask(projectManagerName, 0, 0, curLine, curTaskIdNum)

                            End If

                        Loop Until curLine = END_OF_TEMPLATE_SYMBOL Or curLine Is Nothing

                        wasTemplateFound = True

                    End If

                End If

            Loop Until wasTemplateFound = True Or curLine Is Nothing

            fileStream.Close()

        End If

    End Sub

    Public Sub DeleteTemplateFromTemplateFile(ByRef templateToDeleteName As String)

        If File.Exists(TASK_GROUP_TEMPLATES_FILE_NAME) = True Then

            'read template file; write all templatesto temp file, except one to delete
            Dim fileStream As New StreamReader(TASK_GROUP_TEMPLATES_FILE_NAME)
            Dim tempFileStream As New StreamWriter(TEMP_FILE_NAME, False)
            Dim curLine As String
            Do

                curLine = fileStream.ReadLine()
                If curLine = TASK_GROUP_BLOCK_SYMBOL Then
                    curLine = fileStream.ReadLine() 'read task group name
                    If curLine <> templateToDeleteName Then

                        tempFileStream.WriteLine(TASK_GROUP_BLOCK_SYMBOL) 'write task group symbol
                        tempFileStream.WriteLine(curLine) 'write task group name

                        'loop through tasks
                        Do

                            curLine = fileStream.ReadLine()
                            If curLine = TASK_BLOCK_SYMBOL Then

                                tempFileStream.WriteLine(TASK_BLOCK_SYMBOL) 'write task symbol
                                curLine = fileStream.ReadLine() 'read task name
                                tempFileStream.WriteLine(curLine) 'write task name

                            End If

                        Loop Until curLine = END_OF_TEMPLATE_SYMBOL

                        tempFileStream.WriteLine(END_OF_TEMPLATE_SYMBOL) 'write end of template symbol

                    End If

                End If

            Loop Until curLine Is Nothing

            fileStream.Close()
            tempFileStream.Close()

            'copy temp file contents into template file, then delete temp file
            Dim copyStream As New StreamReader(TEMP_FILE_NAME)
            Dim pasteStream As New StreamWriter(TASK_GROUP_TEMPLATES_FILE_NAME)
            curLine = ""

            Do

                curLine = copyStream.ReadLine()
                pasteStream.WriteLine(curLine)

            Loop Until curLine Is Nothing

            copyStream.Close()
            pasteStream.Close()
            File.Delete(TEMP_FILE_NAME)

        End If

    End Sub

    Public Sub AppendTaskGroupTemplateToProjectManagerAndEasyTreeViewFromTemplateFile(ByRef projectManagerName As projectManager, ByRef easyTreeViewName As easyTreeView, ByVal parentProjectIndex As Integer, ByVal taskGroupTemplateIndex As Integer)

        If File.Exists(TASK_GROUP_TEMPLATES_FILE_NAME) = True Then

            Dim fileStream As New StreamReader(TASK_GROUP_TEMPLATES_FILE_NAME)
            Dim curLine As String
            Dim curGroupIndex As Integer = -1
            Dim wasTemplateFound As Boolean = False

            Do

                curLine = fileStream.ReadLine()

                If curLine = TASK_GROUP_BLOCK_SYMBOL Then

                    curGroupIndex += 1

                    If curGroupIndex = taskGroupTemplateIndex Then

                        curLine = fileStream.ReadLine() 'task group name
                        Dim curGroupName As String = curLine
                        projectManagerName.AppendNewTaskGroupToProject(parentProjectIndex, curGroupName)
                        Dim newGroupIndex As Integer = projectManagerName.GetCurrentNumberOfTaskGroupsInProject(parentProjectIndex) - 1
                        Dim curGroupIdNum As Integer = projectManagerName.GetTaskGroupIdNum(parentProjectIndex, newGroupIndex)
                        easyTreeViewName.AppendNewTaskGroup(projectManagerName, parentProjectIndex, curGroupName, curGroupIdNum)

                        Dim curTaskIndex As Integer = -1

                        Do

                            curLine = fileStream.ReadLine()

                            If curLine = TASK_BLOCK_SYMBOL Then

                                curTaskIndex += 1

                                curLine = fileStream.ReadLine() 'task name
                                projectManagerName.AppendNewTaskToTaskGroup(parentProjectIndex, newGroupIndex, curLine)
                                Dim curTaskIdNum As Integer = projectManagerName.GetTaskIdNum(parentProjectIndex, newGroupIndex, curTaskIndex)
                                easyTreeViewName.AppendNewTask(projectManagerName, parentProjectIndex, newGroupIndex, curLine, curTaskIdNum)

                            End If

                        Loop Until curLine = END_OF_TEMPLATE_SYMBOL Or curLine Is Nothing

                        wasTemplateFound = True

                    End If

                End If

            Loop Until wasTemplateFound = True Or curLine Is Nothing

            fileStream.Close()

        End If

    End Sub

End Class
