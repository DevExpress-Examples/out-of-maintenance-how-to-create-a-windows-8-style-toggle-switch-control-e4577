using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;

namespace CustomEditor {
    [System.ComponentModel.DesignerCategory("")]
    [UserRepositoryItem("Register")]
    public class RepositoryItemToggleSwitch : RepositoryItem{
        static RepositoryItemToggleSwitch() {

            Register();
        }
        public RepositoryItemToggleSwitch()
            : base() {
            
        }


        internal const string EditorName = "ToggleSwitch";

        public static void Register() {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(ToggleSwitch),
                typeof(RepositoryItemToggleSwitch), typeof(ToggleSwitchViewInfo),
                new ToggleSwitchPainter(), true, null));
        }
        public override string EditorTypeName {
            get { return EditorName; }
        }


    }
}
