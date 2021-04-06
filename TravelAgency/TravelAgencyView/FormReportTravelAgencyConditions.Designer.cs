namespace TravelAgencyView
{
    partial class FormReportTravelAgencyConditions
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
            this.saveExcelButton = new System.Windows.Forms.Button();
            this.travelAgencyConditionsDataGridView = new System.Windows.Forms.DataGridView();
            this.TravelAgency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.travelAgencyConditionsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // saveExcelButton
            // 
            this.saveExcelButton.Location = new System.Drawing.Point(180, 12);
            this.saveExcelButton.Name = "saveExcelButton";
            this.saveExcelButton.Size = new System.Drawing.Size(144, 33);
            this.saveExcelButton.TabIndex = 0;
            this.saveExcelButton.Text = "Сохранить в Excel";
            this.saveExcelButton.UseVisualStyleBackColor = true;
            this.saveExcelButton.Click += new System.EventHandler(this.saveExcelButton_Click);
            // 
            // travelAgencyConditionsDataGridView
            // 
            this.travelAgencyConditionsDataGridView.AllowUserToAddRows = false;
            this.travelAgencyConditionsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.travelAgencyConditionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.travelAgencyConditionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TravelAgency,
            this.Condition,
            this.Count});
            this.travelAgencyConditionsDataGridView.Location = new System.Drawing.Point(13, 51);
            this.travelAgencyConditionsDataGridView.Name = "travelAgencyConditionsDataGridView";
            this.travelAgencyConditionsDataGridView.RowHeadersVisible = false;
            this.travelAgencyConditionsDataGridView.Size = new System.Drawing.Size(470, 431);
            this.travelAgencyConditionsDataGridView.TabIndex = 1;
            // 
            // TravelAgency
            // 
            this.TravelAgency.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TravelAgency.HeaderText = "Склад";
            this.TravelAgency.Name = "TravelAgency";
            // 
            // Condition
            // 
            this.Condition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Condition.HeaderText = "Условие поездки";
            this.Condition.Name = "Condition";
            // 
            // Count
            // 
            this.Count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Count.HeaderText = "Количество";
            this.Count.Name = "Count";
            // 
            // FormReportTravelAgencyConditions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 494);
            this.Controls.Add(this.travelAgencyConditionsDataGridView);
            this.Controls.Add(this.saveExcelButton);
            this.Name = "FormReportTravelAgencyConditions";
            this.Text = "Условия поездок по складам";
            this.Load += new System.EventHandler(this.FormReportTravelAgencyConditions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.travelAgencyConditionsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveExcelButton;
        private System.Windows.Forms.DataGridView travelAgencyConditionsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn TravelAgency;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condition;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
    }
}