using System;

namespace Perceptrons
{
    public class Perceptron
    {
        int NumInput;
        double[] Inputs;
        double[] Weights;
        double Bias;
        Random RandomNumberGenerator;

        public Perceptron(int numInput)
        {
            Assign(numInput);
            Initialize();
        }

        private void Assign(int numInput)
        {
            NumInput = numInput;
            Inputs = new double[NumInput];
            Weights = new double[NumInput];
        }

        private void Initialize()
        {
            InitializeRandomNumberGenerator();
            InitializeWeights();
            InitializeBias();
        }

        private void InitializeRandomNumberGenerator()
        {
            RandomNumberGenerator = new Random(0);
        }
        public int ComputeOutput(double[] input)
        {
            SanityCheckForComputeOutput(input);
            Array.Copy(input, Inputs, input.Length);
            double sum = ComputeSum();
            sum += Bias;
            return Activation(sum);
        }

        private double ComputeSum()
        {
            double sum = 0.0;
            for (int i = 0; i < NumInput; i++)
            {
                sum += Inputs[i] * Weights[i];
            }
            return sum;
        }

        private void SanityCheckForComputeOutput(double[] xValues)
        {
            if (xValues == null)
                throw new ArgumentNullException("xValues cannot be null.");
            if (xValues.Length != NumInput)
                throw new ArgumentException("Bad xValues data provided.");
        }

        public double[] Train(double[][] trainingData, double alpha, int maxEpochs)
        {
            SanityCheckForTrain(trainingData);
            double[] xValues = new double[NumInput];
            int[] sequence = InitializeSequence(trainingData);
            for (int epoch = 0; epoch < maxEpochs; epoch++)
            {
                TrainOnCurrentEpoch(trainingData, alpha, xValues, sequence);
            }
            return SetupResult();
        }

        private void TrainOnCurrentEpoch(double[][] trainingData, double alpha, double[] xValues, int[] sequence)
        {
            Shuffle(sequence);
            for (int i = 0; i < trainingData.Length; i++)
            {
                TrainOnCurrentSequence(trainingData, alpha, xValues, sequence, i);
            }
        }

        private static int[] InitializeSequence(double[][] trainingData)
        {
            int[] sequence = new int[trainingData.Length];
            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = i;
            }
            return sequence;
        }

        private void TrainOnCurrentSequence(double[][] trainingData, double alpha, double[] xValues, int[] sequence, int i)
        {
            int current = sequence[i];
            Array.Copy(trainingData[current], xValues, NumInput);
            int desired = int.Parse(trainingData[current][NumInput].ToString());
            int computed = ComputeOutput(xValues);
            int delta = computed - desired;
            if (delta != 0)
            {
                Update(delta, alpha);
            }
        }

        private double[] SetupResult()
        {
            double[] result = new double[NumInput + 1];
            Array.Copy(Weights, result, NumInput);
            result[result.Length - 1] = Bias;
            return result;
        }

        private static void SanityCheckForTrain(double[][] trainingData)
        {
            if (trainingData == null)
            {
                throw new ArgumentNullException("trainingData", "Training data cannot be null.");
            }
        }
        void Shuffle(int[] sequence)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                int r = RandomNumberGenerator.Next(i, sequence.Length);
                int tmp = sequence[r];
                sequence[r] = sequence[i];
                sequence[i] = tmp;
            }
        }
        void Update(int delta, double alpha)
        {
            for (int i = 0; i < Weights.Length; i++)
            {
                UpdateCurrentWeight(delta, alpha, i);
            }
            UpdateBias(delta, alpha);
        }

        private void UpdateBias(int delta, double alpha)
        {
            if (delta > 0)
                delta *= -1;

            Bias += (alpha * delta);
        }

        private void UpdateCurrentWeight(int delta, double alpha, int i)
        {
            double currentInput = Inputs[i] >= 0.0 ? Inputs[i]*-1 : Inputs[i];
            Weights[i] = Weights[i] + (alpha * delta * currentInput);
        }
        void InitializeWeights(double low = -0.01, double high = 0.01)
        {
            for (int i = 0; i < Weights.Length; i++)
            {
                Weights[i] = (high - low) * RandomNumberGenerator.NextDouble() + low;
            }
        }
        void InitializeBias(double low = -0.01, double high = 0.01)
        {
            Bias = (high - low) * RandomNumberGenerator.NextDouble() + low;
        }
        static int Activation(double v)
        {
            return v > 0.0 ? 1 : -1;
        }
    }
}
