using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MOBIS.API;
using MOBIS.Models;
using MOBIS.ViewModels;
using Plugin.LocalNotifications;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MOBIS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Novinky : ContentPage
    {
        public ObservableCollection<Paper> Papers { get; set; } = new ObservableCollection<Paper>();
        
        public Novinky()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new ViewModels.NovinkyViewModel();
            this.NovinkyListView.ItemsSource = this.Papers;

        }

        void cist_vice(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Reader(((Button)sender).CommandParameter.ToString()));
        }
         
        private void Edit(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Reader(((Button)sender).CommandParameter.ToString(),true));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.Papers.Clear();
            string jsonInData = "{ \"UserId\":" + User.Current.Id + ",\"Type\":\"Novinky\"}"; //jednicka pro novinky, 2 pro informace
            string jsonOutData = RestApi.Post("content/list", jsonInData, out bool ok);
            var data = JsonSerializer.Deserialize<Paper[]>(jsonOutData);
            foreach (var paper in data.Reverse())
            {
                this.Papers.Add(paper);
            }
            CrossLocalNotifications.Current.Show("Nove zprávy z vaší oblíbene firmy", "hurá! :)");

        }
    }
}