using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.BusinessLogics;
using TravelAgencyBusinnesLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace TravelAgencyView
{
    public partial class FormAgency : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }
        private int? id;
        private readonly AgencyLogic logic;
        private Dictionary<int, (string, int)> agencyConditions;

        public FormAgency(AgencyLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }

        private void FormAgency_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    AgencyViewModel view = logic.Read(new AgencyBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxAgencyName.Text = view.AgencyName;
                        textBoxFullName.Text = view.FullNameResponsible;
                        agencyConditions = view.AgencyConditions;
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
                agencyConditions = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (agencyConditions != null)
                {
                    dataGridViewConditions.Rows.Clear();
                    foreach (var at in agencyConditions)
                    {
                        dataGridViewConditions.Rows.Add(new object[] { at.Key, at.Value.Item1, at.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAgencyName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxFullName.Text))
            {
                MessageBox.Show("Заполните ответственного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                logic.CreateOrUpdate(new AgencyBindingModel
                {
                    Id = id,
                    AgencyName = textBoxAgencyName.Text,
                    FullNameResponsible = textBoxFullName.Text,
                    AgencyTravels = agencyConditions
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
