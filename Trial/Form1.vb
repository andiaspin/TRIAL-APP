Public Class Form1
    Dim Win32MnClass As System.Management.ManagementClass
    Dim processors As System.Management.ManagementObjectCollection
    Dim Enkrip, Output, Inputan, hasilenkripsi, prosesor As String
    Dim Panjang_Input As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Win32MnClass = New System.Management.ManagementClass("Win32_Processor")
        processors = Win32MnClass.GetInstances()
        For Each processor As System.Management.ManagementObject In processors
            prosesor = (processor("ProcessorID").ToString())
            TextBox1.Text = prosesor
        Next
        Inputan = prosesor
        Panjang_Input = Len(Inputan)

        For i = 1 To Panjang_Input
            Enkrip = Mid(Inputan, i, 1)
            Enkrip = Asc(Enkrip)
            Enkrip = (Enkrip + 20) - 43
            Enkrip = Chr(Enkrip)
            Output = Output & Enkrip
        Next i
        hasilenkripsi = Output

        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\" + hasilenkripsi, "Andi", "Aspin") Is Nothing Then

            MessageBox.Show("Kode Aktivasi Tidak Terdeteksi", "Perhatian !!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Me.Hide()
            Form2.Timer1.Enabled = False
            Form2.ShowDialog()
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Visible = False
        Form2.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox2.Text = hasilenkripsi Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\" + hasilenkripsi, "Andi", "Aspin")
            MessageBox.Show("Kode Aktivasi Benar", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Visible = False
            Form2.Timer1.Enabled = False
            Form2.ShowDialog()
        Else
            MsgBox("Kode Aktivasi Salah", MsgBoxStyle.Exclamation)
        End If

    End Sub
End Class
