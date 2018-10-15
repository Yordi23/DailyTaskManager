﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DailyTaskManager.Models;
using DailyTaskManager.Views;
using DailyTaskManager.ViewModels;
using XLabs.Forms.Behaviors;
using XLabs.Forms.Controls;
using System.Diagnostics;

namespace DailyTaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;


        public ItemsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            LoadItem();
            string dia;
            dia = DateTime.Now.ToString("dddd") + " " + DateTime.Today.Day.ToString();
            lblDate.Text = dia + ", " + DateTime.Now.ToString("MMMM");
            RefreshPronóstico();
        }
        public void LoadItem()
        {
            BindingContext = viewModel = null;
            BindingContext = viewModel = new ItemsViewModel();
            RefreshPronóstico();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
            ItemsListView.BeginRefresh();
            ItemsListView.SelectedItem = null;
            ItemsListView.EndRefresh();
            LoadItem();
            RefreshPronóstico();
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
            RefreshPronóstico();
        }
        /*
        private void GesturesContentView_GestureRecognized(object sender, GestureResult e)
        {
            switch (e.GestureType)
            {
                case GestureType.LongPress:
                    var answer = DisplayAlert("Works?","LONG PRESS", "Yes", "No");
                    
                    break;
                case GestureType.SingleTap:
                    // Add code here                    
                    break;
                case GestureType.DoubleTap:
                    // Add code here
                    break;
                default:
                    break;
            }
        }
        */
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
            RefreshPronóstico();
        }

        public void RefreshPronóstico()
        {
            ReminderPage reminder = new ReminderPage();
            int itemCount = reminder.itemCount;
            if (itemCount <= 10)
            {
                lblPronóstico.Text = "Ligero";
            }
            else if ((itemCount > 10) && (itemCount < 15))
            {
                lblPronóstico.Text = "Ocupado";
            }
            else
            {
                lblPronóstico.Text = "Saturado";
            }

        }
    }
}