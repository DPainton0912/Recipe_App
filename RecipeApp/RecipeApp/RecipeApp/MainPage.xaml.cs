using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using RecipeApp.Models;

namespace RecipeApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetRecipeAsync();
        }

        private async void OnRecipeAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecipeEntryPage
            {
                BindingContext = new Recipe()
            });
        }

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new RecipeEntryPage
                {
                    BindingContext = e.SelectedItem as Recipe
                });
            }
        }
    }
}
