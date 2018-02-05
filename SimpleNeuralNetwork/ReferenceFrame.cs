using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork
{
    class ReferenceFrame : IAnswerer
    {
        private static readonly Random R = new Random();
        private readonly List<IAnswerer> answerers = new List<IAnswerer>();
        private string name;

        public void AddBarrier(IAnswerer answerer)
        {
            answerers.Add(answerer);
        }
        public ReferenceFrame(String name)
        {
            this.name = name;
        }

        public double GenerateCoordinates()
        {
            return R.NextDouble() * 2 - 1;
        }

        public double Answer(double[] questions)
        {
            foreach(IAnswerer answerer in answerers)
            {
                if(answerer.Answer(questions) > 0)
                {
                    return 1;
                }
            }
            return -1;
        }

        public string GetName() => name;
    }
}
