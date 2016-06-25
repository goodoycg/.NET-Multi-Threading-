namespace Thread
{
    partial class Lock
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
            this.btnLockMonitor = new System.Windows.Forms.Button();
            this.btnLockTaken = new System.Windows.Forms.Button();
            this.btnWhenUseLock = new System.Windows.Forms.Button();
            this.btnReentrant = new System.Windows.Forms.Button();
            this.btnMutex = new System.Windows.Forms.Button();
            this.btnSemaphore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLockMonitor
            // 
            this.btnLockMonitor.Location = new System.Drawing.Point(12, 12);
            this.btnLockMonitor.Name = "btnLockMonitor";
            this.btnLockMonitor.Size = new System.Drawing.Size(411, 23);
            this.btnLockMonitor.TabIndex = 0;
            this.btnLockMonitor.Text = "通过锁来实现同步 Monitor.Enter和Monitor.Exit";
            this.btnLockMonitor.UseVisualStyleBackColor = true;
            this.btnLockMonitor.Click += new System.EventHandler(this.btnLockMonitor_Click);
            // 
            // btnLockTaken
            // 
            this.btnLockTaken.Location = new System.Drawing.Point(12, 40);
            this.btnLockTaken.Name = "btnLockTaken";
            this.btnLockTaken.Size = new System.Drawing.Size(411, 23);
            this.btnLockTaken.TabIndex = 1;
            this.btnLockTaken.Text = "LockTaken版本：";
            this.btnLockTaken.UseVisualStyleBackColor = true;
            this.btnLockTaken.Click += new System.EventHandler(this.btnLockTaken_Click);
            // 
            // btnWhenUseLock
            // 
            this.btnWhenUseLock.Location = new System.Drawing.Point(12, 68);
            this.btnWhenUseLock.Name = "btnWhenUseLock";
            this.btnWhenUseLock.Size = new System.Drawing.Size(411, 23);
            this.btnWhenUseLock.TabIndex = 2;
            this.btnWhenUseLock.Text = "什么时候使用lock";
            this.btnWhenUseLock.UseVisualStyleBackColor = true;
            this.btnWhenUseLock.Click += new System.EventHandler(this.btnWhenUseLock_Click);
            // 
            // btnReentrant
            // 
            this.btnReentrant.Location = new System.Drawing.Point(12, 96);
            this.btnReentrant.Name = "btnReentrant";
            this.btnReentrant.Size = new System.Drawing.Size(411, 23);
            this.btnReentrant.TabIndex = 3;
            this.btnReentrant.Text = "关于嵌套锁或者reentrant";
            this.btnReentrant.UseVisualStyleBackColor = true;
            this.btnReentrant.Click += new System.EventHandler(this.btnReentrant_Click);
            // 
            // btnMutex
            // 
            this.btnMutex.Location = new System.Drawing.Point(12, 125);
            this.btnMutex.Name = "btnMutex";
            this.btnMutex.Size = new System.Drawing.Size(411, 23);
            this.btnMutex.TabIndex = 4;
            this.btnMutex.Text = "Mutex";
            this.btnMutex.UseVisualStyleBackColor = true;
            this.btnMutex.Click += new System.EventHandler(this.btnMutex_Click);
            // 
            // btnSemaphore
            // 
            this.btnSemaphore.Location = new System.Drawing.Point(12, 149);
            this.btnSemaphore.Name = "btnSemaphore";
            this.btnSemaphore.Size = new System.Drawing.Size(411, 23);
            this.btnSemaphore.TabIndex = 5;
            this.btnSemaphore.Text = "Semaphore";
            this.btnSemaphore.UseVisualStyleBackColor = true;
            this.btnSemaphore.Click += new System.EventHandler(this.btnSemaphore_Click);
            // 
            // Lock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 184);
            this.Controls.Add(this.btnSemaphore);
            this.Controls.Add(this.btnMutex);
            this.Controls.Add(this.btnReentrant);
            this.Controls.Add(this.btnWhenUseLock);
            this.Controls.Add(this.btnLockTaken);
            this.Controls.Add(this.btnLockMonitor);
            this.Name = "Lock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "细说.NET中的多线程 (四 使用锁进行同步)";
            this.Load += new System.EventHandler(this.Lock_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLockMonitor;
        private System.Windows.Forms.Button btnLockTaken;
        private System.Windows.Forms.Button btnWhenUseLock;
        private System.Windows.Forms.Button btnReentrant;
        private System.Windows.Forms.Button btnMutex;
        private System.Windows.Forms.Button btnSemaphore;
    }
}