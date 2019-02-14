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
    /// <summary>
    /// Bakomliggande kod för Beställningar-sidan. Listar upp alla beställningar som kan hämtas från API
    /// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderStatusPage : ContentPage
	{
		public OrderStatusPage ()
		{
			InitializeComponent ();
		}

        //OnAppearing körs när sidan öppnas, meddelande skickas via MessagingCenter för hämtning av objekt från api/orders
        protected override void OnAppearing()
        {
            MessagingCenter.Send(this, MessagesAndUrls.GetOrdersFromApiMessage);
            base.OnAppearing();
        }

        //Event-hantering för val av beställning från lista, öppnar ny kvittosida.
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