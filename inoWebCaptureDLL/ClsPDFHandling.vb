Imports System.IO
Imports PdfSharp.Pdf
Public Class ClsPDFHandling
    Public pdfFile As PdfDocument

    Public Sub CreateNewPDF()
        pdfFile = New PdfDocument
    End Sub

    Public Function AddPicturePage(filepath As String) As Boolean

        If pdfFile Is Nothing Then CreateNewPDF()

        Dim page = pdfFile.AddPage()

        'Create XImage object from file.
        Using xImg = PdfSharp.Drawing.XImage.FromFile(filepath)
            'Resize page Width and Height to fit picture size.
            page.Width = xImg.PixelWidth * 72 / xImg.HorizontalResolution
            page.Height = xImg.PixelHeight * 72 / xImg.HorizontalResolution

            'Draw current image file to page.
            Dim GR = PdfSharp.Drawing.XGraphics.FromPdfPage(page)
            GR.DrawImage(xImg, 0, 0, page.Width, page.Height)
        End Using

        Return True
    End Function

    Public Sub SavePDF(filepath As String)
        pdfFile.Save(filepath)
    End Sub
End Class
