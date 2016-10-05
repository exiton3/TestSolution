using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication2;
using NUnit.Framework;
using static System.Console;

namespace CardSort.Tests
{
    [TestFixture]
    public class CardSorterTests
    {
        [Test]
        public void SortCards_ReturnSortedCards()
        {
            var cards = new List<Card>
            {
                new Card {Start = "Melburn", End = "Cologne"},
                new Card {Start = "Moscow", End = "Paris"},
                new Card {Start = "Cologne", End = "Moscow"}
            };

            var result = CardSorter.SortCards(cards).ToList();

            Print(result);

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0].Start, Is.EqualTo("Melburn"));
            Assert.That(result[0].End, Is.EqualTo("Cologne"));
            Assert.That(result[1].Start, Is.EqualTo("Cologne"));
            Assert.That(result[1].End, Is.EqualTo("Moscow"));
            Assert.That(result[2].Start, Is.EqualTo("Moscow"));
        }

        [Test]
        public void SortCards_ReturnsOneCardIfListContainsOneCard()
        {
            var cards = new List<Card>
            {
                new Card {Start = "Melburn", End = "Cologne"},
            };

            var result = CardSorter.SortCards(cards).ToList();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Start,Is.EqualTo("Melburn"));
            Assert.That(result[0].End,Is.EqualTo("Cologne"));
        }

        [Test]
        public void SortCards_RetrunsDistinctListOfCardsIfInInputTheyRepeat()
        {
            var cards = new List<Card>
            {
                new Card {Start = "Melburn", End = "Cologne"},
                new Card {Start = "Melburn", End = "Cogne"},
                new Card {Start = "Cologne", End = "Moscow"},
            };

            var result = CardSorter.SortCards(cards).ToList();

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Start, Is.EqualTo("Melburn"));
            Assert.That(result[0].End, Is.EqualTo("Cologne"));
        }

        [Test]
        public void SortCards_ThrowsExeptionIfParameterIsNull()
        {
            TestDelegate action = () => { CardSorter.SortCards(null); };

            Assert.Throws(typeof (ArgumentNullException), action);
        }

        [Test]
        public void SortCards_ThrowsExeptionIfInputListEmpty()
        {
            var cards = new List<Card>();

            TestDelegate action = () => { CardSorter.SortCards(cards); };

            Assert.Throws(typeof(ArgumentException), action);
        }
        private static void Print(List<Card> result)
        {
            foreach (var card in result)
            {
                Write("{0} -> {1} , ", card.Start, card.End);
            }
        }
    }
}
