Public Class RegPasienLuar

    Sub setColor(button As Button)
        btnDash.BackColor = SystemColors.HotTrack
        btnRegLuar.BackColor = SystemColors.HotTrack
        btnBridging.BackColor = SystemColors.HotTrack
        btnTindakan.BackColor = SystemColors.HotTrack
        btnHasil.BackColor = SystemColors.HotTrack
        button.BackColor = Color.DodgerBlue
    End Sub

    Private Sub RegPasienLuar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnRegLuar.BackColor = Color.DodgerBlue
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

    Private Sub btnRegLuar_Click(sender As Object, e As EventArgs) Handles btnRegLuar.Click
        Dim btn As Button = CType(sender, Button)
        setColor(btn)
    End Sub

    Private Sub btnBridging_Click(sender As Object, e As EventArgs) Handles btnBridging.Click
        Dim btn As Button = CType(sender, Button)
        setColor(btn)
    End Sub

    Private Sub btnDaftar_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        setColor(btn)
    End Sub

    Private Sub btnTindakan_Click(sender As Object, e As EventArgs) Handles btnTindakan.Click
        Dim btn As Button = CType(sender, Button)
        setColor(btn)
    End Sub

    Private Sub btnHasil_Click(sender As Object, e As EventArgs) Handles btnHasil.Click
        Dim btn As Button = CType(sender, Button)
        setColor(btn)
    End Sub
End Class