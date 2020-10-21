using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Study_Buddy.Models;
using Study_Buddy.Views;
using Study_Buddy.ViewModels;

namespace Study_Buddy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskPage : ContentPage
    {
        TaskViewModel _viewModel;
        public TaskPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TaskViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
           _viewModel.OnAppearing();
        }
    }
}