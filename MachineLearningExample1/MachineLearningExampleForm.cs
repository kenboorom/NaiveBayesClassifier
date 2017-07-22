using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineLearningExample1
{
    public partial class MachineLearningExampleForm : Form
    {

        // Allow for 3 classes - 0=Nominal, 1=Negative clock skew, 2=Positive clock skew

        public WaveformClassifier w = new WaveformClassifier(2);

        public MachineLearningExampleForm()
        {
            InitializeComponent();
            TraceMessages.SetTrace(this.statusBox);
        }

        private void TrainButton_Click(object sender, EventArgs e)
        {

            TraceMessages.AddMessage("Creating trial set of 300 waveforms each");

            Random r = new Random();

            // Create objects with classification 0 (nominal) and train
            for (int n=0; n<=299; n++)
            {
                GeneratedOutputWaveformGivenParametrics g =
                    new GeneratedOutputWaveformGivenParametrics(0);

                w.TrainNewWaveform(g.outputWaveformInMillivolts, 0);

                // Plot last wavefrom
                if (n==299)
                {
                    g.PlotWaveform(plotNominalWaveform);
                }

            }

            // Create objects with classification 1 (clock too early) and train
            for (int n = 0; n <= 299; n++)
            {
                double theSkew = -1.0 * r.NextDouble() * 50.0;
                GeneratedOutputWaveformGivenParametrics g =
                    new GeneratedOutputWaveformGivenParametrics((int) theSkew);

                w.TrainNewWaveform(g.outputWaveformInMillivolts, 1);
            }

            // Create objects with classification 2 (clock too late) and train
            for (int n = 0; n <= 299; n++)
            {
                double theSkew = r.NextDouble() * 50.0;
                GeneratedOutputWaveformGivenParametrics g =
                    new GeneratedOutputWaveformGivenParametrics((int) theSkew);

                w.TrainNewWaveform(g.outputWaveformInMillivolts, 2);

            }

            string currentTime;

            currentTime = DateTime.Now.ToString("h:mm:ss tt");
            statusBox.AppendText($"{currentTime} Done!\r\n");
            statusBox.SelectionStart = statusBox.TextLength;
            statusBox.ScrollToCaret();


        }
    }
}
