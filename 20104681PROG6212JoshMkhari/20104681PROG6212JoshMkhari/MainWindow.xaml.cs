using _20104681PROG6212JoshMkhari.Logic;
using _20104681PROG6212JoshMkhari.MVVM.Model;
using _20104681PROG6212JoshMkhari.MVVM.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace _20104681PROG6212JoshMkhari
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            var viewModel = (MainViewModel)DataContext;
            if (viewModel.UpdateViewCommand.CanExecute("Login"))
            { viewModel.UpdateViewCommand.Execute("Login"); }
        }


        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mBoxResult = MessageBox.Show("Are you sure you want to close this application? All your data will be lost", "Exit app", MessageBoxButton.OKCancel, MessageBoxImage.Warning); ;
            if (mBoxResult == MessageBoxResult.OK)
            {
                Close();
            }

        }

        private void CalendarRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (StartModel.semesterPeriodDone)
            {
                if (!CalendarModel.attemptToCancel)
                {
                    updater.Value = 3;
                }
            }
            else
            {
                if (UserModel.loggedIn)
                {
                    MessageBox.Show("No data to display, First set a semester period", "Calendar Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                    updater.Value = 1;
                }
                else
                {
                    MessageBox.Show("No data to display, First login", "User Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                    updater.Value = 6;
                }
                ModulesRadio.IsChecked = true;
            }

        }

        private void ResetRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (UserModel.loggedIn || UserModel.signedIn)
            {
                if (StartModel.semesterPeriodDone)
                {
                    //Ask if sure
                    MessageBoxResult mBoxResult = MessageBox.Show("Are you sure? This action will clear all data stored for all users", "Reset Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning); ;
                    if (mBoxResult == MessageBoxResult.Yes)
                    {
                        StartModel.Reset();
                        Program.ResetModuleList();
                        CalendarModel.Reset();
                        UserModel.Reset();
                        ModuleAdderModel.Reset();
                        updater.Value = 6;
                    }
                    else
                    {
                        updater.Value = 2;//show modules
                    }
                    ModulesRadio.IsChecked = true;
                }
                else
                {
                    MessageBox.Show("No data to reset, First set a semester period", "Reset Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                    updater.Value = 1;//information, you need to set a semester period before you can reset the app
                    ModulesRadio.IsChecked = true;
                }
            }
            else
            {
                MessageBox.Show("You must be a logged in user to use this feature", "Reset Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                updater.Value = 6;//information, you need to set a semester period before you can reset the app
                ModulesRadio.IsChecked = true;
            }

        }

        private void ModulesRadio_Click(object sender, RoutedEventArgs e)
        {
            if (StartModel.semesterPeriodDone)
            {
                updater.Value = 5;
                if (CalendarModel.inProcess)
                {
                    CalendarModel.attemptToCancel = true;
                    CalendarRadio.IsChecked = true;
                    MessageBox.Show("Finish current process to comtinue or click back to stop", "Calendar Process", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            else
                if (UserModel.loggedIn)
            {
                updater.Value = 5;
            }
            else
            {
                MessageBox.Show("No data to display, First login", "User Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                updater.Value = 6;
            }
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(MainWindowModel.displayHelp(), "Help", MessageBoxButton.OK, MessageBoxImage.Information);
            ;
        }
    }
}
