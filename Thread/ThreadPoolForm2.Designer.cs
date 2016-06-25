namespace Thread
{
    partial class ThreadPoolForm2
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
            this.btnAsyncDelegate = new System.Windows.Forms.Button();
            this.btnTaskWaitThreadOver = new System.Windows.Forms.Button();
            this.btnTaskGetReturnValue = new System.Windows.Forms.Button();
            this.btnThreadPool = new System.Windows.Forms.Button();
            this.btnAsyncDelegate2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAsyncDelegate
            // 
            this.btnAsyncDelegate.Location = new System.Drawing.Point(68, 108);
            this.btnAsyncDelegate.Name = "btnAsyncDelegate";
            this.btnAsyncDelegate.Size = new System.Drawing.Size(281, 23);
            this.btnAsyncDelegate.TabIndex = 0;
            this.btnAsyncDelegate.Text = "阻塞的方式执行异步委托";
            this.btnAsyncDelegate.UseVisualStyleBackColor = true;
            this.btnAsyncDelegate.Click += new System.EventHandler(this.btnAsyncDelegate_Click);
            // 
            // btnTaskWaitThreadOver
            // 
            this.btnTaskWaitThreadOver.Location = new System.Drawing.Point(68, 77);
            this.btnTaskWaitThreadOver.Name = "btnTaskWaitThreadOver";
            this.btnTaskWaitThreadOver.Size = new System.Drawing.Size(281, 23);
            this.btnTaskWaitThreadOver.TabIndex = 1;
            this.btnTaskWaitThreadOver.Text = "使用Task来等待线程结束";
            this.btnTaskWaitThreadOver.UseVisualStyleBackColor = true;
            this.btnTaskWaitThreadOver.Click += new System.EventHandler(this.btnTaskWaitThreadOver_Click);
            // 
            // btnTaskGetReturnValue
            // 
            this.btnTaskGetReturnValue.Location = new System.Drawing.Point(68, 46);
            this.btnTaskGetReturnValue.Name = "btnTaskGetReturnValue";
            this.btnTaskGetReturnValue.Size = new System.Drawing.Size(281, 23);
            this.btnTaskGetReturnValue.TabIndex = 2;
            this.btnTaskGetReturnValue.Text = "Task来获得线程的返回值";
            this.btnTaskGetReturnValue.UseVisualStyleBackColor = true;
            this.btnTaskGetReturnValue.Click += new System.EventHandler(this.btnTaskGetReturnValue_Click);
            // 
            // btnThreadPool
            // 
            this.btnThreadPool.Location = new System.Drawing.Point(68, 15);
            this.btnThreadPool.Name = "btnThreadPool";
            this.btnThreadPool.Size = new System.Drawing.Size(281, 23);
            this.btnThreadPool.TabIndex = 3;
            this.btnThreadPool.Text = "线程池";
            this.btnThreadPool.UseVisualStyleBackColor = true;
            this.btnThreadPool.Click += new System.EventHandler(this.btnThreadPool_Click);
            // 
            // btnAsyncDelegate2
            // 
            this.btnAsyncDelegate2.Location = new System.Drawing.Point(68, 139);
            this.btnAsyncDelegate2.Name = "btnAsyncDelegate2";
            this.btnAsyncDelegate2.Size = new System.Drawing.Size(281, 23);
            this.btnAsyncDelegate2.TabIndex = 4;
            this.btnAsyncDelegate2.Text = "非阻塞的方式执行异步委托";
            this.btnAsyncDelegate2.UseVisualStyleBackColor = true;
            this.btnAsyncDelegate2.Click += new System.EventHandler(this.btnAsyncDelegate2_Click);
            // 
            // ThreadPoolForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 180);
            this.Controls.Add(this.btnAsyncDelegate2);
            this.Controls.Add(this.btnThreadPool);
            this.Controls.Add(this.btnTaskGetReturnValue);
            this.Controls.Add(this.btnTaskWaitThreadOver);
            this.Controls.Add(this.btnAsyncDelegate);
            this.Name = "ThreadPoolForm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "细说.NET中的多线程 (二 线程池)";
            this.Load += new System.EventHandler(this.ThreadPoolForm2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAsyncDelegate;
        private System.Windows.Forms.Button btnTaskWaitThreadOver;
        private System.Windows.Forms.Button btnTaskGetReturnValue;
        private System.Windows.Forms.Button btnThreadPool;
        private System.Windows.Forms.Button btnAsyncDelegate2;
    }
}