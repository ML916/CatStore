using CatStore.Models;
using CatStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CatStore.Views
{
    /// <summary>
    /// Denna klass är en sida för att visa detaljerad info om en katt
    /// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CatDetailPage : ContentPage
	{
        CatDetailViewModel viewModel;
        
		public CatDetailPage (Cat cat)
		{
			InitializeComponent ();
            this.viewModel = new CatDetailViewModel(cat);
            BindingContext = this.viewModel;

            //Tar mot meddelanden ang. föremål som redan finns i varukorg
            MessagingCenter.Subscribe<ShoppingCartViewModel, bool>(this, MessagesAndUrls.ItemAddedToCart, async (sender, isAdded) => {
                if (isAdded)
                {
                    await DisplayAlert("Tillagd", "Katten finns nu i din varukorg", "Ok");
                }
                else
                {
                    await DisplayAlert("Finns redan i varukorg", "Du kan inte lägga till fler av detta föremål i varukorgen", "Ok");
                }
                await Navigation.PopAsync();
            });
		}
       
        //Event-hantering för klick på "Lägg till i varukorg", skickar meddelande i MessagingCenter för att lägga till i varukorg
        private void ToolbarAdd_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, MessagesAndUrls.AddToCart, viewModel.Cat);
        }
    }
}