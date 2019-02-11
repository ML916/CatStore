using CatStore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CatStore.ViewModels
{
    public class OrderStatusViewModel : BaseViewModel
    {
        public ObservableCollection<Order> Orders { get; set; }

        public OrderStatusViewModel() {
            Title = "Beställningar";
        }
    }
}
