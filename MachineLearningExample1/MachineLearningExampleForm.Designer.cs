namespace MachineLearningExample1
{
    partial class MachineLearningExampleForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.TrainButton = new System.Windows.Forms.Button();
            this.AnalyzeButton = new System.Windows.Forms.Button();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.plotNominalWaveform = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.plotSampledWaveform = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plotNominalWaveform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plotSampledWaveform)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 353F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 341F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 302F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.statusBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.AnalyzeButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.TrainButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.plotNominalWaveform, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.plotSampledWaveform, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 238F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1218, 909);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(999, 453);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 56);
            this.button1.TabIndex = 0;
            this.button1.Text = "Quit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TrainButton
            // 
            this.TrainButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TrainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrainButton.Location = new System.Drawing.Point(48, 303);
            this.TrainButton.Name = "TrainButton";
            this.TrainButton.Size = new System.Drawing.Size(257, 87);
            this.TrainButton.TabIndex = 1;
            this.TrainButton.Text = "Generate Training Set + Train";
            this.TrainButton.UseVisualStyleBackColor = true;
            this.TrainButton.Click += new System.EventHandler(this.TrainButton_Click);
            // 
            // AnalyzeButton
            // 
            this.AnalyzeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnalyzeButton.Location = new System.Drawing.Point(356, 303);
            this.AnalyzeButton.Name = "AnalyzeButton";
            this.AnalyzeButton.Size = new System.Drawing.Size(335, 87);
            this.AnalyzeButton.TabIndex = 2;
            this.AnalyzeButton.Text = "Generate Experimental Set + Analyze";
            this.AnalyzeButton.UseVisualStyleBackColor = true;
            // 
            // statusBox
            // 
            this.statusBox.Location = new System.Drawing.Point(697, 65);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(257, 193);
            this.statusBox.TabIndex = 3;
            // 
            // plotNominalWaveform
            // 
            chartArea1.Name = "ChartArea1";
            this.plotNominalWaveform.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.plotNominalWaveform.Legends.Add(legend1);
            this.plotNominalWaveform.Location = new System.Drawing.Point(3, 65);
            this.plotNominalWaveform.Name = "plotNominalWaveform";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.plotNominalWaveform.Series.Add(series1);
            this.plotNominalWaveform.Size = new System.Drawing.Size(347, 232);
            this.plotNominalWaveform.TabIndex = 4;
            this.plotNominalWaveform.Text = "plotNominalWaveform";
            // 
            // plotSampledWaveform
            // 
            chartArea2.Name = "ChartArea1";
            this.plotSampledWaveform.ChartAreas.Add(chartArea2);
            this.plotSampledWaveform.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.plotSampledWaveform.Legends.Add(legend2);
            this.plotSampledWaveform.Location = new System.Drawing.Point(356, 65);
            this.plotSampledWaveform.Name = "plotSampledWaveform";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.plotSampledWaveform.Series.Add(series2);
            this.plotSampledWaveform.Size = new System.Drawing.Size(335, 232);
            this.plotSampledWaveform.TabIndex = 5;
            this.plotSampledWaveform.Text = "plotSampledWaveform";
            // 
            // MachineLearningExampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 933);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MachineLearningExampleForm";
            this.Text = "MachineLearningExampleForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plotNominalWaveform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plotSampledWaveform)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button TrainButton;
        private System.Windows.Forms.Button AnalyzeButton;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart plotNominalWaveform;
        private System.Windows.Forms.DataVisualization.Charting.Chart plotSampledWaveform;
    }
}

