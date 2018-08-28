<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.bLogin = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.tbPastekey = New System.Windows.Forms.TextBox()
        Me.rtbCode = New System.Windows.Forms.RichTextBox()
        Me.bLoad = New System.Windows.Forms.Button()
        Me.bDelete = New System.Windows.Forms.Button()
        Me.bCreate = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbPasteName = New System.Windows.Forms.TextBox()
        Me.bLoadList = New System.Windows.Forms.Button()
        Me.tbApi = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbUsername = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rtbPastes = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.pView = New System.Windows.Forms.PictureBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bLogin
        '
        Me.bLogin.Location = New System.Drawing.Point(12, 130)
        Me.bLogin.Name = "bLogin"
        Me.bLogin.Size = New System.Drawing.Size(210, 23)
        Me.bLogin.TabIndex = 15
        Me.bLogin.Text = "Login"
        Me.bLogin.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.tbPastekey)
        Me.GroupBox1.Controls.Add(Me.rtbCode)
        Me.GroupBox1.Controls.Add(Me.bLoad)
        Me.GroupBox1.Controls.Add(Me.bDelete)
        Me.GroupBox1.Controls.Add(Me.bCreate)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tbPasteName)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 159)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(445, 310)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pastebin"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(172, 281)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 23)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Edit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'tbPastekey
        '
        Me.tbPastekey.Location = New System.Drawing.Point(216, 32)
        Me.tbPastekey.Name = "tbPastekey"
        Me.tbPastekey.Size = New System.Drawing.Size(215, 20)
        Me.tbPastekey.TabIndex = 14
        '
        'rtbCode
        '
        Me.rtbCode.Location = New System.Drawing.Point(9, 87)
        Me.rtbCode.Name = "rtbCode"
        Me.rtbCode.Size = New System.Drawing.Size(430, 161)
        Me.rtbCode.TabIndex = 13
        Me.rtbCode.Text = resources.GetString("rtbCode.Text")
        '
        'bLoad
        '
        Me.bLoad.Location = New System.Drawing.Point(9, 254)
        Me.bLoad.Name = "bLoad"
        Me.bLoad.Size = New System.Drawing.Size(104, 23)
        Me.bLoad.TabIndex = 10
        Me.bLoad.Text = "Load"
        Me.bLoad.UseVisualStyleBackColor = True
        '
        'bDelete
        '
        Me.bDelete.Location = New System.Drawing.Point(172, 254)
        Me.bDelete.Name = "bDelete"
        Me.bDelete.Size = New System.Drawing.Size(104, 23)
        Me.bDelete.TabIndex = 9
        Me.bDelete.Text = "Delete"
        Me.bDelete.UseVisualStyleBackColor = True
        '
        'bCreate
        '
        Me.bCreate.Location = New System.Drawing.Point(335, 254)
        Me.bCreate.Name = "bCreate"
        Me.bCreate.Size = New System.Drawing.Size(104, 23)
        Me.bCreate.TabIndex = 8
        Me.bCreate.Text = "Create"
        Me.bCreate.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(213, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Paste Key"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Paste Name"
        '
        'tbPasteName
        '
        Me.tbPasteName.Location = New System.Drawing.Point(9, 32)
        Me.tbPasteName.Name = "tbPasteName"
        Me.tbPasteName.Size = New System.Drawing.Size(201, 20)
        Me.tbPasteName.TabIndex = 0
        '
        'bLoadList
        '
        Me.bLoadList.Location = New System.Drawing.Point(228, 130)
        Me.bLoadList.Name = "bLoadList"
        Me.bLoadList.Size = New System.Drawing.Size(229, 23)
        Me.bLoadList.TabIndex = 12
        Me.bLoadList.Text = "Load List"
        Me.bLoadList.UseVisualStyleBackColor = True
        '
        'tbApi
        '
        Me.tbApi.Location = New System.Drawing.Point(12, 104)
        Me.tbApi.Name = "tbApi"
        Me.tbApi.Size = New System.Drawing.Size(210, 20)
        Me.tbApi.TabIndex = 13
        Me.tbApi.Text = "dc4caac6d97c008a47023574e28974a2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "API"
        '
        'tbPassword
        '
        Me.tbPassword.Location = New System.Drawing.Point(12, 65)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.Size = New System.Drawing.Size(210, 20)
        Me.tbPassword.TabIndex = 11
        Me.tbPassword.Text = "@remotebinpassword"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Password"
        '
        'tbUsername
        '
        Me.tbUsername.Location = New System.Drawing.Point(12, 26)
        Me.tbUsername.Name = "tbUsername"
        Me.tbUsername.Size = New System.Drawing.Size(210, 20)
        Me.tbUsername.TabIndex = 9
        Me.tbUsername.Text = "RemoteBinBot"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Username"
        '
        'rtbPastes
        '
        Me.rtbPastes.Location = New System.Drawing.Point(228, 9)
        Me.rtbPastes.Name = "rtbPastes"
        Me.rtbPastes.Size = New System.Drawing.Size(229, 115)
        Me.rtbPastes.TabIndex = 16
        Me.rtbPastes.Text = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(463, 130)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(229, 23)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Create Server File"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(464, 104)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(228, 20)
        Me.TextBox1.TabIndex = 18
        Me.TextBox1.Text = "C:\Users\Kevin\Pictures\1920x1200.jpg"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(464, 175)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(228, 290)
        Me.ListBox1.TabIndex = 19
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(711, 130)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 23)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "Edit"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(721, 175)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 23)
        Me.Button4.TabIndex = 20
        Me.Button4.Text = "Monitor"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(972, 7)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(104, 23)
        Me.Button5.TabIndex = 21
        Me.Button5.Text = "Pic"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'pView
        '
        Me.pView.Location = New System.Drawing.Point(852, 49)
        Me.pView.Name = "pView"
        Me.pView.Size = New System.Drawing.Size(528, 401)
        Me.pView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pView.TabIndex = 22
        Me.pView.TabStop = False
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(698, 218)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(104, 23)
        Me.Button6.TabIndex = 23
        Me.Button6.Text = "Anti"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(698, 247)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(104, 23)
        Me.Button7.TabIndex = 24
        Me.Button7.Text = "Anti"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1382, 481)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.pView)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.rtbPastes)
        Me.Controls.Add(Me.bLogin)
        Me.Controls.Add(Me.bLoadList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tbApi)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbUsername)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MainForm"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub

    Friend WithEvents bLogin As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rtbCode As RichTextBox
    Friend WithEvents bLoadList As Button
    Friend WithEvents bLoad As Button
    Friend WithEvents bDelete As Button
    Friend WithEvents bCreate As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents tbPasteName As TextBox
    Friend WithEvents tbApi As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbUsername As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents rtbPastes As RichTextBox
    Friend WithEvents tbPastekey As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents pView As System.Windows.Forms.PictureBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
End Class
