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
                if (TxtDescription.Text.Length == 0 || TxtNombre.Text.Length == 0 || TxtPlace.Text.Length == 0 || TxtPriority.Text.Length == 0)
                {
                    await DisplayAlert("Error", "Faltan datos por ingresar", "aceptar");
                    TxtNombre.Focus();
                    return;
                }
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
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "aceptar");
            }
            await Navigation.PopModalAsync();

        }
    }
}