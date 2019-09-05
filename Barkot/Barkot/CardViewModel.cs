using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Barkot
{
    public class CardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public CardViewModel(int id, string company, string barcode, string type, string site)
        {
            EditCardCommand = new Command(
                execute: () =>
                {
                    //Создадим экземляр класса страницы передав в конструктор
                    //текущий экземпляр карточки
                    //Передадим экземпляр класса страницы в его функцию
                    EditCardPage page = new EditCardPage(this);
                    page.NavigateToEditCardPage(page);
                }
                );
            AddCardCommand = new Command(
                execute: () =>
                {

                }
                );
            AddCardPhotoCommand = new Command(
                execute: () =>
                {

                }
                );

            Id = id;
            Company = company;
            Barcode = barcode;
            Type = type;
            Site = site;
        }
        public ICommand EditCardCommand { private set; get; }
        public ICommand AddCardCommand { private set; get; }
        public ICommand AddCardPhotoCommand { private set; get; }

        private int id;
        private string company = "";
        private string barcode = "";
        private string type = "";
        private string site = "";

        public int Id { get; set; }
        public string Company
        {
            get { return company; }
            set
            {
                //Console.WriteLine("{0}", Company);
                if (company != value)
                {
                    company = value;
                    OnPropertyChanged("Company");
                }
            }
        }
        public string Barcode
        {
            get { return barcode; }
            set
            {
                if (barcode != value)
                {
                    barcode = value;
                    OnPropertyChanged("Barcode");
                }
            }
        }
        public string Type
        {
            get { return type; }
            set
            {
                if (type != value)
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }
        public string Site
        {
            get { return site; }
            set
            {
                if (site != value)
                {
                    site = @"https://logo.clearbit.com/" + value;
                    OnPropertyChanged("Site");
                }
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
