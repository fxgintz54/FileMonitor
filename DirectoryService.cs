using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMonitor
{
    interface IDirectoryService
    {
        bool IsUpToDate(string directoryName);
    }
    class DirectoryService
    {
        private List<DirectoryConfig> DirectoryConfigs;

        public DirectoryService(List<DirectoryConfig> directoryConfigs)
        {
            DirectoryConfigs = directoryConfigs;
        }
    }
}
