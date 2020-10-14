using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Study_Buddy.Models;
using Study_Buddy.Views;
using Study_Buddy.Services;
using Xamarin.Forms;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Study_Buddy.ViewModels
{
    public class TaskViewModel : BaseViewModel{
        public ObservableCollection<Tasks> TaskItems { get; private set; }
        public ICommand ExpandCommand { get; private set; }
        public bool IsExpanded { get; set; }
        public string Message { get; private set; }
        private Tasks _SelectedTask;

        public Command AddTaskCommand { get; }
        public Command LoadTasksCommand { get; }
        
        public TaskViewModel()
        {
            Title = "Tasks";
            TaskItems = new ObservableCollection<Tasks>();
            ExpandCommand = new Command<Tasks>(Expand);
            IsExpanded = true;
            AddTaskCommand = new Command(AddTask);
            LoadTasksCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            Console.WriteLine("WRITING TO SCREEN");
            IsBusy = true;

            try
            {
                TaskItems.Clear();
                var tasks = await TaskDataStore.GetItemsAsync(true);
                foreach (var item in tasks)
                {
                    TaskItems.Add(item);
                    Console.WriteLine("{0}, {1}", item.Id, item.TaskGroup);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            _SelectedTask = null;
        }

        void Expand(Tasks item)
        {
            Message = $"{item.TaskGroup} tapped.";
            OnPropertyChanged("Message");
        } 

        private async void AddTask(object obj)
        {
            await Shell.Current.GoToAsync(nameof(TaskPlanPage));
        }
    }
}
