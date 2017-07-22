using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void TrainNewWaveform(GeneratedOutputWaveformGivenParametrics genWave, int classifier)
        {
            int n = genWave.ConvertWaveformToInt();
            learnedHistograms[classifier][n]++;
        }

        public void BeginAnalysis()
        {
            histogramToClassify = new int[1 << maxBits];
        }

        public void AddWaveformForAnalysis(GeneratedOutputWaveformGivenParametrics genWave)
        {
            int n = genWave.ConvertWaveformToInt();
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

            TraceMessages.AddMessage($"Showing histogram for {classifier}");

            for (int i=0; i < histogramToShow.Length; i++)
            {
                if (histogramToShow[i] != 0)
                    TraceMessages.AddMessage($"{i} = {histogramToShow[i]}");
            }
        }

    }
}

