using System;
using System.Collections.Generic;
using System.Net.Http;
using Doan.Model;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Doan.View.Account
{
    public partial class OrdersPage : ContentPage
    {
        string user = Preferences.Get("IdUser", string.Empty);
        public OrdersPage()
        {
            InitializeComponent();
            getListCategory();
        }
        public async void getListCategory()
        {
            string url = "http://localhost:2000/api/orders/"+ user;
            HttpClient http = new HttpClient();
            var response = await http.GetStringAsync(url);
            if (response != null)
            {
                var json = JsonConvert.DeserializeObject<List<OrdersList>>(response);
                if (json != null)
                {
                    listCartView.ItemsSource = json;
                }
            }
        }

        void listCartView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var selectItem = e.CurrentSelection[0] as OrdersList;
            Navigation.PushAsync(new DetailOrder(selectItem));
        }
    }
}
