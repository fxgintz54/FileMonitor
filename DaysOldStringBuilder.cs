using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMonitor
{
    public class DaysOldStringBuilder
    {
        public string BuildString(DirectoryNode directoryNode)
        {
            string daysOldString = "";
            if (!directoryNode.IsMonitoredDirectory)
                return daysOldString;
            int TotalDaysOld = (int)(DateTime.Now - directoryNode.Timestamp).TotalDays;
            int daysOld, monthsOld, yearsOld;
            string dayLabel, monthLabel, yearLabel;
            if (TotalDaysOld > 0)
                if (TotalDaysOld > 365)
                {
                    yearsOld = TotalDaysOld / 365;
                    yearLabel = yearsOld > 1 ? "years" : "year";
                    monthsOld = (TotalDaysOld % 365) / 30;
                    monthLabel = monthsOld > 1 ? "months" : "month";
                    if (monthsOld > 0)
                        daysOldString = $" ({yearsOld} {yearLabel} and {monthsOld} {monthLabel} old)";
                    else
                        daysOldString = $" ({yearsOld} {yearLabel} old)";
                }
                else if (TotalDaysOld > 30)
                {
                    monthsOld = TotalDaysOld / 30;
                    monthLabel = monthsOld > 1 ? "months" : "month";
                    daysOld = TotalDaysOld % 30;
                    dayLabel = daysOld > 1 ? "days" : "day";
                    if (daysOld > 0)
                        daysOldString = $" ({monthsOld} {monthLabel} and {daysOld} {dayLabel} old)";
                    else
                        daysOldString = $" ({monthsOld} {monthLabel} old)";
                }
                else
                    if (TotalDaysOld > 1)
                    daysOldString = $" ({TotalDaysOld} days old)";
                else
                    daysOldString = $" ({TotalDaysOld} day old)";
            return daysOldString;
        }
    }
}
