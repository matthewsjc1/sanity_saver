<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class backupSettingsForm
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
        Me.okBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.changeBackupDirBtn = New System.Windows.Forms.Button()
        Me.backupDirTextBox = New System.Windows.Forms.TextBox()
        Me.dirBrowser = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'okBtn
        '
        Me.okBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.okBtn.Location = New System.Drawing.Point(234, 128)
        Me.okBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.okBtn.Name = "okBtn"
        Me.okBtn.Size = New System.Drawing.Size(96, 35)
        Me.okBtn.TabIndex = 1
        Me.okBtn.Text = "Ok"
        Me.okBtn.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Backup Location:"
        '
        'changeBackupDirBtn
        '
        Me.changeBackupDirBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.changeBackupDirBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.changeBackupDirBtn.Location = New System.Drawing.Point(428, 45)
        Me.changeBackupDirBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.changeBackupDirBtn.Name = "changeBackupDirBtn"
        Me.changeBackupDirBtn.Size = New System.Drawing.Size(96, 35)
        Me.changeBackupDirBtn.TabIndex = 4
        Me.changeBackupDirBtn.Text = "Change"
        Me.changeBackupDirBtn.UseVisualStyleBackColor = False
        '
        'backupDirTextBox
        '
        Me.backupDirTextBox.AcceptsTab = True
        Me.backupDirTextBox.Location = New System.Drawing.Point(127, 53)
        Me.backupDirTextBox.Name = "backupDirTextBox"
        Me.backupDirTextBox.ReadOnly = True
        Me.backupDirTextBox.Size = New System.Drawing.Size(296, 20)
        Me.backupDirTextBox.TabIndex = 5
        '
        'backupSettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 197)
        Me.ControlBox = False
        Me.Controls.Add(Me.backupDirTextBox)
        Me.Controls.Add(Me.changeBackupDirBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.okBtn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "backupSettingsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents okBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents changeBackupDirBtn As Button
    Friend WithEvents backupDirTextBox As TextBox
    Friend WithEvents dirBrowser As FolderBrowserDialog
End Class
