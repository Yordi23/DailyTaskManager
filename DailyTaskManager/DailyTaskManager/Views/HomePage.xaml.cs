﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyTaskManager.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            string Fecha, dia, mes;
            dia = DateTime.Today.DayOfWeek.ToString() +" "+ DateTime.Today.Day.ToString();
            lblDate.Text = dia +" "+ DateTime.Today.Month.ToString();
        }
	}
}