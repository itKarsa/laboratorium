Imports MySql.Data.MySqlClient
Public Class RekapPemeriksaan

    Sub setColor(button As Button)
        btnDash.BackColor = SystemColors.HotTrack
        btnRekap.BackColor = SystemColors.HotTrack
        button.BackColor = Color.DodgerBlue
    End Sub

    Sub tampilData()
        Dim dt As Date
        dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Dim query As String = ""
        query = "SELECT
	                    DATE_FORMAT(a.Date,'%d-%m-%Y') AS Date,
	                    SUBSTR(tkt.kelompokTindakan,24,35) AS keltindakan,
	                    tt.tindakan AS tindakan,
	                    ( SELECT count(tindakan) FROM vw_pasienlaboratoriumdetail WHERE tindakan = tt.tindakan AND LEFT(tglMasukPenunjangRajal,10) 	= a.Date ) AS jml
                    FROM
	                    (SELECT
		                    last_day('" & Format(dt, "yyyy-MM-dd") & "') - INTERVAL (a.a + ( 10 * b.a) + (100 * c.a)) DAY AS Date 
	                    FROM
		                    (SELECT 0 AS a UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9) AS a
		                    CROSS JOIN 
		                    (SELECT 0 AS a UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9) AS b
		                    CROSS JOIN 
		                    (SELECT 0 AS a UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9) AS c
	                    ) a, t_tindakan2 tt 
	                    INNER JOIN t_kelompoktindakan tkt ON tt.kdKelompokTindakan = tkt.kdKelompokTindakan
	                    LEFT JOIN vw_pasienlaboratoriumdetail pld ON tt.tindakan=pld.tindakan
                    WHERE
	                    (tt.kdKelompokTindakan BETWEEN '15' AND '24') 
	                    AND a.Date between '" & Format(dt, "yyyy-MM-dd") & "' AND '" & Format(DateAdd(DateInterval.Day, 1, dt), "yyyy-MM-dd") & "'
                    GROUP BY
	                    a.Date,tindakan
                    ORDER BY
	                    a.Date, tkt.kdKelompokTindakan ASC"

        Try
            Call koneksiServer()
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            DataGridView1.Rows.Clear()

            Do While dr.Read
                DataGridView1.Rows.Add(dr.Item("Date"), dr.Item("keltindakan"), dr.Item("tindakan"), dr.Item("jml"))
            Loop

            dr.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Sub cariData()
        Dim dt As Date
        dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Dim query As String = ""
        query = "SELECT
	                    DATE_FORMAT(a.Date,'%d-%m-%Y') AS Date,
	                    SUBSTR(tkt.kelompokTindakan,24,35) AS keltindakan,
	                    tt.tindakan AS tindakan,
	                    ( SELECT count(tindakan) FROM vw_pasienlaboratoriumdetail WHERE tindakan = tt.tindakan AND LEFT(tglMasukPenunjangRajal,10) 	= a.Date ) AS jml
                    FROM
	                    (SELECT
		                    last_day('" & Format(DateAdd(DateInterval.Day, 1, DateTimePicker2.Value), "yyyy-MM-dd") & "') - INTERVAL (a.a + ( 10 * b.a) + (100 * c.a)) DAY AS Date 
	                    FROM
		                    (SELECT 0 AS a UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9) AS a
		                    CROSS JOIN 
		                    (SELECT 0 AS a UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9) AS b
		                    CROSS JOIN 
		                    (SELECT 0 AS a UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9) AS c
	                    ) a, t_tindakan2 tt 
	                    INNER JOIN t_kelompoktindakan tkt ON tt.kdKelompokTindakan = tkt.kdKelompokTindakan
	                    LEFT JOIN vw_pasienlaboratoriumdetail pld ON tt.tindakan=pld.tindakan
                    WHERE
	                    (tt.kdKelompokTindakan BETWEEN '15' AND '24') 
	                    AND a.Date between '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' AND '" & Format(DateAdd(DateInterval.Day, 1, DateTimePicker2.Value), "yyyy-MM-dd") & "'
                    GROUP BY
	                    a.Date,tindakan
                    ORDER BY
	                    a.Date, tkt.kdKelompokTindakan ASC"

        Try
            Call koneksiServer()
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            DataGridView1.Rows.Clear()

            Do While dr.Read
                DataGridView1.Rows.Add(dr.Item("Date"), dr.Item("keltindakan"), dr.Item("tindakan"), dr.Item("jml"))
            Loop

            dr.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub RekapPemeriksaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlStats.Height = btnRekap.Height
        pnlStats.Top = btnRekap.Top
        btnRekap.BackColor = Color.DodgerBlue

        Call tampilData()
    End Sub

    Private Sub btnDash_Click(sender As Object, e As EventArgs) Handles btnDash.Click
        Form1.pnlStats.Height = Form1.btnDash.Height
        Form1.pnlStats.Top = Form1.btnDash.Top
        Form1.btnDash.BackColor = Color.DodgerBlue
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Form1.Show()
        Form1.pnlStats.Height = Form1.btnDash.Height
        Form1.pnlStats.Top = Form1.btnDash.Top
        Me.Close()
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Call cariData()
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
    End Sub
End Class