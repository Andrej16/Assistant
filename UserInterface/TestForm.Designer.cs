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
            ((System.ComponentModel.ISupportInitialize)(this.dgvThreadTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThreadTest2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThreadTest3)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvThreadTest
            // 
            this.dgvThreadTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThreadTest.Location = new System.Drawing.Point(32, 82);
            this.dgvThreadTest.Name = "dgvThreadTest";
            this.dgvThreadTest.Size = new System.Drawing.Size(620, 254);
            this.dgvThreadTest.TabIndex = 1;
            // 
            // dgvThreadTest2
            // 
            this.dgvThreadTest2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThreadTest2.Location = new System.Drawing.Point(32, 342);
            this.dgvThreadTest2.Name = "dgvThreadTest2";
            this.dgvThreadTest2.Size = new System.Drawing.Size(620, 254);
            this.dgvThreadTest2.TabIndex = 2;
            // 
            // dgvThreadTest3
            // 
            this.dgvThreadTest3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThreadTest3.Location = new System.Drawing.Point(658, 82);
            this.dgvThreadTest3.Name = "dgvThreadTest3";
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
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 683);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.dgvThreadTest3);
            this.Controls.Add(this.dgvThreadTest2);
            this.Controls.Add(this.dgvThreadTest);
            this.Name = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThreadTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThreadTest2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThreadTest3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvThreadTest;
        public System.Windows.Forms.DataGridView dgvThreadTest2;
        public System.Windows.Forms.DataGridView dgvThreadTest3;
        public System.Windows.Forms.TextBox tbOutput;
    }
}

