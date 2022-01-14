using System;
using System.Collections.Generic;
using Doan.Model;
using Xamarin.Forms;

namespace Doan.View.Products
{
    public partial class SizePage : ContentPage
    {
        Product productDetail =new Product();
        public SizePage(Product item)
        {
            InitializeComponent();
            productDetail = item;
            p_image.Source = item.image;
            listSizesView.ItemsSource = item.sizes;
        }

        void listSizesView_SelectionChanged(Object sender,SelectionChangedEventArgs e)
        {
            var selectItem = e.CurrentSelection[0];
            double item = Convert.ToDouble(selectItem);
            Navigation.PushAsync(new ReviewPurchasePage(productDetail , item));
        }
    }
}
