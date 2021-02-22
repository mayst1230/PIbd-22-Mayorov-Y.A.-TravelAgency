namespace TravelAgencyView
{
    partial class FormAgencyReplenishment
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
            this.labelAgency = new System.Windows.Forms.Label();
            this.comboBoxAgency = new System.Windows.Forms.ComboBox();
            this.labelTravel = new System.Windows.Forms.Label();
            this.comboBoxTravel = new System.Windows.Forms.ComboBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelStore
            // 
            this.labelAgency.AutoSize = true;
            this.labelAgency.Location = new System.Drawing.Point(12, 21);
            this.labelAgency.Name = "labelAgency";
            this.labelAgency.Size = new System.Drawing.Size(38, 13);
            this.labelAgency.TabIndex = 0;
            this.labelAgency.Text = "Склад";
            // 
            // comboBoxAgency
            // 
            this.comboBoxAgency.FormattingEnabled = true;
            this.comboBoxAgency.Location = new System.Drawing.Point(86, 18);
            this.comboBoxAgency.Name = "comboBoxAgency";
            this.comboBoxAgency.Size = new System.Drawing.Size(213, 21);
            this.comboBoxAgency.TabIndex = 1;
            // 
            // labelTravel
            // 
            this.labelTravel.AutoSize = true;
            this.labelTravel.Location = new System.Drawing.Point(12, 50);
            this.labelTravel.Name = "labelTravel";
            this.labelTravel.Size = new System.Drawing.Size(40, 13);
            this.labelTravel.TabIndex = 2;
            this.labelTravel.Text = "Условие";
            // 
            // comboBoxTravel
            // 
            this.comboBoxTravel.FormattingEnabled = true;
            this.comboBoxTravel.Location = new System.Drawing.Point(86, 47);
            this.comboBoxTravel.Name = "comboBoxTravel";
            this.comboBoxTravel.Size = new System.Drawing.Size(213, 21);
            this.comboBoxTravel.TabIndex = 3;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(12, 79);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(66, 13);
            this.labelCount.TabIndex = 4;
            this.labelCount.Text = "Количество";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(86, 76);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(213, 20);
            this.textBoxCount.TabIndex = 5;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(226, 113);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(73, 30);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(123, 113);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(73, 30);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 155);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.comboBoxTravel);
            this.Controls.Add(this.labelTravel);
            this.Controls.Add(this.comboBoxAgency);
            this.Controls.Add(this.labelAgency);
            this.Text = "Пополнение склада";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelAgency;
        private System.Windows.Forms.ComboBox comboBoxAgency;
        private System.Windows.Forms.Label labelTravel;
        private System.Windows.Forms.ComboBox comboBoxTravel;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}