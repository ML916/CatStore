using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Net.Http;
using System.Net;
using System.Collections.ObjectModel;

namespace CatStore.Models
{
    /// <summary>
    /// Klass motsvarande enskilda Order-objekt så som dom lagras i API:t/servern
    /// </summary>
    public class Order : INotifyPropertyChanged
    {
        private string id;
        private string status;

        public string Id {
            get => id;
            set {
                id = value;
                RaisePropertyChanged("Id");
            }
        }

        public string Status {
            get => status;
            set {
                status = value;
                RaisePropertyChanged("Status");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }

    /// <summary>
    /// Klass motsvarande objekt som returneras vid POST mot api/orders
    /// </summary>
    public class RootObjectResultOrder{
        private string orderId;
        public string OrderId { get => orderId; set => orderId = value; }
    }

    /// <summary>
    /// Klass motsvarande orders-objekt hämtade från GET mot api/orders
    /// </summary>
    public class RootObjectOrders : INotifyPropertyChanged
    {
        private ObservableCollection<Order> orders;
        public ObservableCollection<Order> Orders
        {
            get => orders;
            set
            {
                orders = value;
                RaisePropertyChanged("Orders");
            }
        }
        
        public RootObjectOrders()
        {
            orders = new ObservableCollection<Order>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string property) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public async void GetOrdersFromAPI()
        {
            HttpClient httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync(MessagesAndUrls.OrdersURL);
            var rootObject = await httpResponse.Content.ReadAsAsync<RootObjectOrders>();
            orders = rootObject.orders;
            RaisePropertyChanged("Orders");
        }
    }
}
