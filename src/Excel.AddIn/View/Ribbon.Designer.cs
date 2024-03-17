namespace Excel.AddIn
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.tab = this.Factory.CreateRibbonTab();
            this.groupSerialize = this.Factory.CreateRibbonGroup();
            this.btnCreateClassFile = this.Factory.CreateRibbonButton();
            this.groupSetting = this.Factory.CreateRibbonGroup();
            this.btnSettings = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.tab.SuspendLayout();
            this.groupSerialize.SuspendLayout();
            this.groupSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // tab
            // 
            this.tab.Groups.Add(this.groupSerialize);
            this.tab.Groups.Add(this.groupSetting);
            this.tab.Label = "FB Serializer";
            this.tab.Name = "tab";
            // 
            // groupSerialize
            // 
            this.groupSerialize.Items.Add(this.btnCreateClassFile);
            this.groupSerialize.Label = "Serialize";
            this.groupSerialize.Name = "groupSerialize";
            // 
            // btnCreateClassFile
            // 
            this.btnCreateClassFile.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnCreateClassFile.Label = "클래스 생성";
            this.btnCreateClassFile.Name = "btnCreateClassFile";
            this.btnCreateClassFile.ShowImage = true;
            this.btnCreateClassFile.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnCreateClassFile_Click);
            // 
            // groupSetting
            // 
            this.groupSetting.Items.Add(this.btnSettings);
            this.groupSetting.Label = "Settings";
            this.groupSetting.Name = "groupSetting";
            // 
            // btnSettings
            // 
            this.btnSettings.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnSettings.Label = "설정";
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.ShowImage = true;
            this.btnSettings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSettings_Click);
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Tabs.Add(this.tab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.tab.ResumeLayout(false);
            this.tab.PerformLayout();
            this.groupSerialize.ResumeLayout(false);
            this.groupSerialize.PerformLayout();
            this.groupSetting.ResumeLayout(false);
            this.groupSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        private Microsoft.Office.Tools.Ribbon.RibbonTab tab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupSerialize;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupSetting;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCreateClassFile;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSettings;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon1
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
