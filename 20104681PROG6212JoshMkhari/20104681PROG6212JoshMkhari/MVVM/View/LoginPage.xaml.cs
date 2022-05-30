using _20104681PROG6212JoshMkhari.MVVM.Model;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace _20104681PROG6212JoshMkhari.MVVM.View
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : UserControl
    {
        public LoginPage()
        {
            InitializeComponent();
            BtnSignUp.Visibility = Visibility.Hidden;
            BtnLogin.Visibility = Visibility.Hidden;
            BtnSignUp.IsEnabled = false;
            BtnLogin.IsEnabled = false;
            UserModel.populateUsersList();

        }

        private void TUserName_GotFocus(object sender, RoutedEventArgs e)
        {
            TDisplayHelp.Text = "A user name: \n\n Enter a  \n\n Example input: Josh";
        }

        private void TPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            TDisplayHelp.Text = "A user password: \n\n Enter the matching password \n\n Example input: Josh";
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (TUserName.Text.Length == 0)
            {
                MessageBox.Show("Enter a username", "Username Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (UserModel.checkLogin(TUserName.Text, TPassword.Text))
                {
                    ModuleAdderModel mad = new ModuleAdderModel();
                    Thread retModules = new Thread(new ThreadStart(mad.retrieveModules));
                    retModules.Start();
                    CalendarModel cm = new CalendarModel();
                    Thread popDates = new Thread(new ThreadStart(cm.populateFromDatabase));
                    popDates.Start();
                    updater.Value = 5;
                    StartModel.Users[0] = TUserName.Text;
                    UserModel.loggedIn = true;
                    Thread.Sleep(400);
                }
                else
                {
                    updater.Value = 6;
                    MessageBox.Show("Incorrect Login would you like to signup instead", "Login Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            ;
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("To sign up, enter a user name and set a password", "Sign Up", MessageBoxButton.OK, MessageBoxImage.Warning);
            TViewName.Text = "     Sign Up";
            SignUp.Visibility = Visibility.Hidden;
            Login.Visibility = Visibility.Hidden;
            SignUp.IsEnabled = false;
            Login.IsEnabled = false;

            BtnLogin.Visibility = Visibility.Visible;
            BtnSignUp.Visibility = Visibility.Visible;
            BtnSignUp.IsEnabled = true;
            BtnLogin.IsEnabled = true;

            //     Login Page
        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (TUserName.Text.Length == 0)
            {
                MessageBox.Show("Enter a username", "Username Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (UserModel.SignUp(TUserName.Text, TPassword.Text))
                {
                    updater.Value = 1;
                    UserModel.loggedIn = true;
                    UserModel.signedIn = true;
                    //take to calendar model
                }
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("To Login, enter a user name and a matching password", "Login", MessageBoxButton.OK, MessageBoxImage.Warning);
            TViewName.Text = "     Login Page";
            SignUp.Visibility = Visibility.Visible;
            Login.Visibility = Visibility.Visible;
            SignUp.IsEnabled = true;
            Login.IsEnabled = true;

            BtnLogin.Visibility = Visibility.Hidden;
            BtnSignUp.Visibility = Visibility.Hidden;
            BtnSignUp.IsEnabled = false;
            BtnLogin.IsEnabled = false;
        }

    }
}
