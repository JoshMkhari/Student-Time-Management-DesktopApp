using _20104681PROG6212JoshMkhari.Logic;
using _20104681PROG6212JoshMkhari.MVVM.Model;
using System;
using System.Windows;
using System.Windows.Controls;


namespace _20104681PROG6212JoshMkhari.MVVM.View
{
    /// <summary>
    /// Interaction logic for ModuleAdder.xaml
    /// </summary>
    public partial class ModuleAdder : UserControl
    {
        public ModuleAdder()
        {
            InitializeComponent();
            TForCredits.IsReadOnly = true;
            TForHours.IsReadOnly = true;
            TModuleCode.Focus();
            MainWindowModel.currentView = 4;
            //TCredits.IsReadOnly = true;
            //Thours.IsReadOnly = true;
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Boolean codePass = false;
            Boolean namePass = false;
            if (Program.ValidateInput(1, TModuleCode.Text))//Check if the ModuleCode entered is valid
            {
                codePass = true;
                TModuleCode.BorderBrush = System.Windows.Media.Brushes.Black;
            }
            else
            {
                TModuleCode.BorderBrush = System.Windows.Media.Brushes.Red;
                TModuleCode.Focus();
            }

            if (Program.ValidateInput(2, TModuleName.Text))//Check if the ModuleName entered is valid
            {
                TModuleName.BorderBrush = System.Windows.Media.Brushes.Black;
                namePass = true;
            }
            else
            {
                TModuleName.BorderBrush = System.Windows.Media.Brushes.Red;
                TModuleName.Focus();
            }
            if (namePass && codePass)//if all are true
            {
                ModuleAdderModel.ModuleCode = TModuleCode.Text;
                ModuleAdderModel.ModuleName = TModuleName.Text;
                ModuleAdderModel.NumberOfCredits = Convert.ToInt32(CreditsNum.Value);
                ModuleAdderModel.ClassHoursPerWeek = Convert.ToInt32(HoursNum.Value);
                updater.Value = ModuleAdderModel.populateModule();//Check if the module is valid, if so change view to ViewModules View
            }
            else
            {
                updater.Value = 4;//Set current view to Module Adder view
            }


        }

        //Focus property events for the help text box
        //Will trigger if the user selects any textbox or slider

        private void TModuleCode_GotFocus(object sender, RoutedEventArgs e)
        {
            TDisplayHelp.Text = "A module code: \n\n Code must be 8 Characters long\n First 4 characters uppercase letters \n eg: CLDV \n Last 4 characters must be numerical \n eg:1111 \n Example input: CLDV1111";
        }

        private void TModuleName_GotFocus(object sender, RoutedEventArgs e)
        {
            TDisplayHelp.Text = "A module name: \n\n Name must be at least 3 Characters long \n\n Example input: Cloud Development 2A";
        }

        private void TForCredits_GotFocus(object sender, RoutedEventArgs e)
        {
            TDisplayHelp.Text = "Number of credits: \n\n The number of credits for the module \n\n Example input: 15";
        }

        private void TForHours_GotFocus(object sender, RoutedEventArgs e)
        {
            TDisplayHelp.Text = "Number of class hours: \n\n The number of class hours per \n week for the module \n\n Example input: 5";
        }
    }
}
