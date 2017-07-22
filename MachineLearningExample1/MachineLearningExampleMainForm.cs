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
    public partial class MachineLearningExampleMainForm : Form
    {
        public MachineLearningExampleMainForm()
        {
            InitializeComponent();
            TraceMessages.SetTrace(this.statusBox);
        }

        WaveformClassifier w = new WaveformClassifier(2, GeneratedOutputWaveformGivenParametrics.numberSymbols);

        private void TrainButton_Click(object sender, EventArgs e)
        {

            TraceMessages.AddMessage("Creating trial set of 300 waveforms each");

            Random r = new Random();

            // Create objects with classification 0 (nominal) and train
            for (int n = 0; n <= 299; n++)
            {
                GeneratedOutputWaveformGivenParametrics g =
                    new GeneratedOutputWaveformGivenParametrics(0);

                w.TrainNewWaveform(g, 0);

                // Plot last wavefrom
                if (n == 299)
                {
                    g.PlotWaveform(plotNominalWaveform);
                }

            }

            // Create objects with classification 1 (clock too early) and train
            for (int n = 0; n <= 299; n++)
            {
                double theSkew = -1.0 * r.NextDouble() * 50.0;
                GeneratedOutputWaveformGivenParametrics g =
                    new GeneratedOutputWaveformGivenParametrics((int)theSkew);

                w.TrainNewWaveform(g, 1);
            }

            // Create objects with classification 2 (clock too late) and train
            for (int n = 0; n <= 299; n++)
            {
                double theSkew = r.NextDouble() * 50.0;
                GeneratedOutputWaveformGivenParametrics g =
                    new GeneratedOutputWaveformGivenParametrics((int)theSkew);

                w.TrainNewWaveform(g, 2);

            }

            string currentTime;

            currentTime = DateTime.Now.ToString("h:mm:ss tt");
            statusBox.AppendText($"{currentTime} Done!\r\n");
            statusBox.SelectionStart = statusBox.TextLength;
            statusBox.ScrollToCaret();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void AnalyzeButton_Click(object sender, EventArgs e)
        {
            w.ShowHistogram(0);
            w.ShowHistogram(1);
            w.ShowHistogram(2);
        }

        private void plotSampledWaveform_Click(object sender, EventArgs e)
        {

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
            m.AppendText($"{currentTime} ${theMessage}\r\n");
            m.SelectionStart = m.TextLength;
            m.ScrollToCaret();

        }
    }


}
