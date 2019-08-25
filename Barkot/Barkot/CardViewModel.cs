using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Barkot
{
    public class CardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Card card;
        public CardViewModel(string company, string barcode, string type, string site)
        {
            card = new Card(company, barcode, type, site);
            Company = company;
            Barcode = barcode;
            Type = type;
            Site = @"https://logo.clearbit.com/" + site;

            EditBarcodeCommand = new Command(
                execute: ()=>
                {
                    Barcode = "7020015082238";
                }
                );

            EditCompanyCommand = new Command(
                execute: () =>
                {
                    Company = "U.S. POLO ASSN.";
                }
                );
        }
        public ICommand EditBarcodeCommand { private set; get; }
        public ICommand EditCompanyCommand { private set; get; }
        public string Company
        {
            get { return card.Company; }
            set
            {
                if (card.Company != value)
                {
                    card.Company = value;
                    OnPropertyChanged("Company");
                }
            }
        }
        public string Barcode
        {
            get { return card.Barcode; }
            set
            {
                if (card.Barcode != value)
                {
                    card.Barcode = value;
                    OnPropertyChanged("Barcode");
                }
            }
        }
        public string Type
        {
            get { return card.Type; }
            set
            {
                if (card.Type != value)
                {
                    card.Type = value;
                    OnPropertyChanged("Type");
                }
            }
        }
        public string Site
        {
            get { return card.Site; }
            set
            {
                if (card.Site != value)
                {
                    card.Site = value;
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
