using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Perceptrons;

namespace CodeTests
{
    [TestClass]
    public class TestUIElements
    {
        static char givenCharacter = '-';
        static int givenCharacterCount = 26;
        static string separator = UIElements.Separator(givenCharacter, givenCharacterCount);
        
        [TestMethod]
        public void TestSeparatorForLength()
        {
            Assert.AreEqual(1 + givenCharacterCount + 1, separator.Length);
        }

        [TestMethod]
        public void TestThatSeparatorContainsNewLines()
        {
            Assert.AreEqual(true, separator.Contains("\n"));
        }

        [TestMethod]
        public void TestThatSeparatorContainsTwoNewLineCharacters()
        {
            int countNewLines = 0;
            for (int i = 0; i < separator.Length; i++)
            {
                if (separator[i] == '\n')
                    countNewLines++;
            }
            Assert.AreEqual(2, countNewLines);
        }

        [TestMethod]
        public void TestThatSeparatorContainsGivenCharacterGivenCountTimes()
        {
            int expectedCount = 0;
            for (int i = 0; i < separator.Length; i++)
            {
                if (separator[i] == givenCharacter)
                    expectedCount++;
            }
            Assert.AreEqual(givenCharacterCount, expectedCount);
        }
    }
}
