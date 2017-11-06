using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearningExample1
{

    /* USAGE EXAMPLE
     *             nbm.TrainPredictor(actualArray, actualClasses);

            // Feed original values back into predictor
            int[] resubmitClasses;
            resubmitClasses = nbm.PredictedClasses(actualArray);

            // Report confusion matrix
            ConfusionMatrix("RESUBMIT CONFUSION MATRIX", fs, 3, actualClasses, resubmitClasses);
   */



    public struct oneObservation
    {
        public int classNumber;
        public int[] observations;
    }

    public class NaiveBayesMultinomial
    {
        private int numberPredictors;
        private int numberClasses;

        double[,] conditionalProbabilities;

        public NaiveBayesMultinomial(int passedNumberPredictors, int passedNumberClasses)
        {
            numberPredictors = passedNumberPredictors;
            numberClasses = passedNumberClasses;
            conditionalProbabilities = new double[passedNumberClasses, passedNumberPredictors];
        }

        public void TrainPredictor(int[,] predictors, int[] actualClasses)
        {
            int numberObservations = actualClasses.GetLength(0);

            // Copy into structure so we can use LINQ
            var myObservations = new oneObservation[numberObservations];
            for (int n = 0; n <= actualClasses.GetUpperBound(0); n++)
            {
                myObservations[n].classNumber = actualClasses[n];
                myObservations[n].observations = new int[20];
                for (int m = 0; m < numberPredictors; m++)
                    myObservations[n].observations[m] = predictors[n, m];
            }

            // Enumerate each class
            for (int n = 0; n < numberClasses; n++)
            {

                var justThisClass = from vvv in myObservations
                                    where vvv.classNumber == n
                                    select vvv;

                int numberInClass = justThisClass.Count();
                // Go through each predictor
                double totalProb = 0;
                for (int m = 0; m < numberPredictors; m++)
                {
                    int numberTimesOne = justThisClass.Count(p => p.observations[m] == 1);
                    double probabilityOfOne = (double)numberTimesOne / (double)numberInClass;
                    conditionalProbabilities[n, m] = probabilityOfOne;
                    totalProb += probabilityOfOne;
                }
            }
        }

        public static string ConfusionMatrix(string name, int numberRows, int[] correct, int[] actual)
        {

            StringBuilder rtn = new StringBuilder();

            // Calculate confusion matrix
            int[,] cm = new int[numberRows, numberRows];

            for (int n = 0; n <= correct.GetUpperBound(0); n++)
            {
                cm[correct[n], actual[n]]++;
            }

            // Report confusion matrix
            rtn.Append("\r\n\r\n");
            rtn.Append($"\r\n{name}\r\n             Bayes Output");
                      rtn.Append($"\r\n          Nominal   Early     Late");

            for (int n = 0; n < numberRows; n++)
            {
                rtn.Append("\r\n");
                if (n == 0) rtn.Append("Nominal   ");
                if (n == 1) rtn.Append("Early     ");
                if (n == 2) rtn.Append("Late      ");
                for (int m = 0; m < numberRows; m++)
                {
                    rtn.Append($"{cm[n, m],7}");
                }
            }
            rtn.Append($"\r\n");
            return rtn.ToString();
        }


        private int getPrediction(int[] listObservations)
        {
            double[] listProbabilities = new double[numberClasses];


            for (int n = 0; n < numberClasses; n++)
            {
                double jointProbability = 1;
                for (int m = 0; m <= listObservations.GetUpperBound(0); m++)
                {
                    int observeValue = listObservations[m];
                    double c = conditionalProbabilities[n, m];
                    if (observeValue == 1)
                        jointProbability = jointProbability * c;
                    else
                        jointProbability = jointProbability * (1 - c);
                }
                listProbabilities[n] = jointProbability;
            }


            // Return best prediction
            int bestClass = 0;
            double bestProbability = listProbabilities[0];
            for (int n = 1; n < numberClasses; n++)
                if (listProbabilities[n] > bestProbability)
                {
                    bestProbability = listProbabilities[n];
                    bestClass = n;
                }
            return bestClass;
        }


        public int[] PredictedClasses(int[,] predictorData)
        {
            int numberPredictionsToReturn = predictorData.GetLength(0);
            int[] returnClasses = new int[numberPredictionsToReturn];

            // Go through all requested rows
            for (int n = 0; n <= predictorData.GetUpperBound(0); n++)
            {
                // Get the observations for this row
                int[] oneSet = new int[numberPredictors];
                for (int m = 0; m < numberPredictors; m++)
                    oneSet[m] = predictorData[n, m];
                int onePrediction = getPrediction(oneSet);
                returnClasses[n] = onePrediction;
            }

            return returnClasses;
        }
    }

}
