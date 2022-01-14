using System;
using System.Collections.Generic;
using Doan.Model;
using Xamarin.Forms;

namespace Doan.View.Products
{
    public partial class DetailProductPage : ContentPage
    {
        Product productDeatail = new Product();
        public DetailProductPage(Product item)
        {
            InitializeComponent();
            productDeatail = item;
            p_name.Text = item.name;
            p_description.Text = item.description;
            p_image.Source = item.image;
        }

        void BuyPro_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SizePage(productDeatail));
        }
    }
}
