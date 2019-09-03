using System;
using System.Collections.Generic;

namespace Algorithms.LevenshteinDistance
{
    public static class StringDistance
    {
        static int substitutionCost = 1, insertionCost = 1, deletionCost = 1;

        /// <summary>
        /// Wildcard pattern can be used including characters '?' or '*'
        /// '?' - matches any single character
        /// '*' - matches any sequence of characters(including the empty sequence)
        /// Using the wildcard patterns will not add costs to the distance
        /// </summary>
        public static DistanceResult Distance(string word, string correctedWord)
        {
            int w_length = word.Length;
            int cw_length = correctedWord.Length;

            var lookup = new KeyValuePair<int, MistakeType>[w_length + 1, cw_length + 1];
            var result = new List<Mistake>(Math.Max(w_length, cw_length));

            if (w_length == 0)
            {
                for (int i = 0; i < cw_length; i++)
                    result.Add(new Mistake(i, MistakeType.Insertion));
                return new DistanceResult(result);
            }

            for (int i = 0; i <= w_length; i++)
                lookup[i, 0] = new KeyValuePair<int, MistakeType>(i, MistakeType.None);

            for (int j = 0; j <= cw_length; j++)
                lookup[0, j] = new KeyValuePair<int, MistakeType>(j, MistakeType.None);

            for (int i = 1; i <= w_length; i++)
            {
                for (int j = 1; j <= cw_length; j++)
                {
                    char currentWordChar = word[i - 1];
                    char currentCorrectedWordChar = correctedWord[j - 1];

                    // Current characters are considered as  matching in two cases 
                    // (a) characters actually match 
                    // (b) current character of word is '?' 
                    // (c) current character of word is '*' 

                    bool equal = (currentWordChar == currentCorrectedWordChar) ||
                                    currentWordChar == WildcardChars.MatchAny ||
                                    currentWordChar == WildcardChars.MatchSingle;

                    int delCost = lookup[i - 1, j].Key + deletionCost;
                    int insCost = lookup[i, j - 1].Key + insertionCost;
                    int subCost = lookup[i - 1, j - 1].Key;

                    if (!equal)
                        subCost += substitutionCost;

                    int min = delCost;
                    MistakeType mistakeType = MistakeType.Deletion;
                    if (insCost < min)
                    {
                        min = insCost;
                        mistakeType = MistakeType.Insertion;
                    }
                    if (subCost < min)
                    {
                        min = subCost;
                        mistakeType = equal ? MistakeType.None : MistakeType.Substitution;
                    }

                    lookup[i, j] = new KeyValuePair<int, MistakeType>(min, mistakeType);
                }
            }

            int w_ind = w_length;
            int cw_ind = cw_length;
            while (w_ind >= 0 && cw_ind >= 0)
            {
                switch (lookup[w_ind, cw_ind].Value)
                {
                    case MistakeType.None:
                        w_ind--;
                        cw_ind--;
                        break;
                    case MistakeType.Substitution:
                        result.Add(new Mistake(cw_ind - 1, MistakeType.Substitution, word[w_ind - 1], correctedWord[cw_ind - 1]));
                        w_ind--;
                        cw_ind--;
                        break;
                    case MistakeType.Deletion:
                        result.Add(new Mistake(cw_ind, MistakeType.Deletion, correctedCharacter: word[w_ind - 1]));
                        w_ind--;
                        break;
                    case MistakeType.Insertion:
                        result.Add(new Mistake(cw_ind - 1, MistakeType.Insertion, correctedCharacter: correctedWord[cw_ind - 1]));
                        cw_ind--;
                        break;
                }
            }
            if (lookup[w_length, cw_length].Key > result.Count)
            {
                int delMistakesCount = lookup[w_length, cw_length].Key - result.Count;
                for (int i = 0; i < delMistakesCount; i++)
                    result.Add(new Mistake(0, MistakeType.Deletion));
            }
            result.Reverse();
            return new DistanceResult(result);
        }
    }


}
