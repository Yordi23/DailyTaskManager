﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DailyTaskManager.Models;
using DailyTaskManager.Services.Sqlite;
using System.Security.Cryptography;

namespace DailyTaskManager.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimePage : ContentPage
	{
        string[] daysArray = new string [] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };
        byte day = 0;
        public TimePage ()
		{
			InitializeComponent ();
		}

        public void SaveTime ()
        {
           FreeTime 

        }

        public void PreviousDay()
        {
            if (day > 0)
            {
                day--;

            }
            else
            {
                day = 6;
            }
            lblDays.Text = daysArray[day];
            ResetTime();
        }

        public void NextDay ()
        {
            if (day < 6)
            {
                day++;
                
            }
            else
            {
                day = 0;
            }
            lblDays.Text = daysArray[day];
            ResetTime();
        }

        public void ResetTime ()
        {
            StartTime.Time = new TimeSpan(0);
            EndTime.Time = new TimeSpan(0);
        }

    
	}
}