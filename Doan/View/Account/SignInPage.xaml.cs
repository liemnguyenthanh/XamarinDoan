using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Doan.View
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();
        }
        
        async void submit_Clicked(System.Object sender, System.EventArgs e)
        {
            string url = "http://localhost:3000/api/users/login";
            HttpClient http = new HttpClient();
            User user = new User();
            user.username = usernameEn.Text;
            user.password = passwordEn.Text;
            var json = JsonConvert.SerializeObject(user);
            var httpContent = new StringContent(json ,Encoding.UTF8, "application/json");
            Debug.Write(httpContent);
            var response = await http.PostAsync(url, httpContent);
            if(response != null)
            {
                var content = await response.Content.ReadAsStringAsync();
                string jsonContent = content.ToString();
                var jsonObject = JObject.Parse(jsonContent);
                Debug.Write(jsonObject);
                bool success = bool.Parse((string)jsonObject["success"]);
                string msg = jsonObject["msg"].ToString();
                if (success == true)
                {
                    await DisplayAlert("Login", msg, "ok");
                }
                else
                {
                   await DisplayAlert("Login", msg, "ok");
                }
            }

        }
    }
}
