using System;
using System.Collections.Generic;
using Doan.Model;
using Xamarin.Forms;

namespace Doan.View.Products
{
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage()
        {
            InitializeComponent();
            getCategoryList();
        }
        public void getCategoryList()
        {
            string url = "https://cf.shopee.vn/file/90c00a6eaef4f5ee3e8bdf19472b8141";
            List<Category> list = new List<Category>();
            list.Add(new Category { idCategory = 1, image = url, title = "Sneaker" });
            list.Add(new Category { idCategory = 1, image = url, title = "Sneaker" });
            list.Add(new Category { idCategory = 1, image = url, title = "Sneaker" });
            list.Add(new Category { idCategory = 1, image = url, title = "Sneaker" });
            list.Add(new Category { idCategory = 1, image = url, title = "Sneaker" });
            CategoryList.ItemsSource = list;
        }

        void gotoProduct_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ProductPage());
        }
       
    }
}
