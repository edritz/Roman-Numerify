using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerals
{
    enum RomanNumeral {I = 1, V = 5, X = 10, L = 50, C = 100, D = 500, M = 1000};
    class Source
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number based on roman numerals");
            string romanNumeral = Console.ReadLine();
            Console.WriteLine("Your roman numerals translate to: " + EvaluateRoman(romanNumeral) + " in arabic numerals");
            Console.ReadKey();
        }

        static string TranslateArabic(int number)
        {
            string romanNumber = "";

            return romanNumber;
        }

        static int TranslateRoman(string number)
        {
            number = number.ToUpper();
            int arabicNumber = 0;
            int previousNumber = 0;
            int currentNumber = 0;
            for(int x = 0; x < number.Length; x++)
            {
                currentNumber = RomanToArabic(number[x]);
                if(currentNumber >= previousNumber || (x != number.Length -1 && RomanToArabic(number[x + 1]) == 1))
                {
                    arabicNumber += currentNumber;
                }
                else
                {
                    arabicNumber -= currentNumber;
                }
                previousNumber = currentNumber;
            }
            return arabicNumber;
        }

        static int RomanToArabic(char letter)
        {
            switch(letter)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
            }
            return 0;
        }

        static int EvaluateRoman(string section)
        {
            int positionOfLargestValue = FindLargestNumberPosition(section);
            if(section.Length > 1)
            {
                string leftSide = "";
                string rightSide = "";
                if(positionOfLargestValue != 0)
                {
                    leftSide = section.Substring(0, positionOfLargestValue + 1);
                }
                if(positionOfLargestValue != section.Length - 1)
                {
                    rightSide = section.Substring(positionOfLargestValue + 1, section.Length - (positionOfLargestValue + 1));
                }
                return RomanToArabic(section[positionOfLargestValue]) - EvaluateRoman(leftSide) + EvaluateRoman(rightSide);
            }
            return RomanToArabic(section[0]);
        }

        static int FindLargestNumberPosition(string section)
        {
            int positionOfLargestValue = 0;
            int largestValue = 0;
            for (int x = 0; x > section.Length; x++)
            {
                if (section[x] > largestValue)
                {
                    positionOfLargestValue = x;
                    largestValue = section[x];
                }
            }
            return positionOfLargestValue;
        }


    }
}
