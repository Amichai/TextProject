using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAnalysis {
    public class FrequencyTable {
        int totalNumberOfWords = 0;
        public Dictionary<string, int> frequencies = new Dictionary<string, int>();
        public Dictionary<string, Dictionary<string, int>> successionFrequencies = new Dictionary<string, Dictionary<string, int>>();
        public void Add(string s) {
            totalNumberOfWords++;
            frequencies.AddToFrequencyTable(s);
        }

        internal void AddSuccession(string lastWord, string b) {
            if (lastWord == "") return;
            if (!successionFrequencies.ContainsKey(lastWord)) {
                successionFrequencies.Add(lastWord, new Dictionary<string, int>());
            }
            successionFrequencies[lastWord].AddToFrequencyTable(b);
        }
    }
}
