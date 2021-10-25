<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewCetakHasilRajal
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.CetakHasilLab = New Penunjang.CetakHasilLab()
        Me.vw_cetakhasillabrajalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.vw_cetakhasillabrajalTableAdapter = New Penunjang.CetakHasilLabTableAdapters.vw_cetakhasillabrajalTableAdapter()
        CType(Me.CetakHasilLab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vw_cetakhasillabrajalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "HasilLabRajal"
        ReportDataSource1.Value = Me.vw_cetakhasillabrajalBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Penunjang.cetakHasilLabRajal.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.ShowBackButton = False
        Me.ReportViewer1.ShowDocumentMapButton = False
        Me.ReportViewer1.ShowFindControls = False
        Me.ReportViewer1.ShowPageNavigationControls = False
        Me.ReportViewer1.ShowRefreshButton = False
        Me.ReportViewer1.ShowStopButton = False
        Me.ReportViewer1.Size = New System.Drawing.Size(858, 693)
        Me.ReportViewer1.TabIndex = 0
        '
        'CetakHasilLab
        '
        Me.CetakHasilLab.DataSetName = "CetakHasilLab"
        Me.CetakHasilLab.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'vw_cetakhasillabrajalBindingSource
        '
        Me.vw_cetakhasillabrajalBindingSource.DataMember = "vw_cetakhasillabrajal"
        Me.vw_cetakhasillabrajalBindingSource.DataSource = Me.CetakHasilLab
        '
        'vw_cetakhasillabrajalTableAdapter
        '
        Me.vw_cetakhasillabrajalTableAdapter.ClearBeforeFill = True
        '
        'ViewCetakHasilRajal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 693)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "ViewCetakHasilRajal"
        Me.Text = "ViewCetakHasilRajal"
        CType(Me.CetakHasilLab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vw_cetakhasillabrajalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents vw_cetakhasillabrajalBindingSource As BindingSource
    Friend WithEvents CetakHasilLab As CetakHasilLab
    Friend WithEvents vw_cetakhasillabrajalTableAdapter As CetakHasilLabTableAdapters.vw_cetakhasillabrajalTableAdapter
End Class
