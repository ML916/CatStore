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
                var resultOrder = await httpResponse.Content.ReadAsAsync<RootObjectResultOrder>();
                
                var statusCode = httpResponse.StatusCode;
                if(statusCode == HttpStatusCode.Accepted)
                {
                    foreach(var item in ShoppingCart.Items)
                    {
                        await ShoppingCart.DeleteItemAsync(item.Id);
                    }
                }
                MessagingCenter.Send(this, MessagesAndUrls.OrderResponseMessage,statusCode);
            });
        }
        
    }
}
