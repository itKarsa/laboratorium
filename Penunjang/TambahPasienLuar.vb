Imports MySql.Data.MySqlClient
Public Class TambahPasienLuar

    Sub autoNoPermintaan()
        Dim noPermintaanLab As String

        Try
            Call koneksiServer()
            Dim query As String = ""
            Dim kode As String = ""

            query = "SELECT SUBSTR(noRegistrasiPenunjang,16,4) FROM t_registrasipenunjang ORDER BY CAST(SUBSTR(noRegistrasiPenunjang,16,4) AS UNSIGNED) DESC LIMIT 1"
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                dr.Read()
                noPermintaanLab = "031" + Format(Now, "ddMMyyHHmmss") + "-" + (Val(Trim(dr.Item(0).ToString)) + 1).ToString
                txtNoPermintaan.Text = noPermintaanLab
            Else
                noPermintaanLab = "031" + Format(Now, "ddMMyyHHmmss") + "-1"
                txtNoPermintaan.Text = noPermintaanLab
            End If
            dr.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Exclamation, "NO.PERMINTAAN")
        End Try
    End Sub

    Sub addRegLab()
        Dim dt As String
        dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Call koneksiServer()
        Try
            Dim str As String
            str = "insert into t_registrasipenunjang(noRegistrasiPenunjang,noDaftar,
                                                          kdUnitAsal,unitAsal,kdUnit,unit,
                                                          tglMasukPenunjang,statusPenunjang,
                                                          kdTenagaMedisPengirim,keterangan) 
                   values ('" & txtNoPermintaan.Text & "','" & txtNoReg.Text & "','0',
                           '" & txtRs.Text & "','3002','Laboratorium','" & dt & "','PERMINTAAN','0000',
                           '" & txtKetKlinis.Text & "')"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Insert data Permintaan Penunjang berhasil dilakukan", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            MsgBox("Insert data Permintaan Penunjang gagal dilakukan.", MsgBoxStyle.Critical, "Error")
        End Try
        conn.Close()
    End Sub

    Private Sub TambahPasienLuar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As String
        dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        txtNamaPasien.BackColor = Color.FromArgb(255, 112, 112)
        txtUmur.BackColor = Color.FromArgb(255, 112, 112)
        txtJk.BackColor = Color.FromArgb(255, 112, 112)
        txtAlamat.BackColor = Color.FromArgb(255, 112, 112)
        txtRs.BackColor = Color.FromArgb(255, 112, 112)
        txtDokter.BackColor = Color.FromArgb(255, 112, 112)
        txtKetKlinis.BackColor = Color.FromArgb(255, 112, 112)

        txtNoRM.Text = "00000000"
        txtNoReg.Text = Format(Now, "ddMMyyHHmmss") + "-000"
        datePermintaan.Text = dt

        Call autoNoPermintaan()
    End Sub

    Private Sub txtTglLahir_ValueChanged(sender As Object, e As EventArgs) Handles txtTglLahir.ValueChanged
        Dim lahir As Date = txtTglLahir.Value
        txtUmur.Text = hitungUmur(lahir)
    End Sub

    Private Sub txtNamaPasien_TextChanged(sender As Object, e As EventArgs) Handles txtNamaPasien.TextChanged
        If txtNamaPasien.Text <> "" Then
            txtNamaPasien.BackColor = Color.White
        End If
    End Sub

    Private Sub txtNamaPasien_LostFocus(sender As Object, e As EventArgs) Handles txtNamaPasien.LostFocus
        If txtNamaPasien.Text = "" Then
            txtNamaPasien.BackColor = Color.FromArgb(255, 112, 112)
        End If
    End Sub

    Private Sub txtNamaPasien_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNamaPasien.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            If txtNamaPasien.Text = "" Then
                txtNamaPasien.BackColor = Color.FromArgb(255, 112, 112)
            End If
        End If
    End Sub

    Private Sub txtUmur_TextChanged(sender As Object, e As EventArgs) Handles txtUmur.TextChanged
        If txtUmur.Text <> "" Then
            txtUmur.BackColor = Color.White
        End If
    End Sub

    Private Sub txtUmur_LostFocus(sender As Object, e As EventArgs) Handles txtUmur.LostFocus
        If txtUmur.Text = "" Then
            txtUmur.BackColor = Color.FromArgb(255, 112, 112)
        End If
    End Sub

    Private Sub txtUmur_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUmur.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            If txtUmur.Text = "" Then
                txtUmur.BackColor = Color.FromArgb(255, 112, 112)
            End If
        End If
    End Sub

    Private Sub txtJk_TextChanged(sender As Object, e As EventArgs) Handles txtJk.TextChanged
        If txtJk.Text <> "" Then
            txtJk.BackColor = Color.White
        End If
    End Sub

    Private Sub txtJk_LostFocus(sender As Object, e As EventArgs) Handles txtJk.LostFocus
        If txtJk.Text = "" Then
            txtJk.BackColor = Color.FromArgb(255, 112, 112)
        End If
    End Sub

    Private Sub txtJk_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJk.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            If txtJk.Text = "" Then
                txtJk.BackColor = Color.FromArgb(255, 112, 112)
            End If
        End If
    End Sub

    Private Sub txtAlamat_TextChanged(sender As Object, e As EventArgs) Handles txtAlamat.TextChanged
        If txtAlamat.Text <> "" Then
            txtAlamat.BackColor = Color.White
        End If
    End Sub

    Private Sub txtAlamat_LostFocus(sender As Object, e As EventArgs) Handles txtAlamat.LostFocus
        If txtAlamat.Text = "" Then
            txtAlamat.BackColor = Color.FromArgb(255, 112, 112)
        End If
    End Sub

    Private Sub txtAlamat_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAlamat.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            If txtAlamat.Text = "" Then
                txtAlamat.BackColor = Color.FromArgb(255, 112, 112)
            End If
        End If
    End Sub

    Private Sub txtRs_TextChanged(sender As Object, e As EventArgs) Handles txtRs.TextChanged
        If txtRs.Text <> "" Then
            txtRs.BackColor = Color.White
        End If
    End Sub

    Private Sub txtRs_LostFocus(sender As Object, e As EventArgs) Handles txtRs.LostFocus
        If txtRs.Text = "" Then
            txtRs.BackColor = Color.FromArgb(255, 112, 112)
        End If
    End Sub

    Private Sub txtRs_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRs.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            If txtRs.Text = "" Then
                txtRs.BackColor = Color.FromArgb(255, 112, 112)
            End If
        End If
    End Sub

    Private Sub txtDokter_TextChanged(sender As Object, e As EventArgs) Handles txtDokter.TextChanged
        If txtDokter.Text <> "" Then
            txtDokter.BackColor = Color.White
        End If
    End Sub

    Private Sub txtDokter_LostFocus(sender As Object, e As EventArgs) Handles txtDokter.LostFocus
        If txtDokter.Text = "" Then
            txtDokter.BackColor = Color.FromArgb(255, 112, 112)
        End If
    End Sub

    Private Sub txtDokter_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDokter.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            If txtDokter.Text = "" Then
                txtDokter.BackColor = Color.FromArgb(255, 112, 112)
            End If
        End If
    End Sub

    Private Sub txtKetKlinis_TextChanged(sender As Object, e As EventArgs) Handles txtKetKlinis.TextChanged
        If txtKetKlinis.Text <> "" Then
            txtKetKlinis.BackColor = Color.White
        End If
    End Sub

    Private Sub txtKetKlinis_LostFocus(sender As Object, e As EventArgs) Handles txtKetKlinis.LostFocus
        If txtKetKlinis.Text = "" Then
            txtKetKlinis.BackColor = Color.FromArgb(255, 112, 112)
        End If
    End Sub

    Private Sub txtKetKlinis_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKetKlinis.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            If txtKetKlinis.Text = "" Then
                txtKetKlinis.BackColor = Color.FromArgb(255, 112, 112)
            End If
        End If
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If txtKetKlinis.Text = "" Then
            MsgBox("Mohon Ket.Klinis diisi terlebih dahulu !!", MsgBoxStyle.Exclamation)
        Else
            Call addRegLab()

            Tindakan.Ambil_Data = True
            Tindakan.Form_Ambil_Data = "Tindakan Luar"
            Tindakan.Show()

            Me.Close()
            Form1.Hide()
        End If
    End Sub
End Class