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
        }
    }
}