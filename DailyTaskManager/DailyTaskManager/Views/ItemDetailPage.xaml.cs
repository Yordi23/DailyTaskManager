using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DailyTaskManager.Models;
using DailyTaskManager.ViewModels;

namespace DailyTaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item("Item 1", "This is an item description.", "intec", DateTime.Parse("05/11/18"), 2);

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}