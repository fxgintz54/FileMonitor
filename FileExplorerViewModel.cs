using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMonitor
{
    public interface IFileExplorerViewModel
    {
        DirectoryTree CreateDirectoryTree();
    }
    class FileExplorerViewModel : IFileExplorerViewModel
    {
        const string documentsDirecory = "C:\\Users\\franc\\Documents\\e-Documents";
        private static DirectoryService _DirectoryService;

        public FileExplorerViewModel(DirectoryService directoryService)
        {
            _DirectoryService = directoryService;
        }

        public DirectoryTree CreateDirectoryTree()
        {
            var rootDirectoryInfo = new DirectoryInfo(documentsDirecory);
            var myDirectoryTree = new DirectoryTree(CreateDirectoryNode(rootDirectoryInfo));
            return myDirectoryTree;
        }

        private static DirectoryNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var myDirectoryNode = new DirectoryNode(directoryInfo.Name, new DateTime(), false, false);
            foreach (var directory in directoryInfo.GetDirectories())
                myDirectoryNode.Children.Add(CreateDirectoryNode(directory));
            if (directoryInfo.GetFiles().Length > 0)
                myDirectoryNode.IsMonitoredDirectory = true;
            foreach (var file in directoryInfo.GetFiles())
            {
                DateTime fileTimestamp = _DirectoryService.FileTimestamp(file);
                if (fileTimestamp > myDirectoryNode.Timestamp)
                    myDirectoryNode.Timestamp = fileTimestamp;
                myDirectoryNode.Children.Add(new DirectoryNode(file.Name, fileTimestamp, false, true));
            }
            bool directoryIsUpToDate = _DirectoryService.DirectoryIsUpToDate(myDirectoryNode);
            myDirectoryNode.IsUpToDate = directoryIsUpToDate;
            return myDirectoryNode;
        }
    }
}
