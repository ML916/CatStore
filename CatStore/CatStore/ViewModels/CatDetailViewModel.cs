﻿using System;
using System.Collections.Generic;
using System.Text;
using CatStore.Models;
using Xamarin.Forms;
using CatStore.Views;

namespace CatStore.ViewModels
{
    /// <summary>
    /// ViewModel för data till CatDetailPage
    /// </summary>
    public class CatDetailViewModel : BaseViewModel
    {
        public Cat Cat { get; set; }
        public CatDetailViewModel(Cat cat) {
            Title = cat.Name;
            Cat = cat;

            //Tar mot meddelande från CatDetailPage
            /*MessagingCenter.Subscribe<CatDetailPage, Cat>(this, MessagesAndUrls.AddToCart, (obj, item) =>
            {
                var newCat = item as Cat;
            });*/
        }
    }
}
