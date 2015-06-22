using System;
namespace Perceptrons
{
    class PerceptronProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine(UIElements.Banner('=', 26, "Begin Perceptron demo."));
            Console.WriteLine("Predicting Liberal(-1) or Conservative(1) from age, income.");
            double[][] trainingData = SetupTrainingData();
            Console.WriteLine("\nTraining data is:\n(Age, Income, Political bent)");
            showData(trainingData);
            Console.WriteLine("\nCreating Perceptron:\n");
            Perceptron perceptron = new Perceptron(2);
            double alpha = 0.001;
            int maxEpochs = 100;
            Console.WriteLine("\nBegin training:");
            double[] Weights = perceptron.Train(trainingData, alpha, maxEpochs);
            Console.WriteLine("\nTraining complete.\n");
            Console.WriteLine("\nComputed weights:");
            showData(Weights);

            Predict(perceptron);
            Console.WriteLine(UIElements.Banner('=', 26, "End Perceptron demo."));
            Console.ReadLine();
        }

        private static void Predict(Perceptron perceptron)
        {
            double[][] toPredictData = SetupPredictionInput();
            Console.WriteLine("\nPredictions for new data.");
            foreach (double[] row in toPredictData)
            {
                Console.Write("Age: {0}, Income: {0}, Political bent: ", row[0], row[1]);
                int c = perceptron.ComputeOutput(row);
                if (c > 0)
                    Console.Write("+1 i.e. Conservative\n");
                else
                    Console.Write("-1 i.e. Liberal\n");
            }
        }

        private static double[][] SetupPredictionInput()
        {
            double[][] data = new double[6][];
            data[0] = new double[] { 3.0, 4.0 };
            data[1] = new double[] { 0.0, 2.0 };
            data[2] = new double[] { 2.0, 5.0 };
            data[3] = new double[] { 5.0, 6.0 };
            data[4] = new double[] { 9.0, 9.0 };
            data[5] = new double[] { 4.0, 6.0 };
            return data;
        }

        private static void showData(double[] row)
        {
            foreach (double item in row)
            {
                Console.Write(" {0} ", item.ToString().PadLeft(6));
            }
        }

        private static void showData(double[][] trainingData)
        {
            foreach (double[] row in trainingData)
            {
                showData(row);
                Console.WriteLine();
            }
        }

        private static double[][] SetupTrainingData()
        {
            double[][] trainingData = new double[8][];
            trainingData[0] = new double[] { 1.5, 2.0, -1.0 };
            trainingData[1] = new double[] { 2.0, 3.5, -1.0 };
            trainingData[2] = new double[] { 3.0, 5.0, -1.0 };
            trainingData[3] = new double[] { 3.5, 2.5, -1.0 };
            trainingData[4] = new double[] { 4.5, 5.0, 1.0 };
            trainingData[5] = new double[] { 5.0, 7.0, 1.0 };
            trainingData[6] = new double[] { 5.5, 8.0, 1.0 };
            trainingData[7] = new double[] { 6.0, 6.0, 1.0 };
            return trainingData;
        }
    }

    public class UIElements
    {
        public static string Banner(char ch, int count, string message)
        {
            return Separator(ch, count) + message + Separator(ch, count);
        }

        public static string Separator(char toPrint, int count)
        {
            string separators = "\n";
            for (int i = 1; i <= count; i++)
                separators += toPrint;
            separators += "\n";
            return separators;
        }
    }
}