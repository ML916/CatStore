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
	public partial class CatDetailPage : ContentPage
	{
        CatDetailViewModel viewModel;

        public CatDetailPage() {
            InitializeComponent();

            var cat = new Cat();

            viewModel = new CatDetailViewModel(cat);
            BindingContext = this.viewModel;
        }

		public CatDetailPage (CatDetailViewModel viewModel)
		{
			InitializeComponent ();
            this.viewModel = viewModel;
            BindingContext = this.viewModel;
		}

        private async void ToolbarAdd_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, MessageNames.AddToCart, viewModel.Cat);
            await DisplayAlert("Tillagd", "Katten finns nu i din varukorg", "Ok");
            await Navigation.PopModalAsync();
        }
    }
}