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
            this.tbFirst = new System.Windows.Forms.TextBox();
            this.tbSecond = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThreadTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThreadTest2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThreadTest3)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpGridAsync.SuspendLayout();
            this.pGridAsyncLoad.SuspendLayout();
            this.tpBinding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBinding)).BeginInit();
            this.tpParallel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvThreadTest
            // 
            this.dgvThreadTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThreadTest.Location = new System.Drawing.Point(32, 82);
            this.dgvThreadTest.Name = "dgvThreadTest";
            this.dgvThreadTest.RowHeadersWidth = 62;
            this.dgvThreadTest.Size = new System.Drawing.Size(620, 254);
            this.dgvThreadTest.TabIndex = 1;
            // 
            // dgvThreadTest2
            // 
            this.dgvThreadTest2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThreadTest2.Location = new System.Drawing.Point(32, 342);
            this.dgvThreadTest2.Name = "dgvThreadTest2";
            this.dgvThreadTest2.RowHeadersWidth = 62;
            this.dgvThreadTest2.Size = new System.Drawing.Size(620, 254);
            this.dgvThreadTest2.TabIndex = 2;
            // 
            // dgvThreadTest3
            // 
            this.dgvThreadTest3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThreadTest3.Location = new System.Drawing.Point(658, 82);
            this.dgvThreadTest3.Name = "dgvThreadTest3";
            this.dgvThreadTest3.RowHeadersWidth = 62;
            this.dgvThreadTest3.Size = new System.Drawing.Size(620, 254);
            this.dgvThreadTest3.TabIndex = 3;
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(658, 343);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(282, 253);
            this.tbOutput.TabIndex = 4;
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpGridAsync);
            this.tcMain.Controls.Add(this.tpBinding);
            this.tcMain.Controls.Add(this.tpParallel);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 2;
            this.tcMain.Size = new System.Drawing.Size(771, 735);
            this.tcMain.TabIndex = 5;
            // 
            // tpGridAsync
            // 
            this.tpGridAsync.Controls.Add(this.pGridAsyncLoad);
            this.tpGridAsync.Location = new System.Drawing.Point(4, 22);
            this.tpGridAsync.Name = "tpGridAsync";
            this.tpGridAsync.Padding = new System.Windows.Forms.Padding(3);
            this.tpGridAsync.Size = new System.Drawing.Size(763, 709);
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
            this.pGridAsyncLoad.Location = new System.Drawing.Point(3, 3);
            this.pGridAsyncLoad.Name = "pGridAsyncLoad";
            this.pGridAsyncLoad.Size = new System.Drawing.Size(757, 703);
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
            this.tpBinding.Location = new System.Drawing.Point(4, 22);
            this.tpBinding.Name = "tpBinding";
            this.tpBinding.Padding = new System.Windows.Forms.Padding(3);
            this.tpBinding.Size = new System.Drawing.Size(763, 709);
            this.tpBinding.TabIndex = 1;
            this.tpBinding.Text = "Binding";
            this.tpBinding.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(731, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Index";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(731, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Street";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(731, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "City";
            // 
            // tbIndex
            // 
            this.tbIndex.Location = new System.Drawing.Point(811, 60);
            this.tbIndex.Name = "tbIndex";
            this.tbIndex.Size = new System.Drawing.Size(153, 20);
            this.tbIndex.TabIndex = 3;
            // 
            // tbStreetName
            // 
            this.tbStreetName.Location = new System.Drawing.Point(811, 33);
            this.tbStreetName.Name = "tbStreetName";
            this.tbStreetName.Size = new System.Drawing.Size(153, 20);
            this.tbStreetName.TabIndex = 2;
            // 
            // tbCityName
            // 
            this.tbCityName.Location = new System.Drawing.Point(811, 6);
            this.tbCityName.Name = "tbCityName";
            this.tbCityName.Size = new System.Drawing.Size(153, 20);
            this.tbCityName.TabIndex = 1;
            // 
            // dgBinding
            // 
            this.dgBinding.AllowUserToAddRows = false;
            this.dgBinding.AllowUserToDeleteRows = false;
            this.dgBinding.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBinding.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgBinding.Location = new System.Drawing.Point(3, 3);
            this.dgBinding.Name = "dgBinding";
            this.dgBinding.RowHeadersWidth = 62;
            this.dgBinding.Size = new System.Drawing.Size(682, 703);
            this.dgBinding.TabIndex = 0;
            // 
            // tpParallel
            // 
            this.tpParallel.Controls.Add(this.tbSecond);
            this.tpParallel.Controls.Add(this.tbFirst);
            this.tpParallel.Location = new System.Drawing.Point(4, 22);
            this.tpParallel.Name = "tpParallel";
            this.tpParallel.Padding = new System.Windows.Forms.Padding(3);
            this.tpParallel.Size = new System.Drawing.Size(763, 709);
            this.tpParallel.TabIndex = 2;
            this.tpParallel.Text = "BeginINvoke";
            this.tpParallel.UseVisualStyleBackColor = true;
            // 
            // tbFirst
            // 
            this.tbFirst.Location = new System.Drawing.Point(40, 40);
            this.tbFirst.Multiline = true;
            this.tbFirst.Name = "tbFirst";
            this.tbFirst.Size = new System.Drawing.Size(282, 253);
            this.tbFirst.TabIndex = 5;
            // 
            // tbSecond
            // 
            this.tbSecond.Location = new System.Drawing.Point(424, 40);
            this.tbSecond.Multiline = true;
            this.tbSecond.Name = "tbSecond";
            this.tbSecond.Size = new System.Drawing.Size(282, 253);
            this.tbSecond.TabIndex = 6;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 735);
            this.Controls.Add(this.tcMain);
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
    }
}

