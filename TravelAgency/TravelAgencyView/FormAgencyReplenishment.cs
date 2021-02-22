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

        public FormAgencyReplenishment(AgencyLogic logic_A, TravelLogic logic_T)
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

            List<TravelViewModel> list_T = logic_T.Read(null);
            if (list_T != null)
            {
                comboBoxTravel.DisplayMember = "TravelName";
                comboBoxTravel.ValueMember = "Id";
                comboBoxTravel.DataSource = list_T;
                comboBoxTravel.SelectedItem = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxAgency.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxTravel.SelectedValue == null)
            {
                MessageBox.Show("Выберите условие поездки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Введите количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            agencyLogic.AddTravels(new AddTravelsToAgencyBindingModel
            {
                AgencyId = Convert.ToInt32(comboBoxAgency.SelectedValue),
                TravelId = Convert.ToInt32(comboBoxTravel.SelectedValue),
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
