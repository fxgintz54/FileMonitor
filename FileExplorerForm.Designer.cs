namespace FileMonitor
{
    partial class FileExplorerForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileExplorerTreeView = new System.Windows.Forms.TreeView();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileExplorerTreeView
            // 
            this.fileExplorerTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileExplorerTreeView.Location = new System.Drawing.Point(12, 42);
            this.fileExplorerTreeView.Name = "fileExplorerTreeView";
            this.fileExplorerTreeView.Size = new System.Drawing.Size(540, 424);
            this.fileExplorerTreeView.TabIndex = 0;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(12, 12);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 1;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.LoadTreeView);
            // 
            // FileExplorerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 478);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.fileExplorerTreeView);
            this.Name = "FileExplorerForm";
            this.Text = "FileExplorer";
            this.Load += new System.EventHandler(this.LoadTreeView);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView fileExplorerTreeView;
        private System.Windows.Forms.Button RefreshButton;
    }
}

