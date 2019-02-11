﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CatStore.Models
{
    public class NewOrder
    {
        public List<string> catIds { get; set; }

        public NewOrder(ObservableCollection<Cat> cats) {
            catIds = new List<string>();
            foreach (var cat in cats)
            {
                catIds.Add(cat.Id);
            }
        }
    }
}
