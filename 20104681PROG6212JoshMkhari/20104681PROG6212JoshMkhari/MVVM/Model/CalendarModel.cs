using _20104681PROG6212JoshMkhari.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace _20104681PROG6212JoshMkhari.MVVM.Model
{
    /*
     * Class summary
     * 
     * Used to store all neccessary data from the Calendar View
     * Performs all calendar related methods for the Calendar View
     */
    class CalendarModel
    {
        public static string SelectedDate { get; set; }//Stores the current selected date from the calendar
        public static DateTime SDate { get; set; }//Stores the date in use for choosing study hours
        public static string ModuleCode { get; set; }//Stores the module code the user selects on the ViewModels View
        public static int ModuleHours { get; set; }//Stores the module hours the user selects on the ViewModels View

        public static Boolean inProcess { get; set; }//Used to alert the ViewModule View of the program on what actions are currently allowed

        public static Boolean attemptToCancel { get; set; }//Used to alert the MainWIndow  of the program on what actions are currently allowed

        public static Boolean addingToDatabase { get; set; }//

        public static IList<StoredDates> datesList = new List<StoredDates>();//stores all modules for a specific day and the date

        public static int planned = 0;

        public DateTime StoreDate;
        public int plan, hours;
        public string code;
        public static void Reset()
        {
            datesList.Clear();
            inProcess = false;
        }
        public void dateStorer()//Used to add a date and the modules for the date
        {

            ProgramDAL dal = new ProgramDAL();
            planned++;
            int moduleHours = 0;
            IList<PlannedModule> istOfModules = new List<PlannedModule>();//Used to keep a temporary copy of the module codes and hours already stored within the dates list for a specific day
            Boolean modFound = false;//used to determine if the current module being stored already exists within the curent dates list of modules
            Boolean datFound = false;//used to determine if the current date being stored already exists within the date list
            int datefound = 0;//Stores the location of the found date from the dates list, used to remove it later as it is replaced with an update for the specific day
            for (int i = 0; i < datesList.Count; i++)//repeat for the current length of the dates list
            {
                var currDate = datesList.ElementAt(i);//store the current element within the dateslist

                if (currDate.storedDate.Equals(SelectedDate))//we found a date that already exists
                {
                    datFound = true;
                    datefound = i;
                    int repeat = currDate.plannedList.Count;//stores the count of modules within the current date
                    List<string> foundCodes = new List<string>();//Stores a list of module codes that already exist for a specific day
                    for (int s = 0; s < repeat; s++)//now we are going to look at each module in found date
                    {
                        var curplan = currDate.plannedList.ElementAt(s);
                        if (curplan.codes.Equals(ModuleCode))//if a module is the same as our current module to add
                        {

                            istOfModules.Add(new PlannedModule()//add that module code and then add its old hours with our new hours
                            {
                                codes = curplan.codes,
                                hours = curplan.hours + ModuleHours
                            });
                            foundCodes.Add(ModuleCode);
                            modFound = true;
                            moduleHours = curplan.hours + ModuleHours;
                        }
                        else
                        {
                            if (!foundCodes.Contains(curplan.codes))// check if our found codes does not contain the current code from the current date 
                            {
                                istOfModules.Add(new PlannedModule()//add that module and the add its code
                                {
                                    codes = curplan.codes,
                                    hours = curplan.hours
                                });
                                foundCodes.Add(curplan.codes);
                                moduleHours = curplan.hours;
                            }

                        }
                    }
                    if (!modFound)//If the day did not have the module we are trying to add
                    {
                        //we want every module stored on said day
                        //istOfModules = currDate.plannedList;// make a copy of the current fays planned modules
                        istOfModules.Add(new PlannedModule()//add our new module and its code
                        {
                            codes = ModuleCode,
                            hours = ModuleHours
                        });
                        datesList.RemoveAt(i);
                        datesList.Add(new StoredDates()
                        {
                            storedDate = SelectedDate,
                            plannedList = istOfModules
                        });
                        break;
                    }
                    break;
                }
            }
            if (!datFound)//If we did not find the current day within our dates list
            {
                //First add the module and code we want for this current day
                istOfModules.Add(new PlannedModule()
                {
                    codes = ModuleCode,
                    hours = ModuleHours
                });

                //add the current day to the dates list
                datesList.Add(new StoredDates()
                {
                    storedDate = SelectedDate,
                    plannedList = istOfModules
                });
                if (addingToDatabase)
                {
                    dal.AddDate(SDate);
                    dal.AddPlanned(planned);
                    dal.AddDateToList(SDate, StartModel.Users[0], planned);
                    dal.AddPlannedList(planned, ModuleCode, ModuleHours);//this is fine
                }

            }
            if (datFound)
            {
                if (modFound)
                {
                    //first remove the previous version of the current day
                    datesList.RemoveAt(datefound);

                    //now add the current day and the updated list of modules which includes the old modules and our new addition
                    datesList.Add(new StoredDates()
                    {
                        storedDate = SelectedDate,
                        plannedList = istOfModules
                    });
                    if (addingToDatabase)
                    {
                        planned = dal.GetCurrentPlanned(SDate, StartModel.Users[0]);
                        dal.UpdatePlannedList(planned, ModuleCode, moduleHours);
                    }
                }
                else
                {
                    datesList.RemoveAt(datefound);

                    //now add the current day and the updated list of modules which includes the old modules and our new addition
                    datesList.Add(new StoredDates()
                    {
                        storedDate = SelectedDate,
                        plannedList = istOfModules
                    });
                    if (addingToDatabase)
                    {
                        planned = dal.GetCurrentPlanned(SDate, StartModel.Users[0]);
                        dal.AddPlannedList(planned, ModuleCode, moduleHours);
                        addingToDatabase = false;
                    }
                }
            }
        }

        public void usedDates()
        {
            ProgramDAL dal = new ProgramDAL();
            List<DateTime> dat = (List<DateTime>)dal.GetAllStoredDates();
            for (int i = 0; i < dat.Count; i++)
            {
                IList<PlannedModule> istOfModules = new List<PlannedModule>();
                datesList.Add(new StoredDates()
                {
                    storedDate = dat.ElementAt(i).ToString().Substring(0, 10),
                    plannedList = istOfModules
                });
            }
        }
        public void populateFromDatabase()
        {

            ProgramDAL dal = new ProgramDAL();
            List<CalendarModel> datList = (List<CalendarModel>)dal.GetAllStoredDates(StartModel.Users[0]);
            for (int i = 0; i < datList.Count; i++)
            {
                IList<PlannedModule> istOfModules = new List<PlannedModule>();//Used to keep a temporary copy of the module codes and hours already stored within the dates list for a specific day
                List<CalendarModel> data = (List<CalendarModel>)dal.GetModuleHours(datList.ElementAt(i).plan);
                for (int s = 0; s < data.Count; s++)
                    istOfModules.Add(new PlannedModule()//add that module and the add its code
                    {
                        codes = data.ElementAt(s).code,
                        hours = data.ElementAt(s).hours
                    });
                datesList.Add(new StoredDates()
                {
                    storedDate = datList.ElementAt(i).StoreDate.ToString().Substring(0, 10),
                    plannedList = istOfModules
                });
            }

            if (datList.Count == 0)
            {
                usedDates();
            }
            addingToDatabase = true;
        }
    }


}
