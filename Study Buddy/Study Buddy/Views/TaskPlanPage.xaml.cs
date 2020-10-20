using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Study_Buddy.Models;
using Study_Buddy.Views;
using Study_Buddy.ViewModels;

namespace Study_Buddy.Views
{
    public partial class TaskPlanPage : ContentPage
    {
        /*ItemsViewModel _viewModel;*/

        public TaskPlanPage()
        {
            InitializeComponent();
            /*UserColour selected = new UserColour();
            selected.Picked = Color.FromRgb(255, 255, 255);*/
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}