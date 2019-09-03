using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Barkot
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCardPage : ContentPage
    {
        private CardViewModel old_card;
        public EditCardPage()
        {
            InitializeComponent();
        }

        //Страницы при открытии сразу заполняется переданными
        //ей данными карточки.
        public EditCardPage(CardViewModel card)
        {
            InitializeComponent();
            this.BindingContext = card;
            //Записываем переданную карточку в переменную
            old_card = card;
        }

        //Переход на следующую страницу
        public async void NavigateToEditCardPage(ContentPage page)
        {
            await Navigation.PushAsync(page);
        }

        //Переход на предыдущую страницу
        public async void NavigateFromEditCardPage(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        //Обноыление карточки
        public void UpdateCard(object seder, EventArgs e)
        {
            Card new_card = new Card();

            //Переписываем неизменяемые поля
            new_card.Id = old_card.Id;
            new_card.Type = old_card.Type;
            new_card.Site = old_card.Site;

            //Записываем изменяемые поля
            //TO-DO: Проверка входных данных
            new_card.Company = Company.Text;
            new_card.Barcode = Barcode.Text;

            //Обновляем элемент
            App.Database.SaveItem(new_card);

            //Обновляем список статическим методом
            CardCollectionViewModel.UpdateCards();
        }
    }
}