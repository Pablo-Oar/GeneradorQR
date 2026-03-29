Imports ThoughtWorks.QRCode.Codec

Public Class frmGeneradorQR

    Dim qrEcoder As New QRCodeEncoder()
    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click


        qrEcoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE
        qrEcoder.QRCodeScale = 5

        pbQr.Image = qrEcoder.Encode(txtUrl.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Me.txtUrl.Text = String.Empty
        pbQr.Image = Nothing
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click

        If pbQr.Image Is Nothing Then
            MessageBox.Show("Primero debe generar un código QR.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Using saveFileDialog As New SaveFileDialog
            saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp"
            saveFileDialog.Title = "Guardar Imagen"
            saveFileDialog.FileName = "CodigoQR"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                'Guardo la imagen en la ruta seleccionada
                Dim formato As Imaging.ImageFormat = Imaging.ImageFormat.Png
                Select Case IO.Path.GetExtension(saveFileDialog.FileName).ToLower()
                    Case ".jpg"
                        formato = Imaging.ImageFormat.Jpeg
                    Case ".bmp"
                        formato = Imaging.ImageFormat.Bmp
                End Select
                pbQr.Image.Save(saveFileDialog.FileName, formato)
                MessageBox.Show("Imagen guardada exitosamente.", "QRCode.Generator", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End Using
    End Sub

    Private Sub btnLimpiar_MouseHover(sender As Object, e As EventArgs) Handles btnLimpiar.MouseHover
        btnLimpiar.BackColor = SystemColors.InactiveCaption
        btnLimpiar.Font = New Font(btnLimpiar.Font.FontFamily, 12, FontStyle.Bold)
    End Sub

    Private Sub btnLimpiar_MouseLeave(sender As Object, e As EventArgs) Handles btnLimpiar.MouseLeave
        btnLimpiar.BackColor = SystemColors.Control
        btnLimpiar.Font = New Font(btnLimpiar.Font.FontFamily, 10, FontStyle.Bold)
    End Sub

    Private Sub btnExportar_MouseHover(sender As Object, e As EventArgs) Handles btnExportar.MouseHover
        btnExportar.BackColor = SystemColors.InactiveCaption
        btnExportar.Font = New Font(btnExportar.Font.FontFamily, 12, FontStyle.Bold)
    End Sub
    Private Sub btnExportar_MouseLeave(sender As Object, e As EventArgs) Handles btnExportar.MouseLeave
        btnExportar.BackColor = SystemColors.Control
        btnExportar.Font = New Font(btnExportar.Font.FontFamily, 10, FontStyle.Bold)
    End Sub
    Private Sub btnGenerar_MouseHover(sender As Object, e As EventArgs) Handles btnGenerar.MouseHover
        btnGenerar.BackColor = SystemColors.InactiveCaption
        btnGenerar.Font = New Font(btnGenerar.Font.FontFamily, 12, FontStyle.Bold)
    End Sub
    Private Sub btnGenerar_MouseLeave(sender As Object, e As EventArgs) Handles btnGenerar.MouseLeave
        btnGenerar.BackColor = SystemColors.Control
        btnGenerar.Font = New Font(btnGenerar.Font.FontFamily, 10, FontStyle.Bold)
    End Sub

    Private Sub txtUrl_MouseHover(sender As Object, e As EventArgs) Handles txtUrl.MouseHover
        txtUrl.BackColor = SystemColors.GradientActiveCaption
    End Sub
    Private Sub txtUrl_MouseLeave(sender As Object, e As EventArgs) Handles txtUrl.MouseLeave
        txtUrl.BackColor = SystemColors.Control
    End Sub
End Class