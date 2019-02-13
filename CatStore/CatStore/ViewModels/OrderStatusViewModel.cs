using CatStore.Models;
using CatStore.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace CatStore.ViewModels
{
    /// <summary>
    /// ViewModel-klass för hantering av Beställningar-sidan i appen
    /// </summary>
    public class OrderStatusViewModel : BaseViewModel
    {
        public RootObjectOrders RootObjectOrders { get; set; }

        public OrderStatusViewModel() {
            Title = "Beställningar";
            RootObjectOrders = new RootObjectOrders();
            //Tar mot meddelande för att utföra hämtning av katter från API
            MessagingCenter.Subscribe<OrderStatusPage>(this, MessagesAndUrls.GetOrdersFromApiMessage, (sender)=> {
                RootObjectOrders.GetOrdersFromAPI();
            });
        }
    }
}
