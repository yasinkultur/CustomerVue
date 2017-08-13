using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace CustomerVue.Code
{
    public static class Utilities
    {
        public readonly static string Version = typeof(MvcApplication).Assembly.GetName().Version.ToString(1);



        public static string GetRelativeDateText(DateTimeOffset date)
        {
            TimeSpan span = DateTimeOffset.Now.Subtract(date);

            // Number of days
            if (span.TotalDays >= 1)
            {
                return GetPluralisedTimeSpan((int)span.TotalDays, "day") + " ago";
            }
            else if (span.Hours >= 1)
            {
                return GetPluralisedTimeSpan((int)span.TotalHours, "hour") + " ago";
            }
            else if (span.Minutes >= 1)
            {
                return GetPluralisedTimeSpan((int)span.TotalMinutes, "minute") + " ago";
            }
            else
            {
                return "less than 1 minute ago";
            }
        }

        private static string GetPluralisedTimeSpan(int value, string description)
        {
            return String.Format("{0:#,##0} {1}",
                value, (value == 1) ? description : String.Format("{0}s", description));
        }
    }
}