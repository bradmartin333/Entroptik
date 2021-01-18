<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditParams
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numBorderRectangleSize = New System.Windows.Forms.NumericUpDown()
        Me.numNullCap = New System.Windows.Forms.NumericUpDown()
        Me.numNullThreshold = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblLastCropScore = New System.Windows.Forms.Label()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.numBorderRectangleSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNullCap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNullThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.numBorderRectangleSize, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.numNullCap, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.numNullThreshold, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLastCropScore, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnDone, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(295, 150)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Border Rectangle Size"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 30)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Null Cap"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 30)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Null Threshold"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'numBorderRectangleSize
        '
        Me.numBorderRectangleSize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.numBorderRectangleSize.Location = New System.Drawing.Point(150, 3)
        Me.numBorderRectangleSize.Name = "numBorderRectangleSize"
        Me.numBorderRectangleSize.Size = New System.Drawing.Size(142, 23)
        Me.numBorderRectangleSize.TabIndex = 3
        Me.numBorderRectangleSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numNullCap
        '
        Me.numNullCap.DecimalPlaces = 3
        Me.numNullCap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.numNullCap.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numNullCap.Location = New System.Drawing.Point(150, 33)
        Me.numNullCap.Name = "numNullCap"
        Me.numNullCap.Size = New System.Drawing.Size(142, 23)
        Me.numNullCap.TabIndex = 4
        Me.numNullCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numNullThreshold
        '
        Me.numNullThreshold.DecimalPlaces = 3
        Me.numNullThreshold.Dock = System.Windows.Forms.DockStyle.Fill
        Me.numNullThreshold.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numNullThreshold.Location = New System.Drawing.Point(150, 93)
        Me.numNullThreshold.Name = "numNullThreshold"
        Me.numNullThreshold.Size = New System.Drawing.Size(142, 23)
        Me.numNullThreshold.TabIndex = 5
        Me.numNullThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 30)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Last Crop Score"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLastCropScore
        '
        Me.lblLastCropScore.AutoSize = True
        Me.lblLastCropScore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLastCropScore.Location = New System.Drawing.Point(150, 60)
        Me.lblLastCropScore.Name = "lblLastCropScore"
        Me.lblLastCropScore.Size = New System.Drawing.Size(142, 30)
        Me.lblLastCropScore.TabIndex = 7
        Me.lblLastCropScore.Text = "Label5"
        Me.lblLastCropScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDone
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.btnDone, 2)
        Me.btnDone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDone.Location = New System.Drawing.Point(3, 123)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(289, 24)
        Me.btnDone.TabIndex = 8
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'frmEditParams
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(295, 150)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEditParams"
        Me.Text = "Edit Parameters"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.numBorderRectangleSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNullCap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNullThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents numBorderRectangleSize As NumericUpDown
    Friend WithEvents numNullCap As NumericUpDown
    Friend WithEvents numNullThreshold As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents lblLastCropScore As Label
    Friend WithEvents btnDone As Button
End Class
