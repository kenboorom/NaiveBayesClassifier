namespace MachineLearningExample1
{
    partial class MachineLearningExampleMainForm
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
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.plotDefect2Bitstream = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExportMatlab = new System.Windows.Forms.Button();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.plotDefect1Bitstream = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ButtonGenerateNominal = new System.Windows.Forms.Button();
            this.ButtonGenerateErrorSets = new System.Windows.Forms.Button();
            this.plotNominalWaveform = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonTestBayes = new System.Windows.Forms.Button();
            this.ClassifierDefect1 = new System.Windows.Forms.TextBox();
            this.ClassifierDefect2 = new System.Windows.Forms.TextBox();
            this.ClassifierNominal = new System.Windows.Forms.TextBox();
            this.ClassifierExperiment = new System.Windows.Forms.TextBox();
            this.buttonTrainTestBayes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.plotDefect2Bitstream)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plotDefect1Bitstream)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plotNominalWaveform)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plotDefect2Bitstream
            // 
            chartArea1.Name = "ChartArea1";
            this.plotDefect2Bitstream.ChartAreas.Add(chartArea1);
            this.plotDefect2Bitstream.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Enabled = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "Clock Arrives TOO LATE";
            legend1.TitleAlignment = System.Drawing.StringAlignment.Near;
            this.plotDefect2Bitstream.Legends.Add(legend1);
            this.plotDefect2Bitstream.Location = new System.Drawing.Point(678, 47);
            this.plotDefect2Bitstream.Margin = new System.Windows.Forms.Padding(2);
            this.plotDefect2Bitstream.Name = "plotDefect2Bitstream";
            this.tableLayoutPanel1.SetRowSpan(this.plotDefect2Bitstream, 2);
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.IsVisibleInLegend = false;
            series3.Legend = "Clock Arrives TOO LATE";
            series3.Name = "Series1";
            this.plotDefect2Bitstream.Series.Add(series3);
            this.plotDefect2Bitstream.Size = new System.Drawing.Size(334, 328);
            this.plotDefect2Bitstream.TabIndex = 11;
            this.plotDefect2Bitstream.Text = "chart1";
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.Name = "Title1";
            title3.Text = "Noise Causes Clock to Arrive Too Late\\n (t-late=50*rhnormal)";
            this.plotDefect2Bitstream.Titles.Add(title3);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonExportMatlab);
            this.panel1.Location = new System.Drawing.Point(1016, 379);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 158);
            this.panel1.TabIndex = 15;
            // 
            // buttonExportMatlab
            // 
            this.buttonExportMatlab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportMatlab.Location = new System.Drawing.Point(60, 76);
            this.buttonExportMatlab.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExportMatlab.Name = "buttonExportMatlab";
            this.buttonExportMatlab.Size = new System.Drawing.Size(184, 68);
            this.buttonExportMatlab.TabIndex = 0;
            this.buttonExportMatlab.Text = "Export Training + Experiment to MATLAB";
            this.buttonExportMatlab.UseVisualStyleBackColor = true;
            this.buttonExportMatlab.Click += new System.EventHandler(this.buttonExportToMatlab_Click);
            // 
            // statusBox
            // 
            this.statusBox.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBox.Location = new System.Drawing.Point(1016, 545);
            this.statusBox.Margin = new System.Windows.Forms.Padding(2);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusBox.Size = new System.Drawing.Size(329, 158);
            this.statusBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(471, 36);
            this.label1.TabIndex = 12;
            this.label1.Text = "Naive Bayes Multinomial Classifer ";
            // 
            // plotDefect1Bitstream
            // 
            chartArea3.Name = "ChartArea1";
            this.plotDefect1Bitstream.ChartAreas.Add(chartArea3);
            this.plotDefect1Bitstream.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Alignment = System.Drawing.StringAlignment.Center;
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend3.Enabled = false;
            legend3.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend3.Name = "Clock Arrives TOO EARLY";
            legend3.TitleAlignment = System.Drawing.StringAlignment.Near;
            this.plotDefect1Bitstream.Legends.Add(legend3);
            this.plotDefect1Bitstream.Location = new System.Drawing.Point(340, 47);
            this.plotDefect1Bitstream.Margin = new System.Windows.Forms.Padding(2);
            this.plotDefect1Bitstream.Name = "plotDefect1Bitstream";
            this.tableLayoutPanel1.SetRowSpan(this.plotDefect1Bitstream, 2);
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Clock Arrives TOO EARLY";
            series2.Name = "Series1";
            this.plotDefect1Bitstream.Series.Add(series2);
            this.plotDefect1Bitstream.Size = new System.Drawing.Size(334, 328);
            this.plotDefect1Bitstream.TabIndex = 10;
            this.plotDefect1Bitstream.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Noise Causes Clock to Arrive Too Early \\n (t-early=-50*rhnormal)";
            this.plotDefect1Bitstream.Titles.Add(title2);
            // 
            // ButtonGenerateNominal
            // 
            this.ButtonGenerateNominal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ButtonGenerateNominal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonGenerateNominal.Location = new System.Drawing.Point(72, 711);
            this.ButtonGenerateNominal.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonGenerateNominal.Name = "ButtonGenerateNominal";
            this.ButtonGenerateNominal.Size = new System.Drawing.Size(193, 39);
            this.ButtonGenerateNominal.TabIndex = 1;
            this.ButtonGenerateNominal.Text = "Generate Nominal Set";
            this.ButtonGenerateNominal.UseVisualStyleBackColor = true;
            this.ButtonGenerateNominal.Click += new System.EventHandler(this.ButtonGenerateNominal_Click);
            // 
            // ButtonGenerateErrorSets
            // 
            this.ButtonGenerateErrorSets.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ButtonGenerateErrorSets.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonGenerateErrorSets.Location = new System.Drawing.Point(381, 711);
            this.ButtonGenerateErrorSets.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonGenerateErrorSets.Name = "ButtonGenerateErrorSets";
            this.ButtonGenerateErrorSets.Size = new System.Drawing.Size(251, 39);
            this.ButtonGenerateErrorSets.TabIndex = 2;
            this.ButtonGenerateErrorSets.Text = "Generate+Train Error Sets";
            this.ButtonGenerateErrorSets.UseVisualStyleBackColor = true;
            this.ButtonGenerateErrorSets.Click += new System.EventHandler(this.ButtonGenerateTrainErrorSets_Click);
            // 
            // plotNominalWaveform
            // 
            chartArea2.Name = "ChartArea1";
            this.plotNominalWaveform.ChartAreas.Add(chartArea2);
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Enabled = false;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend2.Name = "Bitstream with No Mfg Defects";
            legend2.TitleAlignment = System.Drawing.StringAlignment.Near;
            this.plotNominalWaveform.Legends.Add(legend2);
            this.plotNominalWaveform.Location = new System.Drawing.Point(2, 47);
            this.plotNominalWaveform.Margin = new System.Windows.Forms.Padding(2);
            this.plotNominalWaveform.Name = "plotNominalWaveform";
            this.tableLayoutPanel1.SetRowSpan(this.plotNominalWaveform, 2);
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Bitstream with No Mfg Defects";
            series1.Name = "Series1";
            this.plotNominalWaveform.Series.Add(series1);
            this.plotNominalWaveform.Size = new System.Drawing.Size(303, 320);
            this.plotNominalWaveform.TabIndex = 4;
            this.plotNominalWaveform.Text = "plotNominalWaveform";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Clock (t=100ps) Arrives At Correct Time";
            this.plotNominalWaveform.Titles.Add(title1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.buttonTestBayes, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.plotNominalWaveform, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ButtonGenerateErrorSets, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.ButtonGenerateNominal, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.plotDefect1Bitstream, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusBox, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.plotDefect2Bitstream, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ClassifierDefect1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.ClassifierDefect2, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.ClassifierNominal, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ClassifierExperiment, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonTrainTestBayes, 2, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1352, 758);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonTestBayes
            // 
            this.buttonTestBayes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTestBayes.Location = new System.Drawing.Point(1016, 711);
            this.buttonTestBayes.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTestBayes.Name = "buttonTestBayes";
            this.buttonTestBayes.Size = new System.Drawing.Size(155, 35);
            this.buttonTestBayes.TabIndex = 1;
            this.buttonTestBayes.Text = "Test Bayes";
            this.buttonTestBayes.UseVisualStyleBackColor = true;
            this.buttonTestBayes.Click += new System.EventHandler(this.buttonTestBayes_Click);
            // 
            // ClassifierDefect1
            // 
            this.ClassifierDefect1.BackColor = System.Drawing.SystemColors.Control;
            this.ClassifierDefect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClassifierDefect1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassifierDefect1.Location = new System.Drawing.Point(340, 379);
            this.ClassifierDefect1.Margin = new System.Windows.Forms.Padding(2);
            this.ClassifierDefect1.Multiline = true;
            this.ClassifierDefect1.Name = "ClassifierDefect1";
            this.tableLayoutPanel1.SetRowSpan(this.ClassifierDefect1, 2);
            this.ClassifierDefect1.Size = new System.Drawing.Size(334, 328);
            this.ClassifierDefect1.TabIndex = 16;
            // 
            // ClassifierDefect2
            // 
            this.ClassifierDefect2.BackColor = System.Drawing.SystemColors.Control;
            this.ClassifierDefect2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClassifierDefect2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassifierDefect2.Location = new System.Drawing.Point(678, 379);
            this.ClassifierDefect2.Margin = new System.Windows.Forms.Padding(2);
            this.ClassifierDefect2.Multiline = true;
            this.ClassifierDefect2.Name = "ClassifierDefect2";
            this.tableLayoutPanel1.SetRowSpan(this.ClassifierDefect2, 2);
            this.ClassifierDefect2.Size = new System.Drawing.Size(334, 328);
            this.ClassifierDefect2.TabIndex = 17;
            // 
            // ClassifierNominal
            // 
            this.ClassifierNominal.BackColor = System.Drawing.SystemColors.Control;
            this.ClassifierNominal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClassifierNominal.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassifierNominal.Location = new System.Drawing.Point(2, 379);
            this.ClassifierNominal.Margin = new System.Windows.Forms.Padding(2);
            this.ClassifierNominal.Multiline = true;
            this.ClassifierNominal.Name = "ClassifierNominal";
            this.tableLayoutPanel1.SetRowSpan(this.ClassifierNominal, 2);
            this.ClassifierNominal.Size = new System.Drawing.Size(334, 328);
            this.ClassifierNominal.TabIndex = 18;
            // 
            // ClassifierExperiment
            // 
            this.ClassifierExperiment.BackColor = System.Drawing.SystemColors.Control;
            this.ClassifierExperiment.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassifierExperiment.Location = new System.Drawing.Point(1016, 47);
            this.ClassifierExperiment.Margin = new System.Windows.Forms.Padding(2);
            this.ClassifierExperiment.Multiline = true;
            this.ClassifierExperiment.Name = "ClassifierExperiment";
            this.tableLayoutPanel1.SetRowSpan(this.ClassifierExperiment, 2);
            this.ClassifierExperiment.Size = new System.Drawing.Size(329, 328);
            this.ClassifierExperiment.TabIndex = 19;
            // 
            // buttonTrainTestBayes
            // 
            this.buttonTrainTestBayes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTrainTestBayes.Location = new System.Drawing.Point(678, 711);
            this.buttonTrainTestBayes.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTrainTestBayes.Name = "buttonTrainTestBayes";
            this.buttonTrainTestBayes.Size = new System.Drawing.Size(176, 39);
            this.buttonTrainTestBayes.TabIndex = 20;
            this.buttonTrainTestBayes.Text = "Train Bayes";
            this.buttonTrainTestBayes.UseVisualStyleBackColor = true;
            this.buttonTrainTestBayes.Click += new System.EventHandler(this.buttonTrainTestBayes_Click);
            // 
            // MachineLearningExampleMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 758);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MachineLearningExampleMainForm";
            this.Text = "MachineLearningExampleForm";
            ((System.ComponentModel.ISupportInitialize)(this.plotDefect2Bitstream)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plotDefect1Bitstream)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plotNominalWaveform)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart plotNominalWaveform;
        private System.Windows.Forms.Button ButtonGenerateErrorSets;
        private System.Windows.Forms.Button ButtonGenerateNominal;
        private System.Windows.Forms.DataVisualization.Charting.Chart plotDefect1Bitstream;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonExportMatlab;
        private System.Windows.Forms.DataVisualization.Charting.Chart plotDefect2Bitstream;
        private System.Windows.Forms.TextBox ClassifierDefect1;
        private System.Windows.Forms.TextBox ClassifierDefect2;
        private System.Windows.Forms.TextBox ClassifierNominal;
        private System.Windows.Forms.TextBox ClassifierExperiment;
        private System.Windows.Forms.Button buttonTrainTestBayes;
        private System.Windows.Forms.Button buttonTestBayes;
    }
}