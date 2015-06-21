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
    }
}
