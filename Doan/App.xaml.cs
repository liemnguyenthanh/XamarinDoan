using System;
using Doan.View.Products;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Doan
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage =new AppShell( new NavigationPage( new CategoryPage() ) );
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
