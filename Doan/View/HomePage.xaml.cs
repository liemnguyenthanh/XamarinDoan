using System;
using System.Collections.Generic;
using System.Net.Http;
using Doan.View.Products;
using Xamarin.Forms;

namespace Doan.View
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            getListProduct();
        }
        string url = "https://fakestoreapi.com/products";
        public async void getListProduct()
        {
            HttpClient http = new HttpClient();
            var result = await http.GetAsync(url);
            if(result != null) { }
            await DisplayAlert("123", "123", "oce");
        }
        private void BuyOrBid_Clicked(object sender , EventArgs e)
        {
        }
    }
}
