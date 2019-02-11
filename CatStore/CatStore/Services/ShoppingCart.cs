using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using CatStore.Models;
using System.ComponentModel;
using System.Net.Http;

namespace CatStore.Services
{
    public class ShoppingCart : IDataStore<Cat>, INotifyPropertyChanged
    {
        private double sum;
        public ObservableCollection<Cat> Items { get; private set; }

        public double Sum {
            get => sum;
            set {
                sum = value;
                RaisePropertyChanged("Sum");
            }
        }

        public ShoppingCart() {
            Items = new ObservableCollection<Cat>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void CalculateSum(){
            Sum = 0;
            foreach (var item in Items)
            {
                Sum += item.Price;
            }
            RaisePropertyChanged("Sum");
        }

        public async Task<HttpResponseMessage> SendOrder() {
            HttpClient httpClient = new HttpClient();
            var order = new NewOrder(Items);
            return await httpClient.PostAsJsonAsync(MessagesAndUrls.OrdersURL, order);
        }

        public async Task<bool> AddItemAsync(Cat item)
        {
            if (!Items.Contains(item)) { 
                Items.Add(item);
                CalculateSum();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = Items.Where((Cat cat) => cat.Id == id).FirstOrDefault();
            Items.Remove(oldItem);
            CalculateSum();
            return await Task.FromResult(true);
        }

        public async Task<Cat> GetItemAsync(string id)
        {
            return await Task.FromResult(Items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Cat>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }

        public Task<bool> UpdateItemAsync(Cat item)
        {
            throw new NotImplementedException();
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
