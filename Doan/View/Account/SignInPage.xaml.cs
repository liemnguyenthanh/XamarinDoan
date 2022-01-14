using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using Doan.View.Account;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Doan.Model;
using Xamarin.Essentials;
using Doan.View.Products;

namespace Doan.View
{
    
    public partial class SignInPage : ContentPage 
    {
        public SignInPage()
        {
            InitializeComponent();
        }
        string url = "http://localhost:2000/api/users";
        private void ExchangeSignUp_Clicked(object sender, EventArgs e)
        {
            ((Button)sender).TextColor = Color.Black;
            BoxViewOfSignUp.Color = Color.Black;

            ExchangeLogin.TextColor = Color.Gray;
            BoxViewOfLogIn.Color = Color.Gray;

            SignUp.IsVisible = true;
            LogIn.IsVisible = false;
        }

        private void ExchangeLogin_Clicked(object sender, EventArgs e)
        {
            ((Button)sender).TextColor = Color.Black;
            BoxViewOfLogIn.Color = Color.Black;

            ExchangeSignUp.TextColor = Color.Gray;
            BoxViewOfSignUp.Color = Color.Gray;

            SignUp.IsVisible = false;
            LogIn.IsVisible = true;
        }
        async void login_btn_Clicked(System.Object sender, System.EventArgs e)
        {
            HttpClient http = new HttpClient();
            AccountSignup user = new AccountSignup();
            user.username = l_username.Text;
            user.password = l_password.Text;
            var json = JsonConvert.SerializeObject(user);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(url + "/signin", httpContent);
            if (response != null)
            {
                var content = await response.Content.ReadAsStringAsync();
                string jsonContent = content.ToString();
                var user_res = JsonConvert.DeserializeObject<UserLogin>(jsonContent);

                if (user_res.success == true)
                {
                    Preferences.Set("IdUser", user_res.user._id);
                    await AppShell.Current.GoToAsync($"//CategoryPage");
                }
                else
                {
                    await DisplayAlert("Login", "Login Failed!!", "ok");
                }
            }
        }

        async  void signup_btn_Clicked(System.Object sender, System.EventArgs e)
        {
            HttpClient http = new HttpClient();
            AccountSignup user = new AccountSignup();
            user.username = r_username.Text;
            user.password = r_password.Text;
            user.name = r_full_name.Text;
            var json = JsonConvert.SerializeObject(user);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(url+ "/register", httpContent);
            if (response != null)
            {

                var content = await response.Content.ReadAsStringAsync();
                string jsonContent = content.ToString();
                Debug.Write(jsonContent);
                var user_res = JsonConvert.DeserializeObject<UserLogin>(jsonContent);

                if (user_res.success == true)
                {
                    await DisplayAlert("SignUp", "Success!!", "ok");
                }
                else
                {
                    await DisplayAlert("SignUp", "Failed!!", "ok");
                }
            }
            else
            {
                await DisplayAlert("Sign Up Failed!!","", "ok");
            }
        }
      
    }
}
