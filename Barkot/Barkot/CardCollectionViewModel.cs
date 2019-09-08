using System.ComponentModel;
using System.Collections.ObjectModel;
using System;

namespace Barkot
{
    public class CardCollectionViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CardViewModel> cards = new ObservableCollection<CardViewModel>();
        public ObservableCollection<CardViewModel> Cards
        {
            get
            {
                return cards;
            }
            set
            {
                if (cards != value)
                {
                    cards = value;
                    OnPropertyChanged("Cards");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        //Обновление списка
        public void UpdateCards()
        {
            Cards = App.Database.GetItems();
            Console.WriteLine("DB LOADED");
        }
        public CardCollectionViewModel()
        {
            //Инициализация списка тут
            UpdateCards();
            Console.WriteLine("LIST LOADED");
        }
    protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
