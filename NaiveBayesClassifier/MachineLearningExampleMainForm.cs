using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;


namespace MachineLearningExample1
{
    public partial class MachineLearningExampleMainForm : Form
    {
        const int NUMBER_ITERATIONS = 100;

        List<Waveform> nominalWaves = new List<Waveform>();
        List<Waveform> earlyWaves = new List<Waveform>();
        List<Waveform> lateWaves = new List<Waveform>();
        List<Waveform> experimentalWaves = new List<Waveform>();

        public MachineLearningExampleMainForm()
        {
            InitializeComponent();
            TraceMessages.SetTrace(this.statusBox);
            InitializePlot(plotNominalWaveform);
            //nitializePlot(plotNominalHistogram);

            InitializePlot(plotDefect1Bitstream);
            //InitializePlot(plotDefect1Histogram);
            InitializePlot(plotDefect2Bitstream);
            //InitializePlot(plotDefect2Histogram);

            //InitializePlot(plotExperimentBitstream);
            //InitializePlot(plotExperimentHistogram);

        }

        private void InitializePlot(Chart targetChart)
        {
            string plotName = targetChart.Legends[0].Name;

            targetChart.Series.Clear();

            // Add waveform and set chart type
            Series s = targetChart.Series.Add(plotName);
            s.BorderWidth = 5;
            s.ChartType = SeriesChartType.Line;
            targetChart.ChartAreas[0].AxisY.Maximum = 1500;

            targetChart.ChartAreas[0].AxisX.LabelStyle.Format = "##.##";
            targetChart.ChartAreas[0].AxisX.Title = "psec";
            targetChart.ChartAreas[0].AxisX.Minimum = 0;
            targetChart.ChartAreas[0].AxisX.Maximum = 1200;

            s.Points.AddXY(0, 0);
            s.Points.AddXY(10000, 0);
        }

        WaveformClassifier w = new WaveformClassifier(3, Waveform.numberSymbols);

        private void ButtonGenerateNominal_Click(object sender, EventArgs e)
        {

            TraceMessages.AddMessage($"Running {NUMBER_ITERATIONS} trials with no clock skew error.");
            
            Random r = new Random();

            w.ClearWaveforms(0);
            nominalWaves.Clear();

            // Create objects with classification 0 (nominal) and train
            for (int n = 1; n <= NUMBER_ITERATIONS; n++)
            {
                Waveform g = new Waveform(0);

                w.AddNewWaveform(g, 0);

                // Plot last wavefrom
                if (n == NUMBER_ITERATIONS)
                {
                    g.ClearThenPlotWaveform(plotNominalWaveform);
                    string s = g.SampleAndReturnAsString();
                    TraceMessages.AddMessage($"Pattern = {s}");
                    nominalWaves.Add(g);
                }

            }
            w.ShowAnyClassifier(0, ClassifierNominal);
            // w.PlotAnyHistogram(0, plotNominalHistogram);
            w.ShowHistogram(0);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonGenerateTrainErrorSets_Click(object sender, EventArgs e)
        {
            Waveform SumClass1ForVisualize = new Waveform();
            Waveform SumClass2ForVisualize = new Waveform();

            TraceMessages.AddMessage($"Running {NUMBER_ITERATIONS} trials with negative clock skew error, stddev=50 psec");

            Random r = new Random();
            // Create objects with classification 1 (clock too early) and train
            plotDefect1Bitstream.Series.Clear();
            w.ClearWaveforms(1);
            earlyWaves.Clear();
            for (int n = 1; n <= NUMBER_ITERATIONS; n++)
            {
                double theSkew = -1.0 * r.NextDouble() * 50.0;
                Waveform g =  new Waveform((int)theSkew);
                string s = g.SampleAndReturnAsString();
                TraceMessages.AddMessage($"Pattern={s}");
                // Just plot the first 10 to avoid muddling screen
                if (n < 10)
                    g.PlotWaveform(plotDefect1Bitstream, $"{n}", n * 10);
                // SumClass1ForVisualize.AddWaveformToSummationForVisualization(g);
                w.AddNewWaveform(g, 1);
                earlyWaves.Add(g);
            }

            TraceMessages.AddMessage($"Running {NUMBER_ITERATIONS} trials with positive clock skew error, stddev=50psec.");

            plotDefect2Bitstream.Series.Clear();
            // Create objects with classification 2 (clock too late) and train
            w.ClearWaveforms(2);

            lateWaves.Clear();
            for (int n = 1; n <= NUMBER_ITERATIONS; n++)
            {
                double theSkew = r.NextDouble() * 50.0;
                Waveform g =
                    new Waveform((int)theSkew);
                string s = g.SampleAndReturnAsString();
                TraceMessages.AddMessage($"Pattern={s}");
                // SumClass2ForVisualize.AddWaveformToSummationForVisualization(g);
                if (n<10)
                    g.PlotWaveform(plotDefect2Bitstream, $"{n}", n * 10);
                w.AddNewWaveform(g, 2);
                lateWaves.Add(g);
            }

            w.ShowHistogram(1);
            w.ShowHistogram(2);

            w.ShowAnyClassifier(1, ClassifierDefect1);
            w.ShowAnyClassifier(2, ClassifierDefect2);

            //w.PlotAnyHistogram(1, plotDefect1Histogram);
            //w.PlotAnyHistogram(2, plotDefect2Histogram);

            // SumClass1ForVisualize.PlotAveragedWaveform(plotDefect1Bitstream);
            // SumClass2ForVisualize.PlotAveragedWaveform(plotDefect2Bitstream);

        }

        private void plotSampledWaveform_Click(object sender, EventArgs e)
        {

        }

        private void plotExperimentBitstream_Click(object sender, EventArgs e)
        {

        }

        private void plotExperimentHistogram_Click(object sender, EventArgs e)
        {

        }

        private void buttonExportToMatlab_Click(object sender, EventArgs e)
        {
            exportOne(nominalWaves, "ml_wave_nominal.csv");
            exportOne(earlyWaves, "ml_wave_early.csv");
            exportOne(lateWaves, "ml_wave_late.csv");
            exportOne(experimentalWaves, "ml_wave_experiment.csv");
        }

        private void exportOne(List<Waveform> waves, string theFile)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(theFile))
            {
                foreach (var oneWave in waves)
                {
                    string s = $"{oneWave.flopClockSkewInPicoseconds}";
                    string s2 = oneWave.SampleAndReturnAsStringWithCommas();
                    file.WriteLine(s + "," + s2);
                }
            }
        }

            
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        NaiveBayesMultinomial nbm;

