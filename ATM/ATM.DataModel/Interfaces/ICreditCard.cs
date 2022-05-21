using ATM.DataModel.Models;
using System.Collections.Generic;

namespace ATM.DataModel.Interfaces
{
    public interface ICreditCard
    {
        public bool ValidateCreditCards(List<CreditCard> cards, int count);
        public void RemoveCards(List<CreditCard> cards, int count);
        public List<CreditCard> GetOrderedList(List<CreditCard> cards);
    }
}
