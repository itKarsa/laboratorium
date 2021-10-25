Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class ViewCetakHasilRanap

    Public Ambil_Data As String
    Public Form_Ambil_Data As String

    Private Sub ViewCetakHasilRanap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksiServer()

        If Ambil_Data = True Then
            Select Case Form_Ambil_Data
                Case "Cetak"
                    Dim noRm, noReg As String
                    noRm = Hasil.txtNoRM.Text
                    noReg = Hasil.txtNoPermintaan.Text

                    Dim dt As New DataTable
                    da = New MySqlDataAdapter("SELECT * FROM vw_cetakhasillabranap 
                                                       WHERE noRekamedis = '" & noRm & "' 
                                                         AND noRegistrasiPenunjangRanap = '" & noReg & "'", conn)
                    ds = New DataSet
                    da.Fill(dt)
                    ReportViewer1.LocalReport.DataSources.Clear()
                    Dim rpt As New ReportDataSource("HasilLabRanap", dt)
                    ReportViewer1.LocalReport.DataSources.Add(rpt)
            End Select
        End If

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class