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
        SplitContainer1 = New SplitContainer()
        LblInfo = New Label()
        CmdCrop = New Button()
        CmdPicture = New Button()
        CmdGetUrl = New Button()
        CmdBrowse = New Button()
        TxtUrl = New TextBox()
        WView = New Microsoft.Web.WebView2.WinForms.WebView2()
        TxtX = New TextBox()
        TxtY = New TextBox()
        TxtW = New TextBox()
        TxtH = New TextBox()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(WView, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        SplitContainer1.Orientation = Orientation.Horizontal
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(TxtH)
        SplitContainer1.Panel1.Controls.Add(TxtW)
        SplitContainer1.Panel1.Controls.Add(TxtY)
        SplitContainer1.Panel1.Controls.Add(TxtX)
        SplitContainer1.Panel1.Controls.Add(LblInfo)
        SplitContainer1.Panel1.Controls.Add(CmdCrop)
        SplitContainer1.Panel1.Controls.Add(CmdPicture)
        SplitContainer1.Panel1.Controls.Add(CmdGetUrl)
        SplitContainer1.Panel1.Controls.Add(CmdBrowse)
        SplitContainer1.Panel1.Controls.Add(TxtUrl)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(WView)
        SplitContainer1.Size = New Size(1100, 508)
        SplitContainer1.SplitterDistance = 71
        SplitContainer1.TabIndex = 0
        ' 
        ' LblInfo
        ' 
        LblInfo.AutoSize = True
        LblInfo.Location = New Point(1013, 12)
        LblInfo.Name = "LblInfo"
        LblInfo.Size = New Size(41, 15)
        LblInfo.TabIndex = 2
        LblInfo.Text = "Label1"
        ' 
        ' CmdCrop
        ' 
        CmdCrop.Location = New Point(871, 9)
        CmdCrop.Name = "CmdCrop"
        CmdCrop.Size = New Size(60, 26)
        CmdCrop.TabIndex = 1
        CmdCrop.Text = "Button1"
        CmdCrop.UseVisualStyleBackColor = True
        ' 
        ' CmdPicture
        ' 
        CmdPicture.Location = New Point(805, 9)
        CmdPicture.Name = "CmdPicture"
        CmdPicture.Size = New Size(60, 26)
        CmdPicture.TabIndex = 1
        CmdPicture.Text = "Button1"
        CmdPicture.UseVisualStyleBackColor = True
        ' 
        ' CmdGetUrl
        ' 
        CmdGetUrl.Location = New Point(937, 10)
        CmdGetUrl.Name = "CmdGetUrl"
        CmdGetUrl.Size = New Size(60, 26)
        CmdGetUrl.TabIndex = 1
        CmdGetUrl.Text = "Get URL"
        CmdGetUrl.UseVisualStyleBackColor = True
        ' 
        ' CmdBrowse
        ' 
        CmdBrowse.Location = New Point(739, 10)
        CmdBrowse.Name = "CmdBrowse"
        CmdBrowse.Size = New Size(60, 26)
        CmdBrowse.TabIndex = 1
        CmdBrowse.Text = "Button1"
        CmdBrowse.UseVisualStyleBackColor = True
        ' 
        ' TxtUrl
        ' 
        TxtUrl.Location = New Point(36, 12)
        TxtUrl.Name = "TxtUrl"
        TxtUrl.Size = New Size(697, 23)
        TxtUrl.TabIndex = 0
        ' 
        ' WView
        ' 
        WView.AllowExternalDrop = True
        WView.CreationProperties = Nothing
        WView.DefaultBackgroundColor = Color.White
        WView.Dock = DockStyle.Fill
        WView.Location = New Point(0, 0)
        WView.Name = "WView"
        WView.Size = New Size(1100, 433)
        WView.Source = New Uri("https://app.powerbi.com/", UriKind.Absolute)
        WView.TabIndex = 0
        WView.ZoomFactor = 1R
        ' 
        ' TxtX
        ' 
        TxtX.Location = New Point(64, 41)
        TxtX.Name = "TxtX"
        TxtX.Size = New Size(100, 23)
        TxtX.TabIndex = 3
        ' 
        ' TxtY
        ' 
        TxtY.Location = New Point(180, 41)
        TxtY.Name = "TxtY"
        TxtY.Size = New Size(100, 23)
        TxtY.TabIndex = 3
        ' 
        ' TxtW
        ' 
        TxtW.Location = New Point(286, 41)
        TxtW.Name = "TxtW"
        TxtW.Size = New Size(100, 23)
        TxtW.TabIndex = 3
        ' 
        ' TxtH
        ' 
        TxtH.Location = New Point(392, 41)
        TxtH.Name = "TxtH"
        TxtH.Size = New Size(100, 23)
        TxtH.TabIndex = 3
        ' 
        ' FrmWeb
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1100, 508)
        Controls.Add(SplitContainer1)
        Name = "FrmWeb"
        Text = "FrmWeb"
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel1.PerformLayout()
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        CType(WView, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents CmdBrowse As Button
    Friend WithEvents TxtUrl As TextBox
    Friend WithEvents WView As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents CmdPicture As Button
    Friend WithEvents CmdCrop As Button
    Friend WithEvents CmdGetUrl As Button
    Friend WithEvents LblInfo As Label
    Friend WithEvents TxtH As TextBox
    Friend WithEvents TxtW As TextBox
    Friend WithEvents TxtY As TextBox
    Friend WithEvents TxtX As TextBox
End Class
