using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAnalysis {
    class SemanticNetwork {
        Node root;
        Dictionary<string, Node> knownElements = new Dictionary<string, Node>();
        public void AddWord(string s, string prox1, string prox2 = null, string prox3 = null) {
            if (!knownElements.ContainsKey(s)) {
                knownElements[s] = new Node();
            }
            knownElements[s].Connect(prox1, 2.5);
            knownElements[s].Connect(prox2, 1.2);
            knownElements[s].Connect(prox3, 1.1);

        }

        public string GetNextWord(string inputWord) {
            Node start = knownElements[inputWord];
            return start.GetNextWord();
        }
        
    }
    class Node {
        Dictionary<string, double> connectionStrengths;
        internal void Connect(string prox, double p) {
            if (connectionStrengths.ContainsKey(prox)) {
                connectionStrengths[prox] *= p;
            }
            else {
                connectionStrengths[prox] = 1;
            }
            strengthsSortedAndSummed = false;
        }

        bool strengthsSortedAndSummed = false;
        double connectionStrengthSum = 0;

        public string GetNextWord() {
            var d = Util.rand.NextDouble();
            if (!strengthsSortedAndSummed) {
                connectionStrengths.OrderByDescending(i => i.Value);
                connectionStrengthSum = connectionStrengths.Sum(i => i.Value);
                strengthsSortedAndSummed = true;
            }
            foreach (var c in connectionStrengths) {
                double prob = c.Value / connectionStrengthSum;
                if (d < prob) {
                    return c.Key;
                }
                else {
                    d -= prob;
                }
            }
            throw new Exception();
        }
    }
}
