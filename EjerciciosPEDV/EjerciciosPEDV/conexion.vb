﻿Imports System.Data.SqlClient
Public Class conexion
    Public conexion As SqlConnection = New SqlConnection("Data Source=HECTOROS\SQLEXPRESS02;Initial Catalog=TiendaIIIPHOC;Integrated Security=True")
    Public ds As DataSet = New DataSet()
    Public da As SqlDataAdapter
    Public cmb As SqlCommand
    Public dr As SqlDataReader

    Public Sub conectar()
        Try
            conexion.Open()
            MessageBox.Show("Conectado con exito")
        Catch ex As Exception
            MessageBox.Show("No se ha podido acceder a la base de datos")
        Finally
            conexion.Close()
        End Try
    End Sub

    Public Function insertarUsuario(idUsuario As Integer, nombre As String, apellido As String, userName As String,
                                    psw As String, rol As String, estado As String, correo As String)
        Try
            conexion.Open()
            cmb = New SqlCommand("insertarUsuario", conexion)
            cmb.CommandType = CommandType.StoredProcedure
            cmb.Parameters.AddWithValue("@idUsuario", idUsuario)
            cmb.Parameters.AddWithValue("@nombre", nombre)
            cmb.Parameters.AddWithValue("@apellido", apellido)
            cmb.Parameters.AddWithValue("@userName", userName)
            cmb.Parameters.AddWithValue("@psw", psw)
            cmb.Parameters.AddWithValue("@rol", rol)
            cmb.Parameters.AddWithValue("@estado", estado)
            cmb.Parameters.AddWithValue("@correo", correo)
            If cmb.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function eliminarUsuario(idUsuario As Integer, rol As String)
        Try
            conexion.Open()
            cmb = New SqlCommand("eliminarUsuario", conexion)
            cmb.CommandType = CommandType.StoredProcedure
            cmb.Parameters.AddWithValue("@idUsuario", idUsuario)
            cmb.Parameters.AddWithValue("@rol", rol)
            If cmb.ExecuteNonQuery <> 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function BuscarUsuario(idUsuario As Integer)
        Try
            conexion.Open()
            cmb = New SqlCommand("BuscarUsuario", conexion)
            cmb.CommandType = CommandType.StoredProcedure
            cmb.Parameters.AddWithValue("@idUsuario", idUsuario)

            If cmb.ExecuteNonQuery <> 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function modificarUsuario(idUsuario As Integer, nombre As String, apellido As String, userName As String,
                                psw As String, rol As String, estado As String, correo As String)
        Try
            conexion.Open()
            cmb = New SqlCommand("modificarUsuario", conexion)
            cmb.CommandType = CommandType.StoredProcedure
            cmb.Parameters.AddWithValue("@idUsuario", idUsuario)
            cmb.Parameters.AddWithValue("@nombre", nombre)
            cmb.Parameters.AddWithValue("@apellido", apellido)
            cmb.Parameters.AddWithValue("@userName", userName)
            cmb.Parameters.AddWithValue("@psw", psw)
            cmb.Parameters.AddWithValue("@rol", rol)
            cmb.Parameters.AddWithValue("@estado", estado)
            cmb.Parameters.AddWithValue("@correo", correo)
            If cmb.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function

End Class

