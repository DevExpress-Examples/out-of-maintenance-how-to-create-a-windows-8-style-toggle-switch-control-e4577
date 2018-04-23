using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using System.Drawing;

namespace CustomEditor {

    public class ToggleSwitchViewInfo : BaseEditViewInfo {
        public ToggleSwitchViewInfo(RepositoryItem item)
            : base(item) {
    
        }

        public Rectangle ThumbRectangle { get; set; }
        public Rectangle BodyRectangle { get; set; }


        private DevExpress.Utils.Drawing.ObjectState thumbState;
        private DevExpress.Utils.Drawing.ObjectState bodyState;

   
        public DevExpress.Utils.Drawing.ObjectState ThumbButtonState {
            get {
                return thumbState;
            }
            set {
                if(thumbState == value) return;
                else {
                    thumbState = value;
                }
                
            }
        }     
        public DevExpress.Utils.Drawing.ObjectState BodyState {
            get {
                return bodyState;
            }
            set {
                if(bodyState == value) return;
                else {
                    bodyState = value;
                }
               
            }
        }

        public override bool UpdateObjectState(System.Windows.Forms.MouseButtons mouseButtons, Point mousePosition) {
            this.CalculateRectangles();
            CaclculateHitInfo(mousePosition);
            return true;
            
        }

        public override bool IsRequiredUpdateOnMouseMove {
            get {
                return true;
            }
        }

        public override Size CalcBestFit(Graphics g) {
           return new Size(50, base.CalcBestFit(g).Height + 4);
        }


        public void CaclculateHitInfo(Point mousePosition) {
            if(this.OwnerEdit != null && this.OwnerEdit.IsDesignMode) {
                return;
            }
            else {
                if(ThumbRectangle.Contains(mousePosition)) {
                    ThumbButtonState = DevExpress.Utils.Drawing.ObjectState.Hot;
                    BodyState = DevExpress.Utils.Drawing.ObjectState.Normal;
                    return;
                }
                else
                    ThumbButtonState = DevExpress.Utils.Drawing.ObjectState.Normal;
                BodyState = BodyRectangle.Contains(mousePosition) ? DevExpress.Utils.Drawing.ObjectState.Hot : DevExpress.Utils.Drawing.ObjectState.Normal;
            }
     
        }

        public void CalculateRectangles() {
            object editValue = this.EditValue;
            Rectangle rect = new Rectangle();
            rect.Y = this.Bounds.Y;
            rect.Width = 20;
            if((bool)editValue == false)
                rect.X = this.Bounds.X;
            else
                rect.X = this.Bounds.X + this.Bounds.Width - 20;
            rect.Height = this.Bounds.Height < 20 ? this.Bounds.Height : 20;
            this.ThumbRectangle = rect;
            this.BodyRectangle = new Rectangle(this.Bounds.X, this.Bounds.Y, this.Bounds.Width, this.Bounds.Height < 20 ? this.Bounds.Height : 20);
        }
     
    }

}
