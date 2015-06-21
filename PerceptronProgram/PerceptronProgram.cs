using System;
namespace Perceptrons
{
    class PerceptronProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine(UIElements.Banner('=', 26, "Begin Perceptron demo."));
            Console.WriteLine(UIElements.Banner('=', 26, "End Perceptron demo."));
            Console.ReadLine();
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