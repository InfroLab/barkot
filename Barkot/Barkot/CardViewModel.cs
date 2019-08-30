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
        }
        public ICommand EditCardCommand { private set; get; }
        public ICommand AddCardCommand { private set; get; }
        public ICommand AddCardPhotoCommand { private set; get; }
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
