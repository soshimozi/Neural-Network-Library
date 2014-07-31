using System.Globalization;

namespace NN
{
    public class DummyEncoding : IEncoding
    {
        private static IEncoding _instance;

        public static IEncoding Instance
        {
            get { return _instance ?? (_instance = new DummyEncoding()); }
        }

        public string EncodeData(int index, int count)
        {
            var values = new int[count];
            values[index] = 1;
            var s = values[0].ToString(CultureInfo.InvariantCulture);
            for (var i = 1; i < values.Length; ++i)
                s += "," + values[i];
            return s;
        }
    }
}