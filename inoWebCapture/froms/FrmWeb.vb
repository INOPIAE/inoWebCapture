Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports Microsoft.Web.WebView2.Core

Public Class FrmWeb
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
        'FrmResize.Show()


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
            '      Dim bit As Bitmap = New Bitmap(crobPictureBox.Image, crobPictureBox.Width, crobPictureBox.Height)

            cropBitmap = New Bitmap(cropWidth, cropHeight)
            Dim g1 As Graphics = Graphics.FromImage(cropBitmap)
            g1.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g1.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            g1.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            '      g.DrawImage(bit, 0, 0, rect, GraphicsUnit.Pixel)
            g1.DrawImage(bmp, 0, 0, rect, GraphicsUnit.Pixel)


            'save the image
            Using sfd As New SaveFileDialog() With {.Filter = "PNG Image|*.png",
                                                    .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop}

                If sfd.ShowDialog() = DialogResult.OK Then
                    cropBitmap.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png)
                End If
            End Using
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

        TxtUrl.Text = My.Settings.LastUrl
    End Sub

    Private Sub FrmWeb_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.LastX = TxtX.Text
        My.Settings.LastY = TxtY.Text
        My.Settings.LastWidth = TxtW.Text
        My.Settings.LastHeight = TxtH.Text

        My.Settings.LastUrl = TxtUrl.Text

        My.Settings.Save()
    End Sub
End Class