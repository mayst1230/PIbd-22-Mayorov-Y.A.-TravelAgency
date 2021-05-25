namespace TravelAgencyView
{
    partial class FormMessages
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
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.labelPage = new System.Windows.Forms.Label();
            this.buttonTo = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPage
            // 
            this.textBoxPage.Location = new System.Drawing.Point(554, 311);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(35, 20);
            this.textBoxPage.TabIndex = 1;
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(490, 314);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(58, 13);
            this.labelPage.TabIndex = 2;
            this.labelPage.Text = "Страница:";
            // 
            // buttonTo
            // 
            this.buttonTo.Location = new System.Drawing.Point(595, 308);
            this.buttonTo.Name = "buttonTo";
            this.buttonTo.Size = new System.Drawing.Size(75, 23);
            this.buttonTo.TabIndex = 3;
            this.buttonTo.Text = "Перейти";
            this.buttonTo.UseVisualStyleBackColor = true;
            this.buttonTo.Click += new System.EventHandler(this.buttonTo_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(1, 1);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(680, 298);
            this.dataGridView.TabIndex = 0;
            // 
            // FormMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 338);
            this.Controls.Add(this.buttonTo);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.textBoxPage);
            this.Controls.Add(this.dataGridView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMessages";
            this.Text = "Письма";
            this.Load += new System.EventHandler(this.FormMessages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.Button buttonTo;
    }
}