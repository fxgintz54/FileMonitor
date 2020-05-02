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
        public FileExplorerForm(IFileExplorerViewModel _viewModel)
        {
            InitializeComponent();
            ViewModel = _viewModel;
        }

        private void LoadTreeView(object sender, EventArgs e)
        {
            fileExplorerTreeView.Nodes.Clear();
            var myDirectoryTree = ViewModel.CreateDirectoryTree();
            fileExplorerTreeView.Nodes.Add(LoadTreeViewNode(myDirectoryTree.Root));
        }

        private TreeNode LoadTreeViewNode(DirectoryNode directoryNode)
        {
            var myTreeNode = new TreeNode(directoryNode.Name + DaysOldStringBuilder(directoryNode));
            myTreeNode.BackColor = directoryNode.IsMonitoredDirectory ? (directoryNode.IsUpToDate ? Color.LimeGreen : Color.Tomato) : Color.Transparent;
            foreach (var child in directoryNode.Children)
                myTreeNode.Nodes.Add(LoadTreeViewNode(child));
            return myTreeNode;
        }

        private string DaysOldStringBuilder(DirectoryNode directoryNode)
        {
            string daysOldString = "";
            if (!directoryNode.IsMonitoredDirectory)
                return daysOldString;
            int TotalDaysOld = (int)(DateTime.Now - directoryNode.Timestamp).TotalDays;
            int daysOld, monthsOld, yearsOld;
            string dayLabel, monthLabel, yearLabel;
            if (TotalDaysOld > 0)
                if (TotalDaysOld > 365)
                {
                    yearsOld = TotalDaysOld / 365;
                    yearLabel = yearsOld > 1 ? "years" : "year";
                    monthsOld = (TotalDaysOld % 365) / 30;
                    monthLabel = monthsOld > 1 ? "months" : "month";
                    if (monthsOld > 0)
                        daysOldString = $" ({yearsOld} {yearLabel} and {monthsOld} {monthLabel} old)";
                    else
                        daysOldString = $" ({yearsOld} {yearLabel} old)";
                }
                else if (TotalDaysOld > 30)
                {
                    monthsOld = TotalDaysOld / 30;
                    monthLabel = monthsOld > 1 ? "months" : "month";
                    daysOld = TotalDaysOld % 30;
                    dayLabel = daysOld > 1 ? "days" : "day";
                    if (daysOld > 0)
                        daysOldString = $" ({monthsOld} {monthLabel} and {daysOld} {dayLabel} old)";
                    else
                        daysOldString = $" ({monthsOld} {monthLabel} old)";
                }
                else
                    if (TotalDaysOld > 1)
                    daysOldString = $" ({TotalDaysOld} days old)";
                    else
                        daysOldString = $" ({TotalDaysOld} day old)";
            return daysOldString;
        }
        
    }
}
