Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository

Namespace CustomEditor
	<System.ComponentModel.DesignerCategory(""), UserRepositoryItem("Register")> _
	Public Class RepositoryItemToggleSwitch
		Inherits RepositoryItem
		Shared Sub New()

			Register()
		End Sub
		Public Sub New()
			MyBase.New()

		End Sub


		Friend Const EditorName As String = "ToggleSwitch"

		Public Shared Sub Register()
            EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(EditorName, GetType(ToggleSwitch), GetType(RepositoryItemToggleSwitch), GetType(ToggleSwitchViewInfo), New ToggleSwitchPainter(), True))
		End Sub
		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return EditorName
			End Get
		End Property


	End Class
End Namespace
