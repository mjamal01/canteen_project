using System.ComponentModel;

namespace DellyShopApp.ViewModel
{
    public class CreditCardPageViewModel : INotifyPropertyChanged
    {
        private string _cardNumber, _cardCvv, _cardExpirationDate;

        public string CardNumber
        {
            get => _cardNumber;
            set
            {
                _cardNumber = value;
                OnPropertyChanged(nameof(CardNumber));
            }

        }

        public string CardCvv
        {
            get => _cardCvv;
            set
            {
                _cardCvv = value;
                OnPropertyChanged(nameof(CardCvv));
            }
        }
        public string CardExpirationDate
        {
            get => _cardExpirationDate;
            set
            {
                _cardExpirationDate = value;
                OnPropertyChanged(nameof(CardExpirationDate));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}