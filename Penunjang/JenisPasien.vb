Public Class JenisPasien
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
        Tambah_Pasien.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("Maaf masih dalam pengembangan ..", MsgBoxStyle.Information)
        'Me.Dispose()
        'TambahPasienLuar.ShowDialog()
    End Sub

    Private Sub JenisPasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class