﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MOBIS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Novinky : ContentPage
    {
        public Novinky()
        {
            InitializeComponent();
            this.BindingContext = new ViewModels.NovinkyViewModel();
        }
    }
}