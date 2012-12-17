using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TextAnalysis {
    public static class Util {
        public static void AddToFrequencyTable(this Dictionary<string, int> table, string s) {
            if (table.ContainsKey(s)) {
                table[s]++;
            }
            else {
                table[s] = 1;
            }
        }

        public static Random rand = new Random();

        public static IEnumerable<string> TextWalker(string filename) {
            var lines = File.ReadLines(filename);
            var words = lines.SelectMany(i => i.Split(' '));

            foreach (var a in words) {
                var b = new string(a.Where(c => !char.IsPunctuation(c)).ToArray());
                if (string.IsNullOrWhiteSpace(b) || b == "") continue;
                b = b.ToLower();
                yield return b;
            }
        }
    }
}
