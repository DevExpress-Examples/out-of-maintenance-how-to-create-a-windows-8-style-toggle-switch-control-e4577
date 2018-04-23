Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace CustomEditor

	<ToolboxItem(True), System.ComponentModel.DesignerCategory("")> _
	Public Class ToggleSwitch
		Inherits BaseEdit
        Private Shared ReadOnly toggleChangedKey As Object = New Object()
		Shared Sub New()
			RepositoryItemToggleSwitch.Register()

		End Sub
		Public Sub New()
			MyBase.New()
		End Sub




		Public Property IsTurnedOn() As Boolean
			Get
				Return CBool(EditValue)
			End Get
			Set(ByVal value As Boolean)
				EditValue = CBool(value)
			End Set
		End Property



		Protected Overrides ReadOnly Property DefaultSize() As Size
			Get
				Return New Size(50, 20)
			End Get
		End Property

		Public Overrides Function CalcBestSize() As Size
			Dim res As Size = Me.DefaultSize
			Return res
		End Function

		<Browsable(False), DefaultValue(False)> _
		Public Overrides Property EditValue() As Object
			Get
				Dim value As Object = MyBase.EditValue
				Return If(value, False)
			End Get
			Set(ByVal value As Object)
				If TypeOf value Is Boolean Then
					MyBase.EditValue = value
				End If
			End Set


		End Property


		Protected Overrides Sub OnEditValueChanged()
			TryCast(Me.ViewInfo, ToggleSwitchViewInfo).EditValue = Me.EditValue
			RaiseToggleChanged()
		End Sub


		Private Sub RaiseToggleChanged()
            Dim handler As EventHandler = CType(Me.Events(toggleChangedKey), EventHandler)
			Dim e As New EventArgs()
			If handler IsNot Nothing Then
				handler(Me, e)
			End If
		End Sub


		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemToggleSwitch.EditorName
			End Get
		End Property
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemToggleSwitch
			Get
				Return TryCast(MyBase.Properties, RepositoryItemToggleSwitch)
			End Get
		End Property


		Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
			MyBase.OnMouseUp(e)
			IsTurnedOn = Not IsTurnedOn

		End Sub

		Public Custom Event ToggleChanged As EventHandler
			AddHandler(ByVal value As EventHandler)
                Me.Events.AddHandler(toggleChangedKey, value)
			End AddHandler
			RemoveHandler(ByVal value As EventHandler)
                Me.Events.RemoveHandler(toggleChangedKey, value)
			End RemoveHandler
			RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
			End RaiseEvent
		End Event


	End Class
End Namespace
