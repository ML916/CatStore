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
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShoppingCartPage : ContentPage
	{
		public ShoppingCartPage ()
		{
			InitializeComponent ();
            MessagingCenter.Subscribe<ShoppingCartViewModel, HttpStatusCode>(this, MessagesAndUrls.OrderResponseMessage, async (sender, args) =>
            {
                var statusCode = args;
                await DisplayAlert("Respons", "Svar från API: "+ statusCode, "Ok");
            });
		}

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

        private void FinalizeOrderButton_Pressed(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, MessagesAndUrls.SendOrder);
        }
    }
}