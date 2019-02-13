using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using CatStore;

namespace CatStore.Models
{
    /// <summary>
    /// Klass för hantering av "business logic" till butikssidan
    /// </summary>
    public class StoreFront : INotifyPropertyChanged
    {
        public ObservableCollection<Cat> AvailableCats { get; set; }

        public StoreFront() {
            AvailableCats = new ObservableCollection<Cat>();
        }

        //Hämtning av Katter från api/cats
        public async void GetCatsFromAPI() {
            HttpClient httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync(MessagesAndUrls.CatsURL);
            RootObjectCats rootObjectCat = await httpResponse.Content.ReadAsAsync<RootObjectCats>();
            AvailableCats = new ObservableCollection<Cat>(rootObjectCat.cats);
            RaisePropertyChanged("AvailableCats");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string property) {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
