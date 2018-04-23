Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraEditors.Drawing
Imports System.Drawing
Imports DevExpress.Skins

Namespace CustomEditor
	Public Class ToggleSwitchPainter
		Inherits BaseEditPainter
		Public Sub New()
			MyBase.New()

		End Sub

		Public Overrides Sub Draw(ByVal info As ControlGraphicsInfoArgs)
			MyBase.Draw(info)
			TryCast(info.ViewInfo, ToggleSwitchViewInfo).CalculateRectangles()
			DrawBody(info)
			DrawThumbButton(info)
		End Sub

		Protected Sub DrawBody(ByVal info As ControlGraphicsInfoArgs)
			Dim bound As Rectangle = (TryCast(info.ViewInfo, ToggleSwitchViewInfo)).BodyRectangle
			Dim currentSkin As Skin = EditorsSkins.GetSkin((TryCast(info.ViewInfo, ToggleSwitchViewInfo)).LookAndFeel)
			Dim bodyRect As Rectangle = (TryCast(info.ViewInfo, ToggleSwitchViewInfo)).BodyRectangle
			bodyRect.Inflate(-3, -3)
			currentSkin = CommonSkins.GetSkin((TryCast(info.ViewInfo, ToggleSwitchViewInfo)).LookAndFeel)
			Dim element As SkinElement = currentSkin(CommonSkins.SkinTextBorder)
			Dim borderColor As Color = element.Border.Top
			info.Cache.FillRectangle(info.Cache.GetSolidBrush(DevExpress.LookAndFeel.LookAndFeelHelper.GetSystemColorEx((TryCast(info.ViewInfo, ToggleSwitchViewInfo)).LookAndFeel, SystemColors.Control)), info.Bounds)
			Dim skinBackColor As Color = currentSkin.CommonSkin.Colors("Control")
			If (TryCast(info.ViewInfo, ToggleSwitchViewInfo)).BodyState = DevExpress.Utils.Drawing.ObjectState.Hot Then
				Using sb As New SolidBrush(ConvertColor(skinBackColor, 100))
					info.Graphics.FillRectangle(sb, bodyRect)
				End Using
			End If

			bound.Width -= 1
			bound.Height -= 1
			info.Graphics.DrawRectangle(New Pen(borderColor), bound)
		End Sub


		Private Function ConvertColor(ByVal baseColor As Color, ByVal transparency As Integer) As Color
			Dim colors As New List(Of Integer)(3)
			colors.Add(baseColor.R)
			colors.Add(baseColor.G)
			colors.Add(baseColor.B)
			Dim index As Integer = -1
			Dim maxValue As Integer = colors(0)
			For i As Integer = 0 To colors.Count - 1
				Dim temp As Integer = colors(i)
				If temp >= maxValue Then
					maxValue = temp
					index = i
				End If
			Next i

			Dim brightess As Single = baseColor.GetBrightness()



			For i As Integer = 0 To colors.Count - 1
				If i <> index Then
					If brightess > 0.75f Then
						colors(i) = If(colors(i) - 40 < 0, 0, colors(i) - 40)
					Else
						colors(i) = If(colors(i) + 100 > 255, 255, colors(i) + 100)
					End If
				End If

			Next i

			Return Color.FromArgb(transparency, colors(0), colors(1), colors(2))


		End Function


		Protected Sub DrawThumbButton(ByVal info As ControlGraphicsInfoArgs)
			Dim currentSkin As Skin = CommonSkins.GetSkin((TryCast(info.ViewInfo, ToggleSwitchViewInfo)).LookAndFeel)
			Dim element As SkinElement = currentSkin(CommonSkins.SkinTextBorder)
			Dim borderColor As Color = element.Border.Top
			Dim thumbRectangle As Rectangle = (TryCast(info.ViewInfo, ToggleSwitchViewInfo)).ThumbRectangle
			info.Graphics.FillRectangle(New SolidBrush(borderColor), thumbRectangle)

			If (TryCast(info.ViewInfo, ToggleSwitchViewInfo)).ThumbButtonState = DevExpress.Utils.Drawing.ObjectState.Hot Then
				Using sb As New SolidBrush(ConvertColor(borderColor, 100))
					info.Graphics.FillRectangle(sb, (TryCast(info.ViewInfo, ToggleSwitchViewInfo)).ThumbRectangle)
				End Using
			End If
		End Sub

	End Class
End Namespace
