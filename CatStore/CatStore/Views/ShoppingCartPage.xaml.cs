using CatStore.Models;
using CatStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CatStore.Views
{
    /// <summary>
    /// Klass för hantering av Varukorgs-sidan i appen
    /// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShoppingCartPage : ContentPage
	{
		public ShoppingCartPage ()
		{
			InitializeComponent ();

            //Tar mot meddelanden från ViewModel om något går fel med skickad beställning
            MessagingCenter.Subscribe<ShoppingCartViewModel, HttpStatusCode>(this, MessagesAndUrls.OrderResponseError, async (sender, args) =>
            {
                var statusCode = args;
                await DisplayAlert("Något gick fel", "Något gick fel med beställningen, felkod: "+ statusCode, "Ok");
            });

            //Tar mot meddelanden från ViewModel om skickad beställning går genom
            MessagingCenter.Subscribe<ShoppingCartViewModel, string>(this, MessagesAndUrls.OrderResponseOkOrAccepted, async (sender, args) =>
            {
                var response = await DisplayAlert("Mottagen beställning", "Din beställning har tagits mot för bearbetning. Vill du se kvittot nu? (Kvittot går även att hämta under Beställningar-fliken)", "Ja", "Nej");
                if (response) {
                    await Navigation.PushAsync(new ReceiptPage(args));
                }
            });
		}

        // Event-hantering för val av objekt från varukorgs-listan, meddelande skickas till ViewModel om användaren vill ta bort katt från varukorg
        private async void ShoppingCartListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) {
                return;
            }
            var cat = e.SelectedItem as Cat;
            var response = await DisplayAlert("Bekräfta", "Vill du ta bort denna katt från varukorgen?", "Ja", "Nej");
            if(response)
                MessagingCenter.Send(this, MessagesAndUrls.DeleteFromShoppingCart, cat);
            
            shoppingCartListView.SelectedItem = null;
        }

        //Event-hantering för tryck på Slutför beställning-knapp. Skickar meddelande till ViewModel för vidare hantering.
        private void FinalizeOrderButton_Pressed(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, MessagesAndUrls.SendOrder);
        }
    }
}