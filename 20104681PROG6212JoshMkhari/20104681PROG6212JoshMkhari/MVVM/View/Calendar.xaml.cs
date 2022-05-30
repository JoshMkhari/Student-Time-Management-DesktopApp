using _20104681PROG6212JoshMkhari.Logic;
using _20104681PROG6212JoshMkhari.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace _20104681PROG6212JoshMkhari.MVVM.View
{
    /// <summary>
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : UserControl
    {
        public Calendar()
        {
            InitializeComponent();
            semesterCalendar.DisplayDateStart = StartModel.semesterStartDate;
            semesterCalendar.DisplayDateEnd = StartModel.semesterEndDate;
            if (CalendarModel.inProcess)
            {
                semesterCalendar.SelectedDate = CalendarModel.SDate;
            }
            else
            {
                semesterCalendar.SelectedDate = StartModel.semesterStartDate;
            }
            DateTime day = (DateTime)semesterCalendar.SelectedDate;
            TDate.Text = day.ToString("d");
            CalendarModel.inProcess = false;
            MainWindowModel.currentView = 3;
            displayCurrentWeekModule(day);
            ProgramDAL dal = new ProgramDAL();
            CalendarModel.planned = dal.GetPlannedID();

            //Load all dates and call date storer
        }

        private void semesterCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            //semesterCalendar.DisplayDateStart = StartModel.semesterStartDate;
            //semesterCalendar.DisplayDateEnd = StartModel.semesterEndDate;
            DateTime day = (DateTime)semesterCalendar.SelectedDate;
            TDate.Text = day.ToString("d");
            populateDailyView();
            calculateCurrentWeek(day);
            displayCurrentWeekModule(day);
        }

        private void addSelfStudyButton_Click(object sender, RoutedEventArgs e)
        {
            //if we have atleast one module then proceed or else warning,  add a module first

            if (Program.moduleList.Count > 0)
            {
                CalendarModel.SelectedDate = semesterCalendar.SelectedDate.ToString().Substring(0, 10);
                CalendarModel.SDate = (DateTime)semesterCalendar.SelectedDate;
                CalendarModel.inProcess = true;
                updater.Value = 5;//change to view modules
            }
            else
            {
                MessageBox.Show("No module to choose self study hours, First add a module", "Calendar Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                updater.Value = 3; //remain on calendar view
            }

        }

        void displayCurrentWeekModule(DateTime day)
        {
            List<string> currentWeekCode = new List<string>();
            List<int> currentWeekHours = new List<int>();
            LCurrentWeekModules.Items.Clear();
            int currentModuleSelfHours = 0;
            int currentDayInt = Convert.ToInt32(day.DayOfWeek); //5

            for (int i = 0; i < 7; i++)// Repeats for each day of the week
            {
                String currentDay = day.AddDays(-currentDayInt + i).ToString().Substring(0, 10);
                for (int s = 0; s < CalendarModel.datesList.Count(); s++) //Repeats for each item in dateslist
                {

                    var currentDate = CalendarModel.datesList.ElementAt(s);
                    if (currentDate.storedDate.Equals(currentDay)) //check if the currentdate is our current day
                    {
                        for (int t = 0; t < currentDate.plannedList.Count(); t++) //now we are going to extract every planned module object for the day
                        {
                            var currentList = currentDate.plannedList.ElementAt(t);
                            if (currentWeekCode.Contains(currentList.codes)) //check if the list we currently has this module
                            {
                                for (int b = 0; b < currentWeekCode.Count(); b++) //repeat for the length of added modules in our list
                                {
                                    if (currentWeekCode.ElementAt(b).Equals(currentList.codes))//if we find the right module code
                                    {
                                        int currTotal = currentWeekHours.ElementAt(b);//8
                                        //currentWeekHours is alwayys remaining hours
                                        // now we should subtract this total from self hours

                                        for (int v = 0; v < Program.moduleList.Count(); v++)//let us retrieve the self hours for this module
                                        {
                                            var currentProgram = Program.moduleList.ElementAt(v);
                                            if (currentProgram.codes.Equals(currentList.codes))
                                            {
                                                currentModuleSelfHours = currentProgram.selfHours;//9
                                                break;//Stop searching as we found what we needed
                                            }
                                        }
                                        currTotal = currentModuleSelfHours - currTotal;//9-8 = 1
                                        int newTotal = currTotal + currentList.hours; //retrieving the current total for week hours
                                        int remainingHours = currentModuleSelfHours - newTotal; //this is the remaining hours
                                        if (remainingHours < 1)
                                        {
                                            remainingHours = 0;
                                        }
                                        currentWeekCode.RemoveAt(b);
                                        currentWeekHours.RemoveAt(b);

                                        currentWeekCode.Add(currentList.codes);
                                        currentWeekHours.Add(remainingHours);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                currentWeekCode.Add(currentList.codes);
                                for (int v = 0; v < Program.moduleList.Count(); v++)//let us retrieve the self hours for this module
                                {
                                    var currentProgram = Program.moduleList.ElementAt(v);
                                    if (currentProgram.codes.Equals(currentList.codes))
                                    {
                                        currentModuleSelfHours = currentProgram.selfHours;
                                        break;
                                    }
                                }
                                int remainingHours = currentModuleSelfHours - currentList.hours;
                                if (remainingHours < 1)
                                {
                                    remainingHours = 0;
                                }
                                currentWeekHours.Add(remainingHours);
                            }
                        }
                    }
                }
            }
            //run through module list, check if elemet at 1 is in current week, if not add it to current week with its self study hours xD
            for (int i = 0; i < Program.moduleList.Count; i++)
            {
                var currentModule = Program.moduleList.ElementAt(i);
                if (!currentWeekCode.Contains(currentModule.codes))// if our list of current week modules has the 
                {
                    currentWeekCode.Add(currentModule.codes);
                    currentWeekHours.Add(currentModule.selfHours);
                }
            }
            if (currentWeekCode.Count == 0)
            {
                LCurrentWeekModules.Items.Add("No modules to display");
                LCurrentWeekModules.Items.Add("Add a module");

            }
            else
            {
                for (int i = 0; i < currentWeekCode.Count; i++)
                {

                    LCurrentWeekModules.Items.Add(" " + currentWeekCode.ElementAt(i) + "\t\t" + currentWeekHours.ElementAt(i));
                }
            }


        }
        void calculateCurrentWeek(DateTime day)//Figuring out which week we are in currently
        {

            //String manipulation to the max
            int currentDay = Convert.ToInt32(day.DayOfWeek); //5

            String edit = day.AddDays(-currentDay).ToString("D");// Monday, 15 June 2009
            Boolean spaceMissing = true;
            int index = 0;

            //Finding the first empty string character
            do
            {

                if (edit.Substring(index, 1).Equals(" "))
                {
                    spaceMissing = false;
                }
                index++;
            }
            while (spaceMissing);

            /*
             * Eg: String is "Monday, 15 June 2009"
             * 
             * THe code below will extract only the "15 June " part
             */
            int start = index;
            int spacesCount = 0;
            edit = edit.Substring(start);
            index = 0;
            do
            {
                if (edit.Substring(index, 1).Equals(" "))
                {
                    spacesCount++;
                }
                index++;
            }
            while (spacesCount != 2);

            string edited = edit.Substring(0, index);
            TWeek.Text = "Week of " + edited;
        }

        void populateDailyView()//Used to populate the daily view listbox
        {
            //CalendarModel.duplicateChecker();//Checking for duplicates withing DateStore list

            LDisplayPlannedModuleForDay.Items.Clear();//Clearing the list before repopulating it

            for (int i = 0; i < CalendarModel.datesList.Count; i++)//Repeat for the length of the dates list
            {
                StoredDates curr = CalendarModel.datesList.ElementAt(i);
                if (curr.storedDate.Equals(semesterCalendar.SelectedDate.ToString().Substring(0, 10)))//check if the current date is the one within our datesList element at i
                {
                    foreach (var item in curr.plannedList)
                        LDisplayPlannedModuleForDay.Items.Add(" " + item.codes + "\t\t" + item.hours);//add to the listbox

                }
            }

            if (LDisplayPlannedModuleForDay.Items.Count == 0)
            {
                LDisplayPlannedModuleForDay.Items.Add(" You have not added any");
                LDisplayPlannedModuleForDay.Items.Add(" modules to study for");
                LDisplayPlannedModuleForDay.Items.Add(" today");
            }
        }
    }


}
