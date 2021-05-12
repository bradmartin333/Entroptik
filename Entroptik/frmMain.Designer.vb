<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.pbx = New System.Windows.Forms.PictureBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenWorkspaceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenImagesDirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewScoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BatchEditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoTrainToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadFollowPatternToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NextStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunAllStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartOverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TipsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.pbx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.pbx, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStatus, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 24)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(401, 342)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'pbx
        '
        Me.pbx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbx.Location = New System.Drawing.Point(3, 3)
        Me.pbx.Name = "pbx"
        Me.pbx.Size = New System.Drawing.Size(395, 307)
        Me.pbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx.TabIndex = 17
        Me.pbx.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.White
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblStatus.Location = New System.Drawing.Point(3, 313)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(3, 0, 3, 5)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblStatus.Size = New System.Drawing.Size(395, 24)
        Me.lblStatus.TabIndex = 18
        Me.lblStatus.Text = "ENTROPTIK V3.0"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ToolsStripMenuItem, Me.ImageToolStripMenuItem, Me.TipsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(401, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenWorkspaceToolStripMenuItem, Me.OpenImagesDirToolStripMenuItem})
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'OpenWorkspaceToolStripMenuItem
        '
        Me.OpenWorkspaceToolStripMenuItem.Image = CType(resources.GetObject("OpenWorkspaceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenWorkspaceToolStripMenuItem.Name = "OpenWorkspaceToolStripMenuItem"
        Me.OpenWorkspaceToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.OpenWorkspaceToolStripMenuItem.Text = "&Workspace"
        '
        'OpenImagesDirToolStripMenuItem
        '
        Me.OpenImagesDirToolStripMenuItem.Image = CType(resources.GetObject("OpenImagesDirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenImagesDirToolStripMenuItem.Name = "OpenImagesDirToolStripMenuItem"
        Me.OpenImagesDirToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.OpenImagesDirToolStripMenuItem.Text = "&Images Directory"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewScoresToolStripMenuItem, Me.ViewLogToolStripMenuItem})
        Me.ViewToolStripMenuItem.Enabled = False
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "&View"
        '
        'ViewScoresToolStripMenuItem
        '
        Me.ViewScoresToolStripMenuItem.Name = "ViewScoresToolStripMenuItem"
        Me.ViewScoresToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.ViewScoresToolStripMenuItem.Text = "Scores"
        '
        'ViewLogToolStripMenuItem
        '
        Me.ViewLogToolStripMenuItem.Name = "ViewLogToolStripMenuItem"
        Me.ViewLogToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.ViewLogToolStripMenuItem.Text = "Log"
        '
        'ToolsStripMenuItem
        '
        Me.ToolsStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BatchEditToolStripMenuItem, Me.AutoTrainToolStripMenuItem, Me.LoadFollowPatternToolStripMenuItem})
        Me.ToolsStripMenuItem.Enabled = False
        Me.ToolsStripMenuItem.Name = "ToolsStripMenuItem"
        Me.ToolsStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ToolsStripMenuItem.Text = "&Tools"
        '
        'BatchEditToolStripMenuItem
        '
        Me.BatchEditToolStripMenuItem.Name = "BatchEditToolStripMenuItem"
        Me.BatchEditToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.BatchEditToolStripMenuItem.Text = "Batch Edit"
        '
        'AutoTrainToolStripMenuItem
        '
        Me.AutoTrainToolStripMenuItem.Name = "AutoTrainToolStripMenuItem"
        Me.AutoTrainToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.AutoTrainToolStripMenuItem.Text = "Auto Train"
        '
        'LoadFollowPatternToolStripMenuItem
        '
        Me.LoadFollowPatternToolStripMenuItem.Name = "LoadFollowPatternToolStripMenuItem"
        Me.LoadFollowPatternToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.LoadFollowPatternToolStripMenuItem.Text = "Load Follow Pattern"
        '
        'ImageToolStripMenuItem
        '
        Me.ImageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NextStripMenuItem, Me.RunAllStripMenuItem, Me.StartOverToolStripMenuItem})
        Me.ImageToolStripMenuItem.Enabled = False
        Me.ImageToolStripMenuItem.Name = "ImageToolStripMenuItem"
        Me.ImageToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.ImageToolStripMenuItem.Text = "&Image"
        '
        'NextStripMenuItem
        '
        Me.NextStripMenuItem.Image = CType(resources.GetObject("NextStripMenuItem.Image"), System.Drawing.Image)
        Me.NextStripMenuItem.Name = "NextStripMenuItem"
        Me.NextStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.NextStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.NextStripMenuItem.Text = "&Next Image"
        '
        'RunAllStripMenuItem
        '
        Me.RunAllStripMenuItem.Image = CType(resources.GetObject("RunAllStripMenuItem.Image"), System.Drawing.Image)
        Me.RunAllStripMenuItem.Name = "RunAllStripMenuItem"
        Me.RunAllStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.RunAllStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.RunAllStripMenuItem.Text = "&Run All Images"
        '
        'StartOverToolStripMenuItem
        '
        Me.StartOverToolStripMenuItem.Image = CType(resources.GetObject("StartOverToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StartOverToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.StartOverToolStripMenuItem.Name = "StartOverToolStripMenuItem"
        Me.StartOverToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.StartOverToolStripMenuItem.Text = "Start Over"
        '
        'TipsToolStripMenuItem
        '
        Me.TipsToolStripMenuItem.Name = "TipsToolStripMenuItem"
        Me.TipsToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.TipsToolStripMenuItem.Text = "Tips"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 366)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = " "
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.pbx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents pbx As PictureBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DrawingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomizeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NextStripMenuItem As ToolStripMenuItem
    Friend WithEvents RunAllStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblStatus As Label
    Friend WithEvents LoadParametersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewScoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewLogToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StartOverToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenWorkspaceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenImagesDirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TipsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsStripMenuItem As ToolStripMenuItem
    Friend WithEvents BatchEditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutoTrainToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadFollowPatternToolStripMenuItem As ToolStripMenuItem
End Class
