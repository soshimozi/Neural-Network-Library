using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NN
{
    public class Link
    {
        public Neuron SourceNeuron
        {
            get;
            set;
        }

        public double Value
        {
            get; 
            set;
        }

        public Link(double value, Neuron source)
        {
            Value = value;
            SourceNeuron = source;
        }
    
    }
}
