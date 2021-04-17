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
    public partial class Informace : ContentPage
    {
        public Informace()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new ViewModels.InformaceViewModel();
        }
    }
}