namespace Converter
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpActual = new System.Windows.Forms.TabPage();
            this.tpRussian = new System.Windows.Forms.TabPage();
            this.tpImperial = new System.Windows.Forms.TabPage();
            this.tpJapanese = new System.Windows.Forms.TabPage();
            this.tpAboutProgram = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpActual);
            this.tabControl1.Controls.Add(this.tpRussian);
            this.tabControl1.Controls.Add(this.tpImperial);
            this.tabControl1.Controls.Add(this.tpJapanese);
            this.tabControl1.Controls.Add(this.tpAboutProgram);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(384, 362);
            this.tabControl1.TabIndex = 7;
            // 
            // tpActual
            // 
            this.tpActual.Location = new System.Drawing.Point(4, 22);
            this.tpActual.Name = "tpActual";
            this.tpActual.Padding = new System.Windows.Forms.Padding(3);
            this.tpActual.Size = new System.Drawing.Size(376, 336);
            this.tpActual.TabIndex = 0;
            this.tpActual.Text = "Современные";
            this.tpActual.UseVisualStyleBackColor = true;
            // 
            // tpRussian
            // 
            this.tpRussian.Location = new System.Drawing.Point(4, 22);
            this.tpRussian.Name = "tpRussian";
            this.tpRussian.Padding = new System.Windows.Forms.Padding(3);
            this.tpRussian.Size = new System.Drawing.Size(376, 336);
            this.tpRussian.TabIndex = 1;
            this.tpRussian.Text = "Старорусские";
            this.tpRussian.UseVisualStyleBackColor = true;
            // 
            // tpImperial
            // 
            this.tpImperial.Location = new System.Drawing.Point(4, 22);
            this.tpImperial.Name = "tpImperial";
            this.tpImperial.Size = new System.Drawing.Size(376, 336);
            this.tpImperial.TabIndex = 2;
            this.tpImperial.Text = "Имперские";
            this.tpImperial.UseVisualStyleBackColor = true;
            // 
            // tpJapanese
            // 
            this.tpJapanese.Location = new System.Drawing.Point(4, 22);
            this.tpJapanese.Name = "tpJapanese";
            this.tpJapanese.Size = new System.Drawing.Size(376, 336);
            this.tpJapanese.TabIndex = 3;
            this.tpJapanese.Text = "Японские";
            this.tpJapanese.UseVisualStyleBackColor = true;
            // 
            // tpAboutProgram
            // 
            this.tpAboutProgram.Location = new System.Drawing.Point(4, 22);
            this.tpAboutProgram.Name = "tpAboutProgram";
            this.tpAboutProgram.Size = new System.Drawing.Size(376, 336);
            this.tpAboutProgram.TabIndex = 4;
            this.tpAboutProgram.Text = "О программе";
            this.tpAboutProgram.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 400);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "MainForm";
            this.Text = "Конвертер";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpActual;
        private System.Windows.Forms.TabPage tpRussian;
        private System.Windows.Forms.TabPage tpImperial;
        private System.Windows.Forms.TabPage tpJapanese;
        private System.Windows.Forms.TabPage tpAboutProgram;
    }
}

