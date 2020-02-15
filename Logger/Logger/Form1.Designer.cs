namespace Logger
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbLogText = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.Label();
            this.btnLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbLogText
            // 
            this.rtbLogText.Location = new System.Drawing.Point(12, 38);
            this.rtbLogText.Name = "rtbLogText";
            this.rtbLogText.Size = new System.Drawing.Size(776, 386);
            this.rtbLogText.TabIndex = 0;
            this.rtbLogText.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(47, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(203, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tbName
            // 
            this.tbName.AutoSize = true;
            this.tbName.Location = new System.Drawing.Point(12, 15);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(29, 13);
            this.tbName.TabIndex = 2;
            this.tbName.Text = "Имя";
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(579, 10);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(209, 23);
            this.btnLog.TabIndex = 3;
            this.btnLog.Text = "Отправить в лог";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 435);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rtbLogText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLogText;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label tbName;
        private System.Windows.Forms.Button btnLog;
    }
}

