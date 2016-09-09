using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
  public static class Searching
  {
    /// <summary>
    /// We basically ignore half of the elements just after one comparison.
    /// 1) Compare x with the middle element.
    /// 2) If x matches with middle element, we return the mid index.
    /// 3) Else If x is greater than the mid element, then x can only lie in right half of the subarray 
    /// after the mid element.So we recur for right half.
    /// 4) Else(x is smaller) recur for the left half.
    /// Time Complexity is O(logn)
    /// </summary>
    public static void BinarySearchAlgorithm()
    {
      var inputarray = new[] { 1, 4, 6, 8, 9, 10, 23, 34, 43, 56, 69 };
      var searchIndex = InternalBinarySearch(inputarray, 0, inputarray.Length - 1, 23);
      Console.WriteLine("Index of search string 23 is" + searchIndex.ToString());
    }
    private static int InternalBinarySearch(int[] input, int left, int right, int toFind)
    {
      if (right >=1)
      {
        var mid = left + (right - left) / 2;

        if (input[mid] == toFind)
        {
          return mid;
        } 

        if (input[mid] > toFind)
        {
          return InternalBinarySearch(input, left, mid-1, toFind);
        }
        else
        {
          return InternalBinarySearch(input, mid + 1, right, toFind);
        } 
      }
      else
      {
        return -1;
      }
    }
  }
}
