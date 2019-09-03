using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.LevenshteinDistance
{
    public struct Mistake
    {
        public char? OriginalCharacter;
        public char? CorrectedCharacter;
        public int Position;
        public MistakeType Type;
        public Mistake(int position, MistakeType type, char? originalCharacter = null, char? correctedCharacter = null)
        {
            Position = position;
            Type = type;
            OriginalCharacter = originalCharacter;
            CorrectedCharacter = correctedCharacter;
        }

        public override string ToString()
        {
            return $"Operation {Type} Position {Position} OriginalCharacter {OriginalCharacter} CorrectedCharacter {CorrectedCharacter}";
        }
    }
}
