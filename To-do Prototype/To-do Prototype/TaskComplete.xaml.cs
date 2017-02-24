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
    /// Interaction logic for TaskComplete.xaml
    /// </summary>
    public partial class TaskComplete : UserControl
    {
        HomeScreen homeScreen = new HomeScreen();
        private string taskTitle;
        private int points;
        public string TaskTitle
        {
            get { return taskTitle; }
            set
            {
                taskTitle = value;
                lblTaskName.Content = taskTitle;
            }
        }
        public int Points
        {
            get { return points; }
            set
            {
                points = value;
                lblPoints.Content = "+" + points + " point(s)";
            }
        }
        public TaskComplete()
        {
            InitializeComponent();
        }

        //private void CompleteTask(object sender, MouseButtonEventArgs e)
        //{
        //    homeScreen.FakeCompleted();
        //    homeScreen.UserPoints = homeScreen.UserPoints + 10;
        //    ((Panel)this.Parent).Children.Add(homeScreen);
        //    ((Panel)this.Parent).Children.Remove(this);
        //}

        private void UndoComplete(object sender, MouseButtonEventArgs e)
        {
            homeScreen.FakeUndoComplete();
            ((Panel)this.Parent).Children.Add(homeScreen);
            ((Panel)this.Parent).Children.Remove(this);
        }
    }
}
