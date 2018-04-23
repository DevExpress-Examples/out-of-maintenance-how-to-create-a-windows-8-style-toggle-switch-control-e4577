Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.ViewInfo
Imports System.Drawing

Namespace CustomEditor

	Public Class ToggleSwitchViewInfo
		Inherits BaseEditViewInfo
		Public Sub New(ByVal item As RepositoryItem)
			MyBase.New(item)

		End Sub

		Private privateThumbRectangle As Rectangle
		Public Property ThumbRectangle() As Rectangle
			Get
				Return privateThumbRectangle
			End Get
			Set(ByVal value As Rectangle)
				privateThumbRectangle = value
			End Set
		End Property
		Private privateBodyRectangle As Rectangle
		Public Property BodyRectangle() As Rectangle
			Get
				Return privateBodyRectangle
			End Get
			Set(ByVal value As Rectangle)
				privateBodyRectangle = value
			End Set
		End Property


		Private thumbState As DevExpress.Utils.Drawing.ObjectState
		Private bodyState_Renamed As DevExpress.Utils.Drawing.ObjectState


		Public Property ThumbButtonState() As DevExpress.Utils.Drawing.ObjectState
			Get
				Return thumbState
			End Get
			Set(ByVal value As DevExpress.Utils.Drawing.ObjectState)
				If thumbState = value Then
					Return
				Else
					thumbState = value
				End If

			End Set
		End Property
		Public Property BodyState() As DevExpress.Utils.Drawing.ObjectState
			Get
				Return bodyState_Renamed
			End Get
			Set(ByVal value As DevExpress.Utils.Drawing.ObjectState)
				If bodyState_Renamed = value Then
					Return
				Else
					bodyState_Renamed = value
				End If

			End Set
		End Property

		Public Overrides Overloads Function UpdateObjectState(ByVal mouseButtons As System.Windows.Forms.MouseButtons, ByVal mousePosition As Point) As Boolean
			Me.CalculateRectangles()
			CaclculateHitInfo(mousePosition)
			Return True

		End Function

		Public Overrides ReadOnly Property IsRequiredUpdateOnMouseMove() As Boolean
			Get
				Return True
			End Get
		End Property

		Public Overrides Function CalcBestFit(ByVal g As Graphics) As Size
		   Return New Size(50, MyBase.CalcBestFit(g).Height + 4)
		End Function


		Public Sub CaclculateHitInfo(ByVal mousePosition As Point)
			If Me.OwnerEdit IsNot Nothing AndAlso Me.OwnerEdit.IsDesignMode Then
				Return
			Else
				If ThumbRectangle.Contains(mousePosition) Then
					ThumbButtonState = DevExpress.Utils.Drawing.ObjectState.Hot
					BodyState = DevExpress.Utils.Drawing.ObjectState.Normal
					Return
				Else
					ThumbButtonState = DevExpress.Utils.Drawing.ObjectState.Normal
				End If
				BodyState = If(BodyRectangle.Contains(mousePosition), DevExpress.Utils.Drawing.ObjectState.Hot, DevExpress.Utils.Drawing.ObjectState.Normal)
			End If

		End Sub

		Public Sub CalculateRectangles()
			Dim editValue As Object = Me.EditValue
			Dim rect As New Rectangle()
			rect.Y = Me.Bounds.Y
			rect.Width = 20
			If CBool(editValue) = False Then
				rect.X = Me.Bounds.X
			Else
				rect.X = Me.Bounds.X + Me.Bounds.Width - 20
			End If
			rect.Height = If(Me.Bounds.Height < 20, Me.Bounds.Height, 20)
			Me.ThumbRectangle = rect
			Me.BodyRectangle = New Rectangle(Me.Bounds.X, Me.Bounds.Y, Me.Bounds.Width,If(Me.Bounds.Height < 20, Me.Bounds.Height, 20))
		End Sub

	End Class

End Namespace
