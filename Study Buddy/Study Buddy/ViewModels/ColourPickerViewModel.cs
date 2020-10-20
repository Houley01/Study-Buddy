using System;
using System.Collections.Generic;
using System.Text;
using Study_Buddy.Models;
using Xamarin.Forms;
using System.Diagnostics;

namespace Study_Buddy.ViewModels
{
    class ColourPickerViewModel : BaseViewModel
    {
        /*private Color selectedColor;*/
        public Command SelectColourCommand { get; }
        public Command CancelCommand { get; }
        public ColourPickerViewModel()
        {
            Title = "Colour Picker";
            SelectColourCommand = new Command(OnSelect);
            CancelCommand = new Command(OnCancel);
        }

     /*   public Color GetColor
        {
            get => selectedColor;
            set => SetProperty(ref selectedColor, value);
        }*/

        
        
        private async void OnCancel()
        {
            Debug.WriteLine("CANCEL");
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSelect()
        {

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
