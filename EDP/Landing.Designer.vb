﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Landing
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
        Me.breed = New System.Windows.Forms.Button()
        Me.color = New System.Windows.Forms.Button()
        Me.sex = New System.Windows.Forms.Button()
        Me.nickname = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'breed
        '
        Me.breed.Location = New System.Drawing.Point(216, 250)
        Me.breed.Name = "breed"
        Me.breed.Size = New System.Drawing.Size(95, 33)
        Me.breed.TabIndex = 0
        Me.breed.Text = "Dogs Breed"
        Me.breed.UseVisualStyleBackColor = True
        '
        'color
        '
        Me.color.Location = New System.Drawing.Point(476, 250)
        Me.color.Name = "color"
        Me.color.Size = New System.Drawing.Size(95, 33)
        Me.color.TabIndex = 1
        Me.color.Text = "Dogs Color"
        Me.color.UseVisualStyleBackColor = True
        '
        'sex
        '
        Me.sex.Location = New System.Drawing.Point(341, 250)
        Me.sex.Name = "sex"
        Me.sex.Size = New System.Drawing.Size(95, 33)
        Me.sex.TabIndex = 2
        Me.sex.Text = "Dogs Sex"
        Me.sex.UseVisualStyleBackColor = True
        '
        'nickname
        '
        Me.nickname.Location = New System.Drawing.Point(95, 250)
        Me.nickname.Name = "nickname"
        Me.nickname.Size = New System.Drawing.Size(95, 33)
        Me.nickname.TabIndex = 3
        Me.nickname.Text = "Dogs Name"
        Me.nickname.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(60, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(183, 31)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "WE TAKING "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(60, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 31)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "CARE FOR  "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(60, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(188, 31)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "YOUR PETS "
        '
        'Landing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(682, 387)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nickname)
        Me.Controls.Add(Me.sex)
        Me.Controls.Add(Me.color)
        Me.Controls.Add(Me.breed)
        Me.MaximizeBox = False
        Me.Name = "Landing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents breed As Button
    Friend WithEvents color As Button
    Friend WithEvents sex As Button
    Friend WithEvents nickname As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
