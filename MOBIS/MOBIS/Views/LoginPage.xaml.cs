using MOBIS.API;
using MOBIS.Models;
using MOBIS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MOBIS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        void TryToLogin(object sender, EventArgs args)
        {
            
            User user = new User("pepazdepa@mail.cz", "mamradmekac");
            string jsonInData = JsonSerializer.Serialize(user);
            string jsonOutData = RestApi.Post("user/login", jsonInData, out bool ok);
            if (ok)
            {
                user = JsonSerializer.Deserialize<User>(jsonOutData);
                if (user.Exists)
                {
                    // Uzivatel existuje
                    Console.WriteLine("Id: " + user.Id);
                    Console.WriteLine("Key: " + user.Key);
                    Console.WriteLine("E-mail: " + user.Email);
                    Navigation.PushAsync(new Zpravy());
                }
                else
                {
                    // Uzivatel neexistuje
                    DisplayAlert("CHYBA?", "SPATNE JMENO NEBO HESLO", "OK");
                }
            }
            else
            {
                throw new Exception("Připojení se nezdařilo.");
            }
        }
    }
}