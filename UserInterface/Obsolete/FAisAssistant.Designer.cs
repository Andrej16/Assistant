namespace UserInterface
{
    partial class FAisAssistant
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.teProgName = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciSqlProcName = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.meResultCode = new DevExpress.XtraEditors.MemoEdit();
            this.lciCodeGenOut = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnOk = new System.Windows.Forms.Button();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.luProgType = new DevExpress.XtraEditors.LookUpEdit();
            this.lciProgType = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teProgName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSqlProcName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meResultCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCodeGenOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProgType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProgType)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.luProgType);
            this.lcMain.Controls.Add(this.btnOk);
            this.lcMain.Controls.Add(this.meResultCode);
            this.lcMain.Controls.Add(this.teProgName);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.Root = this.Root;
            this.lcMain.Size = new System.Drawing.Size(800, 450);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "layoutControl1";
            // 
            // teProgName
            // 
            this.teProgName.Location = new System.Drawing.Point(130, 12);
            this.teProgName.Name = "teProgName";
            this.teProgName.Size = new System.Drawing.Size(268, 20);
            this.teProgName.StyleController = this.lcMain;
            this.teProgName.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciSqlProcName,
            this.emptySpaceItem1,
            this.lciCodeGenOut,
            this.layoutControlItem1,
            this.lciProgType});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(800, 450);
            this.Root.TextVisible = false;
            // 
            // lciSqlProcName
            // 
            this.lciSqlProcName.Control = this.teProgName;
            this.lciSqlProcName.Location = new System.Drawing.Point(0, 0);
            this.lciSqlProcName.Name = "lciSqlProcName";
            this.lciSqlProcName.Size = new System.Drawing.Size(390, 24);
            this.lciSqlProcName.Text = "Название программы";
            this.lciSqlProcName.TextSize = new System.Drawing.Size(115, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 377);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(780, 53);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // meResultCode
            // 
            this.meResultCode.Location = new System.Drawing.Point(12, 52);
            this.meResultCode.Name = "meResultCode";
            this.meResultCode.Size = new System.Drawing.Size(776, 280);
            this.meResultCode.StyleController = this.lcMain;
            this.meResultCode.TabIndex = 5;
            // 
            // lciCodeGenOut
            // 
            this.lciCodeGenOut.Control = this.meResultCode;
            this.lciCodeGenOut.Location = new System.Drawing.Point(0, 24);
            this.lciCodeGenOut.Name = "lciCodeGenOut";
            this.lciCodeGenOut.Size = new System.Drawing.Size(780, 300);
            this.lciCodeGenOut.Text = "Результат генератора";
            this.lciCodeGenOut.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciCodeGenOut.TextSize = new System.Drawing.Size(115, 13);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 336);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(776, 49);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnOk;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 324);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(780, 53);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // luProgType
            // 
            this.luProgType.Location = new System.Drawing.Point(520, 12);
            this.luProgType.Name = "luProgType";
            this.luProgType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luProgType.Size = new System.Drawing.Size(268, 20);
            this.luProgType.StyleController = this.lcMain;
            this.luProgType.TabIndex = 7;
            // 
            // lciProgType
            // 
            this.lciProgType.Control = this.luProgType;
            this.lciProgType.Location = new System.Drawing.Point(390, 0);
            this.lciProgType.Name = "lciProgType";
            this.lciProgType.Size = new System.Drawing.Size(390, 24);
            this.lciProgType.Text = "Тип программы";
            this.lciProgType.TextSize = new System.Drawing.Size(115, 13);
            // 
            // FAisAssistant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lcMain);
            this.Name = "FAisAssistant";
            this.Text = "FAisAssistant";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teProgName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSqlProcName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meResultCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCodeGenOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProgType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProgType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit teProgName;
        private DevExpress.XtraLayout.LayoutControlItem lciSqlProcName;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.Button btnOk;
        private DevExpress.XtraEditors.MemoEdit meResultCode;
        private DevExpress.XtraLayout.LayoutControlItem lciCodeGenOut;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LookUpEdit luProgType;
        private DevExpress.XtraLayout.LayoutControlItem lciProgType;
    }
}