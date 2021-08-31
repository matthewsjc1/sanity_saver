<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.toDoPage = New System.Windows.Forms.TabPage()
        Me.statRepBtn = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.addTaskBtn = New System.Windows.Forms.Button()
        Me.addEmptyProjBtn = New System.Windows.Forms.Button()
        Me.addEmptyTaskGroupBtn = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.editTextBtn = New System.Windows.Forms.Button()
        Me.moveSelUpBtn = New System.Windows.Forms.Button()
        Me.moveSelDownBtn = New System.Windows.Forms.Button()
        Me.cancelRemSelBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.savedTaskGroupTempComboBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.savedProjTempComboBox = New System.Windows.Forms.ComboBox()
        Me.addNewTaskFromTempBtn = New System.Windows.Forms.Button()
        Me.addNewProjFromTempBtn = New System.Windows.Forms.Button()
        Me.toDoTreeView = New System.Windows.Forms.TreeView()
        Me.donePage = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.clearSearchBtn = New System.Windows.Forms.Button()
        Me.searchTextBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.findBtn = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dailyLogDatePickerLabel = New System.Windows.Forms.Label()
        Me.dailyLogDatePicker = New System.Windows.Forms.DateTimePicker()
        Me.generateLogBtn = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.doneTreeView = New System.Windows.Forms.TreeView()
        Me.checkUpdateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileBackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TemplatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TaskGroupTemplateEditorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenProjectTemplateEditorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutSanitySaverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabControl.SuspendLayout()
        Me.toDoPage.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.donePage.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabControl
        '
        Me.tabControl.Controls.Add(Me.toDoPage)
        Me.tabControl.Controls.Add(Me.donePage)
        Me.tabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl.Location = New System.Drawing.Point(0, 24)
        Me.tabControl.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(737, 769)
        Me.tabControl.TabIndex = 0
        '
        'toDoPage
        '
        Me.toDoPage.BackColor = System.Drawing.SystemColors.Control
        Me.toDoPage.Controls.Add(Me.statRepBtn)
        Me.toDoPage.Controls.Add(Me.GroupBox5)
        Me.toDoPage.Controls.Add(Me.GroupBox3)
        Me.toDoPage.Controls.Add(Me.Label1)
        Me.toDoPage.Controls.Add(Me.GroupBox2)
        Me.toDoPage.Controls.Add(Me.toDoTreeView)
        Me.toDoPage.Location = New System.Drawing.Point(4, 22)
        Me.toDoPage.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.toDoPage.Name = "toDoPage"
        Me.toDoPage.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.toDoPage.Size = New System.Drawing.Size(729, 743)
        Me.toDoPage.TabIndex = 0
        Me.toDoPage.Text = "To Do"
        '
        'statRepBtn
        '
        Me.statRepBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.statRepBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.statRepBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.statRepBtn.Location = New System.Drawing.Point(517, 683)
        Me.statRepBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.statRepBtn.Name = "statRepBtn"
        Me.statRepBtn.Size = New System.Drawing.Size(118, 42)
        Me.statRepBtn.TabIndex = 7
        Me.statRepBtn.Text = "Status Report"
        Me.statRepBtn.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.addTaskBtn)
        Me.GroupBox5.Controls.Add(Me.addEmptyProjBtn)
        Me.GroupBox5.Controls.Add(Me.addEmptyTaskGroupBtn)
        Me.GroupBox5.Location = New System.Drawing.Point(505, 260)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Size = New System.Drawing.Size(144, 167)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Add Empty"
        '
        'addTaskBtn
        '
        Me.addTaskBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.addTaskBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addTaskBtn.Location = New System.Drawing.Point(12, 114)
        Me.addTaskBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.addTaskBtn.Name = "addTaskBtn"
        Me.addTaskBtn.Size = New System.Drawing.Size(118, 40)
        Me.addTaskBtn.TabIndex = 0
        Me.addTaskBtn.Text = "Add Task"
        Me.addTaskBtn.UseVisualStyleBackColor = False
        '
        'addEmptyProjBtn
        '
        Me.addEmptyProjBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.addEmptyProjBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addEmptyProjBtn.Location = New System.Drawing.Point(12, 26)
        Me.addEmptyProjBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.addEmptyProjBtn.Name = "addEmptyProjBtn"
        Me.addEmptyProjBtn.Size = New System.Drawing.Size(118, 40)
        Me.addEmptyProjBtn.TabIndex = 0
        Me.addEmptyProjBtn.Text = "Add Empty Project"
        Me.addEmptyProjBtn.UseVisualStyleBackColor = False
        '
        'addEmptyTaskGroupBtn
        '
        Me.addEmptyTaskGroupBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.addEmptyTaskGroupBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addEmptyTaskGroupBtn.Location = New System.Drawing.Point(12, 70)
        Me.addEmptyTaskGroupBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.addEmptyTaskGroupBtn.Name = "addEmptyTaskGroupBtn"
        Me.addEmptyTaskGroupBtn.Size = New System.Drawing.Size(118, 40)
        Me.addEmptyTaskGroupBtn.TabIndex = 1
        Me.addEmptyTaskGroupBtn.Text = "Add Empty Task Group"
        Me.addEmptyTaskGroupBtn.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.editTextBtn)
        Me.GroupBox3.Controls.Add(Me.moveSelUpBtn)
        Me.GroupBox3.Controls.Add(Me.moveSelDownBtn)
        Me.GroupBox3.Controls.Add(Me.cancelRemSelBtn)
        Me.GroupBox3.Location = New System.Drawing.Point(505, 434)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(144, 230)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Current Selection"
        '
        'editTextBtn
        '
        Me.editTextBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.editTextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.editTextBtn.Location = New System.Drawing.Point(12, 26)
        Me.editTextBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.editTextBtn.Name = "editTextBtn"
        Me.editTextBtn.Size = New System.Drawing.Size(118, 42)
        Me.editTextBtn.TabIndex = 6
        Me.editTextBtn.Text = "Edit Text"
        Me.editTextBtn.UseVisualStyleBackColor = False
        '
        'moveSelUpBtn
        '
        Me.moveSelUpBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.moveSelUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.moveSelUpBtn.Location = New System.Drawing.Point(12, 81)
        Me.moveSelUpBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.moveSelUpBtn.Name = "moveSelUpBtn"
        Me.moveSelUpBtn.Size = New System.Drawing.Size(118, 40)
        Me.moveSelUpBtn.TabIndex = 3
        Me.moveSelUpBtn.Text = "↑ Move Up"
        Me.moveSelUpBtn.UseVisualStyleBackColor = False
        '
        'moveSelDownBtn
        '
        Me.moveSelDownBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.moveSelDownBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.moveSelDownBtn.Location = New System.Drawing.Point(12, 125)
        Me.moveSelDownBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.moveSelDownBtn.Name = "moveSelDownBtn"
        Me.moveSelDownBtn.Size = New System.Drawing.Size(118, 40)
        Me.moveSelDownBtn.TabIndex = 4
        Me.moveSelDownBtn.Text = "↓ Move Down"
        Me.moveSelDownBtn.UseVisualStyleBackColor = False
        '
        'cancelRemSelBtn
        '
        Me.cancelRemSelBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cancelRemSelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelRemSelBtn.ForeColor = System.Drawing.Color.DarkRed
        Me.cancelRemSelBtn.Location = New System.Drawing.Point(12, 176)
        Me.cancelRemSelBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.cancelRemSelBtn.Name = "cancelRemSelBtn"
        Me.cancelRemSelBtn.Size = New System.Drawing.Size(118, 40)
        Me.cancelRemSelBtn.TabIndex = 5
        Me.cancelRemSelBtn.Text = "Cancel + Remove"
        Me.cancelRemSelBtn.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "To Do:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.savedTaskGroupTempComboBox)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.savedProjTempComboBox)
        Me.GroupBox2.Controls.Add(Me.addNewTaskFromTempBtn)
        Me.GroupBox2.Controls.Add(Me.addNewProjFromTempBtn)
        Me.GroupBox2.Location = New System.Drawing.Point(505, 29)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(206, 226)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Add From Templates"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Saved Task Group Templates:"
        '
        'savedTaskGroupTempComboBox
        '
        Me.savedTaskGroupTempComboBox.FormattingEnabled = True
        Me.savedTaskGroupTempComboBox.Location = New System.Drawing.Point(12, 45)
        Me.savedTaskGroupTempComboBox.Name = "savedTaskGroupTempComboBox"
        Me.savedTaskGroupTempComboBox.Size = New System.Drawing.Size(180, 21)
        Me.savedTaskGroupTempComboBox.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Saved Project Templates:"
        '
        'savedProjTempComboBox
        '
        Me.savedProjTempComboBox.FormattingEnabled = True
        Me.savedProjTempComboBox.Location = New System.Drawing.Point(12, 145)
        Me.savedProjTempComboBox.Name = "savedProjTempComboBox"
        Me.savedProjTempComboBox.Size = New System.Drawing.Size(180, 21)
        Me.savedProjTempComboBox.TabIndex = 1
        '
        'addNewTaskFromTempBtn
        '
        Me.addNewTaskFromTempBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.addNewTaskFromTempBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addNewTaskFromTempBtn.Location = New System.Drawing.Point(12, 71)
        Me.addNewTaskFromTempBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.addNewTaskFromTempBtn.Name = "addNewTaskFromTempBtn"
        Me.addNewTaskFromTempBtn.Size = New System.Drawing.Size(104, 40)
        Me.addNewTaskFromTempBtn.TabIndex = 0
        Me.addNewTaskFromTempBtn.Text = "Add Task Group Template"
        Me.addNewTaskFromTempBtn.UseVisualStyleBackColor = False
        '
        'addNewProjFromTempBtn
        '
        Me.addNewProjFromTempBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.addNewProjFromTempBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addNewProjFromTempBtn.Location = New System.Drawing.Point(12, 171)
        Me.addNewProjFromTempBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.addNewProjFromTempBtn.Name = "addNewProjFromTempBtn"
        Me.addNewProjFromTempBtn.Size = New System.Drawing.Size(104, 40)
        Me.addNewProjFromTempBtn.TabIndex = 0
        Me.addNewProjFromTempBtn.Text = "Add " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Project Template"
        Me.addNewProjFromTempBtn.UseVisualStyleBackColor = False
        '
        'toDoTreeView
        '
        Me.toDoTreeView.BackColor = System.Drawing.Color.White
        Me.toDoTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.toDoTreeView.CheckBoxes = True
        Me.toDoTreeView.HideSelection = False
        Me.toDoTreeView.HotTracking = True
        Me.toDoTreeView.Location = New System.Drawing.Point(17, 29)
        Me.toDoTreeView.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.toDoTreeView.Name = "toDoTreeView"
        Me.toDoTreeView.Size = New System.Drawing.Size(471, 696)
        Me.toDoTreeView.TabIndex = 0
        '
        'donePage
        '
        Me.donePage.BackColor = System.Drawing.SystemColors.Control
        Me.donePage.Controls.Add(Me.GroupBox4)
        Me.donePage.Controls.Add(Me.GroupBox1)
        Me.donePage.Controls.Add(Me.Label4)
        Me.donePage.Controls.Add(Me.doneTreeView)
        Me.donePage.Location = New System.Drawing.Point(4, 22)
        Me.donePage.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.donePage.Name = "donePage"
        Me.donePage.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.donePage.Size = New System.Drawing.Size(729, 743)
        Me.donePage.TabIndex = 1
        Me.donePage.Text = "Done"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.clearSearchBtn)
        Me.GroupBox4.Controls.Add(Me.searchTextBox)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.findBtn)
        Me.GroupBox4.Location = New System.Drawing.Point(10, 180)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(227, 106)
        Me.GroupBox4.TabIndex = 17
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Search"
        '
        'clearSearchBtn
        '
        Me.clearSearchBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.clearSearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.clearSearchBtn.ForeColor = System.Drawing.Color.DarkRed
        Me.clearSearchBtn.Location = New System.Drawing.Point(14, 57)
        Me.clearSearchBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.clearSearchBtn.Name = "clearSearchBtn"
        Me.clearSearchBtn.Size = New System.Drawing.Size(83, 34)
        Me.clearSearchBtn.TabIndex = 18
        Me.clearSearchBtn.Text = "Clear Search"
        Me.clearSearchBtn.UseVisualStyleBackColor = False
        '
        'searchTextBox
        '
        Me.searchTextBox.Location = New System.Drawing.Point(79, 25)
        Me.searchTextBox.Name = "searchTextBox"
        Me.searchTextBox.Size = New System.Drawing.Size(135, 20)
        Me.searchTextBox.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Search For:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'findBtn
        '
        Me.findBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.findBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.findBtn.Location = New System.Drawing.Point(131, 57)
        Me.findBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.findBtn.Name = "findBtn"
        Me.findBtn.Size = New System.Drawing.Size(83, 34)
        Me.findBtn.TabIndex = 10
        Me.findBtn.Text = "Find"
        Me.findBtn.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dailyLogDatePickerLabel)
        Me.GroupBox1.Controls.Add(Me.dailyLogDatePicker)
        Me.GroupBox1.Controls.Add(Me.generateLogBtn)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(227, 132)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Generate Daily Log"
        '
        'dailyLogDatePickerLabel
        '
        Me.dailyLogDatePickerLabel.AutoSize = True
        Me.dailyLogDatePickerLabel.Location = New System.Drawing.Point(11, 23)
        Me.dailyLogDatePickerLabel.Name = "dailyLogDatePickerLabel"
        Me.dailyLogDatePickerLabel.Size = New System.Drawing.Size(33, 13)
        Me.dailyLogDatePickerLabel.TabIndex = 24
        Me.dailyLogDatePickerLabel.Text = "Date:"
        Me.dailyLogDatePickerLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dailyLogDatePicker
        '
        Me.dailyLogDatePicker.Location = New System.Drawing.Point(14, 39)
        Me.dailyLogDatePicker.Name = "dailyLogDatePicker"
        Me.dailyLogDatePicker.Size = New System.Drawing.Size(200, 20)
        Me.dailyLogDatePicker.TabIndex = 22
        '
        'generateLogBtn
        '
        Me.generateLogBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.generateLogBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.generateLogBtn.Location = New System.Drawing.Point(96, 74)
        Me.generateLogBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.generateLogBtn.Name = "generateLogBtn"
        Me.generateLogBtn.Size = New System.Drawing.Size(118, 38)
        Me.generateLogBtn.TabIndex = 9
        Me.generateLogBtn.Text = "Generate"
        Me.generateLogBtn.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(243, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Done:"
        '
        'doneTreeView
        '
        Me.doneTreeView.BackColor = System.Drawing.Color.White
        Me.doneTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.doneTreeView.HideSelection = False
        Me.doneTreeView.Location = New System.Drawing.Point(246, 32)
        Me.doneTreeView.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.doneTreeView.Name = "doneTreeView"
        Me.doneTreeView.Size = New System.Drawing.Size(468, 696)
        Me.doneTreeView.TabIndex = 1
        '
        'checkUpdateTimer
        '
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileBackupToolStripMenuItem, Me.TemplatesToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(737, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileBackupToolStripMenuItem
        '
        Me.FileBackupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BackupSettingsToolStripMenuItem})
        Me.FileBackupToolStripMenuItem.Name = "FileBackupToolStripMenuItem"
        Me.FileBackupToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.FileBackupToolStripMenuItem.Text = "File Backup"
        '
        'BackupSettingsToolStripMenuItem
        '
        Me.BackupSettingsToolStripMenuItem.Name = "BackupSettingsToolStripMenuItem"
        Me.BackupSettingsToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.BackupSettingsToolStripMenuItem.Text = "Backup Settings"
        '
        'TemplatesToolStripMenuItem
        '
        Me.TemplatesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TaskGroupTemplateEditorToolStripMenuItem, Me.OpenProjectTemplateEditorToolStripMenuItem})
        Me.TemplatesToolStripMenuItem.Name = "TemplatesToolStripMenuItem"
        Me.TemplatesToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.TemplatesToolStripMenuItem.Text = "Templates"
        '
        'TaskGroupTemplateEditorToolStripMenuItem
        '
        Me.TaskGroupTemplateEditorToolStripMenuItem.Name = "TaskGroupTemplateEditorToolStripMenuItem"
        Me.TaskGroupTemplateEditorToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.TaskGroupTemplateEditorToolStripMenuItem.Text = "Task Group Template Editor"
        '
        'OpenProjectTemplateEditorToolStripMenuItem
        '
        Me.OpenProjectTemplateEditorToolStripMenuItem.Name = "OpenProjectTemplateEditorToolStripMenuItem"
        Me.OpenProjectTemplateEditorToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.OpenProjectTemplateEditorToolStripMenuItem.Text = "Project Template Editor"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutSanitySaverToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.HelpToolStripMenuItem.Text = "Contact"
        '
        'AboutSanitySaverToolStripMenuItem
        '
        Me.AboutSanitySaverToolStripMenuItem.Name = "AboutSanitySaverToolStripMenuItem"
        Me.AboutSanitySaverToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.AboutSanitySaverToolStripMenuItem.Text = "Contact Me"
        '
        'mainForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(737, 793)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.Name = "mainForm"
        Me.ShowIcon = False
        Me.Text = "Sanity Saver"
        Me.tabControl.ResumeLayout(False)
        Me.toDoPage.ResumeLayout(False)
        Me.toDoPage.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.donePage.ResumeLayout(False)
        Me.donePage.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tabControl As TabControl
    Friend WithEvents toDoPage As TabPage
    Friend WithEvents donePage As TabPage
    Friend WithEvents toDoTreeView As TreeView
    Friend WithEvents moveSelDownBtn As Button
    Friend WithEvents moveSelUpBtn As Button
    Friend WithEvents cancelRemSelBtn As Button
    Friend WithEvents addNewTaskFromTempBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents addNewProjFromTempBtn As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents addTaskBtn As Button
    Friend WithEvents addEmptyProjBtn As Button
    Friend WithEvents addEmptyTaskGroupBtn As Button
    Friend WithEvents savedProjTempComboBox As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents savedTaskGroupTempComboBox As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents doneTreeView As TreeView
    Friend WithEvents findBtn As Button
    Friend WithEvents generateLogBtn As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents searchTextBox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents checkUpdateTimer As Timer
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutSanitySaverToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TemplatesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenProjectTemplateEditorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TaskGroupTemplateEditorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dailyLogDatePicker As DateTimePicker
    Friend WithEvents dailyLogDatePickerLabel As Label
    Friend WithEvents clearSearchBtn As Button
    Friend WithEvents editTextBtn As Button
    Friend WithEvents FileBackupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BackupSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents statRepBtn As Button
End Class
