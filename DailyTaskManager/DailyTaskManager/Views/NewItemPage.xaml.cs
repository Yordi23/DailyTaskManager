using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DailyTaskManager.Models;
using DailyTaskManager.Services.Sqlite;
using System.Security.Cryptography;

namespace DailyTaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item();

            BindingContext = this;

        }
        private string CreateRowID()
        {
            var bytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }

            string rid = BitConverter.ToString(bytes);
            return rid;
        }
        async void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
                MessagingCenter.Send(this, "AddItem", Item);
                
                using (var data = new DataAccess())
                {
                    Activities actividad = new Activities
                    {
                        Nombre = Item.Name,
                        Descripcion = Item.Description,
                        Fecha = Item.Date,
                        Lugar = Item.Place,
                        Pendiente = Item.Pendent,
                        Prioridad = Item.Priority,
                        RowId = CreateRowID()
                    };

                    data.InsertActvity(actividad);
                }
                
            }
            catch(Exception)
            {
                await DisplayAlert("Error", "Faltan datos por ingresar, tarea no agregada", "aceptar");
            }
            await Navigation.PopModalAsync();

        }

        private void FechaPicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            Item.Date = (FechaPicker.Date.Day.ToString() + "/" + FechaPicker.Date.Month.ToString() + "/" +
                FechaPicker.Date.Year.ToString());
        }
    }
}