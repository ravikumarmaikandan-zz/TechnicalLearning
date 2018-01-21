using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    static class Anagram
    {
        static int NO_OF_CHARS = 256;
        //Time Complexity: O(n)
        public static void IsAnagram()
        {
            var str1 = "geeksforgeeks";
            var str2 = "forgeeksgeeks";
            var result = areAnagram(str1.ToCharArray(), str2.ToCharArray());
            Console.WriteLine($"String1:{str1} and string2:{str2}. IsAnagram:{result.ToString()}");
        }
        static bool areAnagram(char[] str1, char[] str2)
        {
            // Create 2 count arrays and initialize
            // all values as 0
            int[] count1 = new int[NO_OF_CHARS];
            int[] count2 = new int[NO_OF_CHARS];
            int i;

            // For each character in input strings,
            // increment count in the corresponding
            // count array
            for (i = 0; i < str1.Length && i < str2.Length;i++)
            {
                count1[str1[i]]++;
                count2[str2[i]]++;
            }

            // If both strings are of different length.
            // Removing this condition will make the program 
            // fail for strings like "aaca" and "aca"
            if (str1.Length != str2.Length)
                return false;

            // Compare count arrays
            for (i = 0; i < NO_OF_CHARS; i++)
                if (count1[i] != count2[i])
                    return false;

            return true;
        }

    }
}
