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
            this.BindingContext = new ViewModels.InformaceViewModel();
        }
    }
}