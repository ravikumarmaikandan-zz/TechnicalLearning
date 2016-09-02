using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    internal class Trigger
    {
        private static void Main(string[] args)
        {
            Stringmanipulation.NumberToWords(1234);
            var isBalancedParenthis = Stringmanipulation.IsBalancedParentheses();
            Numbers.FindGreatestSumFromArrayItems();
            Numbers.FindNonDuplicateNumbers();

            Numbers.ArrangeNegativeNumbersToLeftWithOutChangingOrder();
            bool palindromeResult = Stringmanipulation.IsPalindrome("Levels");
            Numbers.ConvertToBinary(10);
            BitManipulation.IdentifyFlippedBitsToOne();

            var array1 = new string[]{"One","Two","Three"};
            var array2 = new string[] {"Four", "Five"};
            var array3 = new string[] {"Six", "Seven"};

            var temp = array1.Select(a1 => array2.SelectMany(a2 => array3.Select(a3 => Tuple.Create(a1, a2, a3))));
            var temp2 = (from item in array1
                from item2 in array2
                from item3 in array3
                select new {item, item2, item3}).ToList();


            // 1. Single Linked List 
            CustomLinkedList linkedList = new CustomLinkedList();
            //Create First Node 
            linkedList.Insert("First","Header");
            linkedList.Insert("Second","First");
            linkedList.Insert("Third", "First");
            linkedList.PrintList();

            //Third was wrongly placed so remove the third node 
            linkedList.Remove("Third");
            linkedList.PrintList();







            var collectionProgram = new CollectionPrograms();
            collectionProgram.FindContinuousCollection(8);
            var prog = new SampleProgram();
            Console.WriteLine(prog.Print());
            Console.ReadLine();
            SampleClass tt = new SampleClass();
            var result = tt.Division(4, 2);
            //Implement an algorithm to determine if a string has all unique characters . What if you cannot use additional data structures
            bool isUnique = Stringmanipulation.isUniqueChar("abd");
            bool isUnique2 = Stringmanipulation.isUniqueChar2("abd");

            //Reverse a string
            Stringmanipulation.Reverse("Ravi");

            //Find the pair which whose addition is equal to the provided number 
            //int[] array = {1,4,45,6,10,8};
            int[] array = { 10,5,6};
            Numbers.FindSumOfNumberInArray(array, 16);

            //Test finally, Will the finally statement execute if there is a return statement in the try
            Console.WriteLine(Stringmanipulation.TestFinally());


            //perform the addition of two numbers without using + operator
            Console.WriteLine("Sum is :"+ Numbers.AdditionOfNumbersWithoutUsingPlusOperator(2,3).ToString());
            Console.WriteLine("Sum is :" + Numbers.AdditionOfNumbersWithoutArithmeticOperator(2, 3).ToString());
            
            //Check if one string is the permutation of other
            string firststring = "God";
            string secondstring = "dog";
            Console.WriteLine(firststring+ " is a permuation of "+ secondstring+" : "+Stringmanipulation.IsStringPermutation(firststring,secondstring));

            //Check if one string is the permutation of other
            Console.WriteLine(firststring + " is a permuation(Without Case sensitive) of " + secondstring + " : " + Stringmanipulation.IsStringPermutationWithOutCaseSensitivity(firststring, secondstring));

            //Replace empty space of the string with %20
            string input = "Mr John Smith     ";
            Console.WriteLine("After replacing the empty space of input string:" + input.Trim() +
                              " the output string is:" + Stringmanipulation.ReplaceSpacewithsymbol(input,input.Trim().Length));

            //string input = "Mr John Smith  ";
            Console.WriteLine("After replacing the empty space of input string:" + input.Trim() +
                              " the output string is:" + Stringmanipulation.ReplaceSpaceWithSymbolOptimized(input.ToCharArray(), input.Trim().Length));

            var check = Stringmanipulation.AppedNumberOccueranceWithCharacter("aabcccccaaa");
            Console.ReadLine();
        }
    }
}