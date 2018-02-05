using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputBuilder cp = new OutputBuilder();
            ReferenceFrame rf1 = new ReferenceFrame("Referencja");
            rf1.AddBarrier(new SimpleLine(1, 0, "linia do góry"));
            ReferenceFrame rf2 = new ReferenceFrame("Inna referencja");
            rf2.AddBarrier(new SimpleLine(-0.5, 0.5, "linia lekko do dołu"));
            Perceptron p1 = new Perceptron();
            Perceptron p2 = new Perceptron();
            cp.AddAnswerer(rf1)
                .AddAnswerer(p1)
                .AddAnswerer(rf2)
                .AddAnswerer(p2)
                .Print();
            for (int i = 0; i < 5000; i++)
            {
                double[] d = new double[2];
                d[0] = rf1.GenerateCoordinates();
                d[1] = rf1.GenerateCoordinates();
                double a1 = rf1.Answer(d), a2 = rf2.Answer(d);
                p1.Train(d, a1, 0.01);
                p2.Train(d, a2, 0.01);
                if (i % 250 == 0)
                {
                    cp.Print();
                }
            }
            cp.Print();
            Console.ReadLine();
        }
    }
}
