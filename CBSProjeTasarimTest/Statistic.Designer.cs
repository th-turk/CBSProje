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
            this.analyzeWithHashtag = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.analyzeWithTime = new System.Windows.Forms.Button();
            this.hashtagStat = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.Inclination = 50;
            chartArea1.Area3DStyle.PointDepth = 80;
            chartArea1.Area3DStyle.PointGapDepth = 50;
            chartArea1.Area3DStyle.WallWidth = 5;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.BorderWidth = 50;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series1.Legend = "Legend1";
            series1.Name = "Number";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(321, 333);
            this.chart1.TabIndex = 0;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Searched Tweet Numbers For City";
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
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series2.Legend = "Legend1";
            series2.Name = "hashtag";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(377, 333);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Trend Hashtags For Time";
            this.chart2.Titles.Add(title2);
            // 
            // analyzeWithHashtag
            // 
            this.analyzeWithHashtag.BackColor = System.Drawing.Color.Blue;
            this.analyzeWithHashtag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.analyzeWithHashtag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.analyzeWithHashtag.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.analyzeWithHashtag.Location = new System.Drawing.Point(233, 342);
            this.analyzeWithHashtag.Name = "analyzeWithHashtag";
            this.analyzeWithHashtag.Size = new System.Drawing.Size(91, 25);
            this.analyzeWithHashtag.TabIndex = 3;
            this.analyzeWithHashtag.Text = "Analyze";
            this.analyzeWithHashtag.UseVisualStyleBackColor = false;
            this.analyzeWithHashtag.Click += new System.EventHandler(this.analyzeWithHashtag_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.Highlight;
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
            this.comboBox1.Location = new System.Drawing.Point(366, 347);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(280, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "Select A Time Period";
            // 
            // analyzeWithTime
            // 
            this.analyzeWithTime.BackColor = System.Drawing.Color.Blue;
            this.analyzeWithTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.analyzeWithTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.analyzeWithTime.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.analyzeWithTime.Location = new System.Drawing.Point(652, 343);
            this.analyzeWithTime.Name = "analyzeWithTime";
            this.analyzeWithTime.Size = new System.Drawing.Size(91, 25);
            this.analyzeWithTime.TabIndex = 5;
            this.analyzeWithTime.Text = "Analyze";
            this.analyzeWithTime.UseVisualStyleBackColor = false;
            this.analyzeWithTime.Click += new System.EventHandler(this.analyzeWithTime_Click);
            // 
            // hashtagStat
            // 
            this.hashtagStat.ForeColor = System.Drawing.SystemColors.Highlight;
            this.hashtagStat.FormattingEnabled = true;
            this.hashtagStat.Location = new System.Drawing.Point(4, 345);
            this.hashtagStat.Name = "hashtagStat";
            this.hashtagStat.Size = new System.Drawing.Size(223, 21);
            this.hashtagStat.TabIndex = 6;
            this.hashtagStat.Text = "Select A Hashtag";
            // 
            // Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hashtagStat);
            this.Controls.Add(this.analyzeWithTime);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.analyzeWithHashtag);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Name = "Statistic";
            this.Size = new System.Drawing.Size(780, 379);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button analyzeWithHashtag;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button analyzeWithTime;
        private System.Windows.Forms.ComboBox hashtagStat;
    }
}
