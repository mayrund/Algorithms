using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Tests
{
    public struct TestData
    {
        public TestData(string word, string correctedWord, int distance)
        {
            this.Word = word;
            this.CorrectedWord = correctedWord;
            this.Distance = distance;
        }
        public int Distance { get; set; }
        public string Word { get; set; }
        public string CorrectedWord { get; set; }
    }
}
