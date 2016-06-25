namespace Thread
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
            this.btnCreateThread = new System.Windows.Forms.Button();
            this.btnThreadPara = new System.Windows.Forms.Button();
            this.btnThreadException = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateThread
            // 
            this.btnCreateThread.Location = new System.Drawing.Point(12, 12);
            this.btnCreateThread.Name = "btnCreateThread";
            this.btnCreateThread.Size = new System.Drawing.Size(381, 23);
            this.btnCreateThread.TabIndex = 0;
            this.btnCreateThread.Text = "创建线程";
            this.btnCreateThread.UseVisualStyleBackColor = true;
            this.btnCreateThread.Click += new System.EventHandler(this.btnCreateThread_Click);
            // 
            // btnThreadPara
            // 
            this.btnThreadPara.Location = new System.Drawing.Point(12, 70);
            this.btnThreadPara.Name = "btnThreadPara";
            this.btnThreadPara.Size = new System.Drawing.Size(381, 23);
            this.btnThreadPara.TabIndex = 1;
            this.btnThreadPara.Text = "使用匿名方法的闭包特性可以很方便的为线程传递参数";
            this.btnThreadPara.UseVisualStyleBackColor = true;
            this.btnThreadPara.Click += new System.EventHandler(this.btnThreadPara_Click);
            // 
            // btnThreadException
            // 
            this.btnThreadException.Location = new System.Drawing.Point(12, 41);
            this.btnThreadException.Name = "btnThreadException";
            this.btnThreadException.Size = new System.Drawing.Size(381, 23);
            this.btnThreadException.TabIndex = 2;
            this.btnThreadException.Text = "线程中可能需要捕获异常";
            this.btnThreadException.UseVisualStyleBackColor = true;
            this.btnThreadException.Click += new System.EventHandler(this.btnThreadException_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 109);
            this.Controls.Add(this.btnThreadException);
            this.Controls.Add(this.btnThreadPara);
            this.Controls.Add(this.btnCreateThread);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "细说.NET 中的多线程 (一 概念)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateThread;
        private System.Windows.Forms.Button btnThreadPara;
        private System.Windows.Forms.Button btnThreadException;
    }
}

