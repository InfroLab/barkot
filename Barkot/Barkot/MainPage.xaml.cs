using System.ComponentModel;
using Xamarin.Forms;

namespace Barkot
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new CardCollectionViewModel();
        }
    }
}
