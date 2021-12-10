using System;
using System.Collections.Generic;
using System.Net.Http;
using Doan.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Doan.View.Products
{
    public partial class ProductPage : ContentPage
    {
        public ProductPage()
        {
            InitializeComponent();
            GetItemList();
        }
        async void GetItemList()
        {
            string url = "https://fakestoreapi.com/products";
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(url);
            if(result != null)
            {
                var json = JsonConvert.DeserializeObject<Product[]>(result);
                //itemList.ItemsSource = json;
            }

        }
    }
}
