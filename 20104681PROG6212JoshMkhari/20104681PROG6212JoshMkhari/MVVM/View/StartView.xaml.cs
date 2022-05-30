using _20104681PROG6212JoshMkhari.MVVM.Model;
using _20104681PROG6212JoshMkhari.MVVM.ViewModel;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace _20104681PROG6212JoshMkhari.MVVM.View
{
    /// <summary>
    /// Interaction logic for StartView.xaml
    /// </summary>
    public partial class StartView : UserControl
    {
        public StartView()
        {
            InitializeComponent();
            this.DataContext = new StartViewModel();
            startCalendar.SelectedDate = DateTime.Today;
            TNumberWeeks.IsReadOnly = true;
            MainWindowModel.currentView = 1;

        }

        private void startCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)//Whenever a date is selected
        {
            if (TSemesterStartDate != null)
            {
                //Calculate the semester end day
                DateTime currDay = (DateTime)startCalendar.SelectedDate;
                DateTime endDay = (DateTime)startCalendar.SelectedDate;
                DateTime answer = endDay.AddDays(NumWeeks.Value * 7);
                StartModel.semesterEndDate = answer;

                //Returning only date and removing time aspect
                TSemesterStartDate.Text = startCalendar.SelectedDate.ToString().Substring(0, 10);
                TSemesterEndDate.Text = StartModel.semesterEndDate.ToString().Substring(0, 10);
                TDayOfWeek.Text = currDay.ToString("dddd") + " ," + currDay.ToString("dd");
            }

        }

        private void NumWeeks_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)//Whenever the slider is moved
        {
            DateTime endDay;
            if (startCalendar.SelectedDate == null)//If the calendar is not initialized
            {
                StartModel.semesterStartDate = DateTime.Today;
                endDay = DateTime.Today;
            }
            else
            {
                StartModel.semesterStartDate = (DateTime)startCalendar.SelectedDate;
                endDay = (DateTime)startCalendar.SelectedDate;
            }
            StartModel.semesterWeeks = NumWeeks.Value;

            //Calculate the semester end day
            DateTime answer = endDay.AddDays(NumWeeks.Value * 7);
            StartModel.semesterEndDate = answer;
            TSemesterEndDate.Text = StartModel.semesterEndDate.ToString().Substring(0, 10);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            StartModel.semesterStartDate = (DateTime)startCalendar.SelectedDate;
            StartModel.semesterPeriodDone = true;//alert mainwindow that the user has completed the first view
            CalendarModel cm = new CalendarModel();
            Thread popDates = new Thread(new ThreadStart(cm.usedDates));
            popDates.Start();
        }
    }
}
