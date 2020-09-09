using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using StudyBuddy.Models;
using Xamarin.Forms;

namespace Study_Buddy.ViewModels
{
    class TaskViewModel : BaseViewModel{
        public List<Tasks> TaskItems { get; private set; }
        public ICommand ExpandCommand { get; private set; }

        public bool IsExpanded { get; set; }
        public string Message { get; private set; }

        public TaskViewModel()
        {
            Title = "Tasks";
            CreateTaskCollection();
            ExpandCommand = new Command<Tasks>(Expand);
            IsExpanded = true;
        }
        void Expand(Tasks item)
        {
            Message = $"{item.Name} tapped.";
            OnPropertyChanged("Message");
        }

        void CreateTaskCollection()
        {
            TaskItems = new List<Tasks>();
            TaskItems.Add(new Tasks
            {
                Id = Guid.NewGuid().ToString(),
                TaskGroup = "Group 1",
                Name = "Task1",
                Complete = false
            });
            TaskItems.Add(new Tasks
            {
                Id = Guid.NewGuid().ToString(),
                TaskGroup = "Group 2",
                Name = "Task2",
                Complete = true
            });
            TaskItems.Add(new Tasks
            {
                Id = Guid.NewGuid().ToString(),
                TaskGroup = "Group 3",
                Name = "Task 3",
                Complete = false
            });
        }

        
    }
}
