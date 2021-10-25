Imports MySql.Data.MySqlClient
Public Class RiwayatPasien

    Public Ambil_Data As String
    Public Form_Ambil_Data As String

    Sub dgv1_styleRow()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If i Mod 2 = 0 Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
            Else
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub

    Sub setColor(button As Button)
        btnDash.BackColor = SystemColors.HotTrack
        btnBridging.BackColor = SystemColors.HotTrack
        btnTindakan.BackColor = SystemColors.HotTrack
        btnHasil.BackColor = SystemColors.HotTrack
        btnRiwayat.BackColor = SystemColors.HotTrack
        button.BackColor = Color.DodgerBlue
    End Sub

    Sub caridata()
        Dim query As String
        query = "SELECT * FROM vw_riwayatpasienlab 
                 WHERE SUBSTR(Tanggal_Daftar,1,10) BETWEEN '" & DateTimePicker1.Text & "' 
                 AND '" & DateTimePicker2.Text & "'"
        da = New MySqlDataAdapter(query, conn)

        Dim str As New DataTable
        str.Clear()
        da.Fill(str)
        DataGridView1.DataSource = str

        Call aturDGV()

        If DataGridView1.Rows.Count = 0 Then
            MsgBox("Tidak ada riwayat pasien pada tanggal tsb.", MsgBoxStyle.Information, "Information")
        End If
    End Sub

    Sub tampilData()
        Call koneksiServer()

        Dim query As String = ""
        query = "SELECT * FROM vw_riwayatpasienlab ORDER BY Tanggal_Daftar ASC"
        da = New MySqlDataAdapter(query, conn)
        ds = New DataSet
        da.Fill(ds, "vw_riwayatpasienlab")
        DataGridView1.DataSource = ds.Tables("vw_riwayatpasienlab")
    End Sub

    Sub aturDGV()
        Try
            DataGridView1.Columns(0).Width = 100
            DataGridView1.Columns(1).Width = 250
            DataGridView1.Columns(2).Width = 170
            DataGridView1.Columns(3).Width = 190
            DataGridView1.Columns(4).Width = 250
            DataGridView1.Columns(5).Width = 100
            DataGridView1.Columns(6).Width = 100
            DataGridView1.Columns(7).Width = 100
            DataGridView1.Columns(8).Width = 300
            DataGridView1.Columns(9).Width = 300
            DataGridView1.Columns(0).HeaderText = "NO. RM"
            DataGridView1.Columns(1).HeaderText = "NAMA PASIEN"
            DataGridView1.Columns(2).HeaderText = "TGL. MASUK LAB"
            DataGridView1.Columns(3).HeaderText = "ASAL RUANG / POLI"
            DataGridView1.Columns(4).HeaderText = "JENIS PEMERIKSAAN"
            DataGridView1.Columns(5).HeaderText = "SATUAN HASIL"
            DataGridView1.Columns(6).HeaderText = "NILAI NORMAL"
            DataGridView1.Columns(7).HeaderText = "HASIL"
            DataGridView1.Columns(8).HeaderText = "DOKTER PENGIRIM"
            DataGridView1.Columns(9).HeaderText = "DOKTER LABORATORIUM"

            DataGridView1.Columns(2).DefaultCellStyle.Format = "dd/MM/yyyy"
            DataGridView1.DefaultCellStyle.ForeColor = Color.Black
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.White
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Call dgv1_styleRow()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RiwayatPasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlStats.Height = btnRiwayat.Height
        pnlStats.Top = btnRiwayat.Top
        btnRiwayat.BackColor = Color.DodgerBlue

        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker1.Format = DateTimePickerFormat.Custom

        DateTimePicker2.CustomFormat = "yyyy-MM-dd"
        DateTimePicker2.Format = DateTimePickerFormat.Custom

        Call tampilData()
        Call aturDGV()
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If e.RowIndex > 0 And e.ColumnIndex = 0 Then
            If DataGridView1.Item(0, e.RowIndex - 1).Value = e.Value Then
                e.Value = ""
            End If
        End If

        If e.RowIndex > 0 And e.ColumnIndex = 1 Then
            If DataGridView1.Item(1, e.RowIndex - 1).Value = e.Value Then
                e.Value = ""
            End If

        End If

        If e.RowIndex > 0 And e.ColumnIndex = 2 Then
            If DataGridView1.Item(2, e.RowIndex - 1).Value = e.Value Then
                e.Value = ""
            End If
        End If
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Form1.Show()
        Form1.pnlStats.Height = Form1.btnDash.Height
        Form1.pnlStats.Top = Form1.btnDash.Top
        Me.Close()
    End Sub

    Private Sub btnDash_Click(sender As Object, e As EventArgs) Handles btnDash.Click
        Form1.pnlStats.Height = Form1.btnDash.Height
        Form1.pnlStats.Top = Form1.btnDash.Top
        Form1.btnDash.BackColor = Color.DodgerBlue
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub btnBridging_Click(sender As Object, e As EventArgs) Handles btnBridging.Click
        pnlStats.Height = btnBridging.Height
        pnlStats.Top = btnBridging.Top

        Dim btn As Button = CType(sender, Button)
        setColor(btn)
    End Sub

    Private Sub btnTindakan_Click(sender As Object, e As EventArgs) Handles btnTindakan.Click
        pnlStats.Height = btnTindakan.Height
        pnlStats.Top = btnTindakan.Top

        Dim btn As Button = CType(sender, Button)
        setColor(btn)
    End Sub

    Private Sub btnHasil_Click(sender As Object, e As EventArgs) Handles btnHasil.Click
        pnlStats.Height = btnHasil.Height
        pnlStats.Top = btnHasil.Top

        Dim btn As Button = CType(sender, Button)
        setColor(btn)
    End Sub

    Private Sub btnRiwayat_Click(sender As Object, e As EventArgs) Handles btnRiwayat.Click
        pnlStats.Height = btnRiwayat.Height
        pnlStats.Top = btnRiwayat.Top

        Dim btn As Button = CType(sender, Button)
        setColor(btn)
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Call caridata()
        'MsgBox(DateTimePicker1.Value.Month & " + " & DateTimePicker2.Text)
    End Sub
End Class