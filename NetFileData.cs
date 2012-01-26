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
        private List<List<WeightImage>> weights = new List<List<WeightImage>>();
        private List<int> neurons = new List<int>();

        public double Temperature
        {
            get;
            private set;
        }

        public double Threshold
        {
            get;
            private set;
        }

        public int LayerCount
        {
            get;
            private set;
        }

        public int GetLayerSize(int layer) 
        {
            return neurons[layer];
        }

        public void AddWeights(int layer, int destination, int source, double w)
        {
            var list = weights[layer] == null ? (weights[layer] = new List<WeightImage>()) : weights[layer];
            list.Add(new WeightImage() { DestinationIndex = destination, SourceIndex = source, Data = w });
        }
         
        public double GetWeights(int layer, int destination, int source)
        {
            var query = from wi in weights[layer]
                        where wi.SourceIndex == source && wi.DestinationIndex == destination
                        select wi.Data;

            double? val = query.FirstOrDefault();
            if (val.HasValue)
            {
                return val.Value;
            }
            else
            {
                return 0.0;
            }
        }
    }


}
