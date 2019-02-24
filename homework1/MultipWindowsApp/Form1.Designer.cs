namespace MultipWindowsApp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.inputB = new System.Windows.Forms.TextBox();
            this.inputA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.TextBox();
            this.compute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputB
            // 
            this.inputB.Location = new System.Drawing.Point(218, 106);
            this.inputB.Name = "inputB";
            this.inputB.Size = new System.Drawing.Size(107, 25);
            this.inputB.TabIndex = 1;
            this.inputB.TextChanged += new System.EventHandler(this.NumB_TextChanged);
            // 
            // inputA
            // 
            this.inputA.Location = new System.Drawing.Point(63, 106);
            this.inputA.Name = "inputA";
            this.inputA.Size = new System.Drawing.Size(107, 25);
            this.inputA.TabIndex = 2;
            this.inputA.TextChanged += new System.EventHandler(this.numA_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number A";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number B";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Product";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(63, 213);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(100, 25);
            this.result.TabIndex = 6;
            // 
            // compute
            // 
            this.compute.Location = new System.Drawing.Point(229, 209);
            this.compute.Name = "compute";
            this.compute.Size = new System.Drawing.Size(96, 29);
            this.compute.TabIndex = 7;
            this.compute.Text = "compute";
            this.compute.UseVisualStyleBackColor = true;
            this.compute.Click += new System.EventHandler(this.compute_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 311);
            this.Controls.Add(this.compute);
            this.Controls.Add(this.result);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputA);
            this.Controls.Add(this.inputB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox inputB;
        private System.Windows.Forms.TextBox inputA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Button compute;
    }
}

