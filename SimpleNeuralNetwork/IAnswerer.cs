using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork
{
    interface IAnswerer
    {
        double Answer(double[] questions);
        string GetName();
    }
}
