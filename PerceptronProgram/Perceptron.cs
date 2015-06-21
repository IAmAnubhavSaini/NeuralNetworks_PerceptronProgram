using System;
namespace Perceptrons
{
    public class Perceptron
    {
        int NumInput;
        double[] Inputs;
        double[] Weights;
        double Bias;
        int Output;
        Random rnd;

        public Perceptron(int numInput) {
            NumInput = numInput;
            Inputs = new double[NumInput];
            Weights = new double[NumInput];
            rnd = new Random(0);
            InitializeWeights();
        }
        public int ComputeOutput(double[] xValues) { throw new NotImplementedException(); }
        public double[] Train(double[][] trainingData, double alpha, int maxEpochs) { throw new NotImplementedException(); }
        void Shuffle(int[] sequence) { throw new NotImplementedException(); }
        void Update(int computed, int desired, double alpha) { throw new NotImplementedException(); }
        void InitializeWeights() {
            double low = -0.01;
            double high = 0.01;
            for (int i = 0; i < Weights.Length; i++)
            {
                Weights[i] = (high - low) * rnd.NextDouble() + low;
            }
            Bias = (high - low) * rnd.NextDouble() + low;
        }
        static int Activation(double v) { throw new NotImplementedException(); }
    }
}
