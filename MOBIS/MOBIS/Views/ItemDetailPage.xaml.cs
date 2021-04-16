using MOBIS.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MOBIS.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}