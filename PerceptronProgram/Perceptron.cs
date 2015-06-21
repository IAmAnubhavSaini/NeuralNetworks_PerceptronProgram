using System;
using System.Linq;

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

        public Perceptron(int numInput)
        {
            NumInput = numInput;
            Inputs = new double[NumInput];
            Weights = new double[NumInput];
            rnd = new Random(0);
            InitializeWeights();
        }
        public int ComputeOutput(double[] xValues)
        {
            if (xValues == null)
                throw new ArgumentNullException("xValues cannot be null.");
            if (xValues.Length != NumInput)
                throw new ArgumentException("Bad xValues data provided.");

            for (int i = 0; i < xValues.Length; i++)
            {
                Inputs[i] = xValues[i];
            }
            double sum = 0.0;
            for (int i = 0; i < NumInput; i++)
            {
                sum += Inputs[i] * Weights[i];
            }
            sum += Bias;
            int result = Activation(sum);
            Output = result;
            return result;
        }

        public double[] Train(double[][] trainingData, double alpha, int maxEpochs)
        {
            if (trainingData == null)
            {
                throw new ArgumentNullException("trainingData", "Training data cannot be null.");
            }
            double[] xValues = new double[NumInput];
            int desired = 0;
            int[] sequence = new int[trainingData.Length];
            for(int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = i;
            }
            for (int epoch = 0; epoch < maxEpochs; epoch++ )
            {
                Shuffle(sequence);
                for (int i = 0; i < trainingData.Length; i++)
                {
                    int idx = sequence[i];
                    Array.Copy(trainingData[idx], xValues, NumInput);
                    desired = int.Parse(trainingData[idx][NumInput].ToString());
                    int computed = ComputeOutput(xValues);
                    Update(computed, desired, alpha);
                }
            }
            double[] result = new double[NumInput + 1];
            Array.Copy(Weights, result, NumInput);
            result[result.Length - 1] = Bias;
            return result;
        }
        void Shuffle(int[] sequence)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                int r = rnd.Next(i, sequence.Length);
                int tmp = sequence[r];
                sequence[r] = sequence[i];
                sequence[i] = tmp;
            }
        }
        void Update(int computed, int desired, double alpha) {
            if (computed == desired) return;
            int delta = computed - desired;
            for (int i = 0; i < Weights.Length; i++)
            {
                if (computed > desired && Inputs[i] >= 0.0)
                {
                    Weights[i] = Weights[i] - (alpha * delta * Inputs[i]);
                }
                else if (computed > desired && Inputs[i] >= 0.0)
                {
                    Weights[i] = Weights[i] + (alpha * delta * Inputs[i]);
                }
                else if (computed < desired && Inputs[i] >= 0.0)
                {
                    Weights[i] = Weights[i] - (alpha * delta * Inputs[i]);
                }
                else if (computed < desired && Inputs[i] < 0.0)
                {
                    Weights[i] = Weights[i] + (alpha * delta * Inputs[i]);
                }
            }
            if (computed > desired)
            {
                Bias -= (alpha * delta);
            }
            else
            {
                Bias += (alpha * delta);
            }
        }
        void InitializeWeights()
        {
            double low = -0.01;
            double high = 0.01;
            for (int i = 0; i < Weights.Length; i++)
            {
                Weights[i] = (high - low) * rnd.NextDouble() + low;
            }
            Bias = (high - low) * rnd.NextDouble() + low;
        }
        static int Activation(double v)
        {
            if (v > 0.0)
                return +1;
            else
                return -1;
        }
    }
}
