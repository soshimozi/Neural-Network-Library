using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NN
{
    public class Neuron
    {
        public static double Threshold;
        public static double Temperature;

        public Func<double, double> ActivationFunction
        {
            get;
            set;
        }

        public int Id
        {
            get;
            private set;
        }

        public double Output
        {
            get;
            set;
        }

        public List<Link> Links
        {
            get;
            set;
        }

        public void AddLink(double value, Neuron source)
        {
            Links.Add(new Link(value, source));
        }
    
        public Neuron()
            : this(0)
        {
        }

        public Neuron(int id)
        {
            this.Id = id;

            ActivationFunction = new Func<double, double>((x) => 1 / (1 + Math.Exp(-(x + Threshold) / Temperature)));
        }

        public virtual void Calculate()
        {
            double net = 0.0;

            foreach (Link link in Links)
            {
                Neuron source = link.SourceNeuron;
                double previousOut = source.Output;

                net += link.Value * previousOut;
            }

            if (ActivationFunction != null)
            {
                Output = ActivationFunction(net);
            }
        }
    }
}
