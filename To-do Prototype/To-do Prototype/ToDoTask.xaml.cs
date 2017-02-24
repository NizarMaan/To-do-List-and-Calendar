using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace To_do_Prototype
{
    /// <summary>
    /// Interaction logic for ToDoTask.xaml
    /// </summary>
    public partial class ToDoTask : UserControl
    {
        private string taskTitle;
        private string description;
        private string dueDate;
        public bool selectedEdit=false;
        
        public string TaskTitle            
        {
            get { return taskTitle; }
            set { taskTitle = value;
            lblTaskTitle.Content = taskTitle;
                
            
            }
        }
        public string DueDate
        {
            get { return dueDate; }
            set
            {
                dueDate = value;
                //lblDueDate.Content = this.dueDate;

                if (value == "")
                {
                    lblDueDate.Content = "";
                }
                else
                {
                    lblDueDate.Content = "Due: " + this.dueDate;
                }
               
            }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public ToDoTask()
        {            
            InitializeComponent();
        }
    

        private void lblTaskTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedEdit = true;
        }

        private void ckbCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            this.lblStrikeOutLine.Visibility = Visibility.Visible;
            foreach (Task task in Task.allTasks)
            {
                if (task.TaskName == this.taskTitle)
                {
                    task.Complete = true;
                    task.CompletedDate = DateTime.Now;
                }               
            }
        }

        private void ckbCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.lblStrikeOutLine.Visibility = Visibility.Hidden;
            foreach (Task task in Task.allTasks)
            {
                if (task.TaskName == this.taskTitle)
                {
                    task.Complete = false;
                    task.CompletedDate = new DateTime();
                }
            }
        }
       
        
    }
}
