namespace VideoApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.btnInputURL = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnClear = new System.Windows.Forms.Button();
            this.buttonCollection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxURL
            // 
            this.textBoxURL.BackColor = System.Drawing.Color.White;
            this.textBoxURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxURL.Location = new System.Drawing.Point(184, 5);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(845, 30);
            this.textBoxURL.TabIndex = 0;
            // 
            // btnInputURL
            // 
            this.btnInputURL.BackColor = System.Drawing.Color.Transparent;
            this.btnInputURL.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnInputURL.Location = new System.Drawing.Point(1035, 6);
            this.btnInputURL.Name = "btnInputURL";
            this.btnInputURL.Size = new System.Drawing.Size(93, 33);
            this.btnInputURL.TabIndex = 1;
            this.btnInputURL.Text = "Ввод";
            this.btnInputURL.UseVisualStyleBackColor = false;
            this.btnInputURL.Click += new System.EventHandler(this.btnInputURL_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClear.Location = new System.Drawing.Point(1134, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(115, 33);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // buttonCollection
            // 
            this.buttonCollection.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCollection.Location = new System.Drawing.Point(13, 5);
            this.buttonCollection.Name = "buttonCollection";
            this.buttonCollection.Size = new System.Drawing.Size(165, 34);
            this.buttonCollection.TabIndex = 3;
            this.buttonCollection.Text = "Коллекция";
            this.buttonCollection.UseVisualStyleBackColor = true;
            this.buttonCollection.Click += new System.EventHandler(this.buttonCollection_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1570, 634);
            this.Controls.Add(this.buttonCollection);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnInputURL);
            this.Controls.Add(this.textBoxURL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "YouTube";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Button btnInputURL;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button buttonCollection;
    }
}

