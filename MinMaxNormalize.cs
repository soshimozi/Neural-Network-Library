using System;

namespace NN
{
    public class MinMaxNormalize : INormalize
    {
        public void Normalize(double[][] data, int column)
        {
            var j = column;
            var min = data[0][j];
            var max = data[0][j];

            foreach (var t in data)
            {
                if (t[j] < min)
                    min = t[j];
                if (t[j] > max)
                    max = t[j];
            }

            var range = max - min;
            if (Math.Abs(range) < 0.00000001)
            {
                foreach (var t in data)
                    t[j] = 0.5;
                return;
            }

            foreach (var t in data)
                t[j] = (t[j] - min)/range;
        }
    }
}