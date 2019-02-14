using CatStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CatStore.Views
{
    /// <summary>
    /// Klass för att visa kvitto hämtat från /api/id/orders
    /// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReceiptPage : ContentPage
	{
        private string id;
        public Receipt Receipt { get; set; }
		
        public ReceiptPage(string id)
        {
            this.id = id;
            Title = "Kvitto " + id;
            InitializeComponent();
        }

        //Hämtar kvitto baserat på id
        private async Task SetupBindingContext(string id) {
            HttpClient httpClient = new HttpClient();
            string receiptURL = MessagesAndUrls.OrdersURL + id + "/receipt";
            var httpResponse = await httpClient.GetAsync(receiptURL);
            Receipt = await httpResponse.Content.ReadAsAsync<Receipt>();
            this.BindingContext = Receipt;
        }

        protected override async void OnAppearing()
        {
            await SetupBindingContext(id);
            base.OnAppearing();
        }
    }
}