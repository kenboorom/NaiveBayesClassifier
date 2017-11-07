using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;


namespace MachineLearningExample1
{
    public static class Gaussian
    {
        // Reference: Box-Muller Transform, StackExchange
        // This returns a positive number with a standard deviation (sigma) of the number passed.
        // i.e. This returns a right-half normal distributino

        static Random rand;

        static Gaussian()
        {
            rand = new Random();
        }

        public static int GetRandom (int oneSigmaValue)
        {
            double doubleOneSigmaValue = oneSigmaValue;

            double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)

            double randNormal = randStdNormal * doubleOneSigmaValue;
            if (randNormal < 0.0)
                randNormal = -1.0 * randNormal;
            return (int) randNormal;

        }
    }


    public class VoltageWaveformAfterRegister
    {
        public int flopClockSkewStandardDeviation;
        public int flopClockSkewInPicoseconds;

        public int[] outputWaveformInMillivolts;

        // 10-symbol waveform
        public const int numberSymbols = 10;
        private int[] inputSymbolSequence = { 0, 0, 0, 1, 1, 1, 0, 0, 1, 0};

        const int PICOSECONDS_PER_SYMBOL = 100;
        const int NOMINAL_DELAY_TIME_IN_PICOSECONDS = 20;

        int waveformsSummed = 0;
        private int[] sourceWaveformInMillivolts;

        private void InitializeSourceWaveform()
        {
            int destinationLocation = 0;
            // Generate output waveform.  Run through 10 clock cycles

            // Use 1000 samples per symbol.  Assume 1 Ghz transmission clock, each symbol = 1000 ps
            // Each sample is 1 psec
            // Pad below by full clock cycle in case we sample past end of period
            sourceWaveformInMillivolts = new int[inputSymbolSequence.Length * PICOSECONDS_PER_SYMBOL];

            // Generate input waveform - TODO - Make this static
            foreach (int theSymbol in inputSymbolSequence)
                for (int sampleNumber = 0; sampleNumber <= PICOSECONDS_PER_SYMBOL - 1; sampleNumber++)
                    sourceWaveformInMillivolts[destinationLocation++] = theSymbol * 1000;           // Convert symbol to mV
        }

        // =========================== ONE SAMPLE IS ALWAYS ONE PICOSECONDS ================

        // Constructor #1 - just make a plain old waveform (for nominal case)
        public VoltageWaveformAfterRegister() : this(0)
        {
        }

        // Constructor #2 - Make a waveform and load it with sampled data with random clock skew problem
        public VoltageWaveformAfterRegister(int oneSigmaClockSkew)
        {
            int absSigmaSkew = Math.Abs(oneSigmaClockSkew);
            int sgnSigmaSkew = Math.Sign(oneSigmaClockSkew);

            outputWaveformInMillivolts = new int[inputSymbolSequence.Length * PICOSECONDS_PER_SYMBOL];

            flopClockSkewInPicoseconds = oneSigmaClockSkew;

            InitializeSourceWaveform();

            // We need to produce the output from a sampling flop.  So we will emulate a flop
            // that is sampling based on a clock.  We do this by cycling through the time steps
            // and performing sampling operations on active edges of the clock.

            // First, let's decide where the active edges are going to be
            int[] activeEdges = new int[inputSymbolSequence.Length];

            for (int clockCycle = 0; clockCycle <= inputSymbolSequence.Length - 1; clockCycle++)
            {
                int randomSkewForThisSample;
                // Each sample is 1 psec
                if (absSigmaSkew == 0)
                    randomSkewForThisSample = 0;
                else
                    randomSkewForThisSample = Gaussian.GetRandom(absSigmaSkew) * sgnSigmaSkew;
                //TraceMessages.AddMessage($"For clock {clockCycle} skew is {randomSkewForThisSample}");

                int thisEdge = NOMINAL_DELAY_TIME_IN_PICOSECONDS + clockCycle * PICOSECONDS_PER_SYMBOL + randomSkewForThisSample;
                activeEdges[clockCycle] = thisEdge;
            }

            // Now, march through all the time steps emulating a flop and sample at appropriate
            // times
            int currentClockIndex = 0;
            int nextSamplingTimeInPicoseconds = activeEdges[currentClockIndex];
            int currentSample = 0;
            for (int timeInPicoSeconds = 0; timeInPicoSeconds < inputSymbolSequence.Length * PICOSECONDS_PER_SYMBOL; timeInPicoSeconds++)
            {
                outputWaveformInMillivolts[timeInPicoSeconds] = currentSample;
                if (timeInPicoSeconds >= nextSamplingTimeInPicoseconds)
                {
                    currentSample = sourceWaveformInMillivolts[timeInPicoSeconds];
                    // Advance the pointer to the next clock.  If no more clocks, put the nexxt
                    // sampling time at a high number so it becomes inactive.
                    if (currentClockIndex < activeEdges.Length-1)
                    {
                        currentClockIndex++;
                        nextSamplingTimeInPicoseconds = activeEdges[currentClockIndex];
                    }
                    else
                        nextSamplingTimeInPicoseconds = int.MaxValue;
                }
            }
        }

        public void ClearThenPlotWaveform(Chart targetChart)
        {
            string theName = targetChart.Legends[0].Name;
            targetChart.Series.Clear();
            PlotWaveform(targetChart, theName, 0);
        }

        public void ClearPlot(Chart targetChart)
        {
            targetChart.Series.Clear();
        }

        public void PlotWaveform(Chart targetChart, string theName, int offset)
        {
            // Add waveform and set chart type
            Series s = targetChart.Series.Add(theName);
            s.BorderWidth = 3;
            s.ChartType = SeriesChartType.Line;

            targetChart.ChartAreas[0].AxisY.Maximum = 1500;
            targetChart.ChartAreas[0].AxisX.LabelStyle.Format = "##.##";
            targetChart.ChartAreas[0].AxisX.Title = "psec";
            targetChart.ChartAreas[0].AxisX.Minimum = 0;

            for (int i = 0; i < outputWaveformInMillivolts.Length - 1; i++)
            {
                // We have to round the sample time because the Chart control goes nuts with precision
                // SPlit out for debugging
                int xval = i;
                int yval = outputWaveformInMillivolts[i];

                s.Points.AddXY(xval, yval+offset);
                //TraceMessages.AddMessage($"Plotted {xval}, {yval}");
             }
        }

        public int GetOneSample(int sampleNumber)
        {
            int sampleTime = sampleNumber * PICOSECONDS_PER_SYMBOL + NOMINAL_DELAY_TIME_IN_PICOSECONDS;
            sampleTime += 1;
            if (outputWaveformInMillivolts[sampleTime] == 0)
                return 0;
            else
                return 1;
        }

        public int SampleAndReturnAsInt()
        {
            int rtn = 0;
            int oneBit;
            for (int sampleNumber = 0; sampleNumber <= inputSymbolSequence.Length - 1; sampleNumber++)
            {
                int sampleTime = sampleNumber * PICOSECONDS_PER_SYMBOL + NOMINAL_DELAY_TIME_IN_PICOSECONDS;
                sampleTime += 1;
                if (outputWaveformInMillivolts[sampleTime] == 0)
                    oneBit = 0;
                else
                    oneBit = 1;
                rtn = (rtn << 1) | oneBit;
            }
            return rtn;
        }

        public string SampleAndReturnAsString()
        {
            string rtn = "";
            for (int sampleNumber = 0; sampleNumber <= inputSymbolSequence.Length - 1; sampleNumber++)
            {
                int sampleTime = sampleNumber * PICOSECONDS_PER_SYMBOL + NOMINAL_DELAY_TIME_IN_PICOSECONDS;
                sampleTime += 1;
                if (outputWaveformInMillivolts[sampleTime] == 0)
                    rtn = rtn + "0";
                else
                    rtn = rtn + "1";
            }
            return rtn;

        }

        public string SampleAndReturnAsStringWithCommas()
        {
            string rtn = "";
            for (int sampleNumber = 0; sampleNumber <= inputSymbolSequence.Length - 1; sampleNumber++)
            {
                int sampleTime = sampleNumber * PICOSECONDS_PER_SYMBOL + NOMINAL_DELAY_TIME_IN_PICOSECONDS;
                sampleTime += 1;
                if (outputWaveformInMillivolts[sampleTime] == 0)
                    rtn = rtn + "0,";
                else
                    rtn = rtn + "1,";
            }
            return rtn.Substring(0, rtn.Length - 1);

        }

        public void AddWaveformToSummationForVisualization(Chart targetChart, VoltageWaveformAfterRegister genWave2, int count)
        {
            waveformsSummed++;

            for (int i = 0; i < outputWaveformInMillivolts.Length; i++)
                outputWaveformInMillivolts[i] += genWave2.outputWaveformInMillivolts[i];

            string theName = targetChart.Legends[0].Name;
            targetChart.Series.Clear();
            PlotWaveform(targetChart, theName, count*10);

        }

        public void PlotAveragedWaveform(Chart targetChart)
        {
            //for (int i = 0; i < outputWaveformInMillivolts.Length; i++)
            //    outputWaveformInMillivolts[i] /= waveformsSummed;
            //this.ClearThenPlotWaveform(targetChart);
        }

    }
}
