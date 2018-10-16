using System;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace DailyTaskManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage()
        {
            
            InitializeComponent();
            if (App.FirstExecution)
            {
                Navigation.PushModalAsync(new TimePage());
                Navigation.PushModalAsync(new ProfilePage());
                App.FirstExecution = false;
            }
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom)
             .SetBarItemColor(Color.FromHex("3498DB"))
             .SetBarSelectedItemColor(Color.FromHex("2C3E50"))
             .SetIsSwipePagingEnabled(true);
            CurrentPage = Children[2];
        }

        private void OnCurrentPageChanged(object sender, FocusEventArgs e)
        {

            if (CurrentPage == Children[0])
            {
                ReminderPage.LoadActivities();
                ReminderPage.LoadHour();
                return;
            }
            
            if(CurrentPage == Children[2])
            {
                MessagingCenter.Send(this, "UpdateHome");
                return;
            }

        }

    }
}