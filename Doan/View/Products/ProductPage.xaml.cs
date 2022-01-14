using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Doan.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Doan.View.Products
{
    public partial class ProductPage : ContentPage
    {
        List<Product> localPro = new List<Product>(); 
        public ProductPage(string idCategory)
        {
            InitializeComponent();
            GetItemListAsync(idCategory);
        }
        async void GetItemListAsync(string idCategory)
        {
            string url = "http://localhost:2000/api/products/category/" + idCategory;
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(url);
            if (result != null)
            {
                var json = JsonConvert.DeserializeObject<ProductsList>(result);
                listProductView.ItemsSource = json.data;
                localPro = json.data;
            }

        }

        void listProductView_SelectionChanged(Object sender,SelectionChangedEventArgs e)
        {
            var selectItem = e.CurrentSelection[0] as Product;
            Navigation.PushAsync(new DetailProductPage(selectItem));
        }

        void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            List<Product> newList = new List<Product>();
            
            foreach (Product item in localPro)
            {
                if(item.name.Contains(searchBar.Text)) {
                    newList.Add(item);
                }
            }
            if(searchBar.Text != "")
            {
                listProductView.ItemsSource = newList;
            }
            else
            {
                listProductView.ItemsSource = localPro;
            }
        }
    }
}
