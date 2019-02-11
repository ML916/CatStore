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
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StoreFrontPage : ContentPage
	{
		public StoreFrontPage ()
		{
            InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            MessagingCenter.Send(this, MessagesAndUrls.LoadCats);
            base.OnAppearing();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) {
                return;
            }

            await Navigation.PushAsync(new CatDetailPage(e.SelectedItem as Cat));
            catsListView.SelectedItem = null;
        }
    }
}