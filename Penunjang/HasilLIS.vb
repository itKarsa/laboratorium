Imports MySql.Data.MySqlClient

Public Class HasilLIS

    Sub setColor(button As Button)
        btnDash.BackColor = SystemColors.HotTrack
        btnHasil.BackColor = SystemColors.HotTrack
        button.BackColor = Color.DodgerBlue
    End Sub

    Sub tampilData()
        Dim dt As Date
        dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Dim query As String = ""
        query = "SELECT PID,PNAME,SEX,DATE_FORMAT(DOB,'%d %b %Y') AS DOB,
                        AGEYY,AGEMM,AGEDD,LNO,
                        DATE_FORMAT(REQUEST_DT,'%d/%m/%Y %H.%i') AS REQUEST_DT,
                        DATE_FORMAT(VALIDATE_ON,'%d/%m/%Y %H.%i') AS TGL_SELESAI,
                        VALIDATE_ON,TG_NAME,SOURCE_CD,SOURCE_NM,CLINICIAN_NM 
                   FROM labreshd
                  WHERE STR_TO_DATE(VALIDATE_ON,'%Y%m%d') BETWEEN '" & Format(dt, "yyyy-MM-dd") & "' 
                    AND '" & Format(DateAdd(DateInterval.Day, 1, dt), "yyyy-MM-dd") & "'
               ORDER BY VALIDATE_ON DESC"

        Try
            Call koneksiLis()
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            DataGridView1.Rows.Clear()

            Do While dr.Read
                DataGridView1.Rows.Add(dr.Item("PID"), dr.Item("PNAME"), dr.Item("SEX"), dr.Item("DOB"),
                                       dr.Item("AGEYY"), dr.Item("AGEMM"), dr.Item("AGEDD"), dr.Item("LNO"),
                                       dr.Item("REQUEST_DT"), dr.Item("TGL_SELESAI"), dr.Item("VALIDATE_ON"), dr.Item("TG_NAME"),
                                       dr.Item("SOURCE_CD"), dr.Item("SOURCE_NM"), dr.Item("CLINICIAN_NM"))
            Loop

            dr.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Sub CariData()
        Dim query As String = ""
        query = "SELECT PID,PNAME,SEX,DATE_FORMAT(DOB,'%d %b %Y') AS DOB,
                        AGEYY,AGEMM,AGEDD,LNO,
                        DATE_FORMAT(REQUEST_DT,'%d/%m/%Y %H.%i') AS REQUEST_DT,
                        DATE_FORMAT(VALIDATE_ON,'%d/%m/%Y %H.%i') AS TGL_SELESAI,
                        VALIDATE_ON,TG_NAME,SOURCE_CD,SOURCE_NM,CLINICIAN_NM 
                   FROM labreshd
                  WHERE STR_TO_DATE(VALIDATE_ON,'%Y%m%d') BETWEEN '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' 
                    AND '" & Format(DateAdd(DateInterval.Day, 1, DateTimePicker2.Value), "yyyy-MM-dd") & "'
               ORDER BY VALIDATE_ON DESC"

        Try
            Call koneksiLis()
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            DataGridView1.Rows.Clear()

            Do While dr.Read
                DataGridView1.Rows.Add(dr.Item("PID"), dr.Item("PNAME"), dr.Item("SEX"), dr.Item("DOB"),
                                       dr.Item("AGEYY"), dr.Item("AGEMM"), dr.Item("AGEDD"), dr.Item("LNO"),
                                       dr.Item("REQUEST_DT"), dr.Item("TGL_SELESAI"), dr.Item("VALIDATE_ON"), dr.Item("TG_NAME"),
                                       dr.Item("SOURCE_CD"), dr.Item("SOURCE_NM"), dr.Item("CLINICIAN_NM"))
            Loop

            dr.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Sub CariPasien()
        Dim query As String = ""
        query = "SELECT PID,PNAME,SEX,DATE_FORMAT(DOB,'%d %b %Y') AS DOB,
                        AGEYY,AGEMM,AGEDD,LNO,
                        DATE_FORMAT(REQUEST_DT,'%d/%m/%Y %H.%i') AS REQUEST_DT,
                        DATE_FORMAT(VALIDATE_ON,'%d/%m/%Y %H.%i') AS TGL_SELESAI,
                        VALIDATE_ON,TG_NAME,SOURCE_CD,SOURCE_NM,CLINICIAN_NM 
                   FROM labreshd
                  WHERE (PNAME LIKE '%" & txtNama.Text & "%' OR PID LIKE '%" & txtNama.Text & "%')
               ORDER BY VALIDATE_ON DESC"

        Try
            Call koneksiLis()
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            DataGridView1.Rows.Clear()

            Do While dr.Read
                DataGridView1.Rows.Add(dr.Item("PID"), dr.Item("PNAME"), dr.Item("SEX"), dr.Item("DOB"),
                                       dr.Item("AGEYY"), dr.Item("AGEMM"), dr.Item("AGEDD"), dr.Item("LNO"),
                                       dr.Item("REQUEST_DT"), dr.Item("TGL_SELESAI"), dr.Item("VALIDATE_ON"), dr.Item("TG_NAME"),
                                       dr.Item("SOURCE_CD"), dr.Item("SOURCE_NM"), dr.Item("CLINICIAN_NM"))
            Loop

            dr.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub HasilLIS_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Normal
        Me.StartPosition = FormStartPosition.Manual
        With Screen.PrimaryScreen.WorkingArea
            Me.SetBounds(.Left, .Top, .Width, .Height)
        End With

        pnlStats.Height = btnHasil.Height
        pnlStats.Top = btnHasil.Top
        btnHasil.BackColor = Color.DodgerBlue

        tampilData()
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

    Private Sub btnBridging_Click(sender As Object, e As EventArgs) Handles btnHasil.Click
        pnlStats.Height = btnHasil.Height
        pnlStats.Top = btnHasil.Top

        Dim btn As Button = CType(sender, Button)
        setColor(btn)
    End Sub

    Private Sub btnHasil_Click(sender As Object, e As EventArgs)
        pnlStats.Height = btnHasil.Height
        pnlStats.Top = btnHasil.Top

        Dim btn As Button = CType(sender, Button)
        setColor(btn)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim konfirmasi As MsgBoxResult
        Dim nama As String
        Dim PID, LNO, SOURCE_CD As String
        Dim kdruang As String

        If e.RowIndex = -1 Then
            Return
        End If

        nama = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
        PID = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
        LNO = DataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString
        SOURCE_CD = DataGridView1.Rows(e.RowIndex).Cells(12).Value.ToString

        txtPID.Text = PID
        txtLNO.Text = LNO
        'kdruang = SOURCE_CD.Substring(0, 4)

        'namaRuang(kdruang)

        If e.ColumnIndex = 15 Then
            ViewCetakLIS.Ambil_Data = True
            ViewCetakLIS.Form_Ambil_Data = "CetakLis"
            ViewCetakLIS.Show()
        End If
    End Sub

    Sub namaRuang(kode As String)
        Select Case kode
            Case 2001
                txtSourceNm.Text = "Matahari"
            Case 2002
                txtSourceNm.Text = "Teratai"
            Case 2003
                txtSourceNm.Text = "Mawar"
            Case 2004
                txtSourceNm.Text = "Krisan"
            Case 2005
                txtSourceNm.Text = "Kemuning"
            Case 2006
                txtSourceNm.Text = "Seruni"
            Case 2007
                txtSourceNm.Text = "Anggrek (Unit Stroke)"
            Case 2008
                txtSourceNm.Text = "ICU"
            Case 2009
                txtSourceNm.Text = "Perinatologi"
            Case 1001
                txtSourceNm.Text = "Dalam"
            Case 1002
                txtSourceNm.Text = "Bedah"
            Case 1003
                txtSourceNm.Text = "Kandungan"
            Case 1004
                txtSourceNm.Text = "Anak"
            Case 1005
                txtSourceNm.Text = "Syaraf"
            Case 1006
                txtSourceNm.Text = "Paru"
            Case 1007
                txtSourceNm.Text = "Mata"
            Case 1008
                txtSourceNm.Text = "THT"
            Case 1009
                txtSourceNm.Text = "Gigi dan Orthodonti"
            Case 1010
                txtSourceNm.Text = "Orthopedi"
            Case 1011
                txtSourceNm.Text = "Jantung"
            Case 1012
                txtSourceNm.Text = "Bedah Digestif"
            Case 1013
                txtSourceNm.Text = "Bedah Plastik"
            Case 1014
                txtSourceNm.Text = "Syaraf"
            Case 1015
                txtSourceNm.Text = "Diabetes Melitus"
            Case 1016
                txtSourceNm.Text = "Kulit dan Kelamin"
            Case 1017
                txtSourceNm.Text = "Komplementer"
            Case 1018
                txtSourceNm.Text = "Anastesi"
            Case 1019
                txtSourceNm.Text = "VCT"
            Case 4001
                txtSourceNm.Text = "IGD"
        End Select
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Call CariData()
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 11, FontStyle.Bold)
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.DefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Bold)
        DataGridView1.DefaultCellStyle.ForeColor = Color.Black
        DataGridView1.DefaultCellStyle.SelectionForeColor = Color.White

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If i Mod 2 = 0 Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
            Else
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
            End If
        Next

        For i = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows(i).Cells(15).Style.BackColor = Color.DodgerBlue
            DataGridView1.Rows(i).Cells(15).Style.ForeColor = Color.White
        Next
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call tampilData()
    End Sub

    Private Sub btnCariPasien_Click(sender As Object, e As EventArgs) Handles btnCariPasien.Click
        If txtNama.Text = "" Then
            MsgBox("Masukkan Nama Pasien / No. RM", MsgBoxStyle.Information)
        Else
            Call CariPasien()
        End If
    End Sub

    Private Sub txtNama_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNama.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtNama.Text = "" Then
                MsgBox("Masukkan Nama Pasien / No. RM", MsgBoxStyle.Information)
            Else
                Call CariPasien()
            End If
        End If
    End Sub
End Class