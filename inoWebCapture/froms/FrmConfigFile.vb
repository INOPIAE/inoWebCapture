Public Class FrmConfigFile
    Private Sub CmdLoad_Click(sender As Object, e As EventArgs) Handles CmdLoad.Click
        Dim openFileDialog As New OpenFileDialog()

        With openFileDialog

            .Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*" ' Filter file types
            .FilterIndex = 1 ' Default filter
            .RestoreDirectory = True ' Restore the previous directory if possible
            .Multiselect = False
            .Title = "Bestehende Konfiguationsdatei auswählen"

            ' Show the dialog and check if the user selected a file
            If .ShowDialog() = DialogResult.OK Then
                ' Get the file path of the selected file
                Dim filePath As String = .FileName
                FrmWeb.pFile = filePath
            End If
        End With
        Me.Close()
    End Sub

    Private Sub CmdNew_Click(sender As Object, e As EventArgs) Handles CmdNew.Click
        Dim saveFileDialog As New SaveFileDialog()

        With saveFileDialog

            .Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*" ' Filter file types
            .FilterIndex = 1 ' Default filter
            .RestoreDirectory = True ' Restore the previous directory if possible
            .Title = "Neue Konfigurationsdatei erstellen"

            ' Show the dialog and check if the user selected a file
            If .ShowDialog() = DialogResult.OK Then
                ' Get the file path of the selected file
                Dim filePath As String = .FileName
                FrmWeb.pFile = filePath
            End If
        End With
        Me.Close()
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        Me.Close()
    End Sub
End Class