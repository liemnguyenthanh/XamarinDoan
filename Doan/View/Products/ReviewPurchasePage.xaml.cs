using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Doan.Model;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Doan.View.Products
{
    public partial class ReviewPurchasePage : ContentPage
    {
        Product productDetail = new Product();
        double price = 0;
        public ReviewPurchasePage(Product item , double size)
        {
            InitializeComponent();
            productDetail = item;
            p_size.Text ="Size :" + size.ToString();
            p_image.Source = item.image;
            p_name.Text = "Product :" + item.name;
            p_color.Text = "Colort :" + item.color;
            p_shipingtax.Text = "Shipping tax : 25.000";
            price = item.price + 25000;
            p_total.Text = "Total :" + price;
        }

        void reviewPurchase_Clicked(System.Object sender, System.EventArgs e)
        {
            popupView.IsVisible = true;
        }

        void cancelPopup_Clicked(System.Object sender, System.EventArgs e)
        {
            popupView.IsVisible = false;
        }
        int cnt = 1;
        private void up_Clicked(object sender, EventArgs e)
        {
            cnt++;
            count.Text = cnt.ToString();
            price = productDetail.price * cnt + 25000;
            p_total.Text = "Total :" + price;
        }

        private void down_Clicked(object sender, EventArgs e)
        {
            if(cnt > 1)
            {
                cnt--;
                price = productDetail.price * cnt + 25000;
                p_total.Text = "Total :" + price;
                count.Text = cnt.ToString();
            }
        }
        async void saveShippingAddress_Clicked(System.Object sender, System.EventArgs e)
        {
            string url = "http://localhost:2000/api/orders";
            HttpClient http = new HttpClient();
            OrderRequest orderReq = new OrderRequest();
            orderReq.user = Preferences.Get("IdUser", " ");
            OrderItem itemasd = new OrderItem{ product = productDetail._id, price = productDetail.price, qty = cnt };
            List<OrderItem> listItem= new List<OrderItem>();
            listItem.Add(itemasd);
            orderReq.orderItems = listItem;
            Shipping newShip = new Shipping { address = s_address.Text, reciever = s_name.Text, phone = s_phone.Text };
            orderReq.shipping = newShip;
            orderReq.itemsPrice = 0;
            foreach (OrderItem item in orderReq.orderItems)
            {
                orderReq.itemsPrice += (item.price * item.qty);
            }
            var json = JsonConvert.SerializeObject(orderReq);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(url, httpContent);
            if (response != null)
            {
                popupView.IsVisible = false;
                await DisplayAlert("Orders", "Success!!", "ok");
            }
        }
    }
}
