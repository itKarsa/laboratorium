Imports MySql.Data.MySqlClient
Public Class BridgingLis

    Public Ambil_Data As String
    Public Form_Ambil_Data As String

    Dim jk As String
    Dim tglLahir As Date
    Dim key As String
    Dim value As String
    Dim ruang As String = ""
    Dim kelas As String = ""

    Dim inTglLahir As String

    Sub setColor(button As Button)
        btnDash.BackColor = SystemColors.HotTrack
        btnBridging.BackColor = SystemColors.HotTrack
        btnTindakan.BackColor = SystemColors.HotTrack
        btnHasil.BackColor = SystemColors.HotTrack
        button.BackColor = Color.DodgerBlue
    End Sub

    Sub cariDataRajal()
        Dim query As String
        Dim cmd As MySqlCommand
        Dim dr As MySqlDataReader

        query = "SELECT * FROM vw_pasienrawatjalan WHERE noRekamedis = '" & txtNoRM.Text & "'"

        Try
            Call koneksiServer()
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader

            Do While dr.Read
                tglLahir = dr.Item("tglLahir").ToString
                inTglLahir = Convert.ToString(tglLahir.ToString("yyyyMMdd")) + "000000"
                txtTglLahir.Text = tglLahir
                jk = dr.Item("jenisKelamin").ToString
                If jk = "L" Then
                    txtJk.Text = "LAKI-LAKI"
                    txtKdJk.Text = "1"
                ElseIf jk = "P" Then
                    txtJk.Text = "PEREMPUAN"
                    txtKdJk.Text = "2"
                End If
                txtProv.Text = dr.Item("provinsi").ToString
                txtKota.Text = dr.Item("kabupaten").ToString
                txtKec.Text = dr.Item("kecamatan").ToString
                txtKel.Text = dr.Item("kelurahan").ToString
                txtNoRegIns.Text = dr.Item("noRegistrasiRawatJalan").ToString
                'tglMasuk = dr.Item("provinsi")
                txtTglMsk.Text = dr.Item("tglMasukRawatJalan").ToString
                txtInstalasi.Text = "RAWAT JALAN"
                txtAsal.Text = dr.Item("asalPasien").ToString
                'txtCaraBayar.Text = dr.Item("carabayar").ToString
                txtPenjamin.Text = dr.Item("penjamin").ToString
                'txtRuang.Text = dr.Item("unit").ToString
            Loop

            dr.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        txtRuang.Enabled = False
        txtKelas.Enabled = False
        txtNoKm.Enabled = False
        txtNoBed.Enabled = False

        conn.Close()
    End Sub

    Sub cariDataRanap()
        Dim query As String
        Dim cmd As MySqlCommand
        Dim dr As MySqlDataReader

        query = "SELECT * FROM vw_pasienrawatinap WHERE noRekamedis = '" & txtNoRM.Text & "'"

        Try
            Call koneksiServer()
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader

            Do While dr.Read
                tglLahir = dr.Item("tglLahir").ToString
                inTglLahir = Convert.ToString(tglLahir.ToString("yyyyMMdd")) + "000000"
                txtTglLahir.Text = tglLahir
                jk = dr.Item("jenisKelamin").ToString
                If jk = "L" Then
                    txtJk.Text = "LAKI-LAKI"
                    txtKdJk.Text = "1"
                ElseIf jk = "P" Then
                    txtJk.Text = "PEREMPUAN"
                    txtKdJk.Text = "2"
                End If
                txtProv.Text = dr.Item("provinsi").ToString
                txtKota.Text = dr.Item("kabupaten").ToString
                txtKec.Text = dr.Item("kecamatan").ToString
                txtKel.Text = dr.Item("kelurahan").ToString
                txtNoRegIns.Text = dr.Item("noDaftarRawatInap").ToString
                txtTglMsk.Text = dr.Item("tglMasukRawatInap").ToString
                txtInstalasi.Text = "RAWAT INAP"
                txtAsal.Text = dr.Item("asalPasien").ToString
                'txtCaraBayar.Text = dr.Item("carabayar").ToString
                txtPenjamin.Text = dr.Item("penjamin").ToString
                'txtRuang.Text = dr.Item("rawatInap").ToString
                txtKelas.Text = dr.Item("kelas").ToString
                txtNoKm.Text = dr.Item("noKamar").ToString
                txtNoBed.Text = dr.Item("noBed").ToString
            Loop

            dr.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub cariDataLuar()

    End Sub

    Sub cariDataIgd()
        Call koneksiServer()
        Dim query As String
        Dim cmd As MySqlCommand
        Dim dr As MySqlDataReader

        query = "SELECT * FROM vw_pasienrawatjalan WHERE noRekamedis = '" & txtNoRM.Text & "'"

        Try
            Call koneksiServer()
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader

            Do While dr.Read
                tglLahir = dr.Item("tglLahir").ToString
                inTglLahir = Convert.ToString(tglLahir.ToString("yyyyMMdd")) + "000000"
                txtTglLahir.Text = tglLahir
                jk = dr.Item("jenisKelamin").ToString
                If jk = "L" Then
                    txtJk.Text = "LAKI-LAKI"
                    txtKdJk.Text = "1"
                ElseIf jk = "P" Then
                    txtJk.Text = "PEREMPUAN"
                    txtKdJk.Text = "2"
                End If
                txtProv.Text = dr.Item("provinsi").ToString
                txtKota.Text = dr.Item("kabupaten").ToString
                txtKec.Text = dr.Item("kecamatan").ToString
                txtKel.Text = dr.Item("kelurahan").ToString
                txtNoRegIns.Text = dr.Item("noRegistrasiRawatJalan").ToString
                'tglMasuk = dr.Item("provinsi")
                txtTglMsk.Text = dr.Item("tglMasukRawatJalan").ToString
                txtInstalasi.Text = "IGD"
                txtAsal.Text = dr.Item("asalPasien").ToString
                'txtCaraBayar.Text = dr.Item("carabayar").ToString
                txtPenjamin.Text = dr.Item("penjamin").ToString
                'txtRuang.Text = dr.Item("unit").ToString
            Loop

            dr.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        txtRuang.Enabled = False
        txtKelas.Enabled = False
        txtNoKm.Enabled = False
        txtNoBed.Enabled = False

        conn.Close()
    End Sub

    Sub tampilDataSudahDitindakAll()
        Dim query As String = ""
        Select Case cmbInstalasi.Text
            Case "RAWAT JALAN"
                query = "CALL datadetaillabrajal('" & Form1.noTindakanPenunjang & "')"
            Case "RAWAT INAP"
                query = "CALL datadetaillabranap('" & Form1.noTindakanPenunjang & "')"
            Case "IGD"
                query = "CALL datadetaillabrajal('" & Form1.noTindakanPenunjang & "')"
        End Select

        Try
            Call koneksiServer()
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            BunifuDgv2.Rows.Clear()

            Select Case cmbInstalasi.Text
                Case "RAWAT JALAN"
                    Do While dr.Read
                        BunifuDgv2.Rows.Add(dr.Item("kdTarif"), dr.Item("tindakan"), dr.Item("PPA"),
                                       dr.Item("tarif"), dr.Item("statusTindakan"), dr.Item("tglMulaiLayaniPasien"),
                                       dr.Item("tglSelesaiLayaniPasien"), dr.Item("idTindakanPenunjangRajal"),
                                       dr.Item("noTindakanPenunjangRajal"))
                    Loop
                Case "RAWAT INAP"
                    Do While dr.Read
                        BunifuDgv2.Rows.Add(dr.Item("kdTarif"), dr.Item("tindakan"), dr.Item("PPA"),
                                       dr.Item("tarif"), dr.Item("statusTindakan"), dr.Item("tglMulaiLayaniPasien"),
                                       dr.Item("tglSelesaiLayaniPasien"), dr.Item("idTindakanPenunjangRanap"),
                                       dr.Item("noTindakanPenunjangRanap"))
                    Loop
                Case "IGD"
                    Do While dr.Read
                        BunifuDgv2.Rows.Add(dr.Item("kdTarif"), dr.Item("tindakan"), dr.Item("PPA"),
                                       dr.Item("tarif"), dr.Item("statusTindakan"), dr.Item("tglMulaiLayaniPasien"),
                                       dr.Item("tglSelesaiLayaniPasien"), dr.Item("idTindakanPenunjangRajal"),
                                       dr.Item("noTindakanPenunjangRajal"))
                    Loop
            End Select

            dr.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    Private Sub BridgingLis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlStats.Height = btnBridging.Height
        pnlStats.Top = btnBridging.Top

        btnBridging.BackColor = Color.DodgerBlue

        If Ambil_Data = True Then
            Select Case Form_Ambil_Data
                Case "Bridging"
                    txtNoRM.Text = Form1.txtNoRM.Text
                    txtNoReg.Text = Form1.txtNoReg.Text
                    txtNama.Text = Form1.txtNamaPasien.Text
                    txtAlamat.Text = Form1.txtAlamat.Text
                    txtUmur.Text = Form1.txtUsia.Text
                    txtDokter.Text = Form1.txtDokter.Text
                    cmbInstalasi.Text = Form1.txtInstalasi.Text
                    txtTglPerm.Text = Form1.txtTglReg.Text
                    txtNoPerm.Text = Form1.txtNoPermintaan.Text
                    txtCaraBayar.Text = Form1.caraBayar
                    txtRuang.Text = Form1.unit
            End Select
        End If

        Select Case cmbInstalasi.Text
            Case "RAWAT JALAN"
                Call cariDataRajal()
                Call tampilDataSudahDitindakAll()
                txtKdInstalasi.Text = "OP"
                ruang = txtRuang.Text & " " & txtKategori.Text
                'MsgBox(ruang)
            Case "RAWAT INAP"
                Call cariDataRanap()
                Call tampilDataSudahDitindakAll()
                txtKdInstalasi.Text = "IP"
                'If txtRuang.Text.Contains("LAVENDER") Then
                '    kelas = txtKelas.Text.Substring(6)
                '    ruang = "LAVENDER" & " / " & kelas & " " & txtKategori.Text
                '    MsgBox(ruang)
                'Else
                'End If
                kelas = txtKelas.Text.Substring(6)
                ruang = txtRuang.Text & " / " & kelas & " " & txtKategori.Text
                MsgBox(ruang)
            Case "IGD"
                Call cariDataIgd()
                Call tampilDataSudahDitindakAll()
                txtKdInstalasi.Text = "OP"
            Case "PASIEN LUAR"
                Call cariDataLuar()
                Call tampilDataSudahDitindakAll()
        End Select

        Call koneksiServer()

        Try
            Dim query As String
            query = "SELECT kode FROM t_unitlis WHERE unit LIKE '%" & ruang & "%'"
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            MsgBox(query)
            While dr.Read
                txtKodeUnit.Text = UCase(dr.GetString("kode"))
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        MsgBox(txtKodeUnit.Text)
        conn.Close()
    End Sub

    Sub addToBridgingLis(order As String)
        Dim dt As String
        dt = DateTime.Now.ToString("yyyyMMddHHmmss")

        Call koneksiLis()
        Try
            Dim str As String
            str = "INSERT INTO laborder(MESSAGE_ID,MESSAGE_DT,ORDER_CONTROL,
                                        PID,PNAME,ADDRESS1,ADDRESS2,ADDRESS3,
                                        ADDRESS4,PTYPE,BIRTH_DT,SEX,ONO,REQUEST_DT,
                                        SOURCE,CLINICIAN,ROOM_NO,PRIORITY,
                                        PStatus,ORDER_TESTID)
                   VALUES ('O01','" & dt & "','NW','" & txtNoRM.Text & "','" & txtNama.Text & "','" & txtAlamat.Text & "',
                           '" & txtKec.Text & "','" & txtKel.Text & "','" & txtPenjamin.Text & "','" & txtKdInstalasi.Text & "','" & inTglLahir & "',
                           '" & txtKdJk.Text & "','" & txtNoPerm.Text & "','" & dt & "','" & txtKodeUnit.Text & "^" & txtRuang.Text & "',
                           '" & txtKdDokter.Text & "^" & txtDokter.Text & "','1234','R','0','" & order & "')"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Insert LIS berhasil dilakukan", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            MsgBox("Insert LIS gagal dilakukan.", MsgBoxStyle.Critical, "Error")
        End Try

        conn.Close()
    End Sub

    Sub addToBridgingLisLog(order As String)
        Dim dt As String
        dt = DateTime.Now.ToString("yyyyMMddHHmmss")

        Call koneksiLis()
        Try
            Dim str As String
            str = "INSERT INTO laborder_log(MESSAGE_ID,MESSAGE_DT,ORDER_CONTROL,
                                        PID,PNAME,ADDRESS1,ADDRESS2,ADDRESS3,
                                        ADDRESS4,PTYPE,BIRTH_DT,SEX,ONO,REQUEST_DT,
                                        SOURCE,CLINICIAN,ROOM_NO,PRIORITY,
                                        PStatus,ORDER_TESTID)
                   VALUES ('O01','" & dt & "','NW','" & txtNoRM.Text & "','" & txtNama.Text & "','" & txtAlamat.Text & "',
                           '" & txtKec.Text & "','" & txtKel.Text & "','" & txtPenjamin.Text & "','" & txtKdInstalasi.Text & "','" & inTglLahir & "',
                           '" & txtKdJk.Text & "','" & txtNoPerm.Text & "','" & dt & "','" & txtKodeUnit.Text & "^" & txtRuang.Text & "',
                           '" & txtKdDokter.Text & "^" & txtDokter.Text & "','1234','R','0','" & order & "')"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            'MsgBox("Insert LIS_log berhasil dilakukan", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            MsgBox("Insert LIS_log gagal dilakukan.", MsgBoxStyle.Critical, "Error")
        End Try

        conn.Close()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Form1.Show()
        Form1.pnlStats.Height = Form1.btnDash.Height
        Form1.pnlStats.Top = Form1.btnDash.Top
        Me.Close()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim order As New List(Of String)
        Dim noOrder As String
        Dim numOrder As Integer = 0

        For Each row As DataGridViewRow In BunifuDgv2.Rows
            order.Add(row.Cells(0).Value.ToString)
            numOrder = numOrder + 1
        Next

        noOrder = String.Join("~", order.ToArray)

        If numOrder > 0 Then
            Call addToBridgingLis(noOrder)
            Call addToBridgingLisLog(noOrder)
            'MsgBox(noOrder)
        End If

    End Sub

    Private Sub btnDash_Click(sender As Object, e As EventArgs) Handles btnDash.Click
        Form1.pnlStats.Height = Form1.btnDash.Height
        Form1.pnlStats.Top = Form1.btnDash.Top
        Form1.btnDash.BackColor = Color.DodgerBlue
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub BunifuDgv2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles BunifuDgv2.CellFormatting
        BunifuDgv2.DefaultCellStyle.ForeColor = Color.Black
        BunifuDgv2.DefaultCellStyle.SelectionForeColor = Color.Black
        BunifuDgv2.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        BunifuDgv2.Columns(3).DefaultCellStyle.Format = "###,###,###"
        BunifuDgv2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        For i = 0 To BunifuDgv2.RowCount - 1
            If i Mod 2 = 0 Then
                BunifuDgv2.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                BunifuDgv2.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
            End If
        Next

        For i As Integer = 0 To BunifuDgv2.Rows.Count - 1
            If BunifuDgv2.Rows(i).Cells(4).Value.ToString = "PERMINTAAN" Then
                BunifuDgv2.Rows(i).Cells(4).Style.BackColor = Color.Orange
                BunifuDgv2.Rows(i).Cells(4).Style.ForeColor = Color.White
            ElseIf BunifuDgv2.Rows(i).Cells(4).Value.ToString = "DALAM TINDAKAN" Then
                BunifuDgv2.Rows(i).Cells(4).Style.BackColor = Color.Green
                BunifuDgv2.Rows(i).Cells(4).Style.ForeColor = Color.White
            ElseIf BunifuDgv2.Rows(i).Cells(4).Value.ToString = "SELESAI" Then
                BunifuDgv2.Rows(i).Cells(4).Style.BackColor = Color.Red
                BunifuDgv2.Rows(i).Cells(4).Style.ForeColor = Color.White
                'BunifuDgv2.Rows(i).Visible = False
            End If
        Next
    End Sub

    Private Sub txtDokter_TextChanged(sender As Object, e As EventArgs) Handles txtDokter.TextChanged
        Call koneksiServer()

        Try
            Dim query As String
            query = "SELECT kdPetugasMedis FROM t_tenagamedis2 WHERE namapetugasMedis = '" & txtDokter.Text & "'"
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader

            While dr.Read
                txtKdDokter.Text = UCase(dr.GetString("kdPetugasMedis"))
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        conn.Close()
    End Sub

    Private Sub txtCaraBayar_TextChanged(sender As Object, e As EventArgs) Handles txtCaraBayar.TextChanged
        If txtCaraBayar.Text.Equals("JKN", StringComparison.OrdinalIgnoreCase) Or
           txtCaraBayar.Text.Equals("Taspen", StringComparison.OrdinalIgnoreCase) Or
           txtCaraBayar.Text.Equals("BPJS Jamkesmas", StringComparison.OrdinalIgnoreCase) Or
           txtCaraBayar.Text.Equals("KIS", StringComparison.OrdinalIgnoreCase) Or
           txtCaraBayar.Text.Equals("Jamsostek", StringComparison.OrdinalIgnoreCase) Or
            txtCaraBayar.Text.Equals("Kemenkes", StringComparison.OrdinalIgnoreCase) Then
            txtKategori.Text = "JKN"
        ElseIf txtCaraBayar.Text.Equals("UMUM", StringComparison.OrdinalIgnoreCase) Or
               txtCaraBayar.Text.Equals("Lainnya", StringComparison.OrdinalIgnoreCase) Or
               txtCaraBayar.Text.Equals("Asuransi", StringComparison.OrdinalIgnoreCase) Or
               txtCaraBayar.Text.Equals("InHealth", StringComparison.OrdinalIgnoreCase) Then
            txtKategori.Text = "UMUM"
        End If
    End Sub
End Class