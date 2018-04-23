using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using CustomEditor;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraBars.Helpers;

namespace ProgramNamespace {
    public partial class Form1 : XtraForm {
        BindingList<TestClass>  testDataSource = new BindingList<TestClass>();
        public Form1() {
            InitializeComponent();
            SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();            
            SkinHelper.InitSkinGallery(galleryControl1);
            for(int i = 0; i < 10; i++)
                testDataSource.Add(new TestClass(Convert.ToBoolean(i % 2), String.Format("item {0}", i)));
            gridControl1.DataSource = testDataSource;
            gridView1.Columns[0].ColumnEdit = new RepositoryItemToggleSwitch();
            toggleSwitch1.ToggleChanged += toggleSwitch1_ToggleChanged;
        }

        void toggleSwitch1_ToggleChanged(object sender, EventArgs e) {
            labelControl1.Text = (sender as ToggleSwitch).IsTurnedOn ? "ToggleOn" : "ToggleOFF";
        }

        class TestClass {
            public TestClass(bool v1, string v2) {
                value1 = v1;
                value2 = v2;
            }
            public bool value1 { set; get; }
            public string value2 { set; get; }

        }

       
   
    }
}



  
    

