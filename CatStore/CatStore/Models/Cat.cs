using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CatStore.Models
{
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
