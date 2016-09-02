﻿using System;

public static class Patternmatching
{
  public static void KMPAlgorithm()
  {
    //Knuth Morris Pratt pattern searching algorithm.
    //Step 1 Generate the LPS array  (LPS indicates longest proper prefix which is also a suffix)
    //Step 2 Use the LPS table to perform the pattern matching 
    var inputData = KMPInputData();
    var pattern = inputData.Item1;
    var actualString = inputData.Item2;

    //Compute LPS array
    int[] lps = new int[pattern.Length];
    ComputeLPSArray(pattern, pattern.Length, lps);

    int j = 0;
    int i = 0;
    while (i< actualString.Length)
    {
      if(pattern[j] == actualString[i])
      {
        j++;
        i++;
      }
      if (j==pattern.Length)
      {
        //found pattern
        Console.WriteLine("Found pattern at:" + (i - j));
        j = lps[j - 1];
      }
      else if(i<actualString.Length && pattern[j] != actualString[i])
      {
        if(j!=0)
        {
          j = lps[j - 1];
        }
        else
        {
          i = i + 1;
        }
      }
    }
  }

  private static Tuple<string,string> KMPInputData()
  {
    var indexxx = "012345678";
    var pattern = "ABABCABAB";
    pattern = "ABAB";
    var actualString = "ABABDABACDABABCABAB";
    return Tuple.Create(pattern, actualString);
  }
  private static void ComputeLPSArray(string pattern, int lengthOfPattern, int[] lps)
  {
    var length = 0;
    lps[0] = 0;
    int i = 1;
    while(i < lengthOfPattern)
    {
      if(pattern[i] == pattern[length])
      {
        length++;
        lps[length] = length;
        i++;
      }
      else
      {

        if(length !=0)
        {
          length = lps[length - 1];
        }
        else
        {
          lps[i] = length;
          i++;
        }
      }
    }
  }
}

