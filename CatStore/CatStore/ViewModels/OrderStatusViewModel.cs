using CatStore.Models;
using CatStore.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace CatStore.ViewModels
{
    public class OrderStatusViewModel : BaseViewModel
    {
        public ObservableCollection<Order> Orders { get; set; }

        public RootObjectOrders RootObjectOrders { get; set; }

        public OrderStatusViewModel() {
            Title = "Beställningar";
            RootObjectOrders = new RootObjectOrders();
            MessagingCenter.Subscribe<OrderStatusPage>(this, MessagesAndUrls.GetOrdersFromApiMessage, (sender)=> {
                RootObjectOrders.GetOrdersFromAPI();
            });
        }
    }
}
