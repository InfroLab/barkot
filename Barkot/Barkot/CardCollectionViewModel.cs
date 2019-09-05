using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System;
using Xamarin.Forms;

namespace Barkot
{
    public class CardCollectionViewModel : INotifyPropertyChanged
    {
        public static ObservableCollection<CardViewModel> Cards { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        //Обновление списка
        public static void UpdateCards()
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
