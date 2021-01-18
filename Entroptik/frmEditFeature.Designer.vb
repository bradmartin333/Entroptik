<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditFeature
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
        Me.numScore = New System.Windows.Forms.NumericUpDown()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.lblTrainedScore = New System.Windows.Forms.Label()
        Me.lblLastScore = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblLastScoreValue = New System.Windows.Forms.Label()
        Me.lblTolerance = New System.Windows.Forms.Label()
        Me.numTolerance = New System.Windows.Forms.NumericUpDown()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.numScore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTolerance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.numScore, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnDone, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTrainedScore, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLastScore, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblName, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtName, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLastScoreValue, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTolerance, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.numTolerance, 1, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(205, 149)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'numScore
        '
        Me.numScore.AutoSize = True
        Me.numScore.DecimalPlaces = 3
        Me.numScore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.numScore.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numScore.Location = New System.Drawing.Point(102, 32)
        Me.numScore.Name = "numScore"
        Me.numScore.Size = New System.Drawing.Size(100, 23)
        Me.numScore.TabIndex = 2
        Me.numScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnDone
        '
        Me.btnDone.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.btnDone, 2)
        Me.btnDone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDone.Location = New System.Drawing.Point(3, 119)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(199, 27)
        Me.btnDone.TabIndex = 4
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'lblTrainedScore
        '
        Me.lblTrainedScore.AutoSize = True
        Me.lblTrainedScore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTrainedScore.Location = New System.Drawing.Point(3, 29)
        Me.lblTrainedScore.Name = "lblTrainedScore"
        Me.lblTrainedScore.Size = New System.Drawing.Size(93, 29)
        Me.lblTrainedScore.TabIndex = 5
        Me.lblTrainedScore.Text = "Trained Score"
        Me.lblTrainedScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLastScore
        '
        Me.lblLastScore.AutoSize = True
        Me.lblLastScore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLastScore.Location = New System.Drawing.Point(3, 58)
        Me.lblLastScore.Name = "lblLastScore"
        Me.lblLastScore.Size = New System.Drawing.Size(93, 29)
        Me.lblLastScore.TabIndex = 6
        Me.lblLastScore.Text = "Last Score"
        Me.lblLastScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblName.Location = New System.Drawing.Point(3, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(93, 29)
        Me.lblName.TabIndex = 7
        Me.lblName.Text = "Name"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(102, 3)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(100, 23)
        Me.txtName.TabIndex = 8
        Me.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLastScoreValue
        '
        Me.lblLastScoreValue.AutoSize = True
        Me.lblLastScoreValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLastScoreValue.Location = New System.Drawing.Point(102, 58)
        Me.lblLastScoreValue.Name = "lblLastScoreValue"
        Me.lblLastScoreValue.Size = New System.Drawing.Size(100, 29)
        Me.lblLastScoreValue.TabIndex = 9
        Me.lblLastScoreValue.Text = "Label1"
        Me.lblLastScoreValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTolerance
        '
        Me.lblTolerance.AutoSize = True
        Me.lblTolerance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTolerance.Location = New System.Drawing.Point(3, 87)
        Me.lblTolerance.Name = "lblTolerance"
        Me.lblTolerance.Size = New System.Drawing.Size(93, 29)
        Me.lblTolerance.TabIndex = 10
        Me.lblTolerance.Text = "Tolerance"
        Me.lblTolerance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'numTolerance
        '
        Me.numTolerance.AutoSize = True
        Me.numTolerance.DecimalPlaces = 3
        Me.numTolerance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.numTolerance.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numTolerance.Location = New System.Drawing.Point(102, 90)
        Me.numTolerance.Name = "numTolerance"
        Me.numTolerance.Size = New System.Drawing.Size(100, 23)
        Me.numTolerance.TabIndex = 11
        Me.numTolerance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmEditFeature
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(205, 149)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEditFeature"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FeatureName"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.numScore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTolerance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents numScore As NumericUpDown
    Friend WithEvents btnDone As Button
    Friend WithEvents lblTrainedScore As Label
    Friend WithEvents lblLastScore As Label
    Friend WithEvents lblName As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents lblLastScoreValue As Label
    Friend WithEvents lblTolerance As Label
    Friend WithEvents numTolerance As NumericUpDown
End Class
