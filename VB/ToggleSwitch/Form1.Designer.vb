Imports Microsoft.VisualBasic
Imports System
Namespace ProgramNamespace
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim gridLevelNode1 As New DevExpress.XtraGrid.GridLevelNode()
			Me.toggleSwitch1 = New CustomEditor.ToggleSwitch()
			Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
			Me.galleryControl1 = New DevExpress.XtraBars.Ribbon.GalleryControl()
			Me.galleryControlClient1 = New DevExpress.XtraBars.Ribbon.GalleryControlClient()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			CType(Me.toggleSwitch1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.galleryControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.galleryControl1.SuspendLayout()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' toggleSwitch1
			' 
			Me.toggleSwitch1.IsTurnedOn = False
			Me.toggleSwitch1.Location = New System.Drawing.Point(290, 251)
			Me.toggleSwitch1.Name = "toggleSwitch1"
			Me.toggleSwitch1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
			Me.toggleSwitch1.Properties.Appearance.Options.UseBackColor = True
			Me.toggleSwitch1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
			Me.toggleSwitch1.Size = New System.Drawing.Size(50, 18)
			Me.toggleSwitch1.TabIndex = 21
			' 
			' labelControl1
			' 
			Me.labelControl1.Location = New System.Drawing.Point(373, 251)
			Me.labelControl1.Name = "labelControl1"
			Me.labelControl1.Size = New System.Drawing.Size(26, 13)
			Me.labelControl1.TabIndex = 25
			Me.labelControl1.Text = "State"
			' 
			' galleryControl1
			' 
			Me.galleryControl1.Controls.Add(Me.galleryControlClient1)
			Me.galleryControl1.DesignGalleryGroupIndex = 0
			Me.galleryControl1.DesignGalleryItemIndex = 0
			Me.galleryControl1.Dock = System.Windows.Forms.DockStyle.Top
			Me.galleryControl1.Location = New System.Drawing.Point(0, 0)
			Me.galleryControl1.Name = "galleryControl1"
			Me.galleryControl1.Size = New System.Drawing.Size(930, 185)
			Me.galleryControl1.TabIndex = 28
			Me.galleryControl1.Text = "galleryControl1"
			' 
			' galleryControlClient1
			' 
			Me.galleryControlClient1.GalleryControl = Me.galleryControl1
			Me.galleryControlClient1.Location = New System.Drawing.Point(2, 2)
			Me.galleryControlClient1.Size = New System.Drawing.Size(909, 181)
			' 
			' gridControl1
			' 
			gridLevelNode1.RelationName = "Level1"
			Me.gridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() { gridLevelNode1})
			Me.gridControl1.Location = New System.Drawing.Point(12, 212)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.Size = New System.Drawing.Size(226, 295)
			Me.gridControl1.TabIndex = 29
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(930, 618)
			Me.Controls.Add(Me.gridControl1)
			Me.Controls.Add(Me.galleryControl1)
			Me.Controls.Add(Me.labelControl1)
			Me.Controls.Add(Me.toggleSwitch1)
			Me.LookAndFeel.SkinName = "Valentine"
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.toggleSwitch1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.galleryControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.galleryControl1.ResumeLayout(False)
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private toggleSwitch1 As CustomEditor.ToggleSwitch
		Private labelControl1 As DevExpress.XtraEditors.LabelControl
		Private galleryControl1 As DevExpress.XtraBars.Ribbon.GalleryControl
		Private galleryControlClient1 As DevExpress.XtraBars.Ribbon.GalleryControlClient
		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
	End Class
End Namespace

