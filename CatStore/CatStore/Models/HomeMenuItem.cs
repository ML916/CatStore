using System;
using System.Collections.Generic;
using System.Text;

namespace CatStore.Models
{
    /// <summary>
    /// Klass för att hantera föremål i detaljmeny
    /// </summary>
    public enum MenuItemType
    {
        StoreFront,
        ShoppingCart,
        OrderStatus
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
