using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMonitor
{
    class DirectoryConfig
    {
        public DirectoryConfig(int frequency, string pattern)
        {
            Frequency = frequency;
            Pattern = pattern;
        }

        public int Frequency { get; }
        public string Pattern { get; }

    }
}
