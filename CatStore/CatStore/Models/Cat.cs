using System;
using System.Collections.Generic;
using System.Text;

namespace CatStore.Models
{
    public class Cat
    {
        private string id;
        private string name;
        private double price;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
    }
}
