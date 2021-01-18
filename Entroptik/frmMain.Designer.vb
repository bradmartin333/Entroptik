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
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DrawingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewDrawingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenImagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFeatureSheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NextStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunAllStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveFeatureSheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ViewScoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(343, 506)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'pbxFeatures
        '
        Me.pbxFeatures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbxFeatures.Location = New System.Drawing.Point(3, 3)
        Me.pbxFeatures.Name = "pbxFeatures"
        Me.pbxFeatures.Size = New System.Drawing.Size(337, 233)
        Me.pbxFeatures.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxFeatures.TabIndex = 17
        Me.pbxFeatures.TabStop = False
        '
        'pbxCrop
        '
        Me.pbxCrop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbxCrop.Location = New System.Drawing.Point(3, 242)
        Me.pbxCrop.Name = "pbxCrop"
        Me.pbxCrop.Size = New System.Drawing.Size(337, 233)
        Me.pbxCrop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxCrop.TabIndex = 14
        Me.pbxCrop.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.BackColor = System.Drawing.Color.White
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblStatus.Location = New System.Drawing.Point(3, 478)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(3, 0, 3, 5)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblStatus.Size = New System.Drawing.Size(337, 23)
        Me.lblStatus.TabIndex = 18
        Me.lblStatus.Text = "ENTROPTIK V0.1"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(343, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DrawingToolStripMenuItem, Me.ViewDrawingToolStripMenuItem, Me.OpenImagesToolStripMenuItem, Me.OpenFeatureSheetToolStripMenuItem, Me.OpenProjectToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'DrawingToolStripMenuItem
        '
        Me.DrawingToolStripMenuItem.Image = CType(resources.GetObject("DrawingToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DrawingToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DrawingToolStripMenuItem.Name = "DrawingToolStripMenuItem"
        Me.DrawingToolStripMenuItem.ShowShortcutKeys = False
        Me.DrawingToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.DrawingToolStripMenuItem.Text = "&Open Drawing"
        '
        'ViewDrawingToolStripMenuItem
        '
        Me.ViewDrawingToolStripMenuItem.Name = "ViewDrawingToolStripMenuItem"
        Me.ViewDrawingToolStripMenuItem.ShowShortcutKeys = False
        Me.ViewDrawingToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ViewDrawingToolStripMenuItem.Text = "View Drawing"
        '
        'OpenImagesToolStripMenuItem
        '
        Me.OpenImagesToolStripMenuItem.Image = CType(resources.GetObject("OpenImagesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenImagesToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenImagesToolStripMenuItem.Name = "OpenImagesToolStripMenuItem"
        Me.OpenImagesToolStripMenuItem.ShowShortcutKeys = False
        Me.OpenImagesToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.OpenImagesToolStripMenuItem.Text = "&Open Images Folder"
        '
        'OpenFeatureSheetToolStripMenuItem
        '
        Me.OpenFeatureSheetToolStripMenuItem.Name = "OpenFeatureSheetToolStripMenuItem"
        Me.OpenFeatureSheetToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.OpenFeatureSheetToolStripMenuItem.Text = "Open Feature Sheet"
        '
        'OpenProjectToolStripMenuItem
        '
        Me.OpenProjectToolStripMenuItem.Name = "OpenProjectToolStripMenuItem"
        Me.OpenProjectToolStripMenuItem.ShowShortcutKeys = False
        Me.OpenProjectToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.OpenProjectToolStripMenuItem.Text = "Open Project Folder"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NextStripMenuItem, Me.RunAllStripMenuItem, Me.ToolStripSeparator1, Me.SaveFeatureSheetToolStripMenuItem, Me.SaveLogToolStripMenuItem, Me.ToolStripSeparator2, Me.ViewScoresToolStripMenuItem, Me.ViewLogToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'NextStripMenuItem
        '
        Me.NextStripMenuItem.Name = "NextStripMenuItem"
        Me.NextStripMenuItem.ShowShortcutKeys = False
        Me.NextStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.NextStripMenuItem.Text = "Next Image"
        '
        'RunAllStripMenuItem
        '
        Me.RunAllStripMenuItem.Name = "RunAllStripMenuItem"
        Me.RunAllStripMenuItem.ShowShortcutKeys = False
        Me.RunAllStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.RunAllStripMenuItem.Text = "Run All Images"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(162, 6)
        '
        'SaveFeatureSheetToolStripMenuItem
        '
        Me.SaveFeatureSheetToolStripMenuItem.Name = "SaveFeatureSheetToolStripMenuItem"
        Me.SaveFeatureSheetToolStripMenuItem.ShowShortcutKeys = False
        Me.SaveFeatureSheetToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.SaveFeatureSheetToolStripMenuItem.Text = "Save Feature Sheet"
        '
        'SaveLogToolStripMenuItem
        '
        Me.SaveLogToolStripMenuItem.Name = "SaveLogToolStripMenuItem"
        Me.SaveLogToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.SaveLogToolStripMenuItem.Text = "Save Log"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(162, 6)
        '
        'ViewScoresToolStripMenuItem
        '
        Me.ViewScoresToolStripMenuItem.Name = "ViewScoresToolStripMenuItem"
        Me.ViewScoresToolStripMenuItem.ShowShortcutKeys = False
        Me.ViewScoresToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ViewScoresToolStripMenuItem.Text = "View Scores"
        '
        'ViewLogToolStripMenuItem
        '
        Me.ViewLogToolStripMenuItem.Name = "ViewLogToolStripMenuItem"
        Me.ViewLogToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ViewLogToolStripMenuItem.Text = "View Log"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(343, 530)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = " "
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
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
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ViewDrawingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewScoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenProjectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFeatureSheetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFeatureSheetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SaveLogToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewLogToolStripMenuItem As ToolStripMenuItem
End Class
