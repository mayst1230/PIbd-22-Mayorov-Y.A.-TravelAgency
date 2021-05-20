using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.BusinessLogics;
using System;
using System.Windows.Forms;
using Unity;

namespace TravelAgencyView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly OrderLogic _orderLogic;
        private readonly ReportLogic _reportLogic;
        private readonly BackUpAbstractLogic _backUpAbstractLogic;

        public FormMain(OrderLogic orderLogic, ReportLogic reportLogic, BackUpAbstractLogic backUpAbstractLogic)
        {
            InitializeComponent();
            this._orderLogic = orderLogic;
            this._reportLogic = reportLogic;
            this._backUpAbstractLogic = backUpAbstractLogic;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Program.ConfigGrid(_orderLogic.Read(null), dataGridViewOrders);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConditionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormConditions>();
            form.ShowDialog();
        }

        private void TravelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTravels>();
            form.ShowDialog();
        }
        private void ButtonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }

        private void ButtonPayOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridViewOrders.SelectedRows[0].Cells[0].Value);
                try
                {
                    _orderLogic.PayOrder(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ListTravelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _reportLogic.SaveTravelsToWordFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName
                    });
                    MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
        }

        private void ConditionsTravelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportTravelConditions>();
            form.ShowDialog();
        }

        private void OrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportOrders>();
            form.ShowDialog();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClients>();
            form.ShowDialog();
        }

        private void startWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var workModeling = Container.Resolve<WorkModeling>();
            workModeling.DoWork();
            MessageBox.Show("Работы запущены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void implementersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<ImplementersForm>();
            form.ShowDialog();
        }

        private void messagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormMessages>();
            form.ShowDialog();
        }

        private void createBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_backUpAbstractLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        _backUpAbstractLogic.CreateArchive(fbd.SelectedPath);
                        MessageBox.Show("Бекап создан", "Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);

            }
        }
    }
}