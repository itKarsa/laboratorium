Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class CetakBukti

    Public Ambil_Data As String
    Public Form_Ambil_Data As String

    Private Sub CetakBukti_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim noDaftarParam As New ReportParameter("noPermintaan", Form1.txtNoPermintaan.Text)
        Dim noRmParam As New ReportParameter("noRM", Form1.txtNoRM.Text)
        Dim namaParam As New ReportParameter("namaPasien", Form1.txtNamaPasien.Text)
        Dim ttlParam As New ReportParameter("tglLahir", Form1.txtTglLahir.Text)
        Dim unitParam As New ReportParameter("unit", Form1.unit)
        Dim dokterParam As New ReportParameter("dokterPengirim", Form1.txtDokter.Text)
        Dim tglRegParam As New ReportParameter("tglPermintaan", Form1.txtTglReg.Text)
        Dim caraBayarParam As New ReportParameter("caraBayar", Form1.caraBayar)
        Dim kelasParam As New ReportParameter("kelas", Form1.txtKelas.Text)
        Dim jkParam As New ReportParameter("jk", Form1.txtJk.Text)
        MsgBox(Form1.txtNoPermintaan.Text & "," &
               Form1.txtNoRM.Text & "," &
               Form1.txtNamaPasien.Text & "," &
               Form1.txtTglLahir.Text & "," &
               Form1.unit & "," &
               Form1.txtDokter.Text & "," &
               Form1.txtTglReg.Text & "," &
               Form1.caraBayar & "," &
               Form1.txtKelas.Text & "," &
               Form1.txtJk.Text)
        ReportViewer1.LocalReport.SetParameters(noDaftarParam)
        ReportViewer1.LocalReport.SetParameters(noRmParam)
        ReportViewer1.LocalReport.SetParameters(namaParam)
        ReportViewer1.LocalReport.SetParameters(ttlParam)
        ReportViewer1.LocalReport.SetParameters(unitParam)
        ReportViewer1.LocalReport.SetParameters(dokterParam)
        ReportViewer1.LocalReport.SetParameters(tglRegParam)
        ReportViewer1.LocalReport.SetParameters(caraBayarParam)
        ReportViewer1.LocalReport.SetParameters(kelasParam)
        ReportViewer1.LocalReport.SetParameters(jkParam)

        koneksiServer()

        If Ambil_Data = True Then
            Select Case Form_Ambil_Data
                Case "Cetak"
                    Dim noTindakan As String
                    noTindakan = Form1.noTindakanPenunjang

                    'MsgBox(noTindakan)

                    Dim dt As New DataTable
                    da = New MySqlDataAdapter("SELECT * FROM vw_pasienlaboratoriumdetail
                                                       WHERE noTindakanPenunjangRajal = '" & noTindakan & "'", conn)
                    ds = New DataSet
                    da.Fill(dt)
                    ReportViewer1.LocalReport.DataSources.Clear()
                    Dim rpt As New ReportDataSource("CetakBukti", dt)
                    ReportViewer1.LocalReport.DataSources.Add(rpt)
            End Select
        End If

        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
    End Sub
End Class