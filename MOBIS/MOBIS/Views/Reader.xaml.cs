using MOBIS.API;
using MOBIS.Models;
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
    public partial class Reader : ContentPage
    {
        public Reader(string id)
        {
            InitializeComponent();
            read_message(id);
            this.BindingContext = new ViewModels.UcetViewModel();
        }

      
        private void read_message(string id)
        {
            string jsonInData = "{ \"Id\":" + id + "}";
            string jsonOutData = RestApi.Post("content/load", jsonInData, out bool ok); 
            var data = JsonSerializer.Deserialize<Paper>(jsonOutData);
            Zprava.Text = data.ContentText;
        }
    }
}