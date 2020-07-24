Public Class Login

    Dim conexion As New conexion()


        Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
            txtPsw.Text = txtPsw.Text & "1"
        End Sub

        Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
            txtPsw.Text = txtPsw.Text & "2"
        End Sub

        Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
            txtPsw.Text = txtPsw.Text & "3"
        End Sub

        Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
            txtPsw.Text = txtPsw.Text & "4"
        End Sub

        Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
            txtPsw.Text = txtPsw.Text & "5"
        End Sub

        Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
            txtPsw.Text = txtPsw.Text & "6"
        End Sub

        Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
            txtPsw.Text = txtPsw.Text & "7"
        End Sub

        Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
            txtPsw.Text = txtPsw.Text & "8"
        End Sub

        Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
            txtPsw.Text = txtPsw.Text & "9"
        End Sub

        Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
            txtPsw.Text = txtPsw.Text & "0"
        End Sub

        Private Sub btnborrartodo_Click(sender As Object, e As EventArgs) Handles btnborrartodo.Click
            txtPsw.Clear()
        End Sub



        Private Sub OptVer_Click(sender As Object, e As EventArgs) Handles OptVer.Click
            txtPsw.PasswordChar = ""
            optOcultar.Visible = True
            OptVer.Visible = False
        End Sub

        Private Sub optOcultar_Click(sender As Object, e As EventArgs) Handles optOcultar.Click
            txtPsw.PasswordChar = "*"
            optOcultar.Visible = False
            OptVer.Visible = True
        End Sub

        Private Sub ingresarMenu()
            Dim userName, psw As String
            userName = txtUsuario.Text
            psw = txtPsw.Text
            Try
                If conexion.validarUsuario(userName, psw) Then
                    MsgBox("Correcto")
                Usuarios.Show()
                Me.Hide()
                Else
                    MsgBox("Usuario/Contraseña invalido")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Private Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click
            ingresarMenu()
        End Sub

        Private Sub btnborrarderecha_Click(sender As Object, e As EventArgs) Handles btnborrarderecha.Click
            Dim longitud As Integer
            If txtPsw.Text <> "" Then
                longitud = txtPsw.Text.Length
                txtPsw.Text = Mid(txtPsw.Text, 1, longitud - 1)
            End If
        End Sub

End Class
