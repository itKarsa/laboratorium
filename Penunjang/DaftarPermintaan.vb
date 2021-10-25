Imports MySql.Data.MySqlClient
Public Class DaftarPermintaan

    Public Ambil_Data As String
    Public Form_Ambil_Data As String

    Dim noReg, noRM, tglReg, noPermintaan As String

    Sub tampilDataTgl()
        Call koneksiServer()
        da = New MySqlDataAdapter("CALL daftarTglRegisLabRanap('" & noRM & "', '" & noReg & "')", conn)
        ds = New DataSet
        da.Fill(ds, "vw_datalabpasienranap")
        BunifuDgv1.DataSource = ds.Tables("vw_datalabpasienranap")
        aturDGV1()

        conn.Close()
    End Sub
    Sub tampilDataTindakan()
        Call koneksiServer()
        da = New MySqlDataAdapter("CALL daftarTindakanPermintaanLabRanap('" & noRM & "', '" & noReg & "', '" & noReg & "','" & noReg & "')", conn)
        ds = New DataSet
        da.Fill(ds, "vw_datalabpasienranap")
        BunifuDgv2.DataSource = ds.Tables("vw_datalabpasienranap")
        aturDGV2()

        conn.Close()
    End Sub

    Sub aturDGV1()
        Try
            BunifuDgv1.Columns(0).Width = 150
            BunifuDgv1.Columns(1).Width = 150
            BunifuDgv1.Columns(0).HeaderText = "Tanggal"
            BunifuDgv1.Columns(1).HeaderText = "No.Permintaan"

        Catch ex As Exception

        End Try
    End Sub

    Sub aturDGV2()
        Try
            Dim checkBox As New DataGridViewCheckBoxColumn()
            BunifuDgv2.Columns.Add(checkBox)
            checkBox.HeaderText = "Sudah"
            checkBox.Name = "Cek"

            BunifuDgv1.Columns(0).Width = 150
            BunifuDgv1.Columns(1).Width = 100
            BunifuDgv1.Columns(2).Width = 50
            BunifuDgv1.Columns(0).HeaderText = "Pemeriksaan"
            BunifuDgv1.Columns(1).HeaderText = "Jenis"

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DaftarPermintaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Ambil_Data = True Then
            Select Case Form_Ambil_Data
                Case "Permintaan"
                    noRM = Form1.txtNoRM.Text
                    noReg = Form1.txtNoReg.Text
            End Select
        End If

        Call tampilDataTgl()


    End Sub

    Private Sub BunifuDgv1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles BunifuDgv1.CellMouseClick
        'Dim tglReg, noPermintaan As String

        If e.RowIndex = -1 Then
            Return
        End If

        tglReg = BunifuDgv1.Rows(e.RowIndex).Cells(0).Value
        noPermintaan = BunifuDgv1.Rows(e.RowIndex).Cells(1).Value

        Call tampilDataTindakan()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class