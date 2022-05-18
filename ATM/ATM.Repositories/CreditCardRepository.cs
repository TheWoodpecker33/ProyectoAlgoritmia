using ATM.DataModel.Interfaces;
using ATM.DataModel.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace ATM.Repositories
{
    public class CreditCardRepository : ICreditCard
    {
        public List<CreditCard> Cards { get; set; } = new();
        public int CardsCount { get; set; }
        public CreditCardRepository(string fileName)
        {
            int id = 0;
            foreach (var card in File.ReadLines(fileName))
            {
                CreditCard newCard = new CreditCard { Id = id, Card = Int32.Parse(card) };
                Cards.Add(newCard);
                id++;
            }
            CardsCount = Cards[0].Card;
            Cards.RemoveAt(0);
        }
        public void RemoveCards(List<CreditCard> cards, int count)
        {
            while(cards.Count != count)
            {
                cards.RemoveAt(count);
            }
        }

        public bool ValidateCreditCards(List<CreditCard> cards, int count)
        {
            return cards.Count == count;
        }

        public List<CreditCard> GetList(List<CreditCard> cards)
        {
            Stack<CreditCard> otherList = new();
            int cont = 0;
            for(int i = 1; i < cards.Count; i++)
            {
                if(cards[cont].Card > cards[cont + 1].Card)
                {
                    if(!(cards[cont].Card > cards[cont + 2].Card))
                    otherList.Push(cards[cont + 1]);
                }
            }

            return null;
        }
    }
}
