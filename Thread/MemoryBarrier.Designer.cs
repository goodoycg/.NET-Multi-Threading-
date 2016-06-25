namespace Thread
{
    partial class MemoryBarrier
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
            this.buttonMemoryBarriers = new System.Windows.Forms.Button();
            this.buttonvolatile = new System.Windows.Forms.Button();
            this.buttonVolatileRead2VolatileWrite = new System.Windows.Forms.Button();
            this.buttonInterlocked = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonMemoryBarriers
            // 
            this.buttonMemoryBarriers.Location = new System.Drawing.Point(42, 9);
            this.buttonMemoryBarriers.Name = "buttonMemoryBarriers";
            this.buttonMemoryBarriers.Size = new System.Drawing.Size(406, 23);
            this.buttonMemoryBarriers.TabIndex = 0;
            this.buttonMemoryBarriers.Text = "MemoryBarriers";
            this.buttonMemoryBarriers.UseVisualStyleBackColor = true;
            this.buttonMemoryBarriers.Click += new System.EventHandler(this.buttonMemoryBarriers_Click);
            // 
            // buttonvolatile
            // 
            this.buttonvolatile.Location = new System.Drawing.Point(42, 60);
            this.buttonvolatile.Name = "buttonvolatile";
            this.buttonvolatile.Size = new System.Drawing.Size(406, 23);
            this.buttonvolatile.TabIndex = 1;
            this.buttonvolatile.Text = "volatile关键字";
            this.buttonvolatile.UseVisualStyleBackColor = true;
            this.buttonvolatile.Click += new System.EventHandler(this.buttonvolatile_Click);
            // 
            // buttonVolatileRead2VolatileWrite
            // 
            this.buttonVolatileRead2VolatileWrite.Location = new System.Drawing.Point(42, 111);
            this.buttonVolatileRead2VolatileWrite.Name = "buttonVolatileRead2VolatileWrite";
            this.buttonVolatileRead2VolatileWrite.Size = new System.Drawing.Size(406, 23);
            this.buttonVolatileRead2VolatileWrite.TabIndex = 2;
            this.buttonVolatileRead2VolatileWrite.Text = "VolatileRead和VolatileWrite";
            this.buttonVolatileRead2VolatileWrite.UseVisualStyleBackColor = true;
            this.buttonVolatileRead2VolatileWrite.Click += new System.EventHandler(this.buttonVolatileRead2VolatileWrite_Click);
            // 
            // buttonInterlocked
            // 
            this.buttonInterlocked.Location = new System.Drawing.Point(42, 162);
            this.buttonInterlocked.Name = "buttonInterlocked";
            this.buttonInterlocked.Size = new System.Drawing.Size(406, 23);
            this.buttonInterlocked.TabIndex = 3;
            this.buttonInterlocked.Text = "Interlocked";
            this.buttonInterlocked.UseVisualStyleBackColor = true;
            this.buttonInterlocked.Click += new System.EventHandler(this.buttonInterlocked_Click);
            // 
            // MemoryBarrier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 203);
            this.Controls.Add(this.buttonInterlocked);
            this.Controls.Add(this.buttonVolatileRead2VolatileWrite);
            this.Controls.Add(this.buttonvolatile);
            this.Controls.Add(this.buttonMemoryBarriers);
            this.Name = "MemoryBarrier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "细说.NET中的多线程 (六 使用MemoryBarrier，Volatile进行同步)";
            this.Load += new System.EventHandler(this.MemoryBarrier_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonMemoryBarriers;
        private System.Windows.Forms.Button buttonvolatile;
        private System.Windows.Forms.Button buttonVolatileRead2VolatileWrite;
        private System.Windows.Forms.Button buttonInterlocked;
    }
}