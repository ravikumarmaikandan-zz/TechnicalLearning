using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    internal class Stringmanipulation
    {
        /// <summary>
        /// Using array
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool isUniqueChar(string str)
        {
            if (str.Length > 128)
            {
                return false;
            }
            var char_set = new bool[256];
            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i];

                if (char_set[val])
                {
                    return false;
                }
                char_set[val] = true;
            }
            return true;
        }

        /// <summary>
        /// using bit shifter
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool isUniqueChar2(string str)
        {
            int checker = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i] - 'a';
                if ((checker & (1 << val)) > 0)
                {
                    return false;
                }

                checker |= (i << val);
            }
            return true;
        }

        /// <summary>
        /// Reverse a string
        /// </summary>
        /// <param name="str"></param>
        public static void Reverse(string str)
        {
            StringBuilder temmp = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                temmp.Append(str[i].ToString());
            }

            Console.WriteLine(temmp.ToString());
        }

        /// <summary>
        /// If one string is the permutation of another
        /// </summary>
        /// <returns></returns>
        public static bool IsStringPermutation(string first, string second)
        {
            //If the length of the string is not equal then it's not the permutation of another string
            int sumofFirstString = 0;
            int sumofSecondString = 0;
            if (first.Length != second.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < first.Length; i++)
                {
                    sumofFirstString += first[i];
                    sumofSecondString += second[i];
                }

                return sumofFirstString == sumofSecondString;
            }
        }

        public static bool IsStringPermutationWithOutCaseSensitivity(string first, string second)
        {
            //If the length of the string is not equal then it's not the permutation of another string
            int sumofFirstString = 0;
            int sumofSecondString = 0;
            if (first.Length != second.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < first.Length; i++)
                {
                    int tempFirst = first[i];
                    int tempSecond = second[i];
                    if (first[i] > 96)
                    {
                        tempFirst = first[i] - 32;
                    }
                    if (second[i] > 96)
                        tempSecond = second[i] - 32;
                    sumofFirstString += tempFirst;
                    sumofSecondString += tempSecond;
                }

                return sumofFirstString == sumofSecondString;
            }
        }

        public static bool IsPalindrome(string value)
        {
            int min = 0;
            int max = value.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                char a = value[min];
                char b = value[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                min++;
                max--;
            }
        }

        /// <summary>
        /// Replace the space in the string by %20
        /// This is not an optimal approach
        /// </summary>
        /// <returns></returns>
        public static string ReplaceSpacewithsymbol(string source,int strTruelength)
        {
            var charArray= new char[13];
            int counter = 0;
            var stringArray = source.ToCharArray();

            for (int i = 0; i < stringArray.Length; i++)
            {
                if (i == strTruelength)
                {
                   break;
                }

                if (stringArray[i] == ' ')
                {
                    Array.Resize(ref charArray,charArray.Length +2);
                    charArray[counter] = '%';
                    counter++;
                    charArray[counter] = '2';
                    counter++;
                    charArray[counter] = '0';
                    counter++;
                }
                else
                {
                    charArray[counter] = stringArray[i];
                    counter++;
                }
            }
            var temp =new string(charArray);
            return temp;
        }

        /// <summary>
        /// Replace the space in the string by %20
        /// Optimized
        /// </summary>
        /// <returns></returns>
        public static string ReplaceSpaceWithSymbolOptimized(char[] str, int length)
        {
            int spaceCount=0, newlength;
            for (int i = 0; i < length; i++)
            {
                if (str[i] == ' ')
                {
                    spaceCount++;
                }
            }

            newlength = length + spaceCount*2;
            str[newlength] = '\0';
            for (int i = length-1; i >=0; i--)
            {
                if (str[i] == ' ')
                {
                    str[newlength - 1] = '0';
                    str[newlength - 2] = '2';
                    str[newlength - 3] = '%';
                    newlength = newlength - 3;
                }
                else
                {
                    str[newlength - 1] = str[i];
                    newlength = newlength - 1;
                }
            }

            var temp = str.ToString();
            return temp;
        }

        /// <summary>
        /// Replace the space in the string by %20
        /// </summary>
        /// <returns></returns>
        static void insertHTMLSpaces(ref string myString)
        {
            //The original problem has been modifed for
            //this exercise. It stated that we can assume
            //there is enough space at the end of the
            //string to insert the characters. Instead,
            //we are not assuming there are enough spaces
            //to do the in-place operations. This means we
            //have to create the space first. For every
            //space present in the string, we need to add
            //two more.

            //If extra spaces were given at the beginning or end, remove them.
            myString = myString.Trim();

            //The true length of the string.
            int stringLength = myString.Length;

            if (stringLength < 1) return;

            for (int myIndex = 0; myIndex < stringLength; myIndex++)
            {
                //Add additional spaces for in-place operations.
                if (myString[myIndex] == ' ') myString += "  ";
            }

            //The last character index in the lengthened string.
            int lastCharIndex = myString.Length - 1;

            //The last character from the original string.
            int partitionIndex = stringLength - 1;

            //Convert the string to a char array for in-place swaps.
            char[] myCharArray = myString.ToCharArray();

            while (partitionIndex >= 0)
            {
                if (myString[partitionIndex] != ' ')
                {
                    //Character at partitionIndex is not a space.
                    //Move it to the rear of the string.
                    myCharArray[lastCharIndex] = myCharArray[partitionIndex];
                    lastCharIndex--;
                    partitionIndex--;
                }
                else
                {
                    //Char at partitionIndex is a space. Replace
                    //it as neccessary.
                    myCharArray[lastCharIndex] = '0';
                    myCharArray[--lastCharIndex] = '2';
                    myCharArray[--lastCharIndex] = '%';
                    lastCharIndex--;
                    partitionIndex--;
                }
            }

            //Allocate the transformed string back to the original
            //variable since it was passed by reference.
            myString = new string(myCharArray);

            //O(n) time complexity, in-place swaps in the char array,
            //method ensures there is enough memory to insert extra
            //characters. Return control to caller.
            return;
        }

        /// <summary>
        /// Perform a basic string compression fo example: aabcccccaaa would become a2b1c5a3. 
        /// if the compressed string is not smaller than the original string then return the original string
        /// </summary>
        /// <returns></returns>
        public static string AppedNumberOccueranceWithCharacter(string source)
        {
            var chararray = source.ToCharArray();
            var hashtable = new Hashtable();
            int counter = 0;
            for (int i = counter; i < chararray.Length; i++)
            {                
                if (chararray[counter] == chararray[counter + 1])
                {
                    counter = counter + 2;
                    hashtable[chararray[i]] = counter;
                }
                else
                {
                    hashtable[chararray[counter]] = 1;
                    counter++;
                }
            }

            return string.Empty;
        }

        public static string TestFinally()
        {
            try
            {
                return "From Try";
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Console.WriteLine("From Finally");
            }
        }

        public static bool IsBalancedParentheses()
        {
            string input = "{}";
            int errorAt = -1;
            var tracker = new Stack<char>(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                char item = input[i];
                if (item == '(' || item == '{') //Check for left parenthesis
                {
                    tracker.Push(item);
                    
                }
                else if (item == ')' || item == '}') //Check for right parenthesis
                {
                    if (tracker.Count ==0)
                    {
                        errorAt = i + 1;
                        return false;
                    }
                    else
                    {
                        char temp = tracker.Pop();
                        if ( !((item == ')' && temp == '(') || (item=='}' && temp == '{')) )
                        {
                            errorAt = i+1;
                            return false;
                        }
                    }
                }
            }

            if (tracker.Count > 0)
            {
                errorAt = tracker.Peek() + 1;
                return false;
            }
            return true;
        }

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
    }
}