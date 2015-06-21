using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Perceptrons;

namespace CodeTests
{
    [TestClass]
    public class TestUIElements
    {
        static char givenCharacter = '-';
        static int giveCharacterCount = 26;
        static string separator = UIElements.Separator(givenCharacter, giveCharacterCount);
        
        [TestMethod]
        public void TestSeparatorForLength()
        {
            Assert.AreEqual(separator.Length, 1 + giveCharacterCount + 1);
        }

        [TestMethod]
        public void TestThatSeparatorContainsNewLines()
        {
            Assert.AreEqual(separator.Contains("\n"), true);
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
            Assert.AreEqual(countNewLines, 2);
        }

        [TestMethod]
        public void TestThatSeparatorContainsGivenCharacterGivenCountTimes()
        {
            int countGivenCharacter = 0;
            for (int i = 0; i < separator.Length; i++)
            {
                if (separator[i] == givenCharacter)
                    countGivenCharacter++;
            }
            Assert.AreEqual(countGivenCharacter, giveCharacterCount);
            
        }
    }
}
