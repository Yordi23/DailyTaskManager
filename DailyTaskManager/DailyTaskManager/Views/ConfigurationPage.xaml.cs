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

        public void ShowTimePage()
        {
            Navigation.PushAsync(new TimePage());

        }
    }
}