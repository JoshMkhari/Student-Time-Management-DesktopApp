﻿using System;

namespace _20104681PROG6212JoshMkhari.MVVM.Model
{
    /*
     * Class Summary
     * 
     * Store all data from the StartVeiw
     */
    class StartModel
    {

        public static Boolean semesterPeriodDone { get; set; }//Stores whether the user has completed the first view or not
        public static DateTime semesterStartDate { get; set; }//Stores the semester start date
        public static double semesterWeeks { get; set; }//stores the number of weeks within the semester
        public static DateTime semesterEndDate { get; set; }//stores the semester end date

        public static String[] Users = new string[2];

        public static void Reset()
        {
            semesterPeriodDone = false;
            semesterStartDate = DateTime.Today;
            semesterEndDate = DateTime.Today;
            semesterWeeks = 1;
        }
    }
}
