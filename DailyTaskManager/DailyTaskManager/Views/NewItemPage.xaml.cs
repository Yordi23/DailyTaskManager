using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DailyTaskManager.Models;
using DailyTaskManager.Services.Sqlite;
using System.Security.Cryptography;
using Plugin.LocalNotifications;

namespace DailyTaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }
        public int id = 0;

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
                Item.Date = (FechaPicker.Date.Day.ToString() + "/" + FechaPicker.Date.Month.ToString() + "/" +
                FechaPicker.Date.Year.ToString());
                using (var data = new DataAccess())
                {
                    Activities actividad = new Activities
                    {
                        Nombre = Item.Name,
                        Descripcion = Item.Description,
                        Fecha = Item.Date,
                        Lugar = Item.Place,
                        Hora = Item.Time,
                        Pendiente = true,
                        Prioridad = Item.Priority,
                        RowId = CreateRowID()
                    };

                    data.Insert(actividad);
                    data.Dispose();
                }
                
                if (((Convert.ToDateTime(Item.Date)).Year) == DateTime.Now.Year)
                {
                    int notificationDate = (((Convert.ToDateTime(Item.Date)).DayOfYear - DateTime.Now.DayOfYear)) - 1;

                    if (notificationDate >= 0)
                    {
                        CrossLocalNotifications.Current.Show("Pendiente para mañana:" + Item.Name, Item.Description, id, DateTime.Now.AddDays(notificationDate));
                    }
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
            TxtPlace.Focus();
        }

        public void NextEntry (object sender, EventArgs e )
        {
            var entry = (Entry) sender;
            var classId = entry.ClassId;

            switch (classId)
            {
                case "txtNombre":
                    TxtDescription.Focus();
                    break;
                case "txtDescription":
                    FechaPicker.Focus();
                    break;
                case "txtPlace":
                    TxtPriority.Focus();
                    break;

            }
            
        }
        
        

    }
}