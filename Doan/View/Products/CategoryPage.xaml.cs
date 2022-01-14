using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Doan.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Doan.View.Products
{
    public partial class CategoryPage : ContentPage
    {
        private ObservableCollection<Category> catList;
        public CategoryPage()
        {
            InitializeComponent();
            getListCategory();
        }
        public async void getListCategory()
        {
            string url = "http://localhost:2000/api/category";
            HttpClient http = new HttpClient();
            var response = await http.GetStringAsync(url);
            if (response != null)
            {
                var json = JsonConvert.DeserializeObject<CategoriesList>(response);
                if (json.success)
                {
                    catList = new ObservableCollection<Category>(json.data);
                    listCategoryView.ItemsSource = catList;
                }
            }
        }
     

        public void listCategoryView_SelectionChanged(Object sender, SelectionChangedEventArgs e)
        {
            var selectItem = e.CurrentSelection[0] as Category;
            Navigation.PushAsync(new ProductPage(selectItem._id));

        }

    }
   
}
