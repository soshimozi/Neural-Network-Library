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

        public int Id
        {
            get;
            private set;
        }

        public virtual void Calculate()
        {
        }
    
    }
}
