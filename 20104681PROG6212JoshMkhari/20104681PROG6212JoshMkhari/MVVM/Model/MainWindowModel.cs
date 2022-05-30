namespace _20104681PROG6212JoshMkhari.MVVM.Model
{
    class MainWindowModel
    {
        public static int currentView { get; set; }

        public static string displayHelp()
        {
            //chech what view we are on

            switch (currentView)
            {
                case 1: //Start
                    return "Steps to complete the Semester Period\n\n" +
                        "1)	Use the calendar to select a date the semester will start on.\n" +
                        "\ta.	You can use the right and left arrow keys to change months.\n" +
                        "2)	Once a date has been selected, simply move the slider to determine the number of weeks in the semester.\n" +
                        "3)	Review the Start Date and End date to be sure of the semester period.\n" +
                        "4)	Click on the “Set Semester” button to continue.";
                case 2: //View Modules (add Module)
                    return "Options \n\n" +
                        "1)	Click on the “Add Module” button to begin the module adding process.\n" +
                        "2)	Click on “Calendar” to view the semester calendar.\n" +
                        "3)	Click on “Reset” to clear all program data, this will delete all modules and semester settings.";
                case 3: //Calendar
                    return "Calendar help\n\n" +
                        "1)	First select a date on the calendar.\n" +
                        "\ta.	If the date already has planned modules, they will show on the top left alongside their respective chosen hours.\n" +
                        "\tb.	If the selected date has no planned modules, you can click on “Add Hours” to begin the module planning process.\n" +
                        "2)	The white square will display module information for the current week based on the day selected on the calendar.\n" +
                        "\ta.	This will display the remaining hours of self-study based on the number of hours you have already planned to study for the week.\n" +
                        "\tb.	If you have not added a module, the white square will display no modules.";
                case 4: //Module Adder
                    return "How to add Modules\n\n" +
                        "1)	Enter a valid module code such as, “ADDB1111”\n" +
                        "\ta.	Module codes must be in uppercase\n" +
                        "2)	Enter a valid module name such as, “Management”\n" +
                        "3)	Use the sliders to set module credits and hours respectively\n" +
                        "4)	Click on “Add Module” to add the module.\n" +
                        "5)	Click on “Back” to go back.\n";
                case 5: //View Modules (add Hours)
                    return "How to plan hours for a module\n\n" +
                        "1)	Select a module from the list.\n" +
                        "2)	Use the slider to determine the hours of study\n" +
                        "3)	Click on “Add Hours” to add the hours of study for the specified module.\n" +
                        "4)	Click “Back” to go back and select a different date.";
                case 6: //Sign Up
                    return "How to Login/Sign up\n\n" +
                        "1)	Enter your username\n" +
                        "2)	Enter your password\n" +
                        "3)	Click on “Log in/sign up” to login/signup with the above username/password.\n" +
                        "4)	Click “Or Signup/Log in” to instead use the above username/password to login/signup";
                default:
                    return "help";
            }
        }
    }
}
