using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMonitor
{
    class DirectoryConfig
    {
        
        public DirectoryConfig(string id, FrequencyDays frequency, string fileNamePattern)
        {
            Id = id;
            Frequency = frequency;
            FileNamePattern = fileNamePattern;
        }

        
        // full path of the directory
        public string Id { get; }
        public FrequencyDays Frequency { get; }
        public string FileNamePattern { get; }

    }

    enum FrequencyDays : int
    {
        Monthly = 30,
        Quarterly = 90,
        Yearly = 360
    }
}
