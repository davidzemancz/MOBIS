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
    public partial class Menu : TabbedPage
    {
        public Menu()
        {
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetTitleIconImageSource(this, "Resources.drawable.icon_about.png");

            NavigationPage ucet = new NavigationPage(new Ucet());
            ucet.IconImageSource = "schedule.png";
            ucet.Title = "Účet";

            NavigationPage informace = new NavigationPage(new Novinky());
            informace.IconImageSource = "schedule.png";
            informace.Title = "Novinky";

            NavigationPage novinky = new NavigationPage(new Informace());
            novinky.IconImageSource = "schedule.png";
            novinky.Title = "Informace";


            Children.Add(informace);
            Children.Add(novinky);
            Children.Add(ucet);
        }
    }
}