using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CatStore.Models
{
    /// <summary>
    /// Klass motsvarande enskilda katt-objekt
    /// </summary>
    public class Cat : INotifyPropertyChanged
    {
        private string id;
        private string name;
        private double price;

        public string Id {
            get => id;
            set {
                id = value;
                RaisePropertyChanged("Id");
            }
        }
        public string Name {
            get => name;
            set {
                name = value;
                RaisePropertyChanged("Name");
            }
        }
        public double Price {
            get => price;
            set {
                price = value;
                RaisePropertyChanged("Price");
            }
        }

        public override bool Equals(object obj)
        {
            var cat = obj as Cat;
            return cat != null &&
                   id == cat.id &&
                   name == cat.name &&
                   price == cat.price &&
                   Id == cat.Id &&
                   Name == cat.Name &&
                   Price == cat.Price;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }

    /// <summary>
    /// Klass motsvarande objekt som hämtas vid GET-anrop mot api/cats
    /// </summary>
    class RootObjectCats
    {
        public List<Cat> cats { get; set; }
    }
}
