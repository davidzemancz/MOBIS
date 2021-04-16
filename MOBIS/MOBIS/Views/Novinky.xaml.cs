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
            this.BindingContext = new ViewModels.NovinkyViewModel();

            this.NovinkyListView.ItemsSource = this.Papers;

            string jsonOutData = RestApi.Post("content/list", "", out bool ok);
            var data = JsonSerializer.Deserialize<Paper[]>(jsonOutData);
            foreach (var paper in data)
            {
                this.Papers.Add(paper);
            }
            CrossLocalNotifications.Current.Show("Nove zpravy z vasi oblibene firmy", "hura! :)");
        }
    }
}