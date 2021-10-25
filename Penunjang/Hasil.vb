Imports MySql.Data.MySqlClient
Public Class Hasil

    Public Ambil_Data As String
    Public Form_Ambil_Data As String

    Dim noTindakan As String

    Sub setColor(button As Button)
        btnDash.BackColor = SystemColors.HotTrack
        btnBridging.BackColor = SystemColors.HotTrack
        btnTindakan.BackColor = SystemColors.HotTrack
        btnHasil.BackColor = SystemColors.HotTrack
        button.BackColor = Color.DodgerBlue
    End Sub

    Sub autoComboDok()
        Call koneksiServer()
        cmd = New MySqlCommand("SELECT namapetugasMedis FROM t_tenagamedis", conn)
        da = New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)

        cmbLaborat.DataSource = dt
        cmbLaborat.DisplayMember = "namapetugasMedis"
        cmbLaborat.ValueMember = "namapetugasMedis"
        cmbLaborat.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbLaborat.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Sub updateRegistrasiLabRanap()
        Call koneksiServer()

        Dim dt As String
        dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Try
            Dim str As String
            str = "UPDATE t_registrasipenunjangranap 
                   SET tglSelesaiLayaniPasien = '" & dt & "',
                       statusPenunjang = 'SELESAI', 
                       kdTenagaMedisPemeriksaan = '" & txtKdDokterPeriksa.Text & "' 
                   WHERE noRegistrasiPenunjangRanap = '" & txtNoPermintaan.Text & "'"

            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            'MsgBox("Update data Registrasi Pemeriksaan Lab berhasil dilakukan", MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox("Update data Registrasi Pemeriksaan Lab gagal dilakukan.", MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Sub updateRegistrasiLabRajal()
        Call koneksiServer()

        Dim dt As String
        dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Try
            Dim str As String
            str = "UPDATE t_registrasipenunjangrajal 
                   SET tglSelesaiLayaniPasien = '" & dt & "',
                       statusPenunjang = 'SELESAI', 
                       kdTenagaMedisPemeriksaan = '" & txtKdDokterPeriksa.Text & "' 
                   WHERE noRegistrasiPenunjangRajal = '" & txtNoPermintaan.Text & "'"

            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            'MsgBox("Update data Registrasi Pemeriksaan Lab berhasil dilakukan", MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox("Update data Registrasi Pemeriksaan Lab gagal dilakukan.", MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Sub updateRegistrasiLabLuar()
        Call koneksiServer()

        Dim dt As String
        dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Try
            Dim str As String
            str = "UPDATE t_registrasipenunjang 
                   SET tglSelesaiLayaniPasien = '" & dt & "',
                       statusPenunjang = 'SELESAI', 
                       kdTenagaMedisPemeriksaan = '" & txtKdDokterPeriksa.Text & "' 
                   WHERE noRegistrasiPenunjang = '" & txtNoPermintaan.Text & "'"

            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            'MsgBox("Update data Registrasi Pemeriksaan Lab berhasil dilakukan", MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox("Update data Registrasi Pemeriksaan Lab gagal dilakukan.", MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Sub updateLaboratDetail()
        Dim str As String = ""

        Select Case txtInstalasi.Text
            Case "RAWAT JALAN"
                str = "UPDATE t_detailtindakanpenunjangrajal
                          SET kdTenagaMedis = '" & txtKdDokterPeriksa.Text & "'
                        WHERE noTindakanPenunjangRajal = '" & noTindakan & "'"
            Case "RAWAT INAP"
                str = "UPDATE t_detailtindakanpenunjangranap
                          SET kdTenagaMedis = '" & txtKdDokterPeriksa.Text & "'
                        WHERE noTindakanPenunjangRanap = '" & noTindakan & "'"
            Case "PASIEN LUAR"
        End Select

        Call koneksiServer()
        Try
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            'MsgBox("Update Dokter Lab berhasil dilakukan", MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox("Update Dokter Lab gagal dilakukan.", MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Sub tampilDataSudahDitindakRanap()
        Call koneksiServer()
        da = New MySqlDataAdapter("SELECT kdTarif,tindakan,noTindakanPenunjangRanap 
                                   FROM vw_datalabpasienranap 
                                   WHERE noRekamedis = '" & txtNoRM.Text & "' 
                                   AND noDaftar = '" & txtNoReg.Text & "' 
                                   AND noRegistrasiPenunjangRanap = '" & txtNoPermintaan.Text & "' 
                                   AND statusPenunjang IS NOT NULL", conn)
        ds = New DataSet
        da.Fill(ds, "vw_datalabpasienranap")
        BunifuDgv1.DataSource = ds.Tables("vw_datalabpasienranap")

        Call aturDGV()
    End Sub

    Sub tampilDataSudahDitindakRajal()
        Call koneksiServer()
        da = New MySqlDataAdapter("SELECT kdTarif,tindakan,noTindakanPenunjangRajal 
                                   FROM vw_datalabpasienrajal 
                                   WHERE noRekamedis = '" & txtNoRM.Text & "' 
                                   AND noDaftar = '" & txtNoReg.Text & "' 
                                   AND noRegistrasiPenunjangRajal = '" & txtNoPermintaan.Text & "' 
                                   AND statusPenunjang IS NOT NULL", conn)
        ds = New DataSet
        da.Fill(ds, "vw_datalabpasienrajal")
        BunifuDgv1.DataSource = ds.Tables("vw_datalabpasienrajal")

        Call aturDGV()
    End Sub

    Sub tampilDataSudahDitindakLuar()
        Call koneksiServer()
        da = New MySqlDataAdapter("SELECT kdTarif,tindakan,noTindakanPenunjang
                                   FROM vw_datalabpasienluar
                                   WHERE noRekamedis = '" & txtNoRM.Text & "' 
                                   AND noDaftar = '" & txtNoReg.Text & "' 
                                   AND noRegistrasiPenunjang = '" & txtNoPermintaan.Text & "' 
                                   AND statusPenunjang IS NOT NULL", conn)
        ds = New DataSet
        da.Fill(ds, "vw_datalabpasienluar")
        BunifuDgv1.DataSource = ds.Tables("vw_datalabpasienrajalluar")

        Call aturDGV()
    End Sub

    Sub tampilJenisPemeriksaan()
        Call koneksiServer()
        da = New MySqlDataAdapter("SELECT kdHasilPemeriksaanLab, jenisPemeriksaan, satuanHasil, nilaiNormal 
                                   FROM vw_hasilpemeriksaanlab 
                                   WHERE KelompokPemeriksaanLab = '" & cmbKelPemeriksaan.Text & "'", conn)
        ds = New DataSet
        da.Fill(ds, "vw_hasilpemeriksaanlab")
        BunifuDgv2.DataSource = ds.Tables("vw_hasilpemeriksaanlab")

        Call aturDGV()
    End Sub

    Sub tampilHasilPemeriksaanRanap()
        Call koneksiServer()
        da = New MySqlDataAdapter("SELECT jenisPemeriksaan, satuanHasil, nilaiNormal, hasilPemeriksaanPasienRanap 
                                   FROM t_hasilpemeriksaanpasienranap 
                                   WHERE noRegistrasiPenunjangRanap = '" & txtNoPermintaan.Text & "'", conn)
        ds = New DataSet
        da.Fill(ds, "t_hasilpemeriksaanpasienranap")
        BunifuDgv3.DataSource = ds.Tables("t_hasilpemeriksaanpasienranap")

        Call aturDGV()
    End Sub

    Sub tampilHasilPemeriksaanRajal()
        Call koneksiServer()
        da = New MySqlDataAdapter("SELECT jenisPemeriksaan, satuanHasil, nilaiNormal, hasilPemeriksaanPasienRajal
                                   FROM t_hasilpemeriksaanpasienrajal
                                   WHERE noRegistrasiPenunjangRajal = '" & txtNoPermintaan.Text & "'", conn)
        ds = New DataSet
        da.Fill(ds, "t_hasilpemeriksaanpasienrajal")
        BunifuDgv3.DataSource = ds.Tables("t_hasilpemeriksaanpasienrajal")

        Call aturDGV()
    End Sub

    Sub tampilHasilPemeriksaanLuar()
        Call koneksiServer()
        da = New MySqlDataAdapter("SELECT jenisPemeriksaan, satuanHasil, nilaiNormal, hasilPemeriksaanPasien
                                   FROM t_hasilpemeriksaanpasien
                                   WHERE noRegistrasiPenunjang = '" & txtNoPermintaan.Text & "'", conn)
        ds = New DataSet
        da.Fill(ds, "t_hasilpemeriksaanpasien")
        BunifuDgv3.DataSource = ds.Tables("t_hasilpemeriksaanpasien")

        Call aturDGV()
    End Sub

    Sub tampilTextBoxTindakan()
        Dim jenis1 As String
        Dim kode As String = ""
        Dim jenis As String = ""
        Dim satuan As String = ""
        Dim nilaiNormal As String = ""

        If BunifuDgv1.CurrentRow Is Nothing Then Exit Sub
        Dim i As Integer = BunifuDgv1.CurrentRow.Index
        jenis1 = BunifuDgv1.Item(1, i).Value

        Try
            Call koneksiServer()
            Dim str As String
            str = "SELECT kdHasilPemeriksaanLab, 
                              jenisPemeriksaan, satuanHasil, 
                              nilaiNormal
                         FROM vw_hasilpemeriksaanlab 
                        WHERE jenisPemeriksaan = '" & jenis1 & "'"
            cmd = New MySqlCommand(str, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                kode = dr.Item("kdHasilPemeriksaanLab")
                jenis = dr.Item("jenisPemeriksaan")
                satuan = dr.Item("satuanHasil")
                nilaiNormal = dr.Item("nilaiNormal")
            End If

            txtKdHasilLab.Text = kode
            txtJenisPemeriksaan.Text = jenis
            txtSatuanHasil.Text = satuan
            txtNilaiNormal.Text = nilaiNormal
        Catch ex As Exception
        End Try
    End Sub

    Sub autoComboLaborat()
        conn.Close()
        Call koneksiServer()
        cmd = New MySqlCommand("SELECT namapetugasMedis 
                                  FROM t_tenagamedis
                                 WHERE kdKelompokTenagaMedis = 'ktm13'
                                   AND kdPetugasMedis NOT IN ('P189') 
                              ORDER BY kdPetugasMedis ASC", conn)
        da = New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)

        cmbLaborat.DataSource = dt
        cmbLaborat.DisplayMember = "namapetugasMedis"
        cmbLaborat.ValueMember = "namapetugasMedis"
        cmbLaborat.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbLaborat.AutoCompleteSource = AutoCompleteSource.ListItems
        conn.Close()
    End Sub

    Sub aturDGV()
        Try
            BunifuDgv1.Columns(0).Width = 100
            BunifuDgv1.Columns(1).Width = 400
            BunifuDgv1.Columns(2).Width = 100
            BunifuDgv1.Columns(0).HeaderText = "Kode"
            BunifuDgv1.Columns(1).HeaderText = "Jenis Pemeriksaan"
            BunifuDgv1.Columns(2).HeaderText = "No.Tindakan"

            BunifuDgv1.Columns(2).Visible = False
            BunifuDgv1.DefaultCellStyle.ForeColor = Color.Black
            BunifuDgv1.DefaultCellStyle.SelectionForeColor = Color.White

            BunifuDgv2.Columns(0).Width = 50
            BunifuDgv2.Columns(1).Width = 150
            BunifuDgv2.Columns(2).Width = 150
            BunifuDgv2.Columns(3).Width = 200
            BunifuDgv2.Columns(0).HeaderText = "Kode"
            BunifuDgv2.Columns(1).HeaderText = "Jenis Pemeriksaan"
            BunifuDgv2.Columns(2).HeaderText = "Satuan Hasil"
            BunifuDgv2.Columns(3).HeaderText = "Nilai Normal"

            BunifuDgv2.Columns(0).Visible = False
            BunifuDgv2.DefaultCellStyle.ForeColor = Color.Black
            BunifuDgv2.DefaultCellStyle.SelectionForeColor = Color.White

            BunifuDgv3.Columns(0).Width = 150
            BunifuDgv3.Columns(1).Width = 150
            BunifuDgv3.Columns(2).Width = 150
            BunifuDgv3.Columns(3).Width = 80
            BunifuDgv3.Columns(0).HeaderText = "Jenis Pemeriksaan"
            BunifuDgv3.Columns(1).HeaderText = "Satuan Hasil"
            BunifuDgv3.Columns(2).HeaderText = "Nilai Normal"
            BunifuDgv3.Columns(3).HeaderText = "Hasil"

            BunifuDgv3.DefaultCellStyle.ForeColor = Color.Black
            BunifuDgv3.DefaultCellStyle.SelectionForeColor = Color.White

            For i = 0 To BunifuDgv1.RowCount - 1
                If i Mod 2 = 0 Then
                    BunifuDgv1.Rows(i).DefaultCellStyle.BackColor = Color.White
                Else
                    BunifuDgv1.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                End If
            Next

            For i = 0 To BunifuDgv2.RowCount - 1
                If i Mod 2 = 0 Then
                    BunifuDgv2.Rows(i).DefaultCellStyle.BackColor = Color.White
                Else
                    BunifuDgv2.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                End If
            Next

            For i = 0 To BunifuDgv3.RowCount - 1
                If i Mod 2 = 0 Then
                    BunifuDgv3.Rows(i).DefaultCellStyle.BackColor = Color.White
                Else
                    BunifuDgv3.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Sub addHasilRanap()
        Call koneksiServer()
        Try
            Dim str As String
            str = "insert into t_hasilpemeriksaanpasienranap(noHasilPemeriksaanRanap,noRegistrasiPenunjangRanap,
                                                            kdHasilPemeriksaanLab,kelompokPemeriksaanLab,
                                                            jenisPemeriksaan,satuanHasil,nilaiNormal,
                                                            hasilPemeriksaanPasienRanap) 
                   values ('" & txtNoHasil.Text & "','" & txtNoPermintaan.Text & "','" & txtKdHasilLab.Text & "','" & cmbKelPemeriksaan.Text & "',
                           '" & txtJenisPemeriksaan.Text & "','" & txtSatuanHasil.Text & "','" & txtNilaiNormal.Text & "','" & txtHasil.Text & "')"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Insert Hasil Lab berhasil dilakukan.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Insert Hasil Lab gagal dilakukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Sub addHasilRajal()
        Call koneksiServer()
        Try
            Dim str As String
            str = "insert into t_hasilpemeriksaanpasienrajal(noHasilPemeriksaanRajal,noRegistrasiPenunjangRajal,
                                                            kdHasilPemeriksaanLab,kelompokPemeriksaanLab,
                                                            jenisPemeriksaan,satuanHasil,nilaiNormal,
                                                            hasilPemeriksaanPasienRajal) 
                   values ('" & txtNoHasil.Text & "','" & txtNoPermintaan.Text & "','" & txtKdHasilLab.Text & "','" & cmbKelPemeriksaan.Text & "',
                           '" & txtJenisPemeriksaan.Text & "','" & txtSatuanHasil.Text & "','" & txtNilaiNormal.Text & "','" & txtHasil.Text & "')"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Insert Hasil Lab berhasil dilakukan.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Insert Hasil Lab gagal dilakukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Sub addHasilLuar()
        Call koneksiServer()
        Try
            Dim str As String
            str = "insert into t_hasilpemeriksaanpasien(noHasilPemeriksaan,noRegistrasiPenunjang,
                                                            kdHasilPemeriksaanLab,kelompokPemeriksaanLab,
                                                            jenisPemeriksaan,satuanHasil,nilaiNormal,
                                                            hasilPemeriksaanPasien) 
                   values ('" & txtNoHasil.Text & "','" & txtNoPermintaan.Text & "','" & txtKdHasilLab.Text & "','" & cmbKelPemeriksaan.Text & "',
                           '" & txtJenisPemeriksaan.Text & "','" & txtSatuanHasil.Text & "','" & txtNilaiNormal.Text & "','" & txtHasil.Text & "')"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Insert Hasil Lab berhasil dilakukan.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Insert Hasil Lab gagal dilakukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Sub autoNoHasilRanap()
        Dim noHasilLab As String
        Try
            Call koneksiServer()
            Dim query As String
            query = "Select RIGHT(noHasilPemeriksaanRanap,1) FROM t_hasilpemeriksaanpasienranap ORDER BY noHasilPemeriksaanRanap DESC LIMIT 1"
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                dr.Read()
                noHasilLab = "HL" + Format(Now, "ddMMyyHHmmss") + "-" + (Val(Trim(dr.Item(0).ToString)) + 1).ToString
                txtNoHasil.Text = noHasilLab
            Else
                noHasilLab = "HL" + Format(Now, "ddMMyyHHmmss") + "-1"
                txtNoHasil.Text = noHasilLab
            End If
            conn.Close()
        Catch ex As Exception

        End Try
    End Sub

    Sub autoNoHasilRajal()
        Dim noHasilLab As String
        Try
            Call koneksiServer()
            Dim query As String
            query = "Select RIGHT(noHasilPemeriksaanRajal,1) FROM t_hasilpemeriksaanpasienrajal ORDER BY noHasilPemeriksaanRajal DESC LIMIT 1"
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                dr.Read()
                noHasilLab = "HL" + Format(Now, "ddMMyyHHmmss") + "-" + (Val(Trim(dr.Item(0).ToString)) + 1).ToString
                txtNoHasil.Text = noHasilLab
            Else
                noHasilLab = "HL" + Format(Now, "ddMMyyHHmmss") + "-1"
                txtNoHasil.Text = noHasilLab
            End If
            conn.Close()
        Catch ex As Exception

        End Try
    End Sub

    Sub autoNoHasilLuar()
        Dim noHasilLab As String
        Try
            Call koneksiServer()
            Dim query As String
            query = "Select RIGHT(noHasilPemeriksaan,1) FROM t_hasilpemeriksaanpasien ORDER BY noHasilPemeriksaan DESC LIMIT 1"
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                dr.Read()
                noHasilLab = "HL" + Format(Now, "ddMMyyHHmmss") + "-" + (Val(Trim(dr.Item(0).ToString)) + 1).ToString
                txtNoHasil.Text = noHasilLab
            Else
                noHasilLab = "HL" + Format(Now, "ddMMyyHHmmss") + "-1"
                txtNoHasil.Text = noHasilLab
            End If
            conn.Close()
        Catch ex As Exception

        End Try
    End Sub

    Sub autoComboJenisPemeriksaan()
        Call koneksiServer()
        cmd = New MySqlCommand("select KelompokPemeriksaanLab from t_kelompokpemeriksaanlab", conn)
        da = New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)

        cmbKelPemeriksaan.DataSource = dt
        cmbKelPemeriksaan.DisplayMember = "KelompokPemeriksaanLab"
        cmbKelPemeriksaan.ValueMember = "KelompokPemeriksaanLab"
        cmbKelPemeriksaan.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbKelPemeriksaan.AutoCompleteSource = AutoCompleteSource.ListItems
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

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Form1.Show()
        Form1.pnlStats.Height = Form1.btnDash.Height
        Form1.pnlStats.Top = Form1.btnDash.Top
        Me.Close()
    End Sub

    Private Sub Hasil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlStats.Height = btnHasil.Height
        pnlStats.Top = btnHasil.Top
        btnHasil.BackColor = Color.DodgerBlue

        If Ambil_Data = True Then
            Select Case Form_Ambil_Data
                Case "Hasil"
                    txtNoRM.Text = Form1.txtNoRM.Text
                    txtNoReg.Text = Form1.txtNoReg.Text
                    txtNamaPasien.Text = Form1.txtNamaPasien.Text
                    txtAlamat.Text = Form1.txtAlamat.Text
                    txtUsia.Text = Form1.txtUsia.Text
                    txtUnitAsal.Text = Form1.txtInstalasi.Text
                    txtDokter1.Text = Form1.txtDokter.Text
                    txtNoPermintaan.Text = Form1.txtNoPermintaan.Text
                    dateReg.Text = Form1.txtTglReg.Text
                    txtInstalasi.Text = Form1.txtInstalasi.Text
            End Select
        End If

        Select Case txtUnitAsal.Text
            Case "RAWAT JALAN"
                Call tampilDataSudahDitindakRajal()
                Call autoNoHasilRajal()
                Call tampilHasilPemeriksaanRajal()
            Case "RAWAT INAP"
                Call tampilDataSudahDitindakRanap()
                Call autoNoHasilRanap()
                Call tampilHasilPemeriksaanRanap()
            Case "PASIEN LUAR"
                Call tampilDataSudahDitindakLuar()
                Call autoNoHasilLuar()
                Call tampilHasilPemeriksaanLuar()
        End Select

        Call autoComboJenisPemeriksaan()
        Call autoComboLaborat()
        Call aturDGV()
    End Sub

    Private Sub cmbJenisPemeriksaan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKelPemeriksaan.SelectedIndexChanged
        Call tampilJenisPemeriksaan()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtHasil.Text = Nothing Then
            MessageBox.Show("Masukkan nilai hasil.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtHasil.Select()
            txtHasil.BackColor = Color.FromArgb(255, 112, 112)
        ElseIf txtKdMedis.Text = Nothing Then
            MessageBox.Show("Masukkan laborat.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbLaborat.Select()
            cmbLaborat.BackColor = Color.FromArgb(255, 112, 112)
        ElseIf txtKdDokterPeriksa.Text = Nothing Then
            MessageBox.Show("Masukkan Dokter laboratorium.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbDokter.Select()
            cmbDokter.BackColor = Color.FromArgb(255, 112, 112)
        Else
            Select Case txtUnitAsal.Text
                Case "RAWAT JALAN"
                    Call updateRegistrasiLabRajal()
                    Call addHasilRajal()
                    Call tampilHasilPemeriksaanRajal()
                    Call autoNoHasilRajal()
                Case "RAWAT INAP"
                    Call updateRegistrasiLabRanap()
                    Call addHasilRanap()
                    Call tampilHasilPemeriksaanRanap()
                    Call autoNoHasilRanap()
                Case "PASIEN LUAR"
                    Call updateRegistrasiLabLuar()
                    Call addHasilLuar()
                    Call tampilHasilPemeriksaanLuar()
                    Call autoNoHasilLuar()
            End Select
        End If
    End Sub

    Private Sub BunifuDgv2_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles BunifuDgv2.CellMouseClick
        Dim kode, jenis, satuan, nilaiNormal As String

        If e.RowIndex = -1 Then
            Return
        End If

        kode = BunifuDgv2.Rows(e.RowIndex).Cells(0).Value
        jenis = BunifuDgv2.Rows(e.RowIndex).Cells(1).Value
        satuan = BunifuDgv2.Rows(e.RowIndex).Cells(2).Value.ToString
        nilaiNormal = BunifuDgv2.Rows(e.RowIndex).Cells(3).Value

        txtKdHasilLab.Text = kode
        txtJenisPemeriksaan.Text = jenis
        txtSatuanHasil.Text = satuan
        txtNilaiNormal.Text = nilaiNormal
        txtJenis2.Text = jenis
        txtJenis2.Visible = True
    End Sub

    Private Sub cmbMedis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLaborat.SelectedIndexChanged
        Call koneksiServer()
        Try
            Dim query As String
            query = "select * from t_tenagamedis where namapetugasMedis = '" & cmbLaborat.Text & "'"
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader

            While dr.Read
                txtKdMedis.Text = UCase(dr.GetString("kdPetugasMedis"))
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub BunifuDgv1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles BunifuDgv1.CellMouseClick
        Dim jenis1 As String

        If e.RowIndex = -1 Then
            Return
        End If

        jenis1 = BunifuDgv1.Rows(e.RowIndex).Cells(1).Value
        noTindakan = BunifuDgv1.Rows(e.RowIndex).Cells(2).Value
        txtJenis2.Text = jenis1
        txtJenis2.Visible = True

        Call tampilTextBoxTindakan()
    End Sub

    Private Sub btnCetak_Click(sender As Object, e As EventArgs) Handles btnCetak.Click
        Select Case txtUnitAsal.Text
            Case "RAWAT JALAN"
                ViewCetakHasilRajal.Ambil_Data = True
                ViewCetakHasilRajal.Form_Ambil_Data = "Cetak"
                ViewCetakHasilRajal.Show()
            Case "RAWAT INAP"
                ViewCetakHasilRanap.Ambil_Data = True
                ViewCetakHasilRanap.Form_Ambil_Data = "Cetak"
                ViewCetakHasilRanap.Show()
        End Select
    End Sub

    Private Sub cmbDokter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDokter.SelectedIndexChanged
        Call koneksiServer()
        Try
            Dim query As String
            query = "select * from t_tenagamedis where namapetugasMedis = '" & cmbDokter.Text & "'"
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader

            While dr.Read
                txtKdDokterPeriksa.Text = UCase(dr.GetString("kdPetugasMedis"))
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub txtHasil_TextChanged(sender As Object, e As EventArgs) Handles txtHasil.TextChanged
        If txtHasil.Text <> "" Then
            txtHasil.BackColor = Color.White
        End If
    End Sub

    Private Sub cmbLaborat_TextChanged(sender As Object, e As EventArgs) Handles cmbLaborat.TextChanged
        If cmbLaborat.Text <> "" Then
            cmbLaborat.BackColor = Color.White
        End If
    End Sub

    Private Sub cmbDokter_TextChanged(sender As Object, e As EventArgs) Handles cmbDokter.TextChanged
        If cmbDokter.Text <> "" Then
            cmbDokter.BackColor = Color.White
        End If
    End Sub
End Class