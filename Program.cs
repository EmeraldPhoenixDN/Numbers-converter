using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money_Csharp
{
    class Program
    {

        private static string GetWords(string input)
        {
            // these are Divide_points for each 3 digit in numbers. Billion is max
            string[] Divide_points = { "", " Thousand ", " Million ", " Billion " };

            // Counter is indexed for Divide_points. Every 3 digits converted this will count.
            int i = 0;

            string strWords = "";

            while (input.Length > 0)
            {
                // get the 3 last numbers from input and store it. if there is not 3 numbers - take it.
                string _3digits = input.Length < 3 ? input : input.Substring(input.Length - 3);
                // remove the 3 last digits from input. if there is not 3 numbers - remove it.
                input = input.Length < 3 ? "" : input.Remove(input.Length - 3);

                int three_last = int.Parse(_3digits);
                // Convert 3 digit number into words.
                _3digits = GetWord(three_last);

                // Applying the seperator
                _3digits += Divide_points[i];
                strWords = _3digits + strWords;

                // 3 digits converted. Count and check for next 3 digits
                i++;
            }
            return strWords;
        }

        //convert 3digit number into words.
        private static string GetWord(int three_last)
        {
            string[] Ones =
            {
            "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
            "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Ninteen"
        };

            string[] Tens = { "Ten", "Twenty", "Thirty", "Fourty", "Fift", "Sixty", "Seventy", "Eighty", "Ninty" };

            string word = "";

            if (three_last > 99 && three_last < 1000)
            {
                int i = three_last / 100;
                word = word + Ones[i - 1] + " Hundred ";
                three_last = three_last % 100;
            }

            if (three_last > 19 && three_last < 100)
            {
                int i = three_last / 10;
                word = word + Tens[i - 1] + " ";
                three_last = three_last % 10;
            }

            if (three_last > 0 && three_last < 20)
            {
                word = word + Ones[three_last - 1];
            }

            return word;
        }
        private static void Main(string[] args)
        {
            Console.WriteLine("Put your value");
            string input = Console.ReadLine();

            // take decimal part of input.
            string Decimals_part = "";

            if (input.Contains("."))
            {
                Decimals_part = input.Substring(input.IndexOf(".") + 1);
                // Remove decimal part from input
                input = input.Remove(input.IndexOf("."));
            }

            // Convert input into words. save it into strWords
            string strWords = GetWords(input);


            if (Decimals_part.Length > 0)
            {
                // if there is any decimal part convert it to words and add it to strWords.
                strWords += " Dollars " + GetWords(Decimals_part) + " Cents";
            }

            Console.WriteLine(strWords);
            Console.ReadKey();
        }

        
    }
}
