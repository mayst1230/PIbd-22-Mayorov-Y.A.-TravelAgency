using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.BusinessLogics;
using TravelAgencyBusinnesLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace TravelAgencyView
{
    public partial class FormAgencyReplenishment : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly AgencyLogic agencyLogic;

        public FormAgencyReplenishment(AgencyLogic logic_A, ConditionLogic logic_C)
        {
            InitializeComponent();
            this.agencyLogic = logic_A;
            List<AgencyViewModel> list_A = logic_A.Read(null);
            if (list_A != null)
            {
                comboBoxAgency.DisplayMember = "AgencyName";
                comboBoxAgency.ValueMember = "Id";
                comboBoxAgency.DataSource = list_A;
                comboBoxAgency.SelectedItem = null;
            }

            List<ConditionViewModel> list_T = logic_C.Read(null);
            if (list_T != null)
            {
                comboBoxCondition.DisplayMember = "ConditionName";
                comboBoxCondition.ValueMember = "Id";
                comboBoxCondition.DataSource = list_T;
                comboBoxCondition.SelectedItem = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxAgency.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxCondition.SelectedValue == null)
            {
                MessageBox.Show("Выберите условие поездки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Введите количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            agencyLogic.AddConditions(new AddConditionsToAgencyBindingModel
            {
                AgencyId = Convert.ToInt32(comboBoxAgency.SelectedValue),
                ConditionId = Convert.ToInt32(comboBoxCondition.SelectedValue),
                Count = Convert.ToInt32(textBoxCount.Text)
            });

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
