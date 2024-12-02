using System;

namespace TaskManagement.Model
{
    public class TaskModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}, Description: {Description}, DueDate: {DueDate.ToShortDateString() ?? "N/A"}, Priority: {Priority}";
        }
    }

}
