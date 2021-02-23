using TravelAgencyBusinnesLogic.BusinessLogics;
using TravelAgencyBusinnesLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace TravelAgencyView
{
    public partial class FormTravelCondition : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id
        {
            get { return Convert.ToInt32(comboBoxCondition.SelectedValue); }
            set { comboBoxCondition.SelectedValue = value; }
        }
        public string TravelName { get { return comboBoxCondition.Text; } }
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }

        public FormTravelCondition(ConditionLogic logic)
        {
            InitializeComponent();
            List<ConditionViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxCondition.DisplayMember = "ConditionName";
                comboBoxCondition.ValueMember = "Id";
                comboBoxCondition.DataSource = list;
                comboBoxCondition.SelectedItem = null;
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxCondition.SelectedValue == null)
            {
                MessageBox.Show("Выберите условие поездки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
