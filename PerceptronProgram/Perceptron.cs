using System;
namespace Perceptrons
{
    public class Perceptron
    {
        int numInput;
        double[] inputs;
        double[] weights;
        double bias;
        int output;
        Random rnd;

        public Perceptron(int numInput) { throw new NotImplementedException; }
        public int ComputeOutput(double[] xValues) { throw new NotImplementedException; }
        public double[] Train(double[][] trainingData, double alpha, int maxEpochs) { throw new NotImplementedException; }
        void Shuffle(int[] sequence) { throw new NotImplementedException; }
        void Update(int computed, int desired, double alpha) { throw new NotImplementedException; }
        void InitializeWeights() { throw new NotImplementedException; }
        static int Activation(double v) { throw new NotImplementedException; }
    }
}
