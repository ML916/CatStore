using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

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

    public class RootObjectOrders
    {
        public List<Order> orders { get; set; }
    }
}
