using System;
using System.Windows;
using TaskManagement.ViewModel;

namespace TaskManagement.View
{
    public partial class AddTask : Window
    {
        public AddTask()
        {
            InitializeComponent();
            var viewModel = new AddTaskViewModel();
             viewModel.CloseAction = Close; 
            this.DataContext = viewModel;
        }
    }
}
