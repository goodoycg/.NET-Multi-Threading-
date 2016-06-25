namespace Thread
{
    partial class SemaphoreForm
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
            this.buttonEventWaitHandle = new System.Windows.Forms.Button();
            this.buttonTwoWaySignaling = new System.Windows.Forms.Button();
            this.buttonProducerConsumerQueue = new System.Windows.Forms.Button();
            this.buttonBlockingCollection = new System.Windows.Forms.Button();
            this.buttonManualResetEvent = new System.Windows.Forms.Button();
            this.buttonCountdownEvent = new System.Windows.Forms.Button();
            this.buttonEventWaitHandle2Process = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEventWaitHandle
            // 
            this.buttonEventWaitHandle.Location = new System.Drawing.Point(32, 0);
            this.buttonEventWaitHandle.Name = "buttonEventWaitHandle";
            this.buttonEventWaitHandle.Size = new System.Drawing.Size(477, 23);
            this.buttonEventWaitHandle.TabIndex = 0;
            this.buttonEventWaitHandle.Text = "使用EventWaitHandle信号量进行同步";
            this.buttonEventWaitHandle.UseVisualStyleBackColor = true;
            this.buttonEventWaitHandle.Click += new System.EventHandler(this.buttonEventWaitHandle_Click);
            // 
            // buttonTwoWaySignaling
            // 
            this.buttonTwoWaySignaling.Location = new System.Drawing.Point(32, 37);
            this.buttonTwoWaySignaling.Name = "buttonTwoWaySignaling";
            this.buttonTwoWaySignaling.Size = new System.Drawing.Size(477, 23);
            this.buttonTwoWaySignaling.TabIndex = 1;
            this.buttonTwoWaySignaling.Text = "双向信号灯";
            this.buttonTwoWaySignaling.UseVisualStyleBackColor = true;
            this.buttonTwoWaySignaling.Click += new System.EventHandler(this.buttonTwoWaySignaling_Click);
            // 
            // buttonProducerConsumerQueue
            // 
            this.buttonProducerConsumerQueue.Location = new System.Drawing.Point(32, 74);
            this.buttonProducerConsumerQueue.Name = "buttonProducerConsumerQueue";
            this.buttonProducerConsumerQueue.Size = new System.Drawing.Size(477, 23);
            this.buttonProducerConsumerQueue.TabIndex = 2;
            this.buttonProducerConsumerQueue.Text = "生产消费队列";
            this.buttonProducerConsumerQueue.UseVisualStyleBackColor = true;
            this.buttonProducerConsumerQueue.Click += new System.EventHandler(this.buttonProducerConsumerQueue_Click);
            // 
            // buttonBlockingCollection
            // 
            this.buttonBlockingCollection.Location = new System.Drawing.Point(32, 111);
            this.buttonBlockingCollection.Name = "buttonBlockingCollection";
            this.buttonBlockingCollection.Size = new System.Drawing.Size(477, 23);
            this.buttonBlockingCollection.TabIndex = 3;
            this.buttonBlockingCollection.Text = "一个新的类BlockingCollection实现了类似生产者消费者队列的功能。";
            this.buttonBlockingCollection.UseVisualStyleBackColor = true;
            this.buttonBlockingCollection.Click += new System.EventHandler(this.buttonBlockingCollection_Click);
            // 
            // buttonManualResetEvent
            // 
            this.buttonManualResetEvent.Location = new System.Drawing.Point(32, 148);
            this.buttonManualResetEvent.Name = "buttonManualResetEvent";
            this.buttonManualResetEvent.Size = new System.Drawing.Size(477, 23);
            this.buttonManualResetEvent.TabIndex = 4;
            this.buttonManualResetEvent.Text = "ManualResetEvent";
            this.buttonManualResetEvent.UseVisualStyleBackColor = true;
            this.buttonManualResetEvent.Click += new System.EventHandler(this.buttonManualResetEvent_Click);
            // 
            // buttonCountdownEvent
            // 
            this.buttonCountdownEvent.Location = new System.Drawing.Point(32, 185);
            this.buttonCountdownEvent.Name = "buttonCountdownEvent";
            this.buttonCountdownEvent.Size = new System.Drawing.Size(477, 23);
            this.buttonCountdownEvent.TabIndex = 5;
            this.buttonCountdownEvent.Text = "CountdownEvent";
            this.buttonCountdownEvent.UseVisualStyleBackColor = true;
            this.buttonCountdownEvent.Click += new System.EventHandler(this.buttonCountdownEvent_Click);
            // 
            // buttonEventWaitHandle2Process
            // 
            this.buttonEventWaitHandle2Process.Location = new System.Drawing.Point(32, 222);
            this.buttonEventWaitHandle2Process.Name = "buttonEventWaitHandle2Process";
            this.buttonEventWaitHandle2Process.Size = new System.Drawing.Size(477, 23);
            this.buttonEventWaitHandle2Process.TabIndex = 6;
            this.buttonEventWaitHandle2Process.Text = "创建跨进程的EventWaitHandle";
            this.buttonEventWaitHandle2Process.UseVisualStyleBackColor = true;
            this.buttonEventWaitHandle2Process.Click += new System.EventHandler(this.buttonEventWaitHandle2Process_Click);
            // 
            // SemaphoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 276);
            this.Controls.Add(this.buttonEventWaitHandle2Process);
            this.Controls.Add(this.buttonCountdownEvent);
            this.Controls.Add(this.buttonManualResetEvent);
            this.Controls.Add(this.buttonBlockingCollection);
            this.Controls.Add(this.buttonProducerConsumerQueue);
            this.Controls.Add(this.buttonTwoWaySignaling);
            this.Controls.Add(this.buttonEventWaitHandle);
            this.Name = "SemaphoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "细说.NET中的多线程 (五 使用信号量进行同步)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEventWaitHandle;
        private System.Windows.Forms.Button buttonTwoWaySignaling;
        private System.Windows.Forms.Button buttonProducerConsumerQueue;
        private System.Windows.Forms.Button buttonBlockingCollection;
        private System.Windows.Forms.Button buttonManualResetEvent;
        private System.Windows.Forms.Button buttonCountdownEvent;
        private System.Windows.Forms.Button buttonEventWaitHandle2Process;
    }
}