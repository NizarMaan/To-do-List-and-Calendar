using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ReportsScreen.xaml
    /// </summary>
    ///     
    public partial class ReportsScreen : UserControl
    {
        //array of Rectangle controls that represent each day of the week
        private Rectangle[] dataBars = new Rectangle[7];

        //list of rows in datagrid
        private List<RowValues> rows = new List<RowValues>();

        //list of categories
        private List<string> categories = new List<string>();

        //list of colors to randomly assign a color to a data row
        private SolidColorBrush[] colors;

        //int list to keep track of used numbers, to not repeat the same color
        private List<int> usedIndices = new List<int>();

        //start of week
        private DateTimeOffset mon;

        //end of week
        private DateTimeOffset sun;

        public ReportsScreen()
        {
            InitializeComponent();
            WeeklyView week = new WeeklyView();
            mon = week.mon;
            sun = mon.AddDays(6);

            //insert rectangles to the array
            InsertBars();

            //Insert arbitrarily chosen colors into colors list
            InsertColors();

            //initialize table Data
            InitializeDataGrid();

            //set the add-row event handler for each data table
            Table.LoadingRow += Table_LoadingRow;
            CompletionTable.LoadingRow += Table_LoadingRow;

            //load reports
            RefreshReports();
        }
        private void RefreshReports()
        {
            //reset the used indices list eveyr refresh
            usedIndices.Clear();

            //set appropriate week label
            CurrentWeek.Content = mon.ToString("MMM d") + " - " + sun.ToString("MMM d");
            
            //reset graph
            ResetGraph();
            rows = new List<RowValues>();

            //check what tasks have been completed on what day to set bar graph values
            CalculateValues();

            /*Set the tables data source to the values list.
             *For every RowValues object in the rows list a row will be created in the data grid with each cell of the row
             *displaying the values set to each of the RowValues attributes.
            */
            Table.ItemsSource = rows;
            PopulateCompleted();
        }

        //takes in an index corresponding to the day of the week (i.e. 0 -> monday, 1-> tuesday ... etc.)
        //increases height of the bar
        public void AddPoint(int index){
            if (dataBars[index].Height < 215)
            {
                dataBars[index].Height += 43;     
              
                dataBars[index].Margin = new Thickness(dataBars[index].Margin.Left, dataBars[index].Margin.Top - 43, dataBars[index].Margin.Right, dataBars[index].Margin.Bottom);
            }          
        }

        //takes in an index corresponding to the day of the week (i.e. 0 -> monday, 1-> tuesday ... etc.)
        //decreases height of the bar
        public void RemovePoint(int index)
        {
            if (dataBars[index].Height >= 43)
            {
                dataBars[index].Height -= 43;
                dataBars[index].Margin = new Thickness(dataBars[index].Margin.Left, dataBars[index].Margin.Top + 43, dataBars[index].Margin.Right, dataBars[index].Margin.Bottom);
            }
            else if(dataBars[index].Height > 0)
            {
                dataBars[index].Height -= dataBars[index].Height;
            }
        }

        private void CalculateValues()
        {
            
            //the number of categories will be the number of rows
            //loop through each task to get its Category and store it
            foreach(Task task in Task.allTasks){
                if (categories.Contains(task.Category) == false)
                {
                    categories.Add(task.Category);
                }
            }
            /*nested foreach loop - loop through every category in the category list then loop through taskList
            *
            */
            //set data table values
            foreach (string category in categories)
            {
                RowValues rowData = new RowValues();
                rowData.Category = category;

                foreach (Task task in Task.allTasks)
                {
                    if (task.Complete == true && task.CompletedDate >= mon && task.CompletedDate <= sun)
                    {
                        DayOfWeek day = task.CompletedDate.DayOfWeek;
                        switch (day)
                        {
                            case DayOfWeek.Monday :
                                if (category.Equals(task.Category))
                                {
                                    rowData.M++;
                                }
                                break;
                            case DayOfWeek.Tuesday:
                                if (category.Equals(task.Category))
                                {
                                    rowData.T++;
                                }
                                break;
                            case DayOfWeek.Wednesday:
                                if (category.Equals(task.Category))
                                {
                                    rowData.W++;
                                }
                                break;
                            case DayOfWeek.Thursday:
                                if (category.Equals(task.Category))
                                {
                                    rowData.Th++;
                                }
                                break;
                            case DayOfWeek.Friday:
                                if (category.Equals(task.Category))
                                {
                                    rowData.F++;
                                }
                                break;
                            case DayOfWeek.Saturday:
                                if (category.Equals(task.Category))
                                {
                                    rowData.Sa++;
                                }
                                break;
                            case DayOfWeek.Sunday:
                                if (category.Equals(task.Category))
                                {
                                    rowData.Su++;
                                }
                                break;
                        }
                    }
                }
                rows.Add(rowData);
            }

            //loop through each task in the taskList to determine what day it was completed on
            //set bar graph values to the bar that corresponds to the day a task was completed on
            foreach (Task task in Task.allTasks)
            {
                if (task.Complete == true && task.CompletedDate >= mon && task.CompletedDate <= sun)
                {
                    DayOfWeek day = task.CompletedDate.DayOfWeek;
                    switch (day)
                    {
                        case DayOfWeek.Monday:
                            AddPoint(0);
                            break;
                        case DayOfWeek.Tuesday:
                            AddPoint(1);
                            break;
                        case DayOfWeek.Wednesday:
                            AddPoint(2);
                            break;
                        case DayOfWeek.Thursday:
                            AddPoint(3);
                            break;
                        case DayOfWeek.Friday:
                            AddPoint(4);
                            break;
                        case DayOfWeek.Saturday:
                            AddPoint(5);
                            break;
                        case DayOfWeek.Sunday:
                            AddPoint(6);
                            break;
                    }
                }
            }
        }

        /*This class contains data to create a 8 column headers and a row immedeatly below these headers.
         * each cell in this row derives its value through each of the class's attributes (cellM, cellT, etc.)
         * 
        */
        public class RowValues 
        {
            private string cellCategory;
            private int cellM;
            private int cellT;
            private int cellW;
            private int cellTh;
            private int cellF;
            private int cellSa;
            private int cellSu;

            public string Category
            {
                get { return cellCategory; }
                set { cellCategory = value; }
            }

            public int M
            {
                get { return cellM; }
                set { cellM = value; }
            }

            public int T
            {
                get { return cellT; }
                set { cellT = value;}
            }

            public int W
            {
                get { return cellW; }
                set { cellW = value; }
            }

            public int Th
            {
                get { return cellTh; }
                set { cellTh = value;}
            }

            public int F
            {
                get { return cellF; }
                set { cellF = value;}
            }

            public int Sa
            {
                get { return cellSa; }
                set { cellSa = value;}
            }

            public int Su
            {
                get { return cellSu; }
                set { cellSu = value;}
            }

        }

        /*this class is to store data for records in completed task information
         * 
        */
        public class RowValuesCompleted
        {
            private string topic;
            private int numberOf;
           

            public string Topic
            {
                get { return topic; }
                set { topic = value; }
            }

            public int NumberOf
            {
                get { return numberOf; }
                set { numberOf = value; }
            }

           

        }

        //method call to add a precreated row - just pass in the RowValues object you wish to add
        public void AddRow(RowValues row)
        {
            rows.Add(row);
        }

        //method to add an empty row (for whatever reason)
        public void AddEmptyRow()
        {
            RowValues row = new RowValues();
            rows.Add(row);
        }

        private void Table_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //generate a random num to use to index into colors list
            Random gen = new Random();
            int n = gen.Next(20);

            //if index already used, loop until new one is generated
            while(usedIndices.Contains(n) == true){
                n = gen.Next(20);
            }
            
            //add the used index to the used indices list
            usedIndices.Add(n);
            //use the color at that index
           // e.Row.Foreground = colors[n];
            

            //e.Row.FontWeight = FontWeights.Bold;
            //e.Row.FontFamily = new FontFamily("Segoe UI Black");
        }

        //set user permissions on the data grid
        private void InitializeDataGrid()
        {
            Table.CanUserResizeRows = false;
            Table.CanUserReorderColumns = false;
            Table.CanUserResizeColumns = false;
            Table.CanUserSortColumns = false;
            Table.IsReadOnly = true;
            Table.CanUserDeleteRows = false;
            Table.CanUserAddRows = false;

            CompletionTable.CanUserResizeRows = false;
            CompletionTable.CanUserReorderColumns = false;
            CompletionTable.CanUserResizeColumns = false;
            CompletionTable.CanUserSortColumns = false;
            CompletionTable.IsReadOnly = true;
            CompletionTable.CanUserDeleteRows = false;
            CompletionTable.CanUserAddRows = false;

           // Table.Height = 40;
            Table.Width = 220;
            CompletionTable.Width = 220;           

        }

        //insert bars into DataBars list
        private void InsertBars()
        {
            dataBars[0] = MondayBar;
            dataBars[1] = TuesdayBar;
            dataBars[2] = WednesdayBar;
            dataBars[3] = ThursdayBar;
            dataBars[4] = FridayBar;
            dataBars[5] = SaturdayBar;
            dataBars[6] = SundayBar;
        }

        //this method adds arbitrarily chosen colors into the colors List
        private void InsertColors(){
            colors = new SolidColorBrush[]{
                new SolidColorBrush(Colors.DeepSkyBlue),
                new SolidColorBrush(Colors.BlueViolet),
                new SolidColorBrush(Colors.OrangeRed),
                new SolidColorBrush(Colors.MediumAquamarine),
                new SolidColorBrush(Colors.LightCoral),
                new SolidColorBrush(Colors.Salmon),
                new SolidColorBrush(Colors.Teal),
                new SolidColorBrush(Colors.LightGreen),
                new SolidColorBrush(Colors.NavajoWhite),
                new SolidColorBrush(Colors.Orchid),
                new SolidColorBrush(Colors.DeepPink),
                new SolidColorBrush(Colors.DarkViolet),
                new SolidColorBrush(Colors.LightSeaGreen),
                new SolidColorBrush(Colors.HotPink),
                new SolidColorBrush(Colors.DarkCyan),
                new SolidColorBrush(Colors.DarkOrchid),
                new SolidColorBrush(Colors.DarkOrange),
                new SolidColorBrush(Colors.Chocolate),
                new SolidColorBrush(Colors.MediumSpringGreen),
                new SolidColorBrush(Colors.Tomato)
            };
        }
        
        private void ResetGraph()
        {
            foreach (Rectangle day in dataBars)
            {
                day.Height = 0;
                day.Margin = new Thickness(0, 0, 0, 0);
            }
        }

        private void PopulateCompleted()
        {
            RowValuesCompleted completedRow = new RowValuesCompleted();
            completedRow.Topic = "Completed On Time";
            RowValuesCompleted pastDueRow = new RowValuesCompleted();
            pastDueRow.Topic = "Completed Past Due";
            RowValuesCompleted overDueRow = new RowValuesCompleted();
            overDueRow.Topic = "Not Completed";


            foreach (Task task in Task.allTasks)
            {
                if (task.DueDate >= mon && task.DueDate <= sun)
                {
                    if (task.Complete)
                    {
                        //tasks completed before due date
                        if (task.CompletedDate <= task.DueDate)
                        {
                            completedRow.NumberOf = completedRow.NumberOf + 1;
                        }
                            //tasks completed after due date
                        else if (task.CompletedDate > task.DueDate)
                        {
                            pastDueRow.NumberOf = pastDueRow.NumberOf + 1;
                        }
                    }
                    else
                    {
                        //tasks not completed
                        overDueRow.NumberOf = overDueRow.NumberOf + 1;
                    }
                }
            }

            List<RowValuesCompleted> itemsource = new List<RowValuesCompleted>();
            itemsource.Add(completedRow);
            itemsource.Add(pastDueRow);
            itemsource.Add(overDueRow);

            CompletionTable.ItemsSource = itemsource;
            //CompletionTable.Items.Refresh();                    
        }

        private void imgLastWeek_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mon = mon.AddDays(-7);
            sun = sun.AddDays(-7);
            RefreshReports();
        }

        private void imgNextWeek_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mon = mon.AddDays(7);
            sun = sun.AddDays(7);
            RefreshReports();
        }
    }
}
