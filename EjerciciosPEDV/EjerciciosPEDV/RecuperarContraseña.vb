Imports System.Net
Imports System.Net.Mail

Public Class RecuperarContraseña
    Dim conexion As New conexion()
    Private correos As New MailMessage
    Private envios As New SmtpClient
    Private Sub btnEnviarCorreo_Click(sender As Object, e As EventArgs) Handles btnEnviarCorreo.Click
        mostrarPSW()
        rtxHtml.Text = rtxHtml.Text.Replace("@psw", txtPswMostra.Text)
        enviarCorreo(emisor:=txtCorreo.Text, psw:=txtPswMostra.Text, mensaje:=rtxHtml.Text, asunto:="Recuperar contraseña", destinatario:=txtCorreo.Text, ruta:="")
    End Sub
    Public Sub mostrarPSW()
        Dim correo, psw As String
        Try
            correo = txtCorreo.Text
            If conexion.ConsultarContraseña(correo) Then
                conexion.conexion.Open()
                psw = (conexion.cmb.ExecuteScalar())
                txtPswMostra.Text = psw
                conexion.conexion.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub enviarCorreo(emisor As String, psw As String, mensaje As String, asunto As String, destinatario As String, ruta As String)
        Try
            correos.To.Clear()
            correos.Body = ""
            correos.Subject = ""
            correos.Body = mensaje
            correos.Subject = asunto
            correos.IsBodyHtml = True
            correos.To.Add(Trim(destinatario))
            correos.From = New MailAddress(emisor)
            envios.Credentials = New NetworkCredential(emisor, psw)


            envios.Host = "smtp.gmail.com"
            envios.Port = 587
            envios.EnableSsl = True
            envios.Send(correos)
            MessageBox.Show("Correo enviado", "Revisar Bandeja de entrada")
        Catch ex As Exception
            MessageBox.Show("Correo invalido", "Error")
        End Try
    End Sub
End Class