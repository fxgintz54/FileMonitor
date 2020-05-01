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

        public DirectoryTree CreateDirectoryTree()
        {
            var rootDirectoryInfo = new DirectoryInfo(documentsDirecory);
            var myDirectoryTree = new DirectoryTree(CreateDirectoryNode(rootDirectoryInfo));
            return myDirectoryTree;
        }

        private static DirectoryNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var myDirectoryNode = new DirectoryNode(directoryInfo.Name, new DateTime(), true, false);
            foreach (var directory in directoryInfo.GetDirectories())
                myDirectoryNode.Children.Add(CreateDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles())
            {
                if (file.LastWriteTime > myDirectoryNode.Timestamp)
                    myDirectoryNode.Timestamp = file.LastWriteTime;
                myDirectoryNode.Children.Add(new DirectoryNode(file.Name, file.LastWriteTime, false, true));
            }
            return myDirectoryNode;
        }
    }
}
