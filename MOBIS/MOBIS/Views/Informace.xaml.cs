using MOBIS.API;
using MOBIS.Models;
using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MOBIS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Informace : ContentPage
    {

        public ObservableCollection<Paper> Papers { get; set; } = new ObservableCollection<Paper>();

        public Informace()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new ViewModels.InformaceViewModel();

            this.NovinkyListView.ItemsSource = this.Papers;

            string jsonInData = "{ \"UserId\":" + User.Current.Id + ",\"Type\":2}"; //jednicka pro novinky, 2 pro informace
            string jsonOutData = RestApi.Post("content/list", jsonInData, out bool ok);
            var data = JsonSerializer.Deserialize<Paper[]>(jsonOutData);
            foreach (var paper in data)
            {
                this.Papers.Add(paper);
            }
            CrossLocalNotifications.Current.Show("Nove zpravy z vasi oblibene firmy", "hura! :)");
        }

        void cist_vice(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Reader(((Button)sender).CommandParameter.ToString()));
        }
    }
}