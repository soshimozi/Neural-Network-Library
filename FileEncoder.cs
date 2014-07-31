using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NN
{
    public class FileEncoder
    {
        private readonly string _filename;

        public FileEncoder(string filename)
        {
            _filename = filename;
        }

        public List<string> Encode(List<EncodeMessage> encoding)
        {
            string[] tokens;
            var lines = new List<String>();
            var d = new Dictionary<int, Dictionary<string, int>>();
            var result = new List<String>();

            using (var ifs = new FileStream(_filename, FileMode.Open))
            {
                var sr = new StreamReader(ifs);
                string fileLine;
                while ((fileLine = sr.ReadLine()) != null)
                {
                    lines.Add(fileLine);
                }
                sr.Close();
            }

            foreach (var encode in encoding)
            {
                var itemNum = 0;

                d.Add(encode.Column, new Dictionary<string, int>());
                foreach (var line in lines)
                {
                    tokens = line.Split(',');

                    var column = encode.Column;
                    if (d[column].ContainsKey(tokens[column]) == false)
                        d[column].Add(tokens[column], itemNum++);
                }

            }

            var builder = new StringBuilder();
            foreach(var line in lines)
            {
                tokens = line.Split(',');
                
                for (var i = 0; i < tokens.Length; ++i)
                {
                    // see if we have a matching encoder
                    var encoderMatch = encoding.FirstOrDefault(t => t.Column == i);
                    if(encoderMatch != null) // encode this string
                    {
                        var n = d[encoderMatch.Column].Count;

                        var index = d[encoderMatch.Column][tokens[i]]; // 0, 1, 2, or . . .
                        builder.Append(encoderMatch.Encoding.EncodeData(index, n));
                    }
                    else
                        builder.Append(tokens[i]);

                    builder.Append(",");
                }

                builder.Remove(builder.Length - 1, 1); // Remove trailing ','.
                result.Add(builder.ToString());

                builder.Clear();
            }

            return result;
        }
    }
}