using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Study_Buddy.Models;

namespace Study_Buddy.Services
{
    public class TaskDataStore : ITaskDataStore<Tasks>
    {
        readonly List<Tasks> taskItems;

        public TaskDataStore()
        {
            taskItems = new List<Tasks>() {
                new Tasks {
                    Id = Guid.NewGuid().ToString(), TaskGroup = "Group 1", BackgroundColor = "Red",
                    Task1Name = "Task1", Task1Complete = false, Task2Name = "Task2", Task2Complete = true,
                    Task3Name = "Task3", Task3Complete = false, Task4Name = "Task4", Task4Complete = true,
                    Task5Name = "Task5", Task5Complete = false },
                new Tasks {
                    Id = Guid.NewGuid().ToString(), TaskGroup = "Group 2", BackgroundColor = "Green",
                    Task1Name = "Task1", Task1Complete = false, Task2Name = "Task2", Task2Complete = true,
                    Task3Name = "Task3", Task3Complete = false, Task4Name = "Task4", Task4Complete = true,
                    Task5Name = "Task5", Task5Complete = false },
                new Tasks {
                    Id = Guid.NewGuid().ToString(), TaskGroup = "Group 3", BackgroundColor = "Blue",
                    Task1Name = "Task1", Task1Complete = false, Task2Name = "Task2", Task2Complete = true,
                    Task3Name = "Task3", Task3Complete = false, Task4Name = "Task4", Task4Complete = true,
                    Task5Name = "Task5", Task5Complete = false}
            };
        }
        public async Task<bool> AddItemAsync(Tasks item)
        {
            taskItems.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Tasks item)
        {
            var oldItem = taskItems.Where((Tasks arg) => arg.Id == item.Id).FirstOrDefault();
            taskItems.Remove(oldItem);
            taskItems.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = taskItems.Where((Tasks arg) => arg.Id == id).FirstOrDefault();
            taskItems.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Tasks> GetItemAsync(string id)
        {
            return await Task.FromResult(taskItems.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Tasks>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(taskItems);
        }
    }
}
