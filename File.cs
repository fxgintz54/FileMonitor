using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMonitor
{
    class File
    {
        public File(DateTime date)
        {
            Date = date;
        }

        public DateTime Date { get; }
    }
}
