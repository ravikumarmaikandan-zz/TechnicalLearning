using System;

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
    ComputeLPSArray(pattern, actualString.Length, lps);
  }

  private static Tuple<string,string> KMPInputData()
  {
    var pattern = "ABABCABAB";
    var actualString = "ABABDABACDABABCABAB";
    return Tuple.Create(pattern, actualString);
  }
  private static void ComputeLPSArray(string pattern, int lengthOfString, int[] lps)
  {
    var length = 0;
    lps[0] = 0;
    int i = 1;
    while(i < lengthOfString)
    {
      if(pattern.ToCharArray[i] == pattern.ToCharArray[length])
      {

      }
    }
  }
}

