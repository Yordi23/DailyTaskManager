using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyTaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            string dia;
            dia = DateTime.Now.ToString("dddd") + " " + DateTime.Today.Day.ToString();
            lblDate.Text = dia + ", " + DateTime.Now.ToString("MMMM");
        }
    }
}