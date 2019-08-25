﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Barkot
{
    public class CardCollectionViewModel : INotifyPropertyChanged
    {
        CardViewModel cardEdit;
        bool propertyIsEditing;

        public event PropertyChangedEventHandler PropertyChanged;

        public CardViewModel CardEdit
        {
            get { return cardEdit; }
            set
            {
                if (cardEdit != value)
                {
                    cardEdit = value;
                    OnPropertyChanged("CardEdit");
                }
            }
        }
        public bool PropetyIsEditing
        {
            get { return propertyIsEditing; }
            set
            {
                if (propertyIsEditing != value)
                {
                    propertyIsEditing = value;
                    OnPropertyChanged("PropertyIsEditing");
                }
            }
        }

        public CardCollectionViewModel()
        {
            Cards.Add(new CardViewModel("Guess", "9078604371100650", "CODE_128", "guess.com"));
            Cards.Add(new CardViewModel("Timberland", "7020015082238", "EAN_13", "timberland.com"));


            //Задаем новую команду, создавая новый объект Command
            //и передаем ему двумя лямбдами функции execute и canExecute
            AddCommand = new Command(
                execute: ()=>
                {
                    // (???)
                    CardEdit.PropertyChanged += OnCardEditPropertyChanged;
                    //Говорим текущей модели представления, что происходят изменения
                    propertyIsEditing = true;
                    // (???)
                    RefreshCanExecutes();
                },
                canExecute: ()=>
                {
                    return !PropetyIsEditing;
                }
                );
        }

        void OnCardEditPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            //Вызов метода ChangeCanExecute() из класса Command
            //который вызывает событие CanExecuteChanged обозначающее то,
            //что возможность вызова команды изменилась
            (AddCommand as Command).ChangeCanExecute();
        }

        void RefreshCanExecutes()
        {
            (AddCommand as Command).ChangeCanExecute();
        }
        //Создание переменной команды, которая задается в конструкторе класса
        public ICommand AddCommand { private set; get; }
        // (???)
        public IList<CardViewModel> Cards { get; } = new ObservableCollection<CardViewModel>();
    protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
