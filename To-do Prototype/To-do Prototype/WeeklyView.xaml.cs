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
    /// Interaction logic for WeeklyView.xaml
    /// </summary>
    public partial class WeeklyView : UserControl
    {
        
        private WeeklyView me;
        public DateTimeOffset mon = new DateTime();
        public DateTimeOffset tues = new DateTime();
        public DateTimeOffset weds = new DateTime();
        public DateTimeOffset thurs = new DateTime();
        public DateTimeOffset fri = new DateTime();
        public DateTimeOffset sat = new DateTime();
        public DateTimeOffset sun = new DateTime();

        public WeeklyView()
        {
            InitializeComponent();
            initializeWeek();
            //UserPoints = 0;
        }
        private void initializeWeek()
        {

            mon = new DateTime(2016, 4, 4);
            tues = mon.AddDays(1);
            weds = mon.AddDays(2);
            thurs = mon.AddDays(3);
            fri = mon.AddDays(4);
            sat = mon.AddDays(5);
            sun = mon.AddDays(6);
        }
        public void Itself(WeeklyView me)
        {
            this.me = me;
        }
        public void populateTasks()
        {
            LeftSide.Children.Clear();
            RightSide.Children.Clear();

            lblWeekLabel.Content = mon.ToString("MMM d") + " - " + sun.ToString("MMM d");
            //mon = new DateTime(2016, 3, 14);
            //tues = new DateTime(2016, 3, 15);
            //weds = new DateTime(2016, 3, 16);
            //thurs = new DateTime(2016, 3, 17);
            //fri = new DateTime(2016, 3, 18);
            //sat = new DateTime(2016, 3, 19);
            //sun = new DateTime(2016, 3, 20);
            //DateTime apr5 = new DateTime(2016, 4, 5);

            List<Task> mondayTasks = new List<Task>();
            List<Task> tuesdayTasks = new List<Task>();
            List<Task> wednesdayTasks = new List<Task>();
            List<Task> thursdayTasks = new List<Task>();
            List<Task> fridayTasks = new List<Task>();
            List<Task> saturdayTasks = new List<Task>();
            List<Task> sundayTasks = new List<Task>();

            int spacecount1 = 0;
            int spacecount2 = 0;
            int spacecount3 = 0;
            int spacecount4 = 0;
            int spacecount5 = 0;
            int spacecount6 = 0;

            foreach (Task task in Task.allTasks)
            {
               if (task.DueDate.Equals(mon))
               {
                   mondayTasks.Add(task);
                   spacecount1++;
               }
               else if (task.DueDate.Equals(tues))
               {
                   tuesdayTasks.Add(task);
                   spacecount1--;
                   spacecount2++;
               }
               else if (task.DueDate.Equals(weds))
               {
                   wednesdayTasks.Add(task);
                   spacecount2--;
                   spacecount3++;
               }
               else if (task.DueDate.Equals(thurs))
               {
                   thursdayTasks.Add(task);
                   spacecount3--;
                   spacecount4++;
               }
               else if (task.DueDate.Equals(fri))
               {
                   fridayTasks.Add(task);
                   spacecount4--;
                   spacecount5++;
               }
               else if (task.DueDate.Equals(sat))
               {
                   saturdayTasks.Add(task);
                   spacecount5--;
                   spacecount6++;
               }
               else if (task.DueDate.Equals(sun))
               {
                   sundayTasks.Add(task);
                   
               }               

            }

            //initialize day labels
            Label monday = new Label();
            monday.Content = "Mon, " + mon.ToString("MMM") + " " + mon.Day.ToString();
            monday.Height = 30;
         
            Label tuesday = new Label();
            tuesday.Content = "Tues, " + tues.ToString("MMM") + " " + tues.Day.ToString();
            tuesday.Height = 30;
            Label wednesday = new Label();
            wednesday.Content = "Wed, " + weds.ToString("MMM") + " " + weds.Day.ToString();
            wednesday.Height = 30;
            Label thursday = new Label();
            thursday.Content = "Thurs, " + thurs.ToString("MMM") + " " + thurs.Day.ToString();
            thursday.Height = 30;
            Label friday = new Label();
            friday.Content = "Fri, " + fri.ToString("MMM") + " " + fri.Day.ToString();
            friday.Height = 30;
            Label saturday = new Label();
            saturday.Content = "Sat, " + sat.ToString("MMM") + " " + sat.Day.ToString();
            saturday.Height = 30;
            Label sunday = new Label();
            sunday.Content = "Sun, " + sun.ToString("MMM") + " " + sun.Day.ToString();
           sunday.Height = 30;

            

            //monday
            LeftSide.Children.Add(monday);
           foreach (Task task in mondayTasks)
           {
               WeeklyTaskInsert taskInsert = new WeeklyTaskInsert();
               taskInsert.TaskTitle = task.TaskName;               
               if (task.Complete)
               {
                   taskInsert.chkComplete.IsChecked = true;
               }
               LeftSide.Children.Add(taskInsert);
              
           }

            //tuesday
           //spaceholder
           Canvas spaceholder1 = new Canvas();
           spaceholder1.Height = 20;
           spaceholder1.Width = 135;

           RightSide.Children.Add(spaceholder1);
           RightSide.Children.Add(tuesday);
           foreach (Task task in tuesdayTasks)
           {
               WeeklyTaskInsert taskInsert = new WeeklyTaskInsert();
               taskInsert.TaskTitle = task.TaskName;
               if (task.Complete)
               {
                   taskInsert.chkComplete.IsChecked = true;
               }
               RightSide.Children.Add(taskInsert);
           }

           Canvas spaceholder2 = new Canvas();
           spaceholder2.Height = 25 * Math.Abs(spacecount1);
            if (spacecount1 < 0)
            {                              
                LeftSide.Children.Add(spaceholder2);
            }
            else if (spacecount1 > 0)
            {
                RightSide.Children.Add(spaceholder2);
            }
           

           //wednesday
           LeftSide.Children.Add(wednesday);
           foreach (Task task in wednesdayTasks)
           {
               WeeklyTaskInsert taskInsert = new WeeklyTaskInsert();
               taskInsert.TaskTitle = task.TaskName;
               if (task.Complete)
               {
                   taskInsert.chkComplete.IsChecked = true;
               }
               LeftSide.Children.Add(taskInsert);
              
           }

            //thursday
           RightSide.Children.Add(thursday);
           foreach (Task task in thursdayTasks)
           {
               WeeklyTaskInsert taskInsert = new WeeklyTaskInsert();
               taskInsert.TaskTitle = task.TaskName;
               if (task.Complete)
               {
                   taskInsert.chkComplete.IsChecked = true;
               }
               RightSide.Children.Add(taskInsert);
           }

           Canvas spaceholder3 = new Canvas();
           spaceholder3.Height = 25 * Math.Abs(spacecount3);
           if (spacecount3 < 0)
           {
               LeftSide.Children.Add(spaceholder3);
           }
           else if (spacecount3 > 0)
           {
               RightSide.Children.Add(spaceholder3);
           }
         

            //friday       
           LeftSide.Children.Add(friday);
           foreach (Task task in fridayTasks)
           {
               WeeklyTaskInsert taskInsert = new WeeklyTaskInsert();
               taskInsert.TaskTitle = task.TaskName;
               if (task.Complete)
               {
                   taskInsert.chkComplete.IsChecked = true;
               }
               LeftSide.Children.Add(taskInsert);
               
           }

            //saturday
           RightSide.Children.Add(saturday);
           foreach (Task task in saturdayTasks)
           {
               WeeklyTaskInsert taskInsert = new WeeklyTaskInsert();
               taskInsert.TaskTitle = task.TaskName;
               if (task.Complete)
               {
                   taskInsert.chkComplete.IsChecked = true;
               }
               RightSide.Children.Add(taskInsert);
           }

           //Canvas spaceholder4 = new Canvas();
           //spaceholder4.Height = 10 + 37 * Math.Abs(spacecount5);
           //if (spacecount5 < 0)
           //{
           //    LeftSide.Children.Add(spaceholder4);
           //}
           //else if (spacecount5 > 0)
           //{
           //    RightSide.Children.Add(spaceholder4);
           //}
          
       
           LeftSide.Children.Add(sunday);
           foreach (Task task in sundayTasks)
           {
               WeeklyTaskInsert taskInsert = new WeeklyTaskInsert();
               taskInsert.TaskTitle = task.TaskName;
               if (task.Complete)
               {
                   taskInsert.chkComplete.IsChecked = true;
               }
               LeftSide.Children.Add(taskInsert);
           }



            ////initialize tasks
            //WeeklyTaskInsert task1 = new WeeklyTaskInsert();
            ////task1.WeeklyViewReference(me);
            //task1.TaskTitle = "Feed Max";

            //WeeklyTaskInsert task2 = new WeeklyTaskInsert();
            //task2.TaskTitle = "Assignment1";

            //WeeklyTaskInsert task3 = new WeeklyTaskInsert();
            //task3.TaskTitle = "Study For Midterm";

            //WeeklyTaskInsert task4 = new WeeklyTaskInsert();
            //task4.TaskTitle = "Buy groceries";

            

            

            ////LEFT SIDE
            ////monday
            //LeftSide.Children.Add(monday);
            //LeftSide.Children.Add(task1);
            //LeftSide.Children.Add(task2);

            ////wednesday
            //LeftSide.Children.Add(wednesday);
            //LeftSide.Children.Add(task3);
            //LeftSide.Children.Add(task4);

            ////friday
            //LeftSide.Children.Add(friday);

            //LeftSide.Children.Add(spaceholder4);
            ////sunday
            //LeftSide.Children.Add(sunday);

            ////RIGHT SIDE
            //RightSide.Children.Add(spaceholder1);
            //RightSide.Children.Add(tuesday);
            //RightSide.Children.Add(spaceholder2);            
            //RightSide.Children.Add(thursday);
            //RightSide.Children.Add(spaceholder3);
            //RightSide.Children.Add(saturday);
        }

        private void imgLastWeek_MouseDown(object sender, MouseButtonEventArgs e)
        {

            mon = mon.AddDays(-7);
            tues = tues.AddDays(-7);
            weds = weds.AddDays(-7);
            thurs = thurs.AddDays(-7);
            fri = fri.AddDays(-7);
            sat = sat.AddDays(-7);
            sun = sun.AddDays(-7);
            populateTasks();
        }

        private void imgNextWeek_MouseDown(object sender, MouseButtonEventArgs e)
        {
             mon = mon.AddDays(7);
            tues = tues.AddDays(7);
            weds = weds.AddDays(7);
            thurs = thurs.AddDays(7);
            fri = fri.AddDays(7);
            sat = sat.AddDays(7);
            sun = sun.AddDays(7);
            populateTasks();
        }   

        //public void AddPoints()
        //{
        //    userPoints += 1000;
        //    PointsText.Content = String.Concat("Points: ", userPoints.ToString());
        //}
    }
}
