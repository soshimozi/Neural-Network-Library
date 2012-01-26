using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NN
{
    class Layer
    {
        private double temperature = 0.0;
        private double threshold = 0.0;

        private List<Neuron> neurons = new List<Neuron>();

        public List<Neuron> Neurons
        {
            get { return neurons; }
        }

        public Layer(int id, NetFileData data)
        {
            Id = id;

            for (int i = 0; i < data.GetLayerSize(id); i++ )
            {
                neurons.Add(new Neuron(i));
            }

            neurons.Add(new BiasNode());
        }
        public int Id
        {
            get;
            private set;
        }

        public virtual void Calculate()
        {
            foreach (Neuron n in neurons)
            {
                n.Calculate(); 
            }
        }

        public void SetWeights(List<Neuron> previousLayer, NetFileData data)
        {
            for(int i=0; i < neurons.Count; i++)
            {
                if (!(neurons[i] is BiasNode))
                {
                    for (int prev = 0; prev < previousLayer.Count; prev++)
                    {
                        double weight = data.GetWeights(Id, i, prev);
                        neurons[i].AddLink(weight, previousLayer[prev]);
                    }
                }
            }
        }
    
    }
}
