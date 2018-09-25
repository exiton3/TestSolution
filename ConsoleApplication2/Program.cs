using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ConsoleApplication2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cards = new List<Card>
            {
                new Card {Start = "Melburn", End = "Cologne"},
                new Card {Start = "Moscow", End = "Paris"},
                new Card {Start = "Cologne", End = "Moscow"}
            };

            var result = CardSorter.SortCards(cards);

            foreach (var card in result)
            {
                Write("{0} -> {1} , ", card.Start, card.End);
            }
            ReadKey();
        }
        
        static string GetStringFromArray(int[] a)
        {
            string result = string.Empty;
            Array.Sort(a);   
            int start = a[0];
            int end = a[0];

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] - a[i - 1] == 1)
                {
                    end = a[i];
                }
                else
                {
                    result += FormatString(start, end) + ",";
                    start = a[i];
                    end = a[i];
                }
            }

            result += FormatString(start, end);

            return result;
        }

        private static string FormatString(int start, int end)
        {
            return start == end ? start.ToString() : start + "-" + end;
        }    }
}
