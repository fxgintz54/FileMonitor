using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMonitor
{
    public class DirectoryTree
    {

        public DirectoryTree(DirectoryNode node)
        {
            Root = node;
        }

        public DirectoryNode Root { get; }

    }

    public class DirectoryNode
    {
        public DirectoryNode(string name, DateTime timestamp, bool isMonitoredDirectory, bool isUpToDate)
        {
            Name = name;
            Timestamp = timestamp;
            IsMonitoredDirectory = isMonitoredDirectory;
            IsUpToDate = isUpToDate;
            Children = new List<DirectoryNode>();
        }

        public string Name { get; set; }

        public DateTime Timestamp { get; set; }
        public bool IsMonitoredDirectory { get; set; }

        public bool IsUpToDate { get; set; }

        public List<DirectoryNode> Children { get; }
    }
}
