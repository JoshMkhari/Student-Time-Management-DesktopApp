using _20104681PROG6212JoshMkhari.Logic;
using _20104681PROG6212JoshMkhari.MVVM.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace _20104681PROG6212JoshMkhari.MVVM.View
{
    /// <summary>
    /// Interaction logic for ViewModules.xaml
    /// </summary>
    public partial class ViewModules : UserControl
    {
        String moduleCode;
        public ViewModules()
        {
            InitializeComponent();
            display();
            if (UserModel.signedIn)
            {
                UserModel.SaveDetails();
                ModuleAdderModel mad = new ModuleAdderModel();
                mad.retrieveModules();
                UserModel.signedIn = false;
            }

            TChosenHours.IsReadOnly = true;
            if (CalendarModel.inProcess)//If the user is trying to add study hours
            {
                //display these object
                AddHours.Visibility = Visibility.Visible;
                AddHours.IsEnabled = true;
                TSelectHours.Visibility = Visibility.Visible;
                DPanelHours.Visibility = Visibility.Visible;
                TChosenHours.Visibility = Visibility.Visible;
                Back.Visibility = Visibility.Visible;
                TCurrentDate.Text = "To study on: " + CalendarModel.SDate.ToString("D");
                TCurrentDate.Visibility = Visibility.Visible;
                //Hide this object
                AddModule.Visibility = Visibility.Hidden;
                MainWindowModel.currentView = 5;
            }
            else
            {
                //Hide these objects
                AddHours.Visibility = Visibility.Hidden;
                AddHours.IsEnabled = false;
                TSelectHours.Visibility = Visibility.Hidden;
                TChosenHours.Visibility = Visibility.Hidden;
                DPanelHours.Visibility = Visibility.Hidden;
                Back.Visibility = Visibility.Hidden;
                TCurrentDate.Visibility = Visibility.Hidden;

                //Display this object
                AddModule.Visibility = Visibility.Visible;
                MainWindowModel.currentView = 2;

            }

            //thread to update used dates
        }

        public void display()//used to display every module stored within module list
        {
            String fakeTab = "          ";
            for (int i = 0; i < Program.stored; i++)
            {
                if (!Program.chosenIDs.Contains(i))//repeat for the length of stored modules, checking ID
                {
                    var currentModule = from m in Program.moduleList
                                        where m.moduleID == i
                                        select new { m.codes, m.credits, m.selfHours, m.hours };//Retrieving relevant data for ID

                    foreach (var item in currentModule)//Displaying the data from ID
                        LDisplayModules.Items.Add(item.codes + "\t\t" + fakeTab + item.credits + "\t\t\t" + fakeTab + item.hours + "\t\t\t" + fakeTab + item.selfHours);
                }
            }
        }


        private void AddHours_Click(object sender, RoutedEventArgs e)
        {
            if (LDisplayModules.SelectedIndex == -1)//Warn the user that they have not selected a module
            {
                MessageBox.Show("Select a module to continue", "No Module selected!", MessageBoxButton.OK, MessageBoxImage.Warning);
                updater.Value = 5;
            }
            else
            {
                storeSelection();
                CalendarModel.ModuleCode = moduleCode;
                CalendarModel.ModuleHours = Convert.ToInt32(NumChosenHours.Value);
                CalendarModel.attemptToCancel = false;
                CalendarModel cm = new CalendarModel();
                cm.dateStorer();
                updater.Value = 3;
            }
        }

        void storeSelection()//Uses module ID and ListBox index to find the module the user has selected
        {
            var currentModule = from m in Program.moduleList
                                where m.moduleID == LDisplayModules.SelectedIndex
                                select new { m.codes };
            foreach (var item in currentModule)
            {
                moduleCode = item.codes;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            CalendarModel.inProcess = false;//The adding of a module is no longer in process
            CalendarModel.attemptToCancel = false;//As the user is not trying to illegally leave the view
        }
    }
}
