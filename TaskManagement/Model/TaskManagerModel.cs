    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
using System.Windows;

namespace TaskManagement.Model
    {

        internal class TaskManagerModel 
        {

            public static ObservableCollection<TaskModel> _DatabaseUsers = new ObservableCollection<TaskModel>() {
                    new TaskModel { Title = "Task 1", Description = "First task", DueDate = DateTime.Now.AddDays(1), Priority = "High" },
                    new TaskModel { Title = "Task 2", Description = "Second task", DueDate = DateTime.Now.AddDays(2), Priority = "Medium" },
                    new TaskModel { Title = "Task 3", Description = "Third task", DueDate = DateTime.Now.AddDays(3), Priority = "Low" } };

            public static ObservableCollection<TaskModel> GetTasks()
            {
                return _DatabaseUsers;

            }


             public static async Task AddTaskAsync(TaskModel task)
            {
                await Task.Delay(1000);
                _DatabaseUsers.Add(task);

            }

        public static void DeleteTask(TaskModel task)
        {
            if (Application.Current.Dispatcher.CheckAccess())
            {
                if (_DatabaseUsers.Contains(task))
                {
                    _DatabaseUsers.Remove(task);
                }
            }
            else
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    if (_DatabaseUsers.Contains(task))
                    {
                        _DatabaseUsers.Remove(task);
                    }
                });
            }
        }


        public static ObservableCollection<TaskModel> GetTasksByPriority(string priority)
            {
                var filteredTasks = _DatabaseUsers.Where(task => task.Priority.Equals(priority, StringComparison.OrdinalIgnoreCase)).ToList();
                return new ObservableCollection<TaskModel>(filteredTasks);
            }

      
        }
    
    }
