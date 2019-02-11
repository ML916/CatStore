using System;
using System.Collections.Generic;
using System.Text;
using CatStore.Services;
using Xamarin.Forms;
using CatStore.Views;
using CatStore.Models;
using System.Net.Http;
using System.Net;

namespace CatStore.ViewModels
{
    public class ShoppingCartViewModel : BaseViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }

        public ShoppingCartViewModel()
        {
            ShoppingCart = new ShoppingCart();
            MessagingCenter.Subscribe<CatDetailPage, Cat>(this, MessagesAndUrls.AddToCart, async (sender, arg) => {
                var cat = arg as Cat;
                if (await ShoppingCart.AddItemAsync(cat)) {
                    
                }
            });

            MessagingCenter.Subscribe<ShoppingCartPage, Cat>(this, MessagesAndUrls.DeleteFromShoppingCart, async (sender, arg) => {
                await ShoppingCart.DeleteItemAsync(arg.Id);
            });

            MessagingCenter.Subscribe<ShoppingCartPage>(this, MessagesAndUrls.SendOrder, async (sender) => {
                var httpResponse = await ShoppingCart.SendOrder();
                var statusCode = httpResponse.StatusCode;
                MessagingCenter.Send(this, MessagesAndUrls.OrderResponseMessage,statusCode);
            });
        }
        
    }
}
