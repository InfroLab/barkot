using System.ComponentModel;
using Xamarin.Forms;

namespace Barkot
{

    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public static async void NavigateToEditCardPage(CardViewModel card)
        {
            await Navigation.PushAsync(new EditCardPage(card));
        }
    }
}
