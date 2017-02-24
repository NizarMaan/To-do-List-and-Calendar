using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_do_Prototype
{
    class Task
    {
        public static List<Task> allTasks = new List<Task>();
        private string taskName;
        private string taskDescription;
        private DateTimeOffset dueDate;
        private string category;
        private string priority;
        private bool complete;
        private DateTimeOffset completedDate;
        
        
        public Task()
        {

        }
        public Task(string name, string description, DateTime due, string category, string priority)
        {
            this.taskName = name;
            this.taskDescription = description;
            this.dueDate = due;
            this.category = category;
            this.priority = priority;
            this.complete = false;           

        }
        public Task(string name, string description, DateTime due, string category, string priority, DateTime completeDate)
        {
            this.taskName = name;
            this.taskDescription = description;
            this.dueDate = due;
            this.category = category;
            this.priority = priority;
            this.complete = true;
            this.completedDate = completeDate;

        }
        public string TaskName
        {
            get { return taskName; }
            set { taskName = value; }
        }
        public DateTimeOffset DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public string Priority
        {
            get { return priority; }
            set { priority = value; }
        }
        public bool Complete
        {
            get { return complete; }
            set { complete = value; }
        }
        public DateTimeOffset CompletedDate
        {
            get { return completedDate; }
            set { completedDate = value; }
        }
        
      
    }
}
