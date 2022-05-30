using _20104681PROG6212JoshMkhari.MVVM.ViewModel;
using System;
using System.Windows.Input;

namespace _20104681PROG6212JoshMkhari.Commands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Allows for the changing of views
    /// </summary>
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;
        private static MainViewModel currentView;

        public UpdateViewCommand(MainViewModel viewModel) //For Main View Model
        {
            this.viewModel = viewModel;
            currentView = viewModel;
        }

        public UpdateViewCommand(StartViewModel startViewModel)//For Semester Start View Model
        {
            this.viewModel = currentView;
        }

        public UpdateViewCommand(ModuleAdderViewModel moduleAdderViewModel) //For Adding Modules View Model
        {
            this.viewModel = currentView;
        }

        public UpdateViewCommand(ViewModulesViewModel viewModulesViewModel)//For Viewing Modules View Model
        {
            this.viewModel = currentView;
        }

        public UpdateViewCommand(CalendarViewModel calendarViewModel)////For Viewing Calendar View Model
        {
            this.viewModel = currentView;
        }

        public UpdateViewCommand(LoginViewModel loginViewModel)
        {
            this.viewModel = currentView;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            /*
             * Case: int (Used by a slider named updater on multiple views to change the current view)
             * Case: string (Whenever a view only has one path there is no need for an updater slider)
             */
            switch (parameter.ToString())
            {
                case "1":
                case "Start":
                    viewModel.SelectedViewModel = new StartViewModel();
                    break;
                case "4":
                case "ModuleAdder":
                    viewModel.SelectedViewModel = new ModuleAdderViewModel();
                    break;
                case "5":
                case "ViewModules":
                    viewModel.SelectedViewModel = new ViewModulesViewModel();
                    break;
                case "Calendar":
                case "3":
                    viewModel.SelectedViewModel = new CalendarViewModel();
                    break;
                case "Login":
                case "6":
                    viewModel.SelectedViewModel = new LoginViewModel();
                    break;
            }
        }
    }
}
