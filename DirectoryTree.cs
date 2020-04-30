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
        public DirectoryNode(string name, bool isDirectory, bool isUpToDate)
        {
            Name = name;
            IsDirectory = isDirectory;
            IsUpToDate = isUpToDate;
            Children = new List<DirectoryNode>();
        }

        public string Name { get; }
        public bool IsDirectory { get; }

        public bool IsUpToDate { get; }

        public List<DirectoryNode> Children { get; }
    }
}
