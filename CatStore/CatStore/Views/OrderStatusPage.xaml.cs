using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CatStore.Models;
namespace CatStore.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderStatusPage : ContentPage
	{
		public OrderStatusPage ()
		{
			InitializeComponent ();
		}

        private async void OrderListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var order = e.SelectedItem as Order;

            await Navigation.PushAsync(new ReceiptPage(order.Id));

            orderListView.SelectedItem = null;
        }
    }
}