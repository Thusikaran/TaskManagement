using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TaskManagement.Commands;
using TaskManagement.Model;

namespace TaskManagement.ViewModel
{
    public class AddTaskViewModel : INotifyPropertyChanged
    {
        public ICommand AddTaskCommand { get; }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Priority { get; set; }

        public Action CloseAction { get; set; }

        public ObservableCollection<string> PriorityList { get; set; }

        private ObservableCollection<TaskModel> _tasks;
        public ObservableCollection<TaskModel> Tasks
        {
            get => _tasks;
            set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AddTaskViewModel()
        {
            AddTaskCommand = new RelayCommand(AddTask, CanAddTask);
            PriorityList = new ObservableCollection<string> { "High", "Medium", "Low" };
            Priority = "Medium";
          
                Tasks =TaskManagerModel.GetTasks(); 
            
        }

        private bool CanAddTask(object obj)
        {
            return !string.IsNullOrWhiteSpace(Title) && DueDate.HasValue;
        }

        private async void AddTask(object parameter)
        {
            try
            {
                IsLoading = true; 
                
                await TaskManagerModel.AddTaskAsync(new TaskModel
                {
                    Title = Title,
                    Description = Description,
                    DueDate = DueDate ?? DateTime.Now,
                    Priority = Priority
                });


                CloseAction?.Invoke(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Add Task Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsLoading = false; 
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
