using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CatStore.Models;
using CatStore.Views;
using Xamarin.Forms;

namespace CatStore.ViewModels
{
    /// <summary>
    /// ViewModel-klass för sortiments-sidan i appen
    /// </summary>
    public class StoreFrontViewModel : BaseViewModel
    {
        public StoreFront StoreFront { get; set; }
        public StoreFrontViewModel()
        {
            Title = "Sortiment";
            
            StoreFront = new StoreFront();

            //Tar mot meddelande för att hämta katter från API inuti StoreFront-objektet
            MessagingCenter.Subscribe<StoreFrontPage>(this, MessagesAndUrls.LoadCats, (sender) => {
                StoreFront.GetCatsFromAPI();
            });  
        }
    }
}
