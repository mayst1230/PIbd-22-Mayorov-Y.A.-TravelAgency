﻿using Microsoft.Reporting.WinForms;
using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.BusinessLogics;
using System;
using System.Windows.Forms;
using Unity;

namespace TravelAgencyView
{
    public partial class FormReportOrdersForAllDates : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportOrdersForAllDates(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void createOrdersListButton_Click(object sender, EventArgs e)
        {
            try
            {
                var dataSource = logic.GetOrdersForAllDates();

                ReportDataSource source = new ReportDataSource("DataSetOrdersForAllDates", dataSource);
                OrdersReportViewer.LocalReport.DataSources.Add(source);
                OrdersReportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void saveToPdfButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveOrdersForAllDatesToPdfFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        });

                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                }
            }
        }

        private void FormReportOrdersForAllDates_Load(object sender, EventArgs e)
        {

        }
    }
}
