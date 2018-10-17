using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DailyTaskManager.Models;
using DailyTaskManager.Services.Sqlite;
using System.Security.Cryptography;
using DailyTaskManager.Models.DB;

namespace DailyTaskManager.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimePage : ContentPage
	{
        string[] arrayDays = new string [] { "lunes", "martes", "miércoles", "jueves", "viernes", "sábado", "domingo" };
        string[] arrayDays2 = new string[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };
        byte day = 0;
        public TimePage ()
		{
			InitializeComponent ();
            
        }

        public async Task SaveTime ()
        {
            try
            {

                FreeTime freeTime = new FreeTime();
                freeTime.Day = arrayDays[day];
                freeTime.StartTime = StartTime.Time.TotalMinutes;
                freeTime.EndTime = EndTime.Time.TotalMinutes;
                if (freeTime.EndTime <= freeTime.StartTime)
                {
                    await DisplayAlert("Error", "La fecha de cierre no puede ser menor a la hora de inicio", "Acepar");
                    return;
                }

               bool answer = await DisplayAlert("Verificación", string.Format("Seguro que desea guardar el tiempo: \n {0}, {1} - {2} ?", freeTime.Day,StartTime.Time,EndTime.Time),"Aceptar","Cancelar");
                if (!answer)
                {
                    return;
                }
                using (var data = new DataAccess())
                {
                    List<FreeTime> CurretFreeTime = data.GetFreeTime(freeTime.Day);
                    foreach (FreeTime free in CurretFreeTime)
                    {
                        if (freeTime.StartTime>= free.StartTime && freeTime.EndTime <=free.EndTime)
                        {
                            return;
                        }
                        if(freeTime.StartTime<=free.EndTime && freeTime.EndTime > free.EndTime)
                        {
                            free.EndTime = freeTime.EndTime;
                            data.Update(free);
                            return;
                        }
                        if(freeTime.StartTime<free.StartTime && freeTime.EndTime >= free.StartTime)
                        {
                            free.StartTime = freeTime.StartTime;
                            data.Update(free);
                            return;
                        }
                    }
                    Label lblMensaje = new Label();
                    lblMensaje.IsVisible = true;
                    data.Insert(freeTime);
                    data.Dispose();
                }
            }
            catch (Exception e)
            {
                DisplayAlert("Error", e.Message, "aceptar");
            }


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
            lblDays.Text = arrayDays2[day];
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
            lblDays.Text = arrayDays2[day];
            ResetTime();
        }

        public void ResetTime ()
        {
            StartTime.Time = new TimeSpan(0);
            EndTime.Time = new TimeSpan(0);
        }

        public void Done()
        {
            Navigation.PopModalAsync();
        }
	}
}