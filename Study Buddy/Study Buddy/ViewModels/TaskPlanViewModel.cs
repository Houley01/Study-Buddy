using System;
using System.Windows.Input;
using Xamarin.Essentials;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

using Study_Buddy.Models;
using Study_Buddy.Views;
using StudyBuddy.Models;

namespace Study_Buddy.ViewModels
{
    public class TaskPlanViewModel : BaseViewModel
    {
        private string heading;
        private string task1;
        private string task2;
        private string task3;
        private string task4;
        private string task5;
        private Color headingColor;
        private string date;       


        public Command ColourPickerCommand { get; }
        public TaskPlanViewModel()
        {
            Title = "Task Planning";

            ColourPickerCommand = new Command(ColourPicker);
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();

        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public string Heading
        {
            get => heading;
            set => SetProperty(ref heading, value);
        }

        public string Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        public string Task1
        {
            get => task1;
            set => SetProperty(ref task1, value);
        }

        public string Task2
        {
            get => task2;
            set => SetProperty(ref task2, value);
        }

        public string Task3
        {
            get => task3;
            set => SetProperty(ref task3, value);
        }

        public string Task4
        {
            get => task4;
            set => SetProperty(ref task4, value);
        }

        public string Task5
        {
            get => task5;
            set => SetProperty(ref task5, value);
        }

        public Color HeadingColor
        {
            get => headingColor;
            set => SetProperty(ref headingColor, value);
        }

        private bool ValidateSave()
        {
            return (!String.IsNullOrWhiteSpace(Heading) &
                !String.IsNullOrWhiteSpace(Task1) &
                !String.IsNullOrWhiteSpace(Task2) &
                !String.IsNullOrWhiteSpace(Task3) &
                !String.IsNullOrWhiteSpace(Task4) &
                !String.IsNullOrWhiteSpace(Task5) &
                !String.IsNullOrWhiteSpace(Date)
                );


        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Tasks newItem = new Tasks()
            {
                Id = Guid.NewGuid().ToString(),
                TaskGroup = heading,
                BackgroundColor = headingColor.ToString(),
                Task1Name = task1,
                Task1Complete = false,
                Task2Name = task2,
                Task2Complete = false,
                Task3Name = task3,
                Task3Complete = false,
                Task4Name = task4,
                Task4Complete = false,
                Task5Name = task5,
                Task5Complete = false,
                Date = date.Substring(0,10)

            };

            await TaskDataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
            Console.WriteLine("{0}", date.Substring(0, 10));
        }

        public async void ColourPicker()
        {
            await Shell.Current.GoToAsync(nameof(ColourPickerPage));
        }
    }
}