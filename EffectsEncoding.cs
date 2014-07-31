using System.Globalization;

namespace NN
{
    public class EffectsEncoding : IEncoding
    {
        private static IEncoding _instance;

        public static IEncoding Instance
        {
            get { return _instance ?? (_instance = new EffectsEncoding()); }
        }
        
        public string EncodeData(int index, int count)
        {
            if (count == 2)
            {
                if (index == 0) return "-1";
                if (index == 1) return "1";
            }

            var values = new int[count - 1];
            if (index == count - 1) // Last item is all -1s. 
            {
                for (var i = 0; i < values.Length; ++i)
                    values[i] = -1;

            }
            else
            {
                values[index] = 1; // 0 values are already there. 
            }

            var s = values[0].ToString(CultureInfo.InvariantCulture);

            for (var i = 1; i < values.Length; ++i) s += "," + values[i];

            return s;
        }
    }
}