namespace QLTN.Forms
{
    partial class FormBaocaoThongke
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.headerLabel = new System.Windows.Forms.Label();
            this.filtersPanel = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.cboRange = new System.Windows.Forms.ComboBox();
            this.cboReportType = new System.Windows.Forms.ComboBox();
            this.summaryTable = new System.Windows.Forms.TableLayoutPanel();
            this.card1 = new System.Windows.Forms.Panel();
            this.card1Value = new System.Windows.Forms.Label();
            this.card1Title = new System.Windows.Forms.Label();
            this.card2 = new System.Windows.Forms.Panel();
            this.card2Value = new System.Windows.Forms.Label();
            this.card2Title = new System.Windows.Forms.Label();
            this.card3 = new System.Windows.Forms.Panel();
            this.card3Value = new System.Windows.Forms.Label();
            this.card3Title = new System.Windows.Forms.Label();
            this.card4 = new System.Windows.Forms.Panel();
            this.card4Value = new System.Windows.Forms.Label();
            this.card4Title = new System.Windows.Forms.Label();
            this.chartsTable = new System.Windows.Forms.TableLayoutPanel();
            this.revenueChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.occupancyChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gridsTable = new System.Windows.Forms.TableLayoutPanel();
            this.gridExpiring = new System.Windows.Forms.DataGridView();
            this.gridVacant = new System.Windows.Forms.DataGridView();
            this.filtersPanel.SuspendLayout();
            this.summaryTable.SuspendLayout();
            this.card1.SuspendLayout();
            this.card2.SuspendLayout();
            this.card3.SuspendLayout();
            this.card4.SuspendLayout();
            this.chartsTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.revenueChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.occupancyChart)).BeginInit();
            this.gridsTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridExpiring)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVacant)).BeginInit();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.headerLabel.Location = new System.Drawing.Point(0, 0);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(1200, 50);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Báo cáo & Thống kê";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // filtersPanel
            // 
            this.filtersPanel.Controls.Add(this.btnExport);
            this.filtersPanel.Controls.Add(this.btnApply);
            this.filtersPanel.Controls.Add(this.dtpTo);
            this.filtersPanel.Controls.Add(this.dtpFrom);
            this.filtersPanel.Controls.Add(this.cboRange);
            this.filtersPanel.Controls.Add(this.cboReportType);
            this.filtersPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filtersPanel.Location = new System.Drawing.Point(0, 50);
            this.filtersPanel.Name = "filtersPanel";
            this.filtersPanel.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.filtersPanel.Size = new System.Drawing.Size(1200, 60);
            this.filtersPanel.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(1048, 16);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(123, 28);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Xuất báo cáo";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(957, 16);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(80, 28);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Áp dụng";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(680, 18);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(180, 22);
            this.dtpTo.TabIndex = 3;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(494, 18);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(180, 22);
            this.dtpFrom.TabIndex = 2;
            // 
            // cboRange
            // 
            this.cboRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRange.FormattingEnabled = true;
            this.cboRange.Items.AddRange(new object[] {
            "Tháng này",
            "Quý này",
            "Năm nay"});
            this.cboRange.Location = new System.Drawing.Point(246, 18);
            this.cboRange.Name = "cboRange";
            this.cboRange.Size = new System.Drawing.Size(230, 24);
            this.cboRange.TabIndex = 1;
            // 
            // cboReportType
            // 
            this.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportType.FormattingEnabled = true;
            this.cboReportType.Items.AddRange(new object[] {
            "Khách hàng",
            "Hợp đồng",
            "Doanh thu"});
            this.cboReportType.Location = new System.Drawing.Point(16, 18);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Size = new System.Drawing.Size(210, 24);
            this.cboReportType.TabIndex = 0;
            // 
            // summaryTable
            // 
            this.summaryTable.ColumnCount = 4;
            this.summaryTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.summaryTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.summaryTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.summaryTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.summaryTable.Controls.Add(this.card1, 0, 0);
            this.summaryTable.Controls.Add(this.card2, 1, 0);
            this.summaryTable.Controls.Add(this.card3, 2, 0);
            this.summaryTable.Controls.Add(this.card4, 3, 0);
            this.summaryTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.summaryTable.Location = new System.Drawing.Point(0, 110);
            this.summaryTable.Name = "summaryTable";
            this.summaryTable.Padding = new System.Windows.Forms.Padding(12);
            this.summaryTable.RowCount = 1;
            this.summaryTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.summaryTable.Size = new System.Drawing.Size(1200, 130);
            this.summaryTable.TabIndex = 2;
            // 
            // card1
            // 
            this.card1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(238)))), ((int)(((byte)(237)))));
            this.card1.Controls.Add(this.card1Value);
            this.card1.Controls.Add(this.card1Title);
            this.card1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card1.Location = new System.Drawing.Point(15, 15);
            this.card1.Name = "card1";
            this.card1.Padding = new System.Windows.Forms.Padding(14);
            this.card1.Size = new System.Drawing.Size(288, 100);
            this.card1.TabIndex = 0;
            // 
            // card1Value
            // 
            this.card1Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card1Value.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.card1Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(61)))), ((int)(((byte)(139)))));
            this.card1Value.Location = new System.Drawing.Point(14, 40);
            this.card1Value.Name = "card1Value";
            this.card1Value.Size = new System.Drawing.Size(260, 46);
            this.card1Value.TabIndex = 1;
            this.card1Value.Text = "3";
            this.card1Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // card1Title
            // 
            this.card1Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.card1Title.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.card1Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.card1Title.Location = new System.Drawing.Point(14, 14);
            this.card1Title.Name = "card1Title";
            this.card1Title.Size = new System.Drawing.Size(260, 26);
            this.card1Title.TabIndex = 0;
            this.card1Title.Text = "Hợp đồng sắp hết hạn";
            // 
            // card2
            // 
            this.card2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.card2.Controls.Add(this.card2Value);
            this.card2.Controls.Add(this.card2Title);
            this.card2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card2.Location = new System.Drawing.Point(309, 15);
            this.card2.Name = "card2";
            this.card2.Padding = new System.Windows.Forms.Padding(14);
            this.card2.Size = new System.Drawing.Size(288, 100);
            this.card2.TabIndex = 1;
            // 
            // card2Value
            // 
            this.card2Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card2Value.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.card2Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(61)))), ((int)(((byte)(139)))));
            this.card2Value.Location = new System.Drawing.Point(14, 40);
            this.card2Value.Name = "card2Value";
            this.card2Value.Size = new System.Drawing.Size(260, 46);
            this.card2Value.TabIndex = 1;
            this.card2Value.Text = "24";
            this.card2Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // card2Title
            // 
            this.card2Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.card2Title.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.card2Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.card2Title.Location = new System.Drawing.Point(14, 14);
            this.card2Title.Name = "card2Title";
            this.card2Title.Size = new System.Drawing.Size(260, 26);
            this.card2Title.TabIndex = 0;
            this.card2Title.Text = "Tổng số bất động sản";
            // 
            // card3
            // 
            this.card3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.card3.Controls.Add(this.card3Value);
            this.card3.Controls.Add(this.card3Title);
            this.card3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card3.Location = new System.Drawing.Point(603, 15);
            this.card3.Name = "card3";
            this.card3.Padding = new System.Windows.Forms.Padding(14);
            this.card3.Size = new System.Drawing.Size(288, 100);
            this.card3.TabIndex = 2;
            // 
            // card3Value
            // 
            this.card3Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card3Value.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.card3Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(61)))), ((int)(((byte)(139)))));
            this.card3Value.Location = new System.Drawing.Point(14, 40);
            this.card3Value.Name = "card3Value";
            this.card3Value.Size = new System.Drawing.Size(260, 46);
            this.card3Value.TabIndex = 1;
            this.card3Value.Text = "18";
            this.card3Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // card3Title
            // 
            this.card3Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.card3Title.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.card3Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.card3Title.Location = new System.Drawing.Point(14, 14);
            this.card3Title.Name = "card3Title";
            this.card3Title.Size = new System.Drawing.Size(260, 26);
            this.card3Title.TabIndex = 0;
            this.card3Title.Text = "Hợp đồng đang hoạt động";
            // 
            // card4
            // 
            this.card4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(234)))), ((int)(((byte)(252)))));
            this.card4.Controls.Add(this.card4Value);
            this.card4.Controls.Add(this.card4Title);
            this.card4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card4.Location = new System.Drawing.Point(897, 15);
            this.card4.Name = "card4";
            this.card4.Padding = new System.Windows.Forms.Padding(14);
            this.card4.Size = new System.Drawing.Size(288, 100);
            this.card4.TabIndex = 3;
            // 
            // card4Value
            // 
            this.card4Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card4Value.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.card4Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(61)))), ((int)(((byte)(139)))));
            this.card4Value.Location = new System.Drawing.Point(14, 40);
            this.card4Value.Name = "card4Value";
            this.card4Value.Size = new System.Drawing.Size(260, 46);
            this.card4Value.TabIndex = 1;
            this.card4Value.Text = "245M";
            this.card4Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // card4Title
            // 
            this.card4Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.card4Title.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.card4Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.card4Title.Location = new System.Drawing.Point(14, 14);
            this.card4Title.Name = "card4Title";
            this.card4Title.Size = new System.Drawing.Size(260, 26);
            this.card4Title.TabIndex = 0;
            this.card4Title.Text = "Doanh thu tháng";
            // 
            // chartsTable
            // 
            this.chartsTable.ColumnCount = 2;
            this.chartsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.chartsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.chartsTable.Controls.Add(this.revenueChart, 0, 0);
            this.chartsTable.Controls.Add(this.occupancyChart, 1, 0);
            this.chartsTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.chartsTable.Location = new System.Drawing.Point(0, 240);
            this.chartsTable.Name = "chartsTable";
            this.chartsTable.Padding = new System.Windows.Forms.Padding(12);
            this.chartsTable.RowCount = 1;
            this.chartsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.chartsTable.Size = new System.Drawing.Size(1200, 320);
            this.chartsTable.TabIndex = 3;
            // 
            // revenueChart
            // 
            chartArea1.Name = "ChartArea1";
            this.revenueChart.ChartAreas.Add(chartArea1);
            this.revenueChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.revenueChart.Legends.Add(legend1);
            this.revenueChart.Location = new System.Drawing.Point(15, 15);
            this.revenueChart.Name = "revenueChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "DoanhThu";
            this.revenueChart.Series.Add(series1);
            this.revenueChart.Size = new System.Drawing.Size(699, 290);
            this.revenueChart.TabIndex = 0;
            this.revenueChart.Text = "chart1";
            // 
            // occupancyChart
            // 
            chartArea2.Name = "ChartArea1";
            this.occupancyChart.ChartAreas.Add(chartArea2);
            this.occupancyChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.occupancyChart.Legends.Add(legend2);
            this.occupancyChart.Location = new System.Drawing.Point(720, 15);
            this.occupancyChart.Name = "occupancyChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Legend = "Legend1";
            series2.Name = "TìnhTrạng";
            this.occupancyChart.Series.Add(series2);
            this.occupancyChart.Size = new System.Drawing.Size(465, 290);
            this.occupancyChart.TabIndex = 1;
            this.occupancyChart.Text = "chart2";
            // 
            // gridsTable
            // 
            this.gridsTable.ColumnCount = 2;
            this.gridsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gridsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            // add titles row
            this.gridsTable.RowCount = 2;
            this.gridsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.gridsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            System.Windows.Forms.Label lblExpiringTitle = new System.Windows.Forms.Label();
            lblExpiringTitle.Text = "Hợp đồng sắp hết hạn";
            lblExpiringTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblExpiringTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            lblExpiringTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            System.Windows.Forms.Label lblVacantTitle = new System.Windows.Forms.Label();
            lblVacantTitle.Text = "Phòng trống";
            lblVacantTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblVacantTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            lblVacantTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gridsTable.Controls.Add(lblExpiringTitle, 0, 0);
            this.gridsTable.Controls.Add(lblVacantTitle, 1, 0);
            this.gridsTable.Controls.Add(this.gridExpiring, 0, 1);
            this.gridsTable.Controls.Add(this.gridVacant, 1, 1);
            this.gridsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridsTable.Location = new System.Drawing.Point(0, 560);
            this.gridsTable.Name = "gridsTable";
            this.gridsTable.Padding = new System.Windows.Forms.Padding(12);
            this.gridsTable.Size = new System.Drawing.Size(1200, 340);
            this.gridsTable.TabIndex = 4;
            // 
            // gridExpiring
            // 
            this.gridExpiring.AllowUserToAddRows = false;
            this.gridExpiring.AllowUserToDeleteRows = false;
            this.gridExpiring.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridExpiring.BackgroundColor = System.Drawing.Color.White;
            this.gridExpiring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridExpiring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridExpiring.Location = new System.Drawing.Point(15, 15);
            this.gridExpiring.MultiSelect = false;
            this.gridExpiring.Name = "gridExpiring";
            this.gridExpiring.ReadOnly = true;
            this.gridExpiring.RowHeadersVisible = false;
            this.gridExpiring.RowHeadersWidth = 51;
            this.gridExpiring.RowTemplate.Height = 28;
            this.gridExpiring.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridExpiring.Size = new System.Drawing.Size(582, 310);
            this.gridExpiring.TabIndex = 0;
            // 
            // gridVacant
            // 
            this.gridVacant.AllowUserToAddRows = false;
            this.gridVacant.AllowUserToDeleteRows = false;
            this.gridVacant.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridVacant.BackgroundColor = System.Drawing.Color.White;
            this.gridVacant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVacant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVacant.Location = new System.Drawing.Point(603, 15);
            this.gridVacant.MultiSelect = false;
            this.gridVacant.Name = "gridVacant";
            this.gridVacant.ReadOnly = true;
            this.gridVacant.RowHeadersVisible = false;
            this.gridVacant.RowHeadersWidth = 51;
            this.gridVacant.RowTemplate.Height = 28;
            this.gridVacant.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridVacant.Size = new System.Drawing.Size(582, 310);
            this.gridVacant.TabIndex = 1;
            // 
            // FormBaocaoThongke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 900);
            this.Controls.Add(this.gridsTable);
            this.Controls.Add(this.chartsTable);
            this.Controls.Add(this.summaryTable);
            this.Controls.Add(this.filtersPanel);
            this.Controls.Add(this.headerLabel);
            this.Name = "FormBaocaoThongke";
            this.Text = "Báo cáo & Thống kê";
            this.filtersPanel.ResumeLayout(false);
            this.summaryTable.ResumeLayout(false);
            this.card1.ResumeLayout(false);
            this.card2.ResumeLayout(false);
            this.card3.ResumeLayout(false);
            this.card4.ResumeLayout(false);
            this.chartsTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.revenueChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.occupancyChart)).EndInit();
            this.gridsTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridExpiring)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVacant)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Panel filtersPanel;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.ComboBox cboRange;
        private System.Windows.Forms.ComboBox cboReportType;
        private System.Windows.Forms.TableLayoutPanel summaryTable;
        private System.Windows.Forms.Panel card1;
        private System.Windows.Forms.Label card1Value;
        private System.Windows.Forms.Label card1Title;
        private System.Windows.Forms.Panel card2;
        private System.Windows.Forms.Label card2Value;
        private System.Windows.Forms.Label card2Title;
        private System.Windows.Forms.Panel card3;
        private System.Windows.Forms.Label card3Value;
        private System.Windows.Forms.Label card3Title;
        private System.Windows.Forms.Panel card4;
        private System.Windows.Forms.Label card4Value;
        private System.Windows.Forms.Label card4Title;
        private System.Windows.Forms.TableLayoutPanel chartsTable;
        private System.Windows.Forms.DataVisualization.Charting.Chart revenueChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart occupancyChart;
        private System.Windows.Forms.TableLayoutPanel gridsTable;
        private System.Windows.Forms.DataGridView gridExpiring;
        private System.Windows.Forms.DataGridView gridVacant;
    }
}