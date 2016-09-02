using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    class Numbers
    {
        private static Dictionary<string, long> numberTable = new Dictionary<string, long>
        {{"zero",0},{"one",1},{"two",2},{"three",3},{"four",4},
        {"five",5},{"six",6},{"seven",7},{"eight",8},{"nine",9},
        {"ten",10},{"eleven",11},{"twelve",12},{"thirteen",13},
        {"fourteen",14},{"fifteen",15},{"sixteen",16},
        {"seventeen",17},{"eighteen",18},{"nineteen",19},{"twenty",20},
        {"thirty",30},{"forty",40},{"fifty",50},{"sixty",60},
        {"seventy",70},{"eighty",80},{"ninety",90},{"hundred",100},
        {"thousand",1000},{"million",1000000},{"billion",1000000000},
        {"trillion",1000000000000},{"quadrillion",1000000000000000},
        {"quintillion",1000000000000000000}};
        /// <summary>
        /// In an arry find the pair of elemets which is equal to the provided integer
        /// </summary>
        /// <param name="arrayNumbers"></param>
        /// <param name="sum"></param>
        public static void FindSumOfNumberInArray(int[] arrayNumbers, int sum)
        {
            var arraySize = arrayNumbers.Length;
            var hashtable = new Hashtable();

            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                var temp = sum - arrayNumbers[i];
                if (temp >= 0 && Convert.ToInt16(hashtable[temp]) == 1)
                {
                    Console.WriteLine("Pair with given sum  " + sum.ToString() + "is (" + arrayNumbers[i].ToString() +
                                      "," + temp.ToString() + ")");
                }
                hashtable[arrayNumbers[i]] = 1;
            }
        }

        public static int AdditionOfNumbersWithoutUsingPlusOperator(int firstNumber, int secondNumber)
        {
            return firstNumber - (-secondNumber);
        }

        public static int AdditionOfNumbersWithoutArithmeticOperator(int firstNumber, int secondNumber)
        {
            var xorsum = firstNumber ^ secondNumber;
            var carry = (firstNumber & secondNumber) << 1;
            
            if (secondNumber == 0)
            {
                return firstNumber;
            }
            
            var result =  AdditionOfNumbersWithoutArithmeticOperator(xorsum, carry);
            return result;
        }

        /// <summary>
        /// Convert string to number for example string  "One Thousand and Five" should be converted to 1005
        /// </summary>
        /// <param name="numberString"></param>
        /// <returns></returns>
        public static long ToLong(string numberString)
        {
            var numbers = Regex.Matches(numberString, @"\w+").Cast<Match>()
                 .Select(m => m.Value.ToLowerInvariant())
                 .Where(v => numberTable.ContainsKey(v))
                 .Select(v => numberTable[v]);
            long acc = 0, total = 0L;
            foreach (var n in numbers)
            {
                if (n >= 1000)
                {
                    total += (acc * n);
                    acc = 0;
                }
                else if (n >= 100)
                {
                    acc *= n;
                }
                else acc += n;
            }
            return (total + acc) * (numberString.StartsWith("minus",
                  StringComparison.InvariantCultureIgnoreCase) ? -1 : 1);
        }

        public static void ConvertToBinary(int decimalNumber)
        {
            int remainder;
            string result = string.Empty;
            while (decimalNumber > 0)
            {
                remainder = decimalNumber % 2;
                decimalNumber /= 2;
                result = remainder.ToString() + result;
            }
            Console.WriteLine("Binary:  {0}", result);
        }

        public static void ArrangeNegativeNumbersToLeft()
        {
            int[] input = {-4, 5, -9, 8, 2,0, -1};

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i+1; j < input.Length; j++)
                {
                    if (input[i] > input[j])
                    {
                        var temp = input[j];
                        input[j] = input[i];
                        input[i] = temp;
                    }
                }
            }
            
        }
        public static void ArrangeNegativeNumbersToLeftWithOutChangingOrder()
        {
            int[] input = { -4, 5, -9, 8, 2, 0, -1 };
            int[] Result = new int[input.Length];

            for (int i = 0,j=0; i < input.Length; i++)
            {
                if (input[i] < 0)
                {
                    Result[j++] = input[i];
                }
            }
            for (int i=input.Length-1,j=input.Length-1;i>0; i--)
            {
                if (input[i] >= 0)
                {
                    Result[j--] = input[i];
                }
            }
        }

        public static void FindNonDuplicateNumbers()
        {
            int[] input = {1, 2, 3, 1, 2, 4, 3, 5,8};
            var tracker = new Hashtable();

            for (int i = 0; i < input.Length; i++)
            {
                if (Convert.ToString(tracker[input[i]]) == "")
                {
                    tracker[input[i]] = "0";   
                }
                else if (tracker[input[i]].ToString() == "0")
                {
                    tracker[input[i]]= "1";
                }
            }
            var temp = (from DictionaryEntry item in tracker
                            where item.Value.Equals("0")
                            select item.Key).ToList();
        }

        public static void FindGreatestSumFromArrayItems()
        {
            int[] input = {1, 2, -4, 5, -3, 4, 2};
            int currentSum = 0;
            int greatestSum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (currentSum<= 0)
                {
                    currentSum = input[i];
                }
                else
                {
                    currentSum = currentSum + input[i];
                }

                if (currentSum > greatestSum)
                {
                    greatestSum = currentSum;
                }
            }

            //Greates sum will have the greates value
        }
    }
}
