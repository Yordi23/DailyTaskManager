using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyTaskManager.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfigurationPage : ContentPage
	{
		public ConfigurationPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            string dia;
            dia = DateTime.Now.ToString("dddd") + " " + DateTime.Today.Day.ToString();
            lblDate.Text = dia + ", " + DateTime.Now.ToString("MMMM");
        }

        public void ItemTappedHandler (object sender, ItemTappedEventArgs e)
        {
            var item = e.Item;

            if (item == null) { return; }

            switch (item)
            {
                case "Tiempo":
                    Navigation.PushModalAsync(new NavigationPage(new TimePage()));
                    break;
                case "Estilo":
                    Navigation.PushModalAsync(new NavigationPage(new StylePage()));
                    break;
                case "Perfil":
                    Navigation.PushModalAsync(new NavigationPage(new ProfilePage()));
                    break;


            }
        }
    }
}