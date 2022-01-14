using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Doan.View.Account
{
    public partial class AccountPage : ContentPage
    {
        public AccountPage()
        {
            InitializeComponent();
            getInit();
        }
        public void getInit()
        {
            string user = Preferences.Get("IdUser", string.Empty);
            if (user != "")
            {
                logoutStack.IsVisible = true;
                loginStack.IsVisible = false;
            }
            else
            {
                logoutStack.IsVisible = false;
                loginStack.IsVisible = true;
            }
        }
        void GotoProfile(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }
        void GotoOrder(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrdersPage());
        }

        void GotoLogin(Object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignInPage());
        }

        void btnLogout_Clicked(System.Object sender, System.EventArgs e)
        {
            Preferences.Set("IdUser","");
            getInit();
        }
    }
}
