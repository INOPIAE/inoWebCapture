Imports System.ComponentModel
Imports System.IO

Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.Web.WebView2.Core

Public Class FrmWeb

    Private url() As String
    Private pUrl As Integer = -1
    Private pPic As String
    Private pStart As Boolean
    Private pPicName As String
    Public pFile As String
    Private blnAddUrl As Boolean
    Private pPicTotal As Integer



    Private WithEvents WView As Microsoft.Web.WebView2.WinForms.WebView2
    Private Sub CmdBrowse_Click(sender As Object, e As EventArgs) Handles CmdBrowse.Click
        BrowseToUrl()
    End Sub

    Private Sub BrowseToUrl()
        Try
            WView.CoreWebView2.Navigate(TxtUrl.Text)
        Catch ex As Exception
            MessageBox.Show("Error WebView: " & ex.Message)
        End Try
    End Sub

    Private Sub CmdPicture_Click(sender As Object, e As EventArgs) Handles CmdPicture.Click
        'Dim currentScreen = Screen.FromHandle(Me.Handle).WorkingArea

        ''create a bitmap of the working area
        'Using bmp As New Bitmap(currentScreen.Width, currentScreen.Height)

        '    'copy the screen to the image
        '    Using g = Graphics.FromImage(bmp)
        '        g.CopyFromScreen(New Point(0, 0), New Point(0, 0), currentScreen.Size)
        '    End Using

        '    'save the image
        '    Using sfd As New SaveFileDialog() With {.Filter = "PNG Image|*.png",
        '                                            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop}

        '        If sfd.ShowDialog() = DialogResult.OK Then
        '            bmp.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png)
        '        End If
        '    End Using
        'End Using
    End Sub


    Dim cropX As Integer
    Dim cropY As Integer
    Dim cropWidth As Integer
    Dim cropHeight As Integer

    Dim cropBitmap As Bitmap
    Private Sub CmdCrop_Click(sender As Object, e As EventArgs) Handles CmdCrop.Click
        pPic = ""
        ScreenCopy()
    End Sub

    Private Sub ScreenCopy()
        Dim currentScreen = Screen.FromHandle(Me.Handle).WorkingArea

        'create a bitmap of the working area
        Using bmp As New Bitmap(currentScreen.Width, currentScreen.Height)

            'copy the screen to the image
            Using g = Graphics.FromImage(bmp)
                g.CopyFromScreen(New Point(0, 0), New Point(0, 0), currentScreen.Size)
            End Using

            cropX = TxtX.Text
            cropY = TxtY.Text
            cropWidth = TxtW.Text
            cropHeight = TxtH.Text

            Dim rect As Rectangle = New Rectangle(cropX, cropY, cropWidth, cropHeight)


            cropBitmap = New Bitmap(cropWidth, cropHeight)
            Dim g1 As Graphics = Graphics.FromImage(cropBitmap)
            g1.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g1.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            g1.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            g1.DrawImage(bmp, 0, 0, rect, GraphicsUnit.Pixel)


            'save the image
            If pPic = "" Then
                Using sfd As New SaveFileDialog() With {.Filter = "PNG Image|*.png",
                                                    .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop}

                    If sfd.ShowDialog() = DialogResult.OK Then
                        cropBitmap.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png)
                    End If
                End Using
            Else
                cropBitmap.Save(pPic, System.Drawing.Imaging.ImageFormat.Png)
            End If
        End Using
    End Sub

    Private Sub CmdGetUrl_Click(sender As Object, e As EventArgs) Handles CmdGetUrl.Click
        TxtUrl.Text = WView.Source.ToString()
        blnAddUrl = True
    End Sub

    Private Async Sub FrmWeb_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            TxtX.Text = My.Settings.LastX
            TxtY.Text = My.Settings.LastY
            TxtW.Text = My.Settings.LastWidth
            TxtH.Text = My.Settings.LastHeight
            TxtBildName.Text = My.Settings.LastPicName
            TxtBildPfad.Text = My.Settings.LastPicPath
            ChkAuto.Checked = My.Settings.PicAuto
            NudDuration.Value = My.Settings.PicDuration
            pFile = My.Settings.LastPicFile
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        LblInfo.Text = ""
        LblFile.Text = String.Format("Konfigurationsdatei: {0}", pFile)


        WView = New Microsoft.Web.WebView2.WinForms.WebView2()
        WView.Dock = DockStyle.Fill
        Me.SpBrowser.Panel2.Controls.Add(WView)

        ' Ensure CoreWebView2 is initialized before navigating
        Await WView.EnsureCoreWebView2Async(Nothing)

        Try
            If WView.CoreWebView2 IsNot Nothing Then
                If My.Settings.LastUrl = "" Then
                    WView.CoreWebView2.Navigate("https://app.powerbi.com")
                Else
                    TxtUrl.Text = My.Settings.LastUrl
                    WView.CoreWebView2.Navigate(TxtUrl.Text)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error WebView: " & ex.Message)
        End Try
        pStart = True

        TtpTool.SetToolTip(TxtX, "Position der linken oberen Ecke des Screenshotbereiches von LINKS")
        TtpTool.SetToolTip(TxtY, "Position der linken oberen Ecke des Screenshotbereiches von OBEN")

        TtpTool.SetToolTip(CmdGetUrl, "Übernimmt die URL der aktuellen Seite in URL")
        TtpTool.SetToolTip(CmdBrowse, "Lädt die Seite aus URL")
        TtpTool.SetToolTip(CmdCrop, "Erstellt einen einzelen Screenshot und speichert in ab")
        TtpTool.SetToolTip(CmdAuto, "Wenn automatisch ausgewählt wurde, " _
                           & vbCrLf & "werden die Screenshots automatisch in der vorgegeben Zeit erstellt." _
                           & vbCrLf & "Ansonsten wird mit jedem Klick das nächste Bild verwendet.")


        ' Additional customizations for the ToolTip (optional)
        'TtpTool.ToolTipTitle = "Helpful Information"
        'TtpTool.IsBalloon = True ' Make it appear as a balloon-style tooltip
        TtpTool.AutoPopDelay = 5000 ' Tooltip stays for 5 seconds
        TtpTool.InitialDelay = 1000 ' Delay before showing the tooltip (1 second)
        TtpTool.ReshowDelay = 500 ' Delay before showing the tooltip again (after it's hidden)

        CmdAuto.Text = "Screenshots mit Datei"

    End Sub

    Private Sub FrmWeb_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.LastX = TxtX.Text
        My.Settings.LastY = TxtY.Text
        My.Settings.LastWidth = TxtW.Text
        My.Settings.LastHeight = TxtH.Text
        My.Settings.LastPicName = TxtBildName.Text
        My.Settings.LastPicPath = TxtBildPfad.Text
        My.Settings.LastPicFile = pFile
        My.Settings.PicAuto = ChkAuto.Checked
        My.Settings.PicDuration = NudDuration.Value


        My.Settings.LastUrl = TxtUrl.Text

        My.Settings.Save()
    End Sub

    Private Sub CmdAuto_Click(sender As Object, e As EventArgs) Handles CmdAuto.Click

        If Directory.Exists(TxtBildPfad.Text) = False Then
            MessageBox.Show("Speicherpfad nicht angegeben")
            Exit Sub
        Else
            pPicName = Path.Combine(TxtBildPfad.Text & "\", TxtBildName.Text)
            pPicName = pPicName.Replace("\\", "\")
        End If

        url = File.ReadAllLines(pFile)
        pPicTotal = url.Length

        LblInfo.Text = "Erste Seite wird geladen"
        If ChkAuto.Checked = False Then
            If pStart = True Then
                pUrl = 0
                TxtUrl.Text = url(pUrl)
                BrowseToUrl()
                CmdAuto.Text = "Nächstes Bild"
                pStart = False
            Else
                pPic = pPicName & pUrl + 1 & ".png"
                LblInfo.Text = String.Format("Bild {0} von {1}", pUrl + 1, pPicTotal)

                ScreenCopy()

                pUrl += 1
                If pUrl = url.Length Then
                    pStart = True
                    MessageBox.Show("Am Ende der Liste angekommen")
                    CmdAuto.Text = "Screenshots mit Datei"
                Else
                    TxtUrl.Text = url(pUrl)
                    BrowseToUrl()
                End If
            End If
        Else
            pUrl = 0
            Application.DoEvents()
            For z As Integer = 0 To url.Length - 1


                TxtUrl.Text = url(z)
                BrowseToUrl()
                Application.DoEvents()
                pPic = pPicName & pUrl + 1 & ".png"
                System.Threading.Thread.Sleep(NudDuration.Value * 1000)
                LblInfo.Text = String.Format("Bild {0} von {1}", pUrl + 1, pPicTotal)
                Application.DoEvents()
                ScreenCopy()
                pUrl += 1
            Next
            LblInfo.Text = "fertig"
        End If


    End Sub

    Private Sub CmdPicDatei_Click(sender As Object, e As EventArgs) Handles CmdPicDatei.Click
        FrmConfigFile.ShowDialog()
        LblFile.Text = String.Format("Konfigurationsdatei:{0}", pFile)
    End Sub

    Private Sub CmdAddPic_Click(sender As Object, e As EventArgs) Handles CmdAddPic.Click
        If blnAddUrl = False Then
            MessageBox.Show("Es wurde noch keine URL ausgewählt")
            Exit Sub
        End If
        Try
            ' Use StreamWriter to append to the file
            Using writer As New StreamWriter(pFile, True)
                writer.WriteLine(TxtUrl.Text)
            End Using

            ' Notify user
            MessageBox.Show("Line added successfully!")
        Catch ex As Exception
            ' Handle any errors (e.g., file not found or permission issues)
            MessageBox.Show("Error: " & ex.Message)
        End Try
        blnAddUrl = False
    End Sub

    Private Sub CmdClose_Click(sender As Object, e As EventArgs) Handles CmdClose.Click
        Me.Close()
    End Sub

    Private Sub CmdInfo_Click(sender As Object, e As EventArgs) Handles CmdInfo.Click
        FrmInfo.ShowDialog()
    End Sub

    Private Sub CmdPicPath_Click(sender As Object, e As EventArgs) Handles CmdPicPath.Click
        Dim folderDialog As New FolderBrowserDialog()

        If folderDialog.ShowDialog() = DialogResult.OK Then
            ' Get the selected folder path
            Dim selectedFolderPath As String = folderDialog.SelectedPath

            ' Display the selected folder path (you can use this path as needed)
            'MessageBox.Show("You selected the folder: " & selectedFolderPath)
            TxtBildPfad.Text = selectedFolderPath
        Else
            MessageBox.Show("No folder selected.")
        End If
    End Sub

End Class