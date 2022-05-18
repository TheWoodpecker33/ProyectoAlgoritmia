using ATM.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
