<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.pbxFeatures = New System.Windows.Forms.PictureBox()
        Me.pbxCrop = New System.Windows.Forms.PictureBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenDrawingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenImagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFeatureSheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenParametersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFeatureSheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveParametersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewScoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewDrawingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NextStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunAllStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.pbxFeatures, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxCrop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.pbxFeatures, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pbxCrop, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStatus, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 24)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(343, 511)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'pbxFeatures
        '
        Me.pbxFeatures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbxFeatures.Location = New System.Drawing.Point(3, 3)
        Me.pbxFeatures.Name = "pbxFeatures"
        Me.pbxFeatures.Size = New System.Drawing.Size(337, 235)
        Me.pbxFeatures.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxFeatures.TabIndex = 17
        Me.pbxFeatures.TabStop = False
        '
        'pbxCrop
        '
        Me.pbxCrop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbxCrop.Location = New System.Drawing.Point(3, 244)
        Me.pbxCrop.Name = "pbxCrop"
        Me.pbxCrop.Size = New System.Drawing.Size(337, 235)
        Me.pbxCrop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxCrop.TabIndex = 14
        Me.pbxCrop.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.White
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblStatus.Location = New System.Drawing.Point(3, 482)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(3, 0, 3, 5)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblStatus.Size = New System.Drawing.Size(337, 24)
        Me.lblStatus.TabIndex = 18
        Me.lblStatus.Text = "ENTROPTIK V0.1"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ToolsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(343, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenProjectToolStripMenuItem, Me.OpenDrawingToolStripMenuItem, Me.OpenImagesToolStripMenuItem, Me.OpenFeatureSheetToolStripMenuItem, Me.OpenParametersToolStripMenuItem})
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'OpenProjectToolStripMenuItem
        '
        Me.OpenProjectToolStripMenuItem.Name = "OpenProjectToolStripMenuItem"
        Me.OpenProjectToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenProjectToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.OpenProjectToolStripMenuItem.Text = "Project Folder"
        '
        'OpenDrawingToolStripMenuItem
        '
        Me.OpenDrawingToolStripMenuItem.Image = CType(resources.GetObject("OpenDrawingToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenDrawingToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenDrawingToolStripMenuItem.Name = "OpenDrawingToolStripMenuItem"
        Me.OpenDrawingToolStripMenuItem.ShowShortcutKeys = False
        Me.OpenDrawingToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.OpenDrawingToolStripMenuItem.Text = "&Drawing"
        '
        'OpenImagesToolStripMenuItem
        '
        Me.OpenImagesToolStripMenuItem.Image = CType(resources.GetObject("OpenImagesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenImagesToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenImagesToolStripMenuItem.Name = "OpenImagesToolStripMenuItem"
        Me.OpenImagesToolStripMenuItem.ShowShortcutKeys = False
        Me.OpenImagesToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.OpenImagesToolStripMenuItem.Text = "&Images Folder"
        '
        'OpenFeatureSheetToolStripMenuItem
        '
        Me.OpenFeatureSheetToolStripMenuItem.Name = "OpenFeatureSheetToolStripMenuItem"
        Me.OpenFeatureSheetToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.OpenFeatureSheetToolStripMenuItem.Text = "Feature Sheet"
        '
        'OpenParametersToolStripMenuItem
        '
        Me.OpenParametersToolStripMenuItem.Name = "OpenParametersToolStripMenuItem"
        Me.OpenParametersToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.OpenParametersToolStripMenuItem.Text = "Parameters"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveFeatureSheetToolStripMenuItem, Me.SaveParametersToolStripMenuItem})
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'SaveFeatureSheetToolStripMenuItem
        '
        Me.SaveFeatureSheetToolStripMenuItem.Name = "SaveFeatureSheetToolStripMenuItem"
        Me.SaveFeatureSheetToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.SaveFeatureSheetToolStripMenuItem.Text = "Feature Sheet"
        '
        'SaveParametersToolStripMenuItem
        '
        Me.SaveParametersToolStripMenuItem.Name = "SaveParametersToolStripMenuItem"
        Me.SaveParametersToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.SaveParametersToolStripMenuItem.Text = "Parameters"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewScoresToolStripMenuItem, Me.ViewLogToolStripMenuItem, Me.ViewDrawingToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "&View"
        '
        'ViewScoresToolStripMenuItem
        '
        Me.ViewScoresToolStripMenuItem.Name = "ViewScoresToolStripMenuItem"
        Me.ViewScoresToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.ViewScoresToolStripMenuItem.Text = "Scores"
        '
        'ViewLogToolStripMenuItem
        '
        Me.ViewLogToolStripMenuItem.Name = "ViewLogToolStripMenuItem"
        Me.ViewLogToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.ViewLogToolStripMenuItem.Text = "Log"
        '
        'ViewDrawingToolStripMenuItem
        '
        Me.ViewDrawingToolStripMenuItem.Name = "ViewDrawingToolStripMenuItem"
        Me.ViewDrawingToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.ViewDrawingToolStripMenuItem.Text = "Drawing"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NextStripMenuItem, Me.RunAllStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
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
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(343, 535)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = " "
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.pbxFeatures, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxCrop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents pbxCrop As PictureBox
    Friend WithEvents pbxFeatures As PictureBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DrawingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenImagesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomizeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NextStripMenuItem As ToolStripMenuItem
    Friend WithEvents RunAllStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblStatus As Label
    Friend WithEvents OpenProjectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFeatureSheetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadParametersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenDrawingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenParametersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFeatureSheetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveParametersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewScoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewLogToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewDrawingToolStripMenuItem As ToolStripMenuItem
End Class
