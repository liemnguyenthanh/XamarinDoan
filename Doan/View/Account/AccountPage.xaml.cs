using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Doan.View.Account
{
    public partial class AccountPage : ContentPage
    {
        public AccountPage()
        {
            InitializeComponent();
        }
        void GotoProfile(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }
        void GotoOrder(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        void GotoLogin(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignInPage());
        }
    }
}
