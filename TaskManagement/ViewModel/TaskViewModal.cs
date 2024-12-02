using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TaskManagement.Model;

namespace TaskManagement.ViewModel
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TaskModel> _taskList;

        public ObservableCollection<TaskModel> TaskList
        {
            get { return _taskList; }
            set
            {
                _taskList = value;
                OnPropertyChanged(nameof(TaskList));
            }
        }

        public TaskViewModel()
        {
            TaskList = new ObservableCollection<TaskModel>
            {
                new TaskModel { Title = "Task 1", Description = "First task", DueDate = DateTime.Now.AddDays(1), Priority = "High" },
                new TaskModel { Title = "Task 2", Description = "Second task", DueDate = DateTime.Now.AddDays(2), Priority = "Medium" },
                new TaskModel { Title = "Task 3", Description = "Third task", DueDate = DateTime.Now.AddDays(3), Priority = "Low" }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
