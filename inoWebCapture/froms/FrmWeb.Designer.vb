<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWeb
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        SpBrowser = New SplitContainer()
        CmdResetManual = New Button()
        LblDuration = New Label()
        ChkAuto = New CheckBox()
        NudDuration = New NumericUpDown()
        CmdInfo = New Button()
        CmdClose = New Button()
        CmdPicPath = New Button()
        LblPicName = New Label()
        LblPicPath = New Label()
        LblUrl = New Label()
        LblFile = New Label()
        TxtBildName = New TextBox()
        TxtBildPfad = New TextBox()
        LblTime = New Label()
        LblInfo = New Label()
        CmdCrop = New Button()
        CmdAddPic = New Button()
        CmdPicDatei = New Button()
        CmdPicture = New Button()
        CmdGetUrl = New Button()
        CmdAuto = New Button()
        CmdBrowse = New Button()
        TxtUrl = New TextBox()
        GpScreeshot = New GroupBox()
        LblH = New Label()
        LblW = New Label()
        LblY = New Label()
        LblX = New Label()
        TxtH = New TextBox()
        TxtW = New TextBox()
        TxtY = New TextBox()
        TxtX = New TextBox()
        TtpTool = New ToolTip(components)
        CType(SpBrowser, ComponentModel.ISupportInitialize).BeginInit()
        SpBrowser.Panel1.SuspendLayout()
        SpBrowser.SuspendLayout()
        CType(NudDuration, ComponentModel.ISupportInitialize).BeginInit()
        GpScreeshot.SuspendLayout()
        SuspendLayout()
        ' 
        ' SpBrowser
        ' 
        SpBrowser.Dock = DockStyle.Fill
        SpBrowser.FixedPanel = FixedPanel.Panel1
        SpBrowser.Location = New Point(0, 0)
        SpBrowser.Name = "SpBrowser"
        SpBrowser.Orientation = Orientation.Horizontal
        ' 
        ' SpBrowser.Panel1
        ' 
        SpBrowser.Panel1.Controls.Add(CmdResetManual)
        SpBrowser.Panel1.Controls.Add(LblDuration)
        SpBrowser.Panel1.Controls.Add(ChkAuto)
        SpBrowser.Panel1.Controls.Add(NudDuration)
        SpBrowser.Panel1.Controls.Add(CmdInfo)
        SpBrowser.Panel1.Controls.Add(CmdClose)
        SpBrowser.Panel1.Controls.Add(CmdPicPath)
        SpBrowser.Panel1.Controls.Add(LblPicName)
        SpBrowser.Panel1.Controls.Add(LblPicPath)
        SpBrowser.Panel1.Controls.Add(LblUrl)
        SpBrowser.Panel1.Controls.Add(LblFile)
        SpBrowser.Panel1.Controls.Add(TxtBildName)
        SpBrowser.Panel1.Controls.Add(TxtBildPfad)
        SpBrowser.Panel1.Controls.Add(LblTime)
        SpBrowser.Panel1.Controls.Add(LblInfo)
        SpBrowser.Panel1.Controls.Add(CmdCrop)
        SpBrowser.Panel1.Controls.Add(CmdAddPic)
        SpBrowser.Panel1.Controls.Add(CmdPicDatei)
        SpBrowser.Panel1.Controls.Add(CmdPicture)
        SpBrowser.Panel1.Controls.Add(CmdGetUrl)
        SpBrowser.Panel1.Controls.Add(CmdAuto)
        SpBrowser.Panel1.Controls.Add(CmdBrowse)
        SpBrowser.Panel1.Controls.Add(TxtUrl)
        SpBrowser.Panel1.Controls.Add(GpScreeshot)
        SpBrowser.Size = New Size(1553, 508)
        SpBrowser.SplitterDistance = 126
        SpBrowser.TabIndex = 0
        ' 
        ' CmdResetManual
        ' 
        CmdResetManual.Location = New Point(709, 66)
        CmdResetManual.Name = "CmdResetManual"
        CmdResetManual.Size = New Size(129, 23)
        CmdResetManual.TabIndex = 14
        CmdResetManual.Text = "Manuell Reset"
        CmdResetManual.UseVisualStyleBackColor = True
        ' 
        ' LblDuration
        ' 
        LblDuration.AutoSize = True
        LblDuration.Location = New Point(942, 45)
        LblDuration.Name = "LblDuration"
        LblDuration.Size = New Size(59, 15)
        LblDuration.TabIndex = 16
        LblDuration.Text = "Sekunden"
        ' 
        ' ChkAuto
        ' 
        ChkAuto.AutoSize = True
        ChkAuto.Location = New Point(844, 45)
        ChkAuto.Name = "ChkAuto"
        ChkAuto.Size = New Size(92, 19)
        ChkAuto.TabIndex = 15
        ChkAuto.Text = "automatisch"
        ChkAuto.UseVisualStyleBackColor = True
        ' 
        ' NudDuration
        ' 
        NudDuration.Location = New Point(1007, 43)
        NudDuration.Name = "NudDuration"
        NudDuration.Size = New Size(54, 23)
        NudDuration.TabIndex = 17
        NudDuration.TextAlign = HorizontalAlignment.Right
        ' 
        ' CmdInfo
        ' 
        CmdInfo.Location = New Point(1461, 46)
        CmdInfo.Name = "CmdInfo"
        CmdInfo.Size = New Size(66, 27)
        CmdInfo.TabIndex = 20
        CmdInfo.Text = "Info"
        CmdInfo.UseVisualStyleBackColor = True
        ' 
        ' CmdClose
        ' 
        CmdClose.Location = New Point(1461, 10)
        CmdClose.Name = "CmdClose"
        CmdClose.Size = New Size(66, 27)
        CmdClose.TabIndex = 19
        CmdClose.Text = "Schließen"
        CmdClose.UseVisualStyleBackColor = True
        ' 
        ' CmdPicPath
        ' 
        CmdPicPath.Location = New Point(462, 42)
        CmdPicPath.Name = "CmdPicPath"
        CmdPicPath.Size = New Size(30, 23)
        CmdPicPath.TabIndex = 10
        CmdPicPath.Text = "..."
        CmdPicPath.UseVisualStyleBackColor = True
        ' 
        ' LblPicName
        ' 
        LblPicName.AutoSize = True
        LblPicName.Location = New Point(498, 46)
        LblPicName.Name = "LblPicName"
        LblPicName.Size = New Size(44, 15)
        LblPicName.TabIndex = 11
        LblPicName.Text = "-Name"
        ' 
        ' LblPicPath
        ' 
        LblPicPath.AutoSize = True
        LblPicPath.Location = New Point(251, 46)
        LblPicPath.Name = "LblPicPath"
        LblPicPath.Size = New Size(56, 15)
        LblPicPath.TabIndex = 8
        LblPicPath.Text = "Bild-Pfad"
        ' 
        ' LblUrl
        ' 
        LblUrl.AutoSize = True
        LblUrl.Location = New Point(3, 16)
        LblUrl.Name = "LblUrl"
        LblUrl.Size = New Size(31, 15)
        LblUrl.TabIndex = 0
        LblUrl.Text = "URL:"
        ' 
        ' LblFile
        ' 
        LblFile.AutoSize = True
        LblFile.Location = New Point(1067, 46)
        LblFile.Name = "LblFile"
        LblFile.Size = New Size(41, 15)
        LblFile.TabIndex = 18
        LblFile.Text = "Label1"
        ' 
        ' TxtBildName
        ' 
        TxtBildName.Location = New Point(548, 42)
        TxtBildName.Name = "TxtBildName"
        TxtBildName.Size = New Size(150, 23)
        TxtBildName.TabIndex = 12
        ' 
        ' TxtBildPfad
        ' 
        TxtBildPfad.Location = New Point(313, 42)
        TxtBildPfad.Name = "TxtBildPfad"
        TxtBildPfad.Size = New Size(150, 23)
        TxtBildPfad.TabIndex = 9
        ' 
        ' LblTime
        ' 
        LblTime.AutoSize = True
        LblTime.Location = New Point(251, 93)
        LblTime.Name = "LblTime"
        LblTime.Size = New Size(41, 15)
        LblTime.TabIndex = 23
        LblTime.Text = "Label1"
        ' 
        ' LblInfo
        ' 
        LblInfo.AutoSize = True
        LblInfo.Location = New Point(251, 74)
        LblInfo.Name = "LblInfo"
        LblInfo.Size = New Size(41, 15)
        LblInfo.TabIndex = 22
        LblInfo.Text = "Label1"
        ' 
        ' CmdCrop
        ' 
        CmdCrop.Location = New Point(847, 11)
        CmdCrop.Name = "CmdCrop"
        CmdCrop.Size = New Size(102, 26)
        CmdCrop.TabIndex = 3
        CmdCrop.Text = "Screenshot"
        CmdCrop.UseVisualStyleBackColor = True
        ' 
        ' CmdAddPic
        ' 
        CmdAddPic.Location = New Point(1302, 9)
        CmdAddPic.Name = "CmdAddPic"
        CmdAddPic.Size = New Size(111, 26)
        CmdAddPic.TabIndex = 6
        CmdAddPic.Text = "Add URL"
        CmdAddPic.UseVisualStyleBackColor = True
        ' 
        ' CmdPicDatei
        ' 
        CmdPicDatei.Location = New Point(1065, 10)
        CmdPicDatei.Name = "CmdPicDatei"
        CmdPicDatei.Size = New Size(155, 26)
        CmdPicDatei.TabIndex = 4
        CmdPicDatei.Text = "Konfigurationsdatei"
        CmdPicDatei.UseVisualStyleBackColor = True
        ' 
        ' CmdPicture
        ' 
        CmdPicture.Location = New Point(1384, 73)
        CmdPicture.Name = "CmdPicture"
        CmdPicture.Size = New Size(111, 26)
        CmdPicture.TabIndex = 21
        CmdPicture.Text = "Button1"
        CmdPicture.UseVisualStyleBackColor = True
        CmdPicture.Visible = False
        ' 
        ' CmdGetUrl
        ' 
        CmdGetUrl.Location = New Point(1236, 9)
        CmdGetUrl.Name = "CmdGetUrl"
        CmdGetUrl.Size = New Size(60, 26)
        CmdGetUrl.TabIndex = 5
        CmdGetUrl.Text = "Get URL"
        CmdGetUrl.UseVisualStyleBackColor = True
        ' 
        ' CmdAuto
        ' 
        CmdAuto.Location = New Point(709, 40)
        CmdAuto.Name = "CmdAuto"
        CmdAuto.Size = New Size(129, 26)
        CmdAuto.TabIndex = 13
        CmdAuto.Text = "Nächstes Bild"
        CmdAuto.UseVisualStyleBackColor = True
        ' 
        ' CmdBrowse
        ' 
        CmdBrowse.Location = New Point(739, 10)
        CmdBrowse.Name = "CmdBrowse"
        CmdBrowse.Size = New Size(81, 26)
        CmdBrowse.TabIndex = 2
        CmdBrowse.Text = "Load URL"
        CmdBrowse.UseVisualStyleBackColor = True
        ' 
        ' TxtUrl
        ' 
        TxtUrl.Location = New Point(36, 12)
        TxtUrl.Name = "TxtUrl"
        TxtUrl.Size = New Size(697, 23)
        TxtUrl.TabIndex = 1
        ' 
        ' GpScreeshot
        ' 
        GpScreeshot.Controls.Add(LblH)
        GpScreeshot.Controls.Add(LblW)
        GpScreeshot.Controls.Add(LblY)
        GpScreeshot.Controls.Add(LblX)
        GpScreeshot.Controls.Add(TxtH)
        GpScreeshot.Controls.Add(TxtW)
        GpScreeshot.Controls.Add(TxtY)
        GpScreeshot.Controls.Add(TxtX)
        GpScreeshot.Location = New Point(12, 42)
        GpScreeshot.Name = "GpScreeshot"
        GpScreeshot.Size = New Size(233, 76)
        GpScreeshot.TabIndex = 7
        GpScreeshot.TabStop = False
        GpScreeshot.Text = "Definition des Screenshotbereiches"
        ' 
        ' LblH
        ' 
        LblH.AutoSize = True
        LblH.Location = New Point(116, 50)
        LblH.Name = "LblH"
        LblH.Size = New Size(36, 15)
        LblH.TabIndex = 6
        LblH.Text = "Höhe"
        ' 
        ' LblW
        ' 
        LblW.AutoSize = True
        LblW.Location = New Point(9, 50)
        LblW.Name = "LblW"
        LblW.Size = New Size(37, 15)
        LblW.TabIndex = 4
        LblW.Text = "Breite"
        ' 
        ' LblY
        ' 
        LblY.AutoSize = True
        LblY.Location = New Point(114, 20)
        LblY.Name = "LblY"
        LblY.Size = New Size(63, 15)
        LblY.TabIndex = 2
        LblY.Text = "Start Pos Y"
        ' 
        ' LblX
        ' 
        LblX.AutoSize = True
        LblX.Location = New Point(9, 20)
        LblX.Name = "LblX"
        LblX.Size = New Size(63, 15)
        LblX.TabIndex = 0
        LblX.Text = "Start Pos X"
        ' 
        ' TxtH
        ' 
        TxtH.Location = New Point(174, 47)
        TxtH.Name = "TxtH"
        TxtH.Size = New Size(35, 23)
        TxtH.TabIndex = 7
        TxtH.TextAlign = HorizontalAlignment.Right
        ' 
        ' TxtW
        ' 
        TxtW.Location = New Point(75, 48)
        TxtW.Name = "TxtW"
        TxtW.Size = New Size(35, 23)
        TxtW.TabIndex = 5
        TxtW.TextAlign = HorizontalAlignment.Right
        ' 
        ' TxtY
        ' 
        TxtY.Location = New Point(174, 17)
        TxtY.Name = "TxtY"
        TxtY.Size = New Size(35, 23)
        TxtY.TabIndex = 3
        TxtY.TextAlign = HorizontalAlignment.Right
        ' 
        ' TxtX
        ' 
        TxtX.Location = New Point(75, 17)
        TxtX.Name = "TxtX"
        TxtX.Size = New Size(35, 23)
        TxtX.TabIndex = 1
        TxtX.TextAlign = HorizontalAlignment.Right
        ' 
        ' FrmWeb
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1553, 508)
        Controls.Add(SpBrowser)
        Name = "FrmWeb"
        Text = "inoWebCapture"
        SpBrowser.Panel1.ResumeLayout(False)
        SpBrowser.Panel1.PerformLayout()
        CType(SpBrowser, ComponentModel.ISupportInitialize).EndInit()
        SpBrowser.ResumeLayout(False)
        CType(NudDuration, ComponentModel.ISupportInitialize).EndInit()
        GpScreeshot.ResumeLayout(False)
        GpScreeshot.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SpBrowser As SplitContainer
    Friend WithEvents CmdBrowse As Button
    Friend WithEvents TxtUrl As TextBox
    Friend WithEvents CmdPicture As Button
    Friend WithEvents CmdCrop As Button
    Friend WithEvents CmdGetUrl As Button
    Friend WithEvents LblInfo As Label
    Friend WithEvents CmdAuto As Button
    Friend WithEvents TxtBildName As TextBox
    Friend WithEvents TxtBildPfad As TextBox
    Friend WithEvents CmdAddPic As Button
    Friend WithEvents CmdPicDatei As Button
    Friend WithEvents LblFile As Label
    Friend WithEvents LblUrl As Label
    Friend WithEvents CmdPicPath As Button
    Friend WithEvents LblPicName As Label
    Friend WithEvents LblPicPath As Label
    Friend WithEvents CmdInfo As Button
    Friend WithEvents CmdClose As Button
    Friend WithEvents ChkAuto As CheckBox
    Friend WithEvents NudDuration As NumericUpDown
    Friend WithEvents LblDuration As Label
    Friend WithEvents GpScreeshot As GroupBox
    Friend WithEvents LblH As Label
    Friend WithEvents LblW As Label
    Friend WithEvents LblY As Label
    Friend WithEvents LblX As Label
    Friend WithEvents TxtH As TextBox
    Friend WithEvents TxtW As TextBox
    Friend WithEvents TxtY As TextBox
    Friend WithEvents TxtX As TextBox
    Friend WithEvents TtpTool As ToolTip
    Friend WithEvents LblTime As Label
    Friend WithEvents CmdResetManual As Button
End Class
