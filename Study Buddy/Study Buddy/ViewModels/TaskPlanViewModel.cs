using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

using Study_Buddy.Models;
using Study_Buddy.Views;

namespace Study_Buddy.ViewModels
{
    public class TaskPlanViewModel : BaseViewModel
    {
        public Command ColourPickerCommand { get; }
        public TaskPlanViewModel()
        {
            Title = "Task Planning";

            ColourPickerCommand = new Command(ColourPicker);
            
        }
        /*public Command SaveCommand { get; }
        public Command CancelCommand { get; }*/
        

        public async void ColourPicker()
        {
            await Shell.Current.GoToAsync(nameof(ColourPickerPage));
        }
    }
}