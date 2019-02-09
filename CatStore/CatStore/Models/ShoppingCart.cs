using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CatStore.Models
{
    public class ShoppingCart : ObservableCollection<Cat>
    {
        public ShoppingCart()
        {
        }

        public ShoppingCart(List<Cat> list) : base(list)
        {
        }
    }
}
