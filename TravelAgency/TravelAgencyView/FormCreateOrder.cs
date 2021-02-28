using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.BusinessLogics;
using TravelAgencyBusinnesLogic.ViewModels;
using System;
using System.Windows.Forms;
using Unity;

namespace TravelAgencyView
{
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly TravelLogic _logicT;
        private readonly OrderLogic _logicO;

        public FormCreateOrder(TravelLogic logicT, OrderLogic logicO)
        {
            InitializeComponent();
            _logicT = logicT;
            _logicO = logicO;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                var list = _logicT.Read(null);
                if (list != null)
                {
                    comboBoxTravel.DataSource = list;
                    comboBoxTravel.DisplayMember = "TravelName";
                    comboBoxTravel.ValueMember = "Id";
                    comboBoxTravel.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxTravel.SelectedValue != null &&
           !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxTravel.SelectedValue);
                    TravelViewModel product = _logicT.Read(new TravelBindingModel
                    {
                        Id = id
                    })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * product?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void ComboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxTravel.SelectedValue == null)
            {
                MessageBox.Show("Выберите путевку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicO.CreateOrder(new CreateOrderBindingModel
                {
                    TravelId = Convert.ToInt32(comboBoxTravel.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
