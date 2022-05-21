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

        public List<CreditCard> GetOrderedList(List<CreditCard> cards)
        {
            List<CreditCard> possibleCandidates = getLesserThanFirstCard(ref cards);
            List<CreditCard> answer =  possibleCandidates.Count > cards.Count ? possibleCandidates : cards;
            return answer;
        }

        public static List<CreditCard> getLesserThanFirstCard(ref List<CreditCard> fullCards)
        {
            List<CreditCard> cardsNotBigEnough = new();
            List<CreditCard> cardsToDelete = new();
            List<CreditCard> possibleAnswewrs = new();
            int pivot = 0;
            for (int i = 1; i < fullCards.Count; i++)
            {
                if(fullCards[pivot].Card > fullCards[i].Card)
                {
                    if(cardsNotBigEnough.Count > 0)
                    {
                        if(cardsNotBigEnough[cardsNotBigEnough.Count - 1].Card < 
                            fullCards[i].Card)
                        {
                            cardsNotBigEnough.Add(fullCards[i]);
                        }
                        else
                        {
                            cardsToDelete.Add(fullCards[i]);
                        }
                    }
                    else
                    {
                        cardsNotBigEnough.Add(fullCards[i]);
                    }
                }
                else if(cardsNotBigEnough.Count > 0)
                {
                    if (cardsNotBigEnough[cardsNotBigEnough.Count - 1].Card > fullCards[i].Card)
                    {
                        if (fullCards[pivot].Card < fullCards[i].Card)
                        {
                            continue;
                        }
                        cardsToDelete.Add(fullCards[i]);
                        continue;
                    }
                    cardsNotBigEnough.Add(fullCards[i]);
                }
            }
            foreach (CreditCard card in cardsToDelete)
            {
                fullCards.Remove(card);
            }

            foreach (var card in cardsNotBigEnough)
            {
                fullCards.Remove(card);
            }

            return cardsNotBigEnough;
        }

        public void WriteToFile(string fileName, List<CreditCard> cards)
        {
            using StreamWriter file = new(fileName);
            file.WriteLineAsync(cards.Count.ToString());
            foreach (CreditCard c in cards)
            {
                file.WriteLineAsync(c.Id.ToString());
            }

        }
    }
}
