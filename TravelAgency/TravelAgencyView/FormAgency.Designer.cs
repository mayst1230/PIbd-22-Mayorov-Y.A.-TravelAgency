namespace TravelAgencyView
{
    partial class FormAgency
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
            this.labelFullName = new System.Windows.Forms.Label();
            this.labelAgencyName = new System.Windows.Forms.Label();
            this.textBoxAgencyName = new System.Windows.Forms.TextBox();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.dataGridViewConditions = new System.Windows.Forms.DataGridView();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnConditionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConditions)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.Location = new System.Drawing.Point(12, 47);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(120, 13);
            this.labelFullName.TabIndex = 0;
            this.labelFullName.Text = "ФИО ответственного:";
            // 
            // labelAgencyName
            // 
            this.labelAgencyName.AutoSize = true;
            this.labelAgencyName.Location = new System.Drawing.Point(12, 22);
            this.labelAgencyName.Name = "labelAgencyName";
            this.labelAgencyName.Size = new System.Drawing.Size(60, 13);
            this.labelAgencyName.TabIndex = 1;
            this.labelAgencyName.Text = "Название:";
            // 
            // textBoxAgencyName
            // 
            this.textBoxAgencyName.Location = new System.Drawing.Point(154, 19);
            this.textBoxAgencyName.Name = "textBoxAgencyName";
            this.textBoxAgencyName.Size = new System.Drawing.Size(204, 20);
            this.textBoxAgencyName.TabIndex = 2;
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Location = new System.Drawing.Point(154, 44);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(204, 20);
            this.textBoxFullName.TabIndex = 3;
            // 
            // dataGridViewConditions
            // 
            this.dataGridViewConditions.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewConditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConditions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnConditionName,
            this.ColumnCount});
            this.dataGridViewConditions.Location = new System.Drawing.Point(15, 80);
            this.dataGridViewConditions.Name = "dataGridViewConditions";
            this.dataGridViewConditions.Size = new System.Drawing.Size(342, 190);
            this.dataGridViewConditions.TabIndex = 4;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(286, 283);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(73, 30);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(183, 283);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(73, 30);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Visible = false;
            // 
            // ColumnConditionName
            // 
            this.ColumnConditionName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnConditionName.FillWeight = 80F;
            this.ColumnConditionName.HeaderText = "Название условия";
            this.ColumnConditionName.Name = "ColumnConditionName";
            // 
            // ColumnCount
            // 
            this.ColumnCount.FillWeight = 20F;
            this.ColumnCount.HeaderText = "Количество";
            this.ColumnCount.Name = "ColumnCount";
            // 
            // FormAgency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 321);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridViewConditions);
            this.Controls.Add(this.textBoxFullName);
            this.Controls.Add(this.textBoxAgencyName);
            this.Controls.Add(this.labelAgencyName);
            this.Controls.Add(this.labelFullName);
            this.Name = "FormAgency";
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.FormAgency_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConditions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Label labelAgencyName;
        private System.Windows.Forms.TextBox textBoxAgencyName;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.DataGridView dataGridViewConditions;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnConditionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
    }
}