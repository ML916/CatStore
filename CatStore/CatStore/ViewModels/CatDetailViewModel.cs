using System;
using System.Collections.Generic;
using System.Text;
using CatStore.Models;

namespace CatStore.ViewModels
{
    public class CatDetailViewModel : BaseViewModel
    {
        public Cat Cat { get; set; }
        public CatDetailViewModel(Cat cat) {
            Title = cat.Name;
            Cat = cat;
        }
    }
}
