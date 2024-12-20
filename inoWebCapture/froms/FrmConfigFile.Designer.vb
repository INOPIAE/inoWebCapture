<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfigFile
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
        CmdLoad = New Button()
        CmdNew = New Button()
        CmdCancel = New Button()
        SuspendLayout()
        ' 
        ' CmdLoad
        ' 
        CmdLoad.Location = New Point(32, 36)
        CmdLoad.Name = "CmdLoad"
        CmdLoad.Size = New Size(90, 23)
        CmdLoad.TabIndex = 0
        CmdLoad.Text = "Datei laden"
        CmdLoad.UseVisualStyleBackColor = True
        ' 
        ' CmdNew
        ' 
        CmdNew.Location = New Point(158, 36)
        CmdNew.Name = "CmdNew"
        CmdNew.Size = New Size(90, 23)
        CmdNew.TabIndex = 0
        CmdNew.Text = "Neue Datei"
        CmdNew.UseVisualStyleBackColor = True
        ' 
        ' CmdCancel
        ' 
        CmdCancel.Location = New Point(284, 36)
        CmdCancel.Name = "CmdCancel"
        CmdCancel.Size = New Size(90, 23)
        CmdCancel.TabIndex = 0
        CmdCancel.Text = "Abbrechen"
        CmdCancel.UseVisualStyleBackColor = True
        ' 
        ' FrmConfigFile
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(418, 89)
        Controls.Add(CmdCancel)
        Controls.Add(CmdNew)
        Controls.Add(CmdLoad)
        Name = "FrmConfigFile"
        Text = "Verwalten Konfigurationsdatei"
        ResumeLayout(False)
    End Sub

    Friend WithEvents CmdLoad As Button
    Friend WithEvents CmdNew As Button
    Friend WithEvents CmdCancel As Button
End Class
