using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Barkot
{
    public partial class App : Application
    {
        //Имя БД
        public const string DATABASE_NAME = "card2.db";
        private static Repository database;
        public static Repository Database
        {
            get
            {
                if (database == null)
                {
                    database = new Repository(DATABASE_NAME);
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
