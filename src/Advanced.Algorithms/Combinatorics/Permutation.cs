﻿using System;
using System.Collections.Generic;

namespace Advanced.Algorithms.Combinatorics
{
    /// <summary>
    /// Permutation generator (nPr).
    /// </summary>
    public class Permutation
    {
        public static List<List<T>> Find<T>(List<T> n, int r, bool withRepetition = false)
        {
            var result = new List<List<T>>();

            recurse(n, r, withRepetition, new List<T>(), new HashSet<int>(), result);

            return result;
        }

        private static void recurse<T>(List<T> n, int r, bool withRepetition,
            List<T> prefix, HashSet<int> prefixIndices,
            List<List<T>> result)
        {
            if (prefix.Count == r)
            {
                result.Add(new List<T>(prefix));
                return;
            }

            for (int j = 0; j < n.Count; j++)
            {
                if (prefixIndices.Contains(j) && !withRepetition)
                {
                    continue;
                }

                prefix.Add(n[j]);
                prefixIndices.Add(j);

                recurse(n, r, withRepetition, prefix, prefixIndices, result);

                prefix.RemoveAt(prefix.Count - 1);
                prefixIndices.Remove(j);
            }
        }

    }
}
