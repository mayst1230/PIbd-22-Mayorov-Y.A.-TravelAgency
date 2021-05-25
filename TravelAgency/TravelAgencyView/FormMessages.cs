using System;
using System.Windows.Forms;
using TravelAgencyBusinnesLogic.BusinessLogics;
using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.ViewModels;
using Unity;

namespace TravelAgencyView
{
    public partial class FormMessages : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MailLogic logic;
        public FormMessages(MailLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormMessages_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData(int page = 1)
        {
            try
            {
                var list = logic.GetMessagesPage(new MessageInfoBindingModel
                {
                    Page = page,
                    PageSize = Program.pageSize
                });
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonTo_Click(object sender, EventArgs e)
        {
            int page;
            try
            {
                page = Convert.ToInt32(textBoxPage.Text);
                int max = (logic.Count() - 1) / Program.pageSize + 1;
                if (page > max || page < 1)
                {
                    throw new Exception("Страница должна быть в диапозоне от 1 до " + max);
                }
                LoadData(page);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}