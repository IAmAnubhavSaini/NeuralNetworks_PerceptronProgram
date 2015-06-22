using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Perceptrons;

namespace CodeTests
{
    [TestClass]
    public class TestPerceptronClass
    {
        [TestMethod]
        public void PerceptronObjectIsCreatedSuccessfully()
        {
            Perceptron perceptron = new Perceptron(4);
            Assert.IsNotNull(perceptron);
            Assert.IsInstanceOfType(perceptron, typeof(Perceptron));
        }

        [TestMethod]
        public void TestThatComputeOutputReturnsAnIntegerOnValidInputs()
        {
            Perceptron perceptron = new Perceptron(4);
            double[] xVals = new double[4];
            Assert.IsInstanceOfType(perceptron.ComputeOutput(xVals), typeof(int));
            Assert.AreEqual(-1, perceptron.ComputeOutput(xVals));
        }

        [TestMethod]
        public void ComputOutputReturnsNegativeOne()
        {
            Perceptron perceptron = new Perceptron(4);
            double[] xVals = new double[4] { -0.1, -0.1, -0.2, -0.2 };
            Assert.AreEqual(-1, perceptron.ComputeOutput(xVals));
        }

        [TestMethod]
        public void ComputeOutputReturnsPositiveOne()
        {
            Perceptron perceptron = new Perceptron(4);
            double[] xVals = new double[4]{1.0, 2.1, 3.2, 4.2};
            Assert.AreEqual(1, perceptron.ComputeOutput(xVals));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Bad xValues data provided.")]
        public void ExceptionThrownWhenXValuesArgumentDataMismatchesWithPerceptron()
        {
            Perceptron perceptron = new Perceptron(4);
            double[] xVals = new double[2];
            perceptron.ComputeOutput(xVals);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "xValues cannot be null.")]
        public void ExceptionThrownWhenXValuesAreNull()
        {
            Perceptron perceptron = new Perceptron(4);
            perceptron.ComputeOutput(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Training data cannot be null.")]
        public void ExceptionThrownWhenTrainingDataIsNull()
        {
            Perceptron perceptron = new Perceptron(4);
            perceptron.Train(null, 0.0, 0);
        }

    }
}
