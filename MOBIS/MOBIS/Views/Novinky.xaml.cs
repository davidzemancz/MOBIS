using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOBIS.Models;
using MOBIS.ViewModels;
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
            this.Papers.Add(new Paper(){Title = "Dita"});

        }
    }
}