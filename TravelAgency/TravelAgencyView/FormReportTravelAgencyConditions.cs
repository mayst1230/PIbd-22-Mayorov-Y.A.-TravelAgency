using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.BusinessLogics;
using System;
using System.Windows.Forms;
using Unity;

namespace TravelAgencyView
{
    public partial class FormReportTravelAgencyConditions : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ReportLogic logic;
        public FormReportTravelAgencyConditions(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void saveExcelButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveTravelAgencyConditionsToExcelFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FormReportTravelAgencyConditions_Load(object sender, EventArgs e)
        {
            try
            {
                var travelAgencyConditions = logic.GetTravelAgencyConditions();
                if (travelAgencyConditions != null)
                {
                    travelAgencyConditionsDataGridView.Rows.Clear();

                    foreach (var travelAgency in travelAgencyConditions)
                    {
                        travelAgencyConditionsDataGridView.Rows.Add(new object[] { travelAgency.TravelAgencyName, "", "" });

                        foreach (var condition in travelAgency.Conditions)
                        {
                            travelAgencyConditionsDataGridView.Rows.Add(new object[] { "", condition.Item1, condition.Item2 });
                        }

                        travelAgencyConditionsDataGridView.Rows.Add(new object[] { "Итого", "", travelAgency.TotalCount });
                        travelAgencyConditionsDataGridView.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
