Public Class Form2
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static iCount As Integer
        If iCount = 50 Then
            iCount = 0
            Me.Dispose()
            Form1.Dispose()
        Else
            iCount = iCount + 1
        End If
    End Sub

    Private Sub Form2_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
        Form1.Dispose()
    End Sub
End Class