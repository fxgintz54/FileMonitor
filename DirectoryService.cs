using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileMonitor
{
    interface IDirectoryService
    {
        bool DirectoryIsUpToDate(DirectoryNode directoryNode);
        DateTime FileTimestamp(FileInfo file);
    }
    class DirectoryService
    {
        // private List<DirectoryConfig> DirectoryConfigs;

        //public DirectoryService(List<DirectoryConfig> directoryConfigs)
        //{
        //    DirectoryConfigs = directoryConfigs;
        //}
        public DateTime FileTimestamp(FileInfo file)
        {
            Match matchExpression;
            if (file.Name.StartsWith("eP60"))
            {
                matchExpression = Regex.Match(file.Name, @"eP60-\d{4}-(\d{4})");
                int year = Int32.Parse(matchExpression.Groups[1].Value);
                return new DateTime(year, 5, 1);
            }
            if (file.Name.StartsWith("Payslip"))
            {
                matchExpression = Regex.Match(file.Name, @"Payslip_(\d{4})-\d{4}_(\d{2})");
                int financialMonth = Int32.Parse(matchExpression.Groups[2].Value);
                int financialYear = Int32.Parse(matchExpression.Groups[1].Value);
                return calendarDatefromFinancialDate(financialMonth, financialYear);
            }
            else
                return file.LastWriteTime; // Windows file timestamp by default
        }

        public bool DirectoryIsUpToDate(DirectoryNode directoryNode)
        {
            if (directoryNode.Name == "p60")
                return ((DateTime.Now - directoryNode.Timestamp).TotalDays < 360) ? true : false;
            if (directoryNode.Name == "Payslips")
                return ((DateTime.Now - directoryNode.Timestamp).TotalDays < 30) ? true : false;
            return false;
        }

        private DateTime calendarDatefromFinancialDate(int financialMonth, int financialYear)
        {
            if (financialMonth < 10)
                return new DateTime(financialYear, financialMonth + 3, 25);
            else
                return new DateTime(financialYear + 1, financialMonth - 9, 25);
        }
    }
}
