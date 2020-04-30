using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMonitor
{
    public partial class FileExplorerForm : Form
    {

        private IFileExplorerViewModel ViewModel;
        public FileExplorerForm(IFileExplorerViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        private void LoadTreeView(object sender, EventArgs e)
        {
            fileExplorerTreeView.Nodes.Clear();
            var myDirectoryTree = ViewModel.CreateDirectoryTree();
            fileExplorerTreeView.Nodes.Add(LoadTreeViewNode(myDirectoryTree.Root));
        }

        private TreeNode LoadTreeViewNode(DirectoryNode directoryNode)
        {
            var myTreeNode = new TreeNode(directoryNode.Name);
            myTreeNode.BackColor = directoryNode.IsDirectory ? (directoryNode.IsUpToDate ? Color.LimeGreen : Color.Tomato) : Color.Transparent;
            foreach (var child in directoryNode.Children)
                myTreeNode.Nodes.Add(LoadTreeViewNode(child));
            return myTreeNode;
        }
        
    }
}
