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
    /// Klass för sortiment-sidan i kattbutiken
    /// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StoreFrontPage : ContentPage
	{
		public StoreFrontPage ()
		{
            InitializeComponent ();
		}

        //Skickar meddelande för hämtning av katter från API när sidan visas
        protected override void OnAppearing()
        {
            MessagingCenter.Send(this, MessagesAndUrls.LoadCats);
            base.OnAppearing();
        }

        //Event-hantering för valda katter ur sortiment
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) {
                return;
            }
            //Öppnar ny CatDetailPage
            await Navigation.PushAsync(new CatDetailPage(e.SelectedItem as Cat));
            catsListView.SelectedItem = null;
        }
    }
}