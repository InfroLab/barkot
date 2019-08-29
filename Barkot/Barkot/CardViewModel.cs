using SQLite;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Barkot
{
    [Table("Cards")]
    public class CardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public CardViewModel()
        {
            /*EditBarcodeCommand = new Command(
                execute: () =>
                {
                    Barcode = "7020015082238";
                }
                );*/
            EditCardCommand = new Command(
                execute: () =>
                {
                    //Вызов функции и передача ей текущего экземляра для правки
                    //карточки
                    //TO-DO: сделать красивее
                    MainPage.NavigateToEditCardPage(this);
                }
                );
        }
        /*public ICommand EditBarcodeCommand { private set; get; }
        public ICommand EditCompanyCommand { private set; get; }*/
        public ICommand EditCardCommand { private set; get; }
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        public string Company
        {
            get { return Company; }
            set
            {
                if (Company != value)
                {
                    Company = value;
                    OnPropertyChanged("Company");
                }
            }
        }
        public string Barcode
        {
            get { return Barcode; }
            set
            {
                if (Barcode != value)
                {
                    Barcode = value;
                    OnPropertyChanged("Barcode");
                }
            }
        }
        public string Type
        {
            get { return Type; }
            set
            {
                if (Type != value)
                {
                    Type = value;
                    OnPropertyChanged("Type");
                }
            }
        }
        public string Site
        {
            get { return Site; }
            set
            {
                if (Site != value)
                {
                    Site = value;
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
