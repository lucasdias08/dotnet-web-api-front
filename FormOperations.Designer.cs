using System.Windows.Forms;

namespace a3_202401
{
    partial class FormOperations
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
            labelTitle = new Label();
            titleTextBox = new TextBox();
            buttonTodoTaskDelete = new Button();
            textDescriptionRichBox = new RichTextBox();
            labelDescription = new Label();
            buttonSaveTask = new Button();
            buttonCancelSaveTask = new Button();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(12, 9);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(37, 15);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Título";
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(15, 27);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(207, 23);
            titleTextBox.TabIndex = 1;
            // 
            // buttonTodoTaskDelete
            // 
            buttonTodoTaskDelete.Enabled = false;
            buttonTodoTaskDelete.Location = new Point(147, 55);
            buttonTodoTaskDelete.Name = "buttonTodoTaskDelete";
            buttonTodoTaskDelete.Size = new Size(75, 23);
            buttonTodoTaskDelete.TabIndex = 7;
            buttonTodoTaskDelete.Text = "EXCLUIR";
            buttonTodoTaskDelete.UseVisualStyleBackColor = true;
            buttonTodoTaskDelete.Click += buttonTodoTaskDelete_Click;
            // 
            // textDescriptionRichBox
            // 
            textDescriptionRichBox.Location = new Point(15, 84);
            textDescriptionRichBox.Name = "textDescriptionRichBox";
            textDescriptionRichBox.Size = new Size(207, 169);
            textDescriptionRichBox.TabIndex = 6;
            textDescriptionRichBox.Text = "";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(15, 66);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(58, 15);
            labelDescription.TabIndex = 2;
            labelDescription.Text = "Descrição";
            // 
            // buttonCancelSaveTask
            // 
            buttonCancelSaveTask.Location = new Point(31, 259);
            buttonCancelSaveTask.Name = "buttonCancelSaveTask";
            buttonCancelSaveTask.Size = new Size(75, 23);
            buttonCancelSaveTask.TabIndex = 5;
            buttonCancelSaveTask.Text = "CANCELAR";
            buttonCancelSaveTask.UseVisualStyleBackColor = true;
            buttonCancelSaveTask.Click += buttonCancelSaveTask_Click;
            // 
            // buttonSaveTask
            // 
            buttonSaveTask.Location = new Point(139, 259);
            buttonSaveTask.Name = "buttonSaveTask";
            buttonSaveTask.Size = new Size(75, 23);
            buttonSaveTask.TabIndex = 4;
            buttonSaveTask.Text = "SALVAR";
            buttonSaveTask.UseVisualStyleBackColor = true;
            buttonSaveTask.Click += buttonSaveTask_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 296);
            Controls.Add(buttonTodoTaskDelete);
            Controls.Add(textDescriptionRichBox);
            Controls.Add(buttonCancelSaveTask);
            Controls.Add(buttonSaveTask);
            Controls.Add(labelDescription);
            Controls.Add(titleTextBox);
            Controls.Add(labelTitle);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tarefas";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelTitle;
        private TextBox titleTextBox;
        private Label labelDescription;
        private Button buttonSaveTask;
        private Button buttonCancelSaveTask;
        private RichTextBox textDescriptionRichBox;
        private Button buttonTodoTaskDelete;
    }
}