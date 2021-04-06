
namespace TravelAgencyView
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripTravelAgency = new System.Windows.Forms.MenuStrip();
            this.directoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conditionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.travelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agenciesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AgencyReplenishmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListTravelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConditionsTravelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.travelAgenciesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.travelAgenciesConditionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersForAllDatesListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonTakeOrderInWork = new System.Windows.Forms.Button();
            this.buttonOrderReady = new System.Windows.Forms.Button();
            this.buttonPayOrder = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.menuStripTravelAgency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripTravelAgency
            // 
            this.menuStripTravelAgency.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripTravelAgency.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.directoriesToolStripMenuItem,
            this.AgencyReplenishmentToolStripMenuItem,
            this.отчетыToolStripMenuItem});
            this.menuStripTravelAgency.Location = new System.Drawing.Point(0, 0);
            this.menuStripTravelAgency.Name = "menuStripTravelAgency";
            this.menuStripTravelAgency.Size = new System.Drawing.Size(945, 24);
            this.menuStripTravelAgency.TabIndex = 0;
            this.menuStripTravelAgency.Text = "menuStripTravelAgency";
            // 
            // directoriesToolStripMenuItem
            // 
            this.directoriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conditionsToolStripMenuItem,
            this.travelsToolStripMenuItem,
            this.agenciesToolStripMenuItem});
            this.directoriesToolStripMenuItem.Name = "directoriesToolStripMenuItem";
            this.directoriesToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.directoriesToolStripMenuItem.Text = "Справочники";
            // 
            // conditionsToolStripMenuItem
            // 
            this.conditionsToolStripMenuItem.Name = "conditionsToolStripMenuItem";
            this.conditionsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.conditionsToolStripMenuItem.Text = "Условия поездки";
            this.conditionsToolStripMenuItem.Click += new System.EventHandler(this.ConditionsToolStripMenuItem_Click);
            // 
            // travelsToolStripMenuItem
            // 
            this.travelsToolStripMenuItem.Name = "travelsToolStripMenuItem";
            this.travelsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.travelsToolStripMenuItem.Text = "Путевки";
            this.travelsToolStripMenuItem.Click += new System.EventHandler(this.TravelsToolStripMenuItem_Click);
            // 
            // agenciesToolStripMenuItem
            // 
            this.agenciesToolStripMenuItem.Name = "agenciesToolStripMenuItem";
            this.agenciesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.agenciesToolStripMenuItem.Text = "Склады";
            this.agenciesToolStripMenuItem.Click += new System.EventHandler(this.agenciesToolStripMenuItem_Click);
            // 
            // AgencyReplenishmentToolStripMenuItem
            // 
            this.AgencyReplenishmentToolStripMenuItem.Name = "AgencyReplenishmentToolStripMenuItem";
            this.AgencyReplenishmentToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.AgencyReplenishmentToolStripMenuItem.Text = "Пополнение складов";
            this.AgencyReplenishmentToolStripMenuItem.Click += new System.EventHandler(this.AgencyReplenishmentToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListTravelsToolStripMenuItem,
            this.ConditionsTravelsToolStripMenuItem,
            this.OrdersToolStripMenuItem,
            this.travelAgenciesToolStripMenuItem,
            this.travelAgenciesConditionsToolStripMenuItem,
            this.ordersForAllDatesListToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // ListTravelsToolStripMenuItem
            // 
            this.ListTravelsToolStripMenuItem.Name = "ListTravelsToolStripMenuItem";
            this.ListTravelsToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.ListTravelsToolStripMenuItem.Text = "Список поездок";
            this.ListTravelsToolStripMenuItem.Click += new System.EventHandler(this.ListTravelsToolStripMenuItem_Click);
            // 
            // ConditionsTravelsToolStripMenuItem
            // 
            this.ConditionsTravelsToolStripMenuItem.Name = "ConditionsTravelsToolStripMenuItem";
            this.ConditionsTravelsToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.ConditionsTravelsToolStripMenuItem.Text = "Путевки по условиям";
            this.ConditionsTravelsToolStripMenuItem.Click += new System.EventHandler(this.ConditionsTravelsToolStripMenuItem_Click);
            // 
            // OrdersToolStripMenuItem
            // 
            this.OrdersToolStripMenuItem.Name = "OrdersToolStripMenuItem";
            this.OrdersToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.OrdersToolStripMenuItem.Text = "Список заказов";
            this.OrdersToolStripMenuItem.Click += new System.EventHandler(this.OrdersToolStripMenuItem_Click);
            // 
            // travelAgenciesToolStripMenuItem
            // 
            this.travelAgenciesToolStripMenuItem.Name = "travelAgenciesToolStripMenuItem";
            this.travelAgenciesToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.travelAgenciesToolStripMenuItem.Text = "Список складов";
            this.travelAgenciesToolStripMenuItem.Click += new System.EventHandler(this.travelAgenciesToolStripMenuItem_Click);
            // 
            // travelAgenciesConditionsToolStripMenuItem
            // 
            this.travelAgenciesConditionsToolStripMenuItem.Name = "travelAgenciesConditionsToolStripMenuItem";
            this.travelAgenciesConditionsToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.travelAgenciesConditionsToolStripMenuItem.Text = "Условия по складам";
            this.travelAgenciesConditionsToolStripMenuItem.Click += new System.EventHandler(this.travelAgenciesConditionsToolStripMenuItem_Click);
            // 
            // ordersForAllDatesListToolStripMenuItem
            // 
            this.ordersForAllDatesListToolStripMenuItem.Name = "ordersForAllDatesListToolStripMenuItem";
            this.ordersForAllDatesListToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.ordersForAllDatesListToolStripMenuItem.Text = "Список заказов за весь период";
            this.ordersForAllDatesListToolStripMenuItem.Click += new System.EventHandler(this.ordersForAllDatesListToolStripMenuItem_Click);
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(0, 26);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.RowHeadersWidth = 51;
            this.dataGridViewOrders.Size = new System.Drawing.Size(745, 360);
            this.dataGridViewOrders.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(771, 46);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(148, 25);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // buttonTakeOrderInWork
            // 
            this.buttonTakeOrderInWork.Location = new System.Drawing.Point(771, 90);
            this.buttonTakeOrderInWork.Name = "buttonTakeOrderInWork";
            this.buttonTakeOrderInWork.Size = new System.Drawing.Size(148, 25);
            this.buttonTakeOrderInWork.TabIndex = 3;
            this.buttonTakeOrderInWork.Text = "Отдать на выполнение";
            this.buttonTakeOrderInWork.UseVisualStyleBackColor = true;
            this.buttonTakeOrderInWork.Click += new System.EventHandler(this.ButtonTakeOrderInWork_Click);
            // 
            // buttonOrderReady
            // 
            this.buttonOrderReady.Location = new System.Drawing.Point(771, 136);
            this.buttonOrderReady.Name = "buttonOrderReady";
            this.buttonOrderReady.Size = new System.Drawing.Size(148, 25);
            this.buttonOrderReady.TabIndex = 4;
            this.buttonOrderReady.Text = "Заказ готов";
            this.buttonOrderReady.UseVisualStyleBackColor = true;
            this.buttonOrderReady.Click += new System.EventHandler(this.ButtonOrderReady_Click);
            // 
            // buttonPayOrder
            // 
            this.buttonPayOrder.Location = new System.Drawing.Point(771, 182);
            this.buttonPayOrder.Name = "buttonPayOrder";
            this.buttonPayOrder.Size = new System.Drawing.Size(148, 25);
            this.buttonPayOrder.TabIndex = 5;
            this.buttonPayOrder.Text = "Заказ оплачен";
            this.buttonPayOrder.UseVisualStyleBackColor = true;
            this.buttonPayOrder.Click += new System.EventHandler(this.ButtonPayOrder_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(771, 229);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(148, 25);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 400);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayOrder);
            this.Controls.Add(this.buttonOrderReady);
            this.Controls.Add(this.buttonTakeOrderInWork);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridViewOrders);
            this.Controls.Add(this.menuStripTravelAgency);
            this.MainMenuStrip = this.menuStripTravelAgency;
            this.Name = "FormMain";
            this.Text = "Туристическая фирма";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStripTravelAgency.ResumeLayout(false);
            this.menuStripTravelAgency.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripTravelAgency;
        private System.Windows.Forms.ToolStripMenuItem directoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conditionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem travelsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonTakeOrderInWork;
        private System.Windows.Forms.Button buttonOrderReady;
        private System.Windows.Forms.Button buttonPayOrder;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.ToolStripMenuItem agenciesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AgencyReplenishmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ListTravelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConditionsTravelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem travelAgenciesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem travelAgenciesConditionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordersForAllDatesListToolStripMenuItem;
    }
}