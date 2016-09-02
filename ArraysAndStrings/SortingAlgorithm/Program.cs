using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            MergeSort();
            BubbleSort();
            InsertionSort();
            SelectionSort();
        }

        /// <summary>
        //Overview of Selection sort
        //1. Find the minimum value in an array
        //2. swap the minimum value with the value in the first position
        /// </summary>
        public static void SelectionSort()
        {
            int[] inputArray = {9, 6, 12, 5, 1, 8, 4};
            Console.WriteLine("*****Selection Sort******");
            Console.WriteLine("Input element is:" + string.Join(",", inputArray));
            //Overview of Selection sort
            //1. Find the minimum value in an array
            //2. swap the minimum value with the value in the first position
            for (var i = 0; i < inputArray.Length; i++)
            {
                //1. Find the minimum value in an array
                int minItem = i;
                for (int j = i+1; j < inputArray.Length; j++)
                {
                    if (inputArray[j] < inputArray[minItem])
                    {
                        minItem = j;
                    }
                }
                //2. swap the minimum value with the value in the first position
                var tempHolder = inputArray[i];
                inputArray[i] = inputArray[minItem];
                inputArray[minItem] = tempHolder;
            }

            Console.WriteLine("Output after sorting:"+ string.Join(",",inputArray));
        }

        /// <summary>
        /// Overview of Insertion Sort
        /// Pick the second element and compare the to the left. If small then swap the position. 
        /// pick the next elelemt and compare with all the elelments before that. if found anything smaller then swap position.
        /// </summary>
        public static void InsertionSort()
        {
            int[] inputArray = { 6, 9, 3, 5, 1, 8, 4 };
            Console.WriteLine("*****Insertion Sort******");
            Console.WriteLine("Input element is:" + string.Join(",", inputArray));
            for (int i = 1; i < inputArray.Length; i++)
            {
                //Compare the current element with all the element before that 
                //if small swap position
                var j = i-1;
                int tempHolder = inputArray[i];
                while (j >= 0 && (tempHolder < inputArray[j]))
                {
                    inputArray[j+1] = inputArray[j];
                    j--;
                }
                inputArray[j+1] = tempHolder;

            }

            Console.WriteLine("Output after sorting:" + string.Join(",", inputArray));
        }

        /// <summary>
        /// Overview of Bubbble Sort
        /// Sorting takes place by stepping through all the data items one-by-one in pairs and comparing adjacent data items and swapping each pair that is out of order.
        /// </summary>
        public static void BubbleSort()
        {
            int[] inputArray = { 9, 6, 12, 5, 1, 8, 4 };
            //int[] inputArray = { 5, 1, 6, 2, 4, 3 };
            Console.WriteLine("*****Bubble Sort******");
            Console.WriteLine("Input element is:" + string.Join(",", inputArray));            
            for (int i = 1; i < inputArray.Length; i++)
            {
                bool isSorted = false;
                for (int j = 0; j < inputArray.Length-1; j++)
                {
                    if (inputArray[j] > inputArray[j+1])
                    {
                        var tempHolder = inputArray[j];
                        inputArray[j] = inputArray[j+1];
                        inputArray[j+1] = tempHolder;
                        isSorted = true;
                    }                    
                }

                if (! isSorted)
                {
                    break;
                }
            }
            Console.WriteLine("Output after sorting:" + string.Join(",", inputArray));
        }

        public static void MergeSort()
        {
            int[] inputArray = { 9, 6, 12, 5, 1, 8, 4 };
            //int[] inputArray = { 5, 1, 6, 2, 4, 3 };
            Console.WriteLine("*****Merge Sort******");
            Console.WriteLine("Input element is:" + string.Join(",", inputArray));  
            MergeSortAlgo(inputArray);
            Console.WriteLine("Output element is:" + string.Join(",", inputArray));  
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="startingIndex"></param>
        /// <param name="lastIndex"></param>
        public static void MergeSortAlgo(int[] a)
        {
          //1. Get the length of the input array
          int n = a.Length;
          if(n < 2)
          {
            return;
          }
          //2 get the mid of the input array
          int mid = n / 2;
          //3 Create a left array of size equvalent to mid
          int[] left = new int[mid];
          //4. create the right array of size equalient to second half
          int[] right = new int[n - mid];
          //5. Populate the left and the right array.
          for (int i = 0; i < mid; i++)
          {
            left[i] = a[i]; 
          }
          for (int i = mid; i < n-1; i++)
          {
            right[i - mid] = a[i];
          }

          MergeSortAlgo(left);
          MergeSortAlgo(right);
          Merge(left, right, a);

        }

        public static void Merge(int[]left,int[]right,int[]a)
        {
          //Declare 3 variables to track the index of Left,right and A arrays respectively
          int i=0, j=0, k = 0;

          //Get number of elements in left and right array
          int nl = left.Length;
          int nr = right.Length;

          while(i < nl && j< nr)
          {
            if(left[i]<=right[j])
            {
              a[k] = left[i];
              i++;
            }
            else
            {
              a[k] = right[j];
              j++;
            }
            k++;
          }

          while(i<nl)
          {
              a[k] = left[i];
              k++;
              i++;
          }
          while (j<nl)
          {
              a[k] = right[j];
              j++;
              k++;
          }

        }
    }
}
