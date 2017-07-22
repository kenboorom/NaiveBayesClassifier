using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearningExample1
{
    public class WaveformClassifier
    {

        public int MaxClassifier;

        public WaveformClassifier(int passedMaxClassifer)
        {
            MaxClassifier = passedMaxClassifer;
        }

        public void TrainNewWaveform(int[] inputWaveform, int classifier)
        {

        }

        public int[] ClassifyNewWaveform(int [] inputWaveform)
        {
            int [] classifierMatrix = new int[MaxClassifier];

            return classifierMatrix;

        }
    }
}
