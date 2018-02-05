using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork
{
    class Perceptron : IAnswerer
    {
        private static readonly Random R = new Random();
        private static int cnt = 0;
        private readonly string name;
        private readonly double[] weights;

        public Perceptron()
        {
            name = "Perceptron " + cnt++;
            weights = new double[3];
            GenerateWeigthValues();
        }

        public Perceptron(int size)
        {
            name = "Perceptron " + cnt++;
            weights = new double[size + 1];
            GenerateWeigthValues();
        }

        private void GenerateWeigthValues()
        {
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = R.NextDouble() * 2 - 1;
            }
        }

        public void Train(double[] x, double expectedAnswer, double learnRate)
        {
            double adjustedError = (expectedAnswer - Answer(x)) *
            learnRate;
            for (int i = 0; i < weights.Length - 1; i++)
            {
                weights[i] += adjustedError * x[i];
            }
            weights[weights.Length - 1] += adjustedError;
        }

        public double Answer(double[] x)
        {
            double sum = 0;
            for (int i = 0; i < weights.Length - 1; i++)
            {
                sum += x[i] * weights[i];
            }
            sum += weights[weights.Length - 1];
            return Activate(sum);
        }

        public String GetName()
        {
            return name;
        }

        private double Activate(double sum)
        {
            return (sum > 0) ? 1 : -1;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(name + ": ");
            foreach(double d in weights)
            {
                sb.Append(d).Append(" ");
            }
            return sb.ToString();
        }
    }
}
