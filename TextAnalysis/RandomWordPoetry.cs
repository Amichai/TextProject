using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TextAnalysis {
    class RandomWordPoetry {
        public RandomWordPoetry(Dictionary<string, Dictionary<string,int>> succession) {
            Random rand = new Random();
            string currentWord = "don";
            Debug.Print(currentWord);


            for (int i = 0; i < 3000; i++) {
                if (currentWord == "") {
                    Debug.Print(".");
                    currentWord = "don";
                    Debug.Print(currentWord);
                }
                var frequency = succession[currentWord];
                var l = frequency.OrderByDescending(j => j.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
                int sum = l.Sum(j => j.Value);
                string w = pickNextWord(l, sum);
                currentWord = w;
                Debug.Print(w);
            }
            Console.ReadKey();
        }
        static Random rand = new Random();
        public RandomWordPoetry(Dictionary<string, int> probabilities, int totalNumberOfElements) {

            var l = probabilities.OrderByDescending(i => i.Value);
            string outputString = string.Empty;
            //while(true){
            for(int i=0; i< 3000; i++){
                string w = pickNextWord(probabilities,totalNumberOfElements);
                Debug.Print(w);
            }
            Console.ReadKey();
        }

        public string pickNextWord(Dictionary<string, int> l, int totalNumberOfElements) {
            if (totalNumberOfElements == 0) return "";
            var startNumber = rand.Next(0, totalNumberOfElements);
            var stepsToTake = startNumber;
            foreach (var p in l) {
                if (stepsToTake < p.Value) {
                    return p.Key;
                }
                else {
                    stepsToTake -= p.Value;
                }
            }
            return "";
        }
    }
}
