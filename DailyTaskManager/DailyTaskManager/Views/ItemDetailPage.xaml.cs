using System;
using DailyTaskManager.Services;
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

            var item = new Item("Vacio", "No existe nada que mostrar en esta actividad, intente más tarde",
                "INTEC", DateTime.Parse("01/01/01"), 0);

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        private void DeleteActivity(object sender, EventArgs e)
        {   
            
            var answer = DisplayAlert("Works?", viewModel.Item.GetRowId(), "Yes", "No");
            viewModel.DataStore.DeleteItemAsync(viewModel.Item.GetRowId());
            var dos = DisplayAlert("Works?", viewModel.Item.GetRowId(), "Yes", "No");
        }
        
        private void CompleteActivity(object sender, EventArgs e)
        {
            viewModel.Item.Complete();
        }
    }
}