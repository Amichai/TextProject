using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TextAnalysis {
    class Program {
        static void Main(string[] args) {
            string filename = "DonQuixote1.txt";
            FrequencyTable frequencies = new FrequencyTable();
            string lastWord = "";
            foreach(var b in Util.TextWalker(filename)){
                frequencies.Add(b);
                frequencies.AddSuccession(lastWord, b);
                lastWord = b;
            }

            new RandomWordPoetry(frequencies.successionFrequencies);
            //new FrequencyChart(successionFrequencies);


        }
    }
}
