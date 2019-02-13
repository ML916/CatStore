using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using CatStore.Models;
using System.ComponentModel;
using System.Net.Http;
using CatStore.Services;

namespace CatStore.Models
{
    /// <summary>
    /// Klass för varukorgen, implementerar IDataStore för att ge mer repsons från funktioner för att lägga till och ta bort objekt från varukorg
    /// </summary>
    public class ShoppingCart : IDataStore<Cat>, INotifyPropertyChanged
    {
        private double sum;
        public ObservableCollection<Cat> Items { get; private set; }

        public double Sum {
            get => sum;
            private set {
                sum = value;
                RaisePropertyChanged("Sum");
            }
        }

        public ShoppingCart() {
            Items = new ObservableCollection<Cat>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //Funktion för beräkning av totala summan av innehåll i varukorg
        private void CalculateSum(){
            Sum = 0;
            foreach (var item in Items)
            {
                Sum += item.Price;
            }
            RaisePropertyChanged("Sum");
        }

        //Tömning av varukorg, nollställer också summan 
        public void ClearItems()
        {
            Items.Clear();
            CalculateSum();
        }

        //Funktion för att skicka beställningar mot api/orders
        public async Task<HttpResponseMessage> SendOrder() {
            HttpClient httpClient = new HttpClient();
            var order = new NewOrder(Items);
            return await httpClient.PostAsJsonAsync(MessagesAndUrls.OrdersURL, order);
        }

        //Funktion för att lägga till enskilda föremål i varukorg
        public async Task<bool> AddItemAsync(Cat item)
        {
            if (!Items.Contains(item)) { 
                Items.Add(item);
                CalculateSum();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        //Funktion för att ta bort enskilda föremål från varukorg baserat på id-parameter
        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = Items.Where((Cat cat) => cat.Id == id).FirstOrDefault();
            Items.Remove(oldItem);
            CalculateSum();
            return await Task.FromResult(true);
        }

        //Funktion för hämtning av föremål från varukorg baserat på id
        public async Task<Cat> GetItemAsync(string id)
        {
            return await Task.FromResult(Items.FirstOrDefault(s => s.Id == id));
        }

        //Funktion för hämtning av samtliga föremål från varukorg
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
