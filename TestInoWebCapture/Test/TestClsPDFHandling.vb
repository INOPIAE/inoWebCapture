Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Net.WebRequestMethods
Imports System.Runtime
Imports inoWebCaptureDLL
Imports NUnit.Framework
Imports NUnit.Framework.Internal
Imports File = System.IO.File

Namespace TestInoWebCapture

    Public Class TestClsPDFHandling
        Private testPath As String = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory)).Replace("\bin", ""), "TestData")
        'Private DBFile As String = testPath & "\TestData\DB\pfalzenCurrentDB.accdb"
        Private cPH As ClsPDFHandling
        Private cHelper As New ClsHelper
        Private testFolder As String


        <SetUp>
        Public Sub Setup()
            testFolder = cHelper.CreateTestFolder("currenttestdata")
            cHelper.DeleteTestFolder(testFolder)
            'DBFileTest = testFolder & "\pfalzenCurrentDB.accdb"
            'File.Copy(DBFile, DBFileTest)
            cPH = New ClsPDFHandling()

        End Sub

        <TearDown>
        Public Sub TearDown()
            cHelper.DeleteTestFolder(testFolder)
        End Sub

        <Test>
        Public Sub TestAddPicturePage()

            Dim strFile As String = Path.Combine(testPath, "inoPic1.png")
            Assert.That(cPH.pdfFile, NUnit.Framework.Is.Null)

            cPH.AddPicturePage(strFile)

            Assert.That(cPH.pdfFile.Pages.Count, NUnit.Framework.Is.EqualTo(1))

            strFile = Path.Combine(testPath, "inoPic2.png")
            cPH.AddPicturePage(strFile)
            Assert.That(cPH.pdfFile.Pages.Count, NUnit.Framework.Is.EqualTo(2))
        End Sub

        <Test>
        Public Sub TestCreateNewPDF()

            Dim strFile As String = Path.Combine(testPath, "inoPic1.png")
            Assert.That(cPH.pdfFile, NUnit.Framework.Is.Null)

            cPH.CreateNewPDF()
            Assert.That(cPH.pdfFile.Pages.Count, NUnit.Framework.Is.EqualTo(0))

            cPH.AddPicturePage(strFile)
            Assert.That(cPH.pdfFile.Pages.Count, NUnit.Framework.Is.EqualTo(1))

            cPH.CreateNewPDF()
            Assert.That(cPH.pdfFile.Pages.Count, NUnit.Framework.Is.EqualTo(0))
        End Sub

        <Test>
        Public Sub TestSavePDF()

            Dim strFile As String = Path.Combine(testPath, "inoPic1.png")
            Assert.That(cPH.pdfFile, NUnit.Framework.Is.Null)

            cPH.AddPicturePage(strFile)

            Assert.That(cPH.pdfFile.Pages.Count, NUnit.Framework.Is.EqualTo(1))
            Dim strPDF As String = Path.Combine(testFolder, "ino.pdf")
            cPH.SavePDF(strPDF)

            Assert.That(strPDF, Does.Exist)
        End Sub
    End Class
End Namespace

