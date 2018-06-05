<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Main
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
        Me.lb_log = New System.Windows.Forms.ListBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tp_main = New System.Windows.Forms.TabPage()
        Me.tp_logs = New System.Windows.Forms.TabPage()
        Me.pnl_workspace = New System.Windows.Forms.Panel()
        Me.TabControl1.SuspendLayout()
        Me.tp_main.SuspendLayout()
        Me.tp_logs.SuspendLayout()
        Me.SuspendLayout()
        '
        'lb_log
        '
        Me.lb_log.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lb_log.FormattingEnabled = True
        Me.lb_log.Location = New System.Drawing.Point(3, 3)
        Me.lb_log.Name = "lb_log"
        Me.lb_log.Size = New System.Drawing.Size(1027, 568)
        Me.lb_log.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 650)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(983, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(983, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tp_main)
        Me.TabControl1.Controls.Add(Me.tp_logs)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 25)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(983, 625)
        Me.TabControl1.TabIndex = 4
        '
        'tp_main
        '
        Me.tp_main.Controls.Add(Me.pnl_workspace)
        Me.tp_main.Location = New System.Drawing.Point(4, 22)
        Me.tp_main.Name = "tp_main"
        Me.tp_main.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_main.Size = New System.Drawing.Size(975, 599)
        Me.tp_main.TabIndex = 0
        Me.tp_main.Text = "main view"
        Me.tp_main.UseVisualStyleBackColor = True
        '
        'tp_logs
        '
        Me.tp_logs.Controls.Add(Me.lb_log)
        Me.tp_logs.Location = New System.Drawing.Point(4, 22)
        Me.tp_logs.Name = "tp_logs"
        Me.tp_logs.Padding = New System.Windows.Forms.Padding(3)
        Me.tp_logs.Size = New System.Drawing.Size(1033, 574)
        Me.tp_logs.TabIndex = 1
        Me.tp_logs.Text = "log view"
        Me.tp_logs.UseVisualStyleBackColor = True
        '
        'pnl_workspace
        '
        Me.pnl_workspace.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pnl_workspace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_workspace.Location = New System.Drawing.Point(0, 0)
        Me.pnl_workspace.Name = "pnl_workspace"
        Me.pnl_workspace.Size = New System.Drawing.Size(975, 337)
        Me.pnl_workspace.TabIndex = 0
        '
        'Frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 672)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "Frm_Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.TabControl1.ResumeLayout(False)
        Me.tp_main.ResumeLayout(False)
        Me.tp_logs.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_log As ListBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tp_main As TabPage
    Friend WithEvents tp_logs As TabPage
    Friend WithEvents pnl_workspace As Panel
End Class
