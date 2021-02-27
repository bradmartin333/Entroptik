<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGridWizard
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numX = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numY = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numArea = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numXPitch = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.numYPitch = New System.Windows.Forms.NumericUpDown()
        Me.pbxGridPhoto = New System.Windows.Forms.PictureBox()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnNextImage = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.numX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numXPitch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numYPitch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxGridPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pbxGridPhoto, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(636, 639)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel1.Controls.Add(Me.numX)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel1.Controls.Add(Me.numY)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel1.Controls.Add(Me.numArea)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel1.Controls.Add(Me.numXPitch)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label5)
        Me.FlowLayoutPanel1.Controls.Add(Me.numYPitch)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(630, 29)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "#X"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'numX
        '
        Me.numX.Location = New System.Drawing.Point(30, 3)
        Me.numX.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numX.Name = "numX"
        Me.numX.Size = New System.Drawing.Size(52, 23)
        Me.numX.TabIndex = 1
        Me.numX.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(88, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 29)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "#Y"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'numY
        '
        Me.numY.Location = New System.Drawing.Point(115, 3)
        Me.numY.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numY.Name = "numY"
        Me.numY.Size = New System.Drawing.Size(52, 23)
        Me.numY.TabIndex = 3
        Me.numY.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(173, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 29)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Area"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'numArea
        '
        Me.numArea.Location = New System.Drawing.Point(210, 3)
        Me.numArea.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.numArea.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numArea.Name = "numArea"
        Me.numArea.Size = New System.Drawing.Size(100, 23)
        Me.numArea.TabIndex = 5
        Me.numArea.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(316, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 29)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "X Pitch"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'numXPitch
        '
        Me.numXPitch.Location = New System.Drawing.Point(366, 3)
        Me.numXPitch.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.numXPitch.Name = "numXPitch"
        Me.numXPitch.Size = New System.Drawing.Size(100, 23)
        Me.numXPitch.TabIndex = 7
        Me.numXPitch.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(472, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 29)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Y Pitch"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'numYPitch
        '
        Me.numYPitch.Location = New System.Drawing.Point(522, 3)
        Me.numYPitch.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.numYPitch.Name = "numYPitch"
        Me.numYPitch.Size = New System.Drawing.Size(100, 23)
        Me.numYPitch.TabIndex = 9
        Me.numYPitch.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'pbxGridPhoto
        '
        Me.pbxGridPhoto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.pbxGridPhoto.BackColor = System.Drawing.Color.White
        Me.pbxGridPhoto.InitialImage = Nothing
        Me.pbxGridPhoto.Location = New System.Drawing.Point(3, 38)
        Me.pbxGridPhoto.Name = "pbxGridPhoto"
        Me.pbxGridPhoto.Size = New System.Drawing.Size(630, 561)
        Me.pbxGridPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxGridPhoto.TabIndex = 0
        Me.pbxGridPhoto.TabStop = False
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.Controls.Add(Me.btnNextImage)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnSave)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 605)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(630, 31)
        Me.FlowLayoutPanel2.TabIndex = 2
        '
        'btnNextImage
        '
        Me.btnNextImage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNextImage.AutoSize = True
        Me.btnNextImage.Location = New System.Drawing.Point(3, 3)
        Me.btnNextImage.Name = "btnNextImage"
        Me.btnNextImage.Size = New System.Drawing.Size(78, 25)
        Me.btnNextImage.TabIndex = 0
        Me.btnNextImage.Text = "Next Image"
        Me.btnNextImage.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.AutoSize = True
        Me.btnSave.Location = New System.Drawing.Point(87, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(127, 25)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save Grid Workspace"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmGridWizard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 639)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmGridWizard"
        Me.Text = "Grid Workspace Wizard"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        CType(Me.numX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numXPitch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numYPitch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxGridPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents pbxGridPhoto As PictureBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents numX As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents numY As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents numArea As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents numXPitch As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents numYPitch As NumericUpDown
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnNextImage As Button
End Class
