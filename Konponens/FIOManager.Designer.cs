namespace Komponents
{
    partial class FIOManager
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxFIO = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxFIO
            // 
            this.listBoxFIO.FormattingEnabled = true;
            this.listBoxFIO.Location = new System.Drawing.Point(29, 37);
            this.listBoxFIO.Name = "listBoxFIO";
            this.listBoxFIO.Size = new System.Drawing.Size(418, 30);
            this.listBoxFIO.TabIndex = 0;
            // 
            // FIOManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxFIO);
            this.Name = "FIOManager";
            this.Size = new System.Drawing.Size(476, 99);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxFIO;
    }
}
