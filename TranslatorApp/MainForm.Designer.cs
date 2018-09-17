namespace TranslatorApp
{
    partial class MainForm
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
            this.cbLanguageFrom = new System.Windows.Forms.ComboBox();
            this.cbLanguageTo = new System.Windows.Forms.ComboBox();
            this.tbSourceText = new System.Windows.Forms.TextBox();
            this.tbTranslatedText = new System.Windows.Forms.TextBox();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbLanguageFrom
            // 
            this.cbLanguageFrom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbLanguageFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguageFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbLanguageFrom.FormattingEnabled = true;
            this.cbLanguageFrom.Location = new System.Drawing.Point(191, 16);
            this.cbLanguageFrom.Name = "cbLanguageFrom";
            this.cbLanguageFrom.Size = new System.Drawing.Size(118, 24);
            this.cbLanguageFrom.TabIndex = 2;
            this.cbLanguageFrom.SelectedIndexChanged += new System.EventHandler(this.cbLanguageFrom_SelectedIndexChanged);
            // 
            // cbLanguageTo
            // 
            this.cbLanguageTo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbLanguageTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguageTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbLanguageTo.FormattingEnabled = true;
            this.cbLanguageTo.Location = new System.Drawing.Point(425, 16);
            this.cbLanguageTo.Name = "cbLanguageTo";
            this.cbLanguageTo.Size = new System.Drawing.Size(118, 24);
            this.cbLanguageTo.TabIndex = 1;
            this.cbLanguageTo.SelectedIndexChanged += new System.EventHandler(this.cbLanguageTo_SelectedIndexChanged);
            // 
            // tbSourceText
            // 
            this.tbSourceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSourceText.Location = new System.Drawing.Point(13, 43);
            this.tbSourceText.Multiline = true;
            this.tbSourceText.Name = "tbSourceText";
            this.tbSourceText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSourceText.Size = new System.Drawing.Size(296, 180);
            this.tbSourceText.TabIndex = 0;
            this.tbSourceText.Text = "Кошка";
            // 
            // tbTranslatedText
            // 
            this.tbTranslatedText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbTranslatedText.Location = new System.Drawing.Point(425, 43);
            this.tbTranslatedText.Multiline = true;
            this.tbTranslatedText.Name = "tbTranslatedText";
            this.tbTranslatedText.ReadOnly = true;
            this.tbTranslatedText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTranslatedText.Size = new System.Drawing.Size(296, 180);
            this.tbTranslatedText.TabIndex = 3;
            // 
            // btnTranslate
            // 
            this.btnTranslate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTranslate.Location = new System.Drawing.Point(316, 49);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(103, 30);
            this.btnTranslate.TabIndex = 4;
            this.btnTranslate.Text = "Перевод";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExport.Location = new System.Drawing.Point(316, 85);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(103, 30);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Экспорт XML";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 231);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnTranslate);
            this.Controls.Add(this.tbTranslatedText);
            this.Controls.Add(this.tbSourceText);
            this.Controls.Add(this.cbLanguageTo);
            this.Controls.Add(this.cbLanguageFrom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Переводчик";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLanguageFrom;
        private System.Windows.Forms.ComboBox cbLanguageTo;
        private System.Windows.Forms.TextBox tbSourceText;
        private System.Windows.Forms.TextBox tbTranslatedText;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.Button btnExport;
    }
}

