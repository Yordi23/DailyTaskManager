﻿using System;
using DailyTaskManager.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DailyTaskManager.Models;
using DailyTaskManager.ViewModels;
using DailyTaskManager.Services.Sqlite;

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
            Algo();
        }
        /*
        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item("Vacio", "No existe nada que mostrar en esta actividad, intente más tarde",
                "INTEC", DateTime.Parse("01/01/01"), 0);

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }*/
        void Algo()
        {
            Item Item = viewModel.Item;
            string StMes = Item.Date.Substring(3, 2);
            int mes = int.Parse(StMes);
            Console.WriteLine(mes);
            if (mes >= DateTime.Today.Month - 3)
            {
                Console.WriteLine(mes);
            }
        }
        private void DeleteActivity(object sender, EventArgs e)
        {
            Item Item = viewModel.Item;
            using (var data = new DataAccess())
            {
                Activities actividad = new Activities
                {
                    Nombre = Item.Name,
                    Id = Item.Id,
                    Descripcion = Item.Description,
                    Fecha = Item.Date,
                    Lugar = Item.Place,
                    Hora = Item.Time,
                    Pendiente = Item.Pendent,
                    Prioridad = Item.Priority,
                    RowId = Item.RowId

                };
                data.Delete(actividad);
                data.Dispose();
            }
            Navigation.PopAsync();
            
        }
        
        private void CompleteActivity(object sender, EventArgs e)
        {
            using (var data = new DataAccess())
            {
                Item Item = viewModel.Item;
                Activities actividad = new Activities
                {
                    Nombre = Item.Name,
                    Id = Item.Id,
                    Descripcion = Item.Description,
                    Fecha = Item.Date,
                    Lugar = Item.Place,
                    Hora = Item.Time,
                    Pendiente = false,
                    Prioridad = Item.Priority,
                    RowId = Item.RowId
                };
                data.Update(actividad);
                data.Dispose();
            }
            Navigation.PopAsync();
        }
    }
}