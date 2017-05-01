<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnrollment
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
        Dim BRONCO_IDLabel As System.Windows.Forms.Label
        Dim CATALOG_IDLabel As System.Windows.Forms.Label
        Me.gbEnrollmentList = New System.Windows.Forms.GroupBox()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.CPP_ENROLLMENTDataGridView = New System.Windows.Forms.DataGridView()
        Me.gbEnrollmentDetail = New System.Windows.Forms.GroupBox()
        Me.BRONCO_IDComboBox = New System.Windows.Forms.ComboBox()
        Me.CATALOG_IDComboBox = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        BRONCO_IDLabel = New System.Windows.Forms.Label()
        CATALOG_IDLabel = New System.Windows.Forms.Label()
        Me.gbEnrollmentList.SuspendLayout()
        CType(Me.CPP_ENROLLMENTDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEnrollmentDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbEnrollmentList
        '
        Me.gbEnrollmentList.Controls.Add(Me.btnFind)
        Me.gbEnrollmentList.Controls.Add(Me.btnDelete)
        Me.gbEnrollmentList.Controls.Add(Me.btnAdd)
        Me.gbEnrollmentList.Controls.Add(Me.btnUpdate)
        Me.gbEnrollmentList.Controls.Add(Me.CPP_ENROLLMENTDataGridView)
        Me.gbEnrollmentList.Location = New System.Drawing.Point(18, 213)
        Me.gbEnrollmentList.Name = "gbEnrollmentList"
        Me.gbEnrollmentList.Size = New System.Drawing.Size(652, 310)
        Me.gbEnrollmentList.TabIndex = 36
        Me.gbEnrollmentList.TabStop = False
        Me.gbEnrollmentList.Text = "Student Course List"
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(284, 260)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(81, 23)
        Me.btnFind.TabIndex = 34
        Me.btnFind.Text = "&Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(188, 260)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(81, 23)
        Me.btnDelete.TabIndex = 33
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(6, 260)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(81, 23)
        Me.btnAdd.TabIndex = 31
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(96, 260)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(81, 23)
        Me.btnUpdate.TabIndex = 32
        Me.btnUpdate.Text = "&Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'CPP_ENROLLMENTDataGridView
        '
        Me.CPP_ENROLLMENTDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CPP_ENROLLMENTDataGridView.Location = New System.Drawing.Point(6, 19)
        Me.CPP_ENROLLMENTDataGridView.Name = "CPP_ENROLLMENTDataGridView"
        Me.CPP_ENROLLMENTDataGridView.Size = New System.Drawing.Size(602, 220)
        Me.CPP_ENROLLMENTDataGridView.TabIndex = 1
        '
        'gbEnrollmentDetail
        '
        Me.gbEnrollmentDetail.Controls.Add(BRONCO_IDLabel)
        Me.gbEnrollmentDetail.Controls.Add(Me.BRONCO_IDComboBox)
        Me.gbEnrollmentDetail.Controls.Add(CATALOG_IDLabel)
        Me.gbEnrollmentDetail.Controls.Add(Me.CATALOG_IDComboBox)
        Me.gbEnrollmentDetail.Controls.Add(Me.btnCancel)
        Me.gbEnrollmentDetail.Controls.Add(Me.btnSave)
        Me.gbEnrollmentDetail.Location = New System.Drawing.Point(18, 16)
        Me.gbEnrollmentDetail.Name = "gbEnrollmentDetail"
        Me.gbEnrollmentDetail.Size = New System.Drawing.Size(392, 169)
        Me.gbEnrollmentDetail.TabIndex = 35
        Me.gbEnrollmentDetail.TabStop = False
        Me.gbEnrollmentDetail.Text = "Student Course"
        '
        'BRONCO_IDLabel
        '
        BRONCO_IDLabel.AutoSize = True
        BRONCO_IDLabel.Location = New System.Drawing.Point(36, 40)
        BRONCO_IDLabel.Name = "BRONCO_IDLabel"
        BRONCO_IDLabel.Size = New System.Drawing.Size(70, 13)
        BRONCO_IDLabel.TabIndex = 32
        BRONCO_IDLabel.Text = "BRONCO ID:"
        '
        'BRONCO_IDComboBox
        '
        Me.BRONCO_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BRONCO_IDComboBox.FormattingEnabled = True
        Me.BRONCO_IDComboBox.Items.AddRange(New Object() {"S100 - (HOMER, SIMPSON)", "S200 - (BART, SIMPSON)", "S300 - (LISA, SIMPSON)", "S400 - (MARGE, SIMPSON)", "S500 - (MAGGIE, SIMPSON)", "S600 - (MILLHOUSE, VAN HOUTEN)"})
        Me.BRONCO_IDComboBox.Location = New System.Drawing.Point(116, 37)
        Me.BRONCO_IDComboBox.Name = "BRONCO_IDComboBox"
        Me.BRONCO_IDComboBox.Size = New System.Drawing.Size(233, 21)
        Me.BRONCO_IDComboBox.TabIndex = 33
        '
        'CATALOG_IDLabel
        '
        CATALOG_IDLabel.AutoSize = True
        CATALOG_IDLabel.Location = New System.Drawing.Point(36, 76)
        CATALOG_IDLabel.Name = "CATALOG_IDLabel"
        CATALOG_IDLabel.Size = New System.Drawing.Size(74, 13)
        CATALOG_IDLabel.TabIndex = 34
        CATALOG_IDLabel.Text = "CATALOG ID:"
        '
        'CATALOG_IDComboBox
        '
        Me.CATALOG_IDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CATALOG_IDComboBox.FormattingEnabled = True
        Me.CATALOG_IDComboBox.Items.AddRange(New Object() {"1 - (2015, FALL, CIS234)", "2 - (2015, FALL, CIS304)", "3 - (2015, FALL, CIS305)", "4 - (2015, FALL, CIS338)", "5 - (2015, FALL, COM200)", "6 - (2015, FALL, TOM100)", "7 - (2015, FALL, CIS234)"})
        Me.CATALOG_IDComboBox.Location = New System.Drawing.Point(116, 73)
        Me.CATALOG_IDComboBox.Name = "CATALOG_IDComboBox"
        Me.CATALOG_IDComboBox.Size = New System.Drawing.Size(233, 21)
        Me.CATALOG_IDComboBox.TabIndex = 35
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(217, 120)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 32
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(116, 120)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 31
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmEnrollment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 539)
        Me.Controls.Add(Me.gbEnrollmentList)
        Me.Controls.Add(Me.gbEnrollmentDetail)
        Me.Name = "frmEnrollment"
        Me.Text = "CPP ENROLLMENT INFORMATION"
        Me.gbEnrollmentList.ResumeLayout(False)
        CType(Me.CPP_ENROLLMENTDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEnrollmentDetail.ResumeLayout(False)
        Me.gbEnrollmentDetail.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Friend WithEvents gbEnrollmentList As System.Windows.Forms.GroupBox
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents CPP_ENROLLMENTDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents gbEnrollmentDetail As System.Windows.Forms.GroupBox
    Friend WithEvents BRONCO_IDComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CATALOG_IDComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button

    Public Sub New(strMode As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


End Class
