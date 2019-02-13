using CatStore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CatStore.Views
{
    /// <summary>
    /// MainPage laddar in detaljmenyn och de sidor den innehåller
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        StoreFrontPage storeFrontPage;
        ShoppingCartPage shoppingCartPage;
        OrderStatusPage orderStatusPage;

        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.StoreFront, (NavigationPage)Detail);
            storeFrontPage = new StoreFrontPage();
            shoppingCartPage = new ShoppingCartPage();
            orderStatusPage = new OrderStatusPage();
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.StoreFront:
                        MenuPages.Add(id, new NavigationPage(storeFrontPage));
                        break;
                    case (int)MenuItemType.ShoppingCart:
                        MenuPages.Add(id, new NavigationPage(shoppingCartPage));
                        break;
                    case (int)MenuItemType.OrderStatus:
                        MenuPages.Add(id, new NavigationPage(orderStatusPage));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}