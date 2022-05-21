using ATM.DataModel.Models;
using ATM.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ATM.RepositoriesTest
{
    [TestClass]
    public class CreditCardRepositoryTest
    {
        [TestMethod]
        public void ConstructorTrueTest()
        {
            string fileName = "test01.in";

            var cards = new CreditCardRepository(fileName);

            Assert.IsTrue(cards.ValidateCreditCards(cards.Cards, cards.CardsCount));
        }

        [TestMethod]
        public void ConstructorFalseTest()
        {
            string fileName = "test02.in";

            var cards = new CreditCardRepository(fileName);

            Assert.IsFalse(cards.ValidateCreditCards(cards.Cards, cards.CardsCount));
        }

        [TestMethod]
        public void DeleteListTest()
        {
            string fileName = "test02.in";

            var cards = new CreditCardRepository(fileName);

            cards.RemoveCards(cards.Cards, cards.CardsCount);

            Assert.IsTrue(cards.ValidateCreditCards(cards.Cards, cards.CardsCount));
        }

        [TestMethod]
        public void TestUnorderedList()
        {
            List<CreditCard> unorderedList = new List<CreditCard>
            {
                new CreditCard { Id = 1, Card = 300},
                new CreditCard { Id = 2, Card = 200},
                new CreditCard { Id = 3, Card = 100},
                new CreditCard { Id = 4, Card = 50},
                new CreditCard { Id = 5, Card = 40},
                new CreditCard { Id = 6, Card = 10},
                new CreditCard { Id = 7, Card = 1}
            };

            List<CreditCard> testList = CreditCardRepository.getLesserThanFirstCard(ref     unorderedList);

            Assert.IsTrue(testList.Count == 1 && unorderedList.Count == 1);
        }

        [TestMethod]
        public void TestOrderedList()
        {
            List<CreditCard> orderedList = new List<CreditCard>
            {
                new CreditCard { Id = 1, Card = 300},
                new CreditCard { Id = 2, Card = 400},
                new CreditCard { Id = 3, Card = 500},
                new CreditCard { Id = 4, Card = 600},
                new CreditCard { Id = 5, Card = 700},
                new CreditCard { Id = 6, Card = 800},
                new CreditCard { Id = 7, Card = 900}
            };

            List<CreditCard> testList = CreditCardRepository.getLesserThanFirstCard(ref orderedList);

            Assert.IsTrue(testList.Count == 0 && orderedList.Count == 7);
        }

        [TestMethod]
        public void TestListOrderedByTheMiddle()
        {
            List<CreditCard> orderedList = new List<CreditCard>
            {
                new CreditCard { Id = 1, Card = 700},
                new CreditCard { Id = 2, Card = 100},
                new CreditCard { Id = 3, Card = 200},
                new CreditCard { Id = 4, Card = 300},
                new CreditCard { Id = 5, Card = 400},
                new CreditCard { Id = 6, Card = 500},
                new CreditCard { Id = 7, Card = 90}
            };

            List<CreditCard> testList = CreditCardRepository.getLesserThanFirstCard(ref orderedList);

            Assert.IsTrue(testList.Count == 5 && orderedList.Count == 1);
        }

        [TestMethod]
        public void TestListOrderedExceptForTheFirstOne()
        {
            List<CreditCard> orderedList = new List<CreditCard>
            {
                new CreditCard { Id = 1, Card = 700},
                new CreditCard { Id = 2, Card = 100},
                new CreditCard { Id = 3, Card = 200},
                new CreditCard { Id = 4, Card = 300},
                new CreditCard { Id = 5, Card = 400},
                new CreditCard { Id = 6, Card = 500},
                new CreditCard { Id = 7, Card = 900}
            };

            List<CreditCard> testList = CreditCardRepository.getLesserThanFirstCard(ref orderedList);

            Assert.IsTrue(testList.Count == 6 && orderedList.Count == 1);
        }

        [TestMethod]
        public void GoldieTest()
        {
            List<CreditCard> orderedList = new List<CreditCard>
            {
                new CreditCard { Id = 1, Card = 400},
                new CreditCard { Id = 2, Card = 200},
                new CreditCard { Id = 3, Card = 150},
                new CreditCard { Id = 4, Card = 300},
                new CreditCard { Id = 5, Card = 280},
                new CreditCard { Id = 6, Card = 210},
                new CreditCard { Id = 7, Card = 489},
                new CreditCard { Id = 8, Card = 200},
                new CreditCard { Id = 9, Card = 100},
                new CreditCard { Id = 10, Card = 450},
            };

            List<CreditCard> testList = CreditCardRepository.getLesserThanFirstCard(ref orderedList);

            Assert.IsTrue(testList.Count == 3 && orderedList.Count == 2);
        }

        [TestMethod]
        public void ProfeTest()
        {
            List<CreditCard> orderedList = new List<CreditCard>
            {
                new CreditCard { Id = 1, Card = 400},
                new CreditCard { Id = 2, Card = 300},
                new CreditCard { Id = 3, Card = 500},
                new CreditCard { Id = 4, Card = 450},
                new CreditCard { Id = 5, Card = 480},
            };

            List<CreditCard> testList = CreditCardRepository.getLesserThanFirstCard(ref orderedList);

            Assert.IsTrue(testList.Count == 2 && orderedList.Count == 3);
        }
    }
}
