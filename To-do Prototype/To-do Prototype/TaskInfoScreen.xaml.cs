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
    /// Interaction logic for TaskInfoScreen.xaml
    /// </summary>
    public partial class TaskInfoScreen : UserControl
    {
            
        private string title;
        private string description;
        private string header;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                txtTitle.Text = this.title;
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                txtDescription.Text = this.description;
            }
        }
        public string Header
        {
            get { return header; }
            set
            {
                header = value;
                lblHeader.Content = this.header;
            }
        }
        public TaskInfoScreen()
        {
            InitializeComponent();
        }

        private void CreateTask(object sender, MouseButtonEventArgs e)
        {
            //ToDoTask newTask = new ToDoTask();
            //newTask.TaskTitle = txtTitle.Text;
            //homeScreen.AddNewTask(txtTitle.Text);
             
            if (header == "Edit Task")
            {
                   
                //homeScreen.EditTask();               
            }
            else if (header == "Add New Task")
            {
                //WeeklyTaskInsert newTask = new WeeklyTaskInsert();
                //newTask.TaskTitle = txtTitle.Text;
                //homeScreen.weeklyView.RightSide.Children.Add(newTask);       
                
                string[] split = txtDueDate.Text.Split('/');
                int month = Int32.Parse(split[0]);
                int day = Int32.Parse(split[1]);
                int year = Int32.Parse(split[2]);
                DateTime newDueDate = new DateTime(year, month, day);
                
                Task newTask = new Task(txtTitle.Text, txtDescription.Text, newDueDate, cmbCategory.SelectedItem.ToString(), cmbPriority.SelectedItem.ToString());
                Task.allTasks.Add(newTask);
                
            }
            HomeScreen homeScreen = new HomeScreen();    
            ((Panel)this.Parent).Children.Add(homeScreen);            
            ((Panel)this.Parent).Children.Remove(this);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Reminders.IsEnabled = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Reminders.IsEnabled = false;
        }

        private void imgCancel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HomeScreen homeScreen = new HomeScreen();    
            if (header == "View Task")
            {
                homeScreen.todayScreen();
                ((Panel)this.Parent).Children.Add(homeScreen);
                ((Panel)this.Parent).Children.Remove(this);
            }
            else if(header == "Edit Task")
            {
                homeScreen.todayScreen();
                ((Panel)this.Parent).Children.Add(homeScreen);
                ((Panel)this.Parent).Children.Remove(this);
                //this.InfoSection.IsEnabled = false;
                //this.header = "View Task";
                //this.imgOk.Visibility = Visibility.Hidden;
            }
            else if (header == "Add New Task")
            {                
                ((Panel)this.Parent).Children.Add(homeScreen);
                ((Panel)this.Parent).Children.Remove(this);
            }

            
        }

        private void imgEdit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.InfoSection.IsEnabled = true;
            this.imgOk.Visibility = Visibility.Visible;
            this.Header = "Edit Task";
        }

        private void imgDelete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HomeScreen homeScreen = new HomeScreen();    
            
            if (MessageBox.Show("Are you sure you want to delete this task?","Confirmation", MessageBoxButton.YesNo).Equals(MessageBoxResult.Yes))            
            {
                homeScreen.RemoveTask();
                ((Panel)this.Parent).Children.Add(homeScreen);
                ((Panel)this.Parent).Children.Remove(this);
            }
            
        }

        

        private void btnDueCalendar_Click(object sender, RoutedEventArgs e)
        {
            this.canDueDate.Height = 200;
            this.calDueDate.Visibility = Visibility.Visible;
        }

        private void calDueDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] split = sender.ToString().Split(' ');
            this.txtDueDate.Text = split[0];
            this.canDueDate.Height = 40;
            this.calDueDate.Visibility = Visibility.Hidden;
        }

        private void btnCalendar_Click(object sender, RoutedEventArgs e)
        {
            fitMargins(400, 180);
            this.reminderCalendarPopUp.Visibility = Visibility.Visible;
        }

        private void reminderCalendarPopUp_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] split = sender.ToString().Split(' ');
            this.txtReminderDate.Text = split[0];
            this.reminderCalendarPopUp.Visibility = Visibility.Hidden;
            fitMargins(200, 0);
        }

        private void fitMargins(int canvasRefactorAmount, double componentsRefactorAmount)
        {
            remindersCanvas.Height = canvasRefactorAmount;
            Reminders.Height = canvasRefactorAmount;
            lblReoccurence.Margin = new Thickness(0, componentsRefactorAmount, 0, 0);
            cmbReoccurence.Margin = new Thickness(0, componentsRefactorAmount, 0, 0);
            lblEndDate.Margin = new Thickness(0, componentsRefactorAmount, 0, 0);
            txtEndDay.Margin = new Thickness(0, componentsRefactorAmount, 0, 0);
            btnEndDay.Margin = new Thickness(0, componentsRefactorAmount, 0, 0);
        }

      

        private void txtTitle_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            txtTitle.Text = "";
        }

        private void txtDescription_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            txtDescription.Text = "";
        }

        

        
    }
}
