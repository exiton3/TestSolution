using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication2
{
    /* Complexity of alghorithm is O(N) where N is number of input Cards
     O(3N) ~ O(N)
    */
    public class CardSorter
    {
        public static IEnumerable<Card> SortCards(IList<Card> cards)
        {
            if (cards == null) throw new ArgumentNullException(nameof(cards));
            if (cards.Count == 0)
            {
                throw new ArgumentException("Input list of cards is empty", nameof(cards));
            }

            var result = new List<Card>();

            var endCards = new Dictionary<string, Card>();
            var startCards = new Dictionary<string, Card>();

            foreach (var card in cards)
            {
                if (!endCards.ContainsKey(card.End))
                {
                    endCards.Add(card.End, card);
                }
                if (!startCards.ContainsKey(card.Start))
                {
                    startCards.Add(card.Start, card);
                }
            }

            var firstCard = cards.FirstOrDefault(card => !endCards.ContainsKey(card.Start));
            if (firstCard == null)
            {
                return result;
            }

            result.Add(firstCard);

            for (var i = 0; i < cards.Count - 1; i++)
            {
                if (!startCards.ContainsKey(firstCard.End)) continue;
                var temp = startCards[firstCard.End];
                result.Add(temp);
                firstCard = temp;
            }

            return result;
        }
    }
}