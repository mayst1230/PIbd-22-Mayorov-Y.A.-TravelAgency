namespace TravelAgencyView
{
    partial class FormReportOrdersForAllDates
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.OrdersReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.createOrdersListButton = new System.Windows.Forms.Button();
            this.saveToPdfButton = new System.Windows.Forms.Button();
            this.ReportOrdersForAllDatesViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ReportOrdersForAllDatesViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // OrdersReportViewer
            // 
            reportDataSource1.Name = "DataSetOrdersForAllDates";
            reportDataSource1.Value = this.ReportOrdersForAllDatesViewModelBindingSource;
            this.OrdersReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.OrdersReportViewer.LocalReport.ReportEmbeddedResource = "TravelAgencyView.ReportOrdersForAllDates.rdlc";
            this.OrdersReportViewer.Location = new System.Drawing.Point(12, 42);
            this.OrdersReportViewer.Name = "OrdersReportViewer";
            this.OrdersReportViewer.ServerReport.BearerToken = null;
            this.OrdersReportViewer.Size = new System.Drawing.Size(740, 383);
            this.OrdersReportViewer.TabIndex = 1;
            // 
            // createOrdersListButton
            // 
            this.createOrdersListButton.Location = new System.Drawing.Point(453, 12);
            this.createOrdersListButton.Name = "createOrdersListButton";
            this.createOrdersListButton.Size = new System.Drawing.Size(130, 24);
            this.createOrdersListButton.TabIndex = 0;
            this.createOrdersListButton.Text = "Сформировать";
            this.createOrdersListButton.UseVisualStyleBackColor = true;
            this.createOrdersListButton.Click += new System.EventHandler(this.createOrdersListButton_Click);
            // 
            // saveToPdfButton
            // 
            this.saveToPdfButton.Location = new System.Drawing.Point(589, 12);
            this.saveToPdfButton.Name = "saveToPdfButton";
            this.saveToPdfButton.Size = new System.Drawing.Size(163, 24);
            this.saveToPdfButton.TabIndex = 1;
            this.saveToPdfButton.Text = "Сохранить в PDF";
            this.saveToPdfButton.UseVisualStyleBackColor = true;
            this.saveToPdfButton.Click += new System.EventHandler(this.saveToPdfButton_Click);
            // 
            // ReportOrdersForAllDatesViewModelBindingSource
            // 
            this.ReportOrdersForAllDatesViewModelBindingSource.DataSource = typeof(TravelAgencyBusinnesLogic.ViewModels.ReportOrdersForAllDatesViewModel);
            // 
            // FormReportOrdersForAllDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 437);
            this.Controls.Add(this.saveToPdfButton);
            this.Controls.Add(this.OrdersReportViewer);
            this.Controls.Add(this.createOrdersListButton);
            this.Name = "FormReportOrdersForAllDates";
            this.Text = "Отчет за весь период";
            this.Load += new System.EventHandler(this.FormReportOrdersForAllDates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportOrdersForAllDatesViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer OrdersReportViewer;
        private System.Windows.Forms.Button createOrdersListButton;
        private System.Windows.Forms.Button saveToPdfButton;
        private System.Windows.Forms.BindingSource ReportOrdersForAllDatesViewModelBindingSource;
    }
}