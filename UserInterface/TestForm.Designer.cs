namespace UserInterface
{
    partial class TestForm
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
            this.dgvThreadTest = new System.Windows.Forms.DataGridView();
            this.dgvThreadTest2 = new System.Windows.Forms.DataGridView();
            this.dgvThreadTest3 = new System.Windows.Forms.DataGridView();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpGridAsync = new System.Windows.Forms.TabPage();
            this.pGridAsyncLoad = new System.Windows.Forms.Panel();
            this.tpBinding = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbIndex = new System.Windows.Forms.TextBox();
            this.tbStreetName = new System.Windows.Forms.TextBox();
            this.tbCityName = new System.Windows.Forms.TextBox();
            this.dgBinding = new System.Windows.Forms.DataGridView();
            this.tpParallel = new System.Windows.Forms.TabPage();
            this.tbSecond = new System.Windows.Forms.TextBox();
            this.tbFirst = new System.Windows.Forms.TextBox();
            this.tpAsyncAwait = new System.Windows.Forms.TabPage();
            this.pAsyncAwait = new System.Windows.Forms.Panel();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.tbProccesOutput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThreadTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThreadTest2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThreadTest3)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpGridAsync.SuspendLayout();
            this.pGridAsyncLoad.SuspendLayout();
            this.tpBinding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBinding)).BeginInit();
            this.tpParallel.SuspendLayout();
            this.tpAsyncAwait.SuspendLayout();
            this.pAsyncAwait.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvThreadTest
            // 
            this.dgvThreadTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThreadTest.Location = new System.Drawing.Point(43, 101);
            this.dgvThreadTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvThreadTest.Name = "dgvThreadTest";
            this.dgvThreadTest.RowHeadersWidth = 62;
            this.dgvThreadTest.Size = new System.Drawing.Size(827, 313);
            this.dgvThreadTest.TabIndex = 1;
            // 
            // dgvThreadTest2
            // 
            this.dgvThreadTest2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThreadTest2.Location = new System.Drawing.Point(43, 421);
            this.dgvThreadTest2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvThreadTest2.Name = "dgvThreadTest2";
            this.dgvThreadTest2.RowHeadersWidth = 62;
            this.dgvThreadTest2.Size = new System.Drawing.Size(827, 313);
            this.dgvThreadTest2.TabIndex = 2;
            // 
            // dgvThreadTest3
            // 
            this.dgvThreadTest3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThreadTest3.Location = new System.Drawing.Point(877, 101);
            this.dgvThreadTest3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvThreadTest3.Name = "dgvThreadTest3";
            this.dgvThreadTest3.RowHeadersWidth = 62;
            this.dgvThreadTest3.Size = new System.Drawing.Size(827, 313);
            this.dgvThreadTest3.TabIndex = 3;
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(877, 422);
            this.tbOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(375, 310);
            this.tbOutput.TabIndex = 4;
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpGridAsync);
            this.tcMain.Controls.Add(this.tpBinding);
            this.tcMain.Controls.Add(this.tpParallel);
            this.tcMain.Controls.Add(this.tpAsyncAwait);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(1028, 905);
            this.tcMain.TabIndex = 5;
            // 
            // tpGridAsync
            // 
            this.tpGridAsync.Controls.Add(this.pGridAsyncLoad);
            this.tpGridAsync.Location = new System.Drawing.Point(4, 25);
            this.tpGridAsync.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpGridAsync.Name = "tpGridAsync";
            this.tpGridAsync.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpGridAsync.Size = new System.Drawing.Size(1020, 876);
            this.tpGridAsync.TabIndex = 0;
            this.tpGridAsync.Text = "Async loading";
            this.tpGridAsync.UseVisualStyleBackColor = true;
            // 
            // pGridAsyncLoad
            // 
            this.pGridAsyncLoad.Controls.Add(this.tbOutput);
            this.pGridAsyncLoad.Controls.Add(this.dgvThreadTest3);
            this.pGridAsyncLoad.Controls.Add(this.dgvThreadTest2);
            this.pGridAsyncLoad.Controls.Add(this.dgvThreadTest);
            this.pGridAsyncLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGridAsyncLoad.Location = new System.Drawing.Point(4, 4);
            this.pGridAsyncLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pGridAsyncLoad.Name = "pGridAsyncLoad";
            this.pGridAsyncLoad.Size = new System.Drawing.Size(1012, 868);
            this.pGridAsyncLoad.TabIndex = 5;
            // 
            // tpBinding
            // 
            this.tpBinding.Controls.Add(this.label3);
            this.tpBinding.Controls.Add(this.label2);
            this.tpBinding.Controls.Add(this.label1);
            this.tpBinding.Controls.Add(this.tbIndex);
            this.tpBinding.Controls.Add(this.tbStreetName);
            this.tpBinding.Controls.Add(this.tbCityName);
            this.tpBinding.Controls.Add(this.dgBinding);
            this.tpBinding.Location = new System.Drawing.Point(4, 25);
            this.tpBinding.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpBinding.Name = "tpBinding";
            this.tpBinding.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpBinding.Size = new System.Drawing.Size(1020, 876);
            this.tpBinding.TabIndex = 1;
            this.tpBinding.Text = "Binding";
            this.tpBinding.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(975, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Index";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(975, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Street";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(975, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "City";
            // 
            // tbIndex
            // 
            this.tbIndex.Location = new System.Drawing.Point(1081, 74);
            this.tbIndex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbIndex.Name = "tbIndex";
            this.tbIndex.Size = new System.Drawing.Size(203, 22);
            this.tbIndex.TabIndex = 3;
            // 
            // tbStreetName
            // 
            this.tbStreetName.Location = new System.Drawing.Point(1081, 41);
            this.tbStreetName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbStreetName.Name = "tbStreetName";
            this.tbStreetName.Size = new System.Drawing.Size(203, 22);
            this.tbStreetName.TabIndex = 2;
            // 
            // tbCityName
            // 
            this.tbCityName.Location = new System.Drawing.Point(1081, 7);
            this.tbCityName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbCityName.Name = "tbCityName";
            this.tbCityName.Size = new System.Drawing.Size(203, 22);
            this.tbCityName.TabIndex = 1;
            // 
            // dgBinding
            // 
            this.dgBinding.AllowUserToAddRows = false;
            this.dgBinding.AllowUserToDeleteRows = false;
            this.dgBinding.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBinding.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgBinding.Location = new System.Drawing.Point(4, 4);
            this.dgBinding.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgBinding.Name = "dgBinding";
            this.dgBinding.RowHeadersWidth = 62;
            this.dgBinding.Size = new System.Drawing.Size(909, 868);
            this.dgBinding.TabIndex = 0;
            // 
            // tpParallel
            // 
            this.tpParallel.Controls.Add(this.tbSecond);
            this.tpParallel.Controls.Add(this.tbFirst);
            this.tpParallel.Location = new System.Drawing.Point(4, 25);
            this.tpParallel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpParallel.Name = "tpParallel";
            this.tpParallel.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpParallel.Size = new System.Drawing.Size(1020, 876);
            this.tpParallel.TabIndex = 2;
            this.tpParallel.Text = "BeginINvoke";
            this.tpParallel.UseVisualStyleBackColor = true;
            // 
            // tbSecond
            // 
            this.tbSecond.Location = new System.Drawing.Point(565, 49);
            this.tbSecond.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbSecond.Multiline = true;
            this.tbSecond.Name = "tbSecond";
            this.tbSecond.Size = new System.Drawing.Size(375, 310);
            this.tbSecond.TabIndex = 6;
            // 
            // tbFirst
            // 
            this.tbFirst.Location = new System.Drawing.Point(53, 49);
            this.tbFirst.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbFirst.Multiline = true;
            this.tbFirst.Name = "tbFirst";
            this.tbFirst.Size = new System.Drawing.Size(375, 310);
            this.tbFirst.TabIndex = 5;
            // 
            // tpAsyncAwait
            // 
            this.tpAsyncAwait.Controls.Add(this.pAsyncAwait);
            this.tpAsyncAwait.Location = new System.Drawing.Point(4, 25);
            this.tpAsyncAwait.Name = "tpAsyncAwait";
            this.tpAsyncAwait.Padding = new System.Windows.Forms.Padding(3);
            this.tpAsyncAwait.Size = new System.Drawing.Size(1020, 876);
            this.tpAsyncAwait.TabIndex = 3;
            this.tpAsyncAwait.Text = "Async";
            this.tpAsyncAwait.UseVisualStyleBackColor = true;
            // 
            // pAsyncAwait
            // 
            this.pAsyncAwait.Controls.Add(this.tbProccesOutput);
            this.pAsyncAwait.Controls.Add(this.btnDisconnect);
            this.pAsyncAwait.Controls.Add(this.btnGetData);
            this.pAsyncAwait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAsyncAwait.Location = new System.Drawing.Point(3, 3);
            this.pAsyncAwait.Name = "pAsyncAwait";
            this.pAsyncAwait.Size = new System.Drawing.Size(1014, 870);
            this.pAsyncAwait.TabIndex = 0;
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(40, 62);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(129, 67);
            this.btnGetData.TabIndex = 0;
            this.btnGetData.Text = "GetData";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(311, 62);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(145, 67);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // tbProccesOutput
            // 
            this.tbProccesOutput.Location = new System.Drawing.Point(40, 136);
            this.tbProccesOutput.Multiline = true;
            this.tbProccesOutput.Name = "tbProccesOutput";
            this.tbProccesOutput.Size = new System.Drawing.Size(416, 120);
            this.tbProccesOutput.TabIndex = 2;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 905);
            this.Controls.Add(this.tcMain);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TestForm";
            this.Text = "Test UI";
            this.Load += new System.EventHandler(this.TestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThreadTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThreadTest2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThreadTest3)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tpGridAsync.ResumeLayout(false);
            this.pGridAsyncLoad.ResumeLayout(false);
            this.pGridAsyncLoad.PerformLayout();
            this.tpBinding.ResumeLayout(false);
            this.tpBinding.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBinding)).EndInit();
            this.tpParallel.ResumeLayout(false);
            this.tpParallel.PerformLayout();
            this.tpAsyncAwait.ResumeLayout(false);
            this.pAsyncAwait.ResumeLayout(false);
            this.pAsyncAwait.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvThreadTest;
        public System.Windows.Forms.DataGridView dgvThreadTest2;
        public System.Windows.Forms.DataGridView dgvThreadTest3;
        public System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpGridAsync;
        private System.Windows.Forms.TabPage tpBinding;
        private System.Windows.Forms.Panel pGridAsyncLoad;
        public System.Windows.Forms.DataGridView dgBinding;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbIndex;
        public System.Windows.Forms.TextBox tbStreetName;
        public System.Windows.Forms.TextBox tbCityName;
        private System.Windows.Forms.TabPage tpParallel;
        public System.Windows.Forms.TextBox tbSecond;
        public System.Windows.Forms.TextBox tbFirst;
        private System.Windows.Forms.Panel pAsyncAwait;
        public System.Windows.Forms.TabPage tpAsyncAwait;
        public System.Windows.Forms.TextBox tbProccesOutput;
        public System.Windows.Forms.Button btnDisconnect;
        public System.Windows.Forms.Button btnGetData;
    }
}

