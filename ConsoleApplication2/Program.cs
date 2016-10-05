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
    }
}