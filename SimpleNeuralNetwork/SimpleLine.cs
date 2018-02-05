using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork
{
    class SimpleLine : IAnswerer
    {
        private double a, b;
        private String name;
        public SimpleLine(double a, double b, String name)
        {
            this.a = a;
            this.b = b;
            this.name = name;
        }
        public double Answer(double[] x)
        {
            return ComputeLine(a, x[0], b, x[1]);
        }
        public string GetName()
        {
            return name;
        }
        private double ComputeLine(double a, double x, double b, double y)
        {
            double result = a * x + b;
            return (y > result) ? 1 : -1;
        }
    }
}
