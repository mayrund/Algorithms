using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.LevenshteinDistance
{
    public enum MistakeType
    {
        None = 0,
        Substitution = 1,
        Insertion = 2,
        Deletion = 3
    }
}
