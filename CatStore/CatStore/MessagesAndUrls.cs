using System;
using System.Collections.Generic;
using System.Text;

namespace CatStore
{
    public static class MessagesAndUrls
    {
        public static readonly string AddToCart = "AddToShoppingCart";
        public static readonly string LoadCats = "LoadCatsFromAPI";
        public static readonly string DeleteFromShoppingCart = "DeleteFromShoppingCart";
        public static readonly string SendOrder = "SendOrder";
        public static readonly string OrderResponseMessage = "OrderResponse";

        public static readonly string ApiURL = "https://sogetiorebrointerview.azurewebsites.net/api/";
        public static readonly string CatsURL = ApiURL + "cats/";
        public static readonly string OrdersURL = ApiURL + "orders/";
    }
}
