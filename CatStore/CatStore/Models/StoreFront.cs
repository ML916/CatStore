using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
//using System.Net.Http.Formatting;
using System.Text;
using Newtonsoft.Json;
using CatStore;

namespace CatStore.Models
{
    public class StoreFront : INotifyPropertyChanged
    {
        private readonly string catsURL = "https://sogetiorebrointerview.azurewebsites.net/api/cats";
        
        public ObservableCollection<Cat> AvailableCats { get; set; }

        public StoreFront() {
            AvailableCats = new ObservableCollection<Cat>();
            //GetCatsFromAPI();
        }

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
