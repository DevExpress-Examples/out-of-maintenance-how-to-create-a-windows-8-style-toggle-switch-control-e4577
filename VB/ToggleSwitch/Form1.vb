Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.Data
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.Skins
Imports CustomEditor
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraBars.Helpers

Namespace ProgramNamespace
	Partial Public Class Form1
		Inherits XtraForm
		Private testDataSource As New BindingList(Of TestClass)()
		Public Sub New()
			InitializeComponent()
			SkinManager.EnableFormSkins()
			DevExpress.UserSkins.BonusSkins.Register()
			SkinHelper.InitSkinGallery(galleryControl1)
			For i As Integer = 0 To 9
				testDataSource.Add(New TestClass(Convert.ToBoolean(i Mod 2), String.Format("item {0}", i)))
			Next i
			gridControl1.DataSource = testDataSource
			gridView1.Columns(0).ColumnEdit = New RepositoryItemToggleSwitch()
			AddHandler toggleSwitch1.ToggleChanged, AddressOf toggleSwitch1_ToggleChanged
		End Sub

		Private Sub toggleSwitch1_ToggleChanged(ByVal sender As Object, ByVal e As EventArgs)
			labelControl1.Text = If((TryCast(sender, ToggleSwitch)).IsTurnedOn, "ToggleOn", "ToggleOFF")
		End Sub

		Private Class TestClass
			Public Sub New(ByVal v1 As Boolean, ByVal v2 As String)
				value1 = v1
				value2 = v2
			End Sub
			Private privatevalue1 As Boolean
			Public Property value1() As Boolean
				Get
					Return privatevalue1
				End Get
				Set(ByVal value As Boolean)
					privatevalue1 = value
				End Set
			End Property
			Private privatevalue2 As String
			Public Property value2() As String
				Get
					Return privatevalue2
				End Get
				Set(ByVal value As String)
					privatevalue2 = value
				End Set
			End Property

		End Class



	End Class
End Namespace






