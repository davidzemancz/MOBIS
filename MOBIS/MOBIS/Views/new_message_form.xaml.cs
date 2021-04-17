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
    public partial class new_message_form : ContentPage
    {
        public new_message_form()
        {
            InitializeComponent();
        }

        public void parseText(object sender, EventArgs args)
        {
            string date = Datum.Text;
            string autor = Autor.Text;
            string id = "0";
            string titul = Titulek.Text;
            string zprava = Zprava.Text;
        }
    }
}