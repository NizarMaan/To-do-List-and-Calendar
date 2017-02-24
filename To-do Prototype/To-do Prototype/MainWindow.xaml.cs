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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        

        public MainWindow()
        {
            InitializeTasks();
            InitializeComponent();
            HomeScreen homeScreen = new HomeScreen();
            Display.Children.Add(homeScreen);
            
        }
        public void ChangeScreen()
        {
            Display.Children.Clear();
            TaskInfoScreen taskScreen = new TaskInfoScreen();
            Display.Children.Add(taskScreen);
        }

        private void InitializeTasks()
        {
             DateTime mon = new DateTime(2016,3,28);
             DateTime tues = new DateTime(2016, 3, 29);
             DateTime weds = new DateTime(2016,3,30);
             DateTime thurs = new DateTime(2016, 3, 31);
             DateTime fri = new DateTime(2016, 4, 1);
             DateTime sat = new DateTime(2016, 4, 2);
             DateTime sun = new DateTime(2016, 4, 3);
             DateTime apr4 = new DateTime(2016, 4, 4);
             DateTime apr5 = new DateTime(2016, 4, 5);
             DateTime apr6 = new DateTime(2016, 4, 6);

             DateTime monComplete = new DateTime(2016, 3, 28);
             DateTime tuesComplete = new DateTime(2016, 3, 29);
             DateTime wedsComplete = new DateTime(2016, 3, 30);
             DateTime thursComplete = new DateTime(2016, 3, 31);
             DateTime friComplete = new DateTime(2016, 4, 1);
             DateTime satComplete = new DateTime(2016, 4, 2);
             DateTime sunComplete = new DateTime(2016, 4, 3);


             Task task1 = new Task("Feed Max", "", mon, "Personal", "Med",monComplete);
             Task task2 = new Task("Assignment 1", "", mon, "CPSC481", "High", monComplete);
             Task task3 = new Task("Study for Midterm", "", tues, "CPSC101", "High", monComplete);
             Task task4 = new Task("Buy Groceries", "", weds, "Personal", "Low", tuesComplete);
             Task task5 = new Task("Assignment 1", "", thurs, "CPSC101", "Med", tuesComplete);
             Task task6 = new Task("Essay", "", tues, "CPSC481", "High", tuesComplete);
             Task task7 = new Task("Lab report", "", sat, "CPSC101", "Med", wedsComplete);
             Task task8 = new Task("Bake a pie", "", thurs, "Personal", "Med", thursComplete);
             Task task9 = new Task("Wash car", "", fri, "Personal", "Low", friComplete);
             Task task10 = new Task("Pick up Liz from airport", "", sun, "Personal", "Med", sunComplete);
             Task task11 = new Task("Create prototype video", "", apr4, "CPSC481", "Med", apr4);
             Task task12 = new Task("Prepare demo", "", apr4, "CPSC481", "Low");
             Task task13 = new Task("Present Prototype", "", apr5, "CPSC481", "High");
             Task task14 = new Task("Submit Portfolio", "", apr6, "CPSC481", "High");

             Task.allTasks.Add(task1);
             Task.allTasks.Add(task2);
             Task.allTasks.Add(task3);
             Task.allTasks.Add(task4);
             Task.allTasks.Add(task5);
             Task.allTasks.Add(task6);
             Task.allTasks.Add(task7);
             Task.allTasks.Add(task8);
             Task.allTasks.Add(task9);
             Task.allTasks.Add(task10);
             Task.allTasks.Add(task11);
             Task.allTasks.Add(task12);
             Task.allTasks.Add(task13);
             Task.allTasks.Add(task14);

        }
    }
}
