using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NN
{
    struct WeightImage
    {
        public double Data;
        public int SourceIndex;
        public int DestinationIndex;
    }

    public class NetFileData
    {
        private List<WeightImage> weights = new List<WeightImage>();
    }
}
