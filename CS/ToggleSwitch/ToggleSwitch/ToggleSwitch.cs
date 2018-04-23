using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CustomEditor {

    [ToolboxItem(true)]
    [System.ComponentModel.DesignerCategory("")]
    public class ToggleSwitch : BaseEdit {
        private static readonly object toggleChanged = new object();
        static ToggleSwitch() {
            RepositoryItemToggleSwitch.Register();
         
        }
        public ToggleSwitch() : base() { 
        }

        
        

        public bool IsTurnedOn {
            get { return (bool)EditValue; }
            set { EditValue = (bool) value; }
        }



        protected override Size DefaultSize {
            get {               
                return new Size(50, 20);
            }
        }

        public override Size CalcBestSize() {
            Size res = this.DefaultSize;
            return res;
        }

        [Browsable(false), DefaultValue(false)]
        public override object EditValue {
            get {
                object value = base.EditValue;
                return value?? false;
            }
            set {
                if(value is bool)
                    base.EditValue = value;
            }


        }


        protected override void OnEditValueChanged() {
            (this.ViewInfo as ToggleSwitchViewInfo).EditValue = this.EditValue;
            RaiseToggleChanged();
        }


        private void RaiseToggleChanged() {
            EventHandler handler = (EventHandler)this.Events[toggleChanged];
            EventArgs e = new EventArgs();
            if(handler != null) handler(this, e);
        }


        public override string EditorTypeName {
            get { return RepositoryItemToggleSwitch.EditorName; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemToggleSwitch Properties {
            get { return base.Properties as RepositoryItemToggleSwitch; }
        }
        

        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);
            IsTurnedOn = !IsTurnedOn;
         
        }

        public event EventHandler ToggleChanged {
            add { this.Events.AddHandler(toggleChanged, value); }
            remove { this.Events.RemoveHandler(toggleChanged, value); }
        }

        
    }
}
