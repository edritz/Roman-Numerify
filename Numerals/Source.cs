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
            string romanNumeral = (Console.ReadLine()).ToUpper();
            Console.WriteLine("Your roman numerals translate to: " + EvaluateRoman(romanNumeral) + " in arabic numerals");
            Console.WriteLine("Enter a number based on arabic numerals");
            int arabicNumber = Int32.Parse(Console.ReadLine());
            Console.WriteLine(arabicNumber);
            Console.WriteLine(EvaluateArabic(arabicNumber));
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
                    leftSide = section.Substring(0, positionOfLargestValue);
                }
                if(positionOfLargestValue != section.Length - 1)
                {
                    rightSide = section.Substring(positionOfLargestValue + 1);
                }
                return RomanToArabic(section[positionOfLargestValue]) - EvaluateRoman(leftSide) + EvaluateRoman(rightSide);
                
            }
            else if(section.Length == 0)
            {
                return 0;
            }
            return RomanToArabic(section[positionOfLargestValue]);
        }

        static int FindLargestNumberPosition(string section)
        {
            int positionOfLargestValue = 0;
            int largestValue = 0;
            for (int x = 0; x < section.Length; x++)
            {
                if (RomanToArabic(section[x]) > largestValue)
                {
                    positionOfLargestValue = x;
                    largestValue = RomanToArabic(section[x]);
                }
            }
            return positionOfLargestValue;
        }

        static string EvaluateArabic(int currentNumber)
        {
            int closestNumber = ClosestNumber(currentNumber);
            int nextNumber = currentNumber - closestNumber;
            if(nextNumber > 0)
            {
                return ArabicToRomam(closestNumber) + EvaluateArabic(Math.Abs(nextNumber));
            }
            else if(nextNumber < 0)
            {
                return EvaluateArabic(Math.Abs(nextNumber)) + ArabicToRomam(closestNumber);
            }
            return ArabicToRomam(closestNumber);
        }

        static int ClosestNumber(int number)
        {
            int closestValue = 0;
            int[] arabic = { 1, 5, 10, 50, 100, 500, 1000 };
            for(int x = 0; x < arabic.Length; x++)
            {
                if (Math.Abs(number - arabic[x]) < Math.Abs(number - arabic[closestValue]))
                {
                    closestValue = x;
                }
            }
            return arabic[closestValue];
        }

        static string ArabicToRomam(int number)
        {
            switch(number)
            {
                case 1:
                    return "I";
                case 5:
                    return "V";
                case 10:
                    return "X";
                case 50:
                    return "L";
                case 100:
                    return "C";
                case 500:
                    return "D";
                case 1000:
                    return "M";
            }
            return "";
        }
    }
}
