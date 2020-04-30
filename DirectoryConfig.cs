using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMonitor
{
    class DirectoryConfig
    {
        public DirectoryConfig(string name, int frequency, string pattern)
        {
            Name = name;
            Frequency = frequency;
            Pattern = pattern;
        }

        public string Name { get; }
        public int Frequency { get; }
        public string Pattern { get; }

    }
}
