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
    /// <summary>
    /// ViewModel-klass för hantering av varukorgen
    /// </summary>
    public class ShoppingCartViewModel : BaseViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }

        public ShoppingCartViewModel()
        {
            ShoppingCart = new ShoppingCart();

            //Tar mot meddelande för tillägg i varukorgen
            MessagingCenter.Subscribe<CatDetailPage, Cat>(this, MessagesAndUrls.AddToCart, async (sender, arg) => {
                var cat = arg as Cat;
                var isAdded = await ShoppingCart.AddItemAsync(cat);
                //Skickar meddelande för att bekräfta huruvida ett föremål blir tillagt i varukorg eller inte
                MessagingCenter.Send(this, MessagesAndUrls.ItemAddedToCart, isAdded);
            });

            //Tar mot meddelanden för borttagning av föremål från undvagn
            MessagingCenter.Subscribe<ShoppingCartPage, Cat>(this, MessagesAndUrls.DeleteFromShoppingCart, async (sender, arg) => {
                await ShoppingCart.DeleteItemAsync(arg.Id);
            });

            //Tar mot meddelanden från ShoppingCartPage för respons angående beställningar från API
            MessagingCenter.Subscribe<ShoppingCartPage>(this, MessagesAndUrls.SendOrder, async (sender) => {
                var httpResponse = await ShoppingCart.SendOrder();
                var statusCode = httpResponse.StatusCode;
                if(statusCode == HttpStatusCode.Accepted || statusCode == HttpStatusCode.OK)
                {
                    var resultOrder = await httpResponse.Content.ReadAsAsync<RootObjectResultOrder>();
                    MessagingCenter.Send(this, MessagesAndUrls.OrderResponseOkOrAccepted, resultOrder.OrderId);
                    ShoppingCart.ClearItems();
                }
                else
                {
                    MessagingCenter.Send(this, MessagesAndUrls.OrderResponseError, statusCode);
                }
            });
        }
        
    }
}
