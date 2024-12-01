Public Class Form1
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        Dim nextForm As New Form8()
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2HtmlLabel1_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel1.Click


    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtEmail.Text) Then
            MessageBox.Show("Email cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

    Private Function CheckAccountExists(email As String, password As String) As Boolean
        Dim hashedPassword As String = ""
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Retrieve the hashed password for the email
            Dim query As String = "SELECT Password FROM users WHERE Email = @Email"
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Email", email)
                hashedPassword = Convert.ToString(command.ExecuteScalar())
            End Using
        End Using


    Private Sub Guna2HtmlLabel3_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel3.Click

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim nextForm As New Form2()
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Dim nextForm As New Form3()
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Dim nextForm As New Form4()
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Dim nextForm As New Form5()
        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        Me.Close()
    End Sub
    
End Class
