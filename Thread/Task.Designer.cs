namespace Thread
{
    partial class Task
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
            this.btnInitCreatTask = new System.Windows.Forms.Button();
            this.btnDefaultParaCreateTask = new System.Windows.Forms.Button();
            this.btnCreateTaskOfOpentions = new System.Windows.Forms.Button();
            this.btnWaitTask = new System.Windows.Forms.Button();
            this.btnTaskException = new System.Windows.Forms.Button();
            this.btnSubTask = new System.Windows.Forms.Button();
            this.btnCancelTask = new System.Windows.Forms.Button();
            this.btnTaskContinuationsRun = new System.Windows.Forms.Button();
            this.btnTaskSub = new System.Windows.Forms.Button();
            this.btnTaskFactory = new System.Windows.Forms.Button();
            this.btnParallel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInitCreatTask
            // 
            this.btnInitCreatTask.Location = new System.Drawing.Point(49, 21);
            this.btnInitCreatTask.Name = "btnInitCreatTask";
            this.btnInitCreatTask.Size = new System.Drawing.Size(260, 23);
            this.btnInitCreatTask.TabIndex = 0;
            this.btnInitCreatTask.Text = "创建并且初始化Task";
            this.btnInitCreatTask.UseVisualStyleBackColor = true;
            this.btnInitCreatTask.Click += new System.EventHandler(this.btnInitCreatTask_Click);
            // 
            // btnDefaultParaCreateTask
            // 
            this.btnDefaultParaCreateTask.Location = new System.Drawing.Point(49, 51);
            this.btnDefaultParaCreateTask.Name = "btnDefaultParaCreateTask";
            this.btnDefaultParaCreateTask.Size = new System.Drawing.Size(260, 23);
            this.btnDefaultParaCreateTask.TabIndex = 1;
            this.btnDefaultParaCreateTask.Text = "用默认参数的委托创建Task";
            this.btnDefaultParaCreateTask.UseVisualStyleBackColor = true;
            this.btnDefaultParaCreateTask.Click += new System.EventHandler(this.btnDefaultParaCreateTask_Click);
            // 
            // btnCreateTaskOfOpentions
            // 
            this.btnCreateTaskOfOpentions.Location = new System.Drawing.Point(50, 81);
            this.btnCreateTaskOfOpentions.Name = "btnCreateTaskOfOpentions";
            this.btnCreateTaskOfOpentions.Size = new System.Drawing.Size(259, 23);
            this.btnCreateTaskOfOpentions.TabIndex = 2;
            this.btnCreateTaskOfOpentions.Text = "指定创建Task的一些相关选项";
            this.btnCreateTaskOfOpentions.UseVisualStyleBackColor = true;
            this.btnCreateTaskOfOpentions.Click += new System.EventHandler(this.btnCreateTaskOfOpentions_Click);
            // 
            // btnWaitTask
            // 
            this.btnWaitTask.Location = new System.Drawing.Point(49, 111);
            this.btnWaitTask.Name = "btnWaitTask";
            this.btnWaitTask.Size = new System.Drawing.Size(260, 23);
            this.btnWaitTask.TabIndex = 3;
            this.btnWaitTask.Text = "等待Task";
            this.btnWaitTask.UseVisualStyleBackColor = true;
            this.btnWaitTask.Click += new System.EventHandler(this.btnWaitTask_Click);
            // 
            // btnTaskException
            // 
            this.btnTaskException.Location = new System.Drawing.Point(49, 141);
            this.btnTaskException.Name = "btnTaskException";
            this.btnTaskException.Size = new System.Drawing.Size(260, 23);
            this.btnTaskException.TabIndex = 4;
            this.btnTaskException.Text = "Task异常处理";
            this.btnTaskException.UseVisualStyleBackColor = true;
            this.btnTaskException.Click += new System.EventHandler(this.btnTaskException_Click);
            // 
            // btnSubTask
            // 
            this.btnSubTask.Location = new System.Drawing.Point(50, 171);
            this.btnSubTask.Name = "btnSubTask";
            this.btnSubTask.Size = new System.Drawing.Size(259, 23);
            this.btnSubTask.TabIndex = 5;
            this.btnSubTask.Text = "有父子关系的Task";
            this.btnSubTask.UseVisualStyleBackColor = true;
            this.btnSubTask.Click += new System.EventHandler(this.btnSubTask_Click);
            // 
            // btnCancelTask
            // 
            this.btnCancelTask.Location = new System.Drawing.Point(50, 201);
            this.btnCancelTask.Name = "btnCancelTask";
            this.btnCancelTask.Size = new System.Drawing.Size(259, 23);
            this.btnCancelTask.TabIndex = 6;
            this.btnCancelTask.Text = "取消Task";
            this.btnCancelTask.UseVisualStyleBackColor = true;
            this.btnCancelTask.Click += new System.EventHandler(this.btnCancelTask_Click);
            // 
            // btnTaskContinuationsRun
            // 
            this.btnTaskContinuationsRun.Location = new System.Drawing.Point(50, 231);
            this.btnTaskContinuationsRun.Name = "btnTaskContinuationsRun";
            this.btnTaskContinuationsRun.Size = new System.Drawing.Size(259, 23);
            this.btnTaskContinuationsRun.TabIndex = 7;
            this.btnTaskContinuationsRun.Text = "任务的连续执行";
            this.btnTaskContinuationsRun.UseVisualStyleBackColor = true;
            this.btnTaskContinuationsRun.Click += new System.EventHandler(this.btnTaskContinuationsRun_Click);
            // 
            // btnTaskSub
            // 
            this.btnTaskSub.Location = new System.Drawing.Point(50, 261);
            this.btnTaskSub.Name = "btnTaskSub";
            this.btnTaskSub.Size = new System.Drawing.Size(259, 23);
            this.btnTaskSub.TabIndex = 8;
            this.btnTaskSub.Text = "子任务";
            this.btnTaskSub.UseVisualStyleBackColor = true;
            this.btnTaskSub.Click += new System.EventHandler(this.btnTaskSub_Click);
            // 
            // btnTaskFactory
            // 
            this.btnTaskFactory.Location = new System.Drawing.Point(50, 291);
            this.btnTaskFactory.Name = "btnTaskFactory";
            this.btnTaskFactory.Size = new System.Drawing.Size(259, 23);
            this.btnTaskFactory.TabIndex = 9;
            this.btnTaskFactory.Text = "TaskFactory";
            this.btnTaskFactory.UseVisualStyleBackColor = true;
            this.btnTaskFactory.Click += new System.EventHandler(this.btnTaskFactory_Click);
            // 
            // btnParallel
            // 
            this.btnParallel.Location = new System.Drawing.Point(50, 321);
            this.btnParallel.Name = "btnParallel";
            this.btnParallel.Size = new System.Drawing.Size(259, 23);
            this.btnParallel.TabIndex = 10;
            this.btnParallel.Text = "Parallel的For，Foreach，Invoke 方法";
            this.btnParallel.UseVisualStyleBackColor = true;
            this.btnParallel.Click += new System.EventHandler(this.btnParallel_Click);
            // 
            // Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 372);
            this.Controls.Add(this.btnParallel);
            this.Controls.Add(this.btnTaskFactory);
            this.Controls.Add(this.btnTaskSub);
            this.Controls.Add(this.btnTaskContinuationsRun);
            this.Controls.Add(this.btnCancelTask);
            this.Controls.Add(this.btnSubTask);
            this.Controls.Add(this.btnTaskException);
            this.Controls.Add(this.btnWaitTask);
            this.Controls.Add(this.btnCreateTaskOfOpentions);
            this.Controls.Add(this.btnDefaultParaCreateTask);
            this.Controls.Add(this.btnInitCreatTask);
            this.Name = "Task";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "细说.NET中的多线程 (三 使用Task)";
            this.Load += new System.EventHandler(this.Task_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInitCreatTask;
        private System.Windows.Forms.Button btnDefaultParaCreateTask;
        private System.Windows.Forms.Button btnCreateTaskOfOpentions;
        private System.Windows.Forms.Button btnWaitTask;
        private System.Windows.Forms.Button btnTaskException;
        private System.Windows.Forms.Button btnSubTask;
        private System.Windows.Forms.Button btnCancelTask;
        private System.Windows.Forms.Button btnTaskContinuationsRun;
        private System.Windows.Forms.Button btnTaskSub;
        private System.Windows.Forms.Button btnTaskFactory;
        private System.Windows.Forms.Button btnParallel;
    }
}