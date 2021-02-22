using TravelAgencyBusinnesLogic.BindingModels;
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
    public partial class FormSet : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly SetLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> setTravels;

        public FormSet(SetLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }

        private void FormSet_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    SetViewModel view = logic.Read(new SetBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.SetName;
                        textBoxPrice.Text = view.Price.ToString();
                        setTravels = view.SetTravels;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                setTravels = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (setTravels != null)
                {
                    dataGridViewTravels.Rows.Clear();
                    foreach (var pc in setTravels)
                    {
                        dataGridViewTravels.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSetTravel>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (setTravels.ContainsKey(form.Id))
                {
                    setTravels[form.Id] = (form.TravelName, form.Count);
                }
                else
                {
                    setTravels.Add(form.Id, (form.TravelName, form.Count));
                }
                LoadData();
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewTravels.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormSetTravel>();
                int id = Convert.ToInt32(dataGridViewTravels.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = setTravels[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    setTravels[form.Id] = (form.TravelName, form.Count);
                    LoadData();
                }
            }
        }
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewTravels.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        setTravels.Remove(Convert.ToInt32(dataGridViewTravels.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (setTravels == null || setTravels.Count == 0)
            {
                MessageBox.Show("Заполните условие поездки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new SetBindingModel
                {
                    Id = id,
                    SetName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    SetTravels = setTravels
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
