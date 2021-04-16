using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MOBIS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ucet : ContentPage
    {
        public Ucet()
        {
            InitializeComponent();
            this.BindingContext = new ViewModels.UcetViewModel();
            YourLableID.Text = "ID: " +  Models.User.soucastny_user.Id.ToString();
            YourLableEmail.Text = "Email: " + Models.User.soucastny_user.Email.ToString();
            YourLablePracoviste.Text = "Pracoviste: " + Models.User.soucastny_user.Workplace.ToString();
            YourLableRole.Text = "Pozice: " + Models.User.soucastny_user.Role.ToString();
        }

         async void ZmenaHeslaAsync(object sender, EventArgs args)
        {
            string noveHeslo = await DisplayPromptAsync("Zmena Hesla", "Nove heslo");
            if (noveHeslo != "" && noveHeslo != null)
            {
                await DisplayAlert("Oznameni", "Heslo bylo uspesne zmeneno", "OK");
            }

        }
    }
}