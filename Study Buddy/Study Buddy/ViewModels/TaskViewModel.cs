using System;
using System.Collections.Generic;

using System.Windows.Input;
using StudyBuddy.Models;
using Study_Buddy.Views;

using Xamarin.Forms;

namespace Study_Buddy.ViewModels
{
    class TaskViewModel : BaseViewModel{
        public List<Tasks> TaskItems { get; private set; }
        public ICommand ExpandCommand { get; private set; }

        public bool IsExpanded { get; set; }
        public string Message { get; private set; }

        public Command AddTaskCommand { get; }
        
        public TaskViewModel()
        {
            Title = "Tasks";
            CreateTaskCollection();
            ExpandCommand = new Command<Tasks>(Expand);
            IsExpanded = true;
            AddTaskCommand = new Command(AddTask);
        }

        void Expand(Tasks item)
        {
            Message = $"{item.TaskGroup} tapped.";
            OnPropertyChanged("Message");
        }

        void CreateTaskCollection()
        {
            TaskItems = new List<Tasks>();
            TaskItems.Add(new Tasks
            {
                Id = Guid.NewGuid().ToString(),
                TaskGroup = "Group 1",
                BackgroundColor = "Red",
                TextColor = "Black",
                Task1Name = "Task1",
                Task1Complete = false,
                Task2Name = "Task2",
                Task2Complete = true,
                Task3Name = "Task3",
                Task3Complete = false,
                Task4Name = "Task4",
                Task4Complete = true,
                Task5Name = "Task5",
                Task5Complete = false
            });
            TaskItems.Add(new Tasks
            {
                Id = Guid.NewGuid().ToString(),
                TaskGroup = "Group 2",
                BackgroundColor = "Blue",
                TextColor = "Black",
                Task1Name = "Task1",
                Task1Complete = false,
                Task2Name = "Task2",
                Task2Complete = true,
                Task3Name = "Task3",
                Task3Complete = false,
                Task4Name = "Task4",
                Task4Complete = true,
                Task5Name = "Task5",
                Task5Complete = false
            });
            TaskItems.Add(new Tasks
            {
                Id = Guid.NewGuid().ToString(),
                TaskGroup = "Group 3",
                BackgroundColor = "Green",
                TextColor = "Black",
                Task1Name = "Task1",
                Task1Complete = false,
                Task2Name = "Task2",
                Task2Complete = true,
                Task3Name = "Task3",
                Task3Complete = false,
                Task4Name = "Task4",
                Task4Complete = true,
                Task5Name = "Task5",
                Task5Complete = false
            });
        }

        private async void AddTask(object obj)
        {
            await Shell.Current.GoToAsync(nameof(TaskPlanPage));
            /*await Shell.Current.GoToAsync(nameof(TaskPlanningPage));*/
        }
    }
}
