namespace MasterWordCounter
{
    partial class StatsDashboard
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
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.c_tip_analize = new System.Windows.Forms.ComboBox();
            this.c_tekst = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.c_analiza = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.textsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTextStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveResultsToPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.l_text_stats = new System.Windows.Forms.Label();
            this.l_nastavak = new System.Windows.Forms.Label();
            this.poAutoruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 130);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(397, 244);
            this.dataGridView1.TabIndex = 0;
            // 
            // c_tip_analize
            // 
            this.c_tip_analize.FormattingEnabled = true;
            this.c_tip_analize.Items.AddRange(new object[] {
            "Svi tekstovi",
            "Pojedinačan tekst"});
            this.c_tip_analize.Location = new System.Drawing.Point(117, 50);
            this.c_tip_analize.Name = "c_tip_analize";
            this.c_tip_analize.Size = new System.Drawing.Size(296, 21);
            this.c_tip_analize.TabIndex = 1;
            this.c_tip_analize.SelectedIndexChanged += new System.EventHandler(this.c_tip_analize_SelectedIndexChanged);
            // 
            // c_tekst
            // 
            this.c_tekst.FormattingEnabled = true;
            this.c_tekst.Location = new System.Drawing.Point(117, 77);
            this.c_tekst.Name = "c_tekst";
            this.c_tekst.Size = new System.Drawing.Size(296, 21);
            this.c_tekst.TabIndex = 2;
            this.c_tekst.SelectedIndexChanged += new System.EventHandler(this.c_tekst_SelectedIndexChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(117, 104);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(296, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Opseg rezultata:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Djelo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Veličina rezultata:";
            // 
            // c_analiza
            // 
            this.c_analiza.FormattingEnabled = true;
            this.c_analiza.Items.AddRange(new object[] {
            "Naivna",
            "Sa gramatikom"});
            this.c_analiza.Location = new System.Drawing.Point(117, 23);
            this.c_analiza.Name = "c_analiza";
            this.c_analiza.Size = new System.Drawing.Size(296, 21);
            this.c_analiza.TabIndex = 8;
            this.c_analiza.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tip Analize:";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(423, 26);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Rijec";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(397, 348);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(843, 26);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Rijec";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "LinearPlot";
            this.chart2.Series.Add(series2);
            this.chart2.Series.Add(series3);
            this.chart2.Size = new System.Drawing.Size(397, 348);
            this.chart2.TabIndex = 11;
            this.chart2.Text = "chart2";
            this.chart2.Click += new System.EventHandler(this.chart2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1246, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // textsToolStripMenuItem
            // 
            this.textsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveTextStatsToolStripMenuItem,
            this.saveResultsToPDFToolStripMenuItem,
            this.poAutoruToolStripMenuItem});
            this.textsToolStripMenuItem.Name = "textsToolStripMenuItem";
            this.textsToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.textsToolStripMenuItem.Text = "Texts";
            // 
            // saveTextStatsToolStripMenuItem
            // 
            this.saveTextStatsToolStripMenuItem.Name = "saveTextStatsToolStripMenuItem";
            this.saveTextStatsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.saveTextStatsToolStripMenuItem.Text = "Save text stats";
            this.saveTextStatsToolStripMenuItem.Click += new System.EventHandler(this.saveTextStatsToolStripMenuItem_Click);
            // 
            // saveResultsToPDFToolStripMenuItem
            // 
            this.saveResultsToPDFToolStripMenuItem.Name = "saveResultsToPDFToolStripMenuItem";
            this.saveResultsToPDFToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.saveResultsToPDFToolStripMenuItem.Text = "Save Results to PDF";
            this.saveResultsToPDFToolStripMenuItem.Click += new System.EventHandler(this.saveResultsToPDFToolStripMenuItem_Click);
            // 
            // l_text_stats
            // 
            this.l_text_stats.AutoSize = true;
            this.l_text_stats.Location = new System.Drawing.Point(13, 386);
            this.l_text_stats.Name = "l_text_stats";
            this.l_text_stats.Size = new System.Drawing.Size(35, 13);
            this.l_text_stats.TabIndex = 13;
            this.l_text_stats.Text = "label5";
            // 
            // l_nastavak
            // 
            this.l_nastavak.AutoSize = true;
            this.l_nastavak.Location = new System.Drawing.Point(12, 417);
            this.l_nastavak.Name = "l_nastavak";
            this.l_nastavak.Size = new System.Drawing.Size(35, 13);
            this.l_nastavak.TabIndex = 14;
            this.l_nastavak.Text = "label5";
            // 
            // poAutoruToolStripMenuItem
            // 
            this.poAutoruToolStripMenuItem.Name = "poAutoruToolStripMenuItem";
            this.poAutoruToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.poAutoruToolStripMenuItem.Text = "Po autoru";
            this.poAutoruToolStripMenuItem.Click += new System.EventHandler(this.poAutoruToolStripMenuItem_Click);
            // 
            // StatsDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 439);
            this.Controls.Add(this.l_nastavak);
            this.Controls.Add(this.l_text_stats);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.c_analiza);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.c_tekst);
            this.Controls.Add(this.c_tip_analize);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StatsDashboard";
            this.Text = "StatsDashboard";
            this.Load += new System.EventHandler(this.StatsDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox c_tip_analize;
        private System.Windows.Forms.ComboBox c_tekst;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox c_analiza;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem textsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTextStatsToolStripMenuItem;
        private System.Windows.Forms.Label l_text_stats;
        private System.Windows.Forms.Label l_nastavak;
        private System.Windows.Forms.ToolStripMenuItem saveResultsToPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poAutoruToolStripMenuItem;
    }
}