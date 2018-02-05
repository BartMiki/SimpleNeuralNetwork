using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork
{
    class OutputBuilder
    {
        private readonly List<IAnswerer> answerers = new List<IAnswerer>();

        public OutputBuilder AddAnswerer(IAnswerer answerer)
        {
            answerers.Add(answerer);
            return this;
        }

        public OutputBuilder Print()
        {
            PrintDivisionLine();
            PrintPaddedNames();
            PrintAnswersFields();
            return this;
        }

        private void PrintDivisionLine()
        {
            foreach(var answerer in answerers)
            {
                Console.Write(String.Format("{0,46}", "=").Replace(" ", "=").ToString());
            }
            Console.WriteLine();
        }

        private void PrintAnswersFields()
        {
            for (double y = 1.0; y > -1.1; y -= 0.1)
            {
                foreach (var answerer in answerers)
                {
                    for (double x = -1.0; x < 1.0; x += 0.1)
                    {
                        PrintSingleAnswer(answerer, x, y);
                    }
                    Console.Write("   ");
                }
                Console.WriteLine();
            }
        }

        private void PrintSingleAnswer(IAnswerer answerer, double x, double y)
        {
            double[] questions = { x, y };
            if(answerer.Answer(questions) > 0)
            {
                PrintGreen("1 ");
            }
            else
            {
                PrintRed("0 ");
            }
        }

        private void PrintPaddedNames()
        {
            foreach (var answerer in answerers)
            {
                Console.Write(String.Format("{0,46}", answerer.GetName()).ToString());
            }
            Console.WriteLine();
        }

        private void PrintGreen(string element)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(element);
            Console.ResetColor();
        }

        private void PrintRed(string element)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(element);
            Console.ResetColor();
        }
    }
}
