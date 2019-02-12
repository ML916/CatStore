using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Net.Http;
using System.Net;
using System.Collections.ObjectModel;

namespace CatStore.Models
{
    public class Order : INotifyPropertyChanged
    {
        private string id;
        private string status;

        public string Id {
            get => id;
            set {
                id = value;
                RaisePropertyChanged(Id);
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

    public class RootObjectResultOrder{
        private string orderId;
        public string OrderId { get => orderId; set => orderId = value; }
    }

    public class RootObjectOrders
    {
        public ObservableCollection<Order> orders { get; set; }
        
        public RootObjectOrders()
        {
            orders = new ObservableCollection<Order>();
        }

        public async void GetOrdersFromAPI()
        {
            HttpClient httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync(MessagesAndUrls.OrdersURL);
            var rootObject = await httpResponse.Content.ReadAsAsync<RootObjectOrders>();
            orders = rootObject.orders;
        }
    }
}
