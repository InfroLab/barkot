using System.ComponentModel;
using System.Collections.ObjectModel;
using System;

namespace Barkot
{
    public class CardCollectionViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CardViewModel> Cards
        {
            get
            {
                return Cards;
            }
            set
            {
                if (Cards != value)
                {
                    Cards = value;
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
            //Создаем пустой список
            Cards = new ObservableCollection<CardViewModel>();

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
