using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors.Drawing;
using System.Drawing;
using DevExpress.Skins;

namespace CustomEditor {
    public class ToggleSwitchPainter : BaseEditPainter {
        public ToggleSwitchPainter() : base() {
            
        }

        public override void Draw(ControlGraphicsInfoArgs info) {
            base.Draw(info);
            (info.ViewInfo as ToggleSwitchViewInfo).CalculateRectangles();
            DrawBody(info);
            DrawThumbButton(info);                  
        }

        protected void DrawBody(ControlGraphicsInfoArgs info) {
            Rectangle bound = (info.ViewInfo as ToggleSwitchViewInfo).BodyRectangle;
            Skin currentSkin = EditorsSkins.GetSkin((info.ViewInfo as ToggleSwitchViewInfo).LookAndFeel);    
            Rectangle bodyRect = (info.ViewInfo as ToggleSwitchViewInfo).BodyRectangle;
            bodyRect.Inflate(-3, -3);
            currentSkin = CommonSkins.GetSkin((info.ViewInfo as ToggleSwitchViewInfo).LookAndFeel);
            SkinElement element = currentSkin[CommonSkins.SkinTextBorder];
            Color borderColor = element.Border.Top;
            info.Cache.FillRectangle(info.Cache.GetSolidBrush(DevExpress.LookAndFeel.LookAndFeelHelper.GetSystemColorEx((info.ViewInfo as ToggleSwitchViewInfo).LookAndFeel,
                SystemColors.Control)), info.Bounds);
            Color skinBackColor = currentSkin.CommonSkin.Colors["Control"];
            if((info.ViewInfo as ToggleSwitchViewInfo).BodyState == DevExpress.Utils.Drawing.ObjectState.Hot)
                using(SolidBrush sb = new SolidBrush(ConvertColor(skinBackColor, 100))) {
                    info.Graphics.FillRectangle(sb, bodyRect);
                }

            bound.Width--;
            bound.Height--;
            info.Graphics.DrawRectangle(new Pen(borderColor), bound);
        }


        Color ConvertColor(Color baseColor, int transparency) {
            List<int> colors = new List<int>(3);
            colors.Add(baseColor.R);
            colors.Add(baseColor.G);
            colors.Add(baseColor.B);
            int index = -1;
            int maxValue = colors[0];
            for(int i = 0; i < colors.Count; i++) {
                int temp = colors[i];
                if(temp >= maxValue) {
                    maxValue = temp;
                    index = i;
                }
            }

            float brightess = baseColor.GetBrightness();

            

            for(int i = 0; i < colors.Count; i++) {
                if(i != index) {
                    if(brightess > 0.75f)
                        colors[i] = colors[i] - 40 < 0 ? 0 : colors[i] - 40;
                    else
                        colors[i] = colors[i] + 100 > 255 ? 255 : colors[i] + 100;
                }
                    
            }

            return Color.FromArgb(transparency, colors[0], colors[1], colors[2]);
            

        }


        protected void DrawThumbButton(ControlGraphicsInfoArgs info) {
            Skin currentSkin = CommonSkins.GetSkin((info.ViewInfo as ToggleSwitchViewInfo).LookAndFeel);
            SkinElement element = currentSkin[CommonSkins.SkinTextBorder];
            Color borderColor = element.Border.Top;
            Rectangle thumbRectangle = (info.ViewInfo as ToggleSwitchViewInfo).ThumbRectangle;
            info.Graphics.FillRectangle(new SolidBrush(borderColor), thumbRectangle);

            if((info.ViewInfo as ToggleSwitchViewInfo).ThumbButtonState == DevExpress.Utils.Drawing.ObjectState.Hot)
                using(SolidBrush sb = new SolidBrush(ConvertColor(borderColor, 100))) {
                    info.Graphics.FillRectangle(sb, (info.ViewInfo as ToggleSwitchViewInfo).ThumbRectangle);
                }
        }

    }
}
