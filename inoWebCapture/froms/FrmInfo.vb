
Public NotInheritable Class FrmInfo

    Private Sub FrmInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Legen Sie den Titel des Formulars fest.
        Dim ApplicationTitle As String
        Dim AppVersion As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        If Environment.GetEnvironmentVariable("ClickOnce_IsNetworkDeployed") <> "" Then
            AppVersion = Environment.GetEnvironmentVariable("ClickOnce_CurrentVersion")
        Else
            AppVersion = My.Application.Info.Version.ToString
        End If

        Me.Text = String.Format("Info {0}", ApplicationTitle)
        ' Initialisieren Sie den gesamten Text, der im Infofeld angezeigt wird.
        ' TODO: Die Assemblyinformationen der Anwendung im Bereich "Anwendung" des Dialogfelds für die 
        '    Projekteigenschaften (im Menü "Projekt") anpassen.
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", AppVersion)
        Me.LabelCopyright.Text = String.Format("(c) 2024 {0}", If(Year(Now) = 2024, "", " - " & Year(Now)))
        Me.LabelCompanyName.Text = "INOPIAE GbR" 'My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = My.Application.Info.Description
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

End Class
