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

        public static int GetRandom (int oneSigmaValue)
        {
            double doubleOneSigmaValue = oneSigmaValue;

            Random rand = new Random(); //reuse this if you are generating many
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


    public class GeneratedOutputWaveformGivenParametrics
    {
        public int flopClockSkewStandardDeviation;
        public int flopClockSkewInPicoseconds;

        public int[] outputWaveformInMillivolts;

        // 10-symbol waveform
        public const int numberSymbols = 10;
        private int[] inputSymbolSequence = { 0, 0, 0, 1, 1, 1, 0, 0, 1, 0};

        const int PICOSECONDS_PER_SYMBOL = 100;
        const int NOMINAL_DELAY_TIME_IN_PICOSECONDS = 20;

        // =========================== ONE SAMPLE IS ALWAYS ONE PICOSECONDS ================

        public GeneratedOutputWaveformGivenParametrics(int oneSigmaClockSkew)
        {
            int absSigmaSkew = Math.Abs(oneSigmaClockSkew);
            int sgnSigmaSkew = Math.Sign(oneSigmaClockSkew);

            flopClockSkewInPicoseconds = oneSigmaClockSkew;

            // Use 1000 samples per symbol.  Assume 1 Ghz transmission clock, each symbol = 1000 ps
            // Each sample is 1 psec
            // Pad below by full clock cycle in case we sample past end of period
            int[] sourceWaveform = new int[inputSymbolSequence.Length * PICOSECONDS_PER_SYMBOL];

            outputWaveformInMillivolts = new int[inputSymbolSequence.Length * PICOSECONDS_PER_SYMBOL];

            // Generate input waveform - TODO - make this static
            int destinationLocation = 0;
            foreach (int theSymbol in inputSymbolSequence)
               for (int sampleNumber=0; sampleNumber <=PICOSECONDS_PER_SYMBOL-1; sampleNumber++)
                    sourceWaveform[destinationLocation++] = theSymbol * 1000;

            // Generate output waveform.  Run through 10 clock cycles
            destinationLocation = 0;

            // We need to produce the output from a sampling flop.  So we will emulate a flop
            // that is sampling based on a clock.  We do this by cycling through the time steps
            // and performing sampling operations on active edges of the clock.

            // First, let's decide where the active edges are going to be
            int[] activeEdges = new int[inputSymbolSequence.Length];

            for (int clockCycle = 0; clockCycle <= inputSymbolSequence.Length - 1; clockCycle++)
            {
                // Each sample is 1 psec
                int randomSkewForThisSample = Gaussian.GetRandom(absSigmaSkew) * sgnSigmaSkew;
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
                    currentSample = sourceWaveform[timeInPicoSeconds];
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

        public void PlotWaveform(Chart targetChart)
        {
            targetChart.Series.Clear();

            // Add waveform and set chart type
            Series s = targetChart.Series.Add("Waveform");
            s.BorderWidth = 5;
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

                s.Points.AddXY(xval, yval);
                //TraceMessages.AddMessage($"Plotted {xval}, {yval}");
             }
        }

        public int ConvertWaveformToInt()
        {
            int rtn = 0;
            for (int sampleNumber = 0; sampleNumber <= inputSymbolSequence.Length - 1; sampleNumber++)
            {
                int sampleTime = sampleNumber * PICOSECONDS_PER_SYMBOL + NOMINAL_DELAY_TIME_IN_PICOSECONDS;
                sampleTime += 1;
                if (outputWaveformInMillivolts[sampleTime] == 0)
                    rtn = rtn << 2;
                else
                    rtn = (rtn << 1) | 1;
            }
            return rtn;
        }

    }
}
