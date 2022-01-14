using System;
using System.Collections.Generic;
using Doan.Model;
using Xamarin.Forms;

namespace Doan.View.Account
{
    public partial class DetailOrder : ContentPage
    {
        OrdersList proList = new OrdersList();
        public DetailOrder(OrdersList data)
        {
            InitializeComponent();
            proList = data;
            getInit(data);
        }
        void getInit(OrdersList data)
        {
            listDetailOrderView.ItemsSource = data.orderItems;
            o_address.Text = "Address: " + data.shipping.address;
            o_phone.Text = "Phone number: " + data.shipping.phone;
            o_user.Text = "Reciever:  " + data.shipping.reciever;
            o_total.Text = "Total: " + data.totalPrice +"VND";

        }
    }
}
