using System;
using System.Collections.Generic;
using System.Text;

namespace CatStore
{
    /// <summary>
    /// Klass som innehåller globala variabler för URL:er och meddelanden som används i övriga programmet
    /// </summary>
    public static class MessagesAndUrls
    {
        public static readonly string AddToCart = "AddToShoppingCart";
        public static readonly string LoadCats = "LoadCatsFromAPI";
        public static readonly string DeleteFromShoppingCart = "DeleteFromShoppingCart";
        public static readonly string SendOrder = "SendOrder";
        public static readonly string OrderResponseOkOrAccepted = "OrderResponseOk";
        public static readonly string OrderResponseError = "OrderError";
        public static readonly string GetOrdersFromApiMessage = "GetOrders";
        public static readonly string ItemAddedToCart = "Aded to cart";

        public static readonly string ApiURL = "https://sogetiorebrointerview.azurewebsites.net/api/";
        public static readonly string CatsURL = ApiURL + "cats/";
        public static readonly string OrdersURL = ApiURL + "orders/";
    }
}
