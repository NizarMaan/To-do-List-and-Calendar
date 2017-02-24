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
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : UserControl
    {
        private static List<string> taskList = new List<string>();
        
       
       // private static int userPoints;
        //public int UserPoints
        //{
        //    get { return userPoints; }
        //    set
        //    {
        //        userPoints = value;
        //        PointsText.Content = "Points: " + userPoints;
        //    }
        //}
        //TaskInfoScreen taskScreen = new TaskInfoScreen();
        public HomeScreen()
        {
            InitializeComponent();
            showWeeklyView();
            
            
        }
        private void showWeeklyView()
        {
            WeeklyView weeklyView = new WeeklyView();
            weeklyView.Itself(weeklyView);
            weeklyView.populateTasks();
            TaskSection.Children.Clear();
            TaskSection.Children.Add(weeklyView);
        }

        private void AddNewTask(object sender, MouseButtonEventArgs e)
        {
            TaskInfoScreen taskScreen = new TaskInfoScreen();
            taskScreen.Header = "Add New Task";
            ((Panel)this.Parent).Children.Add(taskScreen);
            ((Panel)this.Parent).Children.Remove(this);
            
            //taskScreen.Header = "Add New Task";            
            //((Panel)this.Parent).Children.Add(taskScreen);
            
        }
        
        private void PopulateTasks()
        {            
            this.TaskSection.Children.Clear();
            foreach (Task task in Task.allTasks)
            {
                ToDoTask newTask = new ToDoTask();
                newTask.TaskTitle = task.TaskName;
                if (task.Complete)
                {
                    newTask.ckbCheckbox.IsChecked = true;
                }
                this.TaskSection.Children.Add(newTask);
            }
        }
        public void AddNewTask(string newTask)
        {
            taskList.Add(newTask);
            PopulateTasks();
        }

        private void imgToday_MouseDown(object sender, MouseButtonEventArgs e)
        {
            todayScreen();
        }
        public void todayScreen()
        {
            Label header = new Label();
            header.Content = "Today, Monday April 5";
            header.HorizontalAlignment = HorizontalAlignment.Center;
            header.FontSize = 16;

            TaskSection.Children.Clear();
            TaskSection.Children.Add(header);

            DateTime today = new DateTime(2016, 4, 5);
            
            foreach (Task task in Task.allTasks)
            {
                if (task.DueDate.Equals(today))
                {
                    ToDoTask newTask = new ToDoTask();
                    newTask.TaskTitle = task.TaskName;                    
                    newTask.DueDate = task.DueDate.ToString("MMM")+ " " + task.DueDate.Day.ToString();
                    if (task.Complete)
                    {
                        newTask.ckbCheckbox.IsChecked = true;
                    }
                    TaskSection.Children.Add(newTask);
                }
                //ToDoTask newTask = new ToDoTask();
                //newTask.TaskTitle = task.TaskName;
                //TaskSection.Children.Add(newTask);
            }

            //ToDoTask task1 = new ToDoTask();
            //task1.TaskTitle = "Feed Max";
            //task1.DueDate = "March 14";

            //ToDoTask task2 = new ToDoTask();
            //task2.TaskTitle = "Assignment 1";
            //task2.DueDate = "March 14";

            //TaskSection.Children.Add(task1);
            //TaskSection.Children.Add(task2);
        }

        private void imgHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TaskSection.Children.Clear();
            //TaskSection.Children.Add(weeklyView);
            showWeeklyView();
        }

        private void imgSort_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (lsvSortBy.Visibility == Visibility.Hidden)
            {
                lsvSortBy.Visibility = Visibility.Visible;
                SelectionGrid.Visibility = Visibility.Visible;
            }
            else
            {
                lsvSortBy.Visibility = Visibility.Hidden;
                SelectionGrid.Visibility = Visibility.Collapsed;
            }
            
        }

        private void imgCalender_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (lsvViewBy.Visibility == Visibility.Hidden)
            {
                lsvViewBy.Visibility = Visibility.Visible;
                SelectionGrid.Visibility = Visibility.Visible;
            }
            else
            {
                lsvViewBy.Visibility = Visibility.Hidden;
                SelectionGrid.Visibility = Visibility.Collapsed;
            }
        }
              

        private void lviAlphabetical(object sender, RoutedEventArgs e)
        {
            //hide list view box
            lsvSortBy.Visibility = Visibility.Hidden;
            TopIcons.Height = 60;
            TaskSection.Children.Clear();

            Label header = new Label();
            header.Content = "Sort Alphabetically";
            header.HorizontalAlignment = HorizontalAlignment.Center;
            header.FontSize = 16;

            TaskSection.Children.Clear();
            TaskSection.Children.Add(header);

            ToDoTask task1 = new ToDoTask();
            task1.TaskTitle = "Feed Max";
            task1.DueDate = "March 14";

            ToDoTask task2 = new ToDoTask();
            task2.TaskTitle = "Assignment 1";
            task2.DueDate = "March 14";

            ToDoTask task3 = new ToDoTask();
            task3.TaskTitle = "Study for Midterm";
            task3.DueDate = "March 16";

            ToDoTask task4 = new ToDoTask();
            task4.TaskTitle = "Buy groceries";
            task4.DueDate = "March 16";

            TaskSection.Children.Add(task2);
            TaskSection.Children.Add(task4);
            TaskSection.Children.Add(task1);
            TaskSection.Children.Add(task3);     
        }

        private void lviDueDate(object sender, RoutedEventArgs e)
        {
            //hide list view box
            lsvSortBy.Visibility = Visibility.Hidden;
            TopIcons.Height = 60;
            TaskSection.Children.Clear();

            //initialize display dates
            Label date1 = new Label();
            date1.Content = "Monday March 14";
            date1.HorizontalAlignment = HorizontalAlignment.Center;
            date1.FontSize = 16;
            

            Label date2 = new Label();
            date2.Content = "Wednesday March 16";
            date2.HorizontalAlignment = HorizontalAlignment.Center;
            date2.FontSize = 16;

            //initialize tasks
            ToDoTask task1 = new ToDoTask();
            task1.TaskTitle = "Feed Max";
            task1.DueDate = "March 14";
            ToDoTask task2 = new ToDoTask();
            task2.TaskTitle = "Assignment 1";
            task2.DueDate = "March 14";
            ToDoTask task3 = new ToDoTask();
            task3.TaskTitle = "Study for Midterm";
            task3.DueDate = "March 16";
            ToDoTask task4 = new ToDoTask();
            task4.TaskTitle = "Buy groceries";
            task4.DueDate = "March 16";
            TaskSection.Children.Clear();

            TaskSection.Children.Add(date1);
            TaskSection.Children.Add(task1);
            TaskSection.Children.Add(task2);

            TaskSection.Children.Add(date2);
            TaskSection.Children.Add(task3);
            TaskSection.Children.Add(task4);   
        }

        private void vbiCategory(object sender, RoutedEventArgs e)
        {
            //hide list view box
            lsvSortBy.Visibility = Visibility.Hidden;
            TopIcons.Height = 60;
            TaskSection.Children.Clear();

            //initialize display dates
            Label category1 = new Label();
            category1.Content = "Personal";
            category1.HorizontalAlignment = HorizontalAlignment.Center;
            category1.FontSize = 16;

            Label category2 = new Label();
            category2.Content = "School";
            category2.HorizontalAlignment = HorizontalAlignment.Center;
            category2.FontSize = 16;

            Label category3 = new Label();
            category3.Content = "School";
            category3.HorizontalAlignment = HorizontalAlignment.Center;
            category3.FontSize = 16;

            //initialize tasks
            ToDoTask task1 = new ToDoTask();
            task1.TaskTitle = "Feed Max";
            task1.DueDate = "March 14";

            ToDoTask task2 = new ToDoTask();
            task2.TaskTitle = "Assignment 1";
            task2.DueDate = "March 14";

            ToDoTask task3 = new ToDoTask();
            task3.TaskTitle = "Study for Midterm";
            task3.DueDate = "March 16";

            ToDoTask task4 = new ToDoTask();
            task4.TaskTitle = "Buy groceries";
            task4.DueDate = "March 16";

            TaskSection.Children.Clear();

            TaskSection.Children.Add(category1);
            TaskSection.Children.Add(task1);
            TaskSection.Children.Add(task2);

            TaskSection.Children.Add(category2);
            TaskSection.Children.Add(task3);
            TaskSection.Children.Add(task4);

           // TaskSection.Children.Add(category3);
        }

        //handles task selection for user to edit/view a task
        private void TaskSection_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (WeeklyTaskInsert.selectable == true)
            //{
            //    TaskInfoScreen taskScreen = new TaskInfoScreen();
            //    taskScreen.Header = "Edit Task";
            //    taskScreen.Title = "Feed Max";
            //    taskScreen.Description = "";
            //    taskScreen.InfoSection.IsEnabled = true;
            //    taskScreen.imgEdit.Visibility = Visibility.Hidden;
            //    taskScreen.imgDelete.Visibility = Visibility.Visible;
            //    taskScreen.imgOk.Visibility = Visibility.Visible;
            //    ((Panel)this.Parent).Children.Add(taskScreen);
            //    ((Panel)this.Parent).Children.Remove(this);
            //}
            
            //if (WeeklyTaskInsert.selectable == true)
            //{
            //    TaskInfoScreen taskScreen = new TaskInfoScreen();
            //    taskScreen.Header = "View Task";
            //    taskScreen.Title = "Feed Max";
            //    taskScreen.Description = "";
            //    taskScreen.InfoSection.IsEnabled = false;
            //    taskScreen.imgEdit.Visibility = Visibility.Visible;
            //    taskScreen.imgDelete.Visibility = Visibility.Visible;
            //    taskScreen.imgOk.Visibility = Visibility.Hidden;
            //    ((Panel)this.Parent).Children.Add(taskScreen);
            //    ((Panel)this.Parent).Children.Remove(this);
            //}
                      
        }
        public void RemoveTask()
        {
            Label header = new Label();
            header.Content = "Today, Monday March 14";
            header.HorizontalAlignment = HorizontalAlignment.Center;
            header.FontSize = 16;

            TaskSection.Children.Clear();
            TaskSection.Children.Add(header);

            ToDoTask task1 = new ToDoTask();
            task1.TaskTitle = "Feed Max";
            task1.DueDate = "March 14";
            ToDoTask task2 = new ToDoTask();
            task2.TaskTitle = "Assignment 1";
            task1.DueDate = "March 14";
            //TaskSection.Children.Add(task1);
            TaskSection.Children.Add(task2);
        }
        public void EditTask()
        {
            Label header = new Label();
            header.Content = "Today, Monday March 14";
            header.HorizontalAlignment = HorizontalAlignment.Center;
            header.FontSize = 16;

            TaskSection.Children.Clear();
            TaskSection.Children.Add(header);

            ToDoTask task1 = new ToDoTask();
            task1.TaskTitle = "Feed Doli";
            task1.DueDate = "March 14";
            ToDoTask task2 = new ToDoTask();
            task2.TaskTitle = "Assignment 1";
            task2.DueDate = "March 14";
            TaskSection.Children.Add(task1);
            TaskSection.Children.Add(task2);
        }

        private void lviAgenda(object sender, RoutedEventArgs e)
        {
            if (lsvViewBy.Visibility == Visibility.Hidden)
            {
                lsvViewBy.Visibility = Visibility.Visible;
                TopIcons.Height = 120;
            }
            else
            {
                lsvViewBy.Visibility = Visibility.Hidden;
                TopIcons.Height = 60;
            }
            //hide list view box
            lsvSortBy.Visibility = Visibility.Hidden;
            TopIcons.Height = 60;
            TaskSection.Children.Clear();

            

            //initialize display dates
            Label date1 = new Label();
            date1.Content = "Monday March 14";
            date1.HorizontalAlignment = HorizontalAlignment.Center;
            date1.FontSize = 16;

            Label date2 = new Label();
            date2.Content = "Wednesday March 16";
            date2.HorizontalAlignment = HorizontalAlignment.Center;
            date2.FontSize = 16;
           

            //initialize times
            Label time1 = new Label();
            time1.Content = "09:00";
            time1.HorizontalAlignment = HorizontalAlignment.Left;
            time1.FontSize = 12;

            Label time2 = new Label();
            time2.Content = "19:00";
            time2.HorizontalAlignment = HorizontalAlignment.Left;
            time2.FontSize = 12;

            Label time3 = new Label();
            time3.Content = "12:00";
            time3.HorizontalAlignment = HorizontalAlignment.Left;
            time3.FontSize = 12;

            Label time4 = new Label();
            time4.Content = "17:00";
            time4.HorizontalAlignment = HorizontalAlignment.Left;
            time4.FontSize = 12;

            //initialize tasks
            Label task1 = new Label();
            task1.Content = "Feed Max";
            //task1.DueDate = "March 14";
            Label task2 = new Label();
            task2.Content = "Assignment 1";
            //task2.DueDate = "March 14";
            Label task3 = new Label();
            task3.Content = "Study for Midterm";
            //task3.DueDate = "March 16";
            Label task4 = new Label();
            task4.Content = "Buy groceries";
           // task4.DueDate = "March 16";
            TaskSection.Children.Clear();

            //agendga entries
            AgendaView agendaView1 = new AgendaView();
            agendaView1.LeftSide.Children.Add(time1);
            agendaView1.RightSide.Children.Add(task1);
         

            AgendaView agendaView2 = new AgendaView();
            agendaView2.LeftSide.Children.Add(time2);
            agendaView2.RightSide.Children.Add(task2);

            AgendaView agendaView3 = new AgendaView();
            agendaView3.LeftSide.Children.Add(time3);
            agendaView3.RightSide.Children.Add(task3);

            AgendaView agendaView4 = new AgendaView();
            agendaView4.LeftSide.Children.Add(time4);
            agendaView4.RightSide.Children.Add(task4);

            //spaceholder
            Canvas spaceholder = new Canvas();
            spaceholder.Height = 20;

            TaskSection.Children.Add(date1);
            TaskSection.Children.Add(agendaView1);
            TaskSection.Children.Add(agendaView2);

            TaskSection.Children.Add(spaceholder);

            TaskSection.Children.Add(date2);
            TaskSection.Children.Add(agendaView3);
            TaskSection.Children.Add(agendaView4);

        }

        private void lviMonthly(object sender, RoutedEventArgs e)
        {
            if (lsvViewBy.Visibility == Visibility.Hidden)
            {
                lsvViewBy.Visibility = Visibility.Visible;
                TopIcons.Height = 120;
            }
            else
            {
                lsvViewBy.Visibility = Visibility.Hidden;
                TopIcons.Height = 60;
            }
            CalendarView calendarview = new CalendarView();
            TaskSection.Children.Clear();
            TaskSection.Children.Add(calendarview);
        }

        private void imgComplete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TaskComplete completeScreen = new TaskComplete();
            completeScreen.TaskTitle = "Assignment 1";
            completeScreen.Points = 10;
            ((Panel)this.Parent).Children.Add(completeScreen);
            ((Panel)this.Parent).Children.Remove(this);

        }
        public void FakeCompleted()
        {
            Label header = new Label();
            header.Content = "Today, Monday March 14";
            header.HorizontalAlignment = HorizontalAlignment.Center;
            header.FontSize = 16;

            TaskSection.Children.Clear();
            TaskSection.Children.Add(header);

            ToDoTask task1 = new ToDoTask();
            task1.TaskTitle = "Feed Doli";
            task1.DueDate = "March 14";
            ToDoTask task2 = new ToDoTask();
            task2.TaskTitle = "Assignment 1";
            task2.DueDate = "March 14";
            task2.ckbCheckbox.IsChecked = true;
            task2.lblStrikeOutLine.Visibility = Visibility.Visible;
            //TaskSection.Children.Add(task1);
            TaskSection.Children.Add(task2);
        }

        public void FakeUndoComplete()
        {
            Label header = new Label();
            header.Content = "Today, Monday March 14";
            header.HorizontalAlignment = HorizontalAlignment.Center;
            header.FontSize = 16;

            TaskSection.Children.Clear();
            TaskSection.Children.Add(header);

            ToDoTask task1 = new ToDoTask();
            task1.TaskTitle = "Feed Doli";
            task1.DueDate = "March 14";
            ToDoTask task2 = new ToDoTask();
            task2.TaskTitle = "Assignment 1";
            task2.DueDate = "March 14";            
           
            //TaskSection.Children.Add(task1);
            TaskSection.Children.Add(task2);
        }

        private void imgSync_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ReportsScreen reportsScreen = new ReportsScreen();
            TaskSection.Children.Clear();
            TaskSection.Children.Add(reportsScreen);
        }



     
        

      

        
    }
}
