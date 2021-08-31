<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class taskGroupTemplateEditorForm
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.taskGroupNameTextBox = New System.Windows.Forms.TextBox()
        Me.addTaskBtn = New System.Windows.Forms.Button()
        Me.doneBtn = New System.Windows.Forms.Button()
        Me.saveTaskGroupTempBtn = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.moveSelUpBtn = New System.Windows.Forms.Button()
        Me.removeSelTaskBtn = New System.Windows.Forms.Button()
        Me.moveSelDownBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.taskGroupPrevTreeView = New System.Windows.Forms.TreeView()
        Me.savedTempsComboBox = New System.Windows.Forms.ComboBox()
        Me.loadSelTempBtn = New System.Windows.Forms.Button()
        Me.delSelTempBtn = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.clearBtn = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Task Group Name:"
        '
        'taskGroupNameTextBox
        '
        Me.taskGroupNameTextBox.Location = New System.Drawing.Point(24, 48)
        Me.taskGroupNameTextBox.Name = "taskGroupNameTextBox"
        Me.taskGroupNameTextBox.Size = New System.Drawing.Size(221, 20)
        Me.taskGroupNameTextBox.TabIndex = 5
        '
        'addTaskBtn
        '
        Me.addTaskBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.addTaskBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addTaskBtn.Location = New System.Drawing.Point(7, 13)
        Me.addTaskBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.addTaskBtn.Name = "addTaskBtn"
        Me.addTaskBtn.Size = New System.Drawing.Size(118, 40)
        Me.addTaskBtn.TabIndex = 0
        Me.addTaskBtn.Text = "Add Task"
        Me.addTaskBtn.UseVisualStyleBackColor = False
        '
        'doneBtn
        '
        Me.doneBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.doneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.doneBtn.Location = New System.Drawing.Point(27, 618)
        Me.doneBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.doneBtn.Name = "doneBtn"
        Me.doneBtn.Size = New System.Drawing.Size(96, 35)
        Me.doneBtn.TabIndex = 0
        Me.doneBtn.Text = "Close Editor"
        Me.doneBtn.UseVisualStyleBackColor = False
        '
        'saveTaskGroupTempBtn
        '
        Me.saveTaskGroupTempBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.saveTaskGroupTempBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.saveTaskGroupTempBtn.Location = New System.Drawing.Point(266, 579)
        Me.saveTaskGroupTempBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.saveTaskGroupTempBtn.Name = "saveTaskGroupTempBtn"
        Me.saveTaskGroupTempBtn.Size = New System.Drawing.Size(118, 40)
        Me.saveTaskGroupTempBtn.TabIndex = 1
        Me.saveTaskGroupTempBtn.Text = "Save Task Group Template"
        Me.saveTaskGroupTempBtn.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Location = New System.Drawing.Point(24, 94)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(144, 282)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.addTaskBtn)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(132, 61)
        Me.GroupBox4.TabIndex = 22
        Me.GroupBox4.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.moveSelUpBtn)
        Me.GroupBox2.Controls.Add(Me.removeSelTaskBtn)
        Me.GroupBox2.Controls.Add(Me.moveSelDownBtn)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 70)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(132, 204)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(7, 14)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(118, 42)
        Me.Button3.TabIndex = 25
        Me.Button3.Text = "Edit Text"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'moveSelUpBtn
        '
        Me.moveSelUpBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.moveSelUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.moveSelUpBtn.Location = New System.Drawing.Point(7, 60)
        Me.moveSelUpBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.moveSelUpBtn.Name = "moveSelUpBtn"
        Me.moveSelUpBtn.Size = New System.Drawing.Size(118, 40)
        Me.moveSelUpBtn.TabIndex = 3
        Me.moveSelUpBtn.Text = "↑ Move Up"
        Me.moveSelUpBtn.UseVisualStyleBackColor = False
        '
        'removeSelTaskBtn
        '
        Me.removeSelTaskBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.removeSelTaskBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.removeSelTaskBtn.ForeColor = System.Drawing.Color.DarkRed
        Me.removeSelTaskBtn.Location = New System.Drawing.Point(7, 155)
        Me.removeSelTaskBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.removeSelTaskBtn.Name = "removeSelTaskBtn"
        Me.removeSelTaskBtn.Size = New System.Drawing.Size(118, 40)
        Me.removeSelTaskBtn.TabIndex = 5
        Me.removeSelTaskBtn.Text = "Remove Task"
        Me.removeSelTaskBtn.UseVisualStyleBackColor = False
        '
        'moveSelDownBtn
        '
        Me.moveSelDownBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.moveSelDownBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.moveSelDownBtn.Location = New System.Drawing.Point(7, 104)
        Me.moveSelDownBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.moveSelDownBtn.Name = "moveSelDownBtn"
        Me.moveSelDownBtn.Size = New System.Drawing.Size(118, 40)
        Me.moveSelDownBtn.TabIndex = 4
        Me.moveSelDownBtn.Text = "↓ Move Down"
        Me.moveSelDownBtn.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(263, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Template Preview:"
        '
        'taskGroupPrevTreeView
        '
        Me.taskGroupPrevTreeView.BackColor = System.Drawing.Color.White
        Me.taskGroupPrevTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.taskGroupPrevTreeView.HideSelection = False
        Me.taskGroupPrevTreeView.HotTracking = True
        Me.taskGroupPrevTreeView.Location = New System.Drawing.Point(266, 32)
        Me.taskGroupPrevTreeView.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.taskGroupPrevTreeView.Name = "taskGroupPrevTreeView"
        Me.taskGroupPrevTreeView.Size = New System.Drawing.Size(455, 542)
        Me.taskGroupPrevTreeView.TabIndex = 14
        '
        'savedTempsComboBox
        '
        Me.savedTempsComboBox.FormattingEnabled = True
        Me.savedTempsComboBox.Location = New System.Drawing.Point(12, 27)
        Me.savedTempsComboBox.Name = "savedTempsComboBox"
        Me.savedTempsComboBox.Size = New System.Drawing.Size(221, 21)
        Me.savedTempsComboBox.TabIndex = 15
        '
        'loadSelTempBtn
        '
        Me.loadSelTempBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.loadSelTempBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.loadSelTempBtn.Location = New System.Drawing.Point(12, 53)
        Me.loadSelTempBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.loadSelTempBtn.Name = "loadSelTempBtn"
        Me.loadSelTempBtn.Size = New System.Drawing.Size(99, 40)
        Me.loadSelTempBtn.TabIndex = 17
        Me.loadSelTempBtn.Text = "Load Selected Template"
        Me.loadSelTempBtn.UseVisualStyleBackColor = False
        '
        'delSelTempBtn
        '
        Me.delSelTempBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.delSelTempBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.delSelTempBtn.ForeColor = System.Drawing.Color.DarkRed
        Me.delSelTempBtn.Location = New System.Drawing.Point(134, 53)
        Me.delSelTempBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.delSelTempBtn.Name = "delSelTempBtn"
        Me.delSelTempBtn.Size = New System.Drawing.Size(99, 40)
        Me.delSelTempBtn.TabIndex = 6
        Me.delSelTempBtn.Text = "Delete Selected Template"
        Me.delSelTempBtn.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.delSelTempBtn)
        Me.GroupBox1.Controls.Add(Me.savedTempsComboBox)
        Me.GroupBox1.Controls.Add(Me.loadSelTempBtn)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 466)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(246, 108)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Saved Task Group Templates"
        '
        'clearBtn
        '
        Me.clearBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.clearBtn.ForeColor = System.Drawing.Color.DarkRed
        Me.clearBtn.Location = New System.Drawing.Point(603, 579)
        Me.clearBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.clearBtn.Name = "clearBtn"
        Me.clearBtn.Size = New System.Drawing.Size(118, 40)
        Me.clearBtn.TabIndex = 6
        Me.clearBtn.Text = "Clear Form"
        Me.clearBtn.UseVisualStyleBackColor = False
        '
        'taskGroupTemplateEditorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(737, 668)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.taskGroupNameTextBox)
        Me.Controls.Add(Me.clearBtn)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.doneBtn)
        Me.Controls.Add(Me.saveTaskGroupTempBtn)
        Me.Controls.Add(Me.taskGroupPrevTreeView)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "taskGroupTemplateEditorForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Task Group Template Editor"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents taskGroupNameTextBox As TextBox
    Friend WithEvents addTaskBtn As Button
    Friend WithEvents doneBtn As Button
    Friend WithEvents saveTaskGroupTempBtn As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents moveSelUpBtn As Button
    Friend WithEvents moveSelDownBtn As Button
    Friend WithEvents removeSelTaskBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents taskGroupPrevTreeView As TreeView
    Friend WithEvents savedTempsComboBox As ComboBox
    Friend WithEvents loadSelTempBtn As Button
    Friend WithEvents delSelTempBtn As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents clearBtn As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Button3 As Button
End Class
