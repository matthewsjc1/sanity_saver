<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dailyLogForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.copyToClipboardBtn = New System.Windows.Forms.Button()
        Me.doneBtn = New System.Windows.Forms.Button()
        Me.dailyLogTextBox = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'copyToClipboardBtn
        '
        Me.copyToClipboardBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.copyToClipboardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.copyToClipboardBtn.Location = New System.Drawing.Point(127, 457)
        Me.copyToClipboardBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.copyToClipboardBtn.Name = "copyToClipboardBtn"
        Me.copyToClipboardBtn.Size = New System.Drawing.Size(118, 40)
        Me.copyToClipboardBtn.TabIndex = 1
        Me.copyToClipboardBtn.Text = "Copy To Clipboard"
        Me.copyToClipboardBtn.UseVisualStyleBackColor = False
        '
        'doneBtn
        '
        Me.doneBtn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.doneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.doneBtn.Location = New System.Drawing.Point(371, 457)
        Me.doneBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.doneBtn.Name = "doneBtn"
        Me.doneBtn.Size = New System.Drawing.Size(118, 40)
        Me.doneBtn.TabIndex = 2
        Me.doneBtn.Text = "Done"
        Me.doneBtn.UseVisualStyleBackColor = False
        '
        'dailyLogTextBox
        '
        Me.dailyLogTextBox.Location = New System.Drawing.Point(12, 12)
        Me.dailyLogTextBox.Name = "dailyLogTextBox"
        Me.dailyLogTextBox.Size = New System.Drawing.Size(594, 430)
        Me.dailyLogTextBox.TabIndex = 3
        Me.dailyLogTextBox.Text = ""
        Me.dailyLogTextBox.WordWrap = False
        '
        'dailyLogForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(618, 533)
        Me.ControlBox = False
        Me.Controls.Add(Me.dailyLogTextBox)
        Me.Controls.Add(Me.doneBtn)
        Me.Controls.Add(Me.copyToClipboardBtn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "dailyLogForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daily Log"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents copyToClipboardBtn As Button
    Friend WithEvents doneBtn As Button
    Friend WithEvents dailyLogTextBox As RichTextBox
End Class
