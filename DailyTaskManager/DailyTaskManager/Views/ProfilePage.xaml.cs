using DailyTaskManager.Models.DB;
using DailyTaskManager.Services.Sqlite;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyTaskManager.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
        public static byte[] ImageArray;
		public ProfilePage ()
		{
			InitializeComponent ();
            LoadUserProfile();
		}

        public void Save()
        {
            User us = new User
            {
                Name = TxtNombreUsuario.Text,
                LastName = TxtApellidoUsuario.Text,
                Image = ImageArray
            };
            using (var data = new DataAccess())
            { 
                List<User> UserL = data.GetUsers();
                if(UserL.Count > 1)
                {
                    foreach (var item in UserL)
                    {
                        data.Delete(item);
                    }           
                }
                else if (UserL.Count == 1)
                {
                    User Nus = data.GetUser();
                    Nus.Name = us.Name;
                    Nus.LastName = us.LastName;
                    Nus.Image = us.Image;
                    data.Update(Nus);
                    

                }else if(UserL.Count == 0)
                {
                    data.Insert(us);
                }
                data.Dispose();
            }
            //DisplayAlert("Aviso", "Algunos cambios no serán establecidos hasta que reinicies la aplicación", "aceptar");
            Navigation.PopModalAsync();
        }

        public void LoadUserProfile()
        {
            try
            {
                using (var data = new DataAccess())
                {
                    User us = data.GetUser();
                    ImageBox.Source = ImageSource.FromStream(() => new MemoryStream(us.Image));
                    TxtApellidoUsuario.Text = us.LastName;
                    TxtNombreUsuario.Text = us.Name;
                    data.Dispose();
                }
            }
            catch
            {

            }
             
        }

        private async void BuscarImagen(object sender, EventArgs e)
        {
            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                var photo = await CrossMedia.Current.PickPhotoAsync();
                if (photo == null)
                    return;

                ImageBox.Source = ImageSource.FromStream(() => photo.GetStream());
                ImageArray = System.IO.File.ReadAllBytes(photo.Path);
            }
                
        }
    }
}