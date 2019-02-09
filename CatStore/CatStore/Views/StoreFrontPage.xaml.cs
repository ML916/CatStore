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
        StoreFrontViewModel viewModel;

		public StoreFrontPage ()
		{
			InitializeComponent ();
            this.viewModel = new StoreFrontViewModel();
            BindingContext = this.viewModel;
		}
	}
}