using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using TaskManagement.Commands;
using TaskManagement.Model;
using TaskManagement.View;

namespace TaskManagement.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }

        public ICommand ShowWindowCommand { get; set; }
        public ICommand DeleteTaskCommand { get; set; }
        public ICommand FilterCommand { get; set; }

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
        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading)); 
            }
        }
        private TaskModel _selectedTask;
        public TaskModel SelectedTask
        {
            get => _selectedTask;
            set
            {
                _selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }

        public ObservableCollection<string> PriorityList { get; set; }
        private string _selectedPriority;
        public string SelectedPriority
        {
            get => _selectedPriority;
            set
            {
                _selectedPriority = value;
                OnPropertyChanged(nameof(SelectedPriority));
                FilterTasks();
            }
        }

        public ObservableCollection<string> SortList { get; set; }

        private string _sortOption;
        public string SortOption
        {
            get => _sortOption;
            set
            {
                _sortOption = value;
                OnPropertyChanged(nameof(SortOption));
                SortTasks(); 
            }
        }
        private DispatcherTimer _timer;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {

          
                Tasks = TaskManagerModel.GetTasks(); 
            
            PriorityList = new ObservableCollection<string> { "All", "High", "Medium", "Low" };
            SelectedPriority = "All";

            SortList = new ObservableCollection<string> { "Sort By Title", "Sort By DueDate" };
            SortOption = "Sort By Title";

            ShowWindowCommand = new RelayCommand(ShowWindow);
            DeleteTaskCommand = new RelayCommand(DeleteSelectedTask);
            FilterCommand = new RelayCommand(_ => FilterTasks());
            
        }

      

    

        private void ShowWindow(object obj)
        {
            AddTask addTaskWindow = new AddTask
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            addTaskWindow.ShowDialog();
        }

        private async void DeleteSelectedTask(object parameter)
        {
            if (parameter is TaskModel selectedTask && Tasks.Contains(selectedTask))
            {
                try
                {
                    IsLoading = true;
                    await Task.Delay(1000);
                    await Task.Run(() =>
                    {
                        TaskManagerModel.DeleteTask(selectedTask);
                       
                    });
                    Tasks.Remove(selectedTask);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Delete Task", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    IsLoading = false;
                }
            }
        }

        private async Task FilterTasks()
        {
            try
            {
                IsLoading = true;
                await Task.Delay(500);
                await Task.Run(() =>
                {
                    if (SelectedPriority == "All")
                    {
                       
                            Tasks = TaskManagerModel.GetTasks();
                        
                    }
                    else
                    {
                        Tasks = TaskManagerModel.GetTasksByPriority(SelectedPriority);
                    }
                });
                await SortTasks(); 
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task SortTasks()
        {
            try
            {
                IsLoading = true;
                await Task.Delay(500); // Simulated delay for sorting

                if (Tasks != null && Tasks.Any())
                {
                    // Sort the tasks only if Tasks is not null and contains data
                    if (SortOption == "Sort By DueDate")
                    {
                        Tasks = new ObservableCollection<TaskModel>(Tasks.OrderBy(task => task.DueDate));
                    }
                    else if (SortOption == "Sort By Title")
                    {
                        Tasks = new ObservableCollection<TaskModel>(Tasks.OrderBy(task => task.Title));
                    }
                }
                else
                {
                    // Optionally, handle the case where there are no tasks
                    MessageBox.Show("No tasks available to sort.", "Sorting Error", MessageBoxButton.OK, MessageBoxImage.Information);
                }
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
