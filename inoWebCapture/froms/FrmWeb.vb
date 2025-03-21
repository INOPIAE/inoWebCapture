﻿Imports System.ComponentModel
Imports System.IO
Imports inoWebCaptureDLL

Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.Web.WebView2.Core
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class FrmWeb

    Private url() As String
    Private pUrl As Integer = -1
    Private pPic As String
    Private pStart As Boolean
    Private pPicName As String
    Public pFile As String
    Private blnAddUrl As Boolean
    Private pPicTotal As Integer
    Private cPH As New ClsPDFHandling



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
        CaptureScreenshot()
    End Sub


    Dim cropX As Integer
    Dim cropY As Integer
    Dim cropWidth As Integer
    Dim cropHeight As Integer

    Dim cropBitmap As Bitmap
    Private Sub CmdCrop_Click(sender As Object, e As EventArgs) Handles CmdCrop.Click
        pPic = ""
        ' ScreenCopy()
        CaptureScreenshot()
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
                Using sfd As New SaveFileDialog() With {.Filter = "PNG Image|*.png"}

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
            ChkPDF.Checked = My.Settings.PicPDF
            pFile = My.Settings.LastPicFile
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        LblInfo.Text = ""
        LblFile.Text = String.Format("Konfigurationsdatei: {0}", pFile)
        LblTime.Text = ""

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
        CmdResetManual.Visible = False
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
        My.Settings.PicPDF = ChkPDF.Checked


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
                LblTime.Text = ""
                CmdResetManual.Visible = True
            Else
                pPic = pPicName & pUrl + 1 & ".png"
                LblInfo.Text = String.Format("Bild {0} von {1}", pUrl + 1, pPicTotal)

                'ScreenCopy()
                CaptureScreenshot()
                If ChkPDF.Checked = True Then
                    cPH.AddPicturePage(pPic)
                End If
                pUrl += 1
                If pUrl = url.Length Then

                    ResetManuell()
                    If ChkPDF.Checked = True Then
                        SavePDF()
                    Else
                        MessageBox.Show("Am Ende der Liste angekommen")
                    End If
                Else
                    TxtUrl.Text = url(pUrl)
                    BrowseToUrl()
                End If
            End If
        Else
            pUrl = 0

            ButtonControl(False)
            Dim dtStart As DateTime = Now
            Dim dtRemain As DateTime = Now
            Dim duration As TimeSpan
            Dim RestDuration As TimeSpan

            dtRemain = dtRemain.AddSeconds(pPicTotal * NudDuration.Value)
            RestDuration = dtRemain - Now
            LblTime.Text = String.Format("Dauer: {0}:{1} Rest: {2}:{3}", duration.Minutes, Format(duration.Seconds, "00"), RestDuration.Minutes, Format(RestDuration.Seconds, "00"))
            Application.DoEvents()

            For z As Integer = 0 To url.Length - 1

                TxtUrl.Text = url(z)
                BrowseToUrl()
                Application.DoEvents()
                pPic = pPicName & pUrl + 1 & ".png"
                System.Threading.Thread.Sleep(NudDuration.Value * 1000)
                LblInfo.Text = String.Format("Bild {0} von {1}", pUrl + 1, pPicTotal)
                duration = Now - dtStart
                RestDuration = dtRemain - Now
                LblTime.Text = String.Format("Dauer: {0}:{1} Rest: {2}:{3}", duration.Minutes, Format(duration.Seconds, "00"), RestDuration.Minutes, Format(RestDuration.Seconds, "00"))
                Application.DoEvents()
                '  ScreenCopy()
                CaptureScreenshot()
                If ChkPDF.Checked = True Then
                    cPH.AddPicturePage(pPic)
                End If
                pUrl += 1
            Next
            ButtonControl(True)

            LblInfo.Text = "fertig"
            If ChkPDF.Checked = True Then
                SavePDF()
            End If
        End If


    End Sub

    Private Sub ResetManuell()
        pStart = True
        CmdAuto.Text = "Screenshots mit Datei"
        CmdResetManual.Visible = False
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

    Private Sub ButtonControl(Optional Activate As Boolean = True)
        CmdAuto.Enabled = Activate
        CmdAddPic.Enabled = Activate
        CmdBrowse.Enabled = Activate
        CmdCrop.Enabled = Activate
        CmdGetUrl.Enabled = Activate
        CmdPicDatei.Enabled = Activate
        CmdPicPath.Enabled = Activate
        CmdPicture.Enabled = Activate

        ChkAuto.Enabled = Activate

        TxtH.Enabled = Activate
        TxtW.Enabled = Activate
        TxtX.Enabled = Activate
        TxtY.Enabled = Activate
    End Sub

    Private Sub CmdResetManual_Click(sender As Object, e As EventArgs) Handles CmdResetManual.Click
        ResetManuell()
    End Sub

    Private Sub SavePDF()

        Dim sfd As New SaveFileDialog

        With sfd
            .Title = "Speichern der fertigen PDF-Datei"
            .Filter = "PDF (*.pdf)|*.pdf"
            If .ShowDialog = DialogResult.OK Then
                Dim filename As String = .FileName
                If Path.GetExtension(filename) = ".pdf" Then
                    cPH.SavePDF(filename)
                    cPH.CreateNewPDF()
                    If MessageBox.Show("Soll die PDF-Datei geöffnet werden?", "PDF-Datei", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                        Dim startInfo As New ProcessStartInfo With {
                            .FileName = filename,
                            .UseShellExecute = True ' Open with the default associated application 
                        }
                        Process.Start(startInfo)
                    End If
                    If MessageBox.Show("Sollen die erstellten PNG-Dateien gelöscht werden?", "Aufräumen", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        Dim dir As New DirectoryInfo(TxtBildPfad.Text)
                        For Each file In dir.EnumerateFiles(String.Format("{0}*.png", TxtBildName.Text))
                            file.Delete()
                        Next
                    End If
                End If
            End If
        End With


    End Sub


    Private Async Sub CaptureScreenshot()
        Try
            ' Check if WebView2 is ready
            If WView.CoreWebView2 IsNot Nothing Then
                ' Create a memory stream to store the image
                Using stream As New MemoryStream()
                    ' Capture the preview
                    Await WView.CoreWebView2.CapturePreviewAsync(
                        CoreWebView2CapturePreviewImageFormat.Png,
                        stream
                    )

                    ' Save the image to a file
                    'Dim filePath As String = Path.Combine(
                    '    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    '    "WebView2Screenshot.png"
                    ')
                    Using image As Image = Image.FromStream(stream)
                        Dim cropRectangle As New Rectangle(TxtX.Text, TxtY.Text, TxtW.Text, TxtH.Text)

                        ' Create a bitmap with the cropped area
                        Using croppedImage As New Bitmap(cropRectangle.Width, cropRectangle.Height)
                            Using graphic = Graphics.FromImage(croppedImage)
                                ' Draw the cropped area onto the new bitmap
                                graphic.DrawImage(image, New Rectangle(0, 0, cropRectangle.Width, cropRectangle.Height), cropRectangle, GraphicsUnit.Pixel)
                            End Using

                            ' Save the cropped image as a PNG
                            ' croppedImage.Save(filePath, ImageFormat.Png)

                            If pPic = "" Then
                                Using sfd As New SaveFileDialog() With {.Filter = "PNG Image|*.png"}

                                    If sfd.ShowDialog() = DialogResult.OK Then
                                        croppedImage.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png)
                                    End If
                                End Using
                            Else
                                croppedImage.Save(pPic, System.Drawing.Imaging.ImageFormat.Png)
                                Debug.Print(pPic)
                            End If
                        End Using

                        '      image.Save(filePath)
                    End Using

                    'MessageBox.Show("Screenshot saved to: " & filePath)
                End Using
            Else
                MessageBox.Show("WebView2 is not initialized.")
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub CmdClearCache_Click(sender As Object, e As EventArgs) Handles CmdClearCache.Click
        ClearWebViewCache()
    End Sub

    Private Async Sub ClearWebViewCache()
        If WView.CoreWebView2 IsNot Nothing Then
            Try
                ' Löscht Cache, Cookies und andere Browsing-Daten
                Await WView.CoreWebView2.Profile.ClearBrowsingDataAsync(CoreWebView2BrowsingDataKinds.AllSite)
                MessageBox.Show("Cache wurde geleert!")
            Catch ex As Exception
                MessageBox.Show("Fehler beim Löschen des Caches: " & ex.Message)
            End Try
        Else
            MessageBox.Show("WebView2 ist noch nicht initialisiert.")
        End If
    End Sub
End Class