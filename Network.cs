using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NN
{
    public class Network
    {
        private List<Layer> layers = new List<Layer>();

        public void Setup(NetFileData data)
        {
            Neuron.Temperature = data.Temperature;
            Neuron.Threshold = data.Threshold;

            for (int i = 0; i < data.LayerCount; i++)
            {
                layers.Add(new Layer(i, data));
            }

            SetWeights(data);
        }

        public void ApplyVector(byte [] vector)
        {
            for(int nindex = 0; nindex < layers[0].Neurons.Count; nindex++)
            {
                double value;
                byte mask;

                if (!(layers[0].Neurons[nindex] is BiasNode))
                {
                    for (int i = 0; i < vector.Length; i++)
                    {
                        mask = 0x80;
                        for (int j = 0; j < 8; j++) // cycle through bit positions
                        {
                            if ((vector[nindex] & mask) != 0)
                            {
                                value = 1.0;
                            }
                            else
                            {
                                value = 0.0;
                            }

                            layers[0].Neurons[nindex].Output = value;
                            nindex++;
                        }
                    }

                }
            }
        }

        public double GetOutputValue(int index)
        {
            return layers[layers.Count - 1].Neurons[index].Output;
        }

        public void RunNetwork()
        {
            for (int i = 1; i < layers.Count; i++)
            {
                layers[i].Calculate();
            }
        }
        private void SetWeights(NetFileData data)
        {
            for (int i = 0; i < layers.Count - 1; i++)
            {
                layers[i + 1].SetWeights(layers[i].Neurons, data);
            }
        }

        public bool Alive
        {
            get;
            private set;
        }

        

    }
}
