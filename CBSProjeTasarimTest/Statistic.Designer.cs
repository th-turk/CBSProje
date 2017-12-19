namespace CBSProjeTasarimTest
{
    partial class Statistic
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.hashtagStat = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 50;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series1.Legend = "Legend1";
            series1.Name = "Number";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(321, 333);
            this.chart1.TabIndex = 0;
            title1.Name = "Title1";
            title1.Text = "Searched Tweet Number";
            this.chart1.Titles.Add(title1);
            // 
            // chart2
            // 
            this.chart2.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea2.Area3DStyle.Inclination = 10;
            chartArea2.Area3DStyle.PointDepth = 80;
            chartArea2.Area3DStyle.PointGapDepth = 200;
            chartArea2.Area3DStyle.Rotation = 50;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(366, 3);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series2.Legend = "Legend1";
            series2.Name = "hashtag";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(377, 333);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            title2.Name = "Title1";
            title2.Text = "Trend Topics Ratio";
            this.chart2.Titles.Add(title2);
            // 
            // hashtagStat
            // 
            this.hashtagStat.Location = new System.Drawing.Point(23, 347);
            this.hashtagStat.Name = "hashtagStat";
            this.hashtagStat.Size = new System.Drawing.Size(204, 20);
            this.hashtagStat.TabIndex = 2;
            this.hashtagStat.Text = "Insert Hashtag...";
            this.hashtagStat.MouseClick += new System.Windows.Forms.MouseEventHandler(this.hashtagStat_MouseClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Blue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(233, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "Analyze";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Last 10 min",
            "Last 30 min",
            "Last 1 hour",
            "Last 3 hour",
            "Last 6 hour",
            "Last 12 hour",
            "Last 1 day",
            "Last 2 day",
            "Last 5 day",
            "Last 1 week",
            "Last 2 week",
            "Last 1 month",
            "Last 2 month"});
            this.comboBox1.Location = new System.Drawing.Point(444, 347);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(202, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Blue;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(652, 343);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 25);
            this.button2.TabIndex = 5;
            this.button2.Text = "Analyze";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.hashtagStat);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Name = "Statistic";
            this.Size = new System.Drawing.Size(780, 379);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.TextBox hashtagStat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
    }
}
