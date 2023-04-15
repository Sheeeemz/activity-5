Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Color
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        With Me
            Call Connect_to_DB()
            Dim mycmd As New MySqlCommand
            Try
                strSQL = "Insert into color values('" _
                & .TextDogID.Text & "', '" _
                & .TextDogColor.Text & "')"
                mycmd.CommandText = strSQL
                mycmd.Connection = myconn
                mycmd.ExecuteNonQuery()
                MsgBox("Record Successfully Added")
                Call Clear_Boxes()
            Catch ex As MySqlException
                MsgBox(ex.Number & " " & ex.Message)
            End Try
            Disconnect_to_DB()
        End With
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim dogID As Integer = Integer.Parse(TextDogID.Text)
        Dim dogColor As String = TextDogColor.Text
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to Delete this Record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Try
                Call Connect_to_DB()
                Dim query As String = "DELETE FROM color WHERE color_id = @color_id AND dog_color = @dog_color"
                Dim cmd As New MySqlCommand(query, myconn)
                cmd.Parameters.AddWithValue("@color_id", dogID)
                cmd.Parameters.AddWithValue("@dog_color", dogColor)
                Dim rowsDeleted As Integer = cmd.ExecuteNonQuery()
                If rowsDeleted > 0 Then
                    MessageBox.Show("Record Successfully Deleted")
                    Call Clear_Boxes()
                Else
                    MessageBox.Show("No Matching Record Found")
                End If
            Catch ex As MySqlException
                MessageBox.Show("Error deleting record: " & ex.Message)
            Finally
                Call Disconnect_to_DB()
            End Try
        End If
    End Sub

    Private Sub Clear_Boxes()
        With Me
            .TextDogID.Text = ""
            .TextDogColor.Text = ""
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Landing As New Landing
        Landing.Show()
        Me.Hide() 'Optional: hide the current form
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim dlg As New OpenFileDialog()
        dlg.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
        If dlg.ShowDialog() = DialogResult.OK Then
            'Read the CSV file into a DataTable
            Dim dt As New DataTable()
            Using reader As New StreamReader(dlg.FileName)
                Dim header As Boolean = True
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Dim values As String() = line.Split(","c)
                    If header Then
                        For Each value As String In values
                            dt.Columns.Add(value)
                        Next
                        header = False
                    Else
                        dt.Rows.Add(values)
                    End If
                End While
            End Using

            'Connect to the MySQL database
            Dim connectionString As String = "Server=127.0.0.1;Database=dog_database;Uid=root;Pwd=shemitsme123;"
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                'Insert the data into the MySQL table
                For Each row As DataRow In dt.Rows
                    Dim insertSql As String = "INSERT INTO color ("
                    Dim valuesSql As String = "VALUES ("
                    For Each column As DataColumn In dt.Columns
                        insertSql += "`" + column.ColumnName + "`, "
                        valuesSql += "@" + column.ColumnName + ", "
                    Next
                    insertSql = insertSql.TrimEnd(", ".ToCharArray()) + ")"
                    valuesSql = valuesSql.TrimEnd(", ".ToCharArray()) + ")"
                    Dim insertCommand As New MySqlCommand(insertSql + valuesSql, connection)
                    For Each column As DataColumn In dt.Columns
                        insertCommand.Parameters.AddWithValue("@" + column.ColumnName, row(column))
                    Next
                    insertCommand.ExecuteNonQuery()
                Next

                MessageBox.Show("CSV file imported successfully!")
            End Using
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        'Retrieve the values of each column in the row
        Dim id As Integer = Convert.ToInt32(selectedRow.Cells("color_id").Value)
        Dim color As String = selectedRow.Cells("dog_color").Value.ToString()

        'Display the values in a message box
        MessageBox.Show("Selected row:" & vbCrLf & "DogID: " & id & vbCrLf & "DogColor: " & color)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        'Clear the existing data in the DataGridView
        DataGridView1.DataSource = Nothing

        'Connect to the MySQL database and retrieve the data
        Dim connectionString As String = "Server=127.0.0.1;Database=dog_database;Uid=root;Pwd=shemitsme123;"
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            'Select all rows from the table
            Dim selectSql As String = "SELECT * FROM color"
            Dim selectCommand As New MySqlCommand(selectSql, connection)
            Dim adapter As New MySqlDataAdapter(selectCommand)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            'Bind the DataTable to the DataGridView
            DataGridView1.DataSource = dt
        End Using
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        'Connect to the MySQL database
        Dim connectionString As String = "Server=127.0.0.1;Database=dog_database;Uid=root;Pwd=shemitsme123;"
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            'Select all rows from the table
            Dim selectSql As String = "SELECT * FROM color"
            Dim selectCommand As New MySqlCommand(selectSql, connection)
            Dim adapter As New MySqlDataAdapter(selectCommand)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            'Prompt the user to choose a location to save the CSV file
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv"
            saveFileDialog.Title = "Export CSV file"
            If saveFileDialog.ShowDialog() <> DialogResult.OK Then
                Exit Sub
            End If

            'Write the contents of the DataTable to the CSV file
            Using writer As New StreamWriter(saveFileDialog.FileName)
                'Write the column headers
                For i As Integer = 0 To dt.Columns.Count - 1
                    writer.Write(dt.Columns(i).ColumnName)
                    If i < dt.Columns.Count - 1 Then
                        writer.Write(",")
                    End If
                Next
                writer.WriteLine()

                'Write the data rows
                For Each row As DataRow In dt.Rows
                    For i As Integer = 0 To dt.Columns.Count - 1
                        writer.Write(row(i).ToString())
                        If i < dt.Columns.Count - 1 Then
                            writer.Write(",")
                        End If
                    Next
                    writer.WriteLine()
                Next
            End Using
        End Using

        MessageBox.Show("Export Completed!")
    End Sub
End Class
