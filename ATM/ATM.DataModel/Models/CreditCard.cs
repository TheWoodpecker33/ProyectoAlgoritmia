namespace ATM.DataModel.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        private int _card;

        public int Card
        {
            get => _card; 
            set 
            {
                if (_card < 0 || _card > 1000) return;
                _card = value; 
            }
        }

    }
}
