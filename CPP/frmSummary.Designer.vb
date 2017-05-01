<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSummary
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
        Me.gbSummary = New System.Windows.Forms.GroupBox()
        Me.CPP_SUMMARYDataGridView = New System.Windows.Forms.DataGridView()
        Me.gbSummary.SuspendLayout()
        CType(Me.CPP_SUMMARYDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbSummary
        '
        Me.gbSummary.Controls.Add(Me.CPP_SUMMARYDataGridView)
        Me.gbSummary.Location = New System.Drawing.Point(12, 12)
        Me.gbSummary.Name = "gbSummary"
        Me.gbSummary.Size = New System.Drawing.Size(761, 545)
        Me.gbSummary.TabIndex = 17
        Me.gbSummary.TabStop = False
        '
        'CPP_SUMMARYDataGridView
        '
        Me.CPP_SUMMARYDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CPP_SUMMARYDataGridView.Location = New System.Drawing.Point(6, 19)
        Me.CPP_SUMMARYDataGridView.Name = "CPP_SUMMARYDataGridView"
        Me.CPP_SUMMARYDataGridView.Size = New System.Drawing.Size(749, 520)
        Me.CPP_SUMMARYDataGridView.TabIndex = 2
        '
        'frmSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 569)
        Me.Controls.Add(Me.gbSummary)
        Me.Name = "frmSummary"
        Me.Text = "frmSummary"
        Me.gbSummary.ResumeLayout(False)
        CType(Me.CPP_SUMMARYDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbSummary As System.Windows.Forms.GroupBox
    Friend WithEvents CPP_SUMMARYDataGridView As System.Windows.Forms.DataGridView
End Class
