using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{

    public class BitManipulation
    {
         //Assume you have a binary number 00110010, you apply some function on it and the number changes to some random number 10100011. 
        //Write a function to determine which numbers flipped from 0 to 1 and which bits flipped from 1 to 0. (You will have to write 2 different functions for 0 to 1 and 1 to 0)
        /// <summary>
        /// Assume you have a binary number 00110010, you apply some function on it and the number changes to some random number 10100011.
        /// Write a function to determine which numbers flipped from 0 to 1 and which bits flipped from 1 to 0. (You will have to write 2 different functions for 0 to 1 and 1 to 0)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void IdentifyFlippedBitsToOne(string a = "00110010", string b = "10100011")
        {
            //Below are the Steps To Identify the bits that flipped to one 
            //1. Result = A XOR 1
            //2. C = Result AND B
            //3. All the position n c for which it is set to 1 are changed bits(0 to 1) position

            var result = (Convert.ToInt32(a, 2)^255);
            var c = result&Convert.ToInt32(b, 2);


        }
        //Assume you have a binary number 00110010, you apply some function on it and the number changes to some random number 10100011. 
        //Write a function to determine which numbers flipped from 0 to 1 and which bits flipped from 1 to 0. (You will have to write 2 different functions for 0 to 1 and 1 to 0)
        /// <summary>
        /// Assume you have a binary number 00110010, you apply some function on it and the number changes to some random number 10100011.
        /// Write a function to determine which numbers flipped from 0 to 1 and which bits flipped from 1 to 0. (You will have to write 2 different functions for 0 to 1 and 1 to 0)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void IdentifyFlippedBitsToZero(uint a, uint b)
        {
            //Below are the steps to Identify the bits that are flipped to zero
            //1. Result = A OR B
            //2. C =  Result XOR B
            //3. All the position n c for which it is set to 1 are changed bits(1 to 0) position
        }
    }
}
