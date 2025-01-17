﻿using System;
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
        public bool language = false;
        public Ucet()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new ViewModels.UcetViewModel();
            YourLableID.Text = Models.User.Current.Id.ToString();
            YourLableID.FontSize = 16;
            YourLableEmail.Text = Models.User.Current.Email.ToString();
            YourLableEmail.FontSize = 16; 
            YourLablePracoviste.Text = Models.User.Current.Workplace.ToString();
            YourLablePracoviste.FontSize = 16;
            YourLableRole.Text = Models.User.Current.Role.ToString();
            YourLableRole.FontSize = 16;
        }
        public void ChangeFlags(object sender, EventArgs e)
        {
            language = !language;
            if (language == true) { flag.Source = "czflag.gif"; heslo.Text = "Password change"; }
            else { flag.Source = "ukflag.gif"; heslo.Text = "Změna hesla"; }
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