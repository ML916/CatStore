using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CatStore.Models;
using CatStore.Views;
using Xamarin.Forms;

namespace CatStore.ViewModels
{
    public class StoreFrontViewModel : BaseViewModel
    {
        public StoreFront StoreFront { get; set; }
        //ObservableCollection<Cat> Cats;
        public StoreFrontViewModel()
        {
            Title = "Sortiment";
            
            StoreFront = new StoreFront();
            MessagingCenter.Subscribe<StoreFrontPage>(this, MessagesAndUrls.LoadCats, (sender) => {
                StoreFront.GetCatsFromAPI();
            });  
        }
    }
}
