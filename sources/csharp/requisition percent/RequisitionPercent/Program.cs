using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace RequisitionPercent
{
    class Program
    {
        static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        static void Main(string[] args)
        {
            //var matchNumbers = Test1(1000, 3.2);

            var matchNumbers = Test2(1000, 3.2);
            Console.WriteLine("{0} numbers above 32% = {1}%", matchNumbers, matchNumbers / 10);
            Console.ReadKey();
        }

        static int Test1(
            int requisitionLength,
            double audienceLength
        )
        {
            int counter = 0;
            var data = new byte[10];

            for (int i = 0; i < requisitionLength; i++)
            {
                var value = RollDice((byte)data.Length);
                if (Math.Round(Convert.ToDouble(value)) < audienceLength)
                {
                    counter++;
                }
                Console.WriteLine(value);
            }

            return counter;
        }

        static int Test2(
            int requisitionLength,
            double audienceLength
        )
        {
            CryptoRandom rand = new CryptoRandom();
            int matchNumbers = 0;
            for (int i = 0; i < requisitionLength; i++)
            {
                var randomDouble = rand.NextDouble() * 100;

                if (randomDouble > audienceLength)
                {
                    matchNumbers++;
                }

                Console.WriteLine(randomDouble);
            }

            return matchNumbers;
        }

        static byte RollDice(byte numberSides)
        {
            if (numberSides <= 0)
                throw new ArgumentOutOfRangeException("numberSides");

            // Create a byte array to hold the random value. 
            byte[] randomNumber = new byte[1];
            do
            {
                // Fill the array with a random value.
                rng.GetBytes(randomNumber);
            }
            while (!IsFairRoll(randomNumber[0], numberSides));
            // Return the random number mod the number 
            // of sides.  The possible values are zero- 
            // based, so we add one. 
            return (byte)((randomNumber[0] % numberSides) + 1);
        }

        static bool IsFairRoll(byte roll, byte numSides)
        {
            // There are MaxValue / numSides full sets of numbers that can come up 
            // in a single byte.  For instance, if we have a 6 sided die, there are 
            // 42 full sets of 1-6 that come up.  The 43rd set is incomplete. 
            int fullSetsOfValues = Byte.MaxValue / numSides;

            // If the roll is within this range of fair values, then we let it continue. 
            // In the 6 sided die case, a roll between 0 and 251 is allowed.  (We use 
            // < rather than <= since the = portion allows through an extra 0 value). 
            // 252 through 255 would provide an extra 0, 1, 2, 3 so they are not fair 
            // to use. 
            return roll < numSides * fullSetsOfValues;
        }
    }
}