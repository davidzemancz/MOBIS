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
        private string _id;

        public Reader(string id)
        {
            InitializeComponent();
            this._id = id;
            read_message();
            this.BindingContext = new ViewModels.UcetViewModel();
        }

        public Reader(string id, bool edit)
        {

            InitializeComponent();
            this._id = id;
            edit_message();
            Save_button.IsVisible = true;
            Save_button.IsEnabled = true;
            this.BindingContext = new ViewModels.UcetViewModel();
        }

        private void edit_message()
        {
            string jsonInData = "{ \"Id\":" + this._id + "}";
            string jsonOutData = RestApi.Post("content/load", jsonInData, out bool ok);
            var data = JsonSerializer.Deserialize<Paper>(jsonOutData);
            Editovatelna_zprava.Text = data.ContentText;
            Editovatelna_zprava.IsVisible = true;
            Title = data.Date + " " + data.Title;
        }


        private void read_message()
        {
            string jsonInData = "{ \"Id\":" + this._id + "}";
            string jsonOutData = RestApi.Post("content/load", jsonInData, out bool ok); 
            var data = JsonSerializer.Deserialize<Paper>(jsonOutData);
            Zprava.Text = data.ContentText;
            Title = data.Date + " " + data.Title;
        }

        private void save_message(object sender, EventArgs args)
        {
            //poslat zpatky text s id zpravy na server ktery ji pushne ostatnim modifikovanou
            string jsonInData = "{ \"Id\":" + this._id + ", \"ContentText\": \"" + this.Editovatelna_zprava.Text + "\"}";
            string jsonOutData = RestApi.Post("content/update", jsonInData, out bool ok);

        }
    }
}