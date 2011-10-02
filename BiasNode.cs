using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NN
{
    public class BiasNode : Neuron
    {
        public override void Calculate()
        {
            Output = 1.0;
        }
    }
}
