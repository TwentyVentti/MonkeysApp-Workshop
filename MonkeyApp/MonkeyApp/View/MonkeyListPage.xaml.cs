﻿using MonkeyApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MonkeyApp.View
{
    public partial class MonkeyListPage : ContentPage
    {
        MonkeyListViewModel vm;
        public MonkeyListPage()
        {
            InitializeComponent();

            vm = new MonkeyListViewModel();
            BindingContext = vm;

            ButtonGetMonkeys.Clicked += async (sender, args) =>
            {
                ButtonGetMonkeys.IsEnabled = false;

                Exception ex = null;

                try
                {
                    await vm.GetMonkeysAsync();
                }
                catch (Exception e)
                {
                    ex = e;
                }

                if (ex != null)
                {
                    await DisplayAlert("Error", "Unable to get monkeys: " + ex.Message, "OK");
                }

                ButtonGetMonkeys.IsEnabled = true;

            };

        }
    }
}