<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewCetakHasilRanap
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.vw_cetakhasillabranapBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CetakHasilLab = New Penunjang.CetakHasilLab()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.vw_cetakhasillabranapTableAdapter = New Penunjang.CetakHasilLabTableAdapters.vw_cetakhasillabranapTableAdapter()
        CType(Me.vw_cetakhasillabranapBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CetakHasilLab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'vw_cetakhasillabranapBindingSource
        '
        Me.vw_cetakhasillabranapBindingSource.DataMember = "vw_cetakhasillabranap"
        Me.vw_cetakhasillabranapBindingSource.DataSource = Me.CetakHasilLab
        '
        'CetakHasilLab
        '
        Me.CetakHasilLab.DataSetName = "CetakHasilLab"
        Me.CetakHasilLab.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "HasilLabRanap"
        ReportDataSource1.Value = Me.vw_cetakhasillabranapBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Penunjang.cetakHasilLabRanap.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.ShowBackButton = False
        Me.ReportViewer1.ShowFindControls = False
        Me.ReportViewer1.ShowPageNavigationControls = False
        Me.ReportViewer1.ShowRefreshButton = False
        Me.ReportViewer1.ShowStopButton = False
        Me.ReportViewer1.Size = New System.Drawing.Size(785, 662)
        Me.ReportViewer1.TabIndex = 0
        '
        'vw_cetakhasillabranapTableAdapter
        '
        Me.vw_cetakhasillabranapTableAdapter.ClearBeforeFill = True
        '
        'ViewCetakHasilRanap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 662)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "ViewCetakHasilRanap"
        Me.Text = "ViewCetakHasil"
        CType(Me.vw_cetakhasillabranapBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CetakHasilLab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents vw_cetakhasillabranapBindingSource As BindingSource
    Friend WithEvents CetakHasilLab As CetakHasilLab
    Friend WithEvents vw_cetakhasillabranapTableAdapter As CetakHasilLabTableAdapters.vw_cetakhasillabranapTableAdapter
End Class
