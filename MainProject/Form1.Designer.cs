namespace MainProject
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
            this.ProviderfioManager = new Komponents.FIOManager();
            this.vivodTableComponent1 = new Lab1ComponentKate.VivodTableComponent();
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ProviderNameField = new System.Windows.Forms.TextBox();
            this.storeData1 = new Komponents.StoreData(this.components);
            this.buttonLoadBackup = new System.Windows.Forms.Button();
            this.diagrammaExcelComponent1 = new Lab1ComponentKate.DiagrammaExcelComponent(this.components);
            this.ReportManagerButton = new System.Windows.Forms.Button();
            this.MyExcelReport1 = new ControlLibrary.MyExcelReport(this.components);
            this.ReportProviderButton = new System.Windows.Forms.Button();
            this.ProviderPhoneField = new ControlLibrary.ControlTelNum();
            this.PluginListViev = new System.Windows.Forms.ListView();
            this.PluginStartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProviderfioManager
            // 
            this.ProviderfioManager.Location = new System.Drawing.Point(333, 12);
            this.ProviderfioManager.Name = "ProviderfioManager";
            this.ProviderfioManager.SelectedIndexFIO = -1;
            this.ProviderfioManager.Size = new System.Drawing.Size(476, 99);
            this.ProviderfioManager.TabIndex = 0;
            // 
            // vivodTableComponent1
            // 
            this.vivodTableComponent1.Location = new System.Drawing.Point(12, 117);
            this.vivodTableComponent1.Name = "vivodTableComponent1";
            this.vivodTableComponent1.Size = new System.Drawing.Size(388, 238);
            this.vivodTableComponent1.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(522, 88);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(603, 88);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 3;
            this.EditButton.Text = "Изменить";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(684, 88);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ProviderNameField
            // 
            this.ProviderNameField.Location = new System.Drawing.Point(38, 48);
            this.ProviderNameField.Name = "ProviderNameField";
            this.ProviderNameField.Size = new System.Drawing.Size(147, 20);
            this.ProviderNameField.TabIndex = 5;
            this.ProviderNameField.Text = "Название поставщика";
            // 
            // buttonLoadBackup
            // 
            this.buttonLoadBackup.Location = new System.Drawing.Point(684, 415);
            this.buttonLoadBackup.Name = "buttonLoadBackup";
            this.buttonLoadBackup.Size = new System.Drawing.Size(104, 23);
            this.buttonLoadBackup.TabIndex = 7;
            this.buttonLoadBackup.Text = "загрузить бекап";
            this.buttonLoadBackup.UseVisualStyleBackColor = true;
            this.buttonLoadBackup.Click += new System.EventHandler(this.LoadBackupButton_Click);
            // 
            // ReportManagerButton
            // 
            this.ReportManagerButton.Location = new System.Drawing.Point(12, 415);
            this.ReportManagerButton.Name = "ReportManagerButton";
            this.ReportManagerButton.Size = new System.Drawing.Size(129, 23);
            this.ReportManagerButton.TabIndex = 8;
            this.ReportManagerButton.Text = "отчет по менеджерам";
            this.ReportManagerButton.UseVisualStyleBackColor = true;
            this.ReportManagerButton.Click += new System.EventHandler(this.ReportManagerButton_Click);
            // 
            // ReportProviderButton
            // 
            this.ReportProviderButton.Location = new System.Drawing.Point(147, 415);
            this.ReportProviderButton.Name = "ReportProviderButton";
            this.ReportProviderButton.Size = new System.Drawing.Size(130, 23);
            this.ReportProviderButton.TabIndex = 9;
            this.ReportProviderButton.Text = "отчет по поставщикам";
            this.ReportProviderButton.UseVisualStyleBackColor = true;
            this.ReportProviderButton.Click += new System.EventHandler(this.ReportProviderButton_Click);
            // 
            // ProviderPhoneField
            // 
            this.ProviderPhoneField.Location = new System.Drawing.Point(147, -9);
            this.ProviderPhoneField.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ProviderPhoneField.Name = "ProviderPhoneField";
            this.ProviderPhoneField.Size = new System.Drawing.Size(221, 161);
            this.ProviderPhoneField.TabIndex = 10;
            // 
            // PluginListViev
            // 
            this.PluginListViev.HideSelection = false;
            this.PluginListViev.Location = new System.Drawing.Point(406, 131);
            this.PluginListViev.Name = "PluginListViev";
            this.PluginListViev.Size = new System.Drawing.Size(272, 83);
            this.PluginListViev.TabIndex = 11;
            this.PluginListViev.UseCompatibleStateImageBehavior = false;
            // 
            // PluginStartButton
            // 
            this.PluginStartButton.Location = new System.Drawing.Point(684, 131);
            this.PluginStartButton.Name = "PluginStartButton";
            this.PluginStartButton.Size = new System.Drawing.Size(75, 38);
            this.PluginStartButton.TabIndex = 12;
            this.PluginStartButton.Text = "запустить плагин";
            this.PluginStartButton.UseVisualStyleBackColor = true;
            this.PluginStartButton.Click += new System.EventHandler(this.PluginStartButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 450);
            this.Controls.Add(this.PluginStartButton);
            this.Controls.Add(this.PluginListViev);
            this.Controls.Add(this.ReportProviderButton);
            this.Controls.Add(this.ReportManagerButton);
            this.Controls.Add(this.buttonLoadBackup);
            this.Controls.Add(this.ProviderNameField);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.vivodTableComponent1);
            this.Controls.Add(this.ProviderfioManager);
            this.Controls.Add(this.ProviderPhoneField);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Komponents.FIOManager ProviderfioManager;
        private Lab1ComponentKate.VivodTableComponent vivodTableComponent1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TextBox ProviderNameField;
        private Komponents.StoreData storeData1;
        private System.Windows.Forms.Button buttonLoadBackup;
        private Lab1ComponentKate.DiagrammaExcelComponent diagrammaExcelComponent1;
        private System.Windows.Forms.Button ReportManagerButton;
        private ControlLibrary.MyExcelReport MyExcelReport1;
        private System.Windows.Forms.Button ReportProviderButton;
        private ControlLibrary.ControlTelNum ProviderPhoneField;
        private System.Windows.Forms.ListView PluginListViev;
        private System.Windows.Forms.Button PluginStartButton;
    }
}

