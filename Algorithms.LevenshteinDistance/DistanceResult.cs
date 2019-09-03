using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.LevenshteinDistance
{
    public class DistanceResult
    {
        public int Distance { get { return Mistakes.Count; } }
        public List<Mistake> Mistakes { get; private set; }

        public DistanceResult(List<Mistake> mistakes)
        {
            this.Mistakes = mistakes;
        }
    }
}
