using System;
using System.Linq;

namespace NN
{
    public class GausianNormalize : INormalize
    {
        public void Normalize(double[][] data, int column)
        {
            var j = column; // Convenience.
            var sum = data.Sum(t => t[j]);
            var mean = sum/data.Length;

            var sumSquares = data.Sum(t => (t[j] - mean)*(t[j] - mean));
            var stdDev = Math.Sqrt(sumSquares/(data.Length - 1));

            foreach (var t in data)
                t[j] = (t[j] - mean)/stdDev;
        }
    }
}