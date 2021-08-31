Imports System.IO

Public Class projectTemplatesFileManager

    'Public Sub AppendProjectToDoneFileFrom??

    '=====================================================
    'project_templates.ss
    'file format:
    '|p|                                    'start of a project block
    'project name
    '|g|                                    'start of a task group block
    'task group name
    '|t|                                    'start of a task block
    'task name
    '|*|                                    'end of template symbol
    '=====================================================

    Public Sub AppendNewProjectTemplateToFileFromProjectManager(ByVal projectManagerName As projectManager)

        Dim fileStream As New StreamWriter(PROJECT_TEMPLATES_FILE_NAME, True)

        fileStream.WriteLine(PROJECT_BLOCK_SYMBOL)

        fileStream.WriteLine(projectManagerName.GetProjectName(0))

        For curGroupIndex As Integer = 0 To projectManagerName.GetCurrentNumberOfTaskGroupsInProject(0) - 1

            fileStream.WriteLine(TASK_GROUP_BLOCK_SYMBOL)

            fileStream.WriteLine(projectManagerName.GetTaskGroupName(0, curGroupIndex))

            For curTaskIndex As Integer = 0 To projectManagerName.GetCurrentNumberOfTasksInTaskGroup(0, curGroupIndex) - 1

                fileStream.WriteLine(TASK_BLOCK_SYMBOL)

                fileStream.WriteLine(projectManagerName.GetTaskName(0, curGroupIndex, curTaskIndex))

            Next

        Next

        fileStream.WriteLine(END_OF_TEMPLATE_SYMBOL)

        fileStream.Close()

    End Sub

    Public Function DoesTemplateNameExistInTemplateFile(ByVal templateName As String) As Boolean

        If File.Exists(PROJECT_TEMPLATES_FILE_NAME) = True Then

            Dim fileStream As New StreamReader(PROJECT_TEMPLATES_FILE_NAME)
            Dim curLine As String
            Dim curProjIndex As Integer = -1

            Do

                curLine = fileStream.ReadLine()

                If curLine = PROJECT_BLOCK_SYMBOL Then

                    curProjIndex += 1

                    curLine = fileStream.ReadLine()
                    Dim curLineLowerCase As String = curLine.ToLower()
                    Dim templateNameLowercase As String = templateName.ToLower()

                    If curLineLowerCase = templateNameLowercase Then 'check in all lowercase, so it's not case-dependent

                        fileStream.Close()
                        Return True

                    End If

                End If

            Loop Until curLine Is Nothing

            fileStream.Close()

            Return False

        Else

            Return False

        End If

    End Function

    Public Sub PopulateComboBoxWithTemplateNamesFromTemplateFile(ByRef comboBoxName As ComboBox)

        comboBoxName.Items.Clear()

        If File.Exists(PROJECT_TEMPLATES_FILE_NAME) = True Then

            Dim fileStream As New StreamReader(PROJECT_TEMPLATES_FILE_NAME)
            Dim curLine As String
            Dim curProjIndex As Integer = -1

            Do

                curLine = fileStream.ReadLine()

                If curLine = PROJECT_BLOCK_SYMBOL Then

                    curProjIndex += 1

                    curLine = fileStream.ReadLine() 'project name
                    comboBoxName.Items.Add(curLine)

                End If

            Loop Until curLine Is Nothing

            fileStream.Close()

            If comboBoxName.Items.Count > 0 Then

                comboBoxName.SelectedIndex = 0

            End If

        End If

    End Sub

    Public Sub LoadTemplateIntoFormFromTemplateFile(ByRef projectManagerName As projectManager, ByVal templateToLoadIndex As Integer, ByRef projectNameTextBox As TextBox, ByRef easyTreeViewName As easyTreeView)

        If File.Exists(PROJECT_TEMPLATES_FILE_NAME) = True Then

            projectNameTextBox.Clear()

            projectManagerName.Clear()
            projectManagerName.AppendNewProject("")

            easyTreeViewName.Clear()
            easyTreeViewName.AppendNewProject(projectManagerName, "", 0)

            Dim fileStream As New StreamReader(PROJECT_TEMPLATES_FILE_NAME)
            Dim curLine As String
            Dim curProjIndex As Integer = -1
            Dim wasTemplateFound As Boolean = False

            Do

                curLine = fileStream.ReadLine()

                If curLine = PROJECT_BLOCK_SYMBOL Then

                    curProjIndex += 1

                    If curProjIndex = templateToLoadIndex Then

                        'load project
                        curLine = fileStream.ReadLine() 'project name
                        Dim projName As String = curLine
                        projectNameTextBox.Text = projName
                        projectManagerName.SetProjectName(0, projName)
                        easyTreeViewName.SetProjectName(0, projName)

                        Dim curGroupIndex As Integer = -1
                        Dim curTaskIndex As Integer = -1

                        Do

                            curLine = fileStream.ReadLine()

                            'load task group
                            If curLine = TASK_GROUP_BLOCK_SYMBOL Then

                                curGroupIndex += 1

                                curLine = fileStream.ReadLine() 'task group name
                                Dim curGroupName As String = curLine
                                projectManagerName.AppendNewTaskGroupToProject(0, curGroupName)
                                Dim curGroupIdNum As Integer = projectManagerName.GetTaskGroupIdNum(0, curGroupIndex)
                                easyTreeViewName.AppendNewTaskGroup(projectManagerName, 0, curGroupName, curGroupIdNum)

                                curTaskIndex = -1

                                'load task
                            ElseIf curLine = TASK_BLOCK_SYMBOL Then

                                curTaskIndex += 1

                                curLine = fileStream.ReadLine() 'task name
                                Dim curTaskName As String = curLine
                                projectManagerName.AppendNewTaskToTaskGroup(0, curGroupIndex, curTaskName)
                                Dim curTaskIdNum As Integer = projectManagerName.GetTaskIdNum(0, curGroupIndex, curTaskIndex)
                                easyTreeViewName.AppendNewTask(projectManagerName, 0, curGroupIndex, curTaskName, curTaskIdNum)

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

        If File.Exists(PROJECT_TEMPLATES_FILE_NAME) = True Then

            'read template file; write all templates to temp file, except one to delete
            Dim fileStream As New StreamReader(PROJECT_TEMPLATES_FILE_NAME)
            Dim tempFileStream As New StreamWriter(TEMP_FILE_NAME, False)
            Dim curLine As String

            Do

                curLine = fileStream.ReadLine()

                If curLine = PROJECT_BLOCK_SYMBOL Then

                    'read project name
                    curLine = fileStream.ReadLine()
                    Dim curProjName As String = curLine

                    If curProjName <> templateToDeleteName Then

                        tempFileStream.WriteLine(PROJECT_BLOCK_SYMBOL)

                        'write project name
                        tempFileStream.WriteLine(curProjName)

                        Do

                            curLine = fileStream.ReadLine()

                            If curLine = TASK_GROUP_BLOCK_SYMBOL Then

                                tempFileStream.WriteLine(TASK_GROUP_BLOCK_SYMBOL)

                                'read task group name
                                curLine = fileStream.ReadLine()
                                Dim curGroupName As String = curLine

                                'write task group name
                                tempFileStream.WriteLine(curGroupName)

                            ElseIf curLine = TASK_BLOCK_SYMBOL Then

                                tempFileStream.WriteLine(TASK_BLOCK_SYMBOL)

                                'read task name
                                curLine = fileStream.ReadLine()
                                Dim curTaskName As String = curLine

                                'write task name
                                tempFileStream.WriteLine(curTaskName)

                            End If

                        Loop Until curLine = END_OF_TEMPLATE_SYMBOL

                        tempFileStream.WriteLine(END_OF_TEMPLATE_SYMBOL)

                    End If

                End If

            Loop Until curLine Is Nothing

            fileStream.Close()
            tempFileStream.Close()

            'copy temp file contents into template file, then delete temp file
            Dim copyStream As New StreamReader(TEMP_FILE_NAME)
            Dim pasteStream As New StreamWriter(PROJECT_TEMPLATES_FILE_NAME)
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

    Public Sub AppendProjectTemplateToProjectManagerAndEasyTreeViewFromTemplateFile(ByRef projectManagerName As projectManager, ByRef easyTreeViewName As easyTreeView, ByVal projectTemplateIndex As Integer, ByVal projectName As String)

        If File.Exists(PROJECT_TEMPLATES_FILE_NAME) = True Then

            easyTreeViewName.BeginUpdate()

            Dim fileStream As New StreamReader(PROJECT_TEMPLATES_FILE_NAME)
            Dim curLine As String
            Dim curProjIndex As Integer = -1
            Dim wasTemplateFound As Boolean = False

            Do

                curLine = fileStream.ReadLine()

                If curLine = PROJECT_BLOCK_SYMBOL Then

                    curProjIndex += 1

                    If curProjIndex = projectTemplateIndex Then

                        curLine = fileStream.ReadLine() 'project name
                        Dim curProjName As String = curLine

                        projectManagerName.AppendNewProject(projectName)

                        Dim newProjIndex As Integer = projectManagerName.GetCurrentNumberOfProjects() - 1
                        Dim curProjIdNum As Integer = projectManagerName.GetProjectIdNum(newProjIndex)

                        easyTreeViewName.AppendNewProject(projectManagerName, projectName, curProjIdNum)

                        Dim curGroupIndex As Integer = -1
                        Dim curTaskIndex As Integer = -1

                        Do

                            curLine = fileStream.ReadLine()

                            If curLine = TASK_GROUP_BLOCK_SYMBOL Then

                                curGroupIndex += 1
                                curTaskIndex = -1

                                curLine = fileStream.ReadLine() 'task group name
                                Dim curGroupName As String = curLine

                                projectManagerName.AppendNewTaskGroupToProject(newProjIndex, curGroupName)

                                Dim curGroupIdNum As Integer = projectManagerName.GetTaskGroupIdNum(newProjIndex, curGroupIndex)

                                easyTreeViewName.AppendNewTaskGroup(projectManagerName, newProjIndex, curGroupName, curGroupIdNum)

                            ElseIf curLine = TASK_BLOCK_SYMBOL Then

                                curTaskIndex += 1

                                curLine = fileStream.ReadLine() 'task name
                                Dim curTaskName As String = curLine

                                projectManagerName.AppendNewTaskToTaskGroup(newProjIndex, curGroupIndex, curTaskName)

                                Dim curTaskIdNum As Integer = projectManagerName.GetTaskIdNum(newProjIndex, curGroupIndex, curTaskIndex)

                                easyTreeViewName.AppendNewTask(projectManagerName, newProjIndex, curGroupIndex, curTaskName, curTaskIdNum)

                            End If

                        Loop Until curLine = END_OF_TEMPLATE_SYMBOL Or curLine Is Nothing

                    End If

                End If

            Loop Until wasTemplateFound = True Or curLine Is Nothing

        End If

        easyTreeViewName.EndUpdate()

    End Sub

End Class
