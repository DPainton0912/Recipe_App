using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RecipeApp.Models;

namespace RecipeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeEntryPage : ContentPage
    {
        public RecipeEntryPage()
        {
            InitializeComponent();
        }

        private async void SaveButtonClicked(object sender, EventArgs e)
        {
            var recipe = (Recipe)BindingContext;
            await App.Database.SaveRecipeAsync(recipe);
            await Navigation.PopAsync();
        }

        private async void DeleteButtonClicked(object sender, EventArgs e)
        {
            var recipe = (Recipe)BindingContext;
            await App.Database.DeleteRecipeAsync(recipe);
            await Navigation.PopAsync();
        }
    }
}