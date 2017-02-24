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
    /// Interaction logic for WeeklyTaskInsert.xaml
    /// </summary>
    public partial class WeeklyTaskInsert : UserControl
    {
        private string taskTitle;
        
        //private WeeklyView reference;

        public string TaskTitle
        {
            get { return taskTitle; }
            set
            {
                taskTitle = value;
                taskName.Text = this.taskTitle;
                taskNameStriked.Text = this.taskTitle;
            }
        }

        //public void WeeklyViewReference(WeeklyView reference)
        //{
        //    this.reference = reference;
        //    //reference.PointsText.Content = "asdada";
        //}
        public WeeklyTaskInsert()
        {
            InitializeComponent();
            taskNameStriked.TextDecorations = TextDecorations.Strikethrough;
            taskNameStriked.Visibility = Visibility.Hidden;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //reference.AddPoints();
            //selectable = false;
            taskNameStriked.Visibility = Visibility.Visible;
            taskName.Visibility = Visibility.Hidden;
            foreach (Task task in Task.allTasks)
            {
                if (task.TaskName == this.taskTitle)
                {
                    if (task.Complete == false)
                    {
                        task.Complete = true;
                        task.CompletedDate = DateTime.Now;
                    }
                    
                }
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //selectable = true;
            taskNameStriked.Visibility = Visibility.Hidden;
            taskName.Visibility = Visibility.Visible;
            foreach (Task task in Task.allTasks)
            {
                if (task.TaskName == this.taskTitle)
                {
                    if (task.Complete == true)
                    {
                        task.Complete = false;
                        task.CompletedDate = new DateTime();
                    }
                }
            }
        }
    }
}
