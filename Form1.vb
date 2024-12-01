Imports MySql.Data.MySqlClient

Public Class Form1
    ' Database connection string
    Private connectionString As String = "server=localhost;user id=root;password=;database=fitcheck;"

    ' Form Load Event
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the password character for txtPassword
        txtPassword.PasswordChar = "•"c

        ' Set properties for Guna2PictureBox controls
        Guna2PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        Guna2PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage

    End Sub

    ' Exit button click event
    Private Sub Guna2PictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox2.Click
        ' Close the application when the Exit button is clicked
        Me.Close()
    End Sub

    ' Maximize button click event
    Private Sub Guna2PictureBox3_Click(sender As Object, e As EventArgs)

    End Sub


    ' Login button click event
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Validate user inputs
        If Not ValidateInputs() Then
            Return
        End If

        Dim email As String = txtEmail.Text
        Dim password As String = txtPassword.Text

        If Not CheckAccountExists(email, password) Then
            MessageBox.Show("Account doesn't exist or invalid credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If Not IsFLS1Completed(email) Then
                ' Redirect to FLS1 form
                Dim fls1Form As New FLS1()
                fls1Form.Show()
                Me.Hide()
            ElseIf Not IsFLS2Completed(email) Then
                ' Redirect to FLS2 form
                Dim fls2Form As New FLS2()
                fls2Form.Show()
                Me.Hide()
            Else
                ' Redirect to Homepage
                Dim homepage As New FLS2()
                homepage.Show()
                Me.Hide()
            End If
        End If
    End Sub

    ' Validate user inputs
    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtEmail.Text) Then
            MessageBox.Show("Username cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Email cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

    ' Check if the account exists in the database
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

        ' If no password is found, the account doesn't exist
        If String.IsNullOrEmpty(hashedPassword) Then
            Return False
        End If

        ' Verify the entered password with the stored hashed password
        Return BCrypt.Net.BCrypt.Verify(password, hashedPassword)
    End Function

    ' Check if FLS1 is completed
    Private Function IsFLS1Completed(email As String) As Boolean
        Using connection As New MySqlConnection(connectionString)
            connection.Open()
            Dim query As String = "SELECT FLS1Status FROM users WHERE Email = @Email"
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Email", email)
                Dim fls1Status As Boolean = Convert.ToBoolean(command.ExecuteScalar())
                Return fls1Status
            End Using
        End Using
    End Function

    ' Check if FLS2 is completed
    Private Function IsFLS2Completed(email As String) As Boolean
        Using connection As New MySqlConnection(connectionString)
            connection.Open()
            Dim query As String = "SELECT FLS2Status FROM users WHERE Email = @Email"
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Email", email)
                Dim fls2Status As Boolean = Convert.ToBoolean(command.ExecuteScalar())
                Return fls2Status
            End Using
        End Using
    End Function

    ' Sign up click event
    Private Sub lblSignUp_Click(sender As Object, e As EventArgs) Handles lblSignUp.Click
        Dim creationOfAccountForm As New CreationOfAccount()
        creationOfAccountForm.Show()
        Me.Hide()
    End Sub

    ' Show password checkbox changed
    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            txtPassword.PasswordChar = ControlChars.NullChar
        Else
            txtPassword.PasswordChar = "•"c
        End If
    End Sub

    Private Sub Guna2PictureBox3_Click_1(sender As Object, e As EventArgs) Handles Guna2PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class
