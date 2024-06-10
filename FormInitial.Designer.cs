namespace a3_202401
{
    partial class FormInitial
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelTasks = new Label();
            buttonCreateTask = new Button();
            listBox = new ListBox();
            process1 = new System.Diagnostics.Process();
            SuspendLayout();
            // 
            // labelTasks
            // 
            labelTasks.AutoSize = true;
            labelTasks.BorderStyle = BorderStyle.Fixed3D;
            labelTasks.Font = new Font("Segoe UI", 20F);
            labelTasks.Location = new Point(147, 9);
            labelTasks.Name = "labelTasks";
            labelTasks.Size = new Size(100, 39);
            labelTasks.TabIndex = 0;
            labelTasks.Text = "Tarefas";
            labelTasks.Click += label1_Click;
            // 
            // buttonCreateTask
            // 
            buttonCreateTask.Location = new Point(120, 61);
            buttonCreateTask.Name = "buttonCreateTask";
            buttonCreateTask.Size = new Size(152, 23);
            buttonCreateTask.TabIndex = 1;
            buttonCreateTask.Text = "+ CRIAR TAREFA";
            buttonCreateTask.UseVisualStyleBackColor = true;
            buttonCreateTask.Click += buttonCreateTask_Click;
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 15;
            listBox.Location = new Point(95, 100);
            listBox.Name = "listBox";
            listBox.Size = new Size(207, 184);
            listBox.TabIndex = 2;
            listBox.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // process1
            // 
            process1.StartInfo.Domain = "";
            process1.StartInfo.LoadUserProfile = false;
            process1.StartInfo.Password = null;
            process1.StartInfo.StandardErrorEncoding = null;
            process1.StartInfo.StandardInputEncoding = null;
            process1.StartInfo.StandardOutputEncoding = null;
            process1.StartInfo.UseCredentialsForNetworkingOnly = false;
            process1.StartInfo.UserName = "";
            process1.SynchronizingObject = this;
            // 
            // FormInitial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 296);
            Controls.Add(listBox);
            Controls.Add(buttonCreateTask);
            Controls.Add(labelTasks);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormInitial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tarefas";
            Load += FormInitial_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTasks;
        private Button buttonCreateTask;
        private ListBox listBox;
        private System.Diagnostics.Process process1;
    }
}
