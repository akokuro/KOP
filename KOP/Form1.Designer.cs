namespace KOP
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
            this.components = new System.ComponentModel.Container();
            this.buttonStore = new System.Windows.Forms.Button();
            this.buttonDate = new System.Windows.Forms.Button();
            this.buttonReport = new System.Windows.Forms.Button();
            this.buttonHist = new System.Windows.Forms.Button();
            this.dateView1 = new Konponens.DateView();
            this.listView = new Komponents.ListView();
            this.fioManager = new Komponents.FIOManager();
            this.storeData1 = new Komponents.StoreData(this.components);
            this.wordReport = new Konponens.WordReport(this.components);
            this.histogram = new Konponens.Histogram(this.components);
            this.SuspendLayout();
            // 
            // buttonStore
            // 
            this.buttonStore.Location = new System.Drawing.Point(579, 103);
            this.buttonStore.Name = "buttonStore";
            this.buttonStore.Size = new System.Drawing.Size(145, 37);
            this.buttonStore.TabIndex = 1;
            this.buttonStore.Text = "Распаковка zip";
            this.buttonStore.UseVisualStyleBackColor = true;
            this.buttonStore.Click += new System.EventHandler(this.buttonStore_Click);
            // 
            // buttonDate
            // 
            this.buttonDate.Location = new System.Drawing.Point(550, 18);
            this.buttonDate.Name = "buttonDate";
            this.buttonDate.Size = new System.Drawing.Size(151, 25);
            this.buttonDate.TabIndex = 4;
            this.buttonDate.Text = "Вывести дату в консоль";
            this.buttonDate.UseVisualStyleBackColor = true;
            this.buttonDate.Click += new System.EventHandler(this.buttonDate_Click);
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(579, 189);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(145, 37);
            this.buttonReport.TabIndex = 5;
            this.buttonReport.Text = "Генерация отчета";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // buttonHist
            // 
            this.buttonHist.Location = new System.Drawing.Point(579, 253);
            this.buttonHist.Name = "buttonHist";
            this.buttonHist.Size = new System.Drawing.Size(145, 37);
            this.buttonHist.TabIndex = 6;
            this.buttonHist.Text = "Генерация гистограммы";
            this.buttonHist.UseVisualStyleBackColor = true;
            this.buttonHist.Click += new System.EventHandler(this.buttonHist_Click);
            // 
            // dateView1
            // 
            this.dateView1.Location = new System.Drawing.Point(527, 12);
            this.dateView1.Name = "dateView1";
            this.dateView1.Size = new System.Drawing.Size(242, 86);
            this.dateView1.TabIndex = 3;
            // 
            // listView
            // 
            this.listView.Location = new System.Drawing.Point(12, 100);
            this.listView.Name = "listView";
            this.listView.SelectedIndex = 0;
            this.listView.Size = new System.Drawing.Size(551, 160);
            this.listView.TabIndex = 2;
            // 
            // fioManager
            // 
            this.fioManager.Location = new System.Drawing.Point(27, 12);
            this.fioManager.Name = "fioManager";
            this.fioManager.SelectedIndexFIO = -1;
            this.fioManager.Size = new System.Drawing.Size(511, 86);
            this.fioManager.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonHist);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.buttonDate);
            this.Controls.Add(this.dateView1);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.buttonStore);
            this.Controls.Add(this.fioManager);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Komponents.FIOManager fioManager;
        private Komponents.StoreData storeData1;
        private System.Windows.Forms.Button buttonStore;
        private Komponents.ListView listView;
        private Konponens.DateView dateView1;
        private System.Windows.Forms.Button buttonDate;
        private Konponens.WordReport wordReport;
        private System.Windows.Forms.Button buttonReport;
        private Konponens.Histogram histogram;
        private System.Windows.Forms.Button buttonHist;
    }
}

