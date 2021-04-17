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
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new ViewModels.UcetViewModel();
            YourLableID.Text = Models.User.Current.Id.ToString();
            YourLableEmail.Text = Models.User.Current.Email.ToString();
            YourLablePracoviste.Text = Models.User.Current.Workplace.ToString();
            YourLableRole.Text = Models.User.Current.Role.ToString();
        }

         async void ZmenaHeslaAsync(object sender, EventArgs args)
        {
            string noveHeslo = await DisplayPromptAsync("Změna hesla", "Nové heslo");
            if (noveHeslo != "" && noveHeslo != null)
            {
                await DisplayAlert("Oznámeni", "Heslo bylo úspěšně změněno", "OK");
            }
        }
    }
}