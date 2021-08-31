<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class projectTemplateEditorForm
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
        Me.clearBtn = New System.Windows.Forms.Button()
        Me.delSelTempBtn = New System.Windows.Forms.Button()
        Me.savedProjTempsComboBox = New System.Windows.Forms.ComboBox()
        Me.loadSelTempBtn = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.projPrevTreeView = New System.Windows.Forms.TreeView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.doneBtn = New System.Windows.Forms.Button()
        Me.saveProjTempBtn = New System.Windows.Forms.Button()
        Me.projNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.removeSelBtn = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.savedTaskGroupTempsComboBox = New System.Windows.Forms.ComboBox()
        Me.addSelTaskGroupTempBtn = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.moveSelUpBtn = New System.Windows.Forms.Button()
        Me.moveSelDownBtn = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
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
        Me.clearBtn.TabIndex = 24
        Me.clearBtn.Text = "Clear Form"
        Me.clearBtn.UseVisualStyleBackColor = False
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
        'savedProjTempsComboBox
        '
        Me.savedProjTempsComboBox.FormattingEnabled = True
        Me.savedProjTempsComboBox.Location = New System.Drawing.Point(12, 27)
        Me.savedProjTempsComboBox.Name = "savedProjTempsComboBox"
        Me.savedProjTempsComboBox.Size = New System.Drawing.Size(221, 21)
        Me.savedProjTempsComboBox.TabIndex = 15
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.delSelTempBtn)
        Me.GroupBox1.Controls.Add(Me.savedProjTempsComboBox)
        Me.GroupBox1.Controls.Add(Me.loadSelTempBtn)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 466)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(246, 108)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Saved Project Templates"
        '
        'projPrevTreeView
        '
        Me.projPrevTreeView.BackColor = System.Drawing.Color.White
        Me.projPrevTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.projPrevTreeView.HideSelection = False
        Me.projPrevTreeView.HotTracking = True
        Me.projPrevTreeView.Location = New System.Drawing.Point(266, 32)
        Me.projPrevTreeView.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.projPrevTreeView.Name = "projPrevTreeView"
        Me.projPrevTreeView.Size = New System.Drawing.Size(455, 542)
        Me.projPrevTreeView.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(263, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Template Preview:"
        '
        'doneBtn
        '
        Me.doneBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.doneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.doneBtn.Location = New System.Drawing.Point(27, 618)
        Me.doneBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.doneBtn.Name = "doneBtn"
        Me.doneBtn.Size = New System.Drawing.Size(96, 35)
        Me.doneBtn.TabIndex = 21
        Me.doneBtn.Text = "Close Editor"
        Me.doneBtn.UseVisualStyleBackColor = False
        '
        'saveProjTempBtn
        '
        Me.saveProjTempBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.saveProjTempBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.saveProjTempBtn.Location = New System.Drawing.Point(266, 579)
        Me.saveProjTempBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.saveProjTempBtn.Name = "saveProjTempBtn"
        Me.saveProjTempBtn.Size = New System.Drawing.Size(118, 40)
        Me.saveProjTempBtn.TabIndex = 22
        Me.saveProjTempBtn.Text = "Save Project Template"
        Me.saveProjTempBtn.UseVisualStyleBackColor = False
        '
        'projNameTextBox
        '
        Me.projNameTextBox.Location = New System.Drawing.Point(24, 48)
        Me.projNameTextBox.Name = "projNameTextBox"
        Me.projNameTextBox.Size = New System.Drawing.Size(221, 20)
        Me.projNameTextBox.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Project Name:"
        '
        'removeSelBtn
        '
        Me.removeSelBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.removeSelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.removeSelBtn.ForeColor = System.Drawing.Color.DarkRed
        Me.removeSelBtn.Location = New System.Drawing.Point(9, 165)
        Me.removeSelBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.removeSelBtn.Name = "removeSelBtn"
        Me.removeSelBtn.Size = New System.Drawing.Size(118, 40)
        Me.removeSelBtn.TabIndex = 8
        Me.removeSelBtn.Text = "Remove Selected"
        Me.removeSelBtn.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.savedTaskGroupTempsComboBox)
        Me.GroupBox2.Controls.Add(Me.addSelTaskGroupTempBtn)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 101)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(246, 108)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Saved Task Group Templates"
        '
        'savedTaskGroupTempsComboBox
        '
        Me.savedTaskGroupTempsComboBox.FormattingEnabled = True
        Me.savedTaskGroupTempsComboBox.Location = New System.Drawing.Point(12, 27)
        Me.savedTaskGroupTempsComboBox.Name = "savedTaskGroupTempsComboBox"
        Me.savedTaskGroupTempsComboBox.Size = New System.Drawing.Size(221, 21)
        Me.savedTaskGroupTempsComboBox.TabIndex = 15
        '
        'addSelTaskGroupTempBtn
        '
        Me.addSelTaskGroupTempBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.addSelTaskGroupTempBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addSelTaskGroupTempBtn.Location = New System.Drawing.Point(12, 53)
        Me.addSelTaskGroupTempBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.addSelTaskGroupTempBtn.Name = "addSelTaskGroupTempBtn"
        Me.addSelTaskGroupTempBtn.Size = New System.Drawing.Size(119, 40)
        Me.addSelTaskGroupTempBtn.TabIndex = 17
        Me.addSelTaskGroupTempBtn.Text = "Add Selected Template"
        Me.addSelTaskGroupTempBtn.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.moveSelUpBtn)
        Me.GroupBox3.Controls.Add(Me.removeSelBtn)
        Me.GroupBox3.Controls.Add(Me.moveSelDownBtn)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 229)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(137, 215)
        Me.GroupBox3.TabIndex = 26
        Me.GroupBox3.TabStop = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(9, 15)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(118, 42)
        Me.Button3.TabIndex = 31
        Me.Button3.Text = "Edit Text"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'moveSelUpBtn
        '
        Me.moveSelUpBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.moveSelUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.moveSelUpBtn.Location = New System.Drawing.Point(9, 70)
        Me.moveSelUpBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.moveSelUpBtn.Name = "moveSelUpBtn"
        Me.moveSelUpBtn.Size = New System.Drawing.Size(118, 40)
        Me.moveSelUpBtn.TabIndex = 6
        Me.moveSelUpBtn.Text = "↑ Move Up"
        Me.moveSelUpBtn.UseVisualStyleBackColor = False
        '
        'moveSelDownBtn
        '
        Me.moveSelDownBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.moveSelDownBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.moveSelDownBtn.Location = New System.Drawing.Point(9, 114)
        Me.moveSelDownBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.moveSelDownBtn.Name = "moveSelDownBtn"
        Me.moveSelDownBtn.Size = New System.Drawing.Size(118, 40)
        Me.moveSelDownBtn.TabIndex = 7
        Me.moveSelDownBtn.Text = "↓ Move Down"
        Me.moveSelDownBtn.UseVisualStyleBackColor = False
        '
        'projectTemplateEditorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(737, 668)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.clearBtn)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.projPrevTreeView)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.doneBtn)
        Me.Controls.Add(Me.saveProjTempBtn)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.projNameTextBox)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "projectTemplateEditorForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Project Template Editor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents clearBtn As Button
    Friend WithEvents delSelTempBtn As Button
    Friend WithEvents savedProjTempsComboBox As ComboBox
    Friend WithEvents loadSelTempBtn As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents projPrevTreeView As TreeView
    Friend WithEvents Label1 As Label
    Friend WithEvents doneBtn As Button
    Friend WithEvents saveProjTempBtn As Button
    Friend WithEvents projNameTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents removeSelBtn As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents savedTaskGroupTempsComboBox As ComboBox
    Friend WithEvents addSelTaskGroupTempBtn As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents moveSelUpBtn As Button
    Friend WithEvents moveSelDownBtn As Button
    Friend WithEvents Button3 As Button
End Class
