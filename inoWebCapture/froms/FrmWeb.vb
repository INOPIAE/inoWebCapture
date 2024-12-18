Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.IO
Imports DocumentFormat.OpenXml.Office.Word
Imports Microsoft.Web.WebView2.Core

Public Class FrmWeb

    Private url() As String
    Private pUrl As Integer = -1
    Private pPic As String
    Private pStart As Boolean
    Private pPicName As String
    Private Sub CmdBrowse_Click(sender As Object, e As EventArgs) Handles CmdBrowse.Click
        WView.CoreWebView2.Navigate(TxtUrl.Text)
    End Sub

    Private Sub CmdPicture_Click(sender As Object, e As EventArgs) Handles CmdPicture.Click
        Dim currentScreen = Screen.FromHandle(Me.Handle).WorkingArea

        'create a bitmap of the working area
        Using bmp As New Bitmap(currentScreen.Width, currentScreen.Height)

            'copy the screen to the image
            Using g = Graphics.FromImage(bmp)
                g.CopyFromScreen(New Point(0, 0), New Point(0, 0), currentScreen.Size)
            End Using

            'save the image
            Using sfd As New SaveFileDialog() With {.Filter = "PNG Image|*.png",
                                                    .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop}

                If sfd.ShowDialog() = DialogResult.OK Then
                    bmp.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png)
                End If
            End Using
        End Using
    End Sub

    'Private Sub SurroundingSub()
    '    Dim image As Image = New Bitmap("Apple.gif")
    '    e.Graphics.DrawImage(image, 0, 0)
    '    Dim width As Integer = image.Width
    '    Dim height As Integer = image.Height
    '    Dim destinationRect As RectangleF = New RectangleF(150, 20, 1.3F * width, 1.3F * height)
    '    Dim sourceRect As RectangleF = New RectangleF(0, 0, 0.75F * width, 0.75F * height)
    '    e.Graphics.DrawImage(image, destinationRect, sourceRect, GraphicsUnit.Pixel)
    'End Sub

    Dim cropX As Integer
    Dim cropY As Integer
    Dim cropWidth As Integer
    Dim cropHeight As Integer

    Dim cropBitmap As Bitmap
    Private Sub CmdCrop_Click(sender As Object, e As EventArgs) Handles CmdCrop.Click
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

    Private Sub WView_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles WView.NavigationCompleted

    End Sub

    Private Sub CmdGetUrl_Click(sender As Object, e As EventArgs) Handles CmdGetUrl.Click
        TxtUrl.Text = WView.Source.ToString()
    End Sub



    Private Sub FrmWeb_Load(sender As Object, e As EventArgs) Handles Me.Load

        TxtX.Text = My.Settings.LastX
        TxtY.Text = My.Settings.LastY
        TxtW.Text = My.Settings.LastWidth
        TxtH.Text = My.Settings.LastHeight
        TxtBildName.Text = My.Settings.LastPicName
        TxtBildPfad.Text = My.Settings.LastPicPath

        If My.Settings.LastUrl = "" Then
            WView.CoreWebView2.Navigate("https://app.powerbi.com")
        Else
            TxtUrl.Text = My.Settings.LastUrl
        End If


        ReDim url(3)
        url(0) = "https://app.powerbi.com/groups/20d350b2-0b6c-48b2-8c0c-c81cb76b0633/reports/be926d05-8098-473e-bab2-a4ccc6c38774/20eda087e4cc2e75b248?experience=power-bi"
        url(1) = "https://app.powerbi.com/groups/20d350b2-0b6c-48b2-8c0c-c81cb76b0633/reports/be926d05-8098-473e-bab2-a4ccc6c38774/7d07333c7ec824516f29?experience=power-bi"
        url(2) = "https://app.powerbi.com/groups/20d350b2-0b6c-48b2-8c0c-c81cb76b0633/reports/be926d05-8098-473e-bab2-a4ccc6c38774/ec45ab4f68a2c42eb061?experience=power-bi"
        url(3) = "https://app.powerbi.com/groups/20d350b2-0b6c-48b2-8c0c-c81cb76b0633/reports/be926d05-8098-473e-bab2-a4ccc6c38774/d4c10a096e09c06f5a9b?experience=power-bi"

        pStart = True

    End Sub

    Private Sub FrmWeb_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.LastX = TxtX.Text
        My.Settings.LastY = TxtY.Text
        My.Settings.LastWidth = TxtW.Text
        My.Settings.LastHeight = TxtH.Text
        My.Settings.LastPicName = TxtBildName.Text
        My.Settings.LastPicPath = TxtBildPfad.Text


        '    My.Settings.LastUrl = TxtUrl.Text

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

        If pStart = True Then
            pUrl = 0
            TxtUrl.Text = url(pUrl)
            CmdBrowse.PerformClick()
            pStart = False

        Else
            pPic = pPicName & pUrl + 1 & ".png"
            LblInfo.Text = "Bild " & pUrl + 1

            ScreenCopy()

            pUrl += 1
            If pUrl = url.Length Then
                pStart = True
                MessageBox.Show("Am Ende der Liste angekommen")
            Else
                TxtUrl.Text = url(pUrl)
                CmdBrowse.PerformClick()
            End If

        End If

        'For z As Integer = 0 To url.Length - 1
        'pUrl += 1

        'TxtUrl.Text = url(z)
        'CmdBrowse.PerformClick()
        'pPic = "D:\test\sc" & z & ".png"
        'LblInfo.Text = "Bild " & z
        'Application.DoEvents()
        'System.Threading.Thread.Sleep(45000)
        'CmdCrop.PerformClick()
        ' Next
        'LblInfo.Text = "fertig"
    End Sub
End Class