using System;
using System.Collections.Generic;
using System.Text;

namespace CatStore.Models
{
    public enum MenuItemType
    {
        StoreFront,
        ShoppingCart,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
