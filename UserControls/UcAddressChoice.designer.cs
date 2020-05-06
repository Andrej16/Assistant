namespace Assistant
{
    partial class UcAddressChoice
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Украина");
            this.layoutControlBase = new DevExpress.XtraLayout.LayoutControl();
            this.leSubaddrBuildingNum = new DevExpress.XtraEditors.LookUpEdit();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            this.tbSubaddrApartmentNum = new System.Windows.Forms.TextBox();
            this.treeViewAddress = new System.Windows.Forms.TreeView();
            this.beObjectName = new DevExpress.XtraEditors.ButtonEdit();
            this.layoutControlGroupBase = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemText = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemAddress = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemSubaddrApartmentNum = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBuildingNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.timerObjectNameChanged = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlBase)).BeginInit();
            this.layoutControlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leSubaddrBuildingNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beObjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSubaddrApartmentNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBuildingNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControlBase
            // 
            this.layoutControlBase.Controls.Add(this.leSubaddrBuildingNum);
            this.layoutControlBase.Controls.Add(this.simpleButtonCancel);
            this.layoutControlBase.Controls.Add(this.simpleButtonOk);
            this.layoutControlBase.Controls.Add(this.tbSubaddrApartmentNum);
            this.layoutControlBase.Controls.Add(this.treeViewAddress);
            this.layoutControlBase.Controls.Add(this.beObjectName);
            this.layoutControlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlBase.Location = new System.Drawing.Point(0, 0);
            this.layoutControlBase.Name = "layoutControlBase";
            this.layoutControlBase.Root = this.layoutControlGroupBase;
            this.layoutControlBase.Size = new System.Drawing.Size(411, 622);
            this.layoutControlBase.TabIndex = 0;
            this.layoutControlBase.Text = "layoutControl1";
            // 
            // leSubaddrBuildingNum
            // 
            this.leSubaddrBuildingNum.Location = new System.Drawing.Point(96, 540);
            this.leSubaddrBuildingNum.Name = "leSubaddrBuildingNum";
            this.leSubaddrBuildingNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.leSubaddrBuildingNum.Properties.DisplayMember = "Column";
            this.leSubaddrBuildingNum.Properties.NullText = "";
            this.leSubaddrBuildingNum.Properties.ValueMember = "Column";
            this.leSubaddrBuildingNum.Size = new System.Drawing.Size(303, 20);
            this.leSubaddrBuildingNum.StyleController = this.layoutControlBase;
            this.leSubaddrBuildingNum.TabIndex = 10;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Location = new System.Drawing.Point(207, 588);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(192, 22);
            this.simpleButtonCancel.StyleController = this.layoutControlBase;
            this.simpleButtonCancel.TabIndex = 9;
            this.simpleButtonCancel.Text = "Cancel";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.Location = new System.Drawing.Point(12, 588);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(191, 22);
            this.simpleButtonOk.StyleController = this.layoutControlBase;
            this.simpleButtonOk.TabIndex = 8;
            this.simpleButtonOk.Text = "OK";
            this.simpleButtonOk.Click += new System.EventHandler(this.simpleButtonOk_Click);
            // 
            // tbSubaddrApartmentNum
            // 
            this.tbSubaddrApartmentNum.Location = new System.Drawing.Point(96, 564);
            this.tbSubaddrApartmentNum.Name = "tbSubaddrApartmentNum";
            this.tbSubaddrApartmentNum.Size = new System.Drawing.Size(303, 20);
            this.tbSubaddrApartmentNum.TabIndex = 7;
            // 
            // treeViewAddress
            // 
            this.treeViewAddress.HideSelection = false;
            this.treeViewAddress.Location = new System.Drawing.Point(12, 52);
            this.treeViewAddress.Name = "treeViewAddress";
            treeNode1.Name = "nodeRoot";
            treeNode1.Text = "Украина";
            this.treeViewAddress.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeViewAddress.Size = new System.Drawing.Size(387, 484);
            this.treeViewAddress.TabIndex = 5;
            this.treeViewAddress.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewAddress_AfterSelect);
            // 
            // beObjectName
            // 
            this.beObjectName.Enabled = false;
            this.beObjectName.Location = new System.Drawing.Point(12, 28);
            this.beObjectName.Name = "beObjectName";
            this.beObjectName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beObjectName.Size = new System.Drawing.Size(387, 20);
            this.beObjectName.StyleController = this.layoutControlBase;
            this.beObjectName.TabIndex = 4;
            this.beObjectName.EditValueChanged += new System.EventHandler(this.beObjectName_EditValueChanged);
            // 
            // layoutControlGroupBase
            // 
            this.layoutControlGroupBase.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupBase.GroupBordersVisible = false;
            this.layoutControlGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemText,
            this.layoutControlItemAddress,
            this.layoutControlItemSubaddrApartmentNum,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItemBuildingNumber});
            this.layoutControlGroupBase.Name = "layoutControlGroupBase";
            this.layoutControlGroupBase.Size = new System.Drawing.Size(411, 622);
            this.layoutControlGroupBase.TextVisible = false;
            // 
            // layoutControlItemText
            // 
            this.layoutControlItemText.Control = this.beObjectName;
            this.layoutControlItemText.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemText.Name = "layoutControlItemText";
            this.layoutControlItemText.Size = new System.Drawing.Size(391, 40);
            this.layoutControlItemText.Text = "Название";
            this.layoutControlItemText.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItemText.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItemAddress
            // 
            this.layoutControlItemAddress.Control = this.treeViewAddress;
            this.layoutControlItemAddress.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItemAddress.Name = "layoutControlItemAddress";
            this.layoutControlItemAddress.Size = new System.Drawing.Size(391, 488);
            this.layoutControlItemAddress.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemAddress.TextVisible = false;
            // 
            // layoutControlItemSubaddrApartmentNum
            // 
            this.layoutControlItemSubaddrApartmentNum.Control = this.tbSubaddrApartmentNum;
            this.layoutControlItemSubaddrApartmentNum.Location = new System.Drawing.Point(0, 552);
            this.layoutControlItemSubaddrApartmentNum.Name = "layoutControlItemSubaddrApartmentNum";
            this.layoutControlItemSubaddrApartmentNum.Size = new System.Drawing.Size(391, 24);
            this.layoutControlItemSubaddrApartmentNum.Text = "Квартира";
            this.layoutControlItemSubaddrApartmentNum.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.simpleButtonOk;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 576);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(195, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButtonCancel;
            this.layoutControlItem2.Location = new System.Drawing.Point(195, 576);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(196, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItemBuildingNumber
            // 
            this.layoutControlItemBuildingNumber.Control = this.leSubaddrBuildingNum;
            this.layoutControlItemBuildingNumber.Location = new System.Drawing.Point(0, 528);
            this.layoutControlItemBuildingNumber.Name = "layoutControlItemBuildingNumber";
            this.layoutControlItemBuildingNumber.Size = new System.Drawing.Size(391, 24);
            this.layoutControlItemBuildingNumber.Text = "Номер строения";
            this.layoutControlItemBuildingNumber.TextSize = new System.Drawing.Size(81, 13);
            // 
            // timerObjectNameChanged
            // 
            this.timerObjectNameChanged.Interval = 500;
            this.timerObjectNameChanged.Tick += new System.EventHandler(this.timerObjectNameChanged_Tick);
            // 
            // UcAdrressChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControlBase);
            this.Name = "UcAdrressChoice";
            this.Size = new System.Drawing.Size(411, 622);
            this.Load += new System.EventHandler(this.UcAdrressChoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlBase)).EndInit();
            this.layoutControlBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leSubaddrBuildingNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beObjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSubaddrApartmentNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBuildingNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControlBase;
        private System.Windows.Forms.TextBox tbSubaddrApartmentNum;
        private System.Windows.Forms.TreeView treeViewAddress;
        private DevExpress.XtraEditors.ButtonEdit beObjectName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupBase;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemText;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemAddress;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemSubaddrApartmentNum;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LookUpEdit leSubaddrBuildingNum;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBuildingNumber;
        private System.Windows.Forms.Timer timerObjectNameChanged;
    }
}