        private void buttonTrainTestBayes_Click(object sender, EventArgs e)
        {
            nbm = new NaiveBayesMultinomial(10, 3);
            int [,] actualArray = new int [300, 10];
            int [] actualClasses = new int [300];

            for (int m=0; m<100; m++)
            {
                actualClasses[m] = 0;
                actualClasses[m + 100] = 1;
                actualClasses[m + 200] = 2;
                for (int n=0; n<10; n++)
                {
                    actualArray[m,n] = nominalWaves[0].GetOneSample(n);
                    actualArray[m+100,n] = earlyWaves[m].GetOneSample(n);
                    actualArray[m+200,n] = lateWaves[m].GetOneSample(n);
                }
            }

            nbm.TrainPredictor(actualArray, actualClasses);

            // Feed original values back into predictor
            int[] resubmitClasses;
            resubmitClasses = nbm.PredictedClasses(actualArray);

            // Report confusion matrix
            string s = NaiveBayesMultinomial.ConfusionMatrix("Error Matrix - Resubmit Training Data", 3, actualClasses, resubmitClasses);

            TraceMessages.AddMessage(s);

        }

        private void buttonTestBayes_Click(object sender, EventArgs e)
        {
            ButtonGenerateTrainErrorSets_Click(sender, e);

            int[,] actualArray = new int[300, 10];
            int[] actualClasses = new int[300];

            for (int m = 0; m < 100; m++)
            {
                actualClasses[m] = 0;
                actualClasses[m + 100] = 1;
                actualClasses[m + 200] = 2;
                for (int n = 0; n < 10; n++)
                {
                    actualArray[m, n] = nominalWaves[0].GetOneSample(n);
                    actualArray[m + 100, n] = earlyWaves[m].GetOneSample(n);
                    actualArray[m + 200, n] = lateWaves[m].GetOneSample(n);
                }
            }

            int[] experimentClasses;
            experimentClasses = nbm.PredictedClasses(actualArray);

            // Report confusion matrix
            string s = NaiveBayesMultinomial.ConfusionMatrix("Error Matrix - Experimental data", 3, actualClasses, experimentClasses);

            TraceMessages.AddMessage(s);
        }

    }

    static public class TraceMessages
    {
        static TextBox m;

        static public void SetTrace(TextBox passedForm)
        {
            m = passedForm;
        }

        static public void AddMessage(string theMessage)
        {
            string currentTime = DateTime.Now.ToString("h:mm:ss tt");
            m.AppendText($"{currentTime} {theMessage}\r\n");
            m.SelectionStart = m.TextLength;
            m.ScrollToCaret();

        }
    }


}
