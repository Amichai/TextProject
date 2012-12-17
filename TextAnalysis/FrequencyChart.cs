using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TextAnalysis {
    class FrequencyChart {
        public FrequencyChart(Dictionary<string, int> frequencies) {
            var l = frequencies.OrderByDescending(i => i.Value);

            var writer = new StreamWriter("Output.csv");
            for (int i = 0; i < 2000; i++) {
                var el = l.ElementAt(i);
                writer.WriteLine(string.Format("{0},{1},{2},{3}", el.Key, i, el.Value, Math.Log(el.Value)));
                Console.WriteLine(el.Key.ToString() + " " + el.Value.ToString());
            }

            writer.Flush();
            writer.Close();
        }
    }
}
