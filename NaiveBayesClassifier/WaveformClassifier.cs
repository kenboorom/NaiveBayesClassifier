using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;


namespace MachineLearningExample1
{
    public class WaveformClassifier
    {

        public int maxClassifier;
        public int maxBits;

        int[][] learnedHistograms;

        int[] histogramToClassify;

        public WaveformClassifier(int passedMaxClassifer, int passedMaxBits)
        {
            maxClassifier = passedMaxClassifer;
            maxBits = passedMaxBits;
            learnedHistograms = new int[passedMaxClassifer+1][];
            for (int i = 0; i <= passedMaxClassifer; i++)
                learnedHistograms[i] = new int[1 << maxBits];
        }

        public void AddNewWaveform(Waveform genWave, int classifier)
        {
            int n = genWave.SampleAndReturnAsInt();
            if (n > 1023) n = 1023;
            learnedHistograms[classifier][n]++;
        }

        public void ClearWaveforms(int classifier)
        {
            Array.Clear(learnedHistograms[classifier], 0, learnedHistograms[classifier].Length);
        }

        public void BeginAnalysis()
        {
            histogramToClassify = new int[1 << maxBits];
        }

        public int ClosestClassifier()
        {
            int [] errorScores = new int[3];
            for (int n = 0; n <= 2; n++)
            {
                int currentError = 0;
                for (int h = 0; h < 1023; h++)
                    currentError = currentError + Math.Abs(learnedHistograms[3][h] - learnedHistograms[n][h]);
                errorScores[n] = currentError;
                TraceMessages.AddMessage($"Comparison with case {n} yields error score of {currentError}");
            }
            int minIndex = Array.IndexOf(errorScores, errorScores.Min());
            return minIndex;
        }


        public void AddWaveformForAnalysis(Waveform genWave)
        {
            int n = genWave.SampleAndReturnAsInt();
            histogramToClassify[n]++; 
        }

        // Which histogram looks most like histogramToClassify
        public int AnalyzeWaveformsReturnClassification()
        {
            int rtn = 0;
            return rtn;
        }

        public void ShowHistogram(int classifier)
        {
            int[] histogramToShow;

            if (classifier == -1)
                histogramToShow = histogramToClassify;
            else
                histogramToShow = learnedHistograms[classifier];

            TraceMessages.AddMessage($"Showing classifier for {classifier}");

            for (int i=0; i < histogramToShow.Length; i++)
            {
                if (histogramToShow[i] != 0)
                    TraceMessages.AddMessage($"{i} = {histogramToShow[i]}");
            }
        }

        public void ShowAnyClassifier(int classifier, TextBox targetText)
        {
            string allText = "";
            int[] histogramToShow = learnedHistograms[classifier];
            targetText.Clear();
            for (int n=0; n<histogramToShow.Length; n++)
            {
                int h = histogramToShow[n];
                if (h != 0)
                    allText = allText + "Pattern " + Convert.ToString(n, 2).PadLeft(10, '0') + $" occurs {h} times" + "\n\r";
            }
            targetText.AppendText($"{allText}\r\n");
        }

        public void PlotAnyHistogram(int classifier, Chart targetChart)
        {
            string plotName = targetChart.Legends[0].Name;

            targetChart.Series.Clear();

            // Add waveform and set chart type
            Series s = targetChart.Series.Add(plotName);
            s.BorderWidth = 1;
            s.ChartType = SeriesChartType.Line;

            targetChart.ChartAreas[0].AxisY.Maximum = 300;
            targetChart.ChartAreas[0].AxisX.LabelStyle.Format = "##.##";
            targetChart.ChartAreas[0].AxisX.Title = "psec";
            targetChart.ChartAreas[0].AxisX.Minimum = 0;

            for (int i = 0; i < learnedHistograms[classifier].Length - 1; i++)
            {
                // We have to round the sample time because the Chart control goes nuts with precision
                // SPlit out for debugging
                int xval = i;
                int yval = learnedHistograms[classifier][i];

                s.Points.AddXY(xval, yval);
                //TraceMessages.AddMessage($"Plotted {xval}, {yval}");
            }

        }

    }
}

